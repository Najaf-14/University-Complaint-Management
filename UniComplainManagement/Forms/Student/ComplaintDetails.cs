
using System;
using System.Drawing;
using System.Windows.Forms;

namespace UniComplainManagement.Forms.Student
{
    public partial class ComplaintDetails : Form
    {
        private Color navy = Color.FromArgb(23, 59, 99);
        private Color teal = Color.FromArgb(13, 148, 136);
        private Color light = Color.FromArgb(244, 248, 252);
        private Color gray = Color.FromArgb(100, 116, 139);

        private string complaintId;
        private string title;
        private string category;
        private string date;
        private string status;

        public ComplaintDetails(
            string id, string complaintTitle,
            string complaintCategory, string complaintDate,
            string complaintStatus)
        {
            InitializeComponent();

            complaintId = id;
            title = complaintTitle;
            category = complaintCategory;
            date = complaintDate;
            status = complaintStatus;

            BuildForm();
        }

        private void BuildForm()
        {
            this.Text = "Complaint Details";
            this.Size = new Size(750, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = light;
            this.Font = new Font("Segoe UI", 10);

            // Header
            Panel header = new Panel();
            header.Dock = DockStyle.Top;
            header.Height = 100;
            header.BackColor = Color.White;
            this.Controls.Add(header);

            Label heading = new Label();
            heading.Text = "Complaint Details";
            heading.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            heading.ForeColor = navy;
            heading.Location = new Point(30, 25);
            heading.AutoSize = true;
            header.Controls.Add(heading);

            Label subtitle = new Label();
            subtitle.Text = "View information about your complaint.";
            subtitle.ForeColor = gray;
            subtitle.Location = new Point(33, 68);
            subtitle.AutoSize = true;
            header.Controls.Add(subtitle);

            // Details Panel
            Panel card = new Panel();
            card.Location = new Point(40, 130);
            card.Size = new Size(650, 340);
            card.BackColor = Color.White;
            card.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(card);

            AddDetail(card, "Complaint ID", complaintId, 30, 30);
            AddDetail(card, "Complaint Title", title, 30, 90);
            AddDetail(card, "Category", category, 30, 150);
            AddDetail(card, "Submitted Date", date, 30, 210);
            AddDetail(card, "Current Status", status, 30, 270);

            // Back Button
            Button btnBack = new Button();
            btnBack.Text = "Back";
            btnBack.Location = new Point(40, 495);
            btnBack.Size = new Size(130, 42);
            btnBack.BackColor = teal;
            btnBack.ForeColor = Color.White;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Cursor = Cursors.Hand;
            btnBack.Click += (s, e) => this.Close();

            this.Controls.Add(btnBack);
        }

        private void AddDetail(
            Panel parent, string labelText,
            string value, int x, int y)
        {
            Label lbl = new Label();
            lbl.Text = labelText;
            lbl.Location = new Point(x, y);
            lbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lbl.ForeColor = navy;
            lbl.AutoSize = true;
            parent.Controls.Add(lbl);

            Label valueLabel = new Label();
            valueLabel.Text = value;
            valueLabel.Location = new Point(x + 190, y);
            valueLabel.Font = new Font("Segoe UI", 10);
            valueLabel.ForeColor = gray;
            valueLabel.AutoSize = true;
            parent.Controls.Add(valueLabel);
        }
    }
}
