using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heldesk.Api.Middlewares
{
    public class ExampleMiddleware
    {
        private RequestDelegate _next;

        public ExampleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // try{

            // var form = context.Request.Body;
            // }catch(Exception ex){

            // }

            await _next(context);
        }
    }
}