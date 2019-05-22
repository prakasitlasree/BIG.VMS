namespace BIG.VMS.PRESENT.Forms.FormVisitor
{
    partial class frmVisitorOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVisitorOut));
            this.txtCarInfo = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPersonInfo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNo = new System.Windows.Forms.TextBox();
            this.picSlip = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.picCard = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnPhoto = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picSlip)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCard)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCarInfo
            // 
            this.txtCarInfo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tableLayoutPanel2.SetColumnSpan(this.txtCarInfo, 2);
            this.txtCarInfo.Location = new System.Drawing.Point(91, 108);
            this.txtCarInfo.Name = "txtCarInfo";
            this.txtCarInfo.ReadOnly = true;
            this.txtCarInfo.Size = new System.Drawing.Size(542, 31);
            this.txtCarInfo.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Red;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(142, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(133, 43);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "(4)ยกเลิก";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Enabled = false;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(3, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 43);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "(3)ยืนยัน";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "ข้อมูลรถ";
            // 
            // txtPersonInfo
            // 
            this.txtPersonInfo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tableLayoutPanel2.SetColumnSpan(this.txtPersonInfo, 2);
            this.txtPersonInfo.Location = new System.Drawing.Point(91, 71);
            this.txtPersonInfo.Name = "txtPersonInfo";
            this.txtPersonInfo.ReadOnly = true;
            this.txtPersonInfo.Size = new System.Drawing.Size(542, 31);
            this.txtPersonInfo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "ข้อมูลคน";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "เลขที่";
            // 
            // txtNo
            // 
            this.txtNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtNo.Location = new System.Drawing.Point(91, 18);
            this.txtNo.Name = "txtNo";
            this.txtNo.Size = new System.Drawing.Size(268, 31);
            this.txtNo.TabIndex = 1;
            this.txtNo.Click += new System.EventHandler(this.txtNo_Click);
            this.txtNo.TextChanged += new System.EventHandler(this.txtNo_TextChanged);
            this.txtNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNo_KeyPress);
            // 
            // picSlip
            // 
            this.picSlip.BackColor = System.Drawing.Color.White;
            this.picSlip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picSlip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picSlip.Image = ((System.Drawing.Image)(resources.GetObject("picSlip.Image")));
            this.picSlip.Location = new System.Drawing.Point(639, 170);
            this.picSlip.Name = "picSlip";
            this.picSlip.Size = new System.Drawing.Size(278, 192);
            this.picSlip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSlip.TabIndex = 5;
            this.picSlip.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.txtCarInfo, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.picSlip, 3, 4);
            this.tableLayoutPanel2.Controls.Add(this.txtNo, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtPersonInfo, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label6, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label7, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.label8, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.picImage, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.picCard, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 3, 5);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(920, 420);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(91, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 25);
            this.label6.TabIndex = 7;
            this.label6.Text = "รูปบัตรประชาชน";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(365, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 25);
            this.label7.TabIndex = 8;
            this.label7.Text = "รูปถ่าย";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(639, 142);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 25);
            this.label8.TabIndex = 10;
            this.label8.Text = "รูปสลิป";
            // 
            // picImage
            // 
            this.picImage.BackColor = System.Drawing.Color.White;
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picImage.Enabled = false;
            this.picImage.Image = ((System.Drawing.Image)(resources.GetObject("picImage.Image")));
            this.picImage.Location = new System.Drawing.Point(365, 170);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(268, 192);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImage.TabIndex = 9;
            this.picImage.TabStop = false;
            // 
            // picCard
            // 
            this.picCard.BackColor = System.Drawing.Color.White;
            this.picCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCard.Enabled = false;
            this.picCard.Image = ((System.Drawing.Image)(resources.GetObject("picCard.Image")));
            this.picCard.Location = new System.Drawing.Point(91, 170);
            this.picCard.Name = "picCard";
            this.picCard.Size = new System.Drawing.Size(268, 192);
            this.picCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCard.TabIndex = 7;
            this.picCard.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(639, 368);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(278, 49);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel2.SetColumnSpan(this.tableLayoutPanel3, 2);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.btnPhoto, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnFind, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(365, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(552, 62);
            this.tableLayoutPanel3.TabIndex = 12;
            // 
            // btnPhoto
            // 
            this.btnPhoto.BackColor = System.Drawing.Color.White;
            this.btnPhoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPhoto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhoto.ForeColor = System.Drawing.Color.Fuchsia;
            this.btnPhoto.Image = ((System.Drawing.Image)(resources.GetObject("btnPhoto.Image")));
            this.btnPhoto.Location = new System.Drawing.Point(278, 3);
            this.btnPhoto.Name = "btnPhoto";
            this.btnPhoto.Size = new System.Drawing.Size(271, 56);
            this.btnPhoto.TabIndex = 4;
            this.btnPhoto.Text = "(2)ถ่ายรูปสลิป";
            this.btnPhoto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPhoto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPhoto.UseVisualStyleBackColor = false;
            this.btnPhoto.Click += new System.EventHandler(this.btnPhoto_Click);
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.Color.White;
            this.btnFind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.ForeColor = System.Drawing.Color.Blue;
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.Location = new System.Drawing.Point(3, 3);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(269, 56);
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "(1)ค้นหา";
            this.btnFind.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // frmVisitorOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(920, 420);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVisitorOut";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ออก";
            this.Load += new System.EventHandler(this.frmVisitorOut_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picSlip)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCard)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNo;
        private System.Windows.Forms.TextBox txtPersonInfo;
        private System.Windows.Forms.TextBox txtCarInfo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picSlip;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.PictureBox picCard;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnPhoto;
        private System.Windows.Forms.Button btnFind;
    }
}