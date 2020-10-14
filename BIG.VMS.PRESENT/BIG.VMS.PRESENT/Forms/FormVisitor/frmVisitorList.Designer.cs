namespace BIG.VMS.PRESENT.Forms.Home
{
    partial class frmVisitorList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVisitorList));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.gridVisitorList = new System.Windows.Forms.DataGridView();
            this.colEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.colPrint = new System.Windows.Forms.DataGridViewImageColumn();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.txtPage = new System.Windows.Forms.TextBox();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.txtIDCard = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtLicense = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboType = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnBlacklist = new System.Windows.Forms.Button();
            this.btnListExit = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTodayOut = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblAllCount = new System.Windows.Forms.Label();
            this.lblTodayIn = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAhead = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnOut = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridVisitorList)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1040, 676);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.gridVisitorList, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 241);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1034, 432);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // gridVisitorList
            // 
            this.gridVisitorList.AllowUserToAddRows = false;
            this.gridVisitorList.AllowUserToDeleteRows = false;
            this.gridVisitorList.BackgroundColor = System.Drawing.Color.White;
            this.gridVisitorList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridVisitorList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEdit,
            this.colDelete,
            this.colPrint});
            this.gridVisitorList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridVisitorList.Location = new System.Drawing.Point(3, 3);
            this.gridVisitorList.Name = "gridVisitorList";
            this.gridVisitorList.ReadOnly = true;
            this.gridVisitorList.Size = new System.Drawing.Size(1028, 376);
            this.gridVisitorList.TabIndex = 0;
            this.gridVisitorList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridVisitorList_CellContentClick);
            // 
            // colEdit
            // 
            this.colEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colEdit.HeaderText = "แก้ไข";
            this.colEdit.Image = ((System.Drawing.Image)(resources.GetObject("colEdit.Image")));
            this.colEdit.Name = "colEdit";
            this.colEdit.ReadOnly = true;
            this.colEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colEdit.Width = 60;
            // 
            // colDelete
            // 
            this.colDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colDelete.HeaderText = "ลบ";
            this.colDelete.Image = ((System.Drawing.Image)(resources.GetObject("colDelete.Image")));
            this.colDelete.Name = "colDelete";
            this.colDelete.ReadOnly = true;
            this.colDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDelete.Width = 60;
            // 
            // colPrint
            // 
            this.colPrint.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colPrint.HeaderText = "พิมพ์";
            this.colPrint.Image = ((System.Drawing.Image)(resources.GetObject("colPrint.Image")));
            this.colPrint.Name = "colPrint";
            this.colPrint.ReadOnly = true;
            this.colPrint.Width = 60;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel4.ColumnCount = 5;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.Controls.Add(this.txtPage, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnFirst, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnPrevious, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnNext, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnLast, 4, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 385);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1028, 44);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // txtPage
            // 
            this.txtPage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPage.Enabled = false;
            this.txtPage.Location = new System.Drawing.Point(8, 6);
            this.txtPage.Name = "txtPage";
            this.txtPage.Size = new System.Drawing.Size(188, 31);
            this.txtPage.TabIndex = 1;
            this.txtPage.Text = "หน้า";
            // 
            // btnFirst
            // 
            this.btnFirst.BackColor = System.Drawing.Color.White;
            this.btnFirst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFirst.Image = ((System.Drawing.Image)(resources.GetObject("btnFirst.Image")));
            this.btnFirst.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFirst.Location = new System.Drawing.Point(208, 3);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(199, 38);
            this.btnFirst.TabIndex = 0;
            this.btnFirst.Text = "หน้าแรก";
            this.btnFirst.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFirst.UseVisualStyleBackColor = false;
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.White;
            this.btnPrevious.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPrevious.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevious.Image")));
            this.btnPrevious.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrevious.Location = new System.Drawing.Point(413, 3);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(199, 38);
            this.btnPrevious.TabIndex = 1;
            this.btnPrevious.Text = "หน้าก่อนหน้า";
            this.btnPrevious.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrevious.UseVisualStyleBackColor = false;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.White;
            this.btnNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.Location = new System.Drawing.Point(618, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(199, 38);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "หน้าถัดไป";
            this.btnNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.BackColor = System.Drawing.Color.White;
            this.btnLast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLast.Image = ((System.Drawing.Image)(resources.GetObject("btnLast.Image")));
            this.btnLast.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLast.Location = new System.Drawing.Point(823, 3);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(202, 38);
            this.btnLast.TabIndex = 3;
            this.btnLast.Text = "หน้าสุดท้าย";
            this.btnLast.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLast.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tableLayoutPanel5.ColumnCount = 6;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.Controls.Add(this.txtIDCard, 5, 0);
            this.tableLayoutPanel5.Controls.Add(this.txtLastName, 3, 0);
            this.tableLayoutPanel5.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.label5, 4, 0);
            this.tableLayoutPanel5.Controls.Add(this.txtName, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.txtLicense, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.label6, 2, 1);
            this.tableLayoutPanel5.Controls.Add(this.txtNo, 3, 1);
            this.tableLayoutPanel5.Controls.Add(this.label4, 4, 1);
            this.tableLayoutPanel5.Controls.Add(this.comboType, 5, 1);
            this.tableLayoutPanel5.Controls.Add(this.panel2, 1, 2);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 109);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1034, 126);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // txtIDCard
            // 
            this.txtIDCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIDCard.Location = new System.Drawing.Point(796, 3);
            this.txtIDCard.Name = "txtIDCard";
            this.txtIDCard.Size = new System.Drawing.Size(235, 31);
            this.txtIDCard.TabIndex = 10;
            // 
            // txtLastName
            // 
            this.txtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastName.Location = new System.Drawing.Point(428, 3);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(233, 31);
            this.txtLastName.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "ชื่อ";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "ทะเบียนรถ";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(344, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "นามสกุล";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(667, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "บัตรประชาชน";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(105, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(233, 31);
            this.txtName.TabIndex = 6;
            // 
            // txtLicense
            // 
            this.txtLicense.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLicense.Location = new System.Drawing.Point(105, 40);
            this.txtLicense.Name = "txtLicense";
            this.txtLicense.Size = new System.Drawing.Size(233, 31);
            this.txtLicense.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(344, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "เลขที่";
            // 
            // txtNo
            // 
            this.txtNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNo.Location = new System.Drawing.Point(428, 40);
            this.txtNo.Name = "txtNo";
            this.txtNo.Size = new System.Drawing.Size(233, 31);
            this.txtNo.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(667, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 25);
            this.label4.TabIndex = 13;
            this.label4.Text = "ประเภท";
            // 
            // comboType
            // 
            this.comboType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboType.FormattingEnabled = true;
            this.comboType.Items.AddRange(new object[] {
            "ทั้งหมด",
            "เข้า",
            "ออก",
            "นัดล่วงหน้า(เข้า)",
            "นัดล่วงหน้า(ออก)"});
            this.comboType.Location = new System.Drawing.Point(796, 45);
            this.comboType.Name = "comboType";
            this.comboType.Size = new System.Drawing.Size(235, 33);
            this.comboType.TabIndex = 14;
            // 
            // panel2
            // 
            this.tableLayoutPanel5.SetColumnSpan(this.panel2, 5);
            this.panel2.Controls.Add(this.btnBlacklist);
            this.panel2.Controls.Add(this.btnListExit);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(105, 77);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(926, 46);
            this.panel2.TabIndex = 16;
            // 
            // btnBlacklist
            // 
            this.btnBlacklist.BackColor = System.Drawing.Color.MistyRose;
            this.btnBlacklist.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBlacklist.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBlacklist.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBlacklist.ForeColor = System.Drawing.Color.Red;
            this.btnBlacklist.Image = ((System.Drawing.Image)(resources.GetObject("btnBlacklist.Image")));
            this.btnBlacklist.Location = new System.Drawing.Point(738, 0);
            this.btnBlacklist.Name = "btnBlacklist";
            this.btnBlacklist.Size = new System.Drawing.Size(188, 46);
            this.btnBlacklist.TabIndex = 15;
            this.btnBlacklist.Text = "Blacklist";
            this.btnBlacklist.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBlacklist.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBlacklist.UseVisualStyleBackColor = false;
            this.btnBlacklist.Click += new System.EventHandler(this.btnBlacklist_Click);
            // 
            // btnListExit
            // 
            this.btnListExit.BackColor = System.Drawing.SystemColors.Info;
            this.btnListExit.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnListExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnListExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListExit.ForeColor = System.Drawing.Color.Black;
            this.btnListExit.Location = new System.Drawing.Point(186, 0);
            this.btnListExit.Name = "btnListExit";
            this.btnListExit.Size = new System.Drawing.Size(224, 46);
            this.btnListExit.TabIndex = 16;
            this.btnListExit.Text = "รายการคนที่ยังไม่ออก";
            this.btnListExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnListExit.UseVisualStyleBackColor = false;
            this.btnListExit.Click += new System.EventHandler(this.btnListExit_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.LightCyan;
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.Blue;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.Location = new System.Drawing.Point(0, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(186, 46);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "ค้นหา";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btnAhead);
            this.panel1.Controls.Add(this.btnReport);
            this.panel1.Controls.Add(this.btnOut);
            this.panel1.Controls.Add(this.btnIn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1034, 100);
            this.panel1.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.PapayaWhip;
            this.panel3.Controls.Add(this.lblTodayOut);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.lblAllCount);
            this.panel3.Controls.Add(this.lblTodayIn);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(762, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(272, 100);
            this.panel3.TabIndex = 17;
            // 
            // lblTodayOut
            // 
            this.lblTodayOut.AutoSize = true;
            this.lblTodayOut.Location = new System.Drawing.Point(199, 36);
            this.lblTodayOut.Name = "lblTodayOut";
            this.lblTodayOut.Size = new System.Drawing.Size(24, 25);
            this.lblTodayOut.TabIndex = 5;
            this.lblTodayOut.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(161, 25);
            this.label9.TabIndex = 4;
            this.label9.Text = "จำนวนคนออกวันนี้";
            // 
            // lblAllCount
            // 
            this.lblAllCount.AutoSize = true;
            this.lblAllCount.Location = new System.Drawing.Point(199, 68);
            this.lblAllCount.Name = "lblAllCount";
            this.lblAllCount.Size = new System.Drawing.Size(24, 25);
            this.lblAllCount.TabIndex = 3;
            this.lblAllCount.Text = "0";
            // 
            // lblTodayIn
            // 
            this.lblTodayIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTodayIn.AutoSize = true;
            this.lblTodayIn.Location = new System.Drawing.Point(199, 4);
            this.lblTodayIn.Name = "lblTodayIn";
            this.lblTodayIn.Size = new System.Drawing.Size(24, 25);
            this.lblTodayIn.TabIndex = 2;
            this.lblTodayIn.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(177, 25);
            this.label8.TabIndex = 1;
            this.label8.Text = "จำนวนคนเข้าทั้งหมด";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 25);
            this.label7.TabIndex = 0;
            this.label7.Text = "จำนวนคนเข้าวันนี้";
            // 
            // btnAhead
            // 
            this.btnAhead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnAhead.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAhead.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAhead.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAhead.ForeColor = System.Drawing.Color.Black;
            this.btnAhead.Image = ((System.Drawing.Image)(resources.GetObject("btnAhead.Image")));
            this.btnAhead.Location = new System.Drawing.Point(567, 0);
            this.btnAhead.Name = "btnAhead";
            this.btnAhead.Size = new System.Drawing.Size(189, 100);
            this.btnAhead.TabIndex = 4;
            this.btnAhead.Text = "นัดล่วงหน้า";
            this.btnAhead.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAhead.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAhead.UseVisualStyleBackColor = false;
            this.btnAhead.Visible = false;
            this.btnAhead.Click += new System.EventHandler(this.btnAhead_Click);
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.Color.LightCyan;
            this.btnReport.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.ForeColor = System.Drawing.Color.Black;
            this.btnReport.Image = ((System.Drawing.Image)(resources.GetObject("btnReport.Image")));
            this.btnReport.Location = new System.Drawing.Point(378, 0);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(189, 100);
            this.btnReport.TabIndex = 5;
            this.btnReport.Text = "รายงาน";
            this.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnOut
            // 
            this.btnOut.BackColor = System.Drawing.Color.MistyRose;
            this.btnOut.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnOut.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOut.ForeColor = System.Drawing.Color.Black;
            this.btnOut.Image = ((System.Drawing.Image)(resources.GetObject("btnOut.Image")));
            this.btnOut.Location = new System.Drawing.Point(189, 0);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(189, 100);
            this.btnOut.TabIndex = 2;
            this.btnOut.Text = "ออก";
            this.btnOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOut.UseVisualStyleBackColor = false;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // btnIn
            // 
            this.btnIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnIn.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnIn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.ForeColor = System.Drawing.Color.Black;
            this.btnIn.Image = ((System.Drawing.Image)(resources.GetObject("btnIn.Image")));
            this.btnIn.Location = new System.Drawing.Point(0, 0);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(189, 100);
            this.btnIn.TabIndex = 1;
            this.btnIn.Text = "เข้า";
            this.btnIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIn.UseVisualStyleBackColor = false;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // frmVisitorList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 676);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmVisitorList";
            this.ShowIcon = false;
            this.Text = "รายการทั้งหมด";
            this.Load += new System.EventHandler(this.frmAllvisitor_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridVisitorList)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataGridView gridVisitorList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.TextBox txtPage;
        private System.Windows.Forms.Button btnOut;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnAhead;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TextBox txtIDCard;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtLicense;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewImageColumn colEdit;
        private System.Windows.Forms.DataGridViewImageColumn colDelete;
        private System.Windows.Forms.DataGridViewImageColumn colPrint;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboType;
        private System.Windows.Forms.Button btnBlacklist;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnListExit;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblAllCount;
        private System.Windows.Forms.Label lblTodayIn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTodayOut;
        private System.Windows.Forms.Label label9;
    }
}