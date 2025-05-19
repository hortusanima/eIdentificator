using eIdentificator.Application.Models;
using eIdentificator.Application.Services;
using eIdentificator.Domain;
using eIdentificator.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace eIdentificator
{
    public partial class FormIdentification : Form
    {
        private readonly IDatabaseHelper _databaseHelper;
        private readonly IFileHelper _fileHelper;
        private readonly IFormHelper _formHelper;
        private readonly IDateHelper _dateHelper;
        private readonly IListHelper _listHelper;
        private readonly StudentsService _studentsService;

        public readonly string _connectionString;

        public List<Student> students = new List<Student>();
        public List<StudentDto> identifiedStudents = new List<StudentDto>();

        public List<string> years = new List<string>();
        public List<string> levels = new List<string>();
        public List<string> departments = new List<string>();

        public bool _isSettingDefaultComboBox;
        public bool _isSettingDefaultDataGridView;
        public FormIdentification(
            IDatabaseHelper databaseHelper, 
            IFileHelper fileHelper,
            IFormHelper formHelper,
            IDateHelper dateHelper,
            IListHelper listHelper,
            StudentsService studentsService
        )
        {
            InitializeComponent();

            _databaseHelper = databaseHelper;
            _connectionString = _databaseHelper.GetConnectionString();

            _fileHelper = fileHelper;
            _formHelper = formHelper;
            _dateHelper = dateHelper;
            _listHelper = listHelper;

            _studentsService = studentsService;

            _isSettingDefaultComboBox = true;
            _isSettingDefaultDataGridView = true;
        }

        private void FormIdentification_Load(object sender, EventArgs e)
        {
            _studentsService.SetStudentsToUnidentified(false);

            string currentDateString = _dateHelper.ParseDateToString(DateTime.Now);
            labelIdentificationDate.Text = currentDateString;
            labelReportDate.Text = currentDateString;

            _studentsService.SetIdentifiedCountForLabel(
                labelCount, 
                true, 
                "Count of identified students", 
                null
            );
            _studentsService.SetIdentifiedCountForLabel(
                labelCountAll, 
                true, 
                "All identified students", 
                null
            );
            _studentsService.SetIdentifiedCountForLabel(
                labelCountBachelor, 
                true, 
                "Identified Bachelor students", 
                "Bachelor"
            );
            _studentsService.SetIdentifiedCountForLabel(
                labelCountMaster, 
                true, 
                "Identified Master students", 
                "Master"
            );
            _studentsService.SetIdentifiedCountForLabel(
                labelCountDoctoral, 
                true, 
                "Identified PhD students", 
                "Doctoral"
            );

            _studentsService.PopulateListWithstudentDistinctFieldValues(
                years, 
                "Year", 
                "All", 
                null
            );
            _formHelper.PopulateComboBoxByList(
                comboBoxYear, 
                years
            );
            comboBoxYear.SelectedIndex = 0;

            _studentsService.PopulateListWithstudentDistinctFieldValues(
                levels, 
                "Level", 
                "All", 
                null
            );
            _formHelper.PopulateComboBoxByList(
                comboBoxLevel, 
                levels
            );
            comboBoxLevel.SelectedIndex = 0;

            _studentsService.PopulateListWithstudentDistinctFieldValues(
                departments, 
                "Department", 
                "All", 
                null
            );
            _formHelper.PopulateComboBoxByList(
                comboBoxDepartment, 
                departments
            );
            comboBoxDepartment.SelectedIndex = 0;

            comboBoxSort.SelectedIndex = 0;

            dataGridViewStudents.DefaultCellStyle.SelectionBackColor = 
                dataGridViewStudents.DefaultCellStyle.BackColor;
            dataGridViewStudents.DefaultCellStyle.SelectionForeColor = 
                dataGridViewStudents.DefaultCellStyle.ForeColor;

            dataGridViewStudents.Visible = false;
            labelMessage.Visible = true;

            _formHelper.CenterControlHorizontal(
                labelCount,
                labelMessage,
                labelManualTitle,
                textBoxManual);

            chartIdentification.Legends[0].Docking = Docking.Top;
            chartIdentification.Legends[0].Font = new Font("Segoe UI", 9, FontStyle.Regular);
            chartIdentification.ChartAreas[0].BackColor = Color.Transparent;
            chartIdentification.Legends[0].BackColor = Color.Transparent;
            _studentsService.SetIdentifiedPercentagesForChart(chartIdentification);

            _studentsService.PopulateListWithIdentifiedStudents(identifiedStudents);
            _listHelper.SortListByClassField(
                ref identifiedStudents, 
                comboBoxSort.SelectedItem.ToString(), 
                radioButtonDescending.Checked
            );
            _formHelper.PopulateTextBoxByList(
                textBoxReport, 
                identifiedStudents
            );

            _formHelper.SetControlAbility(
                identifiedStudents.Count > 0, 
                buttonGenerateReport, 
                labelSort, comboBoxSort, 
                radioButtonAscending, 
                radioButtonDescending, 
                buttonResetReport
            );

            _isSettingDefaultComboBox = false;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string key = textBoxSearch.Text;
            string year = comboBoxYear.SelectedItem.ToString();
            string level = comboBoxLevel.SelectedItem.ToString();
            string department = comboBoxDepartment.SelectedItem.ToString();

            _studentsService.PopulateListWithStudents(
                students, 
                key, 
                year, 
                level, 
                department
            );

            _isSettingDefaultDataGridView = true;
            _studentsService.PopulateDataGridViewWithStudents(
                dataGridViewStudents, 
                labelMessage, 
                key, 
                year, 
                level, 
                department
            );
            _isSettingDefaultDataGridView = false;
        }

        private void dataGridViewStudents_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewStudents.Columns[e.ColumnIndex] is 
                DataGridViewCheckBoxColumn && 
                e.RowIndex >= 0 &&
                !_isSettingDefaultDataGridView)
            {
                string index = dataGridViewStudents
                    .Rows[e.RowIndex]
                    .Cells["columnIndex"]
                    .Value.ToString();
                bool isChecked = bool.Parse(dataGridViewStudents
                    .Rows[e.RowIndex]
                    .Cells[e.ColumnIndex]
                    .Value.ToString());

                _studentsService.SetStudentIdentifiedField(index, isChecked);

                _studentsService.SetIdentifiedCountForLabel(
                    labelCount, 
                    true, 
                    "Count of identified students", 
                    null
                );
                _studentsService.SetIdentifiedCountForLabel(
                    labelCountAll, 
                    true, 
                    "All identified students", 
                    null
                );
                _studentsService.SetIdentifiedCountForLabel(
                    labelCountBachelor, 
                    true, 
                    "Identified Bachelor students", 
                    "Bachelor"
                );
                _studentsService.SetIdentifiedCountForLabel(
                    labelCountMaster, 
                    true, 
                    "Identified Master students", 
                    "Master"
                );
                _studentsService.SetIdentifiedCountForLabel(
                    labelCountDoctoral, 
                    true, 
                    "Identified PhD students", 
                    "Doctoral"
                );
                
                _formHelper.CenterControlHorizontal(labelCount);

                _studentsService.SetIdentifiedPercentagesForChart(chartIdentification);

                string key = textBoxSearch.Text;
                string year = comboBoxYear.SelectedItem.ToString();
                string level = comboBoxLevel.SelectedItem.ToString();
                string department = comboBoxDepartment.SelectedItem.ToString();

                _studentsService.PopulateListWithStudents(
                    students, 
                    key, 
                    year, 
                    level, 
                    department
                );

                _isSettingDefaultDataGridView = true;
                _studentsService.PopulateDataGridViewWithStudents(
                    dataGridViewStudents, 
                    labelMessage, 
                    key, 
                    year, 
                    level, 
                    department
                );
                _isSettingDefaultDataGridView = false;

                _studentsService.PopulateListWithIdentifiedStudents(identifiedStudents);
                _listHelper.SortListByClassField(
                    ref identifiedStudents, 
                    comboBoxSort.SelectedItem.ToString(), 
                    radioButtonDescending.Checked
                );
                _formHelper.PopulateTextBoxByList(
                    textBoxReport, 
                    identifiedStudents
                );

                _formHelper.SetControlAbility(
                    identifiedStudents.Count > 0, 
                    buttonGenerateReport, 
                    labelSort, 
                    comboBoxSort, 
                    radioButtonAscending, 
                    radioButtonDescending, 
                    buttonResetReport
                );
            }
        }

        private void dataGridViewStudents_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewStudents.CurrentCell 
                is DataGridViewCheckBoxCell)
            {
                dataGridViewStudents
                    .CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void buttonGenerateReport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
                saveFileDialog.Title = "Generating Report";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    _fileHelper.WriteCSVFile(identifiedStudents, filePath);

                    MessageBox.Show(
                        "Report successfuly generated.", 
                        "Information", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Information
                    );
                }
            }
        }

        private void buttonResetReport_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                    "Are you sure you want to reset the Report? This action will remove evidention of identified students.", 
                    "Warning", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Warning) ==
                DialogResult.Yes)
            {
                _studentsService.SetStudentsToUnidentified(true);

                _studentsService.SetIdentifiedCountForLabel(
                    labelCount,
                    true,
                    "Count of identified students",
                    null
                );
                _studentsService.SetIdentifiedCountForLabel(
                    labelCountAll,
                    true,
                    "All identified students",
                    null
                );
                _studentsService.SetIdentifiedCountForLabel(
                    labelCountBachelor,
                    true,
                    "Identified Bachelor students",
                    "Bachelor"
                );
                _studentsService.SetIdentifiedCountForLabel(
                    labelCountMaster,
                    true,
                    "Identified Master students",
                    "Master"
                );
                _studentsService.SetIdentifiedCountForLabel(
                    labelCountDoctoral,
                    true,
                    "Identified PhD students",
                    "Doctoral"
                );

                _formHelper.CenterControlHorizontal(labelCount);

                _studentsService.SetIdentifiedPercentagesForChart(chartIdentification);

                string key = textBoxSearch.Text;
                string year = comboBoxYear.SelectedItem.ToString();
                string level = comboBoxLevel.SelectedItem.ToString();
                string department = comboBoxDepartment.SelectedItem.ToString();

                _studentsService.PopulateListWithStudents(
                    students, 
                    key, 
                    year, 
                    level, 
                    department
                );

                _isSettingDefaultDataGridView = true;
                _studentsService.PopulateDataGridViewWithStudents(
                    dataGridViewStudents, 
                    labelMessage, 
                    key, 
                    year, 
                    level, 
                    department
                );
                _isSettingDefaultDataGridView = false;

                _studentsService.PopulateListWithIdentifiedStudents(identifiedStudents);
                _formHelper.PopulateTextBoxByList(
                    textBoxReport, 
                    identifiedStudents
                );

                MessageBox.Show(
                    "Report successfuly reset.", 
                    "Information", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information
                );

                _formHelper.SetControlAbility(
                    identifiedStudents.Count > 0, 
                    buttonGenerateReport, 
                    labelSort, 
                    comboBoxSort, 
                    radioButtonAscending, 
                    radioButtonDescending, 
                    buttonResetReport
                );
            }
        }

        private void comboBoxSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!_isSettingDefaultComboBox)
            {
                _listHelper.SortListByClassField(
                    ref identifiedStudents, 
                    comboBoxSort.SelectedItem.ToString(), 
                    radioButtonDescending.Checked);
                _formHelper.PopulateTextBoxByList(
                    textBoxReport, 
                    identifiedStudents
                );
            }
        }

        private void radioButtonAscending_CheckedChanged(object sender, EventArgs e)
        {
            _listHelper.SortListByClassField(
                ref identifiedStudents, 
                comboBoxSort.SelectedItem.ToString(), 
                radioButtonDescending.Checked
            );
            _formHelper.PopulateTextBoxByList(
                textBoxReport, 
                identifiedStudents
            );
        }

        private void radioButtonDescending_CheckedChanged(object sender, EventArgs e)
        {
            _listHelper.SortListByClassField(
                ref identifiedStudents, 
                comboBoxSort.SelectedItem.ToString(), 
                radioButtonDescending.Checked
            );
            _formHelper.PopulateTextBoxByList(
                textBoxReport, 
                identifiedStudents
            );
        }

        private void comboBoxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isSettingDefaultComboBox)
            {
                _isSettingDefaultComboBox = true;

                string year = comboBoxYear.SelectedItem.ToString();
                string level = comboBoxLevel.SelectedItem.ToString();
                string department = comboBoxDepartment.SelectedItem.ToString();

                _studentsService.PopulateListWithstudentDistinctFieldValues(
                    levels, 
                    "Level", 
                    year, 
                    "Year"
                );

                _formHelper.PopulateComboBoxByList(comboBoxLevel, levels);

                if (levels.Contains(level))
                {
                    comboBoxLevel.SelectedIndex = comboBoxLevel
                        .FindStringExact(level);
                }
                else
                {
                    comboBoxLevel.SelectedIndex = 0;
                }

                _studentsService.PopulateListWithstudentDistinctFieldValues(
                    departments, 
                    "Department", 
                    year, 
                    "Year"
                );
                _formHelper.PopulateComboBoxByList(comboBoxDepartment, departments);

                if (departments.Contains(department))
                {
                    comboBoxDepartment.SelectedIndex = comboBoxDepartment
                        .FindStringExact(department);
                }
                else
                {
                    comboBoxDepartment.SelectedIndex = 0;
                }

                _isSettingDefaultComboBox = false;
            }
        }

        private void comboBoxLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isSettingDefaultComboBox)
            {
                _isSettingDefaultComboBox = true;

                string year = comboBoxYear.SelectedItem.ToString();
                string level = comboBoxLevel.SelectedItem.ToString();
                string department = comboBoxDepartment.SelectedItem.ToString();

                _studentsService.PopulateListWithstudentDistinctFieldValues(
                    years, 
                    "Year", 
                    level, 
                    "Level"
                );
                _formHelper.PopulateComboBoxByList(
                    comboBoxYear, 
                    years
                );

                if (years.Contains(year))
                {
                    comboBoxYear.SelectedIndex = comboBoxYear
                        .FindStringExact(year);
                }
                else
                {
                    comboBoxYear.SelectedIndex = 0;
                }

                _studentsService.PopulateListWithstudentDistinctFieldValues(
                    departments, 
                    "Department", 
                    level, 
                    "Level"
                );
                _formHelper.PopulateComboBoxByList(
                    comboBoxDepartment, 
                    departments
                );

                if (departments.Contains(department))
                {
                    comboBoxDepartment.SelectedIndex = comboBoxDepartment
                        .FindStringExact(department);
                }
                else
                {
                    comboBoxDepartment.SelectedIndex = 0;
                }

                _isSettingDefaultComboBox = false;
            }
        }

        private void comboBoxDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!_isSettingDefaultComboBox)
            {
                _isSettingDefaultComboBox = true;

                string year = comboBoxYear.SelectedItem.ToString();
                string level = comboBoxLevel.SelectedItem.ToString();
                string department = comboBoxDepartment.SelectedItem.ToString();

                _studentsService.PopulateListWithstudentDistinctFieldValues(
                    years, 
                    "Year", 
                    department, 
                    "Department"
                );
                _formHelper.PopulateComboBoxByList(
                    comboBoxYear, 
                    years
                );

                if (years.Contains(year))
                {
                    comboBoxYear.SelectedIndex = comboBoxYear
                        .FindStringExact(year);
                }
                else
                {
                    comboBoxYear.SelectedIndex = 0;
                }

                _studentsService.PopulateListWithstudentDistinctFieldValues(
                    levels, 
                    "Level", 
                    department, 
                    "Department"
                );
                _formHelper.PopulateComboBoxByList(
                    comboBoxLevel, 
                    levels
                );

                if (levels.Contains(level))
                {
                    comboBoxLevel.SelectedIndex = comboBoxLevel
                        .FindStringExact(level);
                }
                else
                {
                    comboBoxLevel.SelectedIndex = 0;
                }

                _isSettingDefaultComboBox = false;
            }
        }
    }
}
