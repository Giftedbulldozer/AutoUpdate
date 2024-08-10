
namespace Colson_s_Inventory_Tracker
{
    partial class ReceiveShipment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblBarCode = new System.Windows.Forms.Label();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.txtPoNumber = new System.Windows.Forms.TextBox();
            this.lblPoNumber = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtQtyOrdered = new System.Windows.Forms.TextBox();
            this.lblQtyOrdered = new System.Windows.Forms.Label();
            this.txtQtyReceived = new System.Windows.Forms.TextBox();
            this.lblQtyReceived = new System.Windows.Forms.Label();
            this.btncompleteOrder = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dtgridReceived = new System.Windows.Forms.DataGridView();
            this.Descript = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PoNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyOrdered = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyReceived = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.btnStageData = new System.Windows.Forms.Button();
            this.txtOrderNum = new System.Windows.Forms.TextBox();
            this.lblOrderNum = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateBarcodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPriceBreakdown = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgridReceived)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBarCode
            // 
            this.lblBarCode.AutoSize = true;
            this.lblBarCode.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblBarCode.Location = new System.Drawing.Point(83, 38);
            this.lblBarCode.Name = "lblBarCode";
            this.lblBarCode.Size = new System.Drawing.Size(84, 25);
            this.lblBarCode.TabIndex = 0;
            this.lblBarCode.Text = "BarCode";
            // 
            // txtBarCode
            // 
            this.txtBarCode.Location = new System.Drawing.Point(173, 40);
            this.txtBarCode.MaxLength = 12;
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(185, 23);
            this.txtBarCode.TabIndex = 1;
            this.txtBarCode.Tag = "Tool Tip";
            this.txtBarCode.TextChanged += new System.EventHandler(this.txtBarCode_TextChanged);
            // 
            // txtPoNumber
            // 
            this.txtPoNumber.Location = new System.Drawing.Point(515, 40);
            this.txtPoNumber.Name = "txtPoNumber";
            this.txtPoNumber.Size = new System.Drawing.Size(185, 23);
            this.txtPoNumber.TabIndex = 2;
            // 
            // lblPoNumber
            // 
            this.lblPoNumber.AutoSize = true;
            this.lblPoNumber.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPoNumber.Location = new System.Drawing.Point(398, 40);
            this.lblPoNumber.Name = "lblPoNumber";
            this.lblPoNumber.Size = new System.Drawing.Size(111, 25);
            this.lblPoNumber.TabIndex = 2;
            this.lblPoNumber.Text = "PO Number";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(173, 98);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(527, 23);
            this.txtDescription.TabIndex = 3;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDescription.Location = new System.Drawing.Point(59, 96);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(108, 25);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Description";
            // 
            // txtQtyOrdered
            // 
            this.txtQtyOrdered.Location = new System.Drawing.Point(191, 158);
            this.txtQtyOrdered.Name = "txtQtyOrdered";
            this.txtQtyOrdered.Size = new System.Drawing.Size(185, 23);
            this.txtQtyOrdered.TabIndex = 4;
            this.txtQtyOrdered.TextChanged += new System.EventHandler(this.txtQtyOrdered_TextChanged);
            // 
            // lblQtyOrdered
            // 
            this.lblQtyOrdered.AutoSize = true;
            this.lblQtyOrdered.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblQtyOrdered.Location = new System.Drawing.Point(26, 156);
            this.lblQtyOrdered.Name = "lblQtyOrdered";
            this.lblQtyOrdered.Size = new System.Drawing.Size(159, 25);
            this.lblQtyOrdered.TabIndex = 6;
            this.lblQtyOrdered.Text = "Quantity Ordered";
            // 
            // txtQtyReceived
            // 
            this.txtQtyReceived.Location = new System.Drawing.Point(587, 158);
            this.txtQtyReceived.Name = "txtQtyReceived";
            this.txtQtyReceived.Size = new System.Drawing.Size(185, 23);
            this.txtQtyReceived.TabIndex = 5;
            this.txtQtyReceived.Tag = "";
            this.txtQtyReceived.TextChanged += new System.EventHandler(this.txtQtyReceived_TextChanged);
            // 
            // lblQtyReceived
            // 
            this.lblQtyReceived.AutoSize = true;
            this.lblQtyReceived.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblQtyReceived.Location = new System.Drawing.Point(422, 156);
            this.lblQtyReceived.Name = "lblQtyReceived";
            this.lblQtyReceived.Size = new System.Drawing.Size(163, 25);
            this.lblQtyReceived.TabIndex = 8;
            this.lblQtyReceived.Text = "Quantity Received";
            // 
            // btncompleteOrder
            // 
            this.btncompleteOrder.Location = new System.Drawing.Point(83, 511);
            this.btncompleteOrder.Name = "btncompleteOrder";
            this.btncompleteOrder.Size = new System.Drawing.Size(115, 37);
            this.btncompleteOrder.TabIndex = 9;
            this.btncompleteOrder.Text = "Complete Order";
            this.btncompleteOrder.UseVisualStyleBackColor = true;
            this.btncompleteOrder.Click += new System.EventHandler(this.btncompleteOrder_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(526, 511);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 37);
            this.button2.TabIndex = 11;
            this.button2.Text = "Discard Entries";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // dtgridReceived
            // 
            this.dtgridReceived.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dtgridReceived.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgridReceived.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Descript,
            this.PoNum,
            this.qtyOrdered,
            this.qtyReceived,
            this.cost,
            this.Total});
            this.dtgridReceived.Location = new System.Drawing.Point(26, 253);
            this.dtgridReceived.Name = "dtgridReceived";
            this.dtgridReceived.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgridReceived.RowHeadersVisible = false;
            this.dtgridReceived.RowTemplate.Height = 25;
            this.dtgridReceived.Size = new System.Drawing.Size(746, 252);
            this.dtgridReceived.TabIndex = 12;
            this.dtgridReceived.TabStop = false;
            // 
            // Descript
            // 
            this.Descript.HeaderText = "Description";
            this.Descript.Name = "Descript";
            this.Descript.Width = 288;
            // 
            // PoNum
            // 
            this.PoNum.HeaderText = "PO Num";
            this.PoNum.Name = "PoNum";
            // 
            // qtyOrdered
            // 
            this.qtyOrdered.HeaderText = "QTY Ordered";
            this.qtyOrdered.Name = "qtyOrdered";
            // 
            // qtyReceived
            // 
            this.qtyReceived.HeaderText = "QTY Recieved";
            this.qtyReceived.MaxInputLength = 10;
            this.qtyReceived.Name = "qtyReceived";
            this.qtyReceived.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // cost
            // 
            this.cost.HeaderText = "Cost EA.";
            this.cost.Name = "cost";
            this.cost.Width = 76;
            // 
            // Total
            // 
            this.Total.HeaderText = "TTL Cost";
            this.Total.Name = "Total";
            this.Total.Width = 77;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(125, 209);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(185, 23);
            this.txtPrice.TabIndex = 6;
            this.txtPrice.Tag = "";
            this.txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPrice.Location = new System.Drawing.Point(20, 209);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(99, 25);
            this.lblPrice.TabIndex = 14;
            this.lblPrice.Text = "Price each";
            // 
            // btnStageData
            // 
            this.btnStageData.Location = new System.Drawing.Point(657, 209);
            this.btnStageData.Name = "btnStageData";
            this.btnStageData.Size = new System.Drawing.Size(115, 37);
            this.btnStageData.TabIndex = 8;
            this.btnStageData.Text = "Append Entry";
            this.btnStageData.UseVisualStyleBackColor = true;
            this.btnStageData.Click += new System.EventHandler(this.btnStageData_Click);
            // 
            // txtOrderNum
            // 
            this.txtOrderNum.Location = new System.Drawing.Point(456, 209);
            this.txtOrderNum.Name = "txtOrderNum";
            this.txtOrderNum.Size = new System.Drawing.Size(185, 23);
            this.txtOrderNum.TabIndex = 7;
            this.txtOrderNum.Tag = "";
            // 
            // lblOrderNum
            // 
            this.lblOrderNum.AutoSize = true;
            this.lblOrderNum.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblOrderNum.Location = new System.Drawing.Point(343, 207);
            this.lblOrderNum.Name = "lblOrderNum";
            this.lblOrderNum.Size = new System.Drawing.Size(107, 25);
            this.lblOrderNum.TabIndex = 16;
            this.lblOrderNum.Text = "Order Num";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateBarcodeToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // generateBarcodeToolStripMenuItem
            // 
            this.generateBarcodeToolStripMenuItem.Name = "generateBarcodeToolStripMenuItem";
            this.generateBarcodeToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.generateBarcodeToolStripMenuItem.Text = "Generate Barcode";
            this.generateBarcodeToolStripMenuItem.Click += new System.EventHandler(this.generateBarcodeToolStripMenuItem_Click);
            // 
            // btnPriceBreakdown
            // 
            this.btnPriceBreakdown.Location = new System.Drawing.Point(286, 511);
            this.btnPriceBreakdown.Name = "btnPriceBreakdown";
            this.btnPriceBreakdown.Size = new System.Drawing.Size(115, 37);
            this.btnPriceBreakdown.TabIndex = 10;
            this.btnPriceBreakdown.Text = "Get Price EA";
            this.btnPriceBreakdown.UseVisualStyleBackColor = true;
            this.btnPriceBreakdown.Click += new System.EventHandler(this.btnPriceBreakdown_Click);
            // 
            // ReceiveShipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(113)))), ((int)(((byte)(108)))));
            this.ClientSize = new System.Drawing.Size(800, 560);
            this.Controls.Add(this.btnPriceBreakdown);
            this.Controls.Add(this.txtOrderNum);
            this.Controls.Add(this.lblOrderNum);
            this.Controls.Add(this.btnStageData);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.dtgridReceived);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btncompleteOrder);
            this.Controls.Add(this.txtQtyReceived);
            this.Controls.Add(this.lblQtyReceived);
            this.Controls.Add(this.txtQtyOrdered);
            this.Controls.Add(this.lblQtyOrdered);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtPoNumber);
            this.Controls.Add(this.lblPoNumber);
            this.Controls.Add(this.txtBarCode);
            this.Controls.Add(this.lblBarCode);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ReceiveShipment";
            this.Text = "Receive Shipment";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReceiveShipment_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dtgridReceived)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBarCode;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.TextBox txtPoNumber;
        private System.Windows.Forms.Label lblPoNumber;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtQtyOrdered;
        private System.Windows.Forms.Label lblQtyOrdered;
        private System.Windows.Forms.TextBox txtQtyReceived;
        private System.Windows.Forms.Label lblQtyReceived;
        private System.Windows.Forms.Button btncompleteOrder;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dtgridReceived;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Button btnStageData;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descript;
        private System.Windows.Forms.DataGridViewTextBoxColumn PoNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyOrdered;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyReceived;
        private System.Windows.Forms.DataGridViewTextBoxColumn cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.TextBox txtOrderNum;
        private System.Windows.Forms.Label lblOrderNum;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button btnPriceBreakdown;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateBarcodeToolStripMenuItem;
    }
}