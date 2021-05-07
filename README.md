# Introduction
A support application in Windows Forms that connects to the Yodlee API using C#.

It allows the user to perform the following tasks through the Yodlee API (https://developer.yodlee.com/api-reference):

a.	View user’s accounts – input is the user

b.	Delete user – input is the user

c.  Update user info - inputs are the user and a short list of changeable parameters (first name, last name, ZIP code...)

d.	View user’s account details – inputs are the user and an account

e.	Delete account – inputs are the user and account

f.	View account’s transactions – inputs are the user, an account, and a date range

# Modifications for testing/production
The current application relies on a list of user names/user IDs written in a .txt file (Users.txt). The values in that file are placeholders that would be replaced by test users from a Yodlee developer account.

In frmMain.cs, lines 13 and 14 are values set for testing purposes. Line 13 provides the location of the Users.txt file (will change depend on where the project is stored), and line 14 modifies the date-range to default seven years ago (2014, as of when this application was designed). This is because Yodlee stores its transactions for test-users around 2014, so no transactions will display for test users unless you request them around that year.

# Credits
This project was developed by James Mead, Zachary Dean, and Kevin Liu as part of CSIT 425/Software Engineering at SUNY Fredonia. It was overseen by Jim Glidden, Dean Wagner, and Andrea Brown of Paychex, and Prof. Denise Joy of SUNY Fredonia.
