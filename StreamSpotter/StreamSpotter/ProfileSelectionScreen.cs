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
		private ProfileController profileController = new ProfileController();
		private ArrayList serviceArray = new ArrayList();
		private ProfileController profileCon = new ProfileController();
		private Profile currentProfile = new Profile();
		private string NewName;
		public ProfileSelectionScreen()
		{
			InitializeComponent();
			SwitchPanel.Visible = false;
			NewProfilePanel.Visible = false;
			
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
			if(NetflixCheckBox.Checked == false)
			{
				for (int i = 0; i < serviceArray.Count; i++)
				{
					if (serviceArray[i] == "netflix")
					{
						serviceArray.Remove("netflix");
					}
				}
			}
			if (DisneyCheckBox.Checked == false)
			{
				for (int i = 0; i < serviceArray.Count; i++)
				{
					if (serviceArray[i] == "disney")
					{
						serviceArray.Remove("disney");
					}
				}
			}
			this.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void CreateButton_Click(object sender, EventArgs e)
		{
			
		}

		private void SwitchButton_Click(object sender, EventArgs e)
		{
			
			
		}

		private void Profile1_Click(object sender, EventArgs e)
		{
			StreamSelectPanel.Visible = true;
			SwitchPanel.Visible = false;
		}

		private void SwitchButton_Click_1(object sender, EventArgs e)
		{
			SwitchPanel.Visible = true;
			StreamSelectPanel.Visible = false;
			Profile1.Visible = true;
		}

		private void SwitchPanel_Paint(object sender, PaintEventArgs e)
		{

		}

		private void Profile1_Click_1(object sender, EventArgs e)
		{
		}

		private void ExitButton_Click(object sender, EventArgs e)
		{
			StreamSelectPanel.Visible = true;
			SwitchPanel.Visible = false;
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			NameTextBox.Text = "";
			NewProfilePanel.Visible = false;
			SwitchPanel.Visible = true;
		}

		private void NewProfileButton_Click(object sender, EventArgs e)
		{
			NewProfilePanel.Visible = true;
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void NameTextBox_TextChanged(object sender, EventArgs e)
		{
			NewName = (string)NameTextBox.Text;
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			profileController.CreateProfile(NewName,serviceArray);
			NewProfilePanel.Visible = false;
			SwitchPanel.Visible = true;
			NameTextBox.Text = "";
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			for(int i = 0; i < serviceArray.Count; i++)
			{
				currentProfile.AddService((string)serviceArray[i]);
			}
		}
	}
}
