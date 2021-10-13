using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace rest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmOrder frm = new frmOrder();
            int length = btnTable2.Text.Length;

            cGeneral._ButtonValue = btnTable1.Text.Substring(length - 6, 6);
            cGeneral._ButtonName = btnTable1.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnTable1_Click(object sender, EventArgs e)
        {
            frmOrder frm = new frmOrder();
            int length = btnTable1.Text.Length;

            cGeneral._ButtonValue = btnTable1.Text.Substring(length - 6, 6);
            cGeneral._ButtonName = btnTable1.Name;
            this.Close();
            frm.ShowDialog();//11. video 3.48 ---- 4.10da veri tabanına ekleme yapıyor



        }

        private void btnTable5_Click(object sender, EventArgs e)
        {
            frmOrder frm = new frmOrder();
            int length = btnTable5.Text.Length;

            cGeneral._ButtonValue = btnTable1.Text.Substring(length - 6, 6);
            cGeneral._ButtonName = btnTable1.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnTable3_Click(object sender, EventArgs e)
        {
            frmOrder frm = new frmOrder();
            int length = btnTable3.Text.Length;

            cGeneral._ButtonValue = btnTable1.Text.Substring(length - 6, 6);
            cGeneral._ButtonName = btnTable1.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnTable4_Click(object sender, EventArgs e)
        {
            frmOrder frm = new frmOrder();
            int length = btnTable4.Text.Length;

            cGeneral._ButtonValue = btnTable1.Text.Substring(length - 6, 6);
            cGeneral._ButtonName = btnTable1.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnTable6_Click(object sender, EventArgs e)
        {
            frmOrder frm = new frmOrder();
            int length = btnTable6.Text.Length;

            cGeneral._ButtonValue = btnTable1.Text.Substring(length - 6, 6);
            cGeneral._ButtonName = btnTable1.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)//EXIT
        {

            if (MessageBox.Show("Are you sure fot exit", "Warning !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                {
                    Application.Exit();

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)//GERIDON
        {
            frmMenu frm = new frmMenu();//10.video 9.44
            this.Close();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)//masa dolu
        {
           

        }

        private void button4_Click(object sender, EventArgs e)//masa bos
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


       
        cGeneral gnl = new cGeneral();
        private void Form1_Load(object sender, EventArgs e) 
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select STATUS,ID from Tables", con);
            SqlDataReader dr = null;

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                foreach (Control item in this.Controls)
                {
                    if (item is Button)
                    {
                        if (item.Name == "btnTable" + dr["ID"].ToString() && dr["STATUS"].ToString() == "1")
                        {
                            item.BackgroundImage = (System.Drawing.Image)(Properties.Resources._008_512);
                        }
                        else if (item.Name == "btnTable" + dr["ID"].ToString() && dr["STATUS"].ToString() == "2")
                        {
                            cTables ms = new cTables();
                            DateTime dt1 = Convert.ToDateTime(ms.SessionSum(2, dr["ID"].ToString()));
                            DateTime dt2 = DateTime.Now;

                            string st1 = Convert.ToDateTime(ms.SessionSum(2, dr["ID"].ToString())).ToShortTimeString();
                            string st2 = DateTime.Now.ToShortTimeString();

                            DateTime t1 = dt1.AddMinutes(DateTime.Parse(st1).TimeOfDay.TotalMinutes);
                            DateTime t2 = dt2.AddMinutes(DateTime.Parse(st2).TimeOfDay.TotalMinutes);
                            var difference = t2 - t1;

                            item.Text = String.Format("{0}{1}{2}",
                                difference.Days > 0 ? string.Format("{0} Day", difference.Days) : "",
                                difference.Hours > 0 ? string.Format("{0} Hours", difference.Hours) : "",
                                difference.Minutes > 0 ? string.Format("{0} Minutes", difference.Minutes) : "").Trim() + "\n\n\nTable" + dr["ID"].ToString();

                            item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.indir);
                            //rezervasyon ve açık masa olayı yok


                        }

                    }

                }
            }

        }
    }
}
