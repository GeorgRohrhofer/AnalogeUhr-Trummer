namespace AnalogeUhr
{
    partial class diagDigital
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
            this.btn_StartStop = new System.Windows.Forms.Button();
            this.txt_second = new System.Windows.Forms.RichTextBox();
            this.txt_minute = new System.Windows.Forms.RichTextBox();
            this.btn_zwischenzeit = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btn_StartStop
            // 
            this.btn_StartStop.Location = new System.Drawing.Point(12, 92);
            this.btn_StartStop.Name = "btn_StartStop";
            this.btn_StartStop.Size = new System.Drawing.Size(75, 23);
            this.btn_StartStop.TabIndex = 0;
            this.btn_StartStop.Text = "Start";
            this.btn_StartStop.UseVisualStyleBackColor = true;
            this.btn_StartStop.Click += new System.EventHandler(this.btn_StartStop_Click);
            // 
            // txt_second
            // 
            this.txt_second.Enabled = false;
            this.txt_second.Font = new System.Drawing.Font("Microsoft Sans Serif", 45F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_second.Location = new System.Drawing.Point(95, 12);
            this.txt_second.Multiline = false;
            this.txt_second.Name = "txt_second";
            this.txt_second.ReadOnly = true;
            this.txt_second.Size = new System.Drawing.Size(82, 74);
            this.txt_second.TabIndex = 3;
            this.txt_second.Text = "00";
            // 
            // txt_minute
            // 
            this.txt_minute.BackColor = System.Drawing.SystemColors.Control;
            this.txt_minute.Enabled = false;
            this.txt_minute.Font = new System.Drawing.Font("Microsoft Sans Serif", 45F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_minute.Location = new System.Drawing.Point(13, 12);
            this.txt_minute.Name = "txt_minute";
            this.txt_minute.Size = new System.Drawing.Size(74, 74);
            this.txt_minute.TabIndex = 2;
            this.txt_minute.Text = "00";
            // 
            // btn_zwischenzeit
            // 
            this.btn_zwischenzeit.Appearance = System.Windows.Forms.Appearance.Button;
            this.btn_zwischenzeit.Location = new System.Drawing.Point(95, 92);
            this.btn_zwischenzeit.Name = "btn_zwischenzeit";
            this.btn_zwischenzeit.Size = new System.Drawing.Size(81, 24);
            this.btn_zwischenzeit.TabIndex = 4;
            this.btn_zwischenzeit.Text = "Interim";
            this.btn_zwischenzeit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_zwischenzeit.UseVisualStyleBackColor = true;
            this.btn_zwischenzeit.Click += new System.EventHandler(this.btn_zwischenzeit_Click);
            // 
            // diagDigital
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(188, 127);
            this.Controls.Add(this.btn_zwischenzeit);
            this.Controls.Add(this.txt_second);
            this.Controls.Add(this.txt_minute);
            this.Controls.Add(this.btn_StartStop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "diagDigital";
            this.Text = "diagDigital";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_StartStop;
        private System.Windows.Forms.RichTextBox txt_second;
        private System.Windows.Forms.RichTextBox txt_minute;
        private System.Windows.Forms.CheckBox btn_zwischenzeit;
    }
}