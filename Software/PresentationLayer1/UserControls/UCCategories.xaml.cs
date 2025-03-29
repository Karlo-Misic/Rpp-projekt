using BusinessLogicLayer;
using EntitiesLayer.Entities;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PresentationLayer1
{

    public partial class UCCategories : UserControl
    {
        private readonly Menu _menu;
        private readonly string _username;
        private readonly string _difficulty;
        private readonly CategoryServices _categoryServices;
        private List<CATEGORy> _categories;


        public UCCategories( Menu menu, string username, string difficulty)
        {
            InitializeComponent();
            _menu = menu;
            _username = username;
            _difficulty = difficulty;
            _categoryServices = new CategoryServices();
            LoadCategories();
        }

        private void LoadCategories()
        {
            try
            {
                _categories = _categoryServices.GetAllCategories();

                if (_categories == null || !_categories.Any())
                {
                    MessageBox.Show("Nema dostupnih kategorija!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                cmbCategories.ItemsSource = _categories;
                cmbCategories.DisplayMemberPath = "name";
                cmbCategories.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri dohvaćanju kategorija: " + ex.Message);
            }
        }

        private void StartQuiz(object sender, RoutedEventArgs e)
        {
            if (cmbCategories.SelectedItem is CATEGORy selectedCategory)
            {
                int categoryId = selectedCategory.categoryID;
                _menu.ContentArea.Content = new UcQuiz(_menu, _username, _difficulty, categoryId);
            }
            else
            {
                MessageBox.Show("Molimo odaberite kategoriju.");
            }
        }
    }
}
