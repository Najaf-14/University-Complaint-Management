using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace UniComplainManagement.Forms
{
    public partial class Login : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        private Image logo;
        private TextBox txtStudentId;
        private TextBox txtPassword;
        private CheckBox chkShowPassword;
        private Button btnLogin;
        private LinkLabel lnkSignUp;

        public Login()
        {
            InitializeUI();
        }

        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, placeholder);
        }

        private void InitializeUI()
        {
            this.Text = "University Complaint & HelpDesk - Login";
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

            // Left Branding Area (Transparent over SplashScreen background & circles)
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
            cardPanel.Size = new Size(430, 440);
            cardPanel.Location = new Point(415, 55);
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
            lblHeading.Text = "Student Sign In";
            lblHeading.Font = new Font("Segoe UI", 19, FontStyle.Bold);
            lblHeading.ForeColor = Color.FromArgb(23, 59, 99);
            lblHeading.Location = new Point(padX, 38);
            lblHeading.AutoSize = true;

            Label lblSubHeading = new Label();
            lblSubHeading.Text = "Enter your credentials to access your dashboard";
            lblSubHeading.Font = new Font("Segoe UI", 9);
            lblSubHeading.ForeColor = Color.FromArgb(100, 116, 139);
            lblSubHeading.Location = new Point(padX, 74);
            lblSubHeading.AutoSize = true;

            // Student ID
            Label lblStudentId = new Label();
            lblStudentId.Text = "Student ID";
            lblStudentId.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            lblStudentId.ForeColor = Color.FromArgb(23, 59, 99);
            lblStudentId.Location = new Point(padX, 122);
            lblStudentId.AutoSize = true;

            txtStudentId = new TextBox();
            txtStudentId.Font = new Font("Segoe UI", 11);
            txtStudentId.Location = new Point(padX, 146);
            txtStudentId.Size = new Size(350, 30);
            SetPlaceholder(txtStudentId, "e.g., SP24-BCS-045");

            // Password
            Label lblPassword = new Label();
            lblPassword.Text = "Password";
            lblPassword.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(23, 59, 99);
            lblPassword.Location = new Point(padX, 198);
            lblPassword.AutoSize = true;

            txtPassword = new TextBox();
            txtPassword.Font = new Font("Segoe UI", 11);
            txtPassword.Location = new Point(padX, 222);
            txtPassword.Size = new Size(350, 30);
            txtPassword.UseSystemPasswordChar = true;
            SetPlaceholder(txtPassword, "Enter your password");

            chkShowPassword = new CheckBox();
            chkShowPassword.Text = "Show password";
            chkShowPassword.Font = new Font("Segoe UI", 9);
            chkShowPassword.ForeColor = Color.FromArgb(100, 116, 139);
            chkShowPassword.Location = new Point(padX, 258);
            chkShowPassword.AutoSize = true;
            chkShowPassword.CheckedChanged += (s, e) =>
            {
                txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
            };

            // Login Button
            btnLogin = new Button();
            btnLogin.Text = "Sign In";
            btnLogin.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnLogin.BackColor = Color.FromArgb(13, 148, 136);
            btnLogin.ForeColor = Color.White;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Location = new Point(padX, 302);
            btnLogin.Size = new Size(350, 42);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Click += BtnLogin_Click;

            // Sign Up Link
            lnkSignUp = new LinkLabel();
            lnkSignUp.Text = "New student? Create an account";
            lnkSignUp.Font = new Font("Segoe UI", 9.5f);
            lnkSignUp.LinkColor = Color.FromArgb(23, 59, 99);
            lnkSignUp.ActiveLinkColor = Color.FromArgb(13, 148, 136);
            lnkSignUp.Location = new Point(padX + 78, 365);
            lnkSignUp.AutoSize = true;
            lnkSignUp.Click += (s, e) =>
            {
                SignUp signUpForm = new SignUp();
                signUpForm.FormClosed += (sender2, args2) => this.Show();
                signUpForm.Show();
                this.Hide();
            };

            cardPanel.Controls.Add(lblHeading);
            cardPanel.Controls.Add(lblSubHeading);
            cardPanel.Controls.Add(lblStudentId);
            cardPanel.Controls.Add(txtStudentId);
            cardPanel.Controls.Add(lblPassword);
            cardPanel.Controls.Add(txtPassword);
            cardPanel.Controls.Add(chkShowPassword);
            cardPanel.Controls.Add(btnLogin);
            cardPanel.Controls.Add(lnkSignUp);

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

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string studentId = txtStudentId.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(studentId) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both Student ID and Password.", "Login Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // TODO: Verify Student ID and Password against your database
            MessageBox.Show($"Welcome back, {studentId}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            logo?.Dispose();
            base.OnFormClosed(e);
            Application.Exit();
        }
    }
}