using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Domain;
using DataAccess.Dto;

namespace DataAccess.Services
{
    public interface IProductsService
    {
        List<SalesbyProducts> SalesbyProducts(int id);

        List<Product> GetProducts();
    }
}
