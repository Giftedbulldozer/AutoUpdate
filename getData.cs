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
        string sqlConnection = ;
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

      public static class StringCipher
    {
        // This constant is used to determine the keysize of the encryption algorithm in bits.
        // We divide this by 8 within the code below to get the equivalent number of bytes.
        private const int Keysize = 256;

        // This constant determines the number of iterations for the password bytes generation function.
        private const int DerivationIterations = 1000;

        public static string Encrypt(string plainText, string passPhrase)
        {
            // Salt and IV is randomly generated each time, but is preprended to encrypted cipher text
            // so that the same Salt and IV values can be used when decrypting.  
            var saltStringBytes = Generate256BitsOfRandomEntropy();
            var ivStringBytes = Generate256BitsOfRandomEntropy();
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                // Create the final bytes as a concatenation of the random salt bytes, the random iv bytes and the cipher bytes.
                                var cipherTextBytes = saltStringBytes;
                                cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray();
                                cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }

        public static string Decrypt(string cipherText, string passPhrase)
        {
            // Get the complete stream of bytes that represent:
            // [32 bytes of Salt] + [32 bytes of IV] + [n bytes of CipherText]
            var cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText);
            // Get the saltbytes by extracting the first 32 bytes from the supplied cipherText bytes.
            var saltStringBytes = cipherTextBytesWithSaltAndIv.Take(Keysize / 8).ToArray();
            // Get the IV bytes by extracting the next 32 bytes from the supplied cipherText bytes.
            var ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(Keysize / 8).Take(Keysize / 8).ToArray();
            // Get the actual cipher text bytes by removing the first 64 bytes from the cipherText string.
            var cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((Keysize / 8) * 2).Take(cipherTextBytesWithSaltAndIv.Length - ((Keysize / 8) * 2)).ToArray();

            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            using (var streamReader = new StreamReader(cryptoStream, Encoding.UTF8))
                            {
                                return streamReader.ReadToEnd();
                            }
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
