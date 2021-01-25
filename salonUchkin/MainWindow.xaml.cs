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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace salonUchkin
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string FirstName;
        string LastName;
        string Patronymic;
        string Birthday;
        string RegistrationDate;
        string Email;
        string Phone;
        string GenderCode;
        string PhotoPath;
        public MainWindow()
        {
            InitializeComponent();
            using(Context db = new Context())
            {
                ClientsDG.ItemsSource = db.Client.ToList();
              
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 f = new Window1();
            f.Show();
            this.Close();
        }
        private List<Client> Search(string searchQuery)
        {
            List<Client> _clients = new List<Client>();
            using (Context db = new Context())
            {
                foreach (Client client in db.Client.ToList())
                {
                    if ($"{client.ID},{client.FirstName},{client.LastName},{client.Patronymic},{client.Birthday},{client.RegistrationDate},{client.Email},{client.Phone},{client.GenderCode},{client.PhotoPath}".IndexOf(searchQuery) >= 0)
                    {
                        _clients.Add(client);
                    }
                }

            }
            return _clients;
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (Context db = new Context())
            {
                if (ClientsDG.SelectedItems.Count > 0)
                    for (int i = 0; i < ClientsDG.SelectedItems.Count; i++)
                    {
                        Client client = ClientsDG.SelectedItem as Client;
                        if (client != null)
                        {
                            db.Entry(client).State = EntityState.Deleted;
                            //db.Client.Remove(client);
                            db.SaveChanges();
                            ClientsDG.ItemsSource = db.Client.ToList();
                            MessageBox.Show("Данные удалены", "Уведомление");
                        }
                    }
            } 

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            List<Client> clients = Search(poisk.Text);
            ClientsDG.ItemsSource = clients;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (Context db = new Context())
            {
                if (TableCB.SelectedIndex == 0)
                {
                    ClientsDG.ItemsSource = db.Client.ToList();
                }
                else if(TableCB.SelectedIndex == 1)
                {
                    ClientsDG.ItemsSource = db.Product.ToList();
                }
                else { ClientsDG.ItemsSource = db.Service.ToList(); }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            

            
        }

        private void ClientsDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Client client = ClientsDG.SelectedItem as Client;
            if (client != null)
                imageV.Source = new BitmapImage(new Uri(client.PhotoPath));
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void izmena_Click(object sender, RoutedEventArgs e)
        {
            Client client = ClientsDG.SelectedItem as Client; //Код для выбора ячейки
            if (client != null)
            {
                FirstName = client.FirstName;
                LastName = client.LastName;
                Patronymic = client.Patronymic;
                Birthday = Convert.ToString(client.Birthday);
                RegistrationDate = Convert.ToString(client.RegistrationDate);
                Email = client.Email;
                Phone = client.Phone;
                GenderCode = Convert.ToString(client.GenderCode);
                PhotoPath = client.PhotoPath;
                var dg = ClientsDG;
                var image = imageV;
                Window2 s = new Window2(FirstName, LastName, Patronymic, Birthday, RegistrationDate, Email, Phone, GenderCode, PhotoPath, dg);
                s.Show();
                this.Close();
            }
            else MessageBox.Show("Вы не выбрали строку для изменения","Уведомление");
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("Нет", "Работает?");
        }
    }
    }

