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
using System.Collections;

namespace rest
{
    public partial class frmOrder : Form
    {
        public frmOrder()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
        void instruction(Object sender, EventArgs e)
        {
            Button btn = sender as Button;

            switch (btn.Name)
            {
                case "btn1":

                    btnNumber.Text += (1).ToString();
                    break;
                case "btn2":

                    btnNumber.Text += (2).ToString();
                    break;
                case "btn3":

                    btnNumber.Text += (3).ToString();
                    break;
                case "btn4":

                    btnNumber.Text += (4).ToString();
                    break;
                case "btn5":

                    btnNumber.Text += (5).ToString();
                    break;
                case "btn6":

                    btnNumber.Text += (6).ToString();
                    break;
                case "btn7":

                    btnNumber.Text += (7).ToString();
                    break;
                case "btn8":

                    btnNumber.Text += (8).ToString();
                    break;
                case "btn9":

                    btnNumber.Text += (9).ToString();
                    break;
                case "btn0":

                    btnNumber.Text += (0).ToString();
                    break;
                default:
                    MessageBox.Show("Enter Number");
                    break;
            }
        }//Calculator
        int tableID; int AdditionId;
        private void frmOrder_Load(object sender, EventArgs e)
        {
            lblTableNo.Text = cGeneral._ButtonValue;
            cTables ms = new cTables();
             tableID = ms.TableGetbyNumber(cGeneral._ButtonName);
            if (ms.TableGetbyState(tableID ,2) == true)
            {
                cAddition Ad = new cAddition();
                AdditionId = Ad.getByAddition(tableID);
                cOrder orders = new cOrder();
                orders.getByOrder(lvOrders, AdditionId);
            }
           

            btn1.Click += new EventHandler(instruction);
            btn2.Click += new EventHandler(instruction);
            btn3.Click += new EventHandler(instruction);
            btn4.Click += new EventHandler(instruction);
            btn5.Click += new EventHandler(instruction);
            btn6.Click += new EventHandler(instruction);
            btn17.Click += new EventHandler(instruction);
            btn8.Click += new EventHandler(instruction);
            btn9.Click += new EventHandler(instruction);
            btn0.Click += new EventHandler(instruction);

        }



        

        private void button3_Click_2(object sender, EventArgs e)
        {
            frmMenu frm = new frmMenu();//10.video 9.44
            this.Close();
            frm.Show();
        }

        private void button2_Click_3(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure fot exit", "Warning !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                {
                    Application.Exit();

                }
            }
        }//exit button

        private void btnNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       



        cProductTypes Uc = new cProductTypes();

        private void btnMainCourse1_Click(object sender, EventArgs e)
        {
           
            Uc.getByProductTypes(lvMenu, btnMainCourse1);
        }

        private void btnDrinks2_Click(object sender, EventArgs e)
        {
            Uc.getByProductTypes(lvMenu, btnDrinks2);
        }

        private void btnPasta3_Click(object sender, EventArgs e)
        {
            Uc.getByProductTypes(lvMenu, btnPasta3);
        }

        private void btnFastFood4_Click(object sender, EventArgs e)
        {
            Uc.getByProductTypes(lvMenu, btnFastFood4);
        }

        private void btnAppetizer5_Click(object sender, EventArgs e)
        {
            Uc.getByProductTypes(lvMenu, btnAppetizer5);
        }

        private void btnSalad6_Click(object sender, EventArgs e)
        {
            Uc.getByProductTypes(lvMenu, btnSalad6);
        }

        private void BtnDessert7_Click(object sender, EventArgs e)
        {
            Uc.getByProductTypes(lvMenu, BtnDessert7);
        }

        private void btnSoup8_Click(object sender, EventArgs e)
        {
            Uc.getByProductTypes(lvMenu, btnSoup8);
        }
       private void lblTableNo_Click_1(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        ArrayList deleted = new ArrayList();
        private void btnOrder_Click(object sender, EventArgs e)
        {
            Form1 tb = new Form1();
            cTables table = new cTables();
            cAddition newAddition = new cAddition();
            cOrder saveOrder = new cOrder();
            bool result = false;

            if (table.TableGetbyState(tableID, 1) == true)
            {
                newAddition.Date = DateTime.Now;
                newAddition.TableId = tableID;

                result = newAddition.SetByAdditionNew(newAddition);
                table.setChangeTableState(cGeneral._ButtonName, 2);

                if (lvOrders.Items.Count > 0)
                {
                    for (int i = 0; i < lvOrders.Items.Count; i++)
                    {
                        saveOrder.tableId = tableID;
                        saveOrder.ProductId = Convert.ToInt32(lvOrders.Items[i].SubItems[2].Text);
                        saveOrder.additionId = newAddition.getByAddition(tableID);
                        saveOrder.Amount = Convert.ToInt32(lvOrders.Items[i].SubItems[1].Text);
                        saveOrder.SetSaveOrder(saveOrder);
                    }
                   
                    this.Close();
                    tb.Show();
                }


            }
            else if (table.TableGetbyState(tableID, 2) == true)
            {
                if (lvNewAdded.Items.Count > 0)
                {
                    for (int i = 0; i < lvNewAdded.Items.Count; i++)
                    {
                        saveOrder.tableId = tableID;
                        saveOrder.ProductId = Convert.ToInt32(lvOrders.Items[i].SubItems[1].Text);
                        saveOrder.additionId = newAddition.getByAddition(tableID);
                        saveOrder.Amount = Convert.ToInt32(lvOrders.Items[i].SubItems[2].Text);
                        saveOrder.SetSaveOrder(saveOrder);
                    }

                }
                if(deleted.Count > 0)
                {
                    foreach(string item in deleted)
                    {
                        saveOrder.setDeleteOrder(Convert.ToInt32(item));
                    }
                }

                this.Close();
                tb.Show();
               
            }
            




        }//order buton
       
        int counter = 0; int counter1 = 0;//Menu Tablosu
        private void lvMenu_DoubleClick_1(object sender, EventArgs e)
        {
            if(txtAmount.Text == "")
            {   
                txtAmount = "1";
            }
            if (lvMenu.Items.Count > 0)
            {
                counter = lvOrders.Items.Count;
                lvOrders.Items.Add(lvMenu.SelectedItems[0].Text);
                lvOrders.Items[counter].SubItems.Add(txtAmount.Text);
                lvOrders.Items[counter].SubItems.Add(lvMenu.SelectedItems[0].SubItems[2].Text);

                lvOrders.Items[counter].SubItems.Add(Convert.ToDecimal(lvMenu.SelectedItems[0].SubItems[1].Text) 
                                                    * Convert.ToDecimal(txtAmount.Text));

                lvOrders.Items[counter].SubItems.Add("0");
                counter1 = lvNewAdded.Items.Count;
                lvOrders.Items[counter].SubItems.Add(counter1.ToString());

                lvNewAdded.Items.Add(AdditionId.ToString());
                lvNewAdded.Items[counter1].SubItems.Add(lvMenu.SelectedItems[0].SubItems[2].Text);
                lvNewAdded.Items[counter1].SubItems.Add(txtAmount.Text);
                lvNewAdded.Items[counter1].SubItems.Add(tableID.ToString());
                lvNewAdded.Items[counter1].SubItems.Add(counter1.ToString());

                counter1++;
                txtAmount.Text = "";
            }
        }

        private void lvOrders_DoubleClick(object sender, EventArgs e)
        {
            if(lvOrders.Items.Count >0)
            {
                if(lvOrders.SelectedItems[0].SubItems[4].Text != "0")
                {
                    cOrder saveOrder = new cOrder();
                    saveOrder.setDeleteOrder(Convert.ToInt32(lvOrders.Items[0].SubItems[4].Text));

                }
                else
                {
                    for(int i=0 ; i < lvNewAdded.Items.Count; i++)
                    {
                        if (lvNewAdded.Items[i].SubItems[4].Text == lvOrders.SelectedItems[0].SubItems[5].Text)
                        {
                            lvNewAdded.Items.RemoveAt(i);
                        }
                    }
                }
                lvOrders.Items.RemoveAt(lvOrders.SelectedItems[0].Index);
            }
        }//orders tablosu

        

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.Text = "";
            }
            else
            {

                cProductTypes cu = new cProductTypes();
                cu.getByProductSearch(lvMenu, Convert.ToInt32(textSearch));

            }
                
        }


       

        

       


       
    }
}
