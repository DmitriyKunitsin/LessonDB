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

namespace LessonDB
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db;
        public MainWindow()
        {
            InitializeComponent();
            
            db= new ApplicationContext();

          
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = TextBoxLogin.Text.Trim();
            string pass = TextBoxPassword.Password.Trim();
            string pass_2 = TextBoxPassword_2.Password.Trim();
            string email = TextBoxEmail.Text.ToLower().Trim();

            if (login.Length < 4)
            {
                TextBoxLogin.ToolTip = "Короткий логин"; // всплывающая подсказка
                TextBoxLogin.Background = Brushes.Red; // задний фон

            }
            else if (pass.Length < 4)
            {
                TextBoxPassword.Background = Brushes.Red; // задний фон
                TextBoxPassword.ToolTip = "Короткий пароль"; // всплывающая подсказка
            }
            else if (pass != pass_2)
            {
                MessageBox.Show("Пароли не совпадают");
            }
            else if (email.Length < 4 || !email.Contains("@") || !email.Contains("."))
            {
                TextBoxEmail.Background = Brushes.Red; // задний фон
                TextBoxEmail.ToolTip = "Не корректная почта"; // всплывающая подсказка
            }
            else
            {
                TextBoxLogin.ToolTip = "";
                TextBoxLogin.Background = Brushes.Transparent; // Прозрачный задний фон
                TextBoxPassword.ToolTip = "";
                TextBoxPassword.Background = Brushes.Transparent;
                TextBoxPassword_2.ToolTip = "";
                TextBoxPassword_2.Background = Brushes.Transparent;
                TextBoxEmail.ToolTip = "";
                TextBoxEmail.Background = Brushes.Transparent;
                MessageBox.Show("Вы успешно прошли регистрацию");
                User user = new User(login,email,pass);
                
                db.Users.Add(user);
                db.SaveChanges();
            }
            }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AutoregWindow AutoWind  = new AutoregWindow();
            AutoWind.Show();
            this.Hide();
        }
    }
    }

