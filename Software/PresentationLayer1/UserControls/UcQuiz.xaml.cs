using BusinessLogicLayer;
using EntitiesLayer.Entities;
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

namespace PresentationLayer1.UserControls
{
    
    public partial class UcQuiz : UserControl
    {
        QuizServices quizServices = new QuizServices();
        private List<TriviaQuestion> questions;
        private int currentQuestionIndex = 0;
        private string correctAnswer;

        private int totalScore = 0;
        private int correctAnswersCount = 0;
        private int incorrectAnswersCount = 0;

        private UserService userService = new UserService();
        private string loggedInUsername;
        private readonly Menu _menu;

        private string _difficulty;
        private int _categoryId;

        public UcQuiz(Menu menu, string username, string difficulty, int categoryId)
        {
            InitializeComponent();
            _menu = menu;
            loggedInUsername = username;
            _difficulty = difficulty;
            _categoryId = categoryId;
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadQuestions();
            DisplayQuestion();
        }

        private async Task LoadQuestions()
        {
            try
            {
                questions = await quizServices.GetTriviaQuestions(_difficulty, _categoryId);
            }
            catch (AddQuestionException ex)
            {
                MessageBox.Show("Error while fetching questions: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DisplayQuestion()
        {
            if (questions == null || questions.Count == 0 || currentQuestionIndex >= questions.Count)
            {
                string category = questions.First().Category;
                string mostAnsweredQuestion = questions.First().Question;
                quizServices.SaveQuizResults(loggedInUsername, category, correctAnswersCount, mostAnsweredQuestion);

                userService.SaveUserScore(loggedInUsername, totalScore);
                MessageBox.Show($"QUIZ SUMMARY\nTotal points: {totalScore}\nCorrect answers: {correctAnswersCount}\nIncorrect answers: {incorrectAnswersCount}",
                                "End of quiz", MessageBoxButton.OK, MessageBoxImage.Information);
                _menu.ContentArea.Content = null;
                return;
            }

            TriviaQuestion question = questions[currentQuestionIndex];

            txtQuestion.Text = question.Question;
            correctAnswer = question.CorrectAnswer;

            List<string> allAnswers = new List<string>(question.IncorrectAnswers);
            allAnswers.Add(question.CorrectAnswer);
            allAnswers = allAnswers.OrderBy(a => Guid.NewGuid()).ToList();

            btnAnswer1.Content = allAnswers[0];
            btnAnswer2.Content = allAnswers[1];
            btnAnswer3.Content = allAnswers[2];
            btnAnswer4.Content = allAnswers[3];
        }

        private void Answer_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton.Content.ToString() == correctAnswer)
            {
                correctAnswersCount++;
                totalScore += GetPointsForCorrectAnswer();
            }
            else
            {
                incorrectAnswersCount++;
                totalScore = Math.Max(0, totalScore - 10);
            }

            UpdateScoreDisplay();
            currentQuestionIndex++;
            DisplayQuestion();
        }

        private int GetPointsForCorrectAnswer()
        {
            switch (_difficulty.ToLower())
            {
                case "easy":
                    return 100;
                case "medium":
                    return 500;
                case "hard":
                    return 1000;
                default:
                    return 100;
            }
        }

        private void UpdateScoreDisplay()
        {
            txtCorrectAnswers.Text = $"Correct: {correctAnswersCount}";
            txtIncorrectAnswers.Text = $"Incorrect: {incorrectAnswersCount}";
            txtTotalScore.Text = $"Total Score: {totalScore}";
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            _menu.ContentArea.Content = null;
        }
    }
}
