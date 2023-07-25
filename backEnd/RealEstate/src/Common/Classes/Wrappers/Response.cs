using Common.Enums;
using Newtonsoft.Json;
namespace Common.Classes.Wrappers
{
    public class Response
    {
        public ApiResultEnum apiResultType { get; set; } = ApiResultEnum.Unspecified;
    }

    public class Response<T>
    {
        public Response()
        {
        }
        public Response(T data, string message = null)
        {
            apiResultType = ApiResultEnum.Success;
            this.message = message;
            this.data = data;
        }
        public Response(string message, ApiResultEnum _apiResultType)
        {
            apiResultType = _apiResultType;
            this.message = message;
        }
        [JsonIgnore]
        public int statusCode { get; set; }
        public ApiResultEnum apiResultType { get; set; } = ApiResultEnum.Unspecified;
        public string message { get; set; }
        public T data { get; set; }
    }
}

