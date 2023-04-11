using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
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
            
            db = new ApplicationContext();

          
        }
        private void Eror_Text_Box(Control Text)
        {
                Text.ToolTip = "Запись должна состоять из более чем 4 символа";
                Text.Background = Brushes.Red;
        }
        private void Clear_Box(string Text, string pass , string email,Control Input) 
        {
            if (Text.Length > 4 || pass.Length > 4 || email.Length > 4)
            {
                Input.Background = Brushes.Transparent;
                Input.ToolTip = "";
            }
        }
        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = TextBoxLogin.Text.Trim();
            string pass = TextBoxPassword.Password.Trim();
            string pass_2 = TextBoxPassword_2.Password.Trim();
            string email = TextBoxEmail.Text.ToLower().Trim();
            Clear_Box(login,pass,email,TextBoxLogin);
            Clear_Box(login, pass, email, TextBoxPassword);
            Clear_Box(login, pass, email, TextBoxEmail);
            if (login.Length < 4)
            {
               Eror_Text_Box(TextBoxLogin);
            }
            else if (pass.Length < 4)
            {
               Eror_Text_Box(TextBoxPassword);
            }
            else if (pass != pass_2)
            {
                MessageBox.Show("Пароли не совпадают");
            }
            else if (email.Length < 4 || !email.Contains("@") || !email.Contains("."))
            {
                Eror_Text_Box(TextBoxEmail);
            }
            else
            {
                try 
                {
                    //добавление логина,пароля и емейла в базу данных
                    ApplicationContext Connect = new ApplicationContext();
                    //Добавление таблицы в случае ее отсутствия
                    string table = "CREATE TABLE IF NOT EXISTS Use (id INTEGER PRIMARY KEY, login TEXT, pass TEXT, email TEXT)";
                    SQLiteCommand addTable= new SQLiteCommand(table, Connect.myConnection);
                    Connect.OpenConnection();
                    addTable.ExecuteNonQuery();
                    string add = "INSERT INTO Use ('login', 'pass', 'email') VALUES (@login, @pass , @email)";
                    SQLiteCommand myCommand = new SQLiteCommand(add, Connect.myConnection);
                    Connect.OpenConnection();
                    myCommand.Parameters.AddWithValue("@login",login );
                    myCommand.Parameters.AddWithValue("@pass", pass);
                    myCommand.Parameters.AddWithValue("@email", email);
                    var resault = myCommand.ExecuteNonQuery();
                    Connect.ClosedConnection();
                    MessageBox.Show("Вы успешно прошли регистрацию, молодец");
                }
                catch 
                {
                    MessageBox.Show("Аккаует не добавлен в базу");
                }


                
                
            }
            }

        private void Button_Auto_Click(object sender, RoutedEventArgs e)
        {
            AutoregWindow AutoWind  = new AutoregWindow();
            AutoWind.Show();
            this.Hide();
        }
    }
    }

