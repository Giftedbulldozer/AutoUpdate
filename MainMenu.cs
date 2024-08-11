using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Colson_s_Inventory_Tracker
{
    public partial class MainMenu : Form
    {

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("User32.dll")]
        private static extern IntPtr GetWindowDC(IntPtr hWnd);

        public MainMenu()

        {
            InitializeComponent();
            
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            const int WM_NCPAINT = 0x85;
            if (m.Msg == WM_NCPAINT)
            {
                IntPtr hdc = GetWindowDC(m.HWnd);
                if ((int)hdc != 0)
                {
                    Graphics g = Graphics.FromHdc(hdc);
                    var brush = new SolidBrush(ColorTranslator.FromHtml("#70706c"));                    
                    g.FillRectangle(brush, new Rectangle(0, 0, 4800, 23));
                    g.Flush();
                    _ = ReleaseDC(m.HWnd, hdc);
                }
            }

        }
            private void Form1_Load(object sender, EventArgs e)
        {   
            // Menu color RGB 107 142 155
            this.BackColor = Color.FromArgb(112,112,108);
            string filePath = Environment.CurrentDirectory + "\\orders.xml";
            if (File.Exists(filePath))
            {
                
                
                getData submitdata = new getData();

                XMLProcessing process = new XMLProcessing();

                if(submitdata.submitOrder(process.ExportXML(filePath)))
                {
                    File.Delete(filePath);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            

            string srv = StringCipher.DecryptString(Properties.Resources.Server, Properties.Resources.Key);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReceiveShipment rs = new ReceiveShipment();
            rs.prevForm = this;
            rs.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
