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
        private WindowsController windowsController;
		private Handler handler;

		public ProfileSelectionScreen()
		{
			profileCon = winControl.profileController;
			currentProfile = profileCon.GetProfile(profileCon.getCurrentProfile());
			handler = new Handler();
			handler.profile = profileCon;

			InitializeComponent();
			
			//true
			SwitchPanel.Visible = true;

			//false
			StreamSelectPanel.Visible = false;

			//false
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
			noCurrentProfile();
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
					if ((string)serviceArray[i] == "netflix")
					{
						serviceArray.Remove("netflix");
					}
				}
			}
			if (DisneyCheckBox.Checked == false)
			{
				for (int i = 0; i < serviceArray.Count; i++)
				{
					if ((string)serviceArray[i] == "disney")
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
			noCurrentProfile();
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
				changeSelectedProfileButton(0);
				currentProfile = profileCon.GetProfile(0);
				winControl.changeCurrentProfile(0);
				winControl.wishlistChanged = false;
				ProfileDeletedLabel.Visible = false;
				noCurrentProfile();				
			}
			else
			{
				ProfileNotCreatedLabel.Visible = true;
			}
			
		}

		private void ExitButton_Click(object sender, EventArgs e)
		{
			winControl.currentProfile = currentProfile;
			winControl.openHomeScreen(this);
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			noCurrentProfile();
			NameTextBox.Text = "";
			NewProfilePanel.Visible = false;
			SwitchPanel.Visible = true;
		}

		private void NewProfileButton_Click(object sender, EventArgs e)
		{
			ProfileNotCreatedLabel.Visible = false;
			//StreamSelectPanel.Visible = true;
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
			int oldID = 0;
			if (currentProfile == null)
			{
				currentProfile = new Profile();
			}
			else
			{
				oldID = currentProfile.id;
			}
			if (currentProfile.getID() <= 9)
			{
				if (profileCon.getListIsFull() == false)
                {
					string[] services = new string[serviceArray.Count];
					serviceArray.CopyTo(services);
					TooManyProfilesLabel.Visible = false;
					currentProfile = new Profile(NewName, services, profileCon.getListLength());
					profileCon.setCurrentProfile(currentProfile.getID());
					winControl.currentProfile = currentProfile;
					NewProfilePanel.Visible = false;
					SwitchPanel.Visible = true;
					StreamSelectPanel.Visible = true;
				}
				else
				{
					TooManyProfilesLabel.Visible = true;
				}
				NameTextBox.Text = "";
			}
			noCurrentProfile();
			changeSelectedProfileButton(currentProfile.id, oldID);
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			noCurrentProfile();
			if (NetflixCheckBox.Checked == true)
			{
				if (!serviceArray.Contains("netflix"))
				{
					serviceArray.Add("netflix");
				}
			}
			if (DisneyCheckBox.Checked == true)
			{
				if (!serviceArray.Contains("disney"))
				{
					serviceArray.Add("disney");
				}
			}
			if (NetflixCheckBox.Checked == false)
			{
				for (int i = 0; i < serviceArray.Count; i++)
				{
					if ((string)serviceArray[i] == "netflix")
					{
						serviceArray.Remove("netflix");
					}
				}
				currentProfile.removeService("netflix");
			}
			if (DisneyCheckBox.Checked == false)
			{
				for (int i = 0; i < serviceArray.Count; i++)
				{
					if ((string)serviceArray[i] == "disney")
					{
						serviceArray.Remove("disney");
					}
				}
				currentProfile.removeService("disney");
			}
			for (int i = 0; i < serviceArray.Count; i++)
			{
				currentProfile.AddService((string)serviceArray[i]);
			}
			ProfileSavedLabel.Visible = true;
			string[] services = new string[serviceArray.Count];
			serviceArray.CopyTo(services);
			handler.AddEntry(currentProfile.profileName, services, currentProfile.id);
			profileCon.UpdateProfile(currentProfile);
			updateProfileButtonName();
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
				else
                {
					temp.Text = "empty" + (i + 1);
                }
			}
		}

		private void DeleteProfileButton_Click(object sender, EventArgs e)
		{
			ProfileNotCreatedLabel.Visible = false;
			if (currentProfile != null)
			{
				//profileCon.RemoveProfile(currentProfile.getID());
				ProfileDeletedLabel.Visible = true;
				resetButttonText(currentProfile.id);
				removeSelectedProfileButton(currentProfile.id);

				handler.RemoveEntry(currentProfile.id);
			}
			if (currentProfile.id > 0)
			{
				currentProfile = profileCon.GetProfile(profileCon.currentProfileID - 1);
				profileCon.setCurrentProfile(currentProfile.id);
			}
			else if(profileCon.GetProfile(currentProfile.id + 1) == null)
            {
				currentProfile = null;
            }
            else
            {
				currentProfile = profileCon.GetProfile(profileCon.currentProfileID + 1);
            }

		}

		private void Profile2_Click(object sender, EventArgs e)
		{
			ProfileNotCreatedLabel.Visible = false;
			//check to see if this profile is in the database and if not show a label saying "Profile not Created"
			if (profileCon.GetProfile(1) != null)
			{
				changeSelectedProfileButton(1);
				currentProfile = profileCon.GetProfile(1);
				winControl.changeCurrentProfile(1);
				winControl.wishlistChanged = false;
				ProfileDeletedLabel.Visible = false;
				noCurrentProfile();				
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
				changeSelectedProfileButton(2);
				currentProfile = profileCon.GetProfile(2);
				winControl.changeCurrentProfile(2);
				winControl.wishlistChanged = false;
				ProfileDeletedLabel.Visible = false;
				noCurrentProfile();				
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
				changeSelectedProfileButton(3);
				currentProfile = profileCon.GetProfile(3);
				winControl.changeCurrentProfile(3);
				winControl.wishlistChanged = false;
				ProfileDeletedLabel.Visible = false;
				noCurrentProfile();				
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
				changeSelectedProfileButton(4);
				currentProfile = profileCon.GetProfile(4);
				winControl.changeCurrentProfile(4);
				winControl.wishlistChanged = false;
				ProfileDeletedLabel.Visible = false;
				noCurrentProfile();				
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
				changeSelectedProfileButton(5);
				currentProfile = profileCon.GetProfile(5);
				winControl.changeCurrentProfile(5);
				winControl.wishlistChanged = false;
				ProfileDeletedLabel.Visible = false;
				noCurrentProfile();				
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
				changeSelectedProfileButton(6);
				currentProfile = profileCon.GetProfile(6);
				winControl.changeCurrentProfile(6);
				winControl.wishlistChanged = false;
				ProfileDeletedLabel.Visible = false;
				noCurrentProfile();				
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
				changeSelectedProfileButton(7);
				currentProfile = profileCon.GetProfile(7);
				winControl.changeCurrentProfile(7);
				winControl.wishlistChanged = false;
				ProfileDeletedLabel.Visible = false;
				noCurrentProfile();				
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
				changeSelectedProfileButton(8);
				currentProfile = profileCon.GetProfile(8);
				winControl.changeCurrentProfile(8);
				winControl.wishlistChanged = false;
				ProfileDeletedLabel.Visible = false;
				noCurrentProfile();
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
				changeSelectedProfileButton(9);
				currentProfile = profileCon.GetProfile(9);
				winControl.changeCurrentProfile(9);
				winControl.wishlistChanged = false;
				ProfileDeletedLabel.Visible = false;
				noCurrentProfile();
			}
			else
			{
				ProfileNotCreatedLabel.Visible = true;
			}
		}

		private void MyCancelButton_Click(object sender, EventArgs e)
		{
			noCurrentProfile();
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
				bool netflix = false, disney = false;
				for (int i = 0; i < currentProfile.getServices().Length; i++)
				{
					if (currentProfile.getServices()[i] == "netflix")
					{
						netflix = true;
					}
					if (currentProfile.getServices()[i] == "disney")
					{
						disney = true;
					}
				}
				NetflixCheckBox.Checked = netflix;
				DisneyCheckBox.Checked = disney;
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

		private void noCurrentProfile()
		{
			if(currentProfile == null)
			{
				ExitButton.Enabled = false;
				serviceButton.Enabled = false;
				DeleteProfileButton.Enabled = false;
			}
			else if (currentProfile.services == null || currentProfile.services.Length == 0)
			{
				serviceButton.Enabled = true;
				serviceButton.BackColor = Color.Red;
				DeleteProfileButton.Enabled = true;
				ExitButton.Enabled = false;
				changeSelectedProfileButton(currentProfile.id);
			}
			else
            {
				serviceButton.Enabled = true;
				serviceButton.BackColor = default(Color);
				serviceButton.UseVisualStyleBackColor = true;
				DeleteProfileButton.Enabled = true;
				ExitButton.Enabled = true;
				changeSelectedProfileButton(currentProfile.id);
			}
		}
		private void changeSelectedProfileButton(int selected)
		{
			Button[] buttons = new Button[10];
			buttonList.CopyTo(buttons);
			if (currentProfile != null)
			{
				buttons[currentProfile.getID()].BackColor = default(Color);
				buttons[currentProfile.getID()].UseVisualStyleBackColor = true;
			}
			buttons[selected].BackColor = Color.Green;

		}
		private void changeSelectedProfileButton(int selected, int old)
		{
			Button[] buttons = new Button[10];
			buttonList.CopyTo(buttons);
			buttons[old].BackColor = default(Color);
			buttons[old].UseVisualStyleBackColor = true;
			buttons[selected].BackColor = Color.Green;

		}
		
		private void removeSelectedProfileButton(int selected)
        {
			Button[] buttons = new Button[10];
			buttonList.CopyTo(buttons);
			buttons[selected].BackColor = default(Color);
			buttons[selected].UseVisualStyleBackColor = true;
			updateProfileButtonName();
        }

		private void resetButttonText(int selected)
        {
			Button[] buttons = new Button[10];
			buttonList.CopyTo(buttons);
			buttons[selected].Text = "empty" + (selected + 1);
		}
		private void ProfileSelectionScreen_Load(object sender, EventArgs e)
		{
			formatScreen();
		}

		private void ProfileSelectionScreen_Resize(object sender, EventArgs e)
		{
			formatScreen();
		}

		private void formatScreen()
		{
			SwitchPanel.Width = this.Width;
			SwitchPanel.Height = this.Height;
			//resizes the NewProfile Button
			NewProfileButton.Width = this.Width / 3;
			NewProfileButton.Height = this.Height / 6;

			//changes the location of the newProfile Button
			NewProfileButton.Location = new Point(this.Width / 3, this.Height - NewProfileButton.Height - 70);

			//resizes the delete, exit, and services buttons
			DeleteProfileButton.Width = this.Width / 8;
			DeleteProfileButton.Height = this.Height / 9;

			ExitButton.Width = this.Width / 8;
			ExitButton.Height = this.Height / 9;

			serviceButton.Width = this.Width / 8;
			serviceButton.Height = this.Height / 9;

			//changes the location of delete, exit, and services buttons
			DeleteProfileButton.Location = new Point(20,20);
			ExitButton.Location = new Point(this.Width - ExitButton.Width - 30,20);
			serviceButton.Location = new Point(this.Width - serviceButton.Width - 30, 30 + ExitButton.Height);

			//changes the font size of buttons
			DeleteProfileButton.Font = new Font("Microsoft Sans Serif",
                      DeleteProfileButton.Width/8,
                      System.Drawing.FontStyle.Regular,
                      System.Drawing.GraphicsUnit.Point,
                      ((byte)(0)));

			ExitButton.Font = new Font("Microsoft Sans Serif",
					  ExitButton.Width / 8,
					  System.Drawing.FontStyle.Regular,
					  System.Drawing.GraphicsUnit.Point,
					  ((byte)(0)));

			serviceButton.Font = new Font("Microsoft Sans Serif",
					  serviceButton.Width / 8,
					  System.Drawing.FontStyle.Regular,
					  System.Drawing.GraphicsUnit.Point,
					  ((byte)(0)));

			NewProfileButton.Font = new Font("Microsoft Sans Serif",
					  NewProfileButton.Width / 15,
					  System.Drawing.FontStyle.Regular,
					  System.Drawing.GraphicsUnit.Point,
					  ((byte)(0)));

			//resizes all Profile Buttons
			for (int i =0; i < buttonList.Count; i++)
			{
				Button change = (Button) buttonList[i];
				change.Width = this.Width / 8;
				change.Height = this.Height / 10;
			}

			int ProfilePlaceBegin = DeleteProfileButton.Location.X + DeleteProfileButton.Width;
			int ProfilePlaceEnd = ExitButton.Location.X;
			int spaceBetween = ProfilePlaceEnd - ProfilePlaceBegin;
			int buttonSpace = spaceBetween * (15 / 100);
			int spaceBetweenButtons = spaceBetween * (5/100);

			Profile1.Location = new Point((this.Width / 2) - (Profile3.Width / 2) - (Profile3.Width*2)-15, DeleteProfileButton.Location.Y + DeleteProfileButton.Height + 20);
			Profile2.Location = new Point((this.Width / 2) - (Profile3.Width / 2) - Profile3.Width -10, DeleteProfileButton.Location.Y + DeleteProfileButton.Height + 20);
			Profile3.Location = new Point((this.Width/2) - (Profile3.Width/2) - 5, DeleteProfileButton.Location.Y + DeleteProfileButton.Height + 20);
			Profile4.Location = new Point((this.Width / 2) - (Profile3.Width / 2) + Profile3.Width, DeleteProfileButton.Location.Y + DeleteProfileButton.Height + 20);
			Profile5.Location = new Point((this.Width / 2) - (Profile3.Width / 2) + (Profile3.Width * 2) + 5, DeleteProfileButton.Location.Y + DeleteProfileButton.Height + 20);

			Profile6.Location = new Point(Profile1.Location.X, Profile1.Location.Y + Profile1.Height + 30);
			Profile7.Location = new Point(Profile2.Location.X, Profile2.Location.Y + Profile2.Height + 30);
			Profile8.Location = new Point(Profile3.Location.X, Profile3.Location.Y + Profile3.Height + 30);
			Profile9.Location = new Point(Profile4.Location.X, Profile4.Location.Y + Profile4.Height + 30);
			Profile10.Location = new Point(Profile5.Location.X, Profile5.Location.Y + Profile5.Height + 30);

			ProfileNotCreatedLabel.Width = this.Width / 3;
			ProfileNotCreatedLabel.Height = this.Height / 20;
			ProfileNotCreatedLabel.Location = new Point((this.Width / 2 - ProfileNotCreatedLabel.Width / 2) -15 , 40);

			ProfileNotCreatedLabel.Font = new Font("Microsoft Sans Serif",
					  ProfileNotCreatedLabel.Width / 30,
					  System.Drawing.FontStyle.Regular,
					  System.Drawing.GraphicsUnit.Point,
					  ((byte)(0)));


			ProfileDeletedLabel.Location = new Point((this.Width / 2 - ProfileDeletedLabel.Width / 2) - 15, 40);

			//Mid Panel

			StreamSelectPanel.Width = this.Width;
			StreamSelectPanel.Height = this.Height;

			//SwitchButton
			SwitchButton.Width = this.Width / 5;
			SwitchButton.Height = this.Height / 15;
			SwitchButton.Location = new Point(this.Width - SwitchButton.Width - 30, 20);

			SwitchButton.Font = new Font("Microsoft Sans Serif",
					  SwitchButton.Width / 14,
					  System.Drawing.FontStyle.Regular,
					  System.Drawing.GraphicsUnit.Point,
					  ((byte)(0)));

			//NetflixCheckedBox
			NetflixCheckBox.Width = this.Width / 4;
			NetflixCheckBox.Height = this.Height / 8;
			NetflixCheckBox.Location = new Point((this.Width / 2) - NetflixCheckBox.Width - 30, this.Height / 2 - 75);


			//DisneyCheckedBox
			DisneyCheckBox.Width = this.Width / 4;
			DisneyCheckBox.Height = this.Height / 8;
			DisneyCheckBox.Location = new Point((this.Width / 2) + 30, this.Height / 2 - 75);

			//saveButton
			SaveButton.Width = this.Width / 8;
			SaveButton.Height = this.Height / 12;
			SaveButton.Location = new Point((this.Width / 2) - SaveButton.Width - 30, this.Height -200);

			SaveButton.Font = new Font("Microsoft Sans Serif",
					  SaveButton.Width / 8,
					  System.Drawing.FontStyle.Regular,
					  System.Drawing.GraphicsUnit.Point,
					  ((byte)(0)));

			//CancelButton
			MyCancelButton.Width = this.Width/8;
			MyCancelButton.Height = this.Height / 12;
			MyCancelButton.Location = new Point((this.Width / 2) + 10, this.Height - 200);

			MyCancelButton.Font = new Font("Microsoft Sans Serif",
					  MyCancelButton.Width / 8,
					  System.Drawing.FontStyle.Regular,
					  System.Drawing.GraphicsUnit.Point,
					  ((byte)(0)));

			//ProfileSavedLabel
			ProfileSavedLabel.Location = new Point(this.Width/2 - ProfileSavedLabel.Width/2 - 12, this.Height/2);

			ProfileSavedLabel.Font = new Font("Microsoft Sans Serif",
					  ProfileSavedLabel.Width / 15,
					  System.Drawing.FontStyle.Regular,
					  System.Drawing.GraphicsUnit.Point,
					  ((byte)(0)));

			//Top Panel
			NewProfilePanel.Width = this.Width;
			NewProfilePanel.Height = this.Height;

			//saveNewProfileButton
			SaveNewProfileButton.Width = this.Width / 6;
			SaveNewProfileButton.Height = this.Height / 12;
			SaveNewProfileButton.Location = new Point((this.Width / 2) - SaveNewProfileButton.Width - 30, this.Height - 200);

			//CancelButton
			CancelButton.Width = this.Width / 6;
			CancelButton.Height = this.Height / 12;
			CancelButton.Location = new Point((this.Width / 2) + 30, this.Height - 200);

			//chooseLabel
			
			label1.Location = new Point(this.Width / 2 - label1.Width / 2, this.Height / 2);

			//TooManyProfilesLabel
			TooManyProfilesLabel.Location = new Point(this.Width / 2 - TooManyProfilesLabel.Width / 2, (this.Height / 20) * 9);

			//NameTextBox
			NameTextBox.Width = this.Width / 3;
			NameTextBox.Height = this.Height / 12;
			NameTextBox.Location = new Point(this.Width / 2 - NameTextBox.Width / 2, this.Height / 3);

			//ProfileNameLabel
			ProfileNameLabel.Location = new Point(this.Width / 2 - NameTextBox.Width / 2, NameTextBox.Location.Y - 30);




		}

        private void undoButton_Click(object sender, EventArgs e)
        {
			handler.Undo();
			updateProfileButtonName();
			noCurrentProfile();
		}

        private void redoButton_Click(object sender, EventArgs e)
        {
			handler.Redo();
			updateProfileButtonName();
			noCurrentProfile();
		}
    }
}
