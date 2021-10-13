using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace rest
{
    class cOrder
    {
        cGeneral gnl = new cGeneral();
        #region Fields
        private int _Id;
        private int _additionId;
        private int _ProductId;
        private int _Amount;
        private int _tableId;
        #endregion
        #region Properties
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        public int additionId
        {
            get { return _additionId; }
            set { _additionId = value; }
        }
        public int ProductId
        {
            get { return _ProductId; }
            set { _ProductId = value; }
        }
        public int Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }
        public int tableId
        {
            get { return _tableId; }
            set { _tableId = value; }
        }

        #endregion

        //siparişleri getir
        public void getByOrder(ListView lv, int AdditionId)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select ProductName,Price,Satislar.Id,Satislar.ProductId," +
                "Satislar.amonunt From satislar Inner Join products on Satislar.ProductId=Product.Id" +
                " Where AdditionId =@AdditionId", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@AdditionId", SqlDbType.Int).Value = AdditionId;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                dr = cmd.ExecuteReader();
                int counter = 0;
                while (dr.Read())//satıslar tablo eklenecek
                {
                    lv.Items.Add(dr["ProductName"].ToString());
                    lv.Items[counter].SubItems.Add(dr["Amount"].ToString());
                    lv.Items[counter].SubItems.Add(dr["ProductId"].ToString());
                    lv.Items[counter].SubItems.Add(dr["Id"].ToString());
                    lv.Items[counter].SubItems.Add(Convert.ToString(Convert.ToDecimal(dr["Amount"]) * Convert.ToDecimal(dr["Amount"])));
                    counter++;
                }

            }
            catch (SqlException ex)
            {
                string error = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }
        }

        public bool SetSaveOrder(cOrder Information)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into Satislar(ADDITIONID,PRODUCTID,AMOUNT,TABLEID) values (@AdditionId,@ProductId,@Amount,@TableId)", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                //tabloya göre yapıldı 20.
                cmd.Parameters.Add("@AdditionId", SqlDbType.Int).Value = Information._additionId;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = Information._ProductId;
                cmd.Parameters.Add("@Amount", SqlDbType.Int).Value = Information. _Amount;
                cmd.Parameters.Add("@TableId", SqlDbType.Int).Value = Information._tableId;

                result = Convert.ToBoolean(cmd.ExecuteNonQuery());


            }
            catch (SqlException ex)
            {
                string error = ex.Message;
            }
            finally
            {

                con.Dispose();
                con.Close();
            }

            return result;


        }

        public void setDeleteOrder(int satisId)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Delete From Satislar  Where ID =@SatisId");
            cmd.Parameters.Add("SatisId", SqlDbType.Int).Value = satisId;

            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.ExecuteNonQuery();
            con.Dispose();
            con.Close();
        }
    }
}
