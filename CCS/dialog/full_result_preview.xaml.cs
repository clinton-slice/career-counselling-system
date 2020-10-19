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
using System.Windows.Shapes;
using System.Data;

namespace CCS.dialog
{
    /// <summary>
    /// Interaction logic for result.xaml
    /// </summary>
    public partial class full_result_preview : Window
    {

        MainWindow parent;
        public full_result_preview(MainWindow root,int assess_)
        {
            parent = root;
            InitializeComponent();
           
            DataTable qry = root.query("select (select career_name from career where career.career_id=result.career_id) as name,career_id,percent from result where result.assessment_id=" + assess_+" and career_id is not null order by percent desc ");
            foreach(DataRow rw in qry.Rows)
            {
                StackPanel panel = new StackPanel();
                panel.Orientation = Orientation.Horizontal;
                panel.Name = "pan_" + rw["career_id"].ToString();

                Label label = new Label();
                label.Content = rw["name"].ToString()+"  ( "+ rw["percent"].ToString()+"% )";
                label.Width = 260;
                panel.Children.Add(label);

                ProgressBar bar = new ProgressBar();
                bar.Minimum = 0;
                bar.Maximum = 100;
                bar.Width = 50;
                bar.Foreground = Brushes.CadetBlue;
                bar.Value = Int32.Parse(rw["percent"].ToString());


                panel.Children.Add(bar);

                listBox.Items.Add(panel);
            }

            if (listBox.Items.Count > 0)
                listBox.SelectedIndex = 0;




           qry = root.query("select (select interest_name from interest where interest.interest_id=result.interest_id) as name,interest_id,percent from result where result.assessment_id=" + assess_ + " and interest_id is not null order by percent desc ");
            foreach (DataRow rw in qry.Rows)
            {
                StackPanel panel = new StackPanel();
                panel.Orientation = Orientation.Horizontal;
                panel.Name = "pan_" + rw["interest_id"].ToString();

                Label label = new Label();
                label.Content = rw["name"].ToString() + "  ( " + rw["percent"].ToString() + "% )";
                label.Width = 260;
                panel.Children.Add(label);

                ProgressBar bar = new ProgressBar();
                bar.Minimum = 0;
                bar.Maximum = 100;
                bar.Width = 50;
                bar.Foreground = Brushes.CadetBlue;
                bar.Value = Int32.Parse(rw["percent"].ToString());


                panel.Children.Add(bar);

                listBox2.Items.Add(panel);
            }





        }

      


    }
}
