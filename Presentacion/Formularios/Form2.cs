using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Negocio.Objetos;

namespace Presentacion.Formularios
{
    public partial class Form2 : Form
    {
        public void Hola()
        {

        }
        private int v = 0;
        private int y = 70;      
        const int altura = 50;
        //lista sintomas de la enfermedad
        List<DataSintoma> list;
        //lista de todos los sintomas.
        List<DataSintoma> listasintomas;
        private int indice = -1;
        public Form2()
        {
            InitializeComponent();
            Initcombox();
        }

        private void Initcombox()
        {
            
            DataSintoma ds1 = new DataSintoma(1, "tos", 40.0);            
            DataSintoma ds2 = new DataSintoma(2, "gripe", 30.0);                       
            DataSintoma ds3 = new DataSintoma(3, "malestar", 20.0);
            this.listasintomas = new List<DataSintoma>();            
            this.listasintomas.Add(ds1);
            this.listasintomas.Add(ds2);
            this.listasintomas.Add(ds3);
            this.list = new List<DataSintoma>();
            this.list.Add(ds1);            
            this.list.Add(ds2);            
            cmbsintomas.DataSource = this.listasintomas;
            cmbsintomas.ValueMember = "id";
            cmbsintomas.DisplayMember = "sintoma";
            //listo los sintomas;
            ListarSintomas();

        }

        //eliminar por nombre
        private void EliminarSintomas()
        {
            foreach (Control c in this.Controls.OfType<TextBox>())
            {
                try
                {
                    this.Controls.Remove(c);
                    /*if (c.Tag!= null)
                    {
                        int tag = (int)c.Tag;
                        if (tag == 1 || tag == 0)
                        {
                            this.Controls.Remove(c);
                            c.Dispose();
                            //break;
                        }
                    }*/

                }
                catch (Exception ex)
                {

                    throw;
                }   
            }

            foreach (Control c in this.Controls.OfType<Label>())
            {
                try
                {
                    this.Controls.Remove(c);
                    /*if (c.Tag != null)
                    {
                        int tag = (int)c.Tag;
                        if (tag == 1 || tag == 0)
                        {
                            this.Controls.Remove(c);
                            c.Dispose();
                            //break;
                        }
                    }*/

                }
                catch (Exception ex)
                {

                    throw;
                }
            }


        }
    /*private void EliminarSintomas()
        {
            foreach (Control item in Controls)
            {
                List<string> laux = this.listasintomas.Select(o=> o.Id.ToString()).ToList();
                if (laux.Contains(item.Name))
                {
                    Controls.Remove(item);
                    item.Dispose();
                }
                List<string> laux2 = this.listasintomas.Select(o => o.Sintoma.ToString()).ToList();
                if (laux2.Contains(item.Name))
                {
                    Controls.Remove(item);
                    item.Dispose();
                }
                List<string> laux3 = this.listasintomas.Select(o => o.Coef.ToString()).ToList();
                if (laux3.Contains(item.Name))
                {
                    Controls.Remove(item);
                    item.Dispose();
                }

            }
        }*/

        private void ListarSintomas()
        {
            foreach (var item in this.list)
            {

                Label lbl1 = new Label();
                lbl1.Width = 46;
                lbl1.Height = 17;
                lbl1.Location = new Point(40, y);
                lbl1.Text = item.Id.ToString();
                lbl1.Name = item.Id.ToString();
                lbl1.Tag = this.v;
                Label lbl2 = new Label();
                lbl2.Width = 46;
                lbl2.Height = 17;
                lbl2.Location = new Point(143, y);
                lbl2.Text = item.Sintoma.ToString();
                lbl2.Name = item.Sintoma.ToString();
                lbl2.Tag = this.v;
                TextBox txt1 = new TextBox();
                txt1.Width = 100;
                txt1.Height = 22;
                txt1.Location = new Point(300, y);
                txt1.Text = item.Coef.ToString();
                txt1.Name = item.Coef.ToString();
                txt1.Tag = this.v;
                txt1.TextChanged += new EventHandler((sender1, e1) => Txt_TextChanged(sender1, e1, txt1.Text, item.Id));
                
                //txt.TextChanged += Txt_TextChanged;
                this.Controls.Add(lbl1);
                this.Controls.Add(lbl2);
                this.Controls.Add(txt1);
                //cuadro de ponderacion
                //aumentar la y
                this.y += altura;
                this.v++;
            }
        }

        



        private void Txt_TextChanged(object sender, EventArgs e, string coef, long id)
        {
            //            
            //this.list.Find(x => x.Id == id);
            bool encontrado = false;
            int cantidad = this.list.Count;
            int iter = 0;
            while (!encontrado)
            {
                if (this.list[iter].Id==id)
                {
                    encontrado = true;
                    this.list[iter].Coef = double.Parse (coef); 
                }
                iter++;
            }            
            //this.list[indice].Coef = coef;

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

        private void btnelim_Click(object sender, EventArgs e)
        {
            EliminarSintomas();
        }
    }
}
