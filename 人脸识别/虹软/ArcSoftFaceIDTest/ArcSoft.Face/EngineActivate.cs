using System;
using System.Collections.Generic;
using System.Text;

namespace ArcSoft.Face
{
   

    /// <summary>
    /// 引擎激活
    /// </summary>
    public class EngineActivate
    {
        public static string AppId = "TLGv6eAQ3ihsBwFwzM9SdtgzS5HLUuL8vfTGGr72wv2";
        public static string AppKey = "5GSobsVbGYosjxGEWLjUM9g1nW7roZT1D36QEhneQLkL";

        //public static string AppId = "H9HdrXNTSxdsr3dJPhS7W4xgAycyHWPz6Sz6ATqEw4oK";
        //public static string AppKey = "CyKUn1ouaeh3fkGfWobtVv9eRDwLUFdCQjBVkUNHFhvR";

        //public static string AppId = "H9HdrXNTSxdsr3dJPhS7W4xgAycyHWPz6Sz6ATqEw4oK";
        //public static string AppKey = "CyKUn1ouaeh3fkGfWobtVv9eUUAdjFa3hMA3BtojW4zq";

        /// <summary>
        /// 激活引擎
        /// </summary>
        /// <param name="appId">appid</param>
        /// <param name="appKey">appkey</param>
        /// <returns>激活结果</returns>
        public static ResultCode ActivateEngine(string appId, string appKey)
        {
            int result = ASFAPI.ASFActivation(appId, appKey);
            return (ResultCode)result;
        }
    }
}
