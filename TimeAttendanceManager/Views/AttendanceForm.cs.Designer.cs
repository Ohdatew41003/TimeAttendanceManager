namespace TimeAttendanceManager
{
    partial class AttendanceForm
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
            this.gridRecords = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTongHop = new System.Windows.Forms.Label();
            this.lblPhieuChamCong = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTaoPhieu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridRecords)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridRecords
            // 
            this.gridRecords.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gridRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRecords.Location = new System.Drawing.Point(222, 52);
            this.gridRecords.Name = "gridRecords";
            this.gridRecords.Size = new System.Drawing.Size(588, 218);
            this.gridRecords.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumPurple;
            this.panel1.Controls.Add(this.lblTongHop);
            this.panel1.Controls.Add(this.lblPhieuChamCong);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(23, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 206);
            this.panel1.TabIndex = 2;
            // 
            // lblTongHop
            // 
            this.lblTongHop.AutoSize = true;
            this.lblTongHop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongHop.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTongHop.Location = new System.Drawing.Point(84, 73);
            this.lblTongHop.Name = "lblTongHop";
            this.lblTongHop.Size = new System.Drawing.Size(63, 13);
            this.lblTongHop.TabIndex = 2;
            this.lblTongHop.Text = "Tổng Hợp";
            this.lblTongHop.Click += new System.EventHandler(this.lblTongHop_Click);
            // 
            // lblPhieuChamCong
            // 
            this.lblPhieuChamCong.AutoSize = true;
            this.lblPhieuChamCong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhieuChamCong.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPhieuChamCong.Location = new System.Drawing.Point(40, 37);
            this.lblPhieuChamCong.Name = "lblPhieuChamCong";
            this.lblPhieuChamCong.Size = new System.Drawing.Size(107, 13);
            this.lblPhieuChamCong.TabIndex = 1;
            this.lblPhieuChamCong.Text = "Phiếu Chấm Công";
            this.lblPhieuChamCong.Click += new System.EventHandler(this.lblPhieuChamCong_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(3, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Menu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(454, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tạo Phiếu";
            // 
            // btnTaoPhieu
            // 
            this.btnTaoPhieu.BackColor = System.Drawing.Color.ForestGreen;
            this.btnTaoPhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoPhieu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTaoPhieu.Location = new System.Drawing.Point(697, 18);
            this.btnTaoPhieu.Name = "btnTaoPhieu";
            this.btnTaoPhieu.Size = new System.Drawing.Size(113, 28);
            this.btnTaoPhieu.TabIndex = 5;
            this.btnTaoPhieu.Text = "+ Tạo Phiếu mới";
            this.btnTaoPhieu.UseVisualStyleBackColor = false;
            this.btnTaoPhieu.Click += new System.EventHandler(this.btnTaoPhieu_Click);
            // 
            // AttendanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 624);
            this.Controls.Add(this.btnTaoPhieu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gridRecords);
            this.Name = "AttendanceForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gridRecords)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridRecords;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTongHop;
        private System.Windows.Forms.Label lblPhieuChamCong;
        private System.Windows.Forms.Button btnTaoPhieu;
    }
}

