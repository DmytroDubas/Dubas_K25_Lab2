namespace ScheduleApp
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtAuditorium = new System.Windows.Forms.TextBox();
            this.txtGroup = new System.Windows.Forms.TextBox();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.txtTeacher = new System.Windows.Forms.TextBox();
            this.chkAuditorium = new System.Windows.Forms.CheckBox();
            this.chkGroup = new System.Windows.Forms.CheckBox();
            this.chkSubject = new System.Windows.Forms.CheckBox();
            this.chkTeacher = new System.Windows.Forms.CheckBox();
            this.rbDom = new System.Windows.Forms.RadioButton();
            this.rbLinq = new System.Windows.Forms.RadioButton();
            this.rbSax = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtbOutput);
            this.groupBox1.Controls.Add(this.btnConvert);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtAuditorium);
            this.groupBox1.Controls.Add(this.txtGroup);
            this.groupBox1.Controls.Add(this.txtSubject);
            this.groupBox1.Controls.Add(this.txtTeacher);
            this.groupBox1.Controls.Add(this.chkAuditorium);
            this.groupBox1.Controls.Add(this.chkGroup);
            this.groupBox1.Controls.Add(this.chkSubject);
            this.groupBox1.Controls.Add(this.chkTeacher);
            this.groupBox1.Controls.Add(this.rbDom);
            this.groupBox1.Controls.Add(this.rbLinq);
            this.groupBox1.Controls.Add(this.rbSax);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 397);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Метод аналізу";
            // 
            // rtbOutput
            // 
            this.rtbOutput.Location = new System.Drawing.Point(390, 36);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.Size = new System.Drawing.Size(367, 259);
            this.rtbOutput.TabIndex = 15;
            this.rtbOutput.Text = "";
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(261, 198);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(106, 58);
            this.btnConvert.TabIndex = 14;
            this.btnConvert.Text = "HTML";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(261, 117);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(106, 62);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Очистити";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(21, 36);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(346, 60);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "Пошук";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtAuditorium
            // 
            this.txtAuditorium.Location = new System.Drawing.Point(132, 237);
            this.txtAuditorium.Name = "txtAuditorium";
            this.txtAuditorium.Size = new System.Drawing.Size(100, 22);
            this.txtAuditorium.TabIndex = 11;
            // 
            // txtGroup
            // 
            this.txtGroup.Location = new System.Drawing.Point(132, 197);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(100, 22);
            this.txtGroup.TabIndex = 10;
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(132, 157);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(100, 22);
            this.txtSubject.TabIndex = 9;
            // 
            // txtTeacher
            // 
            this.txtTeacher.Location = new System.Drawing.Point(133, 117);
            this.txtTeacher.Name = "txtTeacher";
            this.txtTeacher.Size = new System.Drawing.Size(100, 22);
            this.txtTeacher.TabIndex = 8;
            // 
            // chkAuditorium
            // 
            this.chkAuditorium.AutoSize = true;
            this.chkAuditorium.Location = new System.Drawing.Point(21, 225);
            this.chkAuditorium.Name = "chkAuditorium";
            this.chkAuditorium.Size = new System.Drawing.Size(95, 20);
            this.chkAuditorium.TabIndex = 7;
            this.chkAuditorium.Text = "Аудиторія";
            this.chkAuditorium.UseVisualStyleBackColor = true;
            // 
            // chkGroup
            // 
            this.chkGroup.AutoSize = true;
            this.chkGroup.Location = new System.Drawing.Point(21, 188);
            this.chkGroup.Name = "chkGroup";
            this.chkGroup.Size = new System.Drawing.Size(68, 20);
            this.chkGroup.TabIndex = 6;
            this.chkGroup.Text = "Група";
            this.chkGroup.UseVisualStyleBackColor = true;
            // 
            // chkSubject
            // 
            this.chkSubject.AutoSize = true;
            this.chkSubject.Location = new System.Drawing.Point(21, 151);
            this.chkSubject.Name = "chkSubject";
            this.chkSubject.Size = new System.Drawing.Size(87, 20);
            this.chkSubject.TabIndex = 5;
            this.chkSubject.Text = "Предмет";
            this.chkSubject.UseVisualStyleBackColor = true;
            // 
            // chkTeacher
            // 
            this.chkTeacher.AutoSize = true;
            this.chkTeacher.Location = new System.Drawing.Point(21, 117);
            this.chkTeacher.Name = "chkTeacher";
            this.chkTeacher.Size = new System.Drawing.Size(93, 20);
            this.chkTeacher.TabIndex = 4;
            this.chkTeacher.Text = "Викладач";
            this.chkTeacher.UseVisualStyleBackColor = true;
            // 
            // rbDom
            // 
            this.rbDom.AutoSize = true;
            this.rbDom.Location = new System.Drawing.Point(261, 275);
            this.rbDom.Name = "rbDom";
            this.rbDom.Size = new System.Drawing.Size(83, 20);
            this.rbDom.TabIndex = 1;
            this.rbDom.Text = "DOM API";
            this.rbDom.UseVisualStyleBackColor = true;
            // 
            // rbLinq
            // 
            this.rbLinq.AutoSize = true;
            this.rbLinq.Checked = true;
            this.rbLinq.Location = new System.Drawing.Point(132, 277);
            this.rbLinq.Name = "rbLinq";
            this.rbLinq.Size = new System.Drawing.Size(101, 20);
            this.rbLinq.TabIndex = 2;
            this.rbLinq.TabStop = true;
            this.rbLinq.Text = "LINQ to XML";
            this.rbLinq.UseVisualStyleBackColor = true;
            // 
            // rbSax
            // 
            this.rbSax.AutoSize = true;
            this.rbSax.Location = new System.Drawing.Point(21, 277);
            this.rbSax.Name = "rbSax";
            this.rbSax.Size = new System.Drawing.Size(78, 20);
            this.rbSax.TabIndex = 0;
            this.rbSax.Text = "SAX API";
            this.rbSax.UseVisualStyleBackColor = true;
            this.rbSax.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbSax;
        private System.Windows.Forms.RadioButton rbDom;
        private System.Windows.Forms.RadioButton rbLinq;
        private System.Windows.Forms.CheckBox chkAuditorium;
        private System.Windows.Forms.CheckBox chkGroup;
        private System.Windows.Forms.CheckBox chkSubject;
        private System.Windows.Forms.CheckBox chkTeacher;
        private System.Windows.Forms.TextBox txtTeacher;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtAuditorium;
        private System.Windows.Forms.TextBox txtGroup;
        private System.Windows.Forms.RichTextBox rtbOutput;
    }
}

