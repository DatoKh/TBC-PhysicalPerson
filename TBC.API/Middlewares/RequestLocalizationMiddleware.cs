using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TBC.Common.Constants;

namespace TBC.API.Middlewares
{
    public class RequestLocalizationMiddleware
    {
        private readonly RequestDelegate _next;
         
        public RequestLocalizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
         
        public async Task Invoke(HttpContext context)
        {
            var userLangs = context.Request.Headers["Accept-Language"].ToString().Split(',');

            var lang = CultureConfigs.DefaultCulture;
            if (userLangs.Any(x => x.Contains(CultureConfigs.SecondaryCulture)))
                lang = CultureConfigs.SecondaryCulture;

            var cultureInfo = new CultureInfo(lang);
            cultureInfo.DateTimeFormat.ShortDatePattern = CultureConfigs.ShortDatePattern;
            cultureInfo.DateTimeFormat.ShortTimePattern = CultureConfigs.ShortTimePattern;
            cultureInfo.DateTimeFormat.LongDatePattern = CultureConfigs.LongDatePattern;
            cultureInfo.DateTimeFormat.LongTimePattern = CultureConfigs.LongTimePattern;
            cultureInfo.DateTimeFormat.DateSeparator = CultureConfigs.DateSeparator;
            cultureInfo.NumberFormat.NumberDecimalSeparator = CultureConfigs.NumberDecimalSeparator;
            cultureInfo.NumberFormat.NumberDecimalDigits = 2;
            cultureInfo.NumberFormat.CurrencyDecimalDigits = 2;

            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            await _next(context);
        }
    }
}
