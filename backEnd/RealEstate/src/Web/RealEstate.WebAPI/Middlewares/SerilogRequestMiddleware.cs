using System.Text;
using Common.Classes.Wrappers;
using Common.Enums;
using Newtonsoft.Json;
using Serilog.Context;

namespace RealEstate.WebAPI.Middlewares
{
    public class SerilogRequestMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<SerilogRequestMiddleware> _logger;

        public SerilogRequestMiddleware(RequestDelegate next, ILogger<SerilogRequestMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            LogContext.PushProperty("ip_address", httpContext.Connection.RemoteIpAddress?.ToString());
            var request = await FormatRequest(httpContext.Request);

            var originalBodyStream = httpContext.Response.Body;

            using (var responseBody = new MemoryStream())
            {
                httpContext.Response.Body = responseBody;
                await _next(httpContext);

                string response = "";
                responseBody.Seek(0, SeekOrigin.Begin);
                using (var reader = new StreamReader(responseBody))
                {

                    response = await FormatResponse(responseBody, reader);
                    WriteSerilog(httpContext.Response, response, request);
                    responseBody.Seek(0, SeekOrigin.Begin);
                    await responseBody.CopyToAsync(originalBodyStream);
                }
            }
        }

        private static async Task<string> FormatRequest(HttpRequest request)
        {
            request.EnableBuffering();

            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer.AsMemory(0, buffer.Length)).ConfigureAwait(false);
            var bodyAsText = Encoding.UTF8.GetString(buffer);

            request.Body.Position = 0;

            return new
            {
                Method = request.Method,
                Scheme = request.Scheme,
                Host = request.Host,
                Path = request.Path,
                QueryString = request.QueryString,
                Body = bodyAsText
            }.ToString();
        }

        private static async Task<string> FormatResponse(MemoryStream responseBody, StreamReader streamReader)
        {
            responseBody.Seek(0, SeekOrigin.Begin);
            return await streamReader.ReadToEndAsync().ConfigureAwait(false);

        }

        private void WriteSerilog(HttpResponse response, string responseBody, string? request)
        {
            LogContext.PushProperty("request", request);
            if (!String.IsNullOrEmpty(responseBody))
            {
                Response serviceResult = JsonConvert.DeserializeObject<Response>(responseBody);


                switch (serviceResult.apiResultType)
                {
                    case ApiResultEnum.Unspecified:
                    case ApiResultEnum.Error:

                        _logger.LogError(responseBody);
                        break;
                    case ApiResultEnum.Warning:
                        _logger.LogWarning(responseBody);
                        break;
                }
            }
            else if (response.StatusCode == 401)
            {
                _logger.LogWarning("Yetkisiz erişim talebinde bulunurdu!");
            }
        }
    }
}

