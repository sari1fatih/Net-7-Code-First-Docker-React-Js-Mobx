namespace Common.Classes.Extensions
{
    public static partial class ObjectExtension
    {
        public static Boolean IsNull(this Object Expr)
        {
            return (Expr == null || Expr == DBNull.Value);
        }

        public static Int32? ToInt32Nullable(this Object Expr)
        {
            Int32? result = null;

            if (Expr.IsNull())
                return result;

            result = Expr is Enum ? (Int32)Expr : Convert.ToInt32(Expr);

            return result;
        }
    }
}

