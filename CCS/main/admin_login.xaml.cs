using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;

namespace CCS.main
{
    /// <summary>
    /// Interaction logic for admin_login.xaml
    /// </summary>
    public partial class admin_login : UserControl
    {
        MainWindow parent;
        public admin_login(MainWindow root)
        {
            parent = root;
            InitializeComponent();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            parent.show_get_started();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            if (username.Text.Trim().Equals("") || password.Password.Equals(""))
            { MessageBox.Show("Incomplete Information", "CCS", MessageBoxButton.OK, MessageBoxImage.Exclamation); }
            else
            {
                string user = username.Text;
               

                DataTable qry = parent.query("select password from admin where username='" + parent.clean(user) + "'");
              
                if (qry.Rows.Count>0)
                {
                    DataRow rw = qry.Rows[0];
                    string pass = security.DecryptStringAES(rw[0].ToString(), parent.cipher_text);
                    if (pass.Equals(password.Password))
                    {
                        parent.signin(user, "admin");
                        parent.Visibility = Visibility.Hidden;
                        parent.show_get_started();
                        new user_form(parent).Show();
                    }
                    else
                        MessageBox.Show("Authentication Failed", "CCS", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                else
                {
                    MessageBox.Show("Authentication Failed", "CCS", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }

        }












    }
}
