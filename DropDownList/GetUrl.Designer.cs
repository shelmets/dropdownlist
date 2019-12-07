namespace DropDownList
{
    partial class GetUrl
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
        private void InitializeComponent(string country, string url)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetUrl));
            this.buttonOk = new System.Windows.Forms.Button();
            this.linkLabelUrl = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelCountry = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(115, 263);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // linkLabelUrl
            // 
            this.linkLabelUrl.AutoSize = true;
            this.linkLabelUrl.Location = new System.Drawing.Point(118, 165);
            this.linkLabelUrl.Name = "linkLabelUrl";
            this.linkLabelUrl.Text = url;
            this.linkLabelUrl.Size = new System.Drawing.Size(0, 17);
            this.linkLabelUrl.TabIndex = 1;
            this.linkLabelUrl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelUrl_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Link: ";
            // 
            // labelCountry
            // 
            this.labelCountry.AutoSize = true;
            this.labelCountry.Location = new System.Drawing.Point(118, 92);
            this.labelCountry.Name = "labelCountry";
            this.labelCountry.Text = country;
            this.labelCountry.Size = new System.Drawing.Size(0, 17);
            this.labelCountry.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Country: ";
            // 
            // GetUrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 314);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelCountry);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkLabelUrl);
            this.Controls.Add(this.buttonOk);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GetUrl";
            this.Text = "GetUrl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.LinkLabel linkLabelUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCountry;
        private System.Windows.Forms.Label label3;
    }
}