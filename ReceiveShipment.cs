using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;


namespace Colson_s_Inventory_Tracker
{
    public partial class ReceiveShipment : Form
    {
        public Form prevForm;
        private List<inventoryEntry> inv = new();
        public ReceiveShipment()
        {
            InitializeComponent();
        }

        private void ReceiveShipment_FormClosing(object sender, FormClosingEventArgs e)
        {
            string filePath = Environment.CurrentDirectory + "\\orders.xml";
            if (!File.Exists(filePath) && inv.Count > 0)
            {
                XmlDocument doc = new();

                //Create orders root structure Element
                XmlNode newNode = doc.CreateElement("orders");                
               
                foreach (inventoryEntry row in inv)
                {
                    //Create  order entries not saved
                    XmlElement order = doc.CreateElement("order");

                    //Create ordernum chil attribute                    
                    XmlElement att = doc.CreateElement("orderNum");
                    att.InnerText = row.OrderNumber;
                    order.AppendChild(att);

                    //create price attribute
                    XmlElement price = doc.CreateElement("price");
                    price.InnerText = row.price.ToString();
                    order.AppendChild(price);

                    //create UPC Attribute
                    XmlElement upc = doc.CreateElement("upc");
                    upc.InnerText = row.upc;
                    order.AppendChild(upc);

                    //create PO Num Attribute
                    XmlElement po = doc.CreateElement("ponum");
                    po.InnerText = row.PoNum;
                    order.AppendChild(po);

                    //create Quantity Ordered Attribute
                    XmlElement ordered = doc.CreateElement("qtyorder");
                    ordered.InnerText = row.QtyOrdered.ToString();
                    order.AppendChild(ordered);

                    //create Quantity received Attribute
                    XmlElement received = doc.CreateElement("received");
                    received.InnerText = row.QtyReceived.ToString();
                    order.AppendChild(received);

                    //create Quantity received Attribute
                    XmlElement descript = doc.CreateElement("description");
                    descript.InnerText = row.Description;
                    order.AppendChild(descript);

                    newNode.AppendChild(order);
                    doc.AppendChild(newNode);
                }

                
                doc.Save(filePath);
            }
            else if (inv.Count > 0)
            {
                XmlDocument doc = new();
                doc.Load(filePath);

                //Create orders root structure Element
                XmlNode newNode = doc.DocumentElement;

                

                foreach (inventoryEntry row in inv)
                {
                    //Create  order entries not saved
                    XmlElement order = doc.CreateElement("order");

                    //Create ordernum chil attribute                    
                    XmlElement att = doc.CreateElement("orderNum");
                    att.InnerText = row.OrderNumber;
                    order.AppendChild(att);

                    //create price attribute
                    XmlElement price = doc.CreateElement("price");
                    price.InnerText = row.price.ToString();
                    order.AppendChild(price);

                    //create UPC Attribute
                    XmlElement upc = doc.CreateElement("upc");
                    upc.InnerText = row.upc;
                    order.AppendChild(upc);

                    //create PO Num Attribute
                    XmlElement po = doc.CreateElement("ponum");
                    po.InnerText = row.PoNum;
                    order.AppendChild(po);

                    //create Quantity Ordered Attribute
                    XmlElement ordered = doc.CreateElement("qtyorder");
                    ordered.InnerText = row.QtyOrdered.ToString();
                    order.AppendChild(ordered);

                    //create Quantity received Attribute
                    XmlElement received = doc.CreateElement("received");
                    received.InnerText = row.QtyReceived.ToString();
                    order.AppendChild(received);

                    //create Quantity received Attribute
                    XmlElement descript = doc.CreateElement("description");
                    descript.InnerText = row.Description;
                    order.AppendChild(descript);

                    newNode.AppendChild(order);
                    doc.AppendChild(newNode);
                }

                doc.Save(filePath);
            }

            foreach(Form frm in Application.OpenForms)
            {
                if(frm.Name == "PriceBreakdown")
                {
                    frm.Close();
                    break;
                }
            }
            prevForm.Show();
        }

        private void txtBarCode_TextChanged(object sender, EventArgs e)
        {
            txtBarCode.Text.Trim();
            if (txtBarCode.Text.Length == 12)
            {
                getData sql = new();
               var tbl = sql.request("select invID, name, rtrim(upc) From tblInventory Where upc = " + "'" + txtBarCode.Text + "' OR name = '" + txtDescription.Text + "'");

                if (tbl.Rows.Count > 0)
                {
                    foreach (DataRow row in tbl.Rows)
                    {
                        txtDescription.Text = row[1].ToString();
                    }
                    //start for loop checking the textbox
                    foreach (Control D in this.Controls)
                    {
                        if (D.GetType() == typeof(System.Windows.Forms.TextBox))
                        {
                            //Check if textbox is empty
                            if (D.Text == "")
                            {
                                //if textbox is empty, find the related label
                                foreach (Control C in this.Controls)
                                {
                                    if (C.GetType() == typeof(System.Windows.Forms.Label))
                                    {
                                        if (C.Name.Split("lbl")[1] == D.Name.Split("txt")[1])
                                        {
                                            C.Text += "*";
                                            C.ForeColor = Color.FromArgb(255, 0, 0);
                                            C.BackColor = Color.FromArgb(0, 0, 0);
                                            break;
                                        }
                                    }
                                }
                                txtPoNumber.Focus();
                            }
                            else
                            {
                                //if textbox is empty, find the related label
                                foreach (Control C in this.Controls)
                                {
                                    if (C.GetType() == typeof(System.Windows.Forms.Label))
                                    {
                                        if (C.Name.Split("lbl")[1] == D.Name.Split("txt")[1])
                                        {
                                            C.Text = C.Text.Split('*')[0];
                                            C.ForeColor = Color.FromArgb(0, 0, 0);
                                            C.BackColor = Color.FromArgb(113, 113, 108);
                                        }
                                    }
                                }
                                txtPoNumber.Focus();
                            }
                        }
                    }

                    txtPoNumber.Focus();

                }
                else
                {
                    foreach (Control C in this.Controls)
                    {
                        if(C.GetType() == typeof(System.Windows.Forms.Label))
                        {
                            C.Text += "*";
                            C.ForeColor = Color.FromArgb(255, 0, 0);
                            C.BackColor = Color.FromArgb(0, 0, 0);
                           
                        }
                    }
                    txtPoNumber.Focus();         
                }
            }
        }

        private void btnStageData_Click(object sender, EventArgs e)
        {
            bool forgot = false;
            foreach (Control C in this.Controls)
            {               
                if (C.GetType() == typeof(System.Windows.Forms.TextBox))
                {
                    if (C.Text == "")
                    {                        
                        forgot = true;
                    }
                }
            }

            
            if (forgot)
            {
                //start for loop checking the textbox
                foreach (Control D in this.Controls)
                {
                    if (D.GetType() == typeof(System.Windows.Forms.TextBox))
                    {
                        //Check if textbox is empty
                        if (D.Text == "")
                        {
                            //if textbox is empty, find the related label
                            foreach (Control C in this.Controls)
                            {
                                if (C.GetType() == typeof(System.Windows.Forms.Label))
                                {
                                    if (C.Name.Replace("lbl", " ") == D.Name.Replace("txt", " ") && !C.Text.Contains("*"))
                                    {
                                        C.Text += "*";
                                        C.ForeColor = Color.FromArgb(255, 0, 0);
                                        C.BackColor = Color.FromArgb(0, 0, 0);
                                        break;
                                    }
                                }
                            }
                            txtPoNumber.Focus();
                        }
                        else
                        {
                            //if textbox is empty, find the related label
                            foreach (Control C in this.Controls)
                            {
                                if (C.GetType() == typeof(System.Windows.Forms.Label))
                                {
                                    if (C.Name.Replace("lbl", " ") == D.Name.Replace("txt", " "))
                                    {
                                        C.Text = C.Text.Split('*')[0];
                                        C.ForeColor = Color.FromArgb(0, 0, 0);
                                        C.BackColor = Color.FromArgb(113, 113, 108);
                                    }
                                }
                            }
                            txtPoNumber.Focus();
                        }
                    }
                }

                txtPoNumber.Focus();
                return;
            }
            inventoryEntry newlist = new();

            newlist.upc = txtBarCode.Text;
            newlist.Description = txtDescription.Text;
            newlist.PoNum = txtPoNumber.Text;
            newlist.QtyOrdered = Convert.ToInt32(txtQtyOrdered.Text);
            newlist.QtyReceived = Convert.ToInt32(txtQtyReceived.Text);
            newlist.OrderNumber = txtOrderNum.Text;
            newlist.price = Convert.ToDecimal(txtPrice.Text);
            inv.Add(newlist);        

            
            DataGridViewRow dgrow = (DataGridViewRow)dtgridReceived.Rows[0].Clone();
            dgrow.Cells[0].Value = txtDescription.Text;
            dgrow.Cells[1].Value = txtPoNumber.Text;
            dgrow.Cells[2].Value = txtQtyOrdered.Text;
            dgrow.Cells[3].Value = txtQtyReceived.Text;
            dgrow.Cells[4].Value = txtPrice.Text;
            decimal price = Convert.ToDecimal(this.txtPrice.Text);
            decimal qtyReceived = Convert.ToDecimal(this.txtQtyReceived.Text);
            var total = price * qtyReceived;
            dgrow.Cells[5].Value = total;

            dtgridReceived.Rows.Add(dgrow);
            resetInvForm();
            
                foreach (Control C in this.Controls)
            {
                if (C.GetType() == typeof(System.Windows.Forms.Label))
                {
                    if (C.Text != "")
                    {
                        if(C.Text.Contains('*'))
                        {
                            string text = C.Text.Remove(C.Text.Length - 1);
                            C.Text = text;
                        }
                        
                        C.ForeColor = Color.Black;
                        C.BackColor = Color.FromArgb(113, 113, 108);
                    }
                }
            }

        }

        private void txtQtyOrdered_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int test = Convert.ToInt32(txtQtyOrdered.Text);
            }
            catch
            {
                var txt = txtQtyOrdered.Text.ToCharArray();
                txtQtyOrdered.Text = "";
                for(int i = 0; i < txt.Length - 1; i++)
                {
                    txtQtyOrdered.Text += txt[i];
                }
            }

            txtQtyOrdered.SelectionStart = txtQtyOrdered.Text.Length;
        }

        private void txtQtyReceived_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int test = Convert.ToInt32(txtQtyReceived.Text);
            }
            catch
            {
                var txt = txtQtyReceived.Text.ToCharArray();
                txtQtyReceived.Text = "";
                for (int i = 0; i < txt.Length - 1; i++)
                {
                    txtQtyReceived.Text += txt[i];
                }
            }

            txtQtyReceived.SelectionStart = txtQtyReceived.Text.Length;
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string replace = txtPrice.Text.Replace(".", "");
                int test = Convert.ToInt32(replace);
            }
            catch
            {
                var txt = txtPrice.Text.ToCharArray();
                txtPrice.Text = "";
                for (int i = 0; i < txt.Length - 1; i++)
                {
                    txtPrice.Text += txt[i];
                }
            }

            txtPrice.SelectionStart = txtPrice.Text.Length;
        }

        private void resetInvForm()
        {
            txtDescription.Clear();
            txtBarCode.Clear();
            txtPoNumber.Clear();
            txtQtyOrdered.Clear();
            txtQtyReceived.Clear();
            txtPrice.Clear();
            txtOrderNum.Clear();
            txtBarCode.Focus();
        }

        private void btncompleteOrder_Click(object sender, EventArgs e)
        {
            getData sql = new();

            if (inv.Count > 0)
            {
                if (!sql.submitOrder(inv))
                {
                    MessageBox.Show("there was an error submitting the data. Will transmit when connection detected");
                }
                else
                {
                    inv = new List<inventoryEntry>();
                    this.Close();
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPriceBreakdown_Click(object sender, EventArgs e)
        {
            PriceBreakdown pb = new();
            pb.Show();
            //if( pb.ShowDialog() == DialogResult.OK)
            //{
            //    txtPrice.Text = pb.Input1Value.ToString();
            //}
        }

        private void generateBarcodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getData gd = new();
            txtBarCode.Text = gd.generateUPC();
        }
    }
}
