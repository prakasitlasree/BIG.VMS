namespace BIG.VMS.PRESENT.Forms.FormVisitor
{
    partial class frmAppointment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAppointment));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTopic = new System.Windows.Forms.Button();
            this.btnMeet = new System.Windows.Forms.Button();
            this.btnVehicle = new System.Windows.Forms.Button();
            this.btnReadCard = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.Lbl_LicensePlate = new System.Windows.Forms.Label();
            this.Lbl_MeetPeople = new System.Windows.Forms.Label();
            this.Lbl_Topic = new System.Windows.Forms.Label();
            this.Lbl_IDCard = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Lbl_FirstName = new System.Windows.Forms.Label();
            this.txtMeet = new System.Windows.Forms.TextBox();
            this.txtTopic = new System.Windows.Forms.TextBox();
            this.txtIDCard = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCar = new System.Windows.Forms.TextBox();
            this.Lbl_Vahicle = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnProvince = new System.Windows.Forms.Button();
            this.txtProvince = new System.Windows.Forms.TextBox();
            this.txtLicense = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtContactDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtTime = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 73.07111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.95159F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1272, 611);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnTopic);
            this.panel1.Controls.Add(this.btnMeet);
            this.panel1.Controls.Add(this.btnVehicle);
            this.panel1.Controls.Add(this.btnReadCard);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1260, 79);
            this.panel1.TabIndex = 0;
            // 
            // btnTopic
            // 
            this.btnTopic.BackColor = System.Drawing.Color.White;
            this.btnTopic.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTopic.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTopic.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTopic.ForeColor = System.Drawing.Color.OliveDrab;
            this.btnTopic.Image = ((System.Drawing.Image)(resources.GetObject("btnTopic.Image")));
            this.btnTopic.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTopic.Location = new System.Drawing.Point(880, 0);
            this.btnTopic.Margin = new System.Windows.Forms.Padding(6);
            this.btnTopic.Name = "btnTopic";
            this.btnTopic.Size = new System.Drawing.Size(250, 79);
            this.btnTopic.TabIndex = 0;
            this.btnTopic.Text = "(4) เลือกวัตถุประสงค์";
            this.btnTopic.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTopic.UseVisualStyleBackColor = false;
            this.btnTopic.Click += new System.EventHandler(this.btnTopic_Click);
            // 
            // btnMeet
            // 
            this.btnMeet.BackColor = System.Drawing.Color.White;
            this.btnMeet.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMeet.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMeet.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMeet.ForeColor = System.Drawing.Color.OliveDrab;
            this.btnMeet.Image = ((System.Drawing.Image)(resources.GetObject("btnMeet.Image")));
            this.btnMeet.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMeet.Location = new System.Drawing.Point(550, 0);
            this.btnMeet.Margin = new System.Windows.Forms.Padding(6);
            this.btnMeet.Name = "btnMeet";
            this.btnMeet.Size = new System.Drawing.Size(330, 79);
            this.btnMeet.TabIndex = 1;
            this.btnMeet.Text = "(3) เลือกบุคคลที่ต้องการเข้าพบ";
            this.btnMeet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMeet.UseVisualStyleBackColor = false;
            this.btnMeet.Click += new System.EventHandler(this.btnMeet_Click);
            // 
            // btnVehicle
            // 
            this.btnVehicle.BackColor = System.Drawing.Color.White;
            this.btnVehicle.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnVehicle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVehicle.ForeColor = System.Drawing.Color.Crimson;
            this.btnVehicle.Image = ((System.Drawing.Image)(resources.GetObject("btnVehicle.Image")));
            this.btnVehicle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVehicle.Location = new System.Drawing.Point(220, 0);
            this.btnVehicle.Margin = new System.Windows.Forms.Padding(6);
            this.btnVehicle.Name = "btnVehicle";
            this.btnVehicle.Size = new System.Drawing.Size(330, 79);
            this.btnVehicle.TabIndex = 2;
            this.btnVehicle.Text = "(2) เลือกประเภทรถยนต์";
            this.btnVehicle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVehicle.UseVisualStyleBackColor = false;
            this.btnVehicle.Click += new System.EventHandler(this.btnVehicle_Click);
            // 
            // btnReadCard
            // 
            this.btnReadCard.BackColor = System.Drawing.Color.White;
            this.btnReadCard.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnReadCard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReadCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReadCard.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnReadCard.Image = ((System.Drawing.Image)(resources.GetObject("btnReadCard.Image")));
            this.btnReadCard.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReadCard.Location = new System.Drawing.Point(0, 0);
            this.btnReadCard.Margin = new System.Windows.Forms.Padding(6);
            this.btnReadCard.Name = "btnReadCard";
            this.btnReadCard.Size = new System.Drawing.Size(220, 79);
            this.btnReadCard.TabIndex = 0;
            this.btnReadCard.Text = "(1) อ่านบัตร";
            this.btnReadCard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReadCard.UseVisualStyleBackColor = false;
            this.btnReadCard.Click += new System.EventHandler(this.btnReadCard_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(6, 543);
            this.panel2.Margin = new System.Windows.Forms.Padding(6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1260, 62);
            this.panel2.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(200, 0);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(200, 62);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnTakePhoto_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(0, 0);
            this.btnSave.Margin = new System.Windows.Forms.Padding(6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(200, 62);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "บันทึก";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 94);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1266, 440);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.label6, 0, 13);
            this.tableLayoutPanel4.Controls.Add(this.Lbl_LicensePlate, 0, 11);
            this.tableLayoutPanel4.Controls.Add(this.Lbl_MeetPeople, 0, 7);
            this.tableLayoutPanel4.Controls.Add(this.Lbl_Topic, 0, 6);
            this.tableLayoutPanel4.Controls.Add(this.Lbl_IDCard, 0, 5);
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.Lbl_FirstName, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.txtMeet, 1, 7);
            this.tableLayoutPanel4.Controls.Add(this.txtTopic, 1, 6);
            this.tableLayoutPanel4.Controls.Add(this.txtIDCard, 1, 5);
            this.tableLayoutPanel4.Controls.Add(this.txtLastName, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.txtFirstName, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 8);
            this.tableLayoutPanel4.Controls.Add(this.txtCar, 1, 8);
            this.tableLayoutPanel4.Controls.Add(this.Lbl_Vahicle, 0, 9);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel2, 1, 9);
            this.tableLayoutPanel4.Controls.Add(this.txtLicense, 1, 11);
            this.tableLayoutPanel4.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label5, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.dtContactDate, 1, 12);
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 12);
            this.tableLayoutPanel4.Controls.Add(this.dtTime, 1, 13);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 14;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(816, 434);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Crimson;
            this.label6.Location = new System.Drawing.Point(155, 447);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 20);
            this.label6.TabIndex = 24;
            this.label6.Text = "เวลา";
            // 
            // Lbl_LicensePlate
            // 
            this.Lbl_LicensePlate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Lbl_LicensePlate.AutoSize = true;
            this.Lbl_LicensePlate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_LicensePlate.ForeColor = System.Drawing.Color.Crimson;
            this.Lbl_LicensePlate.Location = new System.Drawing.Point(15, 367);
            this.Lbl_LicensePlate.Name = "Lbl_LicensePlate";
            this.Lbl_LicensePlate.Size = new System.Drawing.Size(203, 31);
            this.Lbl_LicensePlate.TabIndex = 3;
            this.Lbl_LicensePlate.Text = "หมายเลขทะเบียน";
            // 
            // Lbl_MeetPeople
            // 
            this.Lbl_MeetPeople.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Lbl_MeetPeople.AutoSize = true;
            this.Lbl_MeetPeople.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_MeetPeople.ForeColor = System.Drawing.Color.OliveDrab;
            this.Lbl_MeetPeople.Location = new System.Drawing.Point(3, 209);
            this.Lbl_MeetPeople.Name = "Lbl_MeetPeople";
            this.Lbl_MeetPeople.Size = new System.Drawing.Size(215, 31);
            this.Lbl_MeetPeople.TabIndex = 5;
            this.Lbl_MeetPeople.Text = "บุคคลที่ต้องการพบ";
            // 
            // Lbl_Topic
            // 
            this.Lbl_Topic.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Lbl_Topic.AutoSize = true;
            this.Lbl_Topic.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Topic.ForeColor = System.Drawing.Color.OliveDrab;
            this.Lbl_Topic.Location = new System.Drawing.Point(71, 166);
            this.Lbl_Topic.Name = "Lbl_Topic";
            this.Lbl_Topic.Size = new System.Drawing.Size(147, 31);
            this.Lbl_Topic.TabIndex = 4;
            this.Lbl_Topic.Text = "วัตถุประสงค์";
            // 
            // Lbl_IDCard
            // 
            this.Lbl_IDCard.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Lbl_IDCard.AutoSize = true;
            this.Lbl_IDCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_IDCard.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Lbl_IDCard.Location = new System.Drawing.Point(12, 123);
            this.Lbl_IDCard.Name = "Lbl_IDCard";
            this.Lbl_IDCard.Size = new System.Drawing.Size(206, 31);
            this.Lbl_IDCard.TabIndex = 1;
            this.Lbl_IDCard.Text = "เลขบัตรประชาชน";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(112, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 31);
            this.label3.TabIndex = 16;
            this.label3.Text = "นามสกุล";
            // 
            // Lbl_FirstName
            // 
            this.Lbl_FirstName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Lbl_FirstName.AutoSize = true;
            this.Lbl_FirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_FirstName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Lbl_FirstName.Location = new System.Drawing.Point(173, 37);
            this.Lbl_FirstName.Name = "Lbl_FirstName";
            this.Lbl_FirstName.Size = new System.Drawing.Size(45, 31);
            this.Lbl_FirstName.TabIndex = 0;
            this.Lbl_FirstName.Text = "ชื่อ";
            // 
            // txtMeet
            // 
            this.txtMeet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMeet.Enabled = false;
            this.txtMeet.Location = new System.Drawing.Point(224, 206);
            this.txtMeet.Name = "txtMeet";
            this.txtMeet.Size = new System.Drawing.Size(589, 37);
            this.txtMeet.TabIndex = 12;
            // 
            // txtTopic
            // 
            this.txtTopic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTopic.Enabled = false;
            this.txtTopic.Location = new System.Drawing.Point(224, 163);
            this.txtTopic.Name = "txtTopic";
            this.txtTopic.Size = new System.Drawing.Size(589, 37);
            this.txtTopic.TabIndex = 10;
            // 
            // txtIDCard
            // 
            this.txtIDCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIDCard.Location = new System.Drawing.Point(224, 120);
            this.txtIDCard.MaxLength = 14;
            this.txtIDCard.Name = "txtIDCard";
            this.txtIDCard.Size = new System.Drawing.Size(589, 37);
            this.txtIDCard.TabIndex = 2;
            // 
            // txtLastName
            // 
            this.txtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastName.Location = new System.Drawing.Point(224, 77);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(589, 37);
            this.txtLastName.TabIndex = 1;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.Location = new System.Drawing.Point(224, 34);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(589, 37);
            this.txtFirstName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Crimson;
            this.label2.Location = new System.Drawing.Point(38, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 31);
            this.label2.TabIndex = 13;
            this.label2.Text = "ประเภทรถยนต์";
            // 
            // txtCar
            // 
            this.txtCar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCar.Enabled = false;
            this.txtCar.Location = new System.Drawing.Point(224, 249);
            this.txtCar.Name = "txtCar";
            this.txtCar.Size = new System.Drawing.Size(589, 37);
            this.txtCar.TabIndex = 14;
            // 
            // Lbl_Vahicle
            // 
            this.Lbl_Vahicle.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Lbl_Vahicle.AutoSize = true;
            this.Lbl_Vahicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Vahicle.ForeColor = System.Drawing.Color.Crimson;
            this.Lbl_Vahicle.Location = new System.Drawing.Point(131, 309);
            this.Lbl_Vahicle.Name = "Lbl_Vahicle";
            this.Lbl_Vahicle.Size = new System.Drawing.Size(87, 31);
            this.Lbl_Vahicle.TabIndex = 2;
            this.Lbl_Vahicle.Text = "จังหวัด";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnProvince, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtProvince, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(224, 292);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(589, 66);
            this.tableLayoutPanel2.TabIndex = 18;
            // 
            // btnProvince
            // 
            this.btnProvince.BackColor = System.Drawing.Color.White;
            this.btnProvince.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnProvince.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProvince.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProvince.ForeColor = System.Drawing.Color.Crimson;
            this.btnProvince.Image = ((System.Drawing.Image)(resources.GetObject("btnProvince.Image")));
            this.btnProvince.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProvince.Location = new System.Drawing.Point(300, 6);
            this.btnProvince.Margin = new System.Windows.Forms.Padding(6);
            this.btnProvince.Name = "btnProvince";
            this.btnProvince.Size = new System.Drawing.Size(283, 54);
            this.btnProvince.TabIndex = 0;
            this.btnProvince.Text = "เลือกจังหวัด";
            this.btnProvince.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProvince.UseVisualStyleBackColor = false;
            this.btnProvince.Click += new System.EventHandler(this.btnProvince_Click);
            // 
            // txtProvince
            // 
            this.txtProvince.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProvince.Enabled = false;
            this.txtProvince.Location = new System.Drawing.Point(3, 14);
            this.txtProvince.Name = "txtProvince";
            this.txtProvince.Size = new System.Drawing.Size(288, 37);
            this.txtProvince.TabIndex = 11;
            // 
            // txtLicense
            // 
            this.txtLicense.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLicense.Location = new System.Drawing.Point(224, 364);
            this.txtLicense.Name = "txtLicense";
            this.txtLicense.Size = new System.Drawing.Size(589, 37);
            this.txtLicense.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(50, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 31);
            this.label4.TabIndex = 20;
            this.label4.Text = "การทำรายการ";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(224, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(589, 31);
            this.label5.TabIndex = 21;
            this.label5.Text = "นัดล่วงหน้า";
            // 
            // dtContactDate
            // 
            this.dtContactDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtContactDate.CustomFormat = "dd-MM-yy";
            this.dtContactDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtContactDate.Location = new System.Drawing.Point(224, 407);
            this.dtContactDate.Name = "dtContactDate";
            this.dtContactDate.Size = new System.Drawing.Size(589, 37);
            this.dtContactDate.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(91, 410);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 31);
            this.label1.TabIndex = 23;
            this.label1.Text = "วันที่จะเข้า";
            // 
            // dtTime
            // 
            this.dtTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtTime.CustomFormat = "hh:mm:ss";
            this.dtTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtTime.Location = new System.Drawing.Point(224, 450);
            this.dtTime.Name = "dtTime";
            this.dtTime.ShowUpDown = true;
            this.dtTime.Size = new System.Drawing.Size(589, 37);
            this.dtTime.TabIndex = 25;
            // 
            // frmAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1272, 611);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmAppointment";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "นัดล่วงหน้า";
            this.Load += new System.EventHandler(this.frmAppointment_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label Lbl_LicensePlate;
        private System.Windows.Forms.Label Lbl_MeetPeople;
        private System.Windows.Forms.Label Lbl_Topic;
        private System.Windows.Forms.Label Lbl_IDCard;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Lbl_FirstName;
        private System.Windows.Forms.TextBox txtMeet;
        private System.Windows.Forms.TextBox txtTopic;
        private System.Windows.Forms.TextBox txtIDCard;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCar;
        private System.Windows.Forms.Label Lbl_Vahicle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnProvince;
        private System.Windows.Forms.TextBox txtProvince;
        private System.Windows.Forms.TextBox txtLicense;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnTopic;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMeet;
        private System.Windows.Forms.Button btnVehicle;
        private System.Windows.Forms.Button btnReadCard;
        private System.Windows.Forms.DateTimePicker dtContactDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtTime;
    }
}