
using System;
using System.Drawing;
using System.Windows.Forms;

namespace UniComplainManagement.Forms.Student
{
    public partial class ComplaintHistory : Form
    {
        private Color navy = Color.FromArgb(23, 59, 99);
        private Color teal = Color.FromArgb(13, 148, 136);
        private Color light = Color.FromArgb(244, 248, 252);
        private Color gray = Color.FromArgb(100, 116, 139);

        private string currentStudentId;

        private ComboBox cmbComplaint;
        private DataGridView dgvHistory;

        public ComplaintHistory(string studentId)
        {
            InitializeComponent();

            currentStudentId = studentId;

            BuildForm();
        }

        private void BuildForm()
        {
            this.Text = "Complaint History";
            this.Size = new Size(1100, 700);
            this.MinimumSize = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = light;
            this.Font = new Font("Segoe UI", 10);

            // Header
            Panel header = new Panel();
            header.Dock = DockStyle.Top;
            header.Height = 110;
            header.BackColor = Color.White;
            this.Controls.Add(header);

            Label heading = new Label();
            heading.Text = "Complaint History";
            heading.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            heading.ForeColor = navy;
            heading.Location = new Point(30, 20);
            heading.AutoSize = true;
            header.Controls.Add(heading);

            Label subtitle = new Label();
            subtitle.Text = "View the complete activity timeline of your complaints.";
            subtitle.ForeColor = gray;
            subtitle.Location = new Point(33, 65);
            subtitle.AutoSize = true;
            header.Controls.Add(subtitle);

            // Main panel
            Panel main = new Panel();
            main.Dock = DockStyle.Fill;
            main.Padding = new Padding(25);
            main.BackColor = light;
            this.Controls.Add(main);
            main.BringToFront();

            // Student ID
            Label lblStudent = new Label();
            lblStudent.Text = "Student ID: " + currentStudentId;
            lblStudent.Location = new Point(25, 20);
            lblStudent.AutoSize = true;
            lblStudent.ForeColor = navy;
            lblStudent.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            main.Controls.Add(lblStudent);

            // Complaint selection
            Label lblComplaint = new Label();
            lblComplaint.Text = "Select Complaint:";
            lblComplaint.Location = new Point(25, 65);
            lblComplaint.AutoSize = true;
            lblComplaint.ForeColor = navy;
            main.Controls.Add(lblComplaint);

            cmbComplaint = new ComboBox();
            cmbComplaint.Location = new Point(155, 60);
            cmbComplaint.Size = new Size(450, 30);
            cmbComplaint.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbComplaint.Items.AddRange(new object[]
            {
                "CMP-001 - Internet Issue",
                "CMP-002 - Fee Correction",
                "CMP-003 - ID Card Issue",
                "CMP-004 - Library Issue"
            });

            cmbComplaint.SelectedIndex = 0;
            cmbComplaint.SelectedIndexChanged += (s, e) =>
            {
                LoadHistory();
            };

            main.Controls.Add(cmbComplaint);

            // History heading
            Label lblHistory = new Label();
            lblHistory.Text = "Activity Timeline";
            lblHistory.Font = new Font("Segoe UI", 15, FontStyle.Bold);
            lblHistory.ForeColor = navy;
            lblHistory.Location = new Point(25, 120);
            lblHistory.AutoSize = true;
            main.Controls.Add(lblHistory);

            // History table
            dgvHistory = new DataGridView();
            dgvHistory.Location = new Point(25, 165);
            dgvHistory.Size = new Size(950, 350);

            dgvHistory.Anchor =
                AnchorStyles.Top | AnchorStyles.Bottom |
                AnchorStyles.Left | AnchorStyles.Right;

            dgvHistory.BackgroundColor = Color.White;
            dgvHistory.BorderStyle = BorderStyle.None;
            dgvHistory.ReadOnly = true;
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.AllowUserToDeleteRows = false;
            dgvHistory.RowHeadersVisible = false;
            dgvHistory.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvHistory.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvHistory.EnableHeadersVisualStyles = false;
            dgvHistory.ColumnHeadersDefaultCellStyle.BackColor = navy;
            dgvHistory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvHistory.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dgvHistory.DefaultCellStyle.Font =
                new Font("Segoe UI", 9.5f);

            dgvHistory.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(220, 240, 245);

            dgvHistory.DefaultCellStyle.SelectionForeColor = navy;
            dgvHistory.RowTemplate.Height = 40;

            dgvHistory.Columns.Add("Date", "Date & Time");
            dgvHistory.Columns.Add("Action", "Activity");
            dgvHistory.Columns.Add("Description", "Description");
            dgvHistory.Columns.Add("UpdatedBy", "Updated By");

            main.Controls.Add(dgvHistory);

            // Back button
            Button btnBack = new Button();
            btnBack.Text = "Back to Dashboard";
            btnBack.Location = new Point(25, 540);
            btnBack.Size = new Size(175, 42);
            btnBack.BackColor = teal;
            btnBack.ForeColor = Color.White;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Cursor = Cursors.Hand;
            btnBack.Click += (s, e) => this.Close();

            main.Controls.Add(btnBack);

            // Load initial history
            LoadHistory();
        }

        private void LoadHistory()
        {
            dgvHistory.Rows.Clear();

            string complaintId =
                cmbComplaint.SelectedItem.ToString().Substring(0, 7);

            if (complaintId == "CMP-001")
            {
                dgvHistory.Rows.Add(
                    "20-Nov-2026 10:30 AM",
                    "Complaint Submitted",
                    "Internet issue complaint was submitted.",
                    "Student");

                dgvHistory.Rows.Add(
                    "21-Nov-2026 09:15 AM",
                    "Complaint Assigned",
                    "Assigned to IT Department.",
                    "Admin");

                dgvHistory.Rows.Add(
                    "22-Nov-2026 11:00 AM",
                    "Status Changed",
                    "Complaint is now In Progress.",
                    "IT Staff");
            }
            else if (complaintId == "CMP-002")
            {
                dgvHistory.Rows.Add(
                    "19-Nov-2026 09:00 AM",
                    "Complaint Submitted",
                    "Fee correction complaint was submitted.",
                    "Student");

                dgvHistory.Rows.Add(
                    "20-Nov-2026 12:00 PM",
                    "Complaint Assigned",
                    "Assigned to Finance Department.",
                    "Admin");
            }
            else if (complaintId == "CMP-003")
            {
                dgvHistory.Rows.Add(
                    "18-Nov-2026 10:00 AM",
                    "Complaint Submitted",
                    "ID card issue complaint was submitted.",
                    "Student");

                dgvHistory.Rows.Add(
                    "19-Nov-2026 02:00 PM",
                    "Status Changed",
                    "Complaint is now In Progress.",
                    "Admin");

                dgvHistory.Rows.Add(
                    "21-Nov-2026 01:30 PM",
                    "Complaint Resolved",
                    "ID card issue has been resolved.",
                    "Admin");
            }
            else if (complaintId == "CMP-004")
            {
                dgvHistory.Rows.Add(
                    "17-Nov-2026 11:00 AM",
                    "Complaint Submitted",
                    "Library issue complaint was submitted.",
                    "Student");

                dgvHistory.Rows.Add(
                    "18-Nov-2026 03:00 PM",
                    "Complaint Assigned",
                    "Assigned to Library Department.",
                    "Admin");
            }
        }
    }
}
