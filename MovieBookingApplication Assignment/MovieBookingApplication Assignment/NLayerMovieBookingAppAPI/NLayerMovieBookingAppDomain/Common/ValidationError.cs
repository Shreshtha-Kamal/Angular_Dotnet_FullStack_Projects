using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerMovieBookingAppDomain.Common
{
    public class ValidationError
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public ValidationError(string code, string description)
        {
            this.Code = code;
            this.Description = description;
        }
    }
}
