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
    public partial class NewInstrType : Form
    {
        public NewInstrType()
        {
            InitializeComponent();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            String Context = "";
            //if select type, add it to SQL
            if (comboBox_InstrType.Text != "")
            {
                foreach (InstType instType in Program.PMC.InstTypes)
                    Context += instType.Typename;
                if (Context.Contains(comboBox_InstrType.Text))
                    MessageBox.Show("This type already exists");
                //if the type is new
                else
                {
                    Program.PMC.InstTypes.Add(new InstType() { Typename = comboBox_InstrType.Text });
                    MessageBox.Show("Add successfully!");
                }
                Program.PMC.SaveChanges();
                this.Dispose();
            }
            else
                MessageBox.Show("Missing inputs");
        }

        private void NewInstrType_Load(object sender, EventArgs e)
        {

        }
    }
}
