using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ScheduleApp
{
    public partial class Form1 : Form
    {
        private readonly XmlProcessor _processor;
        private const string XmlFilePath = "Schedule.xml";
        private const string XslFilePath = "Schedule.xsl";
        private const string HtmlFilePath = "Schedule.html";

        public Form1()
        {
            InitializeComponent();
            _processor = new XmlProcessor();
            rbLinq.Checked = true;
            SetupFilters();
        }

        private void SetupFilters()
        {
            chkTeacher.CheckedChanged += (s, e) => txtTeacher.Enabled = chkTeacher.Checked;
            chkGroup.CheckedChanged += (s, e) => txtGroup.Enabled = chkGroup.Checked;
            chkAuditorium.CheckedChanged += (s, e) => txtAuditorium.Enabled = chkAuditorium.Checked;
            chkSubject.CheckedChanged += (s, e) => txtSubject.Enabled = chkSubject.Checked;

            txtTeacher.Enabled = false;
            txtGroup.Enabled = false;
            txtAuditorium.Enabled = false;
            txtSubject.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                AssignStrategy();
                Lesson template = CreateFilterTemplate();
                List<Lesson> results = _processor.Search(template, XmlFilePath);
                DisplayResults(results);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbOutput.Clear();
            txtTeacher.Clear();
            txtGroup.Clear();
            txtAuditorium.Clear();
            txtSubject.Clear();
            chkTeacher.Checked = false;
            chkGroup.Checked = false;
            chkAuditorium.Checked = false;
            chkSubject.Checked = false;
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                _processor.ConvertToHtml(XmlFilePath, XslFilePath, HtmlFilePath);
                MessageBox.Show("Transformation successful! Saved to " + HtmlFilePath);
                System.Diagnostics.Process.Start(HtmlFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Transformation failed: {ex.Message}");
            }
        }

        private void AssignStrategy()
        {
            if (rbSax.Checked) _processor.SetAnalysisStrategy(new SaxAnalysisStrategy());
            else if (rbDom.Checked) _processor.SetAnalysisStrategy(new DomAnalysisStrategy());
            else if (rbLinq.Checked) _processor.SetAnalysisStrategy(new LinqAnalysisStrategy());
        }

        private Lesson CreateFilterTemplate()
        {
            return new Lesson
            {
                Teacher = chkTeacher.Checked ? txtTeacher.Text : null,
                Group = chkGroup.Checked ? txtGroup.Text : null,
                Auditorium = chkAuditorium.Checked ? txtAuditorium.Text : null,
                Subject = chkSubject.Checked ? txtSubject.Text : null,
            };
        }

        private void DisplayResults(List<Lesson> lessons)
        {
            rtbOutput.Clear();
            if (lessons.Count == 0)
            {
                rtbOutput.Text = "No matches found.";
                return;
            }

            foreach (var lesson in lessons)
            {
                rtbOutput.AppendText(lesson.ToString() + Environment.NewLine);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
    }
}