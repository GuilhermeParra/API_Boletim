using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_EfCore.Domains
{
    public class Pedido : BaseDomains
    {
        
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }

        
    }
}
