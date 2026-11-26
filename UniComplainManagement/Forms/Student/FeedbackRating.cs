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
    public partial class FeedbackRating : Form
    {
        public FeedbackRating()
        {
            InitializeComponent();
        }

        string studentId;
        public FeedbackRating(string studentId)
        {
            this.studentId = studentId;
            InitializeComponent();
        }
    }
}
