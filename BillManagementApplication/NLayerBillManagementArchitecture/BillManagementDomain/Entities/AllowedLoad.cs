using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManagementDomain.Entities
{
    public class AllowedLoad
    {
        [Key]
        public int LoadCategoryInKW { get; set; }
        public int BasePrice { get; set; }
    }
}
