using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace General.GUI
{
    public partial class RolesEdicion : Form
    {
        private void Procesar()
        {
            CLS.Roles oEntidad = new CLS.Roles();
            oEntidad.IdRol = txbIDRol.Text;
            oEntidad.Rol = txbRol.Text;

            try
            {
                if (txbIDRol.TextLength > 0)
                {
                    //ESTOY ACTUALIZANDO
                    if (oEntidad.Editar())
                    {
                        MessageBox.Show("¡Registro actualizado correctamente!", "Confirmación", MessageBoxButtons.OK,MessageBoxIcon.Information);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("¡Ocurrió un problema al actualizar!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    if (oEntidad.Guardar())
                    {
                        MessageBox.Show("¡Registro ingresado correctamente!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("¡Ocurrió un problema al guardar!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);                    }
                }
            }
            catch 
            {

            }
        }
        private Boolean Comprobar()
        {
            Boolean resultado = true;
            Notificador.Clear();

            if (txbRol.TextLength == 0)
            {
                resultado = false;
                Notificador.SetError(txbRol, "Este campo no puede quedar vacio");
            }
            return resultado;
        }


        public RolesEdicion()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Comprobar())
            {
                Procesar();
            }
        }
    }
}
