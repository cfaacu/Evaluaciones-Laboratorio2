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
    public partial class FormAltaProducto : Form
    {
        public FormAltaProducto()
        {
            InitializeComponent();
        }

        private void FormAltaProducto_Load(object sender, EventArgs e)
        {
            foreach (Producto item in DatosSistema.listaProductos)
            {
                cmbTipo.DataSource = Enum.GetValues(typeof(Enumerados.ETipo));
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(double.TryParse(this.txtPrecio.Text, out double precio) && int.TryParse(this.txtCantidad.Text, out int cantidad))
            {
                if (DatosSistema.AltaProducto(this.txtNombre.Text, this.txtDescripcion.Text, precio, this.cmbTipo.SelectedItem.ToString(), cantidad))
                {
                    this.Close();
                }
                else
                {
                    this.lblError.Visible = true;
                    this.lblError.Text = "Error datos incorrectos";
                }
            }
            else
            {
                this.lblError.Visible = true;
                this.lblError.Text = "Error datos incorrectos";
            }
        }
    }
}
