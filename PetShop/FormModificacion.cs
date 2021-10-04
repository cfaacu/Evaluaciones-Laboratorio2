using Entidades;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PetShop
{
    public partial class FormModificacion : Form
    {
        Enumerados.ERango rango;
        Cliente clienteAux;
        string accion;
        public FormModificacion(Enumerados.ERango rango, string accion)
        {
            InitializeComponent();
            this.rango = rango;
            this.accion = accion;
        }
        private void FormModificacion_Load(object sender, EventArgs e)
        {
            if (this.accion == "modificar" || this.accion == "recarga")
            {
                this.btnAceptar.Visible = false;
                this.btnContinuar.Visible = true;
            }
            if (this.rango == Enumerados.ERango.cliente)
            {
                foreach (Cliente item in DatosSistema.listaClientes)
                {
                    lstInfo.Items.Add(item.MostrarDatos());
                }
            }
            if (this.rango == Enumerados.ERango.empleado)
            {
                foreach (Empleado item in DatosSistema.listaEmpleados)
                {
                    if (item.GetType() == typeof(Empleado))
                    {
                        lstInfo.Items.Add(item.MostrarDatos());
                    }
                }
            }
            if (this.rango == Enumerados.ERango.administrador)
            {
                foreach (Empleado item in DatosSistema.listaEmpleados)
                {
                    if (item.GetType() == typeof(Administrador))
                    {
                        lstInfo.Items.Add(item.MostrarDatos());
                    }
                }
            }
        }
        private void btnContinuar_Click(object sender, EventArgs e)
        {
            this.lblError.Text = string.Empty;
            if(this.rango == Enumerados.ERango.cliente && this.accion == "recarga")
            {
                if (Validaciones.IsCuil(this.txtCuil.Text))
                {
                    for (int i = 0; i < DatosSistema.listaClientes.Count(); i++)
                    {
                        if (DatosSistema.listaClientes[i].Cuil.Equals(this.txtCuil.Text))
                        {
                            this.btnContinuar.Visible = false;
                            this.lblSaldo.Visible = true;
                            this.txtSaldo.Visible = true;
                            this.btnAceptar.Visible = true;
                            this.txtCuil.ReadOnly = true;
                            clienteAux = DatosSistema.listaClientes[i];
                            break;
                        }
                        else
                        {
                            this.lblError.Visible = true;
                            this.lblError.Text = "Error cuil inexistente";
                        }
                    }
                }
                else
                {
                    this.lblError.Visible = true;
                    this.lblError.Text = "Error datos invalidos";
                }
            }
            if (this.rango == Enumerados.ERango.cliente && this.accion == "modificar")
            {
                LlenarCamposCliente();
            }
            if (this.rango == Enumerados.ERango.empleado && this.accion == "modificar" || this.rango == Enumerados.ERango.administrador && this.accion == "modificar")
            {
                if (Validaciones.IsCuil(this.txtCuil.Text))
                {
                    for (int i = 0; i < DatosSistema.listaEmpleados.Count(); i++)
                    {
                        if (DatosSistema.listaEmpleados[i].Cuil.Equals(this.txtCuil.Text))
                        {
                            this.btnContinuar.Visible = false;
                            this.lblApellido.Visible = true;
                            this.lblCuil.Visible = true;
                            this.lblNombre.Visible = true;
                            this.lblSaldo.Visible = false;
                            this.txtApellido.Visible = true;
                            this.txtCuil.Visible = true;
                            this.txtNombre.Visible = true;
                            this.txtSaldo.Visible = false;
                            this.btnAceptar.Visible = true;
                            this.txtCuil.ReadOnly = true;
                            this.txtUsuario.Visible = true;
                            this.lblUsuario.Visible = true;
                            this.txtPassword.Visible = true;
                            this.lblPassword.Visible = true;
                            this.txtApellido.Text = DatosSistema.listaEmpleados[i].Apellido;
                            this.txtCuil.Text = DatosSistema.listaEmpleados[i].Cuil;
                            this.txtNombre.Text = DatosSistema.listaEmpleados[i].Nombre;
                            this.txtPassword.Text = DatosSistema.listaEmpleados[i].Password;
                            this.txtUsuario.Text = DatosSistema.listaEmpleados[i].Usuario;
                            break;
                        }
                        else
                        {
                            this.lblError.Visible = true;
                            this.lblError.Text = "Error cuil inexistente";
                        }
                    }
                }
                else
                {
                    this.lblError.Visible = true;
                    this.lblError.Text = "Error datos invalidos";
                }
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.lblError.Text = string.Empty;

            if (this.rango == Enumerados.ERango.cliente && this.accion == "modificar")
            {
                if (double.TryParse(this.txtSaldo.Text, out double saldo))
                {
                    if (DatosSistema.ModificarCliente(this.txtNombre.Text, this.txtApellido.Text, this.txtCuil.Text, saldo))
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
            if (this.rango == Enumerados.ERango.empleado && this.accion == "modificar")
            {
                if (DatosSistema.ModificarEmpleado(this.txtNombre.Text, this.txtApellido.Text, this.txtCuil.Text, this.txtUsuario.Text, this.txtPassword.Text))
                {
                    this.Close();
                }
                else
                {
                    this.lblError.Visible = true;
                    this.lblError.Text = "Error datos incorrectos";
                }
            }
            if (this.rango == Enumerados.ERango.administrador && this.accion == "modificar")
            {
                if (DatosSistema.ModificarAdministrador(this.txtNombre.Text, this.txtApellido.Text, this.txtCuil.Text, this.txtUsuario.Text, this.txtPassword.Text))
                {
                    this.Close();
                }
                else
                {
                    this.lblError.Visible = true;
                    this.lblError.Text = "Error datos incorrectos";
                }
            }
            if (this.rango == Enumerados.ERango.cliente && this.accion == "baja")
            {
                if (DatosSistema.BajaCliente(this.txtCuil.Text))
                {
                    this.Close();
                }
                else
                {
                    this.lblError.Visible = true;
                    this.lblError.Text = "Error datos incorrectos";
                }
            }
            if (this.rango == Enumerados.ERango.empleado && this.accion == "baja")
            {
                if (DatosSistema.BajaEmpleados(this.txtCuil.Text))
                {
                    this.Close();
                }
                else
                {
                    this.lblError.Visible = true;
                    this.lblError.Text = "Error datos incorrectos";
                }

            }
            if (this.rango == Enumerados.ERango.administrador && this.accion == "baja")
            {
                if (DatosSistema.BajaAdministrador(this.txtCuil.Text))
                {
                    this.Close();
                }
                else
                {
                    this.lblError.Visible = true;
                    this.lblError.Text = "Error datos incorrectos";
                }
            }
            if(this.rango == Enumerados.ERango.cliente && this.accion == "recarga")
            {
                if(double.TryParse(this.txtSaldo.Text, out double dinero))
                {
                    clienteAux = clienteAux + dinero;
                    this.Close();
                }
                else
                {
                    this.lblError.Visible = true;
                    this.lblError.Text = "Error saldo incorrecto";
                }
            }
        }

        private void LlenarCamposCliente()
        {
            if (Validaciones.IsCuil(this.txtCuil.Text))
            {
                for (int i = 0; i < DatosSistema.listaClientes.Count(); i++)
                {
                    if (DatosSistema.listaClientes[i].Cuil.Equals(this.txtCuil.Text))
                    {
                        this.btnContinuar.Visible = false;
                        this.lblApellido.Visible = true;
                        this.lblCuil.Visible = true;
                        this.lblNombre.Visible = true;
                        this.lblSaldo.Visible = true;
                        this.txtApellido.Visible = true;
                        this.txtCuil.Visible = true;
                        this.txtNombre.Visible = true;
                        this.txtSaldo.Visible = true;
                        this.btnAceptar.Visible = true;
                        this.txtCuil.ReadOnly = true;
                        this.txtApellido.Text = DatosSistema.listaClientes[i].Apellido;
                        this.txtCuil.Text = DatosSistema.listaClientes[i].Cuil;
                        this.txtNombre.Text = DatosSistema.listaClientes[i].Nombre;
                        this.txtSaldo.Text = DatosSistema.listaClientes[i].Saldo.ToString();
                        break;
                    }
                    else
                    {
                        this.lblError.Visible = true;
                        this.lblError.Text = "Error cuil inexistente";
                    }
                }
            }
            else
            {
                this.lblError.Visible = true;
                this.lblError.Text = "Error datos invalidos";
            }
        }
    }
}
