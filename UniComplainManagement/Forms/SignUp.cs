using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace UniComplainManagement.Forms
{
    public partial class SignUp : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        private Image logo;
        private TextBox txtStudentId;
        private TextBox txtFullName;
        private TextBox txtPassword;
        private CheckBox chkShowPassword;
        private Button btnCreateAccount;
        private LinkLabel lnkBackToLogin;

        public SignUp()
        {
            InitializeUI();
        }

        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, placeholder);
        }

        private void InitializeUI()
        {
            this.Text = "University Complaint & HelpDesk - Create Account";
            this.ClientSize = new Size(900, 550);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(244, 248, 252);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.DoubleBuffered = true;

            string logoPath = Path.Combine(Application.StartupPath, "Assets", "Logo-removebg-preview.png");
            if (File.Exists(logoPath))
            {
                logo = Image.FromFile(logoPath);
            }

            // Left Branding Area
            int leftCenterX = 205;

            PictureBox picLogo = new PictureBox();
            picLogo.Size = new Size(130, 130);
            picLogo.Location = new Point(leftCenterX - 65, 115);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.BackColor = Color.Transparent;
            if (logo != null)
            {
                picLogo.Image = logo;
            }

            Label lblBrandTitle = new Label();
            lblBrandTitle.Text = "UNIVERSITY COMPLAINT";
            lblBrandTitle.Font = new Font("Segoe UI", 15, FontStyle.Bold);
            lblBrandTitle.ForeColor = Color.FromArgb(23, 59, 99);
            lblBrandTitle.BackColor = Color.Transparent;
            lblBrandTitle.AutoSize = false;
            lblBrandTitle.Size = new Size(340, 32);
            lblBrandTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblBrandTitle.Location = new Point(leftCenterX - 170, 260);

            Label lblBrandSub = new Label();
            lblBrandSub.Text = "& HELPDESK";
            lblBrandSub.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblBrandSub.ForeColor = Color.FromArgb(13, 148, 136);
            lblBrandSub.BackColor = Color.Transparent;
            lblBrandSub.AutoSize = false;
            lblBrandSub.Size = new Size(340, 30);
            lblBrandSub.TextAlign = ContentAlignment.MiddleCenter;
            lblBrandSub.Location = new Point(leftCenterX - 170, 292);

            Label lblTagline = new Label();
            lblTagline.Text = "Making University Support Easier";
            lblTagline.Font = new Font("Segoe UI", 9.5f);
            lblTagline.ForeColor = Color.FromArgb(100, 116, 139);
            lblTagline.BackColor = Color.Transparent;
            lblTagline.AutoSize = false;
            lblTagline.Size = new Size(340, 25);
            lblTagline.TextAlign = ContentAlignment.MiddleCenter;
            lblTagline.Location = new Point(leftCenterX - 170, 330);

            this.Controls.Add(picLogo);
            this.Controls.Add(lblBrandTitle);
            this.Controls.Add(lblBrandSub);
            this.Controls.Add(lblTagline);

            // Right White Form Card
            Panel cardPanel = new Panel();
            cardPanel.Size = new Size(430, 460);
            cardPanel.Location = new Point(415, 45);
            cardPanel.BackColor = Color.White;
            cardPanel.Paint += (s, e) =>
            {
                using (Pen borderPen = new Pen(Color.FromArgb(220, 230, 239), 1))
                {
                    e.Graphics.DrawRectangle(borderPen, 0, 0, cardPanel.Width - 1, cardPanel.Height - 1);
                }
            };

            int padX = 40;

            Label lblHeading = new Label();
            lblHeading.Text = "Create Student Account";
            lblHeading.Font = new Font("Segoe UI", 19, FontStyle.Bold);
            lblHeading.ForeColor = Color.FromArgb(23, 59, 99);
            lblHeading.Location = new Point(padX, 28);
            lblHeading.AutoSize = true;

            // Student ID
            Label lblStudentId = new Label();
            lblStudentId.Text = "Student ID";
            lblStudentId.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            lblStudentId.ForeColor = Color.FromArgb(23, 59, 99);
            lblStudentId.Location = new Point(padX, 82);
            lblStudentId.AutoSize = true;

            txtStudentId = new TextBox();
            txtStudentId.Font = new Font("Segoe UI", 11);
            txtStudentId.Location = new Point(padX, 105);
            txtStudentId.Size = new Size(350, 30);
            SetPlaceholder(txtStudentId, "e.g., SP24-BCS-045");

            // Full Name
            Label lblFullName = new Label();
            lblFullName.Text = "Full Name";
            lblFullName.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            lblFullName.ForeColor = Color.FromArgb(23, 59, 99);
            lblFullName.Location = new Point(padX, 152);
            lblFullName.AutoSize = true;

            txtFullName = new TextBox();
            txtFullName.Font = new Font("Segoe UI", 11);
            txtFullName.Location = new Point(padX, 175);
            txtFullName.Size = new Size(350, 30);
            SetPlaceholder(txtFullName, "Enter your full name");

            // Password
            Label lblPassword = new Label();
            lblPassword.Text = "Password";
            lblPassword.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(23, 59, 99);
            lblPassword.Location = new Point(padX, 222);
            lblPassword.AutoSize = true;

            txtPassword = new TextBox();
            txtPassword.Font = new Font("Segoe UI", 11);
            txtPassword.Location = new Point(padX, 245);
            txtPassword.Size = new Size(350, 30);
            txtPassword.UseSystemPasswordChar = true;
            SetPlaceholder(txtPassword, "Minimum 6 characters");

            chkShowPassword = new CheckBox();
            chkShowPassword.Text = "Show password";
            chkShowPassword.Font = new Font("Segoe UI", 9);
            chkShowPassword.ForeColor = Color.FromArgb(100, 116, 139);
            chkShowPassword.Location = new Point(padX, 281);
            chkShowPassword.AutoSize = true;
            chkShowPassword.CheckedChanged += (s, e) =>
            {
                txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
            };

            // Create Account Button
            btnCreateAccount = new Button();
            btnCreateAccount.Text = "Create Account";
            btnCreateAccount.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnCreateAccount.BackColor = Color.FromArgb(13, 148, 136);
            btnCreateAccount.ForeColor = Color.White;
            btnCreateAccount.FlatStyle = FlatStyle.Flat;
            btnCreateAccount.Location = new Point(padX, 322);
            btnCreateAccount.Size = new Size(350, 42);
            btnCreateAccount.Cursor = Cursors.Hand;
            btnCreateAccount.FlatAppearance.BorderSize = 0;
            btnCreateAccount.Click += BtnCreateAccount_Click;

            // Back to Login Link
            lnkBackToLogin = new LinkLabel();
            lnkBackToLogin.Text = "Already have an account? Sign In";
            lnkBackToLogin.Font = new Font("Segoe UI", 9.5f);
            lnkBackToLogin.LinkColor = Color.FromArgb(23, 59, 99);
            lnkBackToLogin.ActiveLinkColor = Color.FromArgb(13, 148, 136);
            lnkBackToLogin.Location = new Point(padX + 75, 385);
            lnkBackToLogin.AutoSize = true;
            lnkBackToLogin.Click += (s, e) =>
            {
                this.Close();
            };

            cardPanel.Controls.Add(lblHeading);
            cardPanel.Controls.Add(lblStudentId);
            cardPanel.Controls.Add(txtStudentId);
            cardPanel.Controls.Add(lblFullName);
            cardPanel.Controls.Add(txtFullName);
            cardPanel.Controls.Add(lblPassword);
            cardPanel.Controls.Add(txtPassword);
            cardPanel.Controls.Add(chkShowPassword);
            cardPanel.Controls.Add(btnCreateAccount);
            cardPanel.Controls.Add(lnkBackToLogin);

            this.Controls.Add(cardPanel);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Decorative circles matching SplashScreen
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(225, 237, 248)))
            {
                g.FillEllipse(brush, -120, -150, 350, 350);
            }

            using (SolidBrush brush = new SolidBrush(Color.FromArgb(222, 245, 241)))
            {
                g.FillEllipse(brush, 690, 390, 300, 300);
            }
        }

        private void BtnCreateAccount_Click(object sender, EventArgs e)
        {
            string studentId = txtStudentId.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(studentId) || string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.", "Weak Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // TODO: Save studentId, fullName, and password to your database

            MessageBox.Show($"Account created successfully for {fullName} ({studentId})!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            logo?.Dispose();
            base.OnFormClosed(e);
        }
    }
}