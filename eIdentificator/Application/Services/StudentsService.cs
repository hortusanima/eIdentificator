using AutoMapper;
using eIdentificator.Application.Models;
using eIdentificator.Domain;
using eIdentificator.Domain.Interfaces;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace eIdentificator.Application.Services
{
    public class StudentsService
    {
        private readonly IStudentsRepository _studentsRepository;
        private readonly IMapper _mapper;
        public StudentsService(
            IStudentsRepository studentsRepository, 
            IMapper mapper
        )
        {
            _studentsRepository = studentsRepository;
            _mapper = mapper;
        }
        
        public void PopulateListWithStudents(
            List<Student> students, 
            string key, 
            string year, 
            string level, 
            string department
        )
        {
            students.Clear();
            students.AddRange(_studentsRepository
                .GetAllStudentsByFilters(
                    key,
                    year, 
                    level, 
                    department
                )
            );
        }

        public void PopulateListWithstudentDistinctFieldValues(
            List<string> list, 
            string field, 
            string referenceValue, 
            string referenceField
        )
        {
            list.Clear();
            list.Add("All");
            list.AddRange(_studentsRepository
                .GetStudentDistinctFieldValues(
                    field, 
                    referenceField, 
                    referenceValue
                )
            );
        }

        public void SetStudentIdentifiedField(
            string index, 
            bool isIdentified) =>
            _studentsRepository.UpdateStudentIdentifiedField(
                index, 
                isIdentified
            );

        public void SetStudentsToUnidentified(bool isForced) =>
            _studentsRepository.ResetStudentFieldValues(isForced);

        public void SetIdentifiedCountForLabel(
            Label label, 
            bool isIdentified, 
            string text, 
            string level
        )
        {
            int count = _studentsRepository
                .GetCountOfStudentsByIdentifiedValue(
                    isIdentified, 
                    level
                );
            label.Text = $"{text}: {count}";
        }

        public void SetIdentifiedPercentagesForChart(Chart chart)
        {
            int count = _studentsRepository
                .GetCountOfAllStudents();
            int countIdentified = _studentsRepository
                .GetCountOfStudentsByIdentifiedValue(
                true, 
                null
            );
            double percentageIdentified = (100.00 * countIdentified) / count;

            chart.Series.Clear();
            Series series = new Series("IdentifiedSeries");
            series.ChartType = SeriesChartType.Pie;

            series.Points.AddXY("", percentageIdentified);
            series.Points.AddXY("", 100 - percentageIdentified);

            series.Points[0].Color = Color.FromArgb(192, 0, 0);
            series.Points[1].Color = Color.LightGray;

            series.Points[0].LegendText = "Identified";
            series.Points[1].LegendText = "Other";

            foreach (var point in series.Points)
            {
                if (point.YValues[0] == 0)
                {
                    point.Label = "";
                }
                else
                {
                    point.Label = "#PERCENT";
                }
            }

            series["PieLabelStyle"] = "Outside";

            chart.Series.Add(series);
        }

        public void PopulateListWithIdentifiedStudents(List<StudentDto> students)
        {
            students.Clear();
            var identifiedStudents = _studentsRepository
                .GetIdentifiedStudents();
            students.AddRange(
                _mapper.Map<List<StudentDto>>(identifiedStudents)
            );
        }

        public void PopulateDataGridViewWithStudents(
            DataGridView dataGridViewStudents, 
            Label labelMessage, 
            string key, 
            string year, 
            string level, 
            string department
        )
        {
            dataGridViewStudents.Rows.Clear();
            List<Student> studenti = _studentsRepository
                .GetAllStudentsByFilters(
                    key, 
                    year,
                    level, 
                    department)
                .ToList();

            if (studenti.Count > 0)
            {
                dataGridViewStudents.Visible = true;
                labelMessage.Visible = false;
                foreach (Student student in studenti)
                {
                    var idrow = dataGridViewStudents.Rows.Add();
                    var row = dataGridViewStudents.Rows[idrow];
                    row.Cells["columnIndex"].Value = student.StudentId;
                    row.Cells["columnName"].Value = student.Name;
                    row.Cells["columnSurname"].Value = student.Surname;
                    row.Cells["columnIdentified"].Value = student.Identified;
                    string vreme = student.Identification_Date.HasValue
                        ? student.Identification_Date.Value.Hour.ToString("D2") + 
                        ":" +
                        student.Identification_Date.Value.Minute.ToString("D2") + 
                        ":" +
                        student.Identification_Date.Value.Second.ToString("D2")
                        : null;
                    row.Cells["columnTime"].Value = vreme;
                }
            }
            else
            {
                dataGridViewStudents.Visible = false;
                labelMessage.Visible = true;
                labelMessage.Text = "There are no students with provided parameters.";
            }
        }
    }
}
