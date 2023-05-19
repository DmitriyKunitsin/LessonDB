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

namespace LessonDB
{
    /// <summary>
    /// Логика взаимодействия для WinCreatTesting.xaml
    /// </summary>
    public partial class WinCreatTesting : Window
    {
        public WinCreatTesting()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string nameTest = nameTesting.Text;
            string nameGroup = nameGruping.Text;
            string dicriptTest = dicriptTesting.Text;
            DataBaseConnect dataBaseConnect = new DataBaseConnect();
            dataBaseConnect.Data_Info_Test(nameTest, nameGroup, dicriptTest, ApplicationContext.ActualUser.id);
            CreatWindow creatWindow = new CreatWindow();
            creatWindow.Show();
            Close();
            
        }
    }
}
