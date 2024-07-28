using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Colson_s_Inventory_Tracker
{
    public partial class ReceiveShipment : Form
    {
        public ReceiveShipment()
        {
            InitializeComponent();
        }

        private void ReceiveShipment_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
        }
    }
}
