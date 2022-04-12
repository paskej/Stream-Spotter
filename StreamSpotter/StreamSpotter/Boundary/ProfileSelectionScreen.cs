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
		private WindowsController winControl = new WindowsController();
		private ProfileController profileCon;
		private ArrayList serviceArray = new ArrayList();
		private Profile currentProfile = null;
		private ArrayList buttonList = new ArrayList();
		private string NewName;
		public ProfileSelectionScreen()
		{
			profileCon = winControl.profileController;
			InitializeComponent();
			SwitchPanel.Visible = false;
			NewProfilePanel.Visible = false;
			TooManyProfilesLabel.Visible = false;
			ProfileDeletedLabel.Visible = false;

			Profile1.Visible = true;
			Profile2.Visible = true;
			Profile3.Visible = true;
			Profile4.Visible = true;
			Profile5.Visible = true;
			Profile6.Visible = true;
			Profile7.Visible = true;
			Profile8.Visible = true;
			Profile9.Visible = true;
			Profile10.Visible = true;

			buttonList.Add(Profile1);
			buttonList.Add(Profile2);
			buttonList.Add(Profile3);
			buttonList.Add(Profile4);
			buttonList.Add(Profile5);
			buttonList.Add(Profile6);
			buttonList.Add(Profile7);
			buttonList.Add(Profile8);
			buttonList.Add(Profile9);
			buttonList.Add(Profile10);

			
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
			updateProfileButtonName();
			SwitchPanel.Visible = true;
			StreamSelectPanel.Visible = false;
			Profile1.Visible = true;
		}

		private void SwitchPanel_Paint(object sender, PaintEventArgs e)
		{

		}

		private void Profile1_Click_1(object sender, EventArgs e)
		{
			currentProfile = profileCon.GetProfile(0);
			ProfileDeletedLabel.Visible = false;
		}

		private void ExitButton_Click(object sender, EventArgs e)
		{
			StreamSelectPanel.Visible = true;
			SwitchPanel.Visible = false;
			ProfileDeletedLabel.Visible = false;
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
			ProfileDeletedLabel.Visible = false;
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
			if (currentProfile == null)
			{
				currentProfile = new Profile();
			}
			if (currentProfile.getID() < 9)
			{
				if (profileCon.getListIsFull() == false)
				{
					TooManyProfilesLabel.Visible = false;
					currentProfile = profileCon.CreateProfile(NewName, serviceArray);
					NewProfilePanel.Visible = false;
					SwitchPanel.Visible = true;
				}
				else
				{
					TooManyProfilesLabel.Visible = true;
				}
				NameTextBox.Text = "";
				updateProfileButtonName();
			}
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
				for (int i = 0; i < serviceArray.Count; i++)
				{
					currentProfile.AddService((string)serviceArray[i]);
				}
			this.Close();
			
		}

		public void updateProfileButtonName()
		{
			for (int i = 0; i < buttonList.Count; i++)
			{
				Button temp = (Button)buttonList[i];
				if(profileCon.GetProfile(i) != null)
				{
					Button tempButton = (Button)buttonList[i];
					tempButton.Text = profileCon.GetProfile(i).profileName;
				}
			}
		}

		private void DeleteProfileButton_Click(object sender, EventArgs e)
		{
			if (currentProfile != null)
			{
				profileCon.RemoveProfile(currentProfile.getID());
				ProfileDeletedLabel.Visible = true;
				
			}

		}

		private void Profile2_Click(object sender, EventArgs e)
		{
			currentProfile = profileCon.GetProfile(1);
			ProfileDeletedLabel.Visible = false;
		}

		private void Profile3_Click(object sender, EventArgs e)
		{
			currentProfile = profileCon.GetProfile(2);
			ProfileDeletedLabel.Visible = false;
		}

		private void Profile4_Click(object sender, EventArgs e)
		{
			currentProfile = profileCon.GetProfile(3);
			ProfileDeletedLabel.Visible = false;
		}

		private void Profile5_Click(object sender, EventArgs e)
		{
			currentProfile = profileCon.GetProfile(4);
			ProfileDeletedLabel.Visible = false;
		}

		private void Profile6_Click(object sender, EventArgs e)
		{
			currentProfile = profileCon.GetProfile(5);
			ProfileDeletedLabel.Visible = false;
		}

		private void Profile7_Click(object sender, EventArgs e)
		{
			currentProfile = profileCon.GetProfile(6);
			ProfileDeletedLabel.Visible = false;
		}

		private void Profile8_Click(object sender, EventArgs e)
		{
			currentProfile = profileCon.GetProfile(7);
			ProfileDeletedLabel.Visible = false;
		}

		private void Profile9_Click(object sender, EventArgs e)
		{
			currentProfile = profileCon.GetProfile(8);
			ProfileDeletedLabel.Visible = false;
		}

		private void Profile10_Click(object sender, EventArgs e)
		{
			currentProfile = profileCon.GetProfile(9);
			ProfileDeletedLabel.Visible = false;
		}

		private void NewProfilePanel_Paint(object sender, PaintEventArgs e)
		{
		}

		public Panel getNewProfilePanel()
		{
			return NewProfilePanel;
		}

		private void MyCancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void updateCheckBoxes()
		{
			NetflixCheckBox.Checked = false;
			DisneyCheckBox.Checked = false;

			Profile current = profileCon.GetProfile(profileCon.getCurrentProfile());
			ArrayList proServices = current.getServices();

			for(int i = 0; i < proServices.Count; i++)
			{
				if(proServices[i] == "netflix")
				{
					NetflixCheckBox.Checked = true;
				}
				if(proServices[i] == "disney")
				{
					DisneyCheckBox.Checked = true;
				}
			}
		}

		private void StreamSelectPanel_Paint(object sender, PaintEventArgs e)
		{
			this.updateCheckBoxes();
		}
	}
}
