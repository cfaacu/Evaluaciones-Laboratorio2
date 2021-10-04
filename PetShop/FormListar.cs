using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetShop
{
    public partial class FormListar : Form
    {
        Enumerados.ERango rango;
        Cliente clienteAux;
        double mayorSaldo;
        public FormListar(Enumerados.ERango rango)
        {
            InitializeComponent();
            this.rango = rango;
        }

        private void FormListar_Load(object sender, EventArgs e)
        {
            if(rango == Enumerados.ERango.cliente)
            {
                foreach (Cliente item in DatosSistema.listaClientes)
                {
                    lstListar.Items.Add(item.MostrarDatos());
                }
                mayorSaldo = (double)clienteAux;
                this.lblClienteMasSaldo.Visible = true;
                this.lblClienteMasSaldo.Text = $"El cliente con mayor saldo tiene: {mayorSaldo}";
            }
            if(rango == Enumerados.ERango.administrador)
            {
                foreach (Empleado item in DatosSistema.listaEmpleados)
                {
                    if(item.GetType() == typeof(Administrador))
                    {
                        lstListar.Items.Add(item.MostrarDatos());
                    }
                }
            }
            if (rango == Enumerados.ERango.empleado)
            {
                foreach (Empleado item in DatosSistema.listaEmpleados)
                {
                    if(item.GetType() == typeof(Empleado))
                    {
                        lstListar.Items.Add(item.MostrarDatos());
                    }
                }
            }
            if (rango == Enumerados.ERango.producto)
            {
                foreach (Producto item in DatosSistema.listaProductos)
                {
                    lstListar.Items.Add(item.MostrarDatos());
                    lstListar.Items.Add(item.MostrarPrecioCant());
                    lstListar.Items.Add("");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
