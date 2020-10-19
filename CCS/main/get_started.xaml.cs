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
using WpfPageTransitions;

namespace CCS.main
{
    /// <summary>
    /// Interaction logic for get_started.xaml
    /// </summary>
    public partial class get_started : UserControl
    {

        MainWindow parent;

        public get_started(MainWindow root)
        {
            parent = root;
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (parent.Dbstate.Equals("Open"))
            {
                if(!emailbox.Text.Trim().Contains("@") || !emailbox.Text.Trim().Contains("."))
                {
                    MessageBox.Show("You entered an invalid email address", "CCS", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            else if (emailbox.Text.Trim().Equals(""))
                {
                    MessageBox.Show("You have not entered in your email address", "CCS", MessageBoxButton.OK, MessageBoxImage.Asterisk); }
                else
                {
                    DataTable qry = parent.query("select counselor_id as id,'counselor' as cat,fullname,password from counselor where email='" + (parent.clean(emailbox.Text.Trim())) + "' union select user_id as id,'user' as cat, fullname,password from user where email='" + (parent.clean(emailbox.Text.Trim())) + "' limit 1");
                    if (qry.Rows.Count == 0)
                    {
                        parent.show_new_account(emailbox.Text.Trim());
                    }
                    else
                    { DataRow rw = qry.Rows[0]; parent.show_resume_account(rw[0].ToString(), rw[1].ToString(), rw[2].ToString(), rw[3].ToString()); }


                }
            }
        }

        private void textBlock1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            parent.show_admin();
        }

        private void textBlock2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new dialog.info().Show();
        }



    }
}
