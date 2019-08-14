namespace BIG.VMS.PRESENT.Forms.FormReport
{
    partial class frmReportList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportList));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnPrintReport = new System.Windows.Forms.Button();
            this.btnPrintMonth = new System.Windows.Forms.Button();
            this.btnPrintToday = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.radAll = new System.Windows.Forms.RadioButton();
            this.radIn = new System.Windows.Forms.RadioButton();
            this.radOut = new System.Windows.Forms.RadioButton();
            this.gridReportList = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.ddlDept = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridReportList)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gridReportList, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1091, 661);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnPrintReport);
            this.panel1.Controls.Add(this.btnPrintMonth);
            this.panel1.Controls.Add(this.btnPrintToday);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 598);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1083, 59);
            this.panel1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(911, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(135, 59);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "ออก";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.White;
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.Location = new System.Drawing.Point(657, 0);
            this.btnExport.Margin = new System.Windows.Forms.Padding(8);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(254, 59);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "นำออก Excel";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.BackColor = System.Drawing.Color.White;
            this.btnPrintReport.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPrintReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintReport.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnPrintReport.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintReport.Image")));
            this.btnPrintReport.Location = new System.Drawing.Point(402, 0);
            this.btnPrintReport.Margin = new System.Windows.Forms.Padding(8);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(255, 59);
            this.btnPrintReport.TabIndex = 1;
            this.btnPrintReport.Text = "พิมพ์รายงานการค้นหา";
            this.btnPrintReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrintReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrintReport.UseVisualStyleBackColor = false;
            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
            // 
            // btnPrintMonth
            // 
            this.btnPrintMonth.BackColor = System.Drawing.Color.White;
            this.btnPrintMonth.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPrintMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintMonth.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnPrintMonth.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintMonth.Image")));
            this.btnPrintMonth.Location = new System.Drawing.Point(197, 0);
            this.btnPrintMonth.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrintMonth.Name = "btnPrintMonth";
            this.btnPrintMonth.Size = new System.Drawing.Size(205, 59);
            this.btnPrintMonth.TabIndex = 6;
            this.btnPrintMonth.Text = "พิมพ์รายเดือน";
            this.btnPrintMonth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrintMonth.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrintMonth.UseVisualStyleBackColor = false;
            this.btnPrintMonth.Click += new System.EventHandler(this.btnPrintMonth_Click);
            // 
            // btnPrintToday
            // 
            this.btnPrintToday.BackColor = System.Drawing.Color.White;
            this.btnPrintToday.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPrintToday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintToday.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintToday.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnPrintToday.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintToday.Image")));
            this.btnPrintToday.Location = new System.Drawing.Point(0, 0);
            this.btnPrintToday.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrintToday.Name = "btnPrintToday";
            this.btnPrintToday.Size = new System.Drawing.Size(197, 59);
            this.btnPrintToday.TabIndex = 5;
            this.btnPrintToday.Text = "พิมพ์รายวัน";
            this.btnPrintToday.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrintToday.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrintToday.UseVisualStyleBackColor = false;
            this.btnPrintToday.Click += new System.EventHandler(this.btnPrintToday_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel2.ColumnCount = 8;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 248F));
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtFrom, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtTo, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnSearch, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.ddlDept, 6, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1083, 100);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "เริ่มต้น";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(323, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "สิ้นสุด";
            // 
            // dtFrom
            // 
            this.dtFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtFrom.CustomFormat = "dd/MM/yyyy";
            this.dtFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFrom.Location = new System.Drawing.Point(85, 13);
            this.dtFrom.Margin = new System.Windows.Forms.Padding(4);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(230, 31);
            this.dtFrom.TabIndex = 1;
            this.dtFrom.Value = new System.DateTime(2019, 1, 1, 0, 0, 0, 0);
            // 
            // dtTo
            // 
            this.dtTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtTo.CustomFormat = "dd/MM/yyyy";
            this.dtTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTo.Location = new System.Drawing.Point(390, 13);
            this.dtTo.Margin = new System.Windows.Forms.Padding(4);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(230, 31);
            this.dtTo.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.White;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.Blue;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(628, 4);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(203, 50);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "ค้นหา";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(390, 66);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(230, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "มาพบฝ่าย";
            // 
            // flowLayoutPanel1
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Controls.Add(this.radAll);
            this.flowLayoutPanel1.Controls.Add(this.radIn);
            this.flowLayoutPanel1.Controls.Add(this.radOut);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(84, 61);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(298, 36);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // radAll
            // 
            this.radAll.AutoSize = true;
            this.radAll.Checked = true;
            this.radAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAll.Location = new System.Drawing.Point(3, 3);
            this.radAll.Name = "radAll";
            this.radAll.Size = new System.Drawing.Size(88, 29);
            this.radAll.TabIndex = 0;
            this.radAll.TabStop = true;
            this.radAll.Text = "ทั้งหมด";
            this.radAll.UseVisualStyleBackColor = true;
            // 
            // radIn
            // 
            this.radIn.AutoSize = true;
            this.radIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radIn.Location = new System.Drawing.Point(97, 3);
            this.radIn.Name = "radIn";
            this.radIn.Size = new System.Drawing.Size(57, 29);
            this.radIn.TabIndex = 1;
            this.radIn.Text = "เข้า";
            this.radIn.UseVisualStyleBackColor = true;
            // 
            // radOut
            // 
            this.radOut.AutoSize = true;
            this.radOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radOut.Location = new System.Drawing.Point(160, 3);
            this.radOut.Name = "radOut";
            this.radOut.Size = new System.Drawing.Size(63, 29);
            this.radOut.TabIndex = 2;
            this.radOut.Text = "ออก";
            this.radOut.UseVisualStyleBackColor = true;
            // 
            // gridReportList
            // 
            this.gridReportList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridReportList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridReportList.Location = new System.Drawing.Point(4, 112);
            this.gridReportList.Margin = new System.Windows.Forms.Padding(4);
            this.gridReportList.Name = "gridReportList";
            this.gridReportList.Size = new System.Drawing.Size(1083, 478);
            this.gridReportList.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 66);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "ประเภท";
            // 
            // ddlDept
            // 
            this.ddlDept.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlDept.FormattingEnabled = true;
            this.ddlDept.Location = new System.Drawing.Point(627, 61);
            this.ddlDept.Name = "ddlDept";
            this.ddlDept.Size = new System.Drawing.Size(204, 33);
            this.ddlDept.TabIndex = 9;
            // 
            // frmReportList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1091, 661);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmReportList";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "รายงาน";
            this.Load += new System.EventHandler(this.frmReportList_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridReportList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPrintReport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView gridReportList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Button btnPrintToday;
        private System.Windows.Forms.Button btnPrintMonth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton radAll;
        private System.Windows.Forms.RadioButton radIn;
        private System.Windows.Forms.RadioButton radOut;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ddlDept;
    }
}