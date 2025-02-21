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

        public MainWindow()
        {
            InitializeComponent();
            GridLog.Visibility = Visibility.Hidden;
            GridReg.Visibility = Visibility.Hidden;
            GridAccaunt.Visibility = Visibility.Hidden;
            GridFej1.Visibility = Visibility.Hidden;
        }


        private void button1_Click(object sender, RoutedEventArgs e) ///login button
        {
            GridLog.Visibility=Visibility.Visible;
            GridMain.Visibility=Visibility.Hidden;
            GridReg.Visibility = Visibility.Hidden;
        }

        private void button3_Click(object sender, RoutedEventArgs e) ///registerbutton
        {
            string username = (string)textbox1.Text;
            string jelszo = (string)textbox2.Text;

            if(username == "" || jelszo == "")
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

                    MessageBox.Show("Sikeres Bejelentkezés");
                    GridLog.Visibility = Visibility.Hidden;
                    GridMain.Visibility = Visibility.Visible;
                    Grid2fej.Visibility = Visibility.Hidden;
                    GridFej1.Visibility = Visibility.Visible;
                }
                else
                {
                    MessageBox.Show("Nincs felhasználó");
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
                    MessageBox.Show("A két jelszó nem egyezik");
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

                        MessageBox.Show("Sikeres Regisztráció");

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
                if(c == '@')
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
    }
}
