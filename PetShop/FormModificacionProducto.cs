using Entidades;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PetShop
{
    public partial class FormModificacionProducto : Form
    {
        string accion;
        public FormModificacionProducto(string accion)
        {
            InitializeComponent();
            this.accion = accion;
        }

        private void FormModificacionProducto_Load(object sender, EventArgs e)
        {
            foreach (Producto item in DatosSistema.listaProductos)
            {
                lstInfo.Items.Add($"Id: {item.MostrarDatos()}");
                lstInfo.Items.Add($"Nombre:{item.MostrarPrecioCant()}");
                lstInfo.Items.Add($"");

                cmbTipo.DataSource = Enum.GetValues(typeof(Enumerados.ETipo));
            }
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            if (accion == "modificar")
            {
                if (int.TryParse(this.txtId.Text, out int id))
                {
                    if (Validaciones.EstaId(id))
                    {
                        for (int i = 0; i < DatosSistema.listaProductos.Count(); i++)
                        {
                            if (DatosSistema.listaProductos[i].Id.Equals(id))
                            {
                                this.btnAceptar.Visible = true;
                                this.lblCantidad.Visible = true;
                                this.lblDescripcion.Visible = true;
                                this.lblNombre.Visible = true;
                                this.lblPrecio.Visible = true;
                                this.lblTipoProducto.Visible = true;
                                this.txtDescripcion.Visible = true;
                                this.txtNombre.Visible = true;
                                this.txtCantidad.Visible = true;
                                this.btnAceptar.Visible = true;
                                this.txtPrecio.Visible = true;
                                this.txtId.ReadOnly = true;
                                this.cmbTipo.Visible = true;
                                this.txtDescripcion.Text = DatosSistema.listaProductos[i].Descripcion;
                                this.txtNombre.Text = DatosSistema.listaProductos[i].Nombre;
                                this.txtCantidad.Text = DatosSistema.listaProductos[i].Cantidad.ToString();
                                this.txtPrecio.Text = DatosSistema.listaProductos[i].Precio.ToString();
                                if (this.cmbTipo.SelectedItem.ToString().Equals(DatosSistema.listaProductos[i].TipoProducto))
                                {
                                    this.cmbTipo.SelectedItem = DatosSistema.listaProductos[i].TipoProducto;
                                }
                                break;
                            }
                        }
                    }
                    else
                    {
                        this.lblError.Visible = true;
                        this.lblError.Text = "Error ID invalido";
                    }
                }
                else
                {
                    this.lblError.Visible = true;
                    this.lblError.Text = "Error ID invalido";
                }
            }
            if (accion == "baja")
            {
                if (int.TryParse(this.txtId.Text, out int idNum))
                {
                    if (DatosSistema.BajaProducto(idNum))
                    {
                        this.Close();
                    }
                    else
                    {
                        this.lblError.Visible = true;
                        this.lblError.Text = "Error ID invalido";
                    }
                }
                else
                {
                    this.lblError.Visible = true;
                    this.lblError.Text = "Error ID invalido";
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (double.TryParse(this.txtPrecio.Text, out double precioNum) && int.TryParse(this.txtCantidad.Text, out int cantidadNum) && int.TryParse(this.txtId.Text, out int idNum))
            {
                if (DatosSistema.ModificarProducto(this.txtNombre.Text, this.txtDescripcion.Text, precioNum, this.cmbTipo.SelectedItem.ToString(), cantidadNum, idNum))
                {
                    this.Close();
                }
            }
        }
    }
}
