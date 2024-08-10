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
    public partial class PriceBreakdown : Form
    {
        public Decimal Input1Value
        {
            get
            { return Convert.ToDecimal(txtPrice.Text); }
        }

        public PriceBreakdown()
        {
            InitializeComponent();
        }

        private void PriceBreakdown_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(txtPrice.Text != "")
            {
                DialogResult = DialogResult.OK;
                
            }
        }

        private void btncalculate_Click(object sender, EventArgs e)
        {
            
            lblpriceOutcome.Text = String.Format("{0:C}",(Convert.ToDecimal(txtPrice.Text)/ Convert.ToDecimal(txtPackage.Text))).ToString();
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

        private void txtPackage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string replace = txtPackage.Text.Replace(".", "");
                int test = Convert.ToInt32(replace);
            }
            catch
            {
                var txt = txtPackage.Text.ToCharArray();
                txtPackage.Text = "";
                for (int i = 0; i < txt.Length - 1; i++)
                {
                    txtPackage.Text += txt[i];
                }
            }

            txtPackage.SelectionStart = txtPackage.Text.Length;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
