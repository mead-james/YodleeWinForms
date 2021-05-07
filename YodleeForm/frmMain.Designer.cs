using System;

namespace YodleeForm
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdViewAccounts = new System.Windows.Forms.DataGridView();
            this.cboxUserList = new System.Windows.Forms.ComboBox();
            this.btnGetAccounts = new System.Windows.Forms.Button();
            this.btnGetAccountDetails = new System.Windows.Forms.Button();
            this.btnGetAccountTransactions = new System.Windows.Forms.Button();
            this.trsctFromDate = new System.Windows.Forms.DateTimePicker();
            this.trsctToDate = new System.Windows.Forms.DateTimePicker();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.lblToDate = new System.Windows.Forms.Label();
            this.btnDeleteAccount = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnUpdateUser = new System.Windows.Forms.Button();
            this.lblUsers = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewAccounts)).BeginInit();
            this.SuspendLayout();
            // 
            // grdViewAccounts
            // 
            this.grdViewAccounts.AllowUserToAddRows = false;
            this.grdViewAccounts.AllowUserToDeleteRows = false;
            this.grdViewAccounts.AllowUserToResizeRows = false;
            this.grdViewAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdViewAccounts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdViewAccounts.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdViewAccounts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdViewAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdViewAccounts.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdViewAccounts.Location = new System.Drawing.Point(29, 135);
            this.grdViewAccounts.Margin = new System.Windows.Forms.Padding(2);
            this.grdViewAccounts.MultiSelect = false;
            this.grdViewAccounts.Name = "grdViewAccounts";
            this.grdViewAccounts.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdViewAccounts.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdViewAccounts.RowHeadersVisible = false;
            this.grdViewAccounts.RowHeadersWidth = 62;
            this.grdViewAccounts.RowTemplate.Height = 28;
            this.grdViewAccounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdViewAccounts.Size = new System.Drawing.Size(571, 286);
            this.grdViewAccounts.TabIndex = 0;
            // 
            // cboxUserList
            // 
            this.cboxUserList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxUserList.FormattingEnabled = true;
            this.cboxUserList.Location = new System.Drawing.Point(29, 24);
            this.cboxUserList.Margin = new System.Windows.Forms.Padding(2);
            this.cboxUserList.Name = "cboxUserList";
            this.cboxUserList.Size = new System.Drawing.Size(217, 21);
            this.cboxUserList.TabIndex = 1;
            this.cboxUserList.SelectedIndexChanged += new System.EventHandler(this.cboxUserList_SelectedIndexChanged);
            // 
            // btnGetAccounts
            // 
            this.btnGetAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGetAccounts.Location = new System.Drawing.Point(29, 441);
            this.btnGetAccounts.Margin = new System.Windows.Forms.Padding(2);
            this.btnGetAccounts.Name = "btnGetAccounts";
            this.btnGetAccounts.Size = new System.Drawing.Size(89, 29);
            this.btnGetAccounts.TabIndex = 2;
            this.btnGetAccounts.Text = "View Accounts";
            this.btnGetAccounts.UseVisualStyleBackColor = true;
            this.btnGetAccounts.Click += new System.EventHandler(this.btnGetAccounts_Click);
            // 
            // btnGetAccountDetails
            // 
            this.btnGetAccountDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGetAccountDetails.Location = new System.Drawing.Point(123, 441);
            this.btnGetAccountDetails.Name = "btnGetAccountDetails";
            this.btnGetAccountDetails.Size = new System.Drawing.Size(123, 29);
            this.btnGetAccountDetails.TabIndex = 3;
            this.btnGetAccountDetails.Text = "View Account Details";
            this.btnGetAccountDetails.UseVisualStyleBackColor = true;
            this.btnGetAccountDetails.Click += new System.EventHandler(this.btnGetAccountDetails_Click);
            // 
            // btnGetAccountTransactions
            // 
            this.btnGetAccountTransactions.Location = new System.Drawing.Point(446, 86);
            this.btnGetAccountTransactions.Name = "btnGetAccountTransactions";
            this.btnGetAccountTransactions.Size = new System.Drawing.Size(154, 29);
            this.btnGetAccountTransactions.TabIndex = 4;
            this.btnGetAccountTransactions.Text = "View Account Transactions";
            this.btnGetAccountTransactions.UseVisualStyleBackColor = true;
            this.btnGetAccountTransactions.Click += new System.EventHandler(this.btnGetAccountTransactions_Click);
            // 
            // trsctFromDate
            // 
            this.trsctFromDate.Location = new System.Drawing.Point(338, 25);
            this.trsctFromDate.Name = "trsctFromDate";
            this.trsctFromDate.Size = new System.Drawing.Size(200, 20);
            this.trsctFromDate.TabIndex = 5;
            // 
            // trsctToDate
            // 
            this.trsctToDate.Location = new System.Drawing.Point(338, 51);
            this.trsctToDate.Name = "trsctToDate";
            this.trsctToDate.Size = new System.Drawing.Size(200, 20);
            this.trsctToDate.TabIndex = 6;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(545, 24);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(55, 13);
            this.lblFromDate.TabIndex = 7;
            this.lblFromDate.Text = "Start Date";
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(545, 51);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(52, 13);
            this.lblToDate.TabIndex = 8;
            this.lblToDate.Text = "End Date";
            // 
            // btnDeleteAccount
            // 
            this.btnDeleteAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteAccount.Location = new System.Drawing.Point(252, 441);
            this.btnDeleteAccount.Name = "btnDeleteAccount";
            this.btnDeleteAccount.Size = new System.Drawing.Size(96, 29);
            this.btnDeleteAccount.TabIndex = 9;
            this.btnDeleteAccount.Text = "Delete Account";
            this.btnDeleteAccount.UseVisualStyleBackColor = true;
            this.btnDeleteAccount.Click += new System.EventHandler(this.btnDeleteAccount_Click);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Location = new System.Drawing.Point(169, 85);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(77, 29);
            this.btnDeleteUser.TabIndex = 10;
            this.btnDeleteUser.Text = "Delete User";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnUpdateUser
            // 
            this.btnUpdateUser.Location = new System.Drawing.Point(60, 85);
            this.btnUpdateUser.Name = "btnUpdateUser";
            this.btnUpdateUser.Size = new System.Drawing.Size(103, 29);
            this.btnUpdateUser.TabIndex = 11;
            this.btnUpdateUser.Text = "Update User Info";
            this.btnUpdateUser.UseVisualStyleBackColor = true;
            this.btnUpdateUser.Click += new System.EventHandler(this.btnUpdateUser_Click);
            // 
            // lblUsers
            // 
            this.lblUsers.AutoSize = true;
            this.lblUsers.Location = new System.Drawing.Point(251, 24);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(34, 13);
            this.lblUsers.TabIndex = 12;
            this.lblUsers.Text = "Users";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 487);
            this.Controls.Add(this.lblUsers);
            this.Controls.Add(this.btnUpdateUser);
            this.Controls.Add(this.btnDeleteUser);
            this.Controls.Add(this.btnDeleteAccount);
            this.Controls.Add(this.lblToDate);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.trsctToDate);
            this.Controls.Add(this.trsctFromDate);
            this.Controls.Add(this.btnGetAccountTransactions);
            this.Controls.Add(this.btnGetAccountDetails);
            this.Controls.Add(this.btnGetAccounts);
            this.Controls.Add(this.cboxUserList);
            this.Controls.Add(this.grdViewAccounts);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(645, 526);
            this.Name = "frmMain";
            this.Text = "Yodlee Support App";
            this.Load += new System.EventHandler(this.YodleeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdViewAccounts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdViewAccounts;
        private System.Windows.Forms.ComboBox cboxUserList;
        private System.Windows.Forms.Button btnGetAccounts;
        private System.Windows.Forms.Button btnGetAccountDetails;
        private System.Windows.Forms.Button btnGetAccountTransactions;
        private System.Windows.Forms.DateTimePicker trsctFromDate;
        private System.Windows.Forms.DateTimePicker trsctToDate;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.Button btnDeleteAccount;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnUpdateUser;
        private System.Windows.Forms.Label lblUsers;
    }
}
