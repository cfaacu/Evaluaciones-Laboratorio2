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
    public partial class FormMenuPrincipal : Form
    {
        private Form formActivo = null;
        FormAlta formAlta;
        FormModificacion formModificacion;
        FormAltaProducto formAltaProducto;
        FormModificacionProducto formModificacionProducto;
        FormFacturacion formFacturacion;
        FormVenta formVenta;
        FormListar formListar;
        Empleado empleado;
        public FormMenuPrincipal(Empleado empleado)
        {
            InitializeComponent();
            this.empleado = empleado;
            PersonalizarDisenio();
        }
        private void FormMenuPrincipal_Load(object sender, EventArgs e)
        {
            if(empleado.GetType() == typeof(Empleado))
            {
                this.panelFormHijo.BackColor = Color.Black;
                this.btnAltaAdministrador.Enabled = false;
                this.btnAltaEmpleado.Enabled = false;
                this.btnBajaAdministrador.Enabled = false;
                this.btnBajaEmpleado.Enabled = false;
                this.btnModificarAdministrador.Enabled = false;
                this.btnModificarEmpleado.Enabled = false;
                this.btnFacturacion.Enabled = false;
            }
        }

        private void btnAltaCliente_Click(object sender, EventArgs e)
        {
            formAlta = new FormAlta (Enumerados.ERango.cliente);
            formAlta.ShowDialog();
            OcultarSubMenu();
        }
        private void btnAltaEmpleado_Click(object sender, EventArgs e)
        {
            formAlta = new FormAlta(Enumerados.ERango.empleado);
            formAlta.ShowDialog();
            OcultarSubMenu();
        }
        private void btnAltaAdministrador_Click(object sender, EventArgs e)
        {
            formAlta = new FormAlta(Enumerados.ERango.administrador);
            formAlta.ShowDialog();
            OcultarSubMenu();
        }
        private void btnAltaProducto_Click(object sender, EventArgs e)
        {
            formAltaProducto = new FormAltaProducto();
            formAltaProducto.ShowDialog();
            OcultarSubMenu();
        }

        private void btnBajaCliente_Click(object sender, EventArgs e)
        {
            formModificacion = new FormModificacion(Enumerados.ERango.cliente, "baja");
            formModificacion.ShowDialog();
            OcultarSubMenu();
        }
        private void btnBajaEmpleado_Click(object sender, EventArgs e)
        {
            formModificacion = new FormModificacion(Enumerados.ERango.empleado, "baja");
            formModificacion.ShowDialog();
            OcultarSubMenu();
        }
        private void txtBajaAdministrador_Click(object sender, EventArgs e)
        {
            formModificacion = new FormModificacion(Enumerados.ERango.administrador, "baja");
            formModificacion.ShowDialog();
            OcultarSubMenu();
        }
        private void btnBajaProducto_Click(object sender, EventArgs e)
        {
            formModificacionProducto = new FormModificacionProducto("baja");
            formModificacionProducto.ShowDialog();
            OcultarSubMenu();
        }

        private void btnModificarEmpleado_Click(object sender, EventArgs e)
        {
            formModificacion = new FormModificacion(Enumerados.ERango.empleado,"modificar");
            formModificacion.ShowDialog();
            OcultarSubMenu();
        }
        private void btnModificarAdministrador_Click(object sender, EventArgs e)
        {
            formModificacion = new FormModificacion(Enumerados.ERango.administrador, "modificar");
            formModificacion.ShowDialog();
            OcultarSubMenu();
        }
        private void btnModificarProducto_Click(object sender, EventArgs e)
        {
            formModificacionProducto = new FormModificacionProducto("modificar");
            formModificacionProducto.ShowDialog();
            OcultarSubMenu();
        }
        private void btnModificarCliente_Click(object sender, EventArgs e)
        {
            formModificacion = new FormModificacion(Enumerados.ERango.cliente, "modificar");
            formModificacion.ShowDialog();
            OcultarSubMenu();
        }

        private void btnVerClientes_Click(object sender, EventArgs e)
        {
            formListar = new FormListar(Enumerados.ERango.cliente);
            formListar.ShowDialog();
        }
        private void btnVerEmpleados_Click(object sender, EventArgs e)
        {
            formListar = new FormListar(Enumerados.ERango.empleado);
            formListar.ShowDialog();
        }
        private void btnVerAdministradoresk_Click(object sender, EventArgs e)
        {
            formListar = new FormListar(Enumerados.ERango.administrador);
            formListar.ShowDialog();
        }
        private void btnVerProductos_Click(object sender, EventArgs e)
        {
            formListar = new FormListar(Enumerados.ERango.producto);
            formListar.ShowDialog();
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            formVenta = new FormVenta();
            formVenta.ShowDialog();
        }
        private void btnFacturacion_Click(object sender, EventArgs e)
        {
            formFacturacion = new FormFacturacion();
            formFacturacion.ShowDialog();
        }

        private void PersonalizarDisenio()
        {
            panelSubMenuAdministrador.Visible = false;
            panelSubMenuClientes.Visible = false;
            panelSubMenuEmpleados.Visible = false;
            panelSubMenuProductos.Visible = false;
        }
        private void OcultarSubMenu()
        {
            if(this.panelSubMenuAdministrador.Visible == true)
            {
                this.panelSubMenuAdministrador.Visible = false;
            }
            if(this.panelSubMenuClientes.Visible == true)
            {
                this.panelSubMenuClientes.Visible = false;
            }
            if(this.panelSubMenuEmpleados.Visible == true)
            {
                this.panelSubMenuEmpleados.Visible = false;
            }
            if(this.panelSubMenuProductos.Visible == true)
            {
                this.panelSubMenuProductos.Visible = false;
            }
        }
        private void MostrarSubMenu(Panel subMenu)
        {
            if(subMenu.Visible == false)
            {
                //OcultarSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }
        private void btnCliente_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(this.panelSubMenuClientes);
        }
        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(this.panelSubMenuEmpleados);
        }
        private void btnAdministradores_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(this.panelSubMenuAdministrador);
        }
        private void btnProductos_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(this.panelSubMenuProductos);
        }
        private void AbrirFormHijo(Form formHijo)
        {
            if(formActivo != null)
            {
                ActiveForm.Close();
            }
            formActivo = formHijo;
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            panelFormHijo.Controls.Add(formHijo);
            panelFormHijo.Tag = formHijo;
            formHijo.BringToFront();
            formHijo.Show();
        }

        private void bntAgregarDinero_Click(object sender, EventArgs e)
        {
            formModificacion = new FormModificacion(Enumerados.ERango.cliente, "recarga");
            formModificacion.ShowDialog();
            OcultarSubMenu();
        }

        private void FormMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
