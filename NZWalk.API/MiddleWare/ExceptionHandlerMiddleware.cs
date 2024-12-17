using System.Net;

namespace NZWalk.API.MiddleWare
{
    public class ExceptionHandlerMiddleware
    {
        private readonly ILogger<ExceptionHandlerMiddleware> logger;
        private readonly RequestDelegate next;
        //Request delegate is return a task that represent the completion of a request processing 
        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger,RequestDelegate next)
        {
            this.logger = logger;
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex) {
                var errorId = Guid.NewGuid();

                //Log the exception
                this.logger.LogError(ex, $"{errorId}:{ ex.Message}");
                //Return a custom Error Message
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";
                var error = new
                {

                    Id= errorId,
                    ErrorMessage ="Something went wrong.we are looking into Resolving this."

                };
                //First convert error object to json object
                await httpContext.Response.WriteAsJsonAsync(error);


            }
        }

    }
}
