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
using System.Data;

namespace CCS.user
{
    /// <summary>
    /// Interaction logic for result.xaml
    /// </summary>
    public partial class result : UserControl
    {

        MainWindow parent;
        user_form subparent;
        int assess_id;

        public result(MainWindow root, user_form subroot, int assess_id_)
        {
            parent = root;
            subparent = subroot;
            assess_id = assess_id_;
            InitializeComponent();

            DataTable qry = parent.query("select *,(select specialization from counselor where  counselor.counselor_id=(select counselor_id from conversation where conversation.assessment_id=assessment.assessment_id)) as c_des,(select fullname from counselor where  counselor.counselor_id=(select counselor_id from conversation where conversation.assessment_id=assessment.assessment_id)) as c_name,(select count(*) from conversation where conversation.assessment_id=assessment.assessment_id) as submitted,(select counselor_id from conversation where conversation.assessment_id=assessment.assessment_id) as recipent,(select fullname from user where user.user_id=assessment.user_id) as fullname,(select career_name from career where career.career_id=(select career_id from result where result.assessment_id=" + assess_id_+ " and career_id is not null order by percent desc limit 1)) as r_career,(select interest_name from interest where interest.interest_id=(select interest_id from result where result.assessment_id="+assess_id_+" and interest_id is not null order by percent desc limit 1)) as r_interest from assessment where assessment_id=" + assess_id_);
            if(qry.Rows.Count==0)
            {
                MessageBox.Show("An error occured", "CCS", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                subparent.show_home();
            }
        else
            {
                DataRow rw = qry.Rows[0];
                name.Text ="Name: "+ rw["fullname"].ToString();
                career.Text = rw["r_career"].ToString();
                interest.Text = rw["r_interest"].ToString();
                duration.Text = "Duration: "+rw["duration"].ToString();

                if(!rw["submitted"].ToString().Equals("0"))
                {
                    if(!rw["recipent"].ToString().Equals(""))
                    {
                        button2.Visibility = Visibility.Hidden;
                        textBlock5.Text = "Active Conversation with: " + rw["c_name"].ToString();
                        description.Text= rw["c_des"].ToString();
                    }
                    else
                    {
                        button2.IsEnabled = false;
                        button2.Content = "Waiting for a counselor";
                    }
                }


            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            new dialog.full_result(parent,assess_id).Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            button2.IsEnabled = false;
            button2.Content = "Waiting for a counselor";
            parent.query("insert into conversation (assessment_id,user_id,date_added) values(" + assess_id + "," + parent.getloggedId() + ",now())");
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            subparent.show_home();
        }

        private void link_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("www.campusexplorer.com");
        }







    }
}
