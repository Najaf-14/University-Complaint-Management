using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniComplainManagement.Forms.Student
{
    public partial class StudentDashboard : Form
    {
        private string currentStudentId;
        public StudentDashboard()
        {
            InitializeComponent();
        }

        public StudentDashboard(string studentId): this()
        {
            this.currentStudentId = studentId;

            Label lbl = new Label();
            lbl.Text = "Student";
            lbl.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            lbl.AutoSize = true;
            lbl.Location = new Point((this.ClientSize.Width - lbl.Width) / 2, (this.ClientSize.Height - lbl.Height) / 2);

            this.Controls.Add(lbl);
        }
    }
}
