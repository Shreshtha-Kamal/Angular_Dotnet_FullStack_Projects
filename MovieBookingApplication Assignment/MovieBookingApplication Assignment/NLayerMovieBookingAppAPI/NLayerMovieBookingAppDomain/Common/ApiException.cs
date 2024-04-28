using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NLayerMovieBookingAppDomain.Common
{
    public class ApiException: Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public Exception Exception { get; set; }
        public ApiException(HttpStatusCode code, Exception exception)
        {
            this.StatusCode = code;
            this.Exception = exception; 
        }
    }
}
