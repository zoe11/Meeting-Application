
namespace FT_ENV
{
    public enum ResCode
    {
        
        Null = -1,
        Correct = 0,
        Exist = 1,
        NotExist = 2,
        SQLError = 3,
        NotNull=4,
        Constaint=9,
        Special=10
    }

    public class Result
    {
        public Result()
        {
            this.Code = ResCode.Correct;
            this.Msg = "";
        }
        
        /*
         * Code -1:空引用
         * Code 0:正常
         * 错误从1开始编号
         * 
         */
        public ResCode Code { get; set; }
        public string Msg { get; set; }
        public object Obj { get; set; }

        public static Result SetResult(object obj, string msg, ResCode code)
        {
            return new Result()
            {
                Obj = obj,
                Msg = msg,
                Code = code
            };
        }

    }

    public class Helper
    {
        public static Result IsNullObj(object obj, string errorMsg)
        {
            var result = new Result();
            if (obj.IsNull())
            {
                result.Code = ResCode.Null;
                result.Msg = errorMsg;
                result.Obj = null;
                return result;
            }
            return result;
        }
        private static bool isClosed = true;
        public static bool IsClosed
        {
            get { return isClosed; }
            set { isClosed = value; }
        }
    }
}
