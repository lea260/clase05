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
        private int y = 70;
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
            DataSintoma ds1 = new DataSintoma(1, "tos", 50.0);
            this.list.Add(ds1);
            DataSintoma ds2 = new DataSintoma(2, "gripe", 50.0);
            this.list.Add(ds2);
            cmbsintomas.DataSource = this.list;
            cmbsintomas.ValueMember = "id";
            cmbsintomas.DisplayMember = "sintoma";
            //listo los sintomas;
            foreach (var item in this.list)
            {
                Label lbl1 = new Label();
                lbl1.Width = 46;
                lbl1.Height = 17;
                lbl1.Location = new Point(40,y);
                lbl1.Text = item.Id.ToString();
                lbl1.Name = item.Id.ToString();
                Label lbl2 = new Label();
                lbl2.Width = 46;
                lbl2.Height = 17;
                lbl2.Location = new Point(143, y);
                lbl2.Text = item.Sintoma.ToString();
                lbl2.Name = item.Sintoma.ToString();
                TextBox txt = new TextBox();
                txt.Width = 100;
                txt.Height = 22;
                txt.Location = new Point(300, y);
                txt.Text = item.Coef.ToString();
                txt.Name = item.Coef.ToString();
                txt.TextChanged += new EventHandler((sender1, e1) => Txt_TextChanged(sender1, e1, txt.Text));
                //txt.TextChanged += Txt_TextChanged;
                this.Controls.Add(lbl1);
                this.Controls.Add(lbl2);
                this.Controls.Add(txt);
                this.y += altura;
                //cuadro de ponderacion
                //aumentar la y
            }
        }

        private void Txt_TextChanged(object sender, EventArgs e, string texto)
        {
            //
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
