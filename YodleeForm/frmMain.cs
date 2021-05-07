using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yodlee;

namespace YodleeForm
{
    public partial class frmMain : Form
    {
        // Temporary values for testing only
        private readonly string TEMP_usersFilePath = @"C:\Users\meadj\Downloads\YodleeWinForms\YodleeWinForms\YodleeForm\Users.txt";
        private readonly int TEMP_fakeDate = -7;

        // Dictionary to store user names/user IDs
        private Dictionary<string, string> userDict = new Dictionary<string, string>();

        private string authToken;
        private User userData;
        private Accounts accountList;
        private Transactions transactionList;

        // Manager objects to access methods
        private TokenManager tokenManager = new TokenManager();
        private UserManager userManager = new UserManager();
        private AccountManager accountManager = new AccountManager();
        private TransactionManager transactionManager = new TransactionManager();

        public frmMain()
        {
            InitializeComponent();
        }

        #region Message boxes (public UI modifications)
        /// <summary>
        /// Generates a pop-up dialog that announces info
        /// </summary>
        /// <param name="msg">Message to display</param>
        /// <param name="caption">Caption/title to display</param>
        public static void msgBoxAnnouncement(string msg, string caption)
        {
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            result = MessageBox.Show(msg, caption, buttons,
                MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

            return;
        }

        /// <summary>
        /// Generates a msgBoxAnnouncement with info about an action being successful/unsuccessful
        /// </summary>
        /// <param name="success">True/false whether the action was successful</param>
        public static void msgBoxSuccessFail(bool success)
        {
            string successMsg;
            string successCaption;

            // Prepares a msgBox to inform the end-user if the changes were successful
            if (success == true)
            {
                successMsg = "The action has been successful!";
                successCaption = "Success!";
            }
            else
            {
                successMsg = "The action has not been successful.";
                successCaption = "Error";
            }

            // Displays a msgBox to inform the end-user if the changes were successful
            frmMain.msgBoxAnnouncement(successMsg, successCaption);
        }

        /// <summary>
        /// Generates a pop-up dialog that asks to confirm a change
        /// </summary>
        /// <param name="msg">Message to display</param>
        /// <param name="caption">Caption/title to display</param>
        /// <returns>Boolean value depending on whether user selects "OK"</returns>
        public static bool msgBoxConfirmChange(string msg, string caption)
        {
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result;

            result = MessageBox.Show(msg, caption, buttons,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.OK)
            {
                return true;
            }
            else return false;
        }
        #endregion

        #region UI modifications
        /// <summary>
        /// Retrieves a list of users from .txt file, converts them into a dictionary
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event argument</param>
        private void YodleeForm_Load(object sender, EventArgs e)
        {
            cboxUserList_LoadUsers();

            // Sets the current date and the date ninety days ago
            var currentDate = DateTime.Now;
            currentDate = currentDate.AddYears(this.TEMP_fakeDate);
            var ninetyDaysAgo = currentDate.AddDays(-90);

            // Sets the DateTimePickers to the established dates
            trsctFromDate.Value = ninetyDaysAgo;
            trsctToDate.Value = currentDate;

            // Disables all buttons until trigger events occur
            btnUpdateUser.Enabled = false;
            btnGetAccounts.Enabled = false;
            btnDeleteUser.Enabled = false;
            btnGetAccountTransactions.Enabled = false;
            btnGetAccountDetails.Enabled = false;
            btnDeleteAccount.Enabled = false;
        }

        /// <summary>
        /// Load list of users to manipulate
        /// </summary>
        private void cboxUserList_LoadUsers()
        {
            string line;

            // Location of the .txt file
            string usersFilePath = this.TEMP_usersFilePath;

            // Reads .txt file into a dictionary with username/user ID string pair
            // Also displays usernames in cboxUserList as selections
            using (StreamReader file = new StreamReader(usersFilePath))
            {
                while ((line = file.ReadLine()) != null)
                {
                    var fields = line.Split(',');
                    userDict.Add(fields[0], fields[1]);
                    cboxUserList.Items.Add(fields[0]);
                }
            }
        }

        /// <summary>
        /// Enables appropriate buttons when a user is selected
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event argument</param>
        private void cboxUserList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Enables btnGetAccounts and btnDeleteUser when a user is selected
            btnUpdateUser.Enabled = true;
            btnGetAccounts.Enabled = true;
            btnDeleteUser.Enabled = true;
        }

        /// <summary>
        /// Clears the grdViewMain and applies relevant changes to the UI
        /// </sum
        /// <summary>
        /// Clears the grdViewMain and applies relevant changes to the UI
        /// </summary>
        private void grdViewMain_Clear()
        {
            // Clears the grdViewMain of all information
            grdViewAccounts.Columns.Clear();

            // Disables btnGetAccountDetails, btnDeleteAccount, and btnGetAccountTransactions
            btnGetAccountDetails.Enabled = false;
            btnDeleteAccount.Enabled = false;
            btnGetAccountTransactions.Enabled = false;
        }
        #endregion

        #region End-user activities
        /// <summary>
        /// Opens a child form to display user info and allow it to be updated
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event argument</param>
        private async void btnUpdateUser_Click(object sender, EventArgs e)
        {
            var userSelected = userDict[cboxUserList.SelectedItem.ToString()];

            // Retrieves user info from the selected user in Yodlee
            await GetUser(userSelected);

            // Prepares a child form to be generated displaying and allowing changes to user info
            frmUpdateUser frmPopUp = new frmUpdateUser(this.authToken, this.userData);
            frmPopUp.Parent = this.Parent;

            // Opens the child form
            var frmData = frmPopUp.ShowDialog();
        }


        /// <summary>
        /// Deletes the selected user
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event argument</param>
        private async void btnDeleteUser_Click(object sender, EventArgs e)
        {
            // Formats a message box to confirm user deletion
            string usernameSelected = cboxUserList.SelectedItem.ToString();
            string msgBoxMsg = "Are you sure that you'd like to delete the user " + "\""
                + usernameSelected + "\"? This action cannot be undone.";
            string msgBoxCaption = "Delete user " + "\"" + usernameSelected + "\"?";

            // Deletes the user if, and only if, the end-user selected "OK" in the msgBox
            if (msgBoxConfirmChange(msgBoxMsg, msgBoxCaption))
            {
                var userSelected = userDict[cboxUserList.SelectedItem.ToString()];

                // Updates the user data and saves the success/failure as a bool
                var success = await DeleteUser(userSelected);

                msgBoxSuccessFail(success);

                grdViewMain_Clear();
            }

            // Deselects currently selected user
            cboxUserList.SelectedIndex = cboxUserList.SelectedIndex - 1;
        }


        /// <summary>
        /// Gets and displays transactions in a given date-range
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event argument</param>
        private async void btnGetAccountTransactions_Click(object sender, EventArgs e)
        {
            var accountSelected = grdViewAccounts.SelectedRows[0].Cells["id"].Value.ToString();

            // Converts start/end dates into formatted strings
            var fromDate = trsctFromDate.Value.ToString("yyyy-MM-dd");
            var toDate = trsctToDate.Value.ToString("yyyy-MM-dd");

            await GetTransactions(accountSelected, fromDate, toDate);

            if (this.transactionList.transaction == null)
            {
                // print error msg
                string msgBoxMsg = "No transactions have been found for the given account and time-range.";
                string msgBoxCaption = "No transactions found";
                msgBoxAnnouncement(msgBoxMsg, msgBoxCaption);
            }
            else
            {
                grdViewAccounts_LoadTransactions(this.transactionList);
            }
        }

        /// <summary>
        /// Displays all transactions associated with a given user in a given date-range
        /// </summary>
        /// <param name="transactionList">List of all of a user's transactions in a given date-range</param>
        private void grdViewAccounts_LoadTransactions(Transactions transactionList)
        {
            // Clears the grdViewAccounts of all information
            grdViewMain_Clear();

            // Adds header columns for grdViewAccounts
            grdViewAccounts.Columns.Add("date", "Date");
            grdViewAccounts.Columns.Add("amount", "Amount");
            grdViewAccounts.Columns.Add("vendor", "Vendor");


            // Pulls summary data for each transaction and adds it to grdViewAccounts
            for (int i = 0; i < transactionList.transaction.Count; i++)
            {
                grdViewAccounts.Rows.Add(
                    transactionList.transaction[i].date,
                    transactionList.transaction[i].amount.amount + " " + transactionList.transaction[i].amount.currency,
                    transactionList.transaction[i].merchant.name
                    );
            }
        }


        /// <summary>
        /// Gets and displays all accounts associated with a given user
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event argument</param>
        private async void btnGetAccounts_Click(object sender, EventArgs e)
        {
            var userSelected = userDict[cboxUserList.SelectedItem.ToString()];

            await GetAccounts(userSelected);

            grdViewAccounts_Load(this.accountList);

            btnGetAccountDetails.Enabled = true;
            btnGetAccountTransactions.Enabled = true;
            btnDeleteAccount.Enabled = true;
        }

        /// <summary>
        /// Displays all accounts associated with a given user in grdViewAccounts
        /// </summary>
        /// <param name="accountList">List of all of a user's accounts</param>
        private void grdViewAccounts_Load(Accounts accountList)
        {
            // Clears the grdViewAccounts of all information
            grdViewMain_Clear();

            // rowID is used to track the initial order of the rows, in case they're sorted by the end-user
            grdViewAccounts.Columns.Add("rowID", "Row ID");
            grdViewAccounts.Columns["rowID"].Visible = false;

            // Adds header columns for grdViewAccounts
            grdViewAccounts.Columns.Add("accountType", "Account Type");
            grdViewAccounts.Columns.Add("accountName", "Account Name");
            grdViewAccounts.Columns.Add("accountStatus", "Account Status");
            grdViewAccounts.Columns.Add("accountNumber", "Account Number");
            grdViewAccounts.Columns.Add("providerName", "Provider Name");
            grdViewAccounts.Columns.Add("id", "ID");

            // Pulls summary data for each account and adds it to UserInfoDisplay
            for (int i = 0; i < accountList.account.Count; i++)
            {
                grdViewAccounts.Rows.Add(
                    i,
                    accountList.account[i].accountType,
                    accountList.account[i].accountName,
                    accountList.account[i].accountStatus,
                    accountList.account[i].accountNumber,
                    accountList.account[i].providerName,
                    accountList.account[i].id
                    );
            }
        }


        /// <summary>
        /// Gets and displays account details associated with a given account
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event argument</param>
        private void btnGetAccountDetails_Click(object sender, EventArgs e)
        {
            // Gets the selected row regardless of row sorting
            var acctRowID = (int)grdViewAccounts.SelectedRows[0].Cells["rowID"].Value;

            // Gets the appropriate account ID in order to retrieve detailed account info
            var account = this.accountList.account[acctRowID];

            grdViewAccounts_LoadDetails(account);

            btnGetAccountTransactions.Enabled = true;
            btnDeleteAccount.Enabled = true;
        }

        /// <summary>
        /// Displays all account details associated with a given account in grdViewAccounts
        /// </summary>
        /// <param name="account">Account to retrieve data from</param>
        private void grdViewAccounts_LoadDetails(Account account)
        {
            // Clears the grdViewAccounts of all information
            grdViewMain_Clear();

            // Adds header columns for grdViewAccounts
            grdViewAccounts.Columns.Add("accountType", "Account Type");
            grdViewAccounts.Columns.Add("accountName", "Account Name");
            grdViewAccounts.Columns.Add("accountStatus", "Account Status");
            grdViewAccounts.Columns.Add("accountNumber", "Account Number");
            grdViewAccounts.Columns.Add("balance", "Balance");
            grdViewAccounts.Columns.Add("lastUpdated", "Last Updated");
            grdViewAccounts.Columns.Add("providerName", "Provider Name");
            grdViewAccounts.Columns.Add("id", "ID");

            // Pulls summary data for each account and adds it to UserInfoDisplay
            grdViewAccounts.Rows.Add(
                account.accountType,
                account.accountName,
                account.accountStatus,
                account.accountNumber,
                account.balance.amount,
                account.lastUpdated,
                account.providerName,
                account.id
                );
        }


        /// <summary>
        /// Deletes the selected account from a user
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event argument</param>
        private async void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            // Formats a message box to confirm user deletion
            string acctNameSelected = grdViewAccounts.SelectedRows[0].Cells["accountName"].Value.ToString();
            string msgBoxMsg = "Are you sure that you'd like to delete the account " + "\""
                + acctNameSelected + "\"? This action cannot be undone.";
            string msgBoxCaption = "Delete account " + "\"" + acctNameSelected + "\"?";

            // Deletes the account if, and only if, the end-user selected "OK" in the msgBox
            if (msgBoxConfirmChange(msgBoxMsg, msgBoxCaption))
            {
                var userSelected = userDict[cboxUserList.SelectedItem.ToString()];

                // Gets the selected accountId
                var accountId = grdViewAccounts.SelectedRows[0].Cells["id"].Value.ToString();

                // Deletes the account and saves the success/failure as a bool
                bool success = await DeleteAccount(userSelected, accountId);

                msgBoxSuccessFail(success);

                // Displays an updated list of the user's accounts
                btnGetAccounts_Click(null, null);
            }
        }
        #endregion

        #region Trigger Yodlee API methods
        /// <summary>
        /// Gets user data
        /// </summary>
        /// <param name="userSelected">User selected by the end-user</param>
        /// <returns></returns>
        private async Task GetUser(string userSelected)
        {
            this.authToken = await tokenManager.CreateAuthToken(userSelected);

            var usersObj = await userManager.GetUser(this.authToken);

            this.userData = usersObj.user;

            return;
        }

        /// <summary>
        /// Deletes a user
        /// </summary>
        /// <param name="userSelected">User selected by the end-user</param>
        /// <returns></returns>
        private async Task<bool> DeleteUser(string userSelected)
        {
            authToken = await tokenManager.CreateAuthToken(userSelected);

            bool success = await userManager.DeleteUser(authToken);

            return success;
        }

        /// <summary>
        /// Generates a list of user's transactions within a date-range
        /// </summary>
        /// <returns>List of user's transactions within a date-range</returns>
        private async Task GetTransactions(string accountSelected, string fromDate, string toDate)
        {
            transactionList = await transactionManager.GetTransactions(this.authToken, accountSelected, fromDate, toDate);

            return;
        }

        /// <summary>
        /// Generates an authorization token and list of user's accounts
        /// </summary>
        /// <param name="userSelected">User selected by end-user</param>
        private async Task GetAccounts(string userSelected)
        {
            this.authToken = await tokenManager.CreateAuthToken(userSelected);

            this.accountList = await accountManager.GetAccounts(this.authToken);

            return;
        }

        /// <summary>
        /// Deletes an account
        /// </summary>
        /// <param name="userSelected">User selected by the end-user</param>
        /// <param name="accountId">Account selected by the end-user</param>
        /// <returns></returns>
        private async Task<bool> DeleteAccount(string userSelected, string accountId)
        {
            authToken = await tokenManager.CreateAuthToken(userSelected);

            bool success = await accountManager.DeleteAccount(authToken, accountId);

            return success;
        }
        #endregion
    }
}
