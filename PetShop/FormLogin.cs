using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetShop
{
    public partial class FormLogin : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        FormMenuPrincipal menuPrincipal;
        Empleado emp1;

        public FormLogin()
        {
            InitializeComponent();            
        }
        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.lblError.Text = string.Empty;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            emp1 = DatosSistema.LoguearUsuario(this.txtUsuario.Text, this.txtPass.Text);
            if(!(emp1 is null))
            {
                menuPrincipal = new FormMenuPrincipal(emp1);
                if(emp1.GetType() == typeof(Empleado))
                {
                    menuPrincipal.BackColor = Color.Black;
                }
                menuPrincipal.Show();
                this.Hide();
            }
            else
            {
                this.lblError.Text = "Error Datos Incorrectos";
            }
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < DatosSistema.listaEmpleados.Count; i++)
            {
                if(DatosSistema.listaEmpleados[i] is Administrador)
                {
                    this.txtUsuario.Text = DatosSistema.listaEmpleados[i].Usuario;
                    this.txtPass.Text = DatosSistema.listaEmpleados[i].Password;
                    break;
                }
            }
        }

        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < DatosSistema.listaEmpleados.Count; i++)
            {
                if (DatosSistema.listaEmpleados[i] is Empleado)
                {
                    this.txtUsuario.Text = DatosSistema.listaEmpleados[i].Usuario;
                    this.txtPass.Text = DatosSistema.listaEmpleados[i].Password;
                    break;
                }
            }
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
