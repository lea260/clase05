using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Formularios
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (checkrecordar.Checked == true)
            {
                Properties.Settings.Default.UserName = txtuser.Text;
                Properties.Settings.Default.password = txtpassword.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.UserName = "";
                Properties.Settings.Default.password = "";
                Properties.Settings.Default.Save();
            }
            Principal p = new Principal();
            p.Show();
            
            //guardo los datos
            

        }
    }
}
