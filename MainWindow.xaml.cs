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
using MySql.Data.MySqlClient;

namespace sneaker_heaven
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int accid = 0;
        internal static Connect Conn = new Connect();
        Dictionary<string, int> kosarcart = new Dictionary<string, int>() { };
        List<string> af1 = new List<string>() { "Triple White", "Triple Black" };
        List<int> af1meret = new List<int>() { 37, 40, 42, 425 , 43, 46 };

        public MainWindow()
        {
            InitializeComponent();
            GridLog.Visibility = Visibility.Hidden;
            GridReg.Visibility = Visibility.Hidden;
            GridAccaunt.Visibility = Visibility.Hidden;
            GridFej1.Visibility = Visibility.Hidden;
            Gridferfi.Visibility = Visibility.Hidden;
            Gridgyerek.Visibility = Visibility.Hidden;
            Gridno.Visibility = Visibility.Hidden;
            Gridakcios.Visibility = Visibility.Hidden;
            Uj1.Visibility = Visibility.Hidden;
            Uj2.Visibility = Visibility.Hidden;
            Pass1.Visibility = Visibility.Hidden;
            Pass2.Visibility = Visibility.Hidden;
            Updatepassword.Visibility = Visibility.Hidden;
            Gridkosar.Visibility = Visibility.Hidden;
            GridCip1.Visibility = Visibility.Hidden;
            szin.ItemsSource = af1;
            meret.ItemsSource = af1meret;
        }


        private void button1_Click(object sender, RoutedEventArgs e) ///login button
        {
            GridLog.Visibility = Visibility.Visible;
            GridMain.Visibility = Visibility.Hidden;
            GridReg.Visibility = Visibility.Hidden;
        }

        private void button3_Click(object sender, RoutedEventArgs e) ///registerbutton
        {
            string username = (string)textbox1.Text;
            string jelszo = (string)textbox2.Text;

            if (username == "" || jelszo == "")
            {
                MessageBox.Show("No data found");
            }
            else
            {
                Conn.Connection.Open();

                string sql = "SELECT `ID`, `UserName`, `Password` FROM `user` WHERE 1";

                MySqlCommand cmd = new MySqlCommand(sql, Conn.Connection);

                MySqlDataReader dr = cmd.ExecuteReader();

                bool regisztralt = false;

                dr.Read();

                do
                {
                    var felhasznalo = new
                    {
                        UserNameAdatbazis = dr.GetString(1),
                        JelszoAdatbazis = dr.GetString(2),
                    };

                    if (username == felhasznalo.UserNameAdatbazis && jelszo == felhasznalo.JelszoAdatbazis)
                    {
                        accid = dr.GetInt32(0);
                        regisztralt = true;
                    }


                }
                while (dr.Read());

                if (regisztralt == true)
                {

                    MessageBox.Show("Successful login");
                    GridLog.Visibility = Visibility.Hidden;
                    GridMain.Visibility = Visibility.Visible;
                    Grid2fej.Visibility = Visibility.Hidden;
                    GridFej1.Visibility = Visibility.Visible;
                }
                else
                {
                    MessageBox.Show("No user found");
                }

                dr.Close();

                Conn.Connection.Close();
            }

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = (string)textbox3.Text;
            string email = (string)textbox4.Text;
            string jelszo = (string)textbox5.Text;
            string jelszo2 = (string)textbox6.Text;

            if (username == "" || email == "" || jelszo == "" || !kukac())
            {
                MessageBox.Show("No data found");
            }
            else
            {
                if (jelszo != jelszo2)
                {
                    MessageBox.Show("The two passwords don't match");
                }
                else
                {
                    try
                    {

                        Conn.Connection.Open();

                        string sql = $"INSERT INTO `user`(`UserName`, `Email`, `Password`) VALUES ('{username}','{email}','{jelszo}')";

                        MySqlCommand cmd = new MySqlCommand(sql, Conn.Connection);
                        cmd.ExecuteNonQuery();

                        Conn.Connection.Close();

                        MessageBox.Show("Successful register");

                        GridReg.Visibility = Visibility.Hidden;
                        GridMain.Visibility = Visibility.Hidden;
                        Grid2fej.Visibility = Visibility.Visible;
                        GridFej1.Visibility = Visibility.Hidden;
                        GridLog.Visibility = Visibility.Visible;

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("The database is not connected");
                    }
                }
            }
        }


        private bool kukac()
        {
            string email = (string)textbox4.Text;


            foreach (char c in email)
            {
                if (c == '@')
                {
                    return true;
                }

            }
            return false;
        }

        private void button2_Click(object sender, RoutedEventArgs e) ///regisztráció button
        {
            GridReg.Visibility = Visibility.Visible;
            GridMain.Visibility = Visibility.Hidden;
            GridLog.Visibility = Visibility.Hidden;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //home button
        {
            GridReg.Visibility = Visibility.Hidden;
            GridMain.Visibility = Visibility.Visible;
            GridLog.Visibility = Visibility.Hidden;
        }

        private void logo_Click(object sender, RoutedEventArgs e)
        {
            GridMain.Visibility = Visibility.Hidden;
            GridAccaunt.Visibility = Visibility.Visible;
            Gridferfi.Visibility = Visibility.Hidden;
            Gridgyerek.Visibility = Visibility.Hidden;
            Gridno.Visibility = Visibility.Hidden;
            Gridakcios.Visibility = Visibility.Hidden;
            GridCip1.Visibility = Visibility.Hidden;
            Conn.Connection.Open();

            string sql = $"SELECT `UserName`, `Email`, `Password` FROM `user` WHERE ID = '{accid}'; ";

            MySqlCommand cmd = new MySqlCommand(sql, Conn.Connection);

            MySqlDataReader dr = cmd.ExecuteReader();


            dr.Read();

            do
            {
                var felhasznalo = new
                {
                    Username = dr.GetString(0),
                    Emaild = dr.GetString(1),
                };

                accname.Content = $"{felhasznalo.Username}";
                accemail.Content = $"{felhasznalo.Emaild}";
            }
            while (dr.Read());


            dr.Close();
            Conn.Connection.Close();

            passlock.Visibility = Visibility.Hidden;
        }

        private void passunlock_Click(object sender, RoutedEventArgs e)
        {
            Conn.Connection.Open();

            string sql = $"SELECT `Password` FROM `user` WHERE ID = '{accid}'; ";

            MySqlCommand cmd = new MySqlCommand(sql, Conn.Connection);

            MySqlDataReader dr = cmd.ExecuteReader();


            dr.Read();

            do
            {
                var felhasznalo = new
                {
                    Userpass = dr.GetString(0),
                };

                accpassword.Content = $"{felhasznalo.Userpass}";
            }
            while (dr.Read());


            dr.Close();
            Conn.Connection.Close();

            passunlock.Visibility = Visibility.Hidden;
            passlock.Visibility = Visibility.Visible;
        }

        private void passlock_Click(object sender, RoutedEventArgs e)
        {
            accpassword.Content = "********";
            passlock.Visibility = Visibility.Hidden;
            passunlock.Visibility = Visibility.Visible;
        }

        private void Men_Click(object sender, RoutedEventArgs e)
        {
            GridMain.Visibility = Visibility.Hidden;
            GridAccaunt.Visibility = Visibility.Hidden;
            Gridgyerek.Visibility = Visibility.Hidden;
            Gridno.Visibility = Visibility.Hidden;
            Gridakcios.Visibility = Visibility.Hidden;
            Gridferfi.Visibility = Visibility.Visible;
        }

        private void Women_Click(object sender, RoutedEventArgs e)
        {
            GridMain.Visibility = Visibility.Hidden;
            GridAccaunt.Visibility = Visibility.Hidden;
            Gridferfi.Visibility = Visibility.Hidden;
            Gridgyerek.Visibility = Visibility.Hidden;
            Gridakcios.Visibility = Visibility.Hidden;
            Gridno.Visibility = Visibility.Visible;
        }

        private void Kids_Click(object sender, RoutedEventArgs e)
        {
            GridMain.Visibility = Visibility.Hidden;
            GridAccaunt.Visibility = Visibility.Hidden;
            Gridferfi.Visibility = Visibility.Hidden;
            Gridno.Visibility = Visibility.Hidden;
            Gridakcios.Visibility = Visibility.Hidden;
            Gridgyerek.Visibility = Visibility.Visible;
        }

        private void Discount_Click(object sender, RoutedEventArgs e)
        {
            GridMain.Visibility = Visibility.Hidden;
            GridAccaunt.Visibility = Visibility.Hidden;
            Gridferfi.Visibility = Visibility.Hidden;
            Gridgyerek.Visibility = Visibility.Hidden;
            Gridno.Visibility = Visibility.Hidden;
            Gridakcios.Visibility = Visibility.Visible;
        }

        private void Newpass_Click(object sender, RoutedEventArgs e)
        {
            Uj1.Visibility = Visibility.Visible;
            Uj2.Visibility = Visibility.Visible;
            Pass1.Visibility = Visibility.Visible;
            Pass2.Visibility = Visibility.Visible;
            Updatepassword.Visibility = Visibility.Visible;
        }

        private void Updatepassword_Click(object sender, RoutedEventArgs e)
        {

            string jelszo1 = Pass1.Text;
            string jelszo2 = Pass2.Text;

            if (jelszo1 != jelszo2)
            {
                MessageBox.Show("The two passwords don't match");
            }
            else
            {
                Conn.Connection.Open();
                string sql = $"UPDATE `user` SET `Password`='{jelszo1}' WHERE `ID` = '{accid}';";

                MySqlCommand cmd = new MySqlCommand(sql, Conn.Connection);
                cmd.ExecuteNonQuery();

                Conn.Connection.Close();
            }
        }

        private void Newpass_Click_1(object sender, RoutedEventArgs e)
        {
            Uj1.Visibility = Visibility.Visible;
            Uj2.Visibility = Visibility.Visible;
            Pass1.Visibility = Visibility.Visible;
            Pass2.Visibility = Visibility.Visible;
            Updatepassword.Visibility = Visibility.Visible;
        }

        private void Updatepassword_Click_1(object sender, RoutedEventArgs e)
        {
            string jelszo1 = Pass1.Text;
            string jelszo2 = Pass2.Text;

            if (jelszo1 != jelszo2)
            {
                MessageBox.Show("The two passwords don't match");
            }
            else
            {
                Conn.Connection.Open();
                string sql = $"UPDATE `user` SET `Password`='{jelszo1}' WHERE `ID` = '{accid}';";

                MySqlCommand cmd = new MySqlCommand(sql, Conn.Connection);
                cmd.ExecuteNonQuery();

                Conn.Connection.Close();

                MessageBox.Show("Successful password update!");
            }
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Gridferfi.Visibility = Visibility.Hidden;
            Gridgyerek.Visibility = Visibility.Hidden;
            Gridno.Visibility = Visibility.Hidden;
            Gridakcios.Visibility = Visibility.Hidden;
            GridMain.Visibility = Visibility.Visible;
            GridAccaunt.Visibility = Visibility.Hidden;
        }

        private void Men_Click_1(object sender, RoutedEventArgs e)
        {
            GridMain.Visibility = Visibility.Hidden;
            GridAccaunt.Visibility = Visibility.Hidden;
            Gridgyerek.Visibility = Visibility.Hidden;
            Gridno.Visibility = Visibility.Hidden;
            Gridakcios.Visibility = Visibility.Hidden;
            Gridferfi.Visibility = Visibility.Visible;
        }

        private void Women_Click_1(object sender, RoutedEventArgs e)
        {
            GridMain.Visibility = Visibility.Hidden;
            GridAccaunt.Visibility = Visibility.Hidden;
            Gridferfi.Visibility = Visibility.Hidden;
            Gridgyerek.Visibility = Visibility.Hidden;
            Gridakcios.Visibility = Visibility.Hidden;
            Gridno.Visibility = Visibility.Visible;
        }

        private void Kids_Click_1(object sender, RoutedEventArgs e)
        {
            GridMain.Visibility = Visibility.Hidden;
            GridAccaunt.Visibility = Visibility.Hidden;
            Gridferfi.Visibility = Visibility.Hidden;
            Gridno.Visibility = Visibility.Hidden;
            Gridakcios.Visibility = Visibility.Hidden;
            Gridgyerek.Visibility = Visibility.Visible;
        }

        private void Discount_Click_1(object sender, RoutedEventArgs e)
        {
            GridMain.Visibility = Visibility.Hidden;
            GridAccaunt.Visibility = Visibility.Hidden;
            Gridferfi.Visibility = Visibility.Hidden;
            Gridgyerek.Visibility = Visibility.Hidden;
            Gridno.Visibility = Visibility.Hidden;
            Gridakcios.Visibility = Visibility.Visible;
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Gridferfi.Visibility = Visibility.Hidden;
            Gridgyerek.Visibility = Visibility.Hidden;
            Gridno.Visibility = Visibility.Hidden;
            Gridakcios.Visibility = Visibility.Hidden;
            GridMain.Visibility = Visibility.Visible;
            GridAccaunt.Visibility = Visibility.Hidden;
            GridLog.Visibility = Visibility.Hidden;
            GridReg.Visibility = Visibility.Hidden;
            GridFej1.Visibility = Visibility.Hidden;
            Grid2fej.Visibility = Visibility.Visible;
            MessageBox.Show("Logged out successfully!");
        }

        private void cart_Click(object sender, RoutedEventArgs e)
        {
            Gridferfi.Visibility = Visibility.Hidden;
            Gridgyerek.Visibility = Visibility.Hidden;
            Gridno.Visibility = Visibility.Hidden;
            Gridakcios.Visibility = Visibility.Hidden;
            GridMain.Visibility = Visibility.Hidden;
            GridAccaunt.Visibility = Visibility.Hidden;
            GridLog.Visibility = Visibility.Hidden;
            GridReg.Visibility = Visibility.Hidden;
            GridFej1.Visibility = Visibility.Visible;
            GridCip1.Visibility = Visibility.Hidden;
            kosarlist.ItemsSource = GetKosarcart().Keys;
            Gridkosar.Visibility = Visibility.Visible;
        }

        private Dictionary<string, int> GetKosarcart()
        {
            return kosarcart;
        }

        public int fizetendo = 0;

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            GridMain.Visibility = Visibility.Hidden;
            GridCip1.Visibility = Visibility.Visible;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void meret_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            string szin2 = Convert.ToString(szin.SelectedItem);
            int meret2 = Convert.ToInt32(meret.SelectedItem);
            if (szin2 == af1[0])
            {
                if (meret2 == af1meret[0] || meret2 == af1meret[1] || meret2 == af1meret[2] || meret2 == af1meret[4])
                {
                    if (new1.IsChecked == true)
                    {
                        ar.Content = "Price: 80€";
                        fizetendo = fizetendo + 80;
                        kosarcart.Add("Air Force 1 Low '07", 80);
                    }
                    else
                    {
                        ar.Content = "Price: 60€";
                        fizetendo = fizetendo + 60;
                        kosarcart.Add("Air Force 1 Low '07", 60);
                    }
                }
                else
                {
                    ar.Content = "We dont have that size. Sorry";
                }
                
            }
            else
            {
                if (meret2 == af1meret[3] || meret2 == af1meret[5])
                {
                    if (new1.IsChecked == true)
                    {
                        ar.Content = "Price : 80€ ";
                        fizetendo = fizetendo + 80;
                        kosarcart.Add("Air Force 1 Low '07", 80);
                    }
                    else
                    {
                        ar.Content = "Price: 60€" ;
                        fizetendo = fizetendo + 60;
                        kosarcart.Add("Air Force 1 Low '07", 60);
                    }
                }
                else
                {
                    ar.Content = "We dont have that size. Sorry";
                }
            }
        }
    }
}