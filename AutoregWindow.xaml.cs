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
using System.Data.SQLite;
using System.Data.Entity;
using System.IO;
using System.Security.Cryptography;

namespace LessonDB
{
    /// <summary>
    /// Логика взаимодействия для AutoregWindow.xaml
    /// </summary>
    public partial class AutoregWindow : Window
    {
        public AutoregWindow()
        {
            InitializeComponent();
        }
        private void Eror_Text_Box(Control Text)
        {
            Text.ToolTip = "Запись должна состоять из более чем 4 символа";
            Text.Background = Brushes.Red;
        }
        private void Clear_Box(string Text, string pass, Control Input)
        {
            if (Text.Length > 4 || pass.Length > 4)
            {
                Input.Background = Brushes.Transparent;
                Input.ToolTip = "";
            }
        }
        private void Button_Auto_Click(object sender, RoutedEventArgs e)
        {
            string login = TextBoxLogin.Text.Trim();
            string pass = TextBoxPassword.Password.Trim();
            Clear_Box(login, pass, TextBoxLogin);
            Clear_Box(login, pass, TextBoxPassword);

            if (login.Length < 4)
            {
                Eror_Text_Box(TextBoxLogin);
            }
            else if (pass.Length < 4)
            {
                Eror_Text_Box(TextBoxPassword);
            }
            else
            {
                try
                {
                    SHA256 hash = SHA256.Create();
                    var hashedPass = (SHA256.Create()
                    .ComputeHash(Encoding.UTF8.GetBytes(pass))
                    .Select(item => item.ToString("x2")))
                    .Aggregate("", (current, next) => current + next);
                    DataBaseConnect baseConnect = new DataBaseConnect();
                    if (baseConnect.Data_Base_Out_User(login, hashedPass.ToString()))
                    {
                        ApplicationContext.ActualUser = baseConnect.FetchUser(login);
                        WorksWindow next = new WorksWindow();
                        next.Show();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Аккаунт не найден");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void Button_Back_Reg_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
