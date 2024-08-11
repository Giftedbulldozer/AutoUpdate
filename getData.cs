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
using System.Security.Cryptography;
using System.IO;

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
        
        public DataTable request(string sqlQuery)
        {
            string connstring = "Server = " + StringCipher.DecryptString(Properties.Resources.Server, Properties.Resources.Key) + ",1433; Database = " + StringCipher.DecryptString(Properties.Resources.Database, Properties.Resources.Key) + "; User ID = " + StringCipher.DecryptString(Properties.Resources.UID, Properties.Resources.Key) + "; Password = " + StringCipher.DecryptString(Properties.Resources.pass, Properties.Resources.Key) + "; Trusted_Connection = False; Encrypt = True;";
            
            DataTable dt = new DataTable();
            //use connection pooling to make the connection system use less resources
            using (SqlConnection conn = new SqlConnection(connstring))
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
            string connstring = "Server = " + StringCipher.DecryptString(Properties.Resources.Server, Properties.Resources.Key) + ",1433; Database = " + StringCipher.DecryptString(Properties.Resources.Database, Properties.Resources.Key) + "; User ID = " + StringCipher.DecryptString(Properties.Resources.UID, Properties.Resources.Key) + "; Password = " + StringCipher.DecryptString(Properties.Resources.pass, Properties.Resources.Key) + "; Trusted_Connection = False; Encrypt = True;";
            using (SqlConnection conn = new SqlConnection(connstring))
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
            string connstring = "Server = " + StringCipher.DecryptString(Properties.Resources.Server, Properties.Resources.Key) + ",1433; Database = " + StringCipher.DecryptString(Properties.Resources.Database, Properties.Resources.Key) + "; User ID = " + StringCipher.DecryptString(Properties.Resources.UID, Properties.Resources.Key) + "; Password = " + StringCipher.DecryptString(Properties.Resources.pass, Properties.Resources.Key) + "; Trusted_Connection = False; Encrypt = True;";
            using (SqlConnection conn = new SqlConnection(connstring))
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
            string connstring = "Server = " + StringCipher.DecryptString(Properties.Resources.Server, Properties.Resources.Key) + ",1433; Database = " + StringCipher.DecryptString(Properties.Resources.Database, Properties.Resources.Key) + "; User ID = " + StringCipher.DecryptString(Properties.Resources.UID, Properties.Resources.Key) + "; Password = " + StringCipher.DecryptString(Properties.Resources.pass, Properties.Resources.Key) + "; Trusted_Connection = False; Encrypt = True;";
            using (SqlConnection conn = new SqlConnection(connstring))
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
            string connstring = "Server = " + StringCipher.DecryptString(Properties.Resources.Server, Properties.Resources.Key) + ",1433; Database = " + StringCipher.DecryptString(Properties.Resources.Database, Properties.Resources.Key) + "; User ID = " + StringCipher.DecryptString(Properties.Resources.UID, Properties.Resources.Key) + "; Password = " + StringCipher.DecryptString(Properties.Resources.pass, Properties.Resources.Key) + "; Trusted_Connection = False; Encrypt = True;";
            using (SqlConnection conn = new SqlConnection(connstring))
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

      public static class StringCipher
    {
        // This constant is used to determine the keysize of the encryption algorithm in bits.
        // We divide this by 8 within the code below to get the equivalent number of bytes.
        private const int Keysize = 256;

        // This constant determines the number of iterations for the password bytes generation function.
        private const int DerivationIterations = 1000;

        public static string EncryptString( string plainText, string key)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        public static string DecryptString( string cipherText, string key)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }

        private static byte[] Generate256BitsOfRandomEntropy()
        {
            var randomBytes = new byte[32]; // 32 Bytes will give us 256 bits.
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                // Fill the array with cryptographically secure random bytes.
                rngCsp.GetBytes(randomBytes);
            }
            return randomBytes;
        }
    }
}
