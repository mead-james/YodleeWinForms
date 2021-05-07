using System;
using System.Windows.Forms;
using Yodlee;

namespace YodleeForm
{
    public partial class frmUpdateUser : Form
    {
        private string authToken;
        private User userData;

        // Manager object to access methods
        private UserManager userManager = new UserManager();

        public frmUpdateUser(string authToken, User userData)
        {
            InitializeComponent();

            this.authToken = authToken;
            this.userData = userData;

            setTxtBoxes();
        }

        /// <summary>
        /// Upon confirmation, replaces user data from Yodlee with user inputted text
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event argument</param>
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            string msgBoxMsg = "Are you sure that you'd like to update this user's information?";
            string msgBoxCaption = "Update user?";

            // Verifies that the end-user intends to change user data from Yodlee
            if (frmMain.msgBoxConfirmChange(msgBoxMsg, msgBoxCaption))
            {
                setUserInfo();

                // Creates a "Users" container to change the user data with Yodlee
                Users userObj = new Users();
                userObj.user = userData;

                // Updates the user data and saves the success/failure as a bool
                bool success = await userManager.UpdateUser(this.authToken, userObj);

                frmMain.msgBoxSuccessFail(success);
            }
        }

        /// <summary>
        /// Displays current user info in the form text boxes
        /// </summary>
        private void setTxtBoxes()
        {
            if (userData.name != null)
            {
                if (userData.name.first != null)
                {
                    txtFirstName.Text = userData.name.first;
                }
                if (userData.name.last != null)
                {
                    txtLastName.Text = userData.name.last;
                }
            }
            if (userData.address != null)
            {
                if (userData.address.address1 != null)
                {
                    txtAddress.Text = userData.address.address1;
                }
                if (userData.address.state != null)
                {
                    txtState.Text = userData.address.state;
                }
                if (userData.address.city != null)
                {
                    txtCity.Text = userData.address.city;
                }
                if (userData.address.zip != 0)
                {
                    txtZip.Text = userData.address.zip.ToString();
                }

                if (userData.address.country != null)
                {
                    txtCountry.Text = userData.address.country;
                }
            }
            if (userData.email != null)
            {
                txtEmail.Text = userData.email;
            }
        }

        /// <summary>
        /// Replaces data in "userData" with user inputted text
        /// </summary>
        private void setUserInfo()
        {
            // Creates a Name obj for userData if it didn't already exist
            if (this.userData.name == null)
            {
                this.userData.name = new Name();
            }

            // Creates an Address obj for userData if it didn't already exist
            if (this.userData.address == null)
            {
                this.userData.address = new Address();
            }

            // Changes fields in userData based on user input to the form
            this.userData.name.first = txtFirstName.Text;
            this.userData.name.last = txtLastName.Text;
            this.userData.address.address1 = txtAddress.Text;
            this.userData.address.state = txtState.Text;
            this.userData.address.country = txtCountry.Text;
            int newZip;
            int.TryParse(txtZip.Text, out newZip);
            this.userData.address.zip = newZip;
            this.userData.address.city = txtCity.Text;
            this.userData.email = txtEmail.Text;
        }
    }
}
