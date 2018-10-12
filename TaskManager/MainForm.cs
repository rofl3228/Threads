using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        private async void TasksAsync(int times)
        {
            int i = 0;
            while (true)
            {
                label1.Text = i.ToString();
                i++;
                Thread.Sleep(1000);
            }
        }
    }
}
