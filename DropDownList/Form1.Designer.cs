namespace DropDownList
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBoxEnter = new System.Windows.Forms.TextBox();
            this.labelEnter = new System.Windows.Forms.Label();
            this.listBoxOutput = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // textBoxEnter
            // 
            this.textBoxEnter.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.textBoxEnter.Location = new System.Drawing.Point(176, 51);
            this.textBoxEnter.Name = "textBoxEnter";
            this.textBoxEnter.Size = new System.Drawing.Size(446, 22);
            this.textBoxEnter.TabIndex = 0;
            this.textBoxEnter.TextChanged += new System.EventHandler(this.textBoxEnter_TextChanged);
            // 
            // labelEnter
            // 
            this.labelEnter.AutoSize = true;
            this.labelEnter.Location = new System.Drawing.Point(29, 54);
            this.labelEnter.Name = "labelEnter";
            this.labelEnter.Size = new System.Drawing.Size(125, 17);
            this.labelEnter.TabIndex = 1;
            this.labelEnter.Text = "Enter the univesity";
            // 
            // listBoxOutput
            // 
            this.listBoxOutput.FormattingEnabled = true;
            this.listBoxOutput.ItemHeight = 16;
            this.listBoxOutput.Location = new System.Drawing.Point(176, 101);
            this.listBoxOutput.Name = "listBoxOutput";
            this.listBoxOutput.Size = new System.Drawing.Size(446, 308);
            this.listBoxOutput.TabIndex = 2;
            this.listBoxOutput.DoubleClick += new System.EventHandler(this.listBoxOutput_DoubleClick);
            this.listBoxOutput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listBoxOutput_Enter);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBoxOutput);
            this.Controls.Add(this.labelEnter);
            this.Controls.Add(this.textBoxEnter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Finder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxEnter;
        private System.Windows.Forms.Label labelEnter;
        private System.Windows.Forms.ListBox listBoxOutput;
    }
}

