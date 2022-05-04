using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gc_proj_2 {
	public partial class NewProjectForm : Form {
		private int projectWidth, projectHeight;

		public int ProjectWidth {
			get { return projectWidth; }
		}

		public int ProjectHeight {
			get { return projectHeight; }
		}

		private void numericHeight_ValueChanged (object sender, EventArgs e) {
			projectHeight = (int) (sender as NumericUpDown).Value;
		}

		private void numericWidth_ValueChanged (object sender, EventArgs e) {
			projectWidth = (int) (sender as NumericUpDown).Value;
		}

		private void buttonCreate_Click (object sender, EventArgs e) {
			DialogResult = DialogResult.OK;
			Close ();
		}

		public NewProjectForm () {
			projectWidth = projectHeight = 320;
			InitializeComponent ();
		}
	}
}
