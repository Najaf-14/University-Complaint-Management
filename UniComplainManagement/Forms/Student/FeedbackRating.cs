
using System;
using System.Drawing;
using System.Windows.Forms;

namespace UniComplainManagement.Forms.Student
{
    public partial class FeedbackRating : Form
    {
        private Color navy = Color.FromArgb(23, 59, 99);
        private Color teal = Color.FromArgb(13, 148, 136);
        private Color light = Color.FromArgb(244, 248, 252);
        private Color gray = Color.FromArgb(100, 116, 139);

        private ComboBox cmbComplaint;
        private TextBox txtFeedback;
        private Label lblRating;
        private int selectedRating = 0;

        public FeedbackRating(string studentId)
        {
            InitializeComponent();
            BuildForm();
        }

        private void BuildForm()
        {
            this.Text = "Feedback & Rating";
            this.Size = new Size(850, 650);
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
            heading.Text = "Feedback & Rating";
            heading.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            heading.ForeColor = navy;
            heading.Location = new Point(30, 20);
            heading.AutoSize = true;
            header.Controls.Add(heading);

            Label subtitle = new Label();
            subtitle.Text = "Share your experience about complaint resolution.";
            subtitle.ForeColor = gray;
            subtitle.Location = new Point(33, 65);
            subtitle.AutoSize = true;
            header.Controls.Add(subtitle);

            // Main panel
            Panel main = new Panel();
            main.Dock = DockStyle.Fill;
            main.Padding = new Padding(30);
            main.BackColor = light;
            this.Controls.Add(main);
            main.BringToFront();

            // Complaint selection
            Label lblComplaint = new Label();
            lblComplaint.Text = "Select Resolved Complaint";
            lblComplaint.Location = new Point(30, 30);
            lblComplaint.AutoSize = true;
            lblComplaint.ForeColor = navy;
            lblComplaint.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            main.Controls.Add(lblComplaint);

            cmbComplaint = new ComboBox();
            cmbComplaint.Location = new Point(30, 65);
            cmbComplaint.Size = new Size(650, 35);
            cmbComplaint.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbComplaint.Items.AddRange(new object[]
            {
                "CMP-003 - Classroom Projector",
                "CMP-005 - Library Internet Issue"
            });
            cmbComplaint.SelectedIndex = 0;
            main.Controls.Add(cmbComplaint);

            // Rating
            Label lblRateTitle = new Label();
            lblRateTitle.Text = "Rate Our Complaint Resolution";
            lblRateTitle.Location = new Point(30, 125);
            lblRateTitle.AutoSize = true;
            lblRateTitle.ForeColor = navy;
            lblRateTitle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            main.Controls.Add(lblRateTitle);

            // Star buttons
            for (int i = 1; i <= 5; i++)
            {
                int rating = i;

                Button star = new Button();
                star.Text = "★";
                star.Font = new Font("Segoe UI Symbol", 25);
                star.Size = new Size(55, 55);
                star.Location = new Point(30 + ((i - 1) * 65), 160);
                star.FlatStyle = FlatStyle.Flat;
                star.FlatAppearance.BorderSize = 0;
                star.BackColor = light;
                star.ForeColor = Color.Silver;
                star.Cursor = Cursors.Hand;
                star.Tag = rating;

                star.Click += (s, e) =>
                {
                    selectedRating = rating;
                    UpdateStars(main);
                };

                main.Controls.Add(star);
            }

            lblRating = new Label();
            lblRating.Text = "Select your rating";
            lblRating.Location = new Point(30, 225);
            lblRating.AutoSize = true;
            lblRating.ForeColor = gray;
            main.Controls.Add(lblRating);

            // Feedback
            Label lblFeedback = new Label();
            lblFeedback.Text = "Your Comments";
            lblFeedback.Location = new Point(30, 275);
            lblFeedback.AutoSize = true;
            lblFeedback.ForeColor = navy;
            lblFeedback.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            main.Controls.Add(lblFeedback);

            txtFeedback = new TextBox();
            txtFeedback.Location = new Point(30, 310);
            txtFeedback.Size = new Size(650, 100);
            txtFeedback.Multiline = true;
            txtFeedback.MaxLength = 500;
            txtFeedback.Font = new Font("Segoe UI", 10);
            txtFeedback.ScrollBars = ScrollBars.Vertical;
            main.Controls.Add(txtFeedback);

            // Submit button
            Button btnSubmit = new Button();
            btnSubmit.Text = "Submit Feedback";
            btnSubmit.Location = new Point(30, 440);
            btnSubmit.Size = new Size(170, 42);
            btnSubmit.BackColor = teal;
            btnSubmit.ForeColor = Color.White;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.Cursor = Cursors.Hand;
            btnSubmit.Click += BtnSubmit_Click;
            main.Controls.Add(btnSubmit);

            // Back button
            Button btnBack = new Button();
            btnBack.Text = "Back to Dashboard";
            btnBack.Location = new Point(215, 440);
            btnBack.Size = new Size(170, 42);
            btnBack.BackColor = navy;
            btnBack.ForeColor = Color.White;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Cursor = Cursors.Hand;
            btnBack.Click += (s, e) => this.Close();
            main.Controls.Add(btnBack);
        }

        private void UpdateStars(Panel main)
        {
            foreach (Control control in main.Controls)
            {
                if (control is Button && control.Tag != null)
                {
                    int rating = Convert.ToInt32(control.Tag);

                    control.ForeColor = rating <= selectedRating
                        ? Color.FromArgb(245, 166, 35)
                        : Color.Silver;
                }
            }

            string[] ratings =
            {
                "",
                "1 - Very Poor",
                "2 - Poor",
                "3 - Average",
                "4 - Good",
                "5 - Excellent"
            };

            lblRating.Text = ratings[selectedRating];
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (cmbComplaint.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a complaint.");
                return;
            }

            if (selectedRating == 0)
            {
                MessageBox.Show("Please select a star rating.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFeedback.Text))
            {
                MessageBox.Show("Please enter your feedback.");
                return;
            }

            MessageBox.Show(
                "Feedback submitted successfully!\n" +
                "Complaint: " + cmbComplaint.SelectedItem +
                "\nRating: " + selectedRating + "/5",
                "Feedback",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            txtFeedback.Clear();
            selectedRating = 0;
            lblRating.Text = "Select your rating";
            cmbComplaint.SelectedIndex = -1;
        }
    }
}
