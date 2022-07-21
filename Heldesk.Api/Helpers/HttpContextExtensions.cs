using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heldesk.Api.Helpers
{
    public static class HttpContextExtensions
    {
        public static void AddHeaderTotalRecords(this HttpContext httpContext,int totalRecords)
        {
            if(httpContext is null)
                throw new ArgumentException(nameof(httpContext));
            
            httpContext.Response.Headers.Add("TotalRecords", totalRecords.ToString());
        }
    }
}