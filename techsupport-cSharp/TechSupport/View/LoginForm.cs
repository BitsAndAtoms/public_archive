using System;
using System.Windows.Forms;

namespace TechSupport.View
{
    /// <summary>
    /// This class creates the loginForm and allows the user to login
    /// to the main form with valid user name and password after checking
    /// </summary>
    public partial class LoginForm : Form
    {
        private MainDashboard newMainDashboard;
        /// <summary>
        /// constructor of loginForm
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
            this.newMainDashboard = new MainDashboard();
        }

        /// <summary>
        /// error message is removed if user edits the password field
        /// </summary>
        /// <param name="sender"> is the event handler object</param>
        /// <param name="e">e is the event arg</param>
        private void password_TextChanged(object sender, EventArgs e)
        {
            this.messageLabel.Text = "";
        }


        /// <summary>
        ///checks the user name password combination
        ///routes to main form if correct
        ///otherwise displays error message
        /// </summary>
        /// <param name="sender">is the event handler object</param>
        /// <param name="e">is the event arg</param>
        private void loginButton_Click(object sender, EventArgs e)
        {

            if (this.userName.Text == "Jane" && this.password.Text == "test1234")
            {
                this.Hide();
                this.newMainDashboard.setUserNameDisplay(this.userName.Text);
                this.newMainDashboard.ShowDialog();
                this.Show();
            }
            else
            {
                messageLabel.Text = "invalid username/password";
            }
        }

        /// <summary>
        /// resets error message if user changes input field
        /// </summary>
        private void userName_TextChanged(object sender, EventArgs e)
        {
            messageLabel.Text = "";
        }

        /// <summary>
        /// gracefully exits the application on clicking cancel button at top
        /// </summary>
        private void ExitForm(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

    }
}
