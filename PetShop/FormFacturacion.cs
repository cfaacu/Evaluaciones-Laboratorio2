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
    public partial class FormFacturacion : Form
    {
        Stack<Producto> stackProducto;
        double facturacionVenta;
        double facturacionTotal;
        public FormFacturacion()
        {
            InitializeComponent();
        }

        private void FormFacturacion_Load(object sender, EventArgs e)
        {
            foreach (Venta item in DatosSistema.PilaVentas)
            {
                stackProducto = item.Carrito;
                facturacionVenta = DatosSistema.PrecioTotal(stackProducto);
                facturacionTotal += facturacionVenta;
                foreach (Producto items in stackProducto)
                {
                    lstVentas.Items.Add($"Nombre: {items.Nombre}    Precio: {items.Precio}");
                }
                lstVentas.Items.Add(item.DatosCliente());
                lstVentas.Items.Add("");
            }
            lblFacturacion.Text = $"Facturacion Total: {facturacionTotal}";
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
