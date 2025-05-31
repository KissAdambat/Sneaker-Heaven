using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        List<string> kosarcart = new List<string>() {};
        List<string> cipok = new List<string>() { "Triple White", "Triple Black", " Adidas Yeezy Foam runner clay taupe", "Adidas yeezy 350 v2 Carbon beluga","Adidas yeezy 350 v2 black red","Adidas yeezy 350 v2 zebra", "Adidas yeezy Foam Runner MX Granite","Adidas yeezy foam runner sand", "Jordan 1 Chicago Lost and Found", "Jordan 1 Low Travis Scott Black Phantom", "Jordan 1 Marina Blue", "Jordan 1 Reimagined", "Jordan 4 Black Cat", "Jordan 4 Bred Remaigned", "Jordan 4 Metallic Green", "Jordan 4 Military Black", "Jordan 4 White Oreo", "Nike Air Force 1 Low Triple Black", "Nike Air Force 1 Low Triple White", "adidas yeezy 350 v2 beluga reflective", "adidas yeezy 700 mnvn blue tint", "adidas yeezy 700 v3 copper fade"};
        List<double> ferfimeretek = new List<double>() {39,40,41,42,43,44,45,46,47,48};
        List<double> gyerekmeret = new List<double>() { 27, 28,29,30,31,32,33,34,35,36,37,38,39,40 };
        List<double> nomeret = new List<double>() { 35.5,36,37,37.5,38,38.5,39,40,41,42 };

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
            Uj1.Visibility = Visibility.Hidden;
            Uj2.Visibility = Visibility.Hidden;
            Pass1.Visibility = Visibility.Hidden;
            Pass2.Visibility = Visibility.Hidden;
            Updatepassword.Visibility = Visibility.Hidden;
            Gridkosar.Visibility = Visibility.Hidden;
            GridCip1.Visibility = Visibility.Hidden;
            GridDev.Visibility = Visibility.Hidden;
            GridCheckOut.Visibility = Visibility.Hidden;
            devbutton.Visibility = Visibility.Hidden;
            GridCip2.Visibility = Visibility.Hidden;
            GridCip3.Visibility = Visibility.Hidden;
            GridCip4.Visibility = Visibility.Hidden;
            GridCip5.Visibility = Visibility.Hidden;
            GridCip6.Visibility = Visibility.Hidden;
            GridCip7.Visibility = Visibility.Hidden;
            GridCip8.Visibility = Visibility.Hidden;
            GridCip9.Visibility = Visibility.Hidden;
            GridCip10.Visibility = Visibility.Hidden;
            szin.Items.Add(cipok[0]);
            szin.Items.Add(cipok[1]);
            meret.ItemsSource = ferfimeretek;
            meret1.ItemsSource = ferfimeretek;
            meret2.ItemsSource = ferfimeretek;
            meret3.ItemsSource = ferfimeretek;
            meret4.ItemsSource = ferfimeretek;
            meret5.ItemsSource = ferfimeretek;
            meret6.ItemsSource = ferfimeretek;
            meret7.ItemsSource = ferfimeretek;
            meret8.ItemsSource = ferfimeretek;
            meret9.ItemsSource = ferfimeretek;
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
            string jelszo = (string)passs.Password;

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
                bool admin = false;
                string adminnev = "admin";
                string adminjel = "alma";

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
                        if (username == adminnev && jelszo == adminjel)
                        {
                            admin = true;
                        }
                    }


                }
                while (dr.Read());

                if (regisztralt == true)
                {

                    if (admin == true)
                    {
                        MessageBox.Show("Successful login as an admin");
                        GridLog.Visibility = Visibility.Hidden;
                        GridMain.Visibility = Visibility.Visible;
                        Grid2fej.Visibility = Visibility.Hidden;
                        GridFej1.Visibility = Visibility.Visible;
                        devbutton.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        MessageBox.Show("Successful login");
                        GridLog.Visibility = Visibility.Hidden;
                        GridMain.Visibility = Visibility.Visible;
                        Grid2fej.Visibility = Visibility.Hidden;
                        GridFej1.Visibility = Visibility.Visible;
                        devbutton.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    MessageBox.Show("No user found");
                }

                dr.Close();

                Conn.Connection.Close();
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = (string)textbox3.Text;
            string email = (string)textbox4.Text;
            string jelszo = (string)pass1.Password;
            string jelszo2 = (string)pass2.Password;

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
            GridCip2.Visibility = Visibility.Hidden;
            GridCip3.Visibility = Visibility.Hidden;
            GridCip4.Visibility = Visibility.Hidden;
            GridCip5.Visibility = Visibility.Hidden;
            GridCip6.Visibility = Visibility.Hidden;
            GridCip7.Visibility = Visibility.Hidden;
            GridCip8.Visibility = Visibility.Hidden;
            GridCip9.Visibility = Visibility.Hidden;
            GridCip10.Visibility = Visibility.Hidden;
            GridMain.Visibility = Visibility.Hidden;
            GridAccaunt.Visibility = Visibility.Visible;
            Gridferfi.Visibility = Visibility.Hidden;
            Gridgyerek.Visibility = Visibility.Hidden;
            Gridno.Visibility = Visibility.Hidden;
            GridDev.Visibility = Visibility.Hidden;
            GridCip1.Visibility = Visibility.Hidden;
            GridCheckOut.Visibility = Visibility.Hidden;
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
            GridCip2.Visibility = Visibility.Hidden;
            GridCip3.Visibility = Visibility.Hidden;
            GridCip4.Visibility = Visibility.Hidden;
            GridCip5.Visibility = Visibility.Hidden;
            GridCip6.Visibility = Visibility.Hidden;
            GridCip7.Visibility = Visibility.Hidden;
            GridCip8.Visibility = Visibility.Hidden;
            GridCip9.Visibility = Visibility.Hidden;
            GridCip10.Visibility = Visibility.Hidden;
            GridMain.Visibility = Visibility.Hidden;
            GridAccaunt.Visibility = Visibility.Hidden;
            Gridgyerek.Visibility = Visibility.Hidden;
            Gridno.Visibility = Visibility.Hidden;
            GridCip1.Visibility = Visibility.Hidden;
            GridDev.Visibility = Visibility.Hidden;
            GridCheckOut.Visibility = Visibility.Hidden;
            Gridferfi.Visibility = Visibility.Visible;
        }

        private void Women_Click(object sender, RoutedEventArgs e)
        {
            GridCip2.Visibility = Visibility.Hidden;
            GridCip3.Visibility = Visibility.Hidden;
            GridCip4.Visibility = Visibility.Hidden;
            GridCip5.Visibility = Visibility.Hidden;
            GridCip6.Visibility = Visibility.Hidden;
            GridCip7.Visibility = Visibility.Hidden;
            GridCip8.Visibility = Visibility.Hidden;
            GridCip9.Visibility = Visibility.Hidden;
            GridCip10.Visibility = Visibility.Hidden;
            GridMain.Visibility = Visibility.Hidden;
            GridAccaunt.Visibility = Visibility.Hidden;
            Gridferfi.Visibility = Visibility.Hidden;
            Gridgyerek.Visibility = Visibility.Hidden;
            GridCip1.Visibility = Visibility.Hidden;
            GridDev.Visibility = Visibility.Hidden;
            GridCheckOut.Visibility = Visibility.Hidden;
            Gridno.Visibility = Visibility.Visible;
        }

        private void Kids_Click(object sender, RoutedEventArgs e)
        {
            GridCip2.Visibility = Visibility.Hidden;
            GridCip3.Visibility = Visibility.Hidden;
            GridCip4.Visibility = Visibility.Hidden;
            GridCip5.Visibility = Visibility.Hidden;
            GridCip6.Visibility = Visibility.Hidden;
            GridCip7.Visibility = Visibility.Hidden;
            GridCip8.Visibility = Visibility.Hidden;
            GridCip9.Visibility = Visibility.Hidden;
            GridCip10.Visibility = Visibility.Hidden;
            GridMain.Visibility = Visibility.Hidden;
            GridAccaunt.Visibility = Visibility.Hidden;
            Gridferfi.Visibility = Visibility.Hidden;
            Gridno.Visibility = Visibility.Hidden;
            GridCip1.Visibility = Visibility.Hidden;
            GridDev.Visibility = Visibility.Hidden;
            GridCheckOut.Visibility = Visibility.Hidden;
            Gridgyerek.Visibility = Visibility.Visible;
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
            GridCip2.Visibility = Visibility.Hidden;
            GridCip3.Visibility = Visibility.Hidden;
            GridCip4.Visibility = Visibility.Hidden;
            GridCip5.Visibility = Visibility.Hidden;
            GridCip6.Visibility = Visibility.Hidden;
            GridCip7.Visibility = Visibility.Hidden;
            GridCip8.Visibility = Visibility.Hidden;
            GridCip9.Visibility = Visibility.Hidden;
            GridCip10.Visibility = Visibility.Hidden;
            Gridferfi.Visibility = Visibility.Hidden;
            Gridgyerek.Visibility = Visibility.Hidden;
            Gridno.Visibility = Visibility.Hidden;
            GridMain.Visibility = Visibility.Visible;
            GridCip1.Visibility = Visibility.Hidden;
            Gridkosar.Visibility = Visibility.Hidden;
            GridDev.Visibility = Visibility.Hidden;
            GridCheckOut.Visibility = Visibility.Hidden;
            GridAccaunt.Visibility = Visibility.Hidden;
        }

        private void Men_Click_1(object sender, RoutedEventArgs e)
        {
            GridCip2.Visibility = Visibility.Hidden;
            GridCip3.Visibility = Visibility.Hidden;
            GridCip4.Visibility = Visibility.Hidden;
            GridCip5.Visibility = Visibility.Hidden;
            GridCip6.Visibility = Visibility.Hidden;
            GridCip7.Visibility = Visibility.Hidden;
            GridCip8.Visibility = Visibility.Hidden;
            GridCip9.Visibility = Visibility.Hidden;
            GridCip10.Visibility = Visibility.Hidden;
            GridMain.Visibility = Visibility.Hidden;
            GridAccaunt.Visibility = Visibility.Hidden;
            Gridgyerek.Visibility = Visibility.Hidden;
            Gridno.Visibility = Visibility.Hidden;
            GridCip1.Visibility = Visibility.Hidden;
            Gridkosar.Visibility = Visibility.Hidden;
            GridDev.Visibility = Visibility.Hidden;
            GridCheckOut.Visibility = Visibility.Hidden;
            Gridferfi.Visibility = Visibility.Visible;
        }

        private void Women_Click_1(object sender, RoutedEventArgs e)
        {
            GridCip2.Visibility = Visibility.Hidden;
            GridCip3.Visibility = Visibility.Hidden;
            GridCip4.Visibility = Visibility.Hidden;
            GridCip5.Visibility = Visibility.Hidden;
            GridCip6.Visibility = Visibility.Hidden;
            GridCip7.Visibility = Visibility.Hidden;
            GridCip8.Visibility = Visibility.Hidden;
            GridCip9.Visibility = Visibility.Hidden;
            GridCip10.Visibility = Visibility.Hidden;
            GridMain.Visibility = Visibility.Hidden;
            GridAccaunt.Visibility = Visibility.Hidden;
            Gridferfi.Visibility = Visibility.Hidden;
            Gridgyerek.Visibility = Visibility.Hidden;
            GridCip1.Visibility = Visibility.Hidden;
            Gridkosar.Visibility = Visibility.Hidden;
            GridDev.Visibility = Visibility.Hidden;
            GridCheckOut.Visibility = Visibility.Hidden;
            Gridno.Visibility = Visibility.Visible;
        }

        private void Kids_Click_1(object sender, RoutedEventArgs e)
        {
            GridCip2.Visibility = Visibility.Hidden;
            GridCip3.Visibility = Visibility.Hidden;
            GridCip4.Visibility = Visibility.Hidden;
            GridCip5.Visibility = Visibility.Hidden;
            GridCip6.Visibility = Visibility.Hidden;
            GridCip7.Visibility = Visibility.Hidden;
            GridCip8.Visibility = Visibility.Hidden;
            GridCip9.Visibility = Visibility.Hidden;
            GridCip10.Visibility = Visibility.Hidden;
            GridMain.Visibility = Visibility.Hidden;
            GridAccaunt.Visibility = Visibility.Hidden;
            Gridferfi.Visibility = Visibility.Hidden;
            Gridno.Visibility = Visibility.Hidden;
            GridCip1.Visibility = Visibility.Hidden;
            Gridkosar.Visibility = Visibility.Hidden;
            GridDev.Visibility = Visibility.Hidden;
            GridCheckOut.Visibility = Visibility.Hidden;
            Gridgyerek.Visibility = Visibility.Visible;
        }

        private void Discount_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            GridCip2.Visibility = Visibility.Hidden;
            GridCip3.Visibility = Visibility.Hidden;
            GridCip4.Visibility = Visibility.Hidden;
            GridCip5.Visibility = Visibility.Hidden;
            GridCip6.Visibility = Visibility.Hidden;
            GridCip7.Visibility = Visibility.Hidden;
            GridCip8.Visibility = Visibility.Hidden;
            GridCip9.Visibility = Visibility.Hidden;
            GridCip10.Visibility = Visibility.Hidden;
            Gridferfi.Visibility = Visibility.Hidden;
            Gridgyerek.Visibility = Visibility.Hidden;
            Gridno.Visibility = Visibility.Hidden;
            GridMain.Visibility = Visibility.Visible;
            GridAccaunt.Visibility = Visibility.Hidden;
            GridLog.Visibility = Visibility.Hidden;
            GridReg.Visibility = Visibility.Hidden;
            GridFej1.Visibility = Visibility.Hidden;
            GridCip1.Visibility = Visibility.Hidden;
            Gridkosar.Visibility = Visibility.Hidden;
            GridDev.Visibility = Visibility.Hidden;
            GridCheckOut.Visibility = Visibility.Hidden;
            Grid2fej.Visibility = Visibility.Visible;
            MessageBox.Show("Logged out successfully!");
        }

        private void cart_Click(object sender, RoutedEventArgs e)
        {
            GridCip2.Visibility = Visibility.Hidden;
            GridCip3.Visibility = Visibility.Hidden;
            GridCip4.Visibility = Visibility.Hidden;
            GridCip5.Visibility = Visibility.Hidden;
            GridCip6.Visibility = Visibility.Hidden;
            GridCip7.Visibility = Visibility.Hidden;
            GridCip8.Visibility = Visibility.Hidden;
            GridCip9.Visibility = Visibility.Hidden;
            GridCip10.Visibility = Visibility.Hidden;
            Gridferfi.Visibility = Visibility.Hidden;
            Gridgyerek.Visibility = Visibility.Hidden;
            Gridno.Visibility = Visibility.Hidden;
            GridMain.Visibility = Visibility.Hidden;
            GridAccaunt.Visibility = Visibility.Hidden;
            GridLog.Visibility = Visibility.Hidden;
            GridReg.Visibility = Visibility.Hidden;
            GridFej1.Visibility = Visibility.Visible;
            GridCip1.Visibility = Visibility.Hidden;
            GridDev.Visibility = Visibility.Hidden;
            GridCheckOut.Visibility = Visibility.Hidden;
            Gridkosar.Visibility = Visibility.Visible;
            fizetendoosszeg.Content = $"To be paid: {fizetendo} €";
        }


        public int fizetendo = 0;

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void meret_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (new1.IsChecked == true)
            {
                kosarlist.Items.Add($"Air Force 1 Low '07' 80 €");
                fizetendo += 80;
            }
            else
            {
                kosarlist.Items.Add($"Air Force 1 Low '07' 60 €");
                fizetendo += 60;
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            string sor = kosarlist.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(sor))
            {
                MessageBox.Show("No item selected.");
                return;
            }
            string[] reszek = sor.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int ar = 0;
            for (int i = reszek.Length - 1; i >= 0; i--)
            {
                string csakSzam = new string(reszek[i].Where(char.IsDigit).ToArray());

                if (int.TryParse(csakSzam, out ar))
                {
                    break;
                }
            }
            if (ar == 0)
            {
                MessageBox.Show("Couldn't understand the price.");
                return;
            }
            fizetendo -= ar;
            kosarlist.Items.Remove(sor);
            fizetendoosszeg.Content = $"To be paid: {fizetendo} €";
            MessageBox.Show("Deleted successfully.");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            GridCip2.Visibility = Visibility.Hidden;
            GridCip3.Visibility = Visibility.Hidden;
            GridCip4.Visibility = Visibility.Hidden;
            GridCip5.Visibility = Visibility.Hidden;
            GridCip6.Visibility = Visibility.Hidden;
            GridCip7.Visibility = Visibility.Hidden;
            GridCip8.Visibility = Visibility.Hidden;
            GridCip9.Visibility = Visibility.Hidden;
            GridCip10.Visibility = Visibility.Hidden;
            GridLog.Visibility = Visibility.Hidden;
            GridReg.Visibility = Visibility.Hidden;
            GridAccaunt.Visibility = Visibility.Hidden;
            Gridferfi.Visibility = Visibility.Hidden;
            Gridgyerek.Visibility = Visibility.Hidden;
            Gridno.Visibility = Visibility.Hidden;
            Uj1.Visibility = Visibility.Hidden;
            Uj2.Visibility = Visibility.Hidden;
            Pass1.Visibility = Visibility.Hidden;
            Pass2.Visibility = Visibility.Hidden;
            Updatepassword.Visibility = Visibility.Hidden;
            Gridkosar.Visibility = Visibility.Hidden;
            GridDev.Visibility = Visibility.Hidden;
            GridCheckOut.Visibility = Visibility.Hidden;
            GridCip1.Visibility = Visibility.Visible;
        }

        private void devbutton_Click(object sender, RoutedEventArgs e)
        {
            GridCip2.Visibility = Visibility.Hidden;
            GridCip3.Visibility = Visibility.Hidden;
            GridCip4.Visibility = Visibility.Hidden;
            GridCip5.Visibility = Visibility.Hidden;
            GridCip6.Visibility = Visibility.Hidden;
            GridCip7.Visibility = Visibility.Hidden;
            GridCip8.Visibility = Visibility.Hidden;
            GridCip9.Visibility = Visibility.Hidden;
            GridCip10.Visibility = Visibility.Hidden;
            Gridferfi.Visibility = Visibility.Hidden;
            Gridgyerek.Visibility = Visibility.Hidden;
            Gridno.Visibility = Visibility.Hidden;
            GridMain.Visibility = Visibility.Hidden;
            GridAccaunt.Visibility = Visibility.Hidden;
            GridLog.Visibility = Visibility.Hidden;
            GridReg.Visibility = Visibility.Hidden;
            GridFej1.Visibility = Visibility.Visible;
            GridCip1.Visibility = Visibility.Hidden;
            GridCheckOut.Visibility = Visibility.Hidden;
            Gridkosar.Visibility = Visibility.Hidden;
            Conn.Connection.Open();

            string sql = "SELECT `ID`, `UserName`, `Email`, `Password` FROM `user` WHERE 1";

            MySqlCommand cmd = new MySqlCommand(sql, Conn.Connection);

            MySqlDataReader dr = cmd.ExecuteReader();


            dr.Read();

            do
            {
                var felhasznalo = new
                {
                    IDAdatbazis = dr.GetInt32(0),
                    Felhasznalonev = dr.GetString(1),
                    email = dr.GetString(2),
                    Jelszo = dr.GetString(3),
                };

                acclist.Items.Add(felhasznalo.IDAdatbazis + "," + felhasznalo.Felhasznalonev + "," + felhasznalo.Jelszo + "," + felhasznalo.email);

            }
            while (dr.Read());

            dr.Close();

            string sql2 = "SELECT * FROM `shoes` WHERE 1";
            MySqlCommand cmd2 = new MySqlCommand(sql2, Conn.Connection);

            MySqlDataReader dr2 = cmd2.ExecuteReader();

            while (dr2.Read())
            {
                var felhasznalo2 = new
                {
                    brand = dr2.GetString(0),
                    model = dr2.GetString(1),
                    color = dr2.GetString(2),
                    newprice = dr2.GetInt64(3),
                    usedprice = dr2.GetInt64(4),
                };

                shoelist.Items.Add(felhasznalo2.brand + "," + felhasznalo2.model + "," + felhasznalo2.color + "," + felhasznalo2.newprice + "," + felhasznalo2.usedprice);
            }

            dr2.Close();
            Conn.Connection.Close();
            newpriceforused.Visibility = Visibility.Hidden;
            newpricefrused.Visibility = Visibility.Hidden;
            newpricelabel.Visibility = Visibility.Hidden;
            newpricefrnew.Visibility = Visibility.Hidden;
            newpricelabel2.Visibility = Visibility.Hidden;
            newpricefornew.Visibility = Visibility.Hidden;
            GridDev.Visibility = Visibility.Visible;
        }

        private void accdel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (acclist.SelectedItem == null)
                {
                    MessageBox.Show("No account selected.");
                    return;
                }

                string sor = acclist.SelectedItem.ToString();
                string[] felvag = sor.Split(',');

                if (felvag.Length == 0 || string.IsNullOrWhiteSpace(felvag[0]))
                {
                    MessageBox.Show("Incorrect or missing ID.");
                    return;
                }

                string id = felvag[0].Trim();

                Conn.Connection.Open();

                string sql = "DELETE FROM `user` WHERE id = @id";
                using (MySqlCommand cmd = new MySqlCommand(sql, Conn.Connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Deleted successfully.");
                        acclist.Items.Remove(sor);
                    }
                    else
                    {
                        MessageBox.Show("No ID found.");
                    }
                }

                Conn.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something went wrong: {ex.Message}");
            }
            finally
            {
                if (Conn.Connection.State == ConnectionState.Open)
                {
                    Conn.Connection.Close();
                }
            }
        }

        private void allclear_Click(object sender, RoutedEventArgs e)
        {
            if (kosarlist.Items.Count == 0)
            {
                MessageBox.Show("The cart is already empty.");
                return;
            }
            kosarlist.Items.Clear();
            fizetendo = 0;
            fizetendoosszeg.Content = "To be paid: 0 €";
            MessageBox.Show("The cart is empty.");
        }

        private void new1_Click(object sender, RoutedEventArgs e)
        {
            if (new1.IsChecked == true)
            {
                ar.Content = $"Price: 80€";
            }
            else
            {
                ar.Content = $"Price: 60€";
            }
        }

        private void Pay_Click(object sender, RoutedEventArgs e)
        {
            GridCip2.Visibility = Visibility.Hidden;
            GridCip3.Visibility = Visibility.Hidden;
            GridCip4.Visibility = Visibility.Hidden;
            GridCip5.Visibility = Visibility.Hidden;
            GridCip6.Visibility = Visibility.Hidden;
            GridCip7.Visibility = Visibility.Hidden;
            GridCip8.Visibility = Visibility.Hidden;
            GridCip9.Visibility = Visibility.Hidden;
            GridCip10.Visibility = Visibility.Hidden;
            Gridferfi.Visibility = Visibility.Hidden;
            Gridgyerek.Visibility = Visibility.Hidden;
            Gridno.Visibility = Visibility.Hidden;
            GridMain.Visibility = Visibility.Hidden;
            GridAccaunt.Visibility = Visibility.Hidden;
            GridLog.Visibility = Visibility.Hidden;
            GridReg.Visibility = Visibility.Hidden;
            GridCip1.Visibility = Visibility.Hidden;
            Gridkosar.Visibility = Visibility.Hidden;
            GridCheckOut.Visibility = Visibility.Visible;
        }

        private void pay2_Click(object sender, RoutedEventArgs e)
        {
            bool hasError = false;
            string pattern = @"^\d+$";

            if (!Regex.IsMatch(cardnumbers.Text, pattern))
            {
                hasError = true;
                MessageBox.Show("The card number can only be a number.");
            }

            if (!Regex.IsMatch(lejaratiido.Text, pattern))
            {
                hasError = true;
                MessageBox.Show("The expiration time can only be a number.");
            }

            if (!Regex.IsMatch(cvv1.Text, pattern))
            {
                hasError = true;
                MessageBox.Show("CVV can only be a number.");
            }

            if (!Regex.IsMatch(postalcode.Text, pattern))
            {
                hasError = true;
                MessageBox.Show("The zip code can only be a number.");
            }

            if (!hasError)
            {
                MessageBox.Show("All data is correct. Thank you for your purchase");
            }
        }

        private void Air_force1_Click(object sender, RoutedEventArgs e)
        {
            GridCip2.Visibility = Visibility.Hidden;
            GridCip3.Visibility = Visibility.Hidden;
            GridCip4.Visibility = Visibility.Hidden;
            GridCip5.Visibility = Visibility.Hidden;
            GridCip6.Visibility = Visibility.Hidden;
            GridCip7.Visibility = Visibility.Hidden;
            GridCip8.Visibility = Visibility.Hidden;
            GridCip9.Visibility = Visibility.Hidden;
            GridCip10.Visibility = Visibility.Hidden;
            Gridno.Visibility = Visibility.Hidden;
            Gridgyerek.Visibility = Visibility.Hidden;
            Gridferfi.Visibility = Visibility.Hidden;
            GridCip1.Visibility = Visibility.Visible;
        }

        private void Adidas_Yeezy_Boost350_V2_Beluga_Reflective_Click(object sender, RoutedEventArgs e)
        {
            GridCip1.Visibility = Visibility.Hidden;
            GridCip3.Visibility = Visibility.Hidden;
            GridCip4.Visibility = Visibility.Hidden;
            GridCip5.Visibility = Visibility.Hidden;
            GridCip6.Visibility = Visibility.Hidden;
            GridCip7.Visibility = Visibility.Hidden;
            GridCip8.Visibility = Visibility.Hidden;
            GridCip9.Visibility = Visibility.Hidden;
            GridCip10.Visibility = Visibility.Hidden;
            Gridno.Visibility = Visibility.Hidden;
            Gridgyerek.Visibility = Visibility.Hidden;
            Gridferfi.Visibility = Visibility.Hidden;
            GridCip2.Visibility = Visibility.Visible;
        }

        private void Adidas_Yeezy_Boost_350_V2_Bred_Click(object sender, RoutedEventArgs e)
        {
            GridCip2.Visibility = Visibility.Hidden;
            GridCip1.Visibility = Visibility.Hidden;
            GridCip4.Visibility = Visibility.Hidden;
            GridCip5.Visibility = Visibility.Hidden;
            GridCip6.Visibility = Visibility.Hidden;
            GridCip7.Visibility = Visibility.Hidden;
            GridCip8.Visibility = Visibility.Hidden;
            GridCip9.Visibility = Visibility.Hidden;
            GridCip10.Visibility = Visibility.Hidden;
            Gridno.Visibility = Visibility.Hidden;
            Gridgyerek.Visibility = Visibility.Hidden;
            Gridferfi.Visibility = Visibility.Hidden;
            GridCip3.Visibility = Visibility.Visible;
        }

        private void Adidas_Yeezy_Boost_350_V2_Zebra_Click(object sender, RoutedEventArgs e)
        {
            GridCip2.Visibility = Visibility.Hidden;
            GridCip3.Visibility = Visibility.Hidden;
            GridCip1.Visibility = Visibility.Hidden;
            GridCip5.Visibility = Visibility.Hidden;
            GridCip6.Visibility = Visibility.Hidden;
            GridCip7.Visibility = Visibility.Hidden;
            GridCip8.Visibility = Visibility.Hidden;
            GridCip9.Visibility = Visibility.Hidden;
            GridCip10.Visibility = Visibility.Hidden;
            Gridno.Visibility = Visibility.Hidden;
            Gridgyerek.Visibility = Visibility.Hidden;
            Gridferfi.Visibility = Visibility.Hidden;
            GridCip4.Visibility = Visibility.Visible;
        }

        private void Adidas_Yeezy_700_V3_Copper_Fade_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Adidas_Yeezy_Foam_Runner_Sand_Click(object sender, RoutedEventArgs e)
        {
            GridCip2.Visibility = Visibility.Hidden;
            GridCip3.Visibility = Visibility.Hidden;
            GridCip4.Visibility = Visibility.Hidden;
            GridCip1.Visibility = Visibility.Hidden;
            GridCip6.Visibility = Visibility.Hidden;
            GridCip7.Visibility = Visibility.Hidden;
            GridCip8.Visibility = Visibility.Hidden;
            GridCip9.Visibility = Visibility.Hidden;
            GridCip10.Visibility = Visibility.Hidden;
            Gridno.Visibility = Visibility.Hidden;
            Gridgyerek.Visibility = Visibility.Hidden;
            Gridferfi.Visibility = Visibility.Hidden;
            GridCip5.Visibility = Visibility.Visible;
        }

        private void Adidas_Yeezy_Foam_Runner_Onyx_Click(object sender, RoutedEventArgs e)
        {
            GridCip2.Visibility = Visibility.Hidden;
            GridCip3.Visibility = Visibility.Hidden;
            GridCip4.Visibility = Visibility.Hidden;
            GridCip5.Visibility = Visibility.Hidden;
            GridCip1.Visibility = Visibility.Hidden;
            GridCip7.Visibility = Visibility.Hidden;
            GridCip8.Visibility = Visibility.Hidden;
            GridCip9.Visibility = Visibility.Hidden;
            GridCip10.Visibility = Visibility.Hidden;
            Gridno.Visibility = Visibility.Hidden;
            Gridgyerek.Visibility = Visibility.Hidden;
            Gridferfi.Visibility = Visibility.Hidden;
            GridCip6.Visibility = Visibility.Visible;
        }

        private void Air_Jordan_1_Retro_High_OG_Chicago_Click(object sender, RoutedEventArgs e)
        {
            GridCip2.Visibility = Visibility.Hidden;
            GridCip3.Visibility = Visibility.Hidden;
            GridCip4.Visibility = Visibility.Hidden;
            GridCip5.Visibility = Visibility.Hidden;
            GridCip6.Visibility = Visibility.Hidden;
            GridCip1.Visibility = Visibility.Hidden;
            GridCip8.Visibility = Visibility.Hidden;
            GridCip9.Visibility = Visibility.Hidden;
            GridCip10.Visibility = Visibility.Hidden;
            Gridno.Visibility = Visibility.Hidden;
            Gridgyerek.Visibility = Visibility.Hidden;
            Gridferfi.Visibility = Visibility.Hidden;
            GridCip7.Visibility = Visibility.Visible;
        }

        private void Air_Jordan_1_Low_Travis_Scott_Black_Phantom_Click(object sender, RoutedEventArgs e)
        {
            GridCip2.Visibility = Visibility.Hidden;
            GridCip3.Visibility = Visibility.Hidden;
            GridCip4.Visibility = Visibility.Hidden;
            GridCip5.Visibility = Visibility.Hidden;
            GridCip6.Visibility = Visibility.Hidden;
            GridCip7.Visibility = Visibility.Hidden;
            GridCip1.Visibility = Visibility.Hidden;
            GridCip9.Visibility = Visibility.Hidden;
            GridCip10.Visibility = Visibility.Hidden;
            Gridno.Visibility = Visibility.Hidden;
            Gridgyerek.Visibility = Visibility.Hidden;
            Gridferfi.Visibility = Visibility.Hidden;
            GridCip8.Visibility = Visibility.Visible;
        }

        private void Air_Jordan_4_Bred_Remaigned_Click(object sender, RoutedEventArgs e)
        {
            GridCip2.Visibility = Visibility.Hidden;
            GridCip3.Visibility = Visibility.Hidden;
            GridCip4.Visibility = Visibility.Hidden;
            GridCip5.Visibility = Visibility.Hidden;
            GridCip6.Visibility = Visibility.Hidden;
            GridCip7.Visibility = Visibility.Hidden;
            GridCip8.Visibility = Visibility.Hidden;
            GridCip1.Visibility = Visibility.Hidden;
            GridCip10.Visibility = Visibility.Hidden;
            Gridno.Visibility = Visibility.Hidden;
            Gridgyerek.Visibility = Visibility.Hidden;
            Gridferfi.Visibility = Visibility.Hidden;
            GridCip9.Visibility = Visibility.Visible;
        }

        private void Air_jordan_4_Military_Black_Click(object sender, RoutedEventArgs e)
        {
            GridCip2.Visibility = Visibility.Hidden;
            GridCip3.Visibility = Visibility.Hidden;
            GridCip4.Visibility = Visibility.Hidden;
            GridCip5.Visibility = Visibility.Hidden;
            GridCip6.Visibility = Visibility.Hidden;
            GridCip7.Visibility = Visibility.Hidden;
            GridCip8.Visibility = Visibility.Hidden;
            GridCip9.Visibility = Visibility.Hidden;
            GridCip1.Visibility = Visibility.Hidden;
            Gridno.Visibility = Visibility.Hidden;
            Gridgyerek.Visibility = Visibility.Hidden;
            Gridferfi.Visibility = Visibility.Hidden;
            GridCip10.Visibility = Visibility.Visible;
        }

        private void Deletecip_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (shoelist.SelectedItem == null)
                {
                    MessageBox.Show("No account selected.");
                    return;
                }

                string sor = shoelist.SelectedItem.ToString();
                string[] felvag = sor.Split(',');

                if (felvag.Length == 0 || string.IsNullOrWhiteSpace(felvag[0]))
                {
                    MessageBox.Show("Incorrect or missing ID.");
                    return;
                }

                string id = felvag[2].Trim();

                Conn.Connection.Open();

                string sql = "DELETE FROM `shoes` WHERE id = @id";
                using (MySqlCommand cmd = new MySqlCommand(sql, Conn.Connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Deleted successfully.");
                        acclist.Items.Remove(sor);
                    }
                    else
                    {
                        MessageBox.Show("No ID found.");
                    }
                }

                Conn.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something went wrong: {ex.Message}");
            }
            finally
            {
                if (Conn.Connection.State == ConnectionState.Open)
                {
                    Conn.Connection.Close();
                }
            }
        }

        private void Updateused_Click(object sender, RoutedEventArgs e)
        {

            newpriceforused.Visibility = Visibility.Visible;
            newpricefrused.Visibility = Visibility.Visible;
            newpricelabel.Visibility = Visibility.Visible;
        }

        private void newpriceforused_Click(object sender, RoutedEventArgs e)
        {
            if (shoelist.SelectedItem == null)
            {
                MessageBox.Show("No shoe selected.");
                return;
            }

            string sor = shoelist.SelectedItem.ToString();
            string[] felvag = sor.Split(',');

            if (felvag.Length < 3)
            {
                MessageBox.Show("Hibás adatformátum.");
                return;
            }

            string brand = felvag[0].Trim();
            string model = felvag[1].Trim();
            string color = felvag[2].Trim();
            object price = newpricefrused.Text;


            try
            {
                Conn.Connection.Open();

                string sql = "UPDATE `shoes` SET `Usedprice`= @price WHERE `Brand` = @brand && `Model` = @model && `Color` = @color";
                MySqlCommand cmd = new MySqlCommand(sql, Conn.Connection);

                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@color", color);
                cmd.Parameters.AddWithValue("@brand", brand);
                cmd.Parameters.AddWithValue("@model", model);

                int rowsAffected = cmd.ExecuteNonQuery();

                Conn.Connection.Close();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Used price successfully updated!");

                    LoadShoeList();
                }
                else
                {
                    MessageBox.Show("Update failed. ID not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt: " + ex.Message);
            }
            finally
            {
                if (Conn.Connection.State == System.Data.ConnectionState.Open)
                {
                    Conn.Connection.Close();
                }
            }

        }

        private void LoadShoeList()
        {
            shoelist.Items.Clear();

            try
            {
                Conn.Connection.Open();
                string sql2 = "SELECT * FROM `shoes` WHERE 1";
                MySqlCommand cmd2 = new MySqlCommand(sql2, Conn.Connection);

                MySqlDataReader dr2 = cmd2.ExecuteReader();

                while (dr2.Read())
                {
                    var felhasznalo2 = new
                    {
                        brand = dr2.GetString(0),
                        model = dr2.GetString(1),
                        color = dr2.GetString(2),
                        newprice = dr2.GetInt64(3),
                        usedprice = dr2.GetInt64(4),
                    };

                    shoelist.Items.Add(felhasznalo2.brand + "," + felhasznalo2.model + "," + felhasznalo2.color + "," + felhasznalo2.newprice + "," + felhasznalo2.usedprice);
                }

                dr2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt a lista betöltésekor: " + ex.Message);
            }
            finally
            {
                Conn.Connection.Close();
            }
        }

        private void Updatenew_Click(object sender, RoutedEventArgs e)
        {
            newpricefornew.Visibility = Visibility.Visible;
            newpricefrnew.Visibility = Visibility.Visible;
            newpricelabel2.Visibility = Visibility.Visible;
        }

        private void newpricefornew_Click(object sender, RoutedEventArgs e)
        {
            if (shoelist.SelectedItem == null)
            {
                MessageBox.Show("No shoe selected.");
                return;
            }

            string sor = shoelist.SelectedItem.ToString();
            string[] felvag = sor.Split(',');

            if (felvag.Length < 3)
            {
                MessageBox.Show("Hibás adatformátum.");
                return;
            }

            string brand = felvag[0].Trim();
            string model = felvag[1].Trim();
            string color = felvag[2].Trim();
            object price = newpricefrnew.Text;


            try
            {
                Conn.Connection.Open();

                string sql = "UPDATE `shoes` SET `Newprice`= @price WHERE `Brand` = @brand && `Model` = @model && `Color` = @color";
                MySqlCommand cmd = new MySqlCommand(sql, Conn.Connection);

                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@color", color);
                cmd.Parameters.AddWithValue("@brand", brand);
                cmd.Parameters.AddWithValue("@model", model);

                int rowsAffected = cmd.ExecuteNonQuery();

                Conn.Connection.Close();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Used price successfully updated!");

                    LoadShoeList();
                }
                else
                {
                    MessageBox.Show("Update failed. ID not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt: " + ex.Message);
            }
            finally
            {
                if (Conn.Connection.State == System.Data.ConnectionState.Open)
                {
                    Conn.Connection.Close();
                }
            }
        }

        private void new10_Checked(object sender, RoutedEventArgs e)
        {
            if (new10.IsChecked == true)
            {
                ar9.Content = $"Price: 210€";
            }
            else
            {
                ar9.Content = $"Price: 165€";
            }
        }

        private void new9_Checked(object sender, RoutedEventArgs e)
        {
            if (new9.IsChecked == true)
            {
                ar8.Content = $"Price: 210€";
            }
            else
            {
                ar8.Content = $"Price: 130€";
            }
        }

        private void new8_Checked(object sender, RoutedEventArgs e)
        {
            if (new8.IsChecked == true)
            {
                ar7.Content = $"Price: 150€";
            }
            else
            {
                ar7.Content = $"Price: 400€";
            }
        }

        private void new7_Checked(object sender, RoutedEventArgs e)
        {
            if (new7.IsChecked == true)
            {
                ar6.Content = $"Price: 170€";
            }
            else
            {
                ar6.Content = $"Price: 77€";
            }
        }

        private void new6_Checked(object sender, RoutedEventArgs e)
        {
            if (new6.IsChecked == true)
            {
                ar5.Content = $"Price: 120€";
            }
            else
            {
                ar5.Content = $"Price: 86€";
            }
        }

        private void new5_Checked(object sender, RoutedEventArgs e)
        {
            if (new5.IsChecked == true)
            {
                ar4.Content = $"Price: 120€";
            }
            else
            {
                ar4.Content = $"Price: 88€";
            }
        }

        private void new4_Checked(object sender, RoutedEventArgs e)
        {
            if (new4.IsChecked == true)
            {
                ar3.Content = $"Price: 220€";
            }
            else
            {
                ar3.Content = $"Price: 168€";
            }
        }

        private void new3_Checked(object sender, RoutedEventArgs e)
        {
            if (new3.IsChecked == true)
            {
                ar2.Content = $"Price: 220€";
            }
            else
            {
                ar2.Content = $"Price: 170€";
            }
        }

        private void new2_Checked(object sender, RoutedEventArgs e)
        {
            if (new2.IsChecked == true)
            {
                ar1.Content = $"Price: 220€";
            }
            else
            {
                ar1.Content = $"Price: 120€";
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (new2.IsChecked == true)
            {
                kosarlist.Items.Add($"Adidas yeezy 350 v2 beluga reflective 220 €");
                fizetendo += 220;
            }
            else
            {
                kosarlist.Items.Add($"Adidas yeezy 350 v2 beluga reflective 120 €");
                fizetendo += 120;
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (new3.IsChecked == true)
            {
                kosarlist.Items.Add($"Adidas yeezy 350 v2 black red 220 €");
                fizetendo += 220;
            }
            else
            {
                kosarlist.Items.Add($"Adidas yeezy 350 v2 black red 170 €");
                fizetendo += 170;
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (new4.IsChecked == true)
            {
                kosarlist.Items.Add($"Adidas yeezy 350 v2 zebra 220 €");
                fizetendo += 220;
            }
            else
            {
                kosarlist.Items.Add($"Adidas yeezy 350 v2 zebra 168 €");
                fizetendo += 168;
            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            if (new5.IsChecked == true)
            {
                kosarlist.Items.Add($"Adidas Yeezy Foam runner clay taupe 120 €");
                fizetendo += 120;
            }
            else
            {
                kosarlist.Items.Add($"Adidas Yeezy Foam runner clay taupe 88 €");
                fizetendo += 88;
            }
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            if (new6.IsChecked == true)
            {
                kosarlist.Items.Add($"Adidas Yeezy Foam Runner Onyx 120 €");
                fizetendo += 120;
            }
            else
            {
                kosarlist.Items.Add($"Adidas Yeezy Foam Runner Onyx 86 €");
                fizetendo += 86;
            }
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            if (new7.IsChecked == true)
            {
                kosarlist.Items.Add($"Jordan 1 Chicago Lost and Found 170 €");
                fizetendo += 170;
            }
            else
            {
                kosarlist.Items.Add($"Jordan 1 Chicago Lost and Found 77 €");
                fizetendo += 77;
            }
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            if (new8.IsChecked == true)
            {
                kosarlist.Items.Add($"Jordan 1 Low Travis Scott Black Phantom 150 €");
                fizetendo += 150;
            }
            else
            {
                kosarlist.Items.Add($"Jordan 1 Low Travis Scott Black Phantom 400 €");
                fizetendo += 400;
            }
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            if (new9.IsChecked == true)
            {
                kosarlist.Items.Add($"Jordan 4 Bred Remaigned 210 €");
                fizetendo += 210;
            }
            else
            {
                kosarlist.Items.Add($"Jordan 4 Bred Remaigned 130 €");
                fizetendo += 130;
            }
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            if (new10.IsChecked == true)
            {
                kosarlist.Items.Add($"Jordan 4 Military Black 210 €");
                fizetendo += 210;
            }
            else
            {
                kosarlist.Items.Add($"Jordan 4 Military Black 165 €");
                fizetendo += 165;
            }
        }
    }
}