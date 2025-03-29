using PresentationLayer1.UserControls;
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
using System.Windows.Shapes;

namespace PresentationLayer1
{
    public partial class Menu : Window
    {
        private readonly string _username;
        public Menu(string username)
        {
            _username = username;
            InitializeComponent();
        }

        private void btnQuiz_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new UCDifficulty(this, _username);
        }

        private void btnAddQuestion_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new UcAddQuestion(this);
        }

        private void btnStats_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new UcStatistics(this);
        }

        private void btnLeaderboard_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new UcLeaderboard();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
