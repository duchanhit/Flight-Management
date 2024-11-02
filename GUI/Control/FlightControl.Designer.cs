namespace GUI.Control
{
    partial class FlightControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelFlightList = new System.Windows.Forms.Panel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnload = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cmbCity = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Button8 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dgvList = new Guna.UI2.WinForms.Guna2DataGridView();
            this.webViewMap = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.panelFlightList.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.webViewMap)).BeginInit();
            this.SuspendLayout();
            // 
            // panelFlightList
            // 
            this.panelFlightList.Controls.Add(this.webViewMap);
            this.panelFlightList.Controls.Add(this.dgvList);
            this.panelFlightList.Controls.Add(this.guna2Panel2);
            this.panelFlightList.Controls.Add(this.guna2Panel1);
            this.panelFlightList.Location = new System.Drawing.Point(0, 0);
            this.panelFlightList.Margin = new System.Windows.Forms.Padding(4);
            this.panelFlightList.Name = "panelFlightList";
            this.panelFlightList.Size = new System.Drawing.Size(964, 607);
            this.panelFlightList.TabIndex = 0;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.btnload);
            this.guna2Panel2.Controls.Add(this.guna2HtmlLabel2);
            this.guna2Panel2.Controls.Add(this.cmbCity);
            this.guna2Panel2.Controls.Add(this.label1);
            this.guna2Panel2.Location = new System.Drawing.Point(4, 47);
            this.guna2Panel2.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(956, 80);
            this.guna2Panel2.TabIndex = 10;
            // 
            // btnload
            // 
            this.btnload.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnload.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnload.Image = global::GUI.Properties.Resources.Restart1;
            this.btnload.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnload.ImageRotate = 90F;
            this.btnload.ImageSize = new System.Drawing.Size(40, 40);
            this.btnload.Location = new System.Drawing.Point(857, 20);
            this.btnload.Margin = new System.Windows.Forms.Padding(4);
            this.btnload.Name = "btnload";
            this.btnload.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnload.Size = new System.Drawing.Size(63, 44);
            this.btnload.TabIndex = 13;
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.AutoSize = false;
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(-4, 28);
            this.guna2HtmlLabel2.Margin = new System.Windows.Forms.Padding(4);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(187, 48);
            this.guna2HtmlLabel2.TabIndex = 12;
            this.guna2HtmlLabel2.Text = "Thành phố";
            // 
            // cmbCity
            // 
            this.cmbCity.BackColor = System.Drawing.Color.Transparent;
            this.cmbCity.BorderRadius = 8;
            this.cmbCity.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCity.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbCity.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbCity.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbCity.ItemHeight = 30;
            this.cmbCity.Location = new System.Drawing.Point(121, 28);
            this.cmbCity.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCity.Name = "cmbCity";
            this.cmbCity.Size = new System.Drawing.Size(728, 36);
            this.cmbCity.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(356, -3);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(362, 27);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tìm Kiếm Chuyến Bay";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.guna2Button8);
            this.guna2Panel1.Controls.Add(this.guna2ControlBox1);
            this.guna2Panel1.Controls.Add(this.guna2HtmlLabel1);
            this.guna2Panel1.Location = new System.Drawing.Point(4, 4);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(956, 36);
            this.guna2Panel1.TabIndex = 8;
            // 
            // guna2Button8
            // 
            this.guna2Button8.BackgroundImage = global::GUI.Properties.Resources.minus;
            this.guna2Button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.guna2Button8.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button8.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button8.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button8.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button8.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button8.ForeColor = System.Drawing.Color.White;
            this.guna2Button8.Location = new System.Drawing.Point(885, 5);
            this.guna2Button8.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Button8.Name = "guna2Button8";
            this.guna2Button8.Size = new System.Drawing.Size(29, 26);
            this.guna2Button8.TabIndex = 9;
            this.guna2Button8.Click += new System.EventHandler(this.guna2Button8_Click);
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.SystemColors.Control;
            this.guna2ControlBox1.ForeColor = System.Drawing.Color.Black;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.Black;
            this.guna2ControlBox1.Location = new System.Drawing.Point(923, 4);
            this.guna2ControlBox1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(29, 27);
            this.guna2ControlBox1.TabIndex = 8;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.AutoSize = false;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.Blue;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(4, 2);
            this.guna2HtmlLabel1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(542, 61);
            this.guna2HtmlLabel1.TabIndex = 6;
            this.guna2HtmlLabel1.Text = "Danh sách chuyến bay";
            // 
            // dgvList
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvList.ColumnHeadersHeight = 4;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvList.Location = new System.Drawing.Point(8, 130);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowHeadersWidth = 51;
            this.dgvList.RowTemplate.Height = 24;
            this.dgvList.Size = new System.Drawing.Size(940, 227);
            this.dgvList.TabIndex = 12;
            this.dgvList.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvList.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvList.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvList.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvList.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvList.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvList.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvList.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvList.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvList.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvList.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvList.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvList.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvList.ThemeStyle.ReadOnly = false;
            this.dgvList.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvList.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvList.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvList.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvList.ThemeStyle.RowsStyle.Height = 24;
            this.dgvList.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvList.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // webViewMap
            // 
            this.webViewMap.AllowExternalDrop = true;
            this.webViewMap.CreationProperties = null;
            this.webViewMap.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webViewMap.Location = new System.Drawing.Point(4, 363);
            this.webViewMap.Name = "webViewMap";
            this.webViewMap.Size = new System.Drawing.Size(957, 241);
            this.webViewMap.TabIndex = 13;
            this.webViewMap.ZoomFactor = 1D;
            // 
            // FlightControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelFlightList);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FlightControl";
            this.Size = new System.Drawing.Size(964, 607);
            this.panelFlightList.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.webViewMap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFlightList;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Button guna2Button8;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2ImageButton btnload;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2ComboBox cmbCity;
        private Guna.UI2.WinForms.Guna2DataGridView dgvList;
        private Microsoft.Web.WebView2.WinForms.WebView2 webViewMap;
    }
}