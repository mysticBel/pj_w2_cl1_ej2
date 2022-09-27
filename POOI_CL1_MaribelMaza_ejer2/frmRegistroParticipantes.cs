using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace POOI_CL1_MaribelMaza_ejer2
{
    public partial class frmRegistroParticipantes : Form
    {
        int n = 0000; //variable global 

        //Definir la colección LIST
        List<Participante> lParticipantes = new List<Participante>();

        public frmRegistroParticipantes()
        {
            InitializeComponent();
        }

        private void frmRegistroParticipantes_Load(object sender, EventArgs e)
        {
            cboTipoDocumento.Items.Add("Certificado");
            cboTipoDocumento.Items.Add("Constancia");
            generaCodigo();
        }

        void generaCodigo()
        {
            n++;
            lblCodigo.Text = n.ToString("0000")+"-2022";
        }

        private void tsRegistrar_Click(object sender, EventArgs e)
        {
            //Obtener la información del participante y enviarlo a la clase
            Participante objP = new Participante();
            objP.codigo = lblCodigo.Text;
            objP.nombParticipante = txtNomParticipante.Text;
            objP.telefono = txtTelefono.Text;
            objP.email = txtEmail.Text;
            objP.tipoDocumento = cboTipoDocumento.Text;

            //Validación del nombre
            foreach (Participante p in lParticipantes)
            {
                if (p.nombParticipante == objP.nombParticipante)
                {
                    MessageBox.Show("Participante ya se encuentra registrado…!!");
                    limpiarControles();
                    return;
                }
            }

            //Enviar la información a la colección
            lParticipantes.Add(objP);
            listaParticipantes();
            limpiarControles();
            generaCodigo();
        }

        //Método que liste los participantes
        public void listaParticipantes()
        {
            lvParticipantes.Items.Clear();
            foreach (Participante p in lParticipantes)
            {
                ListViewItem fila = new ListViewItem(p.codigo);
                fila.SubItems.Add(p.nombParticipante);
                fila.SubItems.Add(p.telefono);
                fila.SubItems.Add(p.email);
                fila.SubItems.Add(p.tipoDocumento);
                lvParticipantes.Items.Add(fila);
            }
        }

        void limpiarControles()
        {
            txtNomParticipante.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            cboTipoDocumento.SelectedIndex = -1;
            txtNomParticipante.Focus();
        }
    }
}
