
using System;
using System.Drawing;
using System.Windows.Forms;

namespace UniComplainManagement.Forms.Student
{
    public partial class StudentProfile : Form
    {
        private Color navy = Color.FromArgb(23, 59, 99);
        private Color teal = Color.FromArgb(13, 148, 136);
        private Color light = Color.FromArgb(244, 248, 252);
        private Color gray = Color.FromArgb(100, 116, 139);

        private string currentStudentId;

        private TextBox txtName;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private TextBox txtDepartment;
        private TextBox txtSemester;

        public StudentProfile() : this("Student")
        {
        }

        public StudentProfile(string studentId)
        {
            InitializeComponent();

            currentStudentId = studentId;
            BuildForm();
        }

        private void BuildForm()
        {
            this.Text = "My Profile";
            this.Size = new Size(850, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = light;
            this.Font = new Font("Segoe UI", 10);

            // Header
            Panel header = new Panel();
            header.Dock = DockStyle.Top;
            header.Height = 105;
            header.BackColor = Color.White;
            this.Controls.Add(header);

            Label heading = new Label();
            heading.Text = "My Profile";
            heading.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            heading.ForeColor = navy;
            heading.Location = new Point(30, 20);
            heading.AutoSize = true;
            header.Controls.Add(heading);

            Label subtitle = new Label();
            subtitle.Text = "View and update your personal information.";
            subtitle.ForeColor = gray;
            subtitle.Location = new Point(33, 65);
            subtitle.AutoSize = true;
            header.Controls.Add(subtitle);

            // Profile Card
            Panel card = new Panel();
            card.Location = new Point(55, 135);
            card.Size = new Size(710, 440);
            card.BackColor = Color.White;
            card.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(card);

            // Profile Icon
            Label avatar = new Label();
            avatar.Text = "S";
            avatar.Size = new Size(75, 75);
            avatar.Location = new Point(30, 25);
            avatar.BackColor = navy;
            avatar.ForeColor = Color.White;
            avatar.Font = new Font("Segoe UI", 28, FontStyle.Bold);
            avatar.TextAlign = ContentAlignment.MiddleCenter;
            card.Controls.Add(avatar);

            Label profileTitle = new Label();
            profileTitle.Text = "Student Information";
            profileTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            profileTitle.ForeColor = navy;
            profileTitle.Location = new Point(125, 35);
            profileTitle.AutoSize = true;
            card.Controls.Add(profileTitle);

            Label idLabel = new Label();
            idLabel.Text = "Student ID: " + currentStudentId;
            idLabel.ForeColor = gray;
            idLabel.Location = new Point(127, 65);
            idLabel.AutoSize = true;
            card.Controls.Add(idLabel);

            // Input Fields
            AddLabel(card, "Full Name", 35, 135);
            txtName = AddTextBox(card, "Student Name", 35, 160);

            AddLabel(card, "Email Address", 365, 135);
            txtEmail = AddTextBox(card, "student@example.com", 365, 160);

            AddLabel(card, "Phone Number", 35, 225);
            txtPhone = AddTextBox(card, "03XXXXXXXXX", 35, 250);

            AddLabel(card, "Department", 365, 225);
            txtDepartment = AddTextBox(card, "Computer Science", 365, 250);

            AddLabel(card, "Semester", 35, 315);
            txtSemester = AddTextBox(card, "6th Semester", 35, 340);

            // Save Button
            Button btnSave = new Button();
            btnSave.Text = "Save Changes";
            btnSave.Location = new Point(365, 350);
            btnSave.Size = new Size(145, 42);
            btnSave.BackColor = teal;
            btnSave.ForeColor = Color.White;
            btnSave.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Cursor = Cursors.Hand;

            btnSave.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtName.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtPhone.Text))
                {
                    MessageBox.Show(
                        "Please fill in Name, Email and Phone.",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                MessageBox.Show(
                    "Profile information updated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            };

            card.Controls.Add(btnSave);

            // Back Button
            Button btnBack = new Button();
            btnBack.Text = "Back to Dashboard";
            btnBack.Location = new Point(55, 600);
            btnBack.Size = new Size(175, 42);
            btnBack.BackColor = navy;
            btnBack.ForeColor = Color.White;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Cursor = Cursors.Hand;
            btnBack.Click += (s, e) => this.Close();

            this.Controls.Add(btnBack);
        }

        private void AddLabel(Panel parent, string text, int x, int y)
        {
            Label lbl = new Label();
            lbl.Text = text;
            lbl.Location = new Point(x, y);
            lbl.AutoSize = true;
            lbl.ForeColor = navy;
            lbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            parent.Controls.Add(lbl);
        }

        private TextBox AddTextBox(
            Panel parent, string value, int x, int y)
        {
            TextBox txt = new TextBox();
            txt.Text = value;
            txt.Location = new Point(x, y);
            txt.Size = new Size(280, 32);
            txt.Font = new Font("Segoe UI", 10);
            parent.Controls.Add(txt);

            return txt;
        }
    }
}
