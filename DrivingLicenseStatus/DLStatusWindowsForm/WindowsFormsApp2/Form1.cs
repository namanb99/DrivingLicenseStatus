using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(id_txt.Text == string.Empty)
            {
                id_txt.Focus();
                MessageBox.Show("Email-id can't be left blank");
                return;
            }
            else if(!id_txt.Text.Contains("@"))
            {
                id_txt.Focus();
                MessageBox.Show("Email-id should contain '@'!");
                return;
            }
            else if(pwd_box.Text == string.Empty)
            {
                pwd_box.Focus();
                MessageBox.Show("Password can't be left blank");
                return;
            }
            else if (dl_txt.Text == string.Empty)
            {
                dl_txt.Focus();
                MessageBox.Show("Application No. can't be left blank");
                return;
            }
            else
            {
                try
                {
                    string connetionString;
                    SqlConnection con;
                    connetionString = @"Data Source=;Initial Catalog=.Net Project;User ID=;Password=";
                    con = new SqlConnection(connetionString);
                    con.Open();
                    string output = "";
                    string command = "SELECT Status FROM DL_APPLICANTS WHERE Email_id = '"+ id_txt.Text +"' AND Password = '"+ pwd_box.Text +"' AND App_num = '" + dl_txt.Text +"'";
                    SqlCommand cmd = new SqlCommand(command, con);
                    SqlDataReader dr;
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows == false)
                    {
                        MessageBox.Show("Invalid Entry");
                        return;
                    }
                    while (dr.Read())
                    {
                        output = output + "Your status is: " + dr.GetValue(0) + "\n";
                    }
                    MessageBox.Show(output);
                    con.Close();
                }
                catch (Exception es)

                {
                    MessageBox.Show(es.Message);
                }

            }
        }

        
    }
}
