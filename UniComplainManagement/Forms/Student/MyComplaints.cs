
using System;
using System.Drawing;
using System.Windows.Forms;

namespace UniComplainManagement.Forms.Student
{
    public partial class MyComplaints : Form
    {
        private Color navy = Color.FromArgb(23, 59, 99);
        private Color teal = Color.FromArgb(13, 148, 136);
        private Color light = Color.FromArgb(244, 248, 252);
        private Color gray = Color.FromArgb(100, 116, 139);

        private DataGridView dgvComplaints;

        public MyComplaints()
        {
            InitializeComponent();
            BuildForm();
        }

        private void BuildForm()
        {
            this.Text = "My Complaints";
            this.Size = new Size(1100, 700);
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
            heading.Text = "My Complaints";
            heading.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            heading.ForeColor = navy;
            heading.Location = new Point(30, 20);
            heading.AutoSize = true;
            header.Controls.Add(heading);

            Label subtitle = new Label();
            subtitle.Text = "View and track all your submitted complaints.";
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

            // Filter label
            Label lblFilter = new Label();
            lblFilter.Text = "Filter by Status:";
            lblFilter.Location = new Point(25, 25);
            lblFilter.AutoSize = true;
            lblFilter.ForeColor = navy;
            main.Controls.Add(lblFilter);

            ComboBox cmbStatus = new ComboBox();
            cmbStatus.Items.AddRange(new object[]
            {
                "All",
                "Pending",
                "In Progress",
                "Resolved",
                "Rejected"
            });
            cmbStatus.SelectedIndex = 0;
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Location = new Point(145, 20);
            cmbStatus.Size = new Size(180, 30);
            main.Controls.Add(cmbStatus);

            // Complaints table
            dgvComplaints = new DataGridView();
            dgvComplaints.Location = new Point(25, 75);
            dgvComplaints.Size = new Size(1000, 440);
            dgvComplaints.Anchor =
                AnchorStyles.Top | AnchorStyles.Bottom |
                AnchorStyles.Left | AnchorStyles.Right;

            dgvComplaints.BackgroundColor = Color.White;
            dgvComplaints.BorderStyle = BorderStyle.None;
            dgvComplaints.AllowUserToAddRows = false;
            dgvComplaints.AllowUserToDeleteRows = false;
            dgvComplaints.ReadOnly = true;
            dgvComplaints.RowHeadersVisible = false;
            dgvComplaints.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvComplaints.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvComplaints.EnableHeadersVisualStyles = false;
            dgvComplaints.ColumnHeadersDefaultCellStyle.BackColor = navy;
            dgvComplaints.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvComplaints.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dgvComplaints.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(220, 240, 245);
            dgvComplaints.DefaultCellStyle.SelectionForeColor = navy;
            dgvComplaints.RowTemplate.Height = 40;

            dgvComplaints.Columns.Add("ID", "Complaint ID");
            dgvComplaints.Columns.Add("Title", "Title");
            dgvComplaints.Columns.Add("Category", "Category");
            dgvComplaints.Columns.Add("Date", "Submitted Date");
            dgvComplaints.Columns.Add("Priority", "Priority");
            dgvComplaints.Columns.Add("Status", "Status");

            dgvComplaints.Rows.Add(
                "CMP-001", "Internet Not Working",
                "IT & Networking", "20-Nov-2026", "High", "In Progress");

            dgvComplaints.Rows.Add(
                "CMP-002", "Fee Challan Issue",
                "Finance & Fee Issues", "19-Nov-2026", "Medium", "Pending");

            dgvComplaints.Rows.Add(
                "CMP-003", "Classroom Projector",
                "Administration", "18-Nov-2026", "Low", "Resolved");

            dgvComplaints.Rows.Add(
                "CMP-004", "Transport Delay",
                "Transport", "17-Nov-2026", "Urgent", "Rejected");

            main.Controls.Add(dgvComplaints);

            // Status filter
            cmbStatus.SelectedIndexChanged += (s, e) =>
            {
                string selectedStatus = cmbStatus.SelectedItem.ToString();

                foreach (DataGridViewRow row in dgvComplaints.Rows)
                {
                    if (selectedStatus == "All")
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible =
                            row.Cells["Status"].Value.ToString() == selectedStatus;
                    }
                }
            };

            // View details button
            Button btnDetails = new Button();
            btnDetails.Text = "View Details";
            btnDetails.Size = new Size(140, 40);
            btnDetails.Location = new Point(25, 535);
            btnDetails.BackColor = navy;
            btnDetails.ForeColor = Color.White;
            btnDetails.FlatStyle = FlatStyle.Flat;
            btnDetails.FlatAppearance.BorderSize = 0;
            btnDetails.Cursor = Cursors.Hand;
            btnDetails.Click += BtnDetails_Click;
            main.Controls.Add(btnDetails);

            // Back button
            Button btnBack = new Button();
            btnBack.Text = "Back to Dashboard";
            btnBack.Size = new Size(170, 40);
            btnBack.Location = new Point(180, 535);
            btnBack.BackColor = teal;
            btnBack.ForeColor = Color.White;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Cursor = Cursors.Hand;
            btnBack.Click += (s, e) => this.Close();
            main.Controls.Add(btnBack);
        }

        private void BtnDetails_Click(object sender, EventArgs e)
        {
            if (dgvComplaints.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a complaint first.");
                return;
            }

            string complaintId =
                dgvComplaints.SelectedRows[0].Cells["ID"].Value.ToString();

            MessageBox.Show(
                "Selected Complaint: " + complaintId +
                "\nComplaint details will be connected later.",
                "Complaint Details",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
