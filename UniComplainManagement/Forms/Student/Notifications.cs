
using System;
using System.Drawing;
using System.Windows.Forms;

namespace UniComplainManagement.Forms.Student
{
    public partial class Notifications : Form
    {
        private Color navy = Color.FromArgb(23, 59, 99);
        private Color teal = Color.FromArgb(13, 148, 136);
        private Color light = Color.FromArgb(244, 248, 252);
        private Color gray = Color.FromArgb(100, 116, 139);

        private FlowLayoutPanel notificationPanel;

        public Notifications()
        {
            InitializeComponent();
            BuildForm();
        }

        private void BuildForm()
        {
            this.Text = "Notifications";
            this.Size = new Size(1000, 700);
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
            heading.Text = "Notifications";
            heading.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            heading.ForeColor = navy;
            heading.Location = new Point(30, 20);
            heading.AutoSize = true;
            header.Controls.Add(heading);

            Label subtitle = new Label();
            subtitle.Text = "Stay updated about your complaints.";
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

            // Mark all as read button
            Button btnMarkAll = new Button();
            btnMarkAll.Text = "Mark All as Read";
            btnMarkAll.Size = new Size(160, 38);
            btnMarkAll.Location = new Point(25, 20);
            btnMarkAll.BackColor = navy;
            btnMarkAll.ForeColor = Color.White;
            btnMarkAll.FlatStyle = FlatStyle.Flat;
            btnMarkAll.FlatAppearance.BorderSize = 0;
            btnMarkAll.Cursor = Cursors.Hand;
            main.Controls.Add(btnMarkAll);

            // Notification list
            notificationPanel = new FlowLayoutPanel();
            notificationPanel.Location = new Point(25, 75);
            notificationPanel.Size = new Size(900, 440);
            notificationPanel.Anchor =
                AnchorStyles.Top | AnchorStyles.Bottom |
                AnchorStyles.Left | AnchorStyles.Right;
            notificationPanel.FlowDirection = FlowDirection.TopDown;
            notificationPanel.WrapContents = false;
            notificationPanel.AutoScroll = true;
            notificationPanel.BackColor = light;
            main.Controls.Add(notificationPanel);

            // Sample notifications
            AddNotification(
                "Complaint Submitted",
                "Your complaint CMP-001 has been submitted successfully.",
                "20-Nov-2026",
                false);

            AddNotification(
                "Complaint In Progress",
                "Your complaint CMP-001 is now being reviewed.",
                "21-Nov-2026",
                false);

            AddNotification(
                "Complaint Resolved",
                "Your complaint CMP-003 has been resolved.",
                "22-Nov-2026",
                true);

            AddNotification(
                "Complaint Assigned",
                "Your complaint CMP-002 has been assigned to the Finance Department.",
                "23-Nov-2026",
                false);

            // Mark all as read functionality
            btnMarkAll.Click += (s, e) =>
            {
                foreach (Control control in notificationPanel.Controls)
                {
                    Panel card = control as Panel;

                    if (card != null)
                    {
                        card.BackColor = Color.White;

                        foreach (Control child in card.Controls)
                        {
                            if (child is Label && child.Name == "unread")
                            {
                                child.Text = "Read";
                                child.ForeColor = gray;
                            }
                        }
                    }
                }

                MessageBox.Show("All notifications marked as read.");
            };

            // Back button
            Button btnBack = new Button();
            btnBack.Text = "Back to Dashboard";
            btnBack.Size = new Size(170, 40);
            btnBack.Location = new Point(25, 535);
            btnBack.BackColor = teal;
            btnBack.ForeColor = Color.White;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Cursor = Cursors.Hand;
            btnBack.Click += (s, e) => this.Close();
            main.Controls.Add(btnBack);
        }

        private void AddNotification(
            string title,
            string message,
            string date,
            bool isRead)
        {
            Panel card = new Panel();
            card.Size = new Size(850, 95);
            card.BackColor = isRead
                ? Color.White
                : Color.FromArgb(232, 243, 250);
            card.Margin = new Padding(0, 0, 0, 12);

            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblTitle.ForeColor = navy;
            lblTitle.Location = new Point(15, 12);
            lblTitle.AutoSize = true;
            card.Controls.Add(lblTitle);

            Label lblMessage = new Label();
            lblMessage.Text = message;
            lblMessage.Font = new Font("Segoe UI", 9);
            lblMessage.ForeColor = gray;
            lblMessage.Location = new Point(15, 42);
            lblMessage.AutoSize = true;
            card.Controls.Add(lblMessage);

            Label lblDate = new Label();
            lblDate.Text = date;
            lblDate.Font = new Font("Segoe UI", 8);
            lblDate.ForeColor = gray;
            lblDate.Location = new Point(700, 15);
            lblDate.AutoSize = true;
            card.Controls.Add(lblDate);

            Label lblRead = new Label();
            lblRead.Name = "unread";
            lblRead.Text = isRead ? "Read" : "Unread";
            lblRead.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            lblRead.ForeColor = isRead ? gray : teal;
            lblRead.Location = new Point(700, 48);
            lblRead.AutoSize = true;
            card.Controls.Add(lblRead);

            notificationPanel.Controls.Add(card);
        }
    }
}
