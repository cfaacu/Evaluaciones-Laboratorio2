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
    public partial class FormAlta : Form
    {
        Enumerados.ERango rango;
        public FormAlta(Enumerados.ERango ERango)
        {
            this.rango = ERango;
            InitializeComponent();
        }
        private void FormAlta_Load(object sender, EventArgs e)
        {
            if(rango == Enumerados.ERango.cliente)
            {
                this.lblUsuario.Visible = false;
                this.txtUsuario.Visible = false;
                this.lblPassword.Visible = false;
                this.txtPassword.Visible = false;
            }
            else
            {
                this.lblSaldo.Visible = false;
                this.txtSaldo.Visible = false;
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(rango == Enumerados.ERango.cliente)
            {
                if(double.TryParse(this.txtSaldo.Text, out double saldo))
                {
                    if(Validaciones.EstaPersona(this.txtCuil.Text))
                    {
                        lblError.Visible = true;
                        lblError.Text = "Error cuil utilizado";
                    }
                    else
                    {
                        if (DatosSistema.AltaCliente(this.txtNombre.Text, this.txtApellido.Text, this.txtCuil.Text, saldo))
                        {
                            this.Close();
                        }
                        else
                        {
                            this.lblError.Visible = true;
                            lblError.Text = "Error datos incorrectos";
                        }
                    }
                }
            }
            if(rango == Enumerados.ERango.empleado)
            {
                if (Validaciones.EstaPersona(this.txtCuil.Text))
                {
                    this.lblError.Visible = true;
                    this.lblError.Text = "Error cuil utilizado";
                }
                else if(Validaciones.EstaUsuario(this.txtUsuario.Text))
                {
                    this.lblError.Visible = true;
                    this.lblError.Text = "Error usuario utlizado";
                }
                else
                {
                    if (DatosSistema.AltaEmpleado(this.txtNombre.Text, this.txtApellido.Text, this.txtCuil.Text, this.txtUsuario.Text, this.txtPassword.Text))
                    {
                        this.Close();
                    }
                    else
                    {
                        this.lblError.Visible = true;
                        lblError.Text = "Error datos incorrectos";
                    }
                }
            }
            if(rango == Enumerados.ERango.administrador)
            {
                if (Validaciones.EstaPersona(this.txtCuil.Text))
                {
                    this.lblError.Visible = true;
                    this.lblError.Text = "Error cuil utilizado";
                }
                else if(Validaciones.EstaUsuario(this.txtUsuario.Text))
                {
                    this.lblError.Visible = true;
                    this.lblError.Text = "Error usuario utilizado";
                }
                else
                {
                    if (DatosSistema.AltaAdministrador(this.txtNombre.Text, this.txtApellido.Text, this.txtCuil.Text, this.txtUsuario.Text, this.txtPassword.Text))
                    {
                        this.Close();
                    }
                    else
                    {
                        this.lblError.Visible = true;
                        lblError.Text = "Error datos incorrectos";
                    }
                }
            }
        }       
    }
}
