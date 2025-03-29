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

namespace PresentationLayer1
{
    public partial class UCDifficulty : UserControl
    {

        private readonly Menu _menu;
        private readonly string _username;

        public UCDifficulty(Menu menu, string username)
        {
            InitializeComponent();
            _menu = menu;
            _username = username;
        }


        private void DifficultySelected(object sender, RoutedEventArgs e)
        {
            Button selectedButton = sender as Button;
            string difficulty = selectedButton.Content.ToString();

            _menu.ContentArea.Content = new UCCategories(_menu, _username, difficulty);
        }
    }
}
