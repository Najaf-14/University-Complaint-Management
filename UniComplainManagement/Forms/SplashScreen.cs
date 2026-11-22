
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace UniComplainManagement.Forms
{
    public partial class SplashScreen : Form
    {
        private Timer animationTimer;
        private Image logo;
        private int elapsedTime = 0;
        private float logoOpacity = 0;
        private float titleOpacity = 0;
        private float progress = 0;

        public SplashScreen()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(244, 248, 252);
            this.ClientSize = new Size(900, 550);
            this.DoubleBuffered = true;

            string logoPath = Path.Combine(
                Application.StartupPath,
                "Assets",
                "Logo-removebg-preview.png"
            );

            logo = Image.FromFile(logoPath);

            animationTimer = new Timer();
            animationTimer.Interval = 30;
            animationTimer.Tick += AnimationTimer_Tick;

            this.Shown += (s, e) => animationTimer.Start();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            elapsedTime += animationTimer.Interval;

            // Fade in logo
            if (elapsedTime <= 1800 && logoOpacity < 1)
            {
                logoOpacity += 0.025f;

                if (logoOpacity > 1)
                    logoOpacity = 1;
            }

            // Fade in title
            if (elapsedTime >= 1000 && titleOpacity < 1)
            {
                titleOpacity += 0.025f;

                if (titleOpacity > 1)
                    titleOpacity = 1;
            }

            // Loading progress
            progress = Math.Min(elapsedTime / 5000f, 1f);

            Invalidate();

            // Open Login form
            if (elapsedTime >= 5200)
            {
                animationTimer.Stop();

                Login login = new Login();

                login.FormClosed += (s, args) => this.Close();

                login.Show();
                this.Hide();
            }
        }

        // Draw image with transparency
        private void DrawImageWithOpacity(
            Graphics g, Image image, Rectangle rectangle, float opacity)
        {
            ColorMatrix colorMatrix = new ColorMatrix();
            colorMatrix.Matrix33 = opacity;

            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(colorMatrix);

            g.DrawImage(
                image,
                rectangle,
                0,
                0,
                image.Width,
                image.Height,
                GraphicsUnit.Pixel,
                attributes
            );

            attributes.Dispose();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int centerX = this.ClientSize.Width / 2;

            // Background
            g.Clear(Color.FromArgb(244, 248, 252));

            // Decorative circles
            using (SolidBrush brush =
                new SolidBrush(Color.FromArgb(225, 237, 248)))
            {
                g.FillEllipse(brush, -120, -150, 350, 350);
            }

            using (SolidBrush brush =
                new SolidBrush(Color.FromArgb(222, 245, 241)))
            {
                g.FillEllipse(brush, 690, 390, 300, 300);
            }

            // Logo fade-in
            int logoSize = 170;

            Rectangle logoRectangle = new Rectangle(
                centerX - logoSize / 2,
                80,
                logoSize,
                logoSize
            );

            DrawImageWithOpacity(
                g,
                logo,
                logoRectangle,
                logoOpacity
            );

            // Title
            int alpha = (int)(titleOpacity * 255);

            using (SolidBrush brush =
                new SolidBrush(Color.FromArgb(alpha, 23, 59, 99)))
            using (Font font =
                new Font("Segoe UI", 25, FontStyle.Bold))
            {
                string title = "UNIVERSITY COMPLAINT";

                SizeF size = g.MeasureString(title, font);

                g.DrawString(
                    title,
                    font,
                    brush,
                    centerX - size.Width / 2,
                    275
                );
            }

            // Subtitle
            using (SolidBrush brush =
                new SolidBrush(Color.FromArgb(alpha, 13, 148, 136)))
            using (Font font =
                new Font("Segoe UI", 22, FontStyle.Bold))
            {
                string subtitle = "& HELPDESK";

                SizeF size = g.MeasureString(subtitle, font);

                g.DrawString(
                    subtitle,
                    font,
                    brush,
                    centerX - size.Width / 2,
                    320
                );
            }

            // Tagline
            using (SolidBrush brush =
                new SolidBrush(Color.FromArgb(alpha, 100, 116, 139)))
            using (Font font =
                new Font("Segoe UI", 10))
            {
                string tagline = "Making University Support Easier";

                SizeF size = g.MeasureString(tagline, font);

                g.DrawString(
                    tagline,
                    font,
                    brush,
                    centerX - size.Width / 2,
                    375
                );
            }

            // Progress bar background
            int barWidth = 300;
            int barX = centerX - barWidth / 2;
            int barY = 435;

            using (SolidBrush brush =
                new SolidBrush(Color.FromArgb(220, 230, 239)))
            {
                g.FillRectangle(
                    brush,
                    barX,
                    barY,
                    barWidth,
                    7
                );
            }

            // Progress bar fill
            using (SolidBrush brush =
                new SolidBrush(Color.FromArgb(13, 148, 136)))
            {
                g.FillRectangle(
                    brush,
                    barX,
                    barY,
                    (int)(barWidth * progress),
                    7
                );
            }

            // Loading text
            using (SolidBrush brush =
                new SolidBrush(Color.FromArgb(100, 116, 139)))
            using (Font font =
                new Font("Segoe UI", 9))
            {
                string loading = "Loading...";

                SizeF size = g.MeasureString(loading, font);

                g.DrawString(
                    loading,
                    font,
                    brush,
                    centerX - size.Width / 2,
                    455
                );
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            animationTimer?.Stop();
            animationTimer?.Dispose();
            logo?.Dispose();

            base.OnFormClosed(e);
        }
    }
}
