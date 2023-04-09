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
            // connection object
            SQLiteConnection connectionBase = new SQLiteConnection(@"C:\\Users\\kunic\\source\\repos\\LessonDB\\LessonDataBase.db");
            // commond object
            
        }
        private void Eror_Text_Box(Control Text)
        {
            Text.ToolTip = "Запись должна состоять из более чем 4 символа";
            Text.Background = Brushes.Red;
        }
        private void Clear_Box(string Text, string pass,Control Input)
        {
            if (Text.Length > 4 || pass.Length > 4 )
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
            Clear_Box(login,pass,TextBoxPassword);

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
                User authUser = null;
                using (ApplicationContext db = new ApplicationContext())
                {
                    authUser = db.Users.Where(b => b.Login == login && b.Pass == pass).FirstOrDefault();

                    if (authUser != null)
                    {
                        MessageBox.Show("Данные ввели правильно");
                        WorksWindow openWorkWindow = new WorksWindow();
                        openWorkWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        Eror_Text_Box(TextBoxLogin);
                        MessageBox.Show("Вы ввели не корректные данные");
                    }
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
