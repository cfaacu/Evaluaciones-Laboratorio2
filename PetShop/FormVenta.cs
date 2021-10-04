using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetShop
{
    public partial class FormVenta : Form
    {
        Venta venta;
        List<Producto> listaProductoAux;
        Stack<Producto> carrito;
        Cliente clienteAux;
        double precioTotal = 0;
        double precio;
        string cuil;
        public FormVenta()
        {
            listaProductoAux = new List<Producto>();
            carrito = new Stack<Producto>();
            InitializeComponent();
        }

        private void FormVenta_Load(object sender, EventArgs e)
        {
            listaProductoAux = DatosSistema.listaProductos.ToList();
            foreach (Cliente item in DatosSistema.listaClientes)
            {
                lstInfo.Items.Add(item.MostrarDatos());
            }
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            if (Validaciones.EstaPersona(this.txtCuil.Text,out clienteAux))
            {
                cuil = txtCuil.Text;
                this.btnContinuar.Visible = false;
                this.lstCarrito.Visible = true;
                this.btnAgregar.Visible = true;
                this.lblTotal.Visible = true;
                this.btnFinalizar.Visible = true;
                this.lstInfo.Items.Clear();

                this.ActualizarLista();

                this.lblCuil.Text = "ID";
                this.btnContinuar.Visible = false;
            }
            else
            {
                this.lblError.Visible = true;
                this.lblError.Text = "Error no existe el cliente";
            }
            this.txtCuil.Text = string.Empty;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int.TryParse(this.txtCuil.Text, out int id);
            if (Validaciones.ValidarCamposProducto(id))
            {
                for (int i = 0; i < listaProductoAux.Count; i++)
                {
                    if (listaProductoAux[i].Id.Equals(id))
                    {
                        if (listaProductoAux[i].Cantidad > 0)
                        {
                            if(clienteAux.Saldo > 0)
                            {
                                carrito.Push(listaProductoAux[i]);
                                listaProductoAux[i].Cantidad -= 1;
                                precioTotal = DatosSistema.PrecioTotal(carrito);
                                if (precioTotal != double.MinValue)
                                {
                                    this.lblTotal.Text = $"Total: {precioTotal}";
                                }
                                this.lstCarrito.Items.Add(listaProductoAux[i].MostrarDatosVenta());                               
                            }
                            else
                            {
                                this.lblError.Visible = true;
                                this.lblError.Text = "Error cliente sin dinero";
                            }
                        }
                        else
                        {
                            this.lblError.Visible = true;
                            this.lblError.Text = "Error no hay mas stock";
                        }
                    }
                }
                ActualizarLista();
            }
            else
            {
                this.lblError.Visible = true;
                this.lblError.Text = "Error ID incorrecto";
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            venta = new Venta(carrito, precioTotal,clienteAux);
            DatosSistema.PilaVentas.Push(venta);
            if(DatosSistema.RestarDineroCliente(cuil,precioTotal))
            {
                Console.Beep();
                this.Close();
                MessageBox.Show("Venta generada con exito");
            }
        }
        private void ActualizarLista()
        {
            lstInfo.Items.Clear();
            foreach (Producto item in listaProductoAux)
            {
                lstInfo.Items.Add(item.MostrarDatos());
                lstInfo.Items.Add(item.MostrarPrecioCant());
                lstInfo.Items.Add($"");
            }
        }
    }
}
