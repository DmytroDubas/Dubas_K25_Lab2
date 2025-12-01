using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ScheduleApp
{
    public partial class Form1 : Form
    {
        private readonly XmlProcessor _processor;
        private string _xmlFilePath = "Schedule.xml";
        private const string XslFilePath = "Schedule.xsl";
        private const string HtmlFilePath = "Schedule.html";
        private List<Lesson> _lastResults = new List<Lesson>();

        public Form1()
        {
            InitializeComponent();
            _processor = new XmlProcessor();
            rbLinq.Checked = true;
            this.FormClosing += Form1_FormClosing;

            SetupFilters();
            LoadAllData(); // Завантажуємо всі списки при старті
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вийти з програми?", "Вихід", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        // Метод для заповнення ВСІХ випадаючих списків
        private void LoadAllData()
        {
            if (!File.Exists(_xmlFilePath)) return;

            // Очищаємо списки перед заповненням
            cmbTeacher.Items.Clear();
            cmbSubject.Items.Clear();
            cmbGroup.Items.Clear();
            cmbAuditorium.Items.Clear();

            // Заповнюємо даними з XML
            cmbTeacher.Items.AddRange(_processor.GetUniqueValues(_xmlFilePath, "Teacher").ToArray());
            cmbSubject.Items.AddRange(_processor.GetUniqueValues(_xmlFilePath, "Subject").ToArray());
            cmbGroup.Items.AddRange(_processor.GetUniqueValues(_xmlFilePath, "Group").ToArray());
            cmbAuditorium.Items.AddRange(_processor.GetUniqueValues(_xmlFilePath, "Auditorium").ToArray());
        }

        private void SetupFilters()
        {
            // Тепер всюди працюємо з ComboBox (cmb...)
            chkTeacher.CheckedChanged += (s, e) => cmbTeacher.Enabled = chkTeacher.Checked;
            chkGroup.CheckedChanged += (s, e) => cmbGroup.Enabled = chkGroup.Checked;
            chkAuditorium.CheckedChanged += (s, e) => cmbAuditorium.Enabled = chkAuditorium.Checked;
            chkSubject.CheckedChanged += (s, e) => cmbSubject.Enabled = chkSubject.Checked;

            cmbTeacher.Enabled = false;
            cmbGroup.Enabled = false;
            cmbAuditorium.Enabled = false;
            cmbSubject.Enabled = false;
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _xmlFilePath = openFileDialog.FileName;
                    if (lblSelectedFile != null)
                        lblSelectedFile.Text = "Файл: " + Path.GetFileName(_xmlFilePath);

                    // Перезавантажуємо списки з нового файлу
                    LoadAllData();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                AssignStrategy();
                Lesson template = CreateFilterTemplate();
                _lastResults = _processor.Search(template, _xmlFilePath);
                DisplayResults(_lastResults);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                if (_lastResults == null || _lastResults.Count == 0)
                {
                    if (MessageBox.Show("Список порожній. Експортувати все?", "Увага", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        _lastResults = _processor.Search(new Lesson(), _xmlFilePath);
                    }
                    else return;
                }

                _processor.ConvertToHtml(_lastResults, XslFilePath, HtmlFilePath);
                MessageBox.Show("Готово! Файл збережено.");
                System.Diagnostics.Process.Start(HtmlFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbOutput.Clear();
            _lastResults.Clear();

            // Скидаємо вибір у всіх списках
            cmbTeacher.SelectedIndex = -1;
            cmbSubject.SelectedIndex = -1;
            cmbGroup.SelectedIndex = -1;
            cmbAuditorium.SelectedIndex = -1;

            chkTeacher.Checked = false;
            chkGroup.Checked = false;
            chkAuditorium.Checked = false;
            chkSubject.Checked = false;
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
                // Зчитуємо значення з випадаючих списків
                Teacher = chkTeacher.Checked ? cmbTeacher.Text : null,
                Group = chkGroup.Checked ? cmbGroup.Text : null,
                Auditorium = chkAuditorium.Checked ? cmbAuditorium.Text : null,
                Subject = chkSubject.Checked ? cmbSubject.Text : null,
            };
        }

        private void DisplayResults(List<Lesson> lessons)
        {
            rtbOutput.Clear();
            if (lessons.Count == 0)
            {
                rtbOutput.Text = "Нічого не знайдено.";
                return;
            }
            foreach (var lesson in lessons)
            {
                rtbOutput.AppendText(lesson.ToString() + Environment.NewLine);
            }
        }

        // Заглушки
        private void radioButton1_CheckedChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
    }
}