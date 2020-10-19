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
    /// Interaction logic for home.xaml
    /// </summary>
    public partial class home : UserControl
    {
        MainWindow parent;
        user_form subparent;

        public class ResultHolder
        {
            public int id { set; get; }
            public int aid { get; set; }
            public string career { get; set; }
            public string counselor { get; set; }
            public string date{ get; set; }
        }

        public home(MainWindow root,  user_form subroot)
        {
            parent = root;
            subparent = subroot;
            InitializeComponent();

            nameLabel.Content = "Logged in: " + parent.getloggedname();
            show_history();
        }

        private void launch(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            ResultHolder result= b.CommandParameter as ResultHolder;
            subparent.show_result_history(result.aid);
        }


        public void show_history()
        {
            DataTable qry = parent.query("select *,(select (select career_name from career where career.career_id=result.career_id) from result where result.assessment_id=assessment.assessment_id and career_id is not null order by percent desc limit 1) as r_career,(select fullname from counselor where counselor_id=(select counselor_id from conversation where conversation.assessment_id=assessment.assessment_id)) as counselor_name_cov from assessment where user_id=" + parent.getloggedId());
            int count = 0;
            foreach (DataRow rw in qry.Rows)
            {
                ResultHolder result = new ResultHolder();
                result.id = ++count;
                result.aid = Int32.Parse(rw["assessment_id"].ToString());
                result.career = (rw["r_career"].ToString());
                result.counselor = rw["counselor_name_cov"].ToString();
                result.date = (rw["date_taken"].ToString());
                listView.Items.Add(result);
            }

        }

        private void label4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
              subparent.Close();
        }

        private void listView_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void label2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            subparent.show_home();
        }

        private void label3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            subparent.show_conversation();
        }

        private void label3_Copy_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            subparent.show_settings();
        }

        private void image1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            subparent.start_test();
        }
    }
}
