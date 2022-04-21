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
using System.Threading;

namespace StreamSpotter
{
	public partial class ProfileSelectionScreen : Form
	{
		private WindowsController winControl = WindowsController.getInstance();
		private ArrayList serviceArray = new ArrayList();
		private ProfileController profileCon;
		private Profile currentProfile;
		private ArrayList buttonList = new ArrayList();
		private string NewName;
		public ProfileSelectionScreen()
		{
			profileCon = winControl.profileController;
			currentProfile = profileCon.GetProfile(profileCon.getCurrentProfile());

			InitializeComponent();
			
			SwitchPanel.Visible = true;
			StreamSelectPanel.Visible = false;
			NewProfilePanel.Visible = false;

			TooManyProfilesLabel.Visible = false;
			ProfileDeletedLabel.Visible = false;
			ProfileSavedLabel.Visible = false;
			ProfileNotCreatedLabel.Visible = false;

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

			updateProfileButtonName();
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
			if (NetflixCheckBox.Checked == true)
			{
				serviceArray.Add("netflix");
			}
			if (DisneyCheckBox.Checked == true)
			{
				serviceArray.Add("disney");
			}
			if (NetflixCheckBox.Checked == false)
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
			ProfileSavedLabel.Visible = false;
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
			ProfileNotCreatedLabel.Visible = false;
			if (profileCon.GetProfile(0) != null)
			{
				currentProfile = profileCon.GetProfile(0);
				winControl.changeCurrentProfile(0);
				winControl.wishlistChanged = false;
				ProfileDeletedLabel.Visible = false;
			}
			else
			{
				ProfileNotCreatedLabel.Visible = true;
			}
			
		}

		private void ExitButton_Click(object sender, EventArgs e)
		{
			winControl.openHomeScreen(this);
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			NameTextBox.Text = "";
			NewProfilePanel.Visible = false;
			SwitchPanel.Visible = true;
		}

		private void NewProfileButton_Click(object sender, EventArgs e)
		{
			ProfileNotCreatedLabel.Visible = false;
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
			if (currentProfile.getID() <= 9)
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
			ProfileSavedLabel.Visible = true;
			profileCon.UpdateProfile(currentProfile);
		}

		public void updateProfileButtonName()
		{
			for (int i = 0; i < buttonList.Count; i++)
			{
				Button temp = (Button)buttonList[i];
				if (profileCon.GetProfile(i) != null)
				{
					Button tempButton = (Button)buttonList[i];
					tempButton.Text = profileCon.GetProfile(i).profileName;
				}
			}
		}

		private void DeleteProfileButton_Click(object sender, EventArgs e)
		{
			ProfileNotCreatedLabel.Visible = false;
			if (currentProfile != null)
			{
				profileCon.RemoveProfile(currentProfile.getID());
				ProfileDeletedLabel.Visible = true;

			}

		}

		private void Profile2_Click(object sender, EventArgs e)
		{
			ProfileNotCreatedLabel.Visible = false;
			//check to see if this profile is in the database and if not show a label saying "Profile not Created"
			if (profileCon.GetProfile(1) != null)
			{
				currentProfile = profileCon.GetProfile(1);
				winControl.changeCurrentProfile(1);
				winControl.wishlistChanged = false;
				ProfileDeletedLabel.Visible = false;
			}
			else
			{
				ProfileNotCreatedLabel.Visible = true;
			}
		}

		private void Profile3_Click(object sender, EventArgs e)
		{
			ProfileNotCreatedLabel.Visible = false;
			if (profileCon.GetProfile(2) != null)
			{
				currentProfile = profileCon.GetProfile(2);
				winControl.changeCurrentProfile(2);
				winControl.wishlistChanged = false;
				ProfileDeletedLabel.Visible = false;
			}
			else
			{
				ProfileNotCreatedLabel.Visible = true;
			}
		}

		private void Profile4_Click(object sender, EventArgs e)
		{
			ProfileNotCreatedLabel.Visible = false;
			if (profileCon.GetProfile(3) != null)
			{
				currentProfile = profileCon.GetProfile(3);
				winControl.changeCurrentProfile(3);
				winControl.wishlistChanged = false;
				ProfileDeletedLabel.Visible = false;
			}
			else
			{
				ProfileNotCreatedLabel.Visible = true;
			}
		}

		private void Profile5_Click(object sender, EventArgs e)
		{
			ProfileNotCreatedLabel.Visible = false;
			if (profileCon.GetProfile(4) != null)
			{
				currentProfile = profileCon.GetProfile(4);
				winControl.changeCurrentProfile(4);
				winControl.wishlistChanged = false;
				ProfileDeletedLabel.Visible = false;
			}
			else
			{
				ProfileNotCreatedLabel.Visible = true;
			}
		}

		private void Profile6_Click(object sender, EventArgs e)
		{
			ProfileNotCreatedLabel.Visible = false;
			if (profileCon.GetProfile(5) != null)
			{
				currentProfile = profileCon.GetProfile(5);
				winControl.changeCurrentProfile(5);
				winControl.wishlistChanged = false;
				ProfileDeletedLabel.Visible = false;
			}
			else
			{
				ProfileNotCreatedLabel.Visible = true;
			}
		}

		private void Profile7_Click(object sender, EventArgs e)
		{
			ProfileNotCreatedLabel.Visible = false;
			if (profileCon.GetProfile(6) != null)
			{
				currentProfile = profileCon.GetProfile(6);
				winControl.changeCurrentProfile(6);
				winControl.wishlistChanged = false;
				ProfileDeletedLabel.Visible = false;
			}
			else
			{
				ProfileNotCreatedLabel.Visible = true;
			}
		}

		private void Profile8_Click(object sender, EventArgs e)
		{
			ProfileNotCreatedLabel.Visible = false;
			if (profileCon.GetProfile(7) != null)
			{
				currentProfile = profileCon.GetProfile(7);
				winControl.changeCurrentProfile(7);
				winControl.wishlistChanged = false;
				ProfileDeletedLabel.Visible = false;
			}
			else
			{
				ProfileNotCreatedLabel.Visible = true;
			}
		}

		private void Profile9_Click(object sender, EventArgs e)
		{
			ProfileNotCreatedLabel.Visible = false;
			if (profileCon.GetProfile(8) != null)
			{
				currentProfile = profileCon.GetProfile(8);
				winControl.changeCurrentProfile(8);
				winControl.wishlistChanged = false;
				ProfileDeletedLabel.Visible = false;
			}
			else
			{
				ProfileNotCreatedLabel.Visible = true;
			}
		}

		private void Profile10_Click(object sender, EventArgs e)
		{
			ProfileNotCreatedLabel.Visible = false;
			if (profileCon.GetProfile(9) != null)
			{
				currentProfile = profileCon.GetProfile(9);
				winControl.changeCurrentProfile(9);
				winControl.wishlistChanged = false;
				ProfileDeletedLabel.Visible = false;
			}
			else
			{
				ProfileNotCreatedLabel.Visible = true;
			}
		}

		private void MyCancelButton_Click(object sender, EventArgs e)
		{
			SwitchPanel.Visible = true;
			StreamSelectPanel.Visible = false;
			NewProfilePanel.Visible = false;
		}

		public void updateServiceBoxes()
		{

		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void label2_Click_1(object sender, EventArgs e)
		{

		}

		public void createNewProfileOnStart()
		{
			NewProfilePanel.Visible = true;
			//add a boolean to check if it is first time starting
			//Then make it so that the user cannot exit until they have created a profile.
		}

		public void updateCheckedBoxes()
		{
			if (currentProfile.getServices() != null)
			{
				for (int i = 0; i < currentProfile.getServices().Count; i++)
				{
					if (currentProfile.getServices()[i] == "netflix")
					{
						NetflixCheckBox.Checked = true;
					}
					else
					{
						NetflixCheckBox.Checked = false;
					}
					if (currentProfile.getServices()[i] == "disney")
					{
						DisneyCheckBox.Checked = true;
					}
					else
					{
						DisneyCheckBox.Checked = false;
					}
				}
			}
		}

		public void updateFormPosition(Form lastForm)
		{
			//lastForm.
		}

		private void SwitchPanel_Paint_1(object sender, PaintEventArgs e)
		{

		}

		private void NewProfilePanel_Paint(object sender, PaintEventArgs e)
		{

		}

		private void ProfileDeletedLabel_Click(object sender, EventArgs e)
		{

		}

		private void serviceButton_Click(object sender, EventArgs e)
		{
			SwitchPanel.Visible = true;
			StreamSelectPanel.Visible = true;
			NewProfilePanel.Visible = false;
			updateCheckedBoxes();
		}
	}
}
