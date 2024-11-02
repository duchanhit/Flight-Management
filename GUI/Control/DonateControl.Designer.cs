namespace GUI.Control
{
    partial class DonateControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.MiniMize = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.AutoSize = false;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.Blue;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(4, 4);
            this.guna2HtmlLabel1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(550, 59);
            this.guna2HtmlLabel1.TabIndex = 7;
            this.guna2HtmlLabel1.Text = "Donate ";
            // 
            // MiniMize
            // 
            this.MiniMize.BackgroundImage = global::GUI.Properties.Resources.minus;
            this.MiniMize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MiniMize.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.MiniMize.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.MiniMize.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.MiniMize.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.MiniMize.FillColor = System.Drawing.Color.Transparent;
            this.MiniMize.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MiniMize.ForeColor = System.Drawing.Color.White;
            this.MiniMize.Location = new System.Drawing.Point(905, 0);
            this.MiniMize.Margin = new System.Windows.Forms.Padding(4);
            this.MiniMize.Name = "MiniMize";
            this.MiniMize.Size = new System.Drawing.Size(29, 26);
            this.MiniMize.TabIndex = 8;
            this.MiniMize.Click += new System.EventHandler(this.MiniMize_Click);
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.SystemColors.Control;
            this.guna2ControlBox1.ForeColor = System.Drawing.Color.Black;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.Black;
            this.guna2ControlBox1.Location = new System.Drawing.Point(942, 0);
            this.guna2ControlBox1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(29, 27);
            this.guna2ControlBox1.TabIndex = 9;
            // 
            // DonateControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.MiniMize);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DonateControl";
            this.Size = new System.Drawing.Size(969, 610);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Button MiniMize;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
    }
}
