using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blackjack
{
    public partial class InputName : Form
    {
        private MainForm mainForm;
        public string InputResult { get; set; }

        public InputName(MainForm _mainForm)
        {
            this.mainForm = _mainForm;
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InputResult = textBox1.Text;
            DialogResult = DialogResult.OK;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
