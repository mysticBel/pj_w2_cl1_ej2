using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POOI_CL1_MaribelMaza_ejer2
{
    public partial class frmRegistroParticipantes : Form
    {
        int n = 0000; //variable global 
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
    }
}
