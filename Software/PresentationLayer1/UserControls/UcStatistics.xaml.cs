using BusinessLogicLayer;
using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EntitiesLayer.Entities;

namespace PresentationLayer1.UserControls
{
    public partial class UcStatistics : UserControl
    {
        private UserStatisticsServices userStatisticsServices = new UserStatisticsServices();
        private readonly Menu _menu;
        public UcStatistics(Menu menu)
        {
            InitializeComponent();
            _menu = menu;
        }

        private void BackToMenu_Click(object sender, RoutedEventArgs e)
        {
            _menu.ContentArea.Content = null;
        }

        private void LoadChartData()
        {
            var userStatistics = userStatisticsServices.GetStatisticsByUsername(UserSession.Username);

            var categories = userStatistics.Select(s => s.category).Distinct().ToList();
            var correctPercentages = new ChartValues<double>();

            foreach (var category in categories)
            {
                var categoryStats = userStatistics.Where(s => s.category == category);
                var averageCorrectPercentage = categoryStats.Average(s => s.correctPercentage);
                correctPercentages.Add(Math.Round(averageCorrectPercentage*100, 2));
            }

            cartesianChart.Series = new SeriesCollection
    {
        new ColumnSeries
        {
            Title = "Correct Percentage",
            Values = correctPercentages
        }
    };

            cartesianChart.AxisX[0].Labels = categories;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadChartData();
            dgMostAnsweredQuestions.ItemsSource = userStatisticsServices.GetMostAnsweredQuestion().ToList();
        }
    }
}
