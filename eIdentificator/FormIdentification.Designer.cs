namespace eIdentificator
{
    partial class FormIdentification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormIdentification));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabIdentification = new System.Windows.Forms.TabPage();
            this.labelCount = new System.Windows.Forms.Label();
            this.labelMessage = new System.Windows.Forms.Label();
            this.labelDepartment = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.labelYear = new System.Windows.Forms.Label();
            this.labelIdentificationDate = new System.Windows.Forms.Label();
            this.labelIdentificationTitle = new System.Windows.Forms.Label();
            this.comboBoxDepartment = new System.Windows.Forms.ComboBox();
            this.comboBoxLevel = new System.Windows.Forms.ComboBox();
            this.comboBoxYear = new System.Windows.Forms.ComboBox();
            this.dataGridViewStudents = new System.Windows.Forms.DataGridView();
            this.columnIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnSurname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnIdentified = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.columnTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.labelSearch = new System.Windows.Forms.Label();
            this.tabReport = new System.Windows.Forms.TabPage();
            this.radioButtonDescending = new System.Windows.Forms.RadioButton();
            this.radioButtonAscending = new System.Windows.Forms.RadioButton();
            this.comboBoxSort = new System.Windows.Forms.ComboBox();
            this.labelSort = new System.Windows.Forms.Label();
            this.buttonResetReport = new System.Windows.Forms.Button();
            this.textBoxReport = new System.Windows.Forms.TextBox();
            this.buttonGenerateReport = new System.Windows.Forms.Button();
            this.labelReport = new System.Windows.Forms.Label();
            this.groupBoxbStatistics = new System.Windows.Forms.GroupBox();
            this.labelCountAll = new System.Windows.Forms.Label();
            this.labelCountDoctoral = new System.Windows.Forms.Label();
            this.labelCountMaster = new System.Windows.Forms.Label();
            this.labelCountBachelor = new System.Windows.Forms.Label();
            this.chartIdentification = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelReportDate = new System.Windows.Forms.Label();
            this.labelReportTitle = new System.Windows.Forms.Label();
            this.tabManual = new System.Windows.Forms.TabPage();
            this.textBoxManual = new System.Windows.Forms.TextBox();
            this.labelManualTitle = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabIdentification.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).BeginInit();
            this.tabReport.SuspendLayout();
            this.groupBoxbStatistics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartIdentification)).BeginInit();
            this.tabManual.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabIdentification);
            this.tabControl.Controls.Add(this.tabReport);
            this.tabControl.Controls.Add(this.tabManual);
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            // 
            // tabIdentification
            // 
            this.tabIdentification.Controls.Add(this.labelCount);
            this.tabIdentification.Controls.Add(this.labelMessage);
            this.tabIdentification.Controls.Add(this.labelDepartment);
            this.tabIdentification.Controls.Add(this.label);
            this.tabIdentification.Controls.Add(this.labelYear);
            this.tabIdentification.Controls.Add(this.labelIdentificationDate);
            this.tabIdentification.Controls.Add(this.labelIdentificationTitle);
            this.tabIdentification.Controls.Add(this.comboBoxDepartment);
            this.tabIdentification.Controls.Add(this.comboBoxLevel);
            this.tabIdentification.Controls.Add(this.comboBoxYear);
            this.tabIdentification.Controls.Add(this.dataGridViewStudents);
            this.tabIdentification.Controls.Add(this.buttonSearch);
            this.tabIdentification.Controls.Add(this.textBoxSearch);
            this.tabIdentification.Controls.Add(this.labelSearch);
            resources.ApplyResources(this.tabIdentification, "tabIdentification");
            this.tabIdentification.Name = "tabIdentification";
            this.tabIdentification.UseVisualStyleBackColor = true;
            // 
            // labelCount
            // 
            resources.ApplyResources(this.labelCount, "labelCount");
            this.labelCount.Name = "labelCount";
            // 
            // labelMessage
            // 
            resources.ApplyResources(this.labelMessage, "labelMessage");
            this.labelMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelMessage.Name = "labelMessage";
            // 
            // labelDepartment
            // 
            resources.ApplyResources(this.labelDepartment, "labelDepartment");
            this.labelDepartment.Name = "labelDepartment";
            // 
            // label
            // 
            resources.ApplyResources(this.label, "label");
            this.label.Name = "label";
            // 
            // labelYear
            // 
            resources.ApplyResources(this.labelYear, "labelYear");
            this.labelYear.Name = "labelYear";
            // 
            // labelIdentificationDate
            // 
            resources.ApplyResources(this.labelIdentificationDate, "labelIdentificationDate");
            this.labelIdentificationDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelIdentificationDate.Name = "labelIdentificationDate";
            // 
            // labelIdentificationTitle
            // 
            resources.ApplyResources(this.labelIdentificationTitle, "labelIdentificationTitle");
            this.labelIdentificationTitle.Name = "labelIdentificationTitle";
            // 
            // comboBoxDepartment
            // 
            this.comboBoxDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDepartment.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxDepartment, "comboBoxDepartment");
            this.comboBoxDepartment.Name = "comboBoxDepartment";
            this.comboBoxDepartment.SelectedIndexChanged += new System.EventHandler(this.comboBoxDepartment_SelectedIndexChanged);
            // 
            // comboBoxLevel
            // 
            this.comboBoxLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLevel.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxLevel, "comboBoxLevel");
            this.comboBoxLevel.Name = "comboBoxLevel";
            this.comboBoxLevel.SelectedIndexChanged += new System.EventHandler(this.comboBoxLevel_SelectedIndexChanged);
            // 
            // comboBoxYear
            // 
            this.comboBoxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxYear.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxYear, "comboBoxYear");
            this.comboBoxYear.Name = "comboBoxYear";
            this.comboBoxYear.SelectedIndexChanged += new System.EventHandler(this.comboBoxYear_SelectedIndexChanged);
            // 
            // dataGridViewStudents
            // 
            this.dataGridViewStudents.AllowUserToAddRows = false;
            this.dataGridViewStudents.AllowUserToDeleteRows = false;
            this.dataGridViewStudents.AllowUserToResizeColumns = false;
            this.dataGridViewStudents.AllowUserToResizeRows = false;
            this.dataGridViewStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStudents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnIndex,
            this.columnName,
            this.columnSurname,
            this.columnIdentified,
            this.columnTime});
            resources.ApplyResources(this.dataGridViewStudents, "dataGridViewStudents");
            this.dataGridViewStudents.Name = "dataGridViewStudents";
            this.dataGridViewStudents.RowHeadersVisible = false;
            this.dataGridViewStudents.RowTemplate.Height = 24;
            this.dataGridViewStudents.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStudents_CellValueChanged);
            this.dataGridViewStudents.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridViewStudents_CurrentCellDirtyStateChanged);
            // 
            // columnIndex
            // 
            resources.ApplyResources(this.columnIndex, "columnIndex");
            this.columnIndex.Name = "columnIndex";
            this.columnIndex.ReadOnly = true;
            // 
            // columnName
            // 
            resources.ApplyResources(this.columnName, "columnName");
            this.columnName.Name = "columnName";
            this.columnName.ReadOnly = true;
            // 
            // columnSurname
            // 
            resources.ApplyResources(this.columnSurname, "columnSurname");
            this.columnSurname.Name = "columnSurname";
            this.columnSurname.ReadOnly = true;
            // 
            // columnIdentified
            // 
            resources.ApplyResources(this.columnIdentified, "columnIdentified");
            this.columnIdentified.Name = "columnIdentified";
            // 
            // columnTime
            // 
            resources.ApplyResources(this.columnTime, "columnTime");
            this.columnTime.Name = "columnTime";
            this.columnTime.ReadOnly = true;
            // 
            // buttonSearch
            // 
            resources.ApplyResources(this.buttonSearch, "buttonSearch");
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxSearch
            // 
            resources.ApplyResources(this.textBoxSearch, "textBoxSearch");
            this.textBoxSearch.Name = "textBoxSearch";
            // 
            // labelSearch
            // 
            resources.ApplyResources(this.labelSearch, "labelSearch");
            this.labelSearch.Name = "labelSearch";
            // 
            // tabReport
            // 
            this.tabReport.Controls.Add(this.radioButtonDescending);
            this.tabReport.Controls.Add(this.radioButtonAscending);
            this.tabReport.Controls.Add(this.comboBoxSort);
            this.tabReport.Controls.Add(this.labelSort);
            this.tabReport.Controls.Add(this.buttonResetReport);
            this.tabReport.Controls.Add(this.textBoxReport);
            this.tabReport.Controls.Add(this.buttonGenerateReport);
            this.tabReport.Controls.Add(this.labelReport);
            this.tabReport.Controls.Add(this.groupBoxbStatistics);
            this.tabReport.Controls.Add(this.labelReportDate);
            this.tabReport.Controls.Add(this.labelReportTitle);
            resources.ApplyResources(this.tabReport, "tabReport");
            this.tabReport.Name = "tabReport";
            this.tabReport.UseVisualStyleBackColor = true;
            // 
            // radioButtonDescending
            // 
            resources.ApplyResources(this.radioButtonDescending, "radioButtonDescending");
            this.radioButtonDescending.Name = "radioButtonDescending";
            this.radioButtonDescending.TabStop = true;
            this.radioButtonDescending.UseVisualStyleBackColor = true;
            this.radioButtonDescending.CheckedChanged += new System.EventHandler(this.radioButtonDescending_CheckedChanged);
            // 
            // radioButtonAscending
            // 
            resources.ApplyResources(this.radioButtonAscending, "radioButtonAscending");
            this.radioButtonAscending.Name = "radioButtonAscending";
            this.radioButtonAscending.TabStop = true;
            this.radioButtonAscending.UseVisualStyleBackColor = true;
            this.radioButtonAscending.CheckedChanged += new System.EventHandler(this.radioButtonAscending_CheckedChanged);
            // 
            // comboBoxSort
            // 
            this.comboBoxSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.comboBoxSort, "comboBoxSort");
            this.comboBoxSort.FormattingEnabled = true;
            this.comboBoxSort.Items.AddRange(new object[] {
            resources.GetString("comboBoxSort.Items"),
            resources.GetString("comboBoxSort.Items1")});
            this.comboBoxSort.Name = "comboBoxSort";
            this.comboBoxSort.SelectedIndexChanged += new System.EventHandler(this.comboBoxSort_SelectedIndexChanged);
            // 
            // labelSort
            // 
            resources.ApplyResources(this.labelSort, "labelSort");
            this.labelSort.Name = "labelSort";
            // 
            // buttonResetReport
            // 
            resources.ApplyResources(this.buttonResetReport, "buttonResetReport");
            this.buttonResetReport.Name = "buttonResetReport";
            this.buttonResetReport.UseVisualStyleBackColor = true;
            this.buttonResetReport.Click += new System.EventHandler(this.buttonResetReport_Click);
            // 
            // textBoxReport
            // 
            resources.ApplyResources(this.textBoxReport, "textBoxReport");
            this.textBoxReport.Name = "textBoxReport";
            this.textBoxReport.ReadOnly = true;
            // 
            // buttonGenerateReport
            // 
            resources.ApplyResources(this.buttonGenerateReport, "buttonGenerateReport");
            this.buttonGenerateReport.Name = "buttonGenerateReport";
            this.buttonGenerateReport.UseVisualStyleBackColor = true;
            this.buttonGenerateReport.Click += new System.EventHandler(this.buttonGenerateReport_Click);
            // 
            // labelReport
            // 
            resources.ApplyResources(this.labelReport, "labelReport");
            this.labelReport.Name = "labelReport";
            // 
            // groupBoxbStatistics
            // 
            this.groupBoxbStatistics.Controls.Add(this.labelCountAll);
            this.groupBoxbStatistics.Controls.Add(this.labelCountDoctoral);
            this.groupBoxbStatistics.Controls.Add(this.labelCountMaster);
            this.groupBoxbStatistics.Controls.Add(this.labelCountBachelor);
            this.groupBoxbStatistics.Controls.Add(this.chartIdentification);
            resources.ApplyResources(this.groupBoxbStatistics, "groupBoxbStatistics");
            this.groupBoxbStatistics.Name = "groupBoxbStatistics";
            this.groupBoxbStatistics.TabStop = false;
            // 
            // labelCountAll
            // 
            resources.ApplyResources(this.labelCountAll, "labelCountAll");
            this.labelCountAll.Name = "labelCountAll";
            // 
            // labelCountDoctoral
            // 
            resources.ApplyResources(this.labelCountDoctoral, "labelCountDoctoral");
            this.labelCountDoctoral.Name = "labelCountDoctoral";
            // 
            // labelCountMaster
            // 
            resources.ApplyResources(this.labelCountMaster, "labelCountMaster");
            this.labelCountMaster.Name = "labelCountMaster";
            // 
            // labelCountBachelor
            // 
            resources.ApplyResources(this.labelCountBachelor, "labelCountBachelor");
            this.labelCountBachelor.Name = "labelCountBachelor";
            // 
            // chartIdentification
            // 
            this.chartIdentification.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chartIdentification.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartIdentification.Legends.Add(legend1);
            resources.ApplyResources(this.chartIdentification, "chartIdentification");
            this.chartIdentification.Name = "chartIdentification";
            this.chartIdentification.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Legitimacija";
            this.chartIdentification.Series.Add(series1);
            // 
            // labelReportDate
            // 
            resources.ApplyResources(this.labelReportDate, "labelReportDate");
            this.labelReportDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelReportDate.Name = "labelReportDate";
            // 
            // labelReportTitle
            // 
            resources.ApplyResources(this.labelReportTitle, "labelReportTitle");
            this.labelReportTitle.Name = "labelReportTitle";
            // 
            // tabManual
            // 
            this.tabManual.Controls.Add(this.textBoxManual);
            this.tabManual.Controls.Add(this.labelManualTitle);
            resources.ApplyResources(this.tabManual, "tabManual");
            this.tabManual.Name = "tabManual";
            this.tabManual.UseVisualStyleBackColor = true;
            // 
            // textBoxManual
            // 
            resources.ApplyResources(this.textBoxManual, "textBoxManual");
            this.textBoxManual.Name = "textBoxManual";
            this.textBoxManual.ReadOnly = true;
            // 
            // labelManualTitle
            // 
            resources.ApplyResources(this.labelManualTitle, "labelManualTitle");
            this.labelManualTitle.Name = "labelManualTitle";
            // 
            // FormIdentification
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormIdentification";
            this.Load += new System.EventHandler(this.FormIdentification_Load);
            this.tabControl.ResumeLayout(false);
            this.tabIdentification.ResumeLayout(false);
            this.tabIdentification.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).EndInit();
            this.tabReport.ResumeLayout(false);
            this.tabReport.PerformLayout();
            this.groupBoxbStatistics.ResumeLayout(false);
            this.groupBoxbStatistics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartIdentification)).EndInit();
            this.tabManual.ResumeLayout(false);
            this.tabManual.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabIdentification;
        private System.Windows.Forms.TabPage tabManual;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.DataGridView dataGridViewStudents;
        private System.Windows.Forms.ComboBox comboBoxDepartment;
        private System.Windows.Forms.ComboBox comboBoxLevel;
        private System.Windows.Forms.ComboBox comboBoxYear;
        private System.Windows.Forms.Label labelIdentificationDate;
        private System.Windows.Forms.Label labelIdentificationTitle;
        private System.Windows.Forms.Label labelDepartment;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label labelYear;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Label labelManualTitle;
        private System.Windows.Forms.TextBox textBoxManual;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.TabPage tabReport;
        private System.Windows.Forms.Label labelReportDate;
        private System.Windows.Forms.Label labelReportTitle;
        private System.Windows.Forms.GroupBox groupBoxbStatistics;
        private System.Windows.Forms.TextBox textBoxReport;
        private System.Windows.Forms.Label labelReport;
        private System.Windows.Forms.Button buttonResetReport;
        private System.Windows.Forms.Button buttonGenerateReport;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartIdentification;
        private System.Windows.Forms.Label labelCountDoctoral;
        private System.Windows.Forms.Label labelCountMaster;
        private System.Windows.Forms.Label labelCountBachelor;
        private System.Windows.Forms.Label labelCountAll;
        private System.Windows.Forms.RadioButton radioButtonDescending;
        private System.Windows.Forms.RadioButton radioButtonAscending;
        private System.Windows.Forms.ComboBox comboBoxSort;
        private System.Windows.Forms.Label labelSort;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnSurname;
        private System.Windows.Forms.DataGridViewCheckBoxColumn columnIdentified;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnTime;
    }
}

