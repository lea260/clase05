using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio.Objetos;

namespace Presentacion.Formularios
{
    public partial class Form2 : Form
    {
        private int y = 73;
        const int altura = 50;
        List<DataSintoma> list;
        private int indice = -1;
        public Form2()
        {
            InitializeComponent();
            Initcombox();
        }

        private void Initcombox()
        {
            this.list = new List<DataSintoma>();
            DataSintoma ds1 = new DataSintoma(1, "tos");
            this.list.Add(ds1);
            DataSintoma ds2 = new DataSintoma(2, "gripe");
            this.list.Add(ds2);
            cmbsintomas.DataSource = this.list;
            cmbsintomas.ValueMember = "id";
            cmbsintomas.DisplayMember = "sintoma";
            //listo los sintomas;
            foreach (var item in this.list)
            {
                TextBox txt = new TextBox();
                txt.Width = 46;
                txt.Height = 17;
                txt.Location = new Point(40,y);
                txt.Text = item.Id.ToString();
                txt.Name = item.Id.ToString();
                TextBox txt2 = new TextBox();
                txt.Width = 46;
                txt.Height = 17;
                txt.Location = new Point(40, y);
                txt.Text = item.Id.ToString();
                txt.Name = item.Id.ToString();
                this.Controls.Add(txt);
                //cuadro de ponderacion
                //aumentar la y
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //int indice = cmbsintomas.SelectedIndex;
            if (this.indice != -1)
            {
                long id = this.list[this.indice].Id;
                string sintoma = this.list[this.indice].Sintoma;
                MessageBox.Show("id:" + id + " el sintoma es: " + sintoma);
            }


            //List<>
        }

        private void cmbsintomas_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.indice = cmbsintomas.SelectedIndex;
            

        }
    }
}
