using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccess.Context;
using DataAccess.Domain;
using DataAccess.Dto;

namespace DataAccess.Services
{
    public class ProductsService :  IProductsService
    {
        //private readonly AdventureWorkContext _context;

        public ProductsService()
        {
            //_context = new ;
        }

        public List<SalesbyProducts> SalesbyProducts(int id)
        {
            try
            {
                using (var context = new AdventureWorkContext())
                {
                    var result = from oh in context.SalesOrderHeader
                                 join od in context.SalesOrderDetail on oh.SalesOrderID equals od.SalesOrderID
                                 join pr in context.Product on od.ProductID equals pr.ProductID
                                 where pr.ProductID.Equals(id)
                                 select new
                                 {
                                     pr.Name,
                                     pr.ProductID,
                                     oh.OrderDate.Year,
                                     oh.TotalDue
                                 }
                        into x
                                 group x by new { x.Year, x.Name, x.ProductID }
                        into g
                                 select new SalesbyProducts()
                                 {
                                     Total = g.Sum(x => x.TotalDue),
                                     Year = g.Key.Year.ToString(),
                                     Name = g.Key.Name.ToUpper(),
                                     ProductoId = g.Key.ProductID
                                 };

                    return result.AsNoTracking().ToList();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<Product> GetProducts()
        {
            using (var context = new AdventureWorkContext())
            {
                return context.Product.AsNoTracking().ToList();
            }
        }

    }
}
