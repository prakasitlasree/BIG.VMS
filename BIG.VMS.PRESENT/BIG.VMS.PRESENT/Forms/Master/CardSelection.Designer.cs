namespace BIG.VMS.PRESENT.Forms.Master
{
    partial class CardSelection
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_driving_licence = new System.Windows.Forms.Button();
            this.btn_NID = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btn_driving_licence, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_NID, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(808, 268);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btn_driving_licence
            // 
            this.btn_driving_licence.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_driving_licence.AutoEllipsis = true;
            this.btn_driving_licence.BackColor = System.Drawing.Color.DarkGreen;
            this.btn_driving_licence.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_driving_licence.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_driving_licence.Location = new System.Drawing.Point(407, 3);
            this.btn_driving_licence.Name = "btn_driving_licence";
            this.btn_driving_licence.Size = new System.Drawing.Size(398, 262);
            this.btn_driving_licence.TabIndex = 1;
            this.btn_driving_licence.Text = "(2) ใบขับขี่";
            this.btn_driving_licence.UseVisualStyleBackColor = false;
            // 
            // btn_NID
            // 
            this.btn_NID.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_NID.BackColor = System.Drawing.Color.MediumBlue;
            this.btn_NID.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_NID.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_NID.Location = new System.Drawing.Point(3, 3);
            this.btn_NID.Name = "btn_NID";
            this.btn_NID.Size = new System.Drawing.Size(398, 262);
            this.btn_NID.TabIndex = 0;
            this.btn_NID.Text = "(1) บัตรประชาชน";
            this.btn_NID.UseVisualStyleBackColor = false;
            this.btn_NID.Click += new System.EventHandler(this.btn_NID_Click);
            // 
            // CardSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 268);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CardSelection";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "กรุณาเลือกอ่านบัตร";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_NID;
        private System.Windows.Forms.Button btn_driving_licence;
    }
}