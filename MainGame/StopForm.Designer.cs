
namespace MainGame
{
    partial class StopForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StopForm));
            this.btnNO = new System.Windows.Forms.Button();
            this.lblStopForm = new System.Windows.Forms.Label();
            this.btnYES = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnNO
            // 
            this.btnNO.BackColor = System.Drawing.Color.DimGray;
            this.btnNO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNO.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btnNO.Location = new System.Drawing.Point(102, 105);
            this.btnNO.Name = "btnNO";
            this.btnNO.Size = new System.Drawing.Size(154, 33);
            this.btnNO.TabIndex = 44;
            this.btnNO.Text = "NO";
            this.btnNO.UseVisualStyleBackColor = false;
            this.btnNO.Click += new System.EventHandler(this.btnNO_Click);
            // 
            // lblStopForm
            // 
            this.lblStopForm.AutoSize = true;
            this.lblStopForm.Font = new System.Drawing.Font("Futura Bk BT", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStopForm.ForeColor = System.Drawing.Color.DarkGray;
            this.lblStopForm.Location = new System.Drawing.Point(90, 28);
            this.lblStopForm.Name = "lblStopForm";
            this.lblStopForm.Size = new System.Drawing.Size(377, 25);
            this.lblStopForm.TabIndex = 43;
            this.lblStopForm.Text = "ARE YOU SURE YOU WANT TO STOP ?";
            this.lblStopForm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnYES
            // 
            this.btnYES.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYES.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYES.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYES.ForeColor = System.Drawing.Color.DimGray;
            this.btnYES.Location = new System.Drawing.Point(292, 105);
            this.btnYES.Name = "btnYES";
            this.btnYES.Size = new System.Drawing.Size(154, 33);
            this.btnYES.TabIndex = 42;
            this.btnYES.Text = "YES";
            this.btnYES.UseVisualStyleBackColor = true;
            this.btnYES.Click += new System.EventHandler(this.btnYES_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(128, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 19);
            this.label1.TabIndex = 45;
            this.label1.Text = "ALL OF YOUR PROGRESS WILL BE LOST !";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(548, 169);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNO);
            this.Controls.Add(this.lblStopForm);
            this.Controls.Add(this.btnYES);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StopForm";
            this.Text = "StopForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNO;
        private System.Windows.Forms.Label lblStopForm;
        private System.Windows.Forms.Button btnYES;
        private System.Windows.Forms.Label label1;
    }
}