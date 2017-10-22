using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;

namespace HighchartsSample.Chart
{
    public class ChartConfig
    {
        public Highcharts Init(XAxis xAxis,string subtitle,string title
            ,string yAxisTitle,List<Series> series)
        {
            var columnChart = new Highcharts("columnChart");

            columnChart.InitChart(new DotNet.Highcharts.Options.Chart()
            {
                Type = DotNet.Highcharts.Enums.ChartTypes.Column,
                BackgroundColor = new BackColorOrGradient(Color.AliceBlue),
                Style = "fontWeight: 'bold', fontsize:'17px'",
                BorderColor = Color.LightBlue,
                BorderRadius = 0,
                BorderWidth = 2
            });

            columnChart.SetSubtitle(new Subtitle()
            {
                Text = subtitle
            });

            columnChart.SetTitle(new Title()
            {
                Text = title
            });

            columnChart.SetXAxis(xAxis);

            columnChart.SetYAxis(new YAxis()
            {
                Title = new YAxisTitle()
                {
                    Text = yAxisTitle,
                    Style = "fontWeight: 'bold', fontSize: '17px'"
                },
                ShowFirstLabel = true,
                ShowLastLabel = true,
                Min = 0
            });

            columnChart.SetLegend(new Legend
            {
                Enabled = true,
                BorderColor = Color.CornflowerBlue,
                BorderRadius = 6,
                BackgroundColor = new BackColorOrGradient(ColorTranslator.FromHtml("#FFADD8E6"))
            });

            var seriesarray = series.ToArray();
            columnChart.SetSeries(seriesarray);


            return columnChart;
        }

        
    }
}