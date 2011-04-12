using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IP_stream.AsynchThread
{
	public partial class DualTests : Form {
		public DualTests() {
			InitializeComponent();
		}
		private bool go = false;
		private void RunData() {
		}
        private void DualTests_Load(object sender, EventArgs e)
        {
            RunData();
        }
	}
}