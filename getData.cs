using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml;
using System.Diagnostics;

namespace Colson_s_Inventory_Tracker
{
    public class inventoryEntry
    {
        public string upc { get; set; }
        public string Description { get; set; }
        public string PoNum { get; set; }
        public int QtyOrdered { get; set; }        
        public int QtyReceived { get; set; }
        public decimal price { get; set; }
        public string OrderNumber { get; set; }
    }
    class getData
    {
        string sqlConnection = "Server=tcp:electinv.database.windows.net,1433;Database=inventelect;Uid=ferb;Pwd=Jacobfrank@19;Encrypt=yes;TrustServerCertificate=no;Connection Timeout=30;";
        public DataTable request(string sqlQuery)
        {
            
            DataTable dt = new DataTable();
            //use connection pooling to make the connection system use less resources
            using(SqlConnection conn = new SqlConnection(sqlConnection))
            {
                try
                {
                    //Open the connection to the server
                    
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sqlQuery;
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    da.Fill(dt);
                    conn.Close();
                    return dt;
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message);
                    conn.Close();
                    return null;
                }
                
            }
            
        }

        public string generateUPC()
        {
            using (SqlConnection conn = new SqlConnection(sqlConnection))
            {

                //Open the connection to the server

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select CAST(MAX(upc) as FLOAT) + 1 from tblInventory";
                conn.Open();
                var returnedValue = cmd.ExecuteScalar();
                conn.Close();

                return returnedValue.ToString();
            }
        }

        public bool sendXML(string xml)
        {
            using (SqlConnection conn = new SqlConnection(sqlConnection))
            {                
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "processXML";               
                    cmd.Parameters.Add("@report", SqlDbType.VarChar).Value = xml;
                  
                    conn.Open();
                    var ID = cmd.ExecuteScalar(); 
                    conn.Close();
                    return true;
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message);
                    conn.Close();
                    return false;
                }
             }
        }
    

        public string sendData(string sqlQuery)
        {
            using (SqlConnection conn = new SqlConnection(sqlConnection))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sqlQuery;

                    cmd.ExecuteNonQuery();
                    
                    conn.Close();
                    return "Data successfully entered";
                    
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message);
                    conn.Close();
                    return e.Message;
                    
                }
                
            }
            
        }

        public  bool submitOrder(List<inventoryEntry> inv)
        {
            using (SqlConnection conn = new SqlConnection(sqlConnection))
            {
               // return false;
                try
                {
                    //Open the connection to the server

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spreceiveInventory";
                    conn.Open();
                    for (int i = 0; i <= inv.Count -1; i++)
                    //foreach(inventoryEntry entry in inv)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@receive", SqlDbType.Int).Value = inv[i].QtyReceived;
                        cmd.Parameters.Add("@ordered", SqlDbType.Int).Value = inv[i].QtyOrdered;
                        cmd.Parameters.Add("@price", SqlDbType.Decimal).Value = inv[i].price;
                        cmd.Parameters.Add("@ordNum", SqlDbType.NVarChar).Value = inv[i].OrderNumber;
                        cmd.Parameters.Add("@upc", SqlDbType.NVarChar).Value = inv[i].upc;
                        cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = inv[i].Description;
                        cmd.Parameters.Add("@po", SqlDbType.NVarChar).Value = inv[i].PoNum;

                        try
                        {
                            var returnedValue = cmd.ExecuteScalar();
                            if (Convert.ToInt32(returnedValue) == 1)
                            {
                                inv.Remove(inv[i]);
                                i--;
                            }
                        }
                        catch (SqlException e)
                        {
                            MessageBox.Show(e.Message);
                        }


                    }
                    conn.Close();
                    return true;
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message);
                    conn.Close();
                    return false;
                }

            }
        }
    }

    class XMLProcessing
    {
        //THis function is only used to batch update inventory when continueing from offline. 
        public List<inventoryEntry> ExportXML(string filePath)
        {
            //Process.Start("Notepad.exe", filePath);
            
            XmlDocument doc = new XmlDocument();
            
            doc.Load(filePath);
            //Create orders root structure Element
            XmlElement root = (XmlElement)doc.SelectSingleNode("/orders");
            
            XmlNodeList currnode = root.ChildNodes;

               
           // var children = doc.ChildNodes("/orders");
            
            List<inventoryEntry> prepped = new List<inventoryEntry>();

            foreach (XmlNode node in root.ChildNodes)
            {
                inventoryEntry batch = new inventoryEntry();
                batch.upc = node["upc"].InnerText;
                batch.Description = node["description"].InnerText;
                batch.PoNum = node["ponum"].InnerText;
                batch.QtyOrdered = Convert.ToInt32(node["qtyorder"].InnerText);
                batch.QtyReceived = Convert.ToInt32(node["received"].InnerText);
                batch.OrderNumber = node["orderNum"].InnerText;
                batch.price = Convert.ToDecimal(node["price"].InnerText);
                prepped.Add(batch);
                
            }       

            
            return prepped;
        }
    }
}
