using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Portfolio
{
    public partial class RateAnalysis : Form
    {
        public RateAnalysis()
        {
            InitializeComponent();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void RateAnalysis_Load(object sender, EventArgs e)
        {
            //refresh database
            var query = from i in Program.PMC.InterestRates select i;
            List<InterestRate> Rate = new List<InterestRate>();
            foreach (var i in query)
                Rate.Add(i);
            dataGridView1.DataSource = Rate;
            dataGridView1.Columns[0].Visible = false;
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.ContextMenuStrip.Show(this.dataGridView1, e.Location);
                ContextMenuStrip.Show(Cursor.Position);
            }
        }
    }
}
