using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleBrowse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// /this function is called when the user clicks exit in the menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This program was created by Kyle Aisho see more at\r\n" +
                            "www.kyleaisho.com");
        }

        /// <summary>
        /// On click should grab the text from the txtURL and pass it to the browser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGo_Click(object sender, EventArgs e)
        {
            navigate();
        }

        /// <summary>
        /// When enter is pressed click the Go! btn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtURL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)ConsoleKey.Enter)
                navigate();
        }

        /// <summary>
        /// This will provide navigate to the URL listed in the text box
        /// </summary>
        private void navigate()
        {
            lblProgressBar.Text = "Navigation started...";
            txtURL.Enabled = false;
            btnGo.Enabled = false;
            BrowserWindow.Navigate(txtURL.Text);
        }

        /// <summary>
        /// When loading a page elements will be disabled, reenable them here
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BrowserWindow_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            txtURL.Enabled = true;
            btnGo.Enabled = true;
            lblProgressBar.Text = "Complete";
        }

        private void BrowserWindow_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if (e.CurrentProgress > 0 && e.MaximumProgress > 0)
                progressBar.ProgressBar.Value = (int) (e.CurrentProgress * 100 / e.MaximumProgress);
        }
    }
}