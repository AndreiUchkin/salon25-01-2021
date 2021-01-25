using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        string FilePath;
        private System.Windows.Controls.DataGrid gr = null;
        public Window2(string FirstName, string LastName, string Patronymic, string Birthday, string RegistrationDate, string Email, string Phone, string GenderCode, string PhotoPath, System.Windows.Controls.DataGrid dg)
        {
            InitializeComponent();
            TB1.Text = FirstName;
            TB2.Text = LastName;
            TB3.Text = Patronymic;
            TB4.Text = Birthday;
            TB5.Text = RegistrationDate;
            TB6.Text = Email;
            TB7.Text = Phone;
            TB8.Text = GenderCode;
            TB9.Text = PhotoPath;
            this.gr = dg;
        }
        //private DataGrid gr = null;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Client client = gr.SelectedItem as Client;
            if (client == null)
            {
                return;
            }
            if (FilePath == null)
                FilePath = TB9.Text;
            Client newclient = new Client { FirstName = TB1.Text, LastName = TB2.Text, Patronymic = TB3.Text, Birthday = Convert.ToDateTime(TB4.Text), RegistrationDate = Convert.ToDateTime(TB5.Text), Email = TB6.Text, Phone = TB7.Text, GenderCode = Convert.ToString(TB8.Text), PhotoPath = TB9.Text };
            newclient.ID = client.ID;
            using (Context db = new Context())
            {
                db.Entry(newclient).State = EntityState.Modified;
                db.SaveChanges();
                System.Windows.MessageBox.Show("Изменения сохранены", "Уведомление");
                MainWindow a = new MainWindow();
                a.Show();
                this.Close();
                gr.ItemsSource = db.Client.ToList();


            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow f = new MainWindow();
            f.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            FilePath = openFileDialog.FileName;
        }
    }
}
