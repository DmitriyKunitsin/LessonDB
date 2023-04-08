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
    /// Логика взаимодействия для AutoregWindow.xaml
    /// </summary>
    public partial class AutoregWindow : Window
    {
        public AutoregWindow()
        {
            InitializeComponent();
        }
        
        private void Button_Auto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

       
    }
}
