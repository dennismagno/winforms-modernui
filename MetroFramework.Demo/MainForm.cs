using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

using MetroFramework.Forms;
using System.Data;

namespace MetroFramework.Demo
{
    public partial class MainForm : MetroForm
    {
        public MainForm()
        {
            InitializeComponent();

            DataTable _table = new DataTable();
            _table.ReadXml(Application.StartupPath + @"\Data\Books.xml");
            metroGrid1.DataSource = _table;

            metroGrid1.Font = new Font("Segoe UI", 11f, FontStyle.Regular, GraphicsUnit.Pixel);
            metroGrid1.AllowUserToAddRows = false;
        }

        private void metroTileSwitch_Click(object sender, EventArgs e)
        {
            var m = new Random();
            int next = m.Next(0, 13);
            metroStyleManager.Style = (MetroColorStyle)next;
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            metroStyleManager.Theme = metroStyleManager.Theme == MetroThemeStyle.Light ? MetroThemeStyle.Dark : MetroThemeStyle.Light;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            MetroTaskWindow.ShowTaskWindow(this,"SubControl in TaskWindow", new TaskWindowControl(), 10);
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "Do you like this metro message box?", "Metro Title", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            metroContextMenu1.Show(metroButton5, new Point(0, metroButton5.Height));
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "This is a sample MetroMessagebox `OK` only button", "MetroMessagebox", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void metroButton10_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "This is a sample MetroMessagebox `OK` and `Cancel` button", "MetroMessagebox", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "This is a sample MetroMessagebox `Yes` and `No` button", "MetroMessagebox", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "This is a sample MetroMessagebox `Yes`, `No` and `Cancel` button", "MetroMessagebox", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }

        private void metroButton11_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "This is a sample MetroMessagebox `Retry` and `Cancel` button.  With warning style.", "MetroMessagebox", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
        }

        private void metroButton9_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "This is a sample MetroMessagebox `Abort`, `Retry` and `Ignore` button.  With Error style.", "MetroMessagebox", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
        }

        private void metroButton12_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "This is a sample `default` MetroMessagebox ", "MetroMessagebox");
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            metroTextBox2.Focus();
        }

       
    }
}
