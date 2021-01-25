using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace salonUchkin
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        string FilePath;
        public Window1()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow f = new MainWindow();
            f.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (Context db = new Context())
            {
                Client client = new Client { FirstName = TB1.Text, LastName = TB2.Text, Patronymic = TB3.Text, Birthday = Convert.ToDateTime(TB4.Text), RegistrationDate = Convert.ToDateTime(TB5.Text), Email = TB6.Text, Phone = TB7.Text, GenderCode = TB8.Text, PhotoPath = FilePath };
                db.Client.Add(client);
                db.SaveChanges();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            FilePath = openFileDialog.FileName;
        }
    }
}
