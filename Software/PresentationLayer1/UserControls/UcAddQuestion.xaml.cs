using BusinessLogicLayer;
using DataAccessLayer;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PresentationLayer1.UserControls
{
    public partial class UcAddQuestion : UserControl
    {
        private CategoryServices category = new CategoryServices();
        private DifficultyServices difficulty = new DifficultyServices();
        private readonly QuestionServices questionservices = new QuestionServices();
        private readonly Menu _menu;

        public UcAddQuestion(Menu menu)
        {
            InitializeComponent();
            _menu = menu;
        }

        private void BtnSaveQuestion_Click(object sender, RoutedEventArgs e)
        {
            ResetBorders();

            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtQuestion.Text))
            {
                txtQuestion.BorderBrush = Brushes.Red;
                txtQuestion.BorderThickness = new Thickness(2);
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtcorrectAnswer.Text))
            {
                txtcorrectAnswer.BorderBrush = Brushes.Red;
                txtcorrectAnswer.BorderThickness = new Thickness(2);
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtincorrectAnswer1.Text))
            {
                txtincorrectAnswer1.BorderBrush = Brushes.Red;
                txtincorrectAnswer1.BorderThickness = new Thickness(2);
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtincorrectAnswer2.Text))
            {
                txtincorrectAnswer2.BorderBrush = Brushes.Red;
                txtincorrectAnswer2.BorderThickness = new Thickness(2);
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtincorrectAnswer3.Text))
            {
                txtincorrectAnswer3.BorderBrush = Brushes.Red;
                txtincorrectAnswer3.BorderThickness = new Thickness(2);
                isValid = false;
            }

            if (!isValid)
            {
                MessageBox.Show("All fields must be filled in!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var question = new QUESTION
            {
                question = txtQuestion.Text,
                correctAnswer = txtcorrectAnswer.Text,
                incorrectAnswer1 = txtincorrectAnswer1.Text,
                incorrectAnswer2 = txtincorrectAnswer2.Text,
                incorrectAnswer3 = txtincorrectAnswer3.Text,
                CATEGORy = cmbCategories.SelectedItem as CATEGORy,
                DIFFICULTy = cmbDifficulties.SelectedItem as DIFFICULTy
            };

            try
            {
                if (questionservices.AddQuestion(question))
                {
                    MessageBox.Show("Question saved successfully!", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ResetBorders()
        {
            txtQuestion.BorderBrush = Brushes.Gray;
            txtQuestion.BorderThickness = new Thickness(1);

            txtcorrectAnswer.BorderBrush = Brushes.Gray;
            txtcorrectAnswer.BorderThickness = new Thickness(1);

            txtincorrectAnswer1.BorderBrush = Brushes.Gray;
            txtincorrectAnswer1.BorderThickness = new Thickness(1);

            txtincorrectAnswer2.BorderBrush = Brushes.Gray;
            txtincorrectAnswer2.BorderThickness = new Thickness(1);

            txtincorrectAnswer3.BorderBrush = Brushes.Gray;
            txtincorrectAnswer3.BorderThickness = new Thickness(1);
        }

        private void ClearFields()
        {
            txtQuestion.Clear();
            txtcorrectAnswer.Clear();
            txtincorrectAnswer1.Clear();
            txtincorrectAnswer2.Clear();
            txtincorrectAnswer3.Clear();
            cmbCategories.SelectedIndex = -1;
            cmbDifficulties.SelectedIndex = -1;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            _menu.ContentArea.Content = null;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            cmbCategories.ItemsSource = category.GetAllCategories().ToList();
            cmbDifficulties.ItemsSource = difficulty.GetAllDifficulties().ToList();
        }
    }
}
