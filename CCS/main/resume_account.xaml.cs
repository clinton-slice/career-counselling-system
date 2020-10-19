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
    /// Interaction logic for resume_account.xaml
    /// </summary>
    public partial class resume_account : UserControl
    {
        MainWindow parent;
        string id = "";
        string category = "";
        string password="";
        public resume_account(MainWindow root,string _id,string _category,string _name,string _password)
        {
            parent = root;
            id = _id;
            category = _category;
            InitializeComponent();
            name.Text = _name;
            password = _password;

         

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (security.DecryptStringAES(password, parent.cipher_text).Equals(passwordBox.Password))
            {
                parent.signin(id, category);
                parent.Visibility = Visibility.Hidden;
                parent.show_get_started();
                new user_form(parent).Show();
            }
            else
            {
                passwordBox.BorderBrush = Brushes.PaleVioletRed;
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            parent.show_get_started();
        }

        private void passwordBox_KeyDown(object sender, KeyEventArgs e)
        {
            passwordBox.Foreground = Brushes.Gray;
        }
    }
}
