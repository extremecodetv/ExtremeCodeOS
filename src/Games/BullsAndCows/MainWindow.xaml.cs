using System;
using System.Linq;
using System.Windows;

namespace BullsAndCows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] Number = new string[4];
        int count = 0;

        public MainWindow()
        {
            InitializeComponent();

            Number = CreateNumber();
        }

        private string[] CreateNumber()
        {
            string Example = "0123456789";
            string[] Out = new string[4];
            Random random = new Random();
            int count = 10;

            for (int i = 0; i < 4; i++)
            {
                int index = random.Next(count - 1);
                Out[i] = Example[index].ToString();

                Example = Example.Remove(index, 1);
                count--;
            }

            return Out;
        }

        private bool Validate(string s)
        {
            for (int i = 0; i < 4; i++)
            {
                if (s.Count(x => x == s[i]) > 1)
                {
                    return false;
                }
            }

            return true;
        }

        private void NewGame(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Вы уверены?", "Новая игра", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                return;
            }

            Cow.Content = "Коровы: 0";
            Bull.Content = "Быки: 0";
            InputBox.Text = "";
            History.Text = "";
            count = 0;
            Number = CreateNumber();
        }

        private void Step(object sender, RoutedEventArgs e)
        {
            if(InputBox.Text.Length < 4 || 
               !Validate(InputBox.Text) || 
               !int.TryParse(InputBox.Text, out int x))
            {
                MessageBox.Show("Недопустимое значение!", 
                                "Ошибка", 
                                MessageBoxButton.OK, 
                                MessageBoxImage.Error);
                return;
            }

            int Cows = 0;
            int Bulls = 0;

            for (int i = 0; i < 4; i++)
            {
                if (InputBox.Text[i].ToString() == Number[i])
                {
                    Bulls++;

                    continue;
                }

                for (int j = 0; j < 4; j++)
                {
                    if(InputBox.Text[j].ToString() == Number[i] && i != j)
                    {
                        Cows++;

                        continue;
                    }
                }
            }

            count++;

            Cow.Content = $"Коровы: {Cows}";
            Bull.Content = $"Быки: {Bulls}";
            History.Text += $"{count}.  {InputBox.Text}" + "\r\n";

            if (Bulls == 4)
            {
                MessageBox.Show("Вы отгадали число!",
                                "Победа",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);

                if (MessageBox.Show("Начать новую игру?",
                                    "Победа",
                                    MessageBoxButton.YesNo,
                                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    NewGame(sender, e);
                }
                else
                {
                    Close();
                }
            }
        }
    }
}
