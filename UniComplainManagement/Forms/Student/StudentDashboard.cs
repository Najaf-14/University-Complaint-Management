using System;
using System.Drawing;
using System.Windows.Forms;

namespace UniComplainManagement.Forms.Student
{
    public partial class StudentDashboard : Form
    {
        private string currentStudentId;

        // Theme Colors
        private Color navy = Color.FromArgb(23, 59, 99);
        private Color teal = Color.FromArgb(13, 148, 136);
        private Color background = Color.FromArgb(244, 248, 252);
        private Color gray = Color.FromArgb(100, 116, 139);

        public StudentDashboard() : this("Student")
        {
        }

        public StudentDashboard(string studentId)
        {
            InitializeComponent();

            currentStudentId = studentId;

            BuildDashboard();
        }

        private void BuildDashboard()
        {
            // Form Settings
            this.Text = "University Complaint & HelpDesk";
            this.Size = new Size(1200, 750);
            this.MinimumSize = new Size(1050, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = background;
            this.Font = new Font("Segoe UI", 10);

            // Main Layout
            TableLayoutPanel mainLayout = new TableLayoutPanel();
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.ColumnCount = 2;
            mainLayout.RowCount = 1;

            mainLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 230));

            mainLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100));

            mainLayout.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100));

            this.Controls.Add(mainLayout);

            // Sidebar
            Panel sidebar = new Panel();
            sidebar.Dock = DockStyle.Fill;
            sidebar.BackColor = navy;

            mainLayout.Controls.Add(sidebar, 0, 0);

            // Main Content Area
            Panel mainPanel = new Panel();
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.BackColor = background;

            mainLayout.Controls.Add(mainPanel, 1, 0);

            // Sidebar Title
            Label appTitle = new Label();
            appTitle.Text = "UNIVERSITY\nCOMPLAINT";
            appTitle.Font = new Font("Segoe UI", 17, FontStyle.Bold);
            appTitle.ForeColor = Color.White;
            appTitle.Location = new Point(25, 35);
            appTitle.Size = new Size(195, 65);
            sidebar.Controls.Add(appTitle);

            Label subTitle = new Label();
            subTitle.Text = "HELPDESK";
            subTitle.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            subTitle.ForeColor = teal;
            subTitle.Location = new Point(25, 105);
            subTitle.AutoSize = true;
            sidebar.Controls.Add(subTitle);

            // Menu Heading
            Label menuTitle = new Label();
            menuTitle.Text = "MAIN MENU";
            menuTitle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            menuTitle.ForeColor = Color.LightGray;
            menuTitle.Location = new Point(25, 165);
            menuTitle.AutoSize = true;
            sidebar.Controls.Add(menuTitle);

            // Navigation Buttons
            AddMenuButton(sidebar, "Dashboard", 205, true);
            AddMenuButton(sidebar, "Submit Complaint", 260, false);
            AddMenuButton(sidebar, "My Complaints", 315, false);
            AddMenuButton(sidebar, "Notifications", 370, false);
            AddMenuButton(sidebar, "My Profile", 425, false);

            // Logout Button
            Button logout = new Button();
            logout.Text = "Logout";
            logout.Size = new Size(190, 45);
            logout.Location = new Point(20, 590);
            logout.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

            logout.BackColor = Color.FromArgb(153, 45, 55);
            logout.ForeColor = Color.White;
            logout.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            logout.FlatStyle = FlatStyle.Flat;
            logout.FlatAppearance.BorderSize = 0;
            logout.Cursor = Cursors.Hand;

            logout.MouseEnter += (s, e) =>
            {
                logout.BackColor = Color.FromArgb(180, 55, 65);
            };

            logout.MouseLeave += (s, e) =>
            {
                logout.BackColor = Color.FromArgb(153, 45, 55);
            };

            logout.Click += (s, e) =>
            {
                this.Close();
            };

            sidebar.Controls.Add(logout);

            // Header
            Panel header = new Panel();
            header.Dock = DockStyle.Top;
            header.Height = 75;
            header.BackColor = Color.White;

            Label dashboardTitle = new Label();
            dashboardTitle.Text = "Student Dashboard";
            dashboardTitle.Font = new Font("Segoe UI", 17, FontStyle.Bold);
            dashboardTitle.ForeColor = navy;
            dashboardTitle.Location = new Point(30, 20);
            dashboardTitle.AutoSize = true;
            header.Controls.Add(dashboardTitle);

            Label studentId = new Label();
            studentId.Text = "Student ID: " + currentStudentId;
            studentId.Font = new Font("Segoe UI", 9.5f);
            studentId.ForeColor = gray;
            studentId.AutoSize = true;
            header.Controls.Add(studentId);

            // Position Student ID on the right
            header.Resize += (s, e) =>
            {
                studentId.Location = new Point(
                    header.Width - studentId.Width - 30, 27);
            };

            // Dashboard Content
            Panel content = new Panel();
            content.Dock = DockStyle.Fill;
            content.AutoScroll = true;
            content.BackColor = background;

            // IMPORTANT: Add DockStyle.Fill (content) BEFORE DockStyle.Top (header)
            // so content starts cleanly below the 75px header instead of behind it.
            mainPanel.Controls.Add(content);
            mainPanel.Controls.Add(header);

            // Welcome Heading
            Label welcome = new Label();
            welcome.Text = "Welcome Back!";
            welcome.Font = new Font("Segoe UI", 21, FontStyle.Bold);
            welcome.ForeColor = navy;
            welcome.Location = new Point(30, 25);
            welcome.AutoSize = true;
            content.Controls.Add(welcome);

            Label description = new Label();
            description.Text = "Manage your complaints and track their progress.";
            description.Font = new Font("Segoe UI", 10);
            description.ForeColor = gray;
            description.Location = new Point(33, 68);
            description.AutoSize = true;
            content.Controls.Add(description);

            // Submit Complaint Button
            Button submit = new Button();
            submit.Text = "+ Submit Complaint";
            submit.Size = new Size(190, 42);
            submit.Location = new Point(690, 32);

            submit.BackColor = teal;
            submit.ForeColor = Color.White;
            submit.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            submit.FlatStyle = FlatStyle.Flat;
            submit.FlatAppearance.BorderSize = 0;
            submit.Cursor = Cursors.Hand;

            submit.Click += (s, e) =>
            {
                OpenForm(new SubmitComplaint());
            };

            content.Controls.Add(submit);

            // Statistics Cards
            AddStatCard(content, "Total Complaints", "12",
                Color.FromArgb(35, 110, 180), 30);

            AddStatCard(content, "Pending", "4",
                Color.FromArgb(220, 155, 45), 245);

            AddStatCard(content, "In Progress", "1",
                Color.FromArgb(115, 85, 180), 460);

            AddStatCard(content, "Resolved", "7",
                Color.FromArgb(45, 155, 100), 675);

            // Recent Complaints Heading
            Label recentTitle = new Label();
            recentTitle.Text = "Recent Complaints";
            recentTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            recentTitle.ForeColor = navy;
            recentTitle.Location = new Point(30, 285);
            recentTitle.AutoSize = true;
            content.Controls.Add(recentTitle);

            // Complaints Table
            DataGridView grid = new DataGridView();

            grid.Location = new Point(30, 330);
            grid.Size = new Size(850, 250);

            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;

            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.RowHeadersVisible = false;

            grid.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            grid.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            // Table Header Style
            grid.EnableHeadersVisualStyles = false;

            grid.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(230, 238, 247);

            grid.ColumnHeadersDefaultCellStyle.ForeColor = navy;

            grid.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            // Table Row Style
            grid.DefaultCellStyle.Font =
                new Font("Segoe UI", 9.5f);

            grid.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(222, 245, 241);

            grid.DefaultCellStyle.SelectionForeColor = navy;

            grid.RowTemplate.Height = 38;

            // Columns
            grid.Columns.Add("ID", "Complaint ID");
            grid.Columns.Add("Title", "Complaint Title");
            grid.Columns.Add("Category", "Category");
            grid.Columns.Add("Date", "Date");
            grid.Columns.Add("Status", "Status");

            // Sample Data
            grid.Rows.Add(
                "CMP-001", "Internet Issue",
                "IT & Networking", "20-Nov-2026", "Pending");

            grid.Rows.Add(
                "CMP-002", "Fee Correction",
                "Finance", "19-Nov-2026", "In Progress");

            grid.Rows.Add(
                "CMP-001", "Internet Issue",
                "IT & Networking", "20-Nov-2026", "Pending");

            grid.Rows.Add(
                "CMP-003", "ID Card Issue",
                "Administration", "17-Nov-2026", "Resolved");

            // Double-click row to view details
            grid.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    OpenForm(new ComplaintDetails());
                }
            };

            content.Controls.Add(grid);

            // Keep Submit button and Table aligned when form resizes
            content.Resize += (s, e) =>
            {
                int rightEdge = Math.Max(880, content.ClientSize.Width - 30);
                submit.Location = new Point(rightEdge - submit.Width, 32);
                grid.Width = rightEdge - 30;
            };
        }

        // Helper to open child forms cleanly
        private void OpenForm(Form form)
        {
            form.FormClosed += (s, e) => this.Show();
            form.Show();
            this.Hide();
        }

        // Navigation Button Method
        private void AddMenuButton(
            Panel sidebar, string text, int y, bool active)
        {
            Button btn = new Button();

            btn.Text = text;
            btn.Location = new Point(15, y);
            btn.Size = new Size(200, 45);

            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(15, 0, 0, 0);

            btn.Font = new Font("Segoe UI", 10);
            btn.ForeColor = Color.White;

            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;

            btn.BackColor = active ? teal : navy;

            if (!active)
            {
                btn.MouseEnter += (s, e) =>
                {
                    btn.BackColor = Color.FromArgb(35, 75, 115);
                };

                btn.MouseLeave += (s, e) =>
                {
                    btn.BackColor = navy;
                };
            }

            btn.Click += (s, e) =>
            {
                switch (text)
                {
                    case "Dashboard":
                        return;
                    case "Submit Complaint":
                        OpenForm(new SubmitComplaint());
                        break;
                    case "My Complaints":
                        OpenForm(new MyComplaints());
                        break;
                    case "Notifications":
                        OpenForm(new Notifications());
                        break;
                    case "My Profile":
                        OpenForm(new StudentProfile());
                        break;
                }
            };

            sidebar.Controls.Add(btn);
        }

        // Statistics Card Method
        private void AddStatCard(
            Panel parent, string title, string value,
            Color accent, int x)
        {
            Panel card = new Panel();

            card.Location = new Point(x, 120);
            card.Size = new Size(195, 130);
            card.BackColor = Color.White;
            card.BorderStyle = BorderStyle.FixedSingle;

            Label heading = new Label();
            heading.Text = title;
            heading.Location = new Point(15, 20);
            heading.AutoSize = true;
            heading.ForeColor = gray;

            Label number = new Label();
            number.Text = value;
            number.Location = new Point(15, 55);
            number.AutoSize = true;
            number.Font = new Font("Segoe UI", 27, FontStyle.Bold);
            number.ForeColor = accent;

            card.Controls.Add(heading);
            card.Controls.Add(number);

            parent.Controls.Add(card);
        }
    }
}