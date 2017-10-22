using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Services;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using HighchartsSample.Chart;
using WebGrease.Css.Extensions;

namespace HighchartsSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsService _productsService;
        private readonly ChartConfig _chartConfig;

        public HomeController(IProductsService productsService)
        {
            _productsService = productsService;
            _chartConfig = new ChartConfig();
        }

        public ActionResult Chart(int id)
        {
            var result = _productsService.SalesbyProducts(id);

            var xAxis = new XAxis
            {
                Type = AxisTypes.Category,
                Title = new XAxisTitle { Text = "Years", Style = "fontWeight: 'bold', fontSize: '17px'" },
                Categories = result.Select(x => x.Year).ToArray()
            };

            var obj = result.Select(x => x.Total).Cast<object>().ToArray();
            var nameSerie = result.Select(x => x.Name).FirstOrDefault();

            var series = new List<Series>()
            {
                new Series
                {
                    Name = nameSerie,
                    Data = new Data(obj)
                }
            };

            var chart = _chartConfig.Init(xAxis, "", $"Product Sales - {nameSerie}", "Sales", series);

            return PartialView("_ViewChart", chart);
        }

        public ActionResult Index()
        {
            ViewBag.Products = new SelectList(_productsService.GetProducts(), "ProductID", "Name");

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}