using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dto
{
    public class SalesbyProducts
    {
        public int ProductoId { get; set; }
        public string Name { get; set; }
        public string Year { get; set; }
        public decimal Total { get; set; }
    }
}
