using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StreamSpotter
{
	public partial class ProfileSelectionScreen : Form
	{
		private ArrayList serviceArray = new ArrayList();
		public ProfileSelectionScreen()
		{
			InitializeComponent();
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			NetflixCheckBox.Checked = true;
		}

		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			DisneyCheckBox.Checked = true;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if(NetflixCheckBox.Checked == true)
			{
				serviceArray.Add("netflix");
			}
			if (DisneyCheckBox.Checked == true)
			{
				serviceArray.Add("disney");
			}
			this.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
