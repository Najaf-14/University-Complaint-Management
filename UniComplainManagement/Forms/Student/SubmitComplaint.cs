
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace UniComplainManagement.Forms.Student
{
    public partial class SubmitComplaint : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(
            IntPtr hWnd,
            int msg,
            int wParam,
            [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        private const int EM_SETCUEBANNER = 0x1501;

        private string currentStudentId;

        // Theme Colors
        private Color navy = Color.FromArgb(23, 59, 99);
        private Color teal = Color.FromArgb(13, 148, 136);
        private Color background = Color.FromArgb(244, 248, 252);
        private Color gray = Color.FromArgb(100, 116, 139);

        // Form Controls
        private TextBox txtTitle;
        private ComboBox cmbCategory;
        private ComboBox cmbPriority;
        private TextBox txtLocation;
        private TextBox txtDescription;

        public SubmitComplaint()
        {
            InitializeComponent();
            BuildFormUI();
        }

        public SubmitComplaint(string studentId)
        {
            InitializeComponent();
            currentStudentId = studentId;
            BuildFormUI();
        }

        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, placeholder);
        }

        private void BuildFormUI()
        {
            // Form Settings
            this.Text = "Submit New Complaint - University HelpDesk";
            this.Size = new Size(920, 720);
            this.MinimumSize = new Size(820, 680);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = background;
            this.Font = new Font("Segoe UI", 10);

            // Header
            Panel header = new Panel();
            header.Dock = DockStyle.Top;
            header.Height = 70;
            header.BackColor = Color.White;

            Label lblHeaderTitle = new Label();
            lblHeaderTitle.Text = "Submit a New Complaint";
            lblHeaderTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblHeaderTitle.ForeColor = navy;
            lblHeaderTitle.Location = new Point(35, 19);
            lblHeaderTitle.AutoSize = true;
            header.Controls.Add(lblHeaderTitle);

            Button btnBack = new Button();
            btnBack.Text = "← Back to Dashboard";
            btnBack.Size = new Size(175, 38);
            btnBack.BackColor = Color.FromArgb(230, 238, 247);
            btnBack.ForeColor = navy;
            btnBack.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Cursor = Cursors.Hand;
            btnBack.Click += (s, e) => this.Close();
            header.Controls.Add(btnBack);

            header.Resize += (s, e) =>
            {
                btnBack.Location = new Point(
                    header.Width - btnBack.Width - 35, 16);
            };

            // Scrollable Content
            Panel content = new Panel();
            content.Dock = DockStyle.Fill;
            content.AutoScroll = true;
            content.BackColor = background;

            this.Controls.Add(content);
            this.Controls.Add(header);

            // White Card
            Panel card = new Panel();
            card.Size = new Size(810, 520);
            card.Location = new Point(45, 25);
            card.BackColor = Color.White;

            card.Paint += (s, e) =>
            {
                using (Pen borderPen = new Pen(
                    Color.FromArgb(220, 230, 239), 1))
                {
                    e.Graphics.DrawRectangle(
                        borderPen, 0, 0,
                        card.Width - 1, card.Height - 1);
                }
            };

            int padX = 40;

            // Description
            Label lblSub = new Label();
            lblSub.Text = "Please provide clear details so university support staff can resolve your issue quickly.";
            lblSub.Font = new Font("Segoe UI", 9.5f);
            lblSub.ForeColor = gray;
            lblSub.Location = new Point(padX, 25);
            lblSub.AutoSize = true;
            card.Controls.Add(lblSub);

            // Complaint Title
            Label lblTitle = new Label();
            lblTitle.Text = "Complaint Title *";
            lblTitle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblTitle.ForeColor = navy;
            lblTitle.Location = new Point(padX, 65);
            lblTitle.AutoSize = true;
            card.Controls.Add(lblTitle);

            txtTitle = new TextBox();
            txtTitle.Font = new Font("Segoe UI", 10.5f);
            txtTitle.Location = new Point(padX, 90);
            txtTitle.Size = new Size(730, 30);
            SetPlaceholder(txtTitle, "e.g., Campus Wi-Fi not connecting in CS Lab 3");
            card.Controls.Add(txtTitle);

            // Category
            Label lblCategory = new Label();
            lblCategory.Text = "Category / Department *";
            lblCategory.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblCategory.ForeColor = navy;
            lblCategory.Location = new Point(padX, 140);
            lblCategory.AutoSize = true;
            card.Controls.Add(lblCategory);

            cmbCategory = new ComboBox();
            cmbCategory.Font = new Font("Segoe UI", 10.5f);
            cmbCategory.Location = new Point(padX, 165);
            cmbCategory.Size = new Size(350, 30);
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbCategory.Items.AddRange(new object[]
            {
                "Select a category...",
                "IT & Networking",
                "Academics & Examination",
                "Finance & Fee Issues",
                "Hostel & Accommodation",
                "Transport",
                "Library & Labs",
                "Administration / Other"
            });

            cmbCategory.SelectedIndex = 0;
            card.Controls.Add(cmbCategory);

            // Priority
            Label lblPriority = new Label();
            lblPriority.Text = "Priority Level";
            lblPriority.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblPriority.ForeColor = navy;
            lblPriority.Location = new Point(420, 140);
            lblPriority.AutoSize = true;
            card.Controls.Add(lblPriority);

            cmbPriority = new ComboBox();
            cmbPriority.Font = new Font("Segoe UI", 10.5f);
            cmbPriority.Location = new Point(420, 165);
            cmbPriority.Size = new Size(350, 30);
            cmbPriority.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbPriority.Items.AddRange(new object[]
            {
                "Low",
                "Medium",
                "High",
                "Urgent"
            });

            cmbPriority.SelectedIndex = 1;
            card.Controls.Add(cmbPriority);

            // Location
            Label lblLocation = new Label();
            lblLocation.Text = "Location / Building (Optional)";
            lblLocation.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblLocation.ForeColor = navy;
            lblLocation.Location = new Point(padX, 215);
            lblLocation.AutoSize = true;
            card.Controls.Add(lblLocation);

            txtLocation = new TextBox();
            txtLocation.Font = new Font("Segoe UI", 10.5f);
            txtLocation.Location = new Point(padX, 240);
            txtLocation.Size = new Size(730, 30);
            SetPlaceholder(txtLocation, "e.g., CS Block Room 204, Boys Hostel B, Admin Office");
            card.Controls.Add(txtLocation);

            // Detailed Description
            Label lblDescription = new Label();
            lblDescription.Text = "Detailed Description *";
            lblDescription.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblDescription.ForeColor = navy;
            lblDescription.Location = new Point(padX, 290);
            lblDescription.AutoSize = true;
            card.Controls.Add(lblDescription);

            txtDescription = new TextBox();
            txtDescription.Font = new Font("Segoe UI", 10.5f);
            txtDescription.Location = new Point(padX, 315);
            txtDescription.Size = new Size(730, 115);
            txtDescription.Multiline = true;
            txtDescription.ScrollBars = ScrollBars.Vertical;
            SetPlaceholder(txtDescription, "Describe the issue in detail, including when it started...");
            card.Controls.Add(txtDescription);

            // Clear Button
            Button btnClear = new Button();
            btnClear.Text = "Clear Form";
            btnClear.Size = new Size(130, 42);
            btnClear.Location = new Point(450, 455);
            btnClear.BackColor = Color.FromArgb(226, 232, 240);
            btnClear.ForeColor = Color.FromArgb(51, 65, 85);
            btnClear.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.Cursor = Cursors.Hand;
            btnClear.Click += (s, e) => ClearFields();
            card.Controls.Add(btnClear);

            // Submit Button
            Button btnSubmit = new Button();
            btnSubmit.Text = "Submit Complaint";
            btnSubmit.Size = new Size(175, 42);
            btnSubmit.Location = new Point(595, 455);
            btnSubmit.BackColor = teal;
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.Cursor = Cursors.Hand;
            btnSubmit.Click += BtnSubmit_Click;
            card.Controls.Add(btnSubmit);

            content.Controls.Add(card);

            // Center Card
            content.Resize += (s, e) =>
            {
                int x = Math.Max(
                    30, (content.ClientSize.Width - card.Width) / 2);

                card.Location = new Point(x, 25);
            };
        }

        private void ClearFields()
        {
            txtTitle.Clear();
            cmbCategory.SelectedIndex = 0;
            cmbPriority.SelectedIndex = 1;
            txtLocation.Clear();
            txtDescription.Clear();
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string description = txtDescription.Text.Trim();

            // Validate Title
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show(
                    "Please enter a complaint title.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTitle.Focus();
                return;
            }

            // Validate Category
            if (cmbCategory.SelectedIndex == 0)
            {
                MessageBox.Show(
                    "Please select a category.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbCategory.Focus();
                return;
            }

            // Validate Description
            if (string.IsNullOrEmpty(description))
            {
                MessageBox.Show(
                    "Please provide a detailed description of your issue.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtDescription.Focus();
                return;
            }

            string category = cmbCategory.SelectedItem.ToString();
            string priority = cmbPriority.SelectedItem.ToString();

            // TODO: Save complaint to database.

            MessageBox.Show(
                $"Complaint submitted successfully!\n\n" +
                $"Title: {title}\n" +
                $"Category: {category}\n" +
                $"Priority: {priority}",
                "Complaint Submitted",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            this.Close();
        }
    }
}
