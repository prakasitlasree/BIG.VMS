namespace BIG.VMS.PRESENT.Forms.FormVisitor
{
    partial class frmSelectInType
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
            this.btnInWithOutCard = new System.Windows.Forms.Button();
            this.btnInCard = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnInWithOutCard, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnInCard, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(646, 272);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnInWithOutCard
            // 
            this.btnInWithOutCard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInWithOutCard.AutoEllipsis = true;
            this.btnInWithOutCard.BackColor = System.Drawing.Color.DarkGreen;
            this.btnInWithOutCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInWithOutCard.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnInWithOutCard.Location = new System.Drawing.Point(325, 2);
            this.btnInWithOutCard.Margin = new System.Windows.Forms.Padding(2);
            this.btnInWithOutCard.Name = "btnInWithOutCard";
            this.btnInWithOutCard.Size = new System.Drawing.Size(319, 268);
            this.btnInWithOutCard.TabIndex = 1;
            this.btnInWithOutCard.Text = "เข้าโดยไม่ใช้บัตร";
            this.btnInWithOutCard.UseVisualStyleBackColor = false;
            this.btnInWithOutCard.Click += new System.EventHandler(this.btnInWithOutCard_Click);
            // 
            // btnInCard
            // 
            this.btnInCard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInCard.BackColor = System.Drawing.Color.MediumBlue;
            this.btnInCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInCard.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnInCard.Location = new System.Drawing.Point(2, 2);
            this.btnInCard.Margin = new System.Windows.Forms.Padding(2);
            this.btnInCard.Name = "btnInCard";
            this.btnInCard.Size = new System.Drawing.Size(319, 268);
            this.btnInCard.TabIndex = 0;
            this.btnInCard.Text = "เข้าโดยใช้บัตรประชาชน/ใบขับขี่ี";
            this.btnInCard.UseVisualStyleBackColor = false;
            this.btnInCard.Click += new System.EventHandler(this.btnInCard_Click);
            // 
            // frmSelectInType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 272);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmSelectInType";
            this.ShowIcon = false;
            this.Text = "เลือกวิธีเข้า";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnInWithOutCard;
        private System.Windows.Forms.Button btnInCard;
    }
}