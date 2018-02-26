namespace RTD2660
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonErase = new System.Windows.Forms.Button();
            this.buttonFlash = new System.Windows.Forms.Button();
            this.buttonFile = new System.Windows.Forms.Button();
            this.fileInputTextBox = new System.Windows.Forms.TextBox();
            this.debugTextBox = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.serialPortcComboBox = new System.Windows.Forms.ComboBox();
            this.buttonInfo = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(139, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port:";
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(280, 10);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(75, 23);
            this.buttonOpen.TabIndex = 2;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonErase
            // 
            this.buttonErase.BackColor = System.Drawing.SystemColors.Control;
            this.buttonErase.Enabled = false;
            this.buttonErase.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonErase.Location = new System.Drawing.Point(280, 130);
            this.buttonErase.Name = "buttonErase";
            this.buttonErase.Size = new System.Drawing.Size(75, 23);
            this.buttonErase.TabIndex = 3;
            this.buttonErase.Text = "Erase";
            this.buttonErase.UseVisualStyleBackColor = false;
            this.buttonErase.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonFlash
            // 
            this.buttonFlash.Enabled = false;
            this.buttonFlash.Location = new System.Drawing.Point(280, 159);
            this.buttonFlash.Name = "buttonFlash";
            this.buttonFlash.Size = new System.Drawing.Size(75, 23);
            this.buttonFlash.TabIndex = 4;
            this.buttonFlash.Text = "Flash";
            this.buttonFlash.UseVisualStyleBackColor = true;
            this.buttonFlash.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonFile
            // 
            this.buttonFile.Location = new System.Drawing.Point(280, 50);
            this.buttonFile.Name = "buttonFile";
            this.buttonFile.Size = new System.Drawing.Size(75, 23);
            this.buttonFile.TabIndex = 5;
            this.buttonFile.Text = "Select File";
            this.buttonFile.UseVisualStyleBackColor = true;
            this.buttonFile.Click += new System.EventHandler(this.button4_Click);
            // 
            // fileInputTextBox
            // 
            this.fileInputTextBox.Location = new System.Drawing.Point(15, 52);
            this.fileInputTextBox.Name = "fileInputTextBox";
            this.fileInputTextBox.Size = new System.Drawing.Size(259, 20);
            this.fileInputTextBox.TabIndex = 6;
            // 
            // debugTextBox
            // 
            this.debugTextBox.Location = new System.Drawing.Point(12, 218);
            this.debugTextBox.Multiline = true;
            this.debugTextBox.Name = "debugTextBox";
            this.debugTextBox.Size = new System.Drawing.Size(343, 156);
            this.debugTextBox.TabIndex = 7;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // serialPortcComboBox
            // 
            this.serialPortcComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.serialPortcComboBox.FormattingEnabled = true;
            this.serialPortcComboBox.Location = new System.Drawing.Point(174, 11);
            this.serialPortcComboBox.Name = "serialPortcComboBox";
            this.serialPortcComboBox.Size = new System.Drawing.Size(100, 21);
            this.serialPortcComboBox.TabIndex = 8;
            // 
            // buttonInfo
            // 
            this.buttonInfo.Location = new System.Drawing.Point(280, 101);
            this.buttonInfo.Name = "buttonInfo";
            this.buttonInfo.Size = new System.Drawing.Size(75, 23);
            this.buttonInfo.TabIndex = 9;
            this.buttonInfo.Text = "Info";
            this.buttonInfo.UseVisualStyleBackColor = true;
            this.buttonInfo.Click += new System.EventHandler(this.buttonInfo_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 188);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(343, 20);
            this.progressBar.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 23);
            this.label2.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 386);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.buttonInfo);
            this.Controls.Add(this.serialPortcComboBox);
            this.Controls.Add(this.debugTextBox);
            this.Controls.Add(this.fileInputTextBox);
            this.Controls.Add(this.buttonFile);
            this.Controls.Add(this.buttonFlash);
            this.Controls.Add(this.buttonErase);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "RTD2660 Arduino Flasher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonErase;
        private System.Windows.Forms.Button buttonFlash;
        private System.Windows.Forms.Button buttonFile;
        private System.Windows.Forms.TextBox fileInputTextBox;
        private System.Windows.Forms.TextBox debugTextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox serialPortcComboBox;
        private System.Windows.Forms.Button buttonInfo;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label2;
    }
}

