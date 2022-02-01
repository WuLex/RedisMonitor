using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;

namespace RedisMonitor.Core.Extension
{
    public static class CoreExtension
    {
        private static IHttpContextAccessor _httpContextAccessor;

        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public static HttpContext HttpContext
        {
            get
            {
                return _httpContextAccessor.HttpContext;
            }
        }

        /// <summary>
        /// 出去字母后判断是否为数值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool RelaceIsNum(this string value)
        {
            var newValue = Regex.Replace(value, "[a-zA-Z]", "");
            decimal num;
            return decimal.TryParse(newValue, out num);
        }
    }
}