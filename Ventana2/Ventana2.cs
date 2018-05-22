using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; //Agregar la libreria

namespace Ventana2
{
    public partial class Ventana2 : Form
    {

        decimal[] respA; Int16[] respB; decimal[] respC;

        public void setResultados(decimal[] respA, Int16[] respB, decimal[] respC) {
            this.respA = respA;
            this.respB = respB;
            this.respC = respC;
        }

        public Ventana2()
        {
            InitializeComponent();

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            ExamenU1Re.Formulario1 obj = new ExamenU1Re.Formulario1();
            this.Hide();
            obj.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
           
        }


        public void LeerBinario()
        {

            Stream registro;
            registro = File.Open("C://VS2015//U_5//archivosGenerados//Sucursales.bin", FileMode.Open, FileAccess.Read);
            BinaryReader NIA = new BinaryReader(registro); //Conexion con el archivo binario intermedio


            do
            {
                txtClave.Text = Convert.ToString(NIA.ReadInt16());
                txtSucursal.Text = Convert.ToString(NIA.ReadString());
                txtPrecio1.Text = Convert.ToString(NIA.ReadDecimal());
                txtPrecio2.Text = Convert.ToString(NIA.ReadDecimal());
                txtPrecio3.Text = Convert.ToString(NIA.ReadDecimal());
                txtPrecio4.Text = Convert.ToString(NIA.ReadDecimal());
                txtPrecio5.Text = Convert.ToString(NIA.ReadDecimal());
                txtPrecio6.Text = Convert.ToString(NIA.ReadDecimal());
                txtPrecio7.Text = Convert.ToString(NIA.ReadDecimal());
                txtPrecio8.Text = Convert.ToString(NIA.ReadDecimal());
                txtPrecio9.Text = Convert.ToString(NIA.ReadDecimal());
                txtPrecio10.Text = Convert.ToString(NIA.ReadDecimal());
                txtCan1.Text= Convert.ToString(NIA.ReadInt16());
                txtCan2.Text = Convert.ToString(NIA.ReadInt16());
                txtCan3.Text = Convert.ToString(NIA.ReadInt16());
                txtCan4.Text = Convert.ToString(NIA.ReadInt16());
                txtCan5.Text = Convert.ToString(NIA.ReadInt16());
                txtCan6.Text = Convert.ToString(NIA.ReadInt16());
                txtCan7.Text = Convert.ToString(NIA.ReadInt16());
                txtCan8.Text = Convert.ToString(NIA.ReadInt16());
                txtCan9.Text = Convert.ToString(NIA.ReadInt16());
                txtCan10.Text = Convert.ToString(NIA.ReadInt16());
                

                MessageBox.Show("Presione para continuar...");

            } while (NIA.PeekChar() != -1);

            registro.Close();
        }

        private void btnCargarBinario_Click(object sender, EventArgs e)
        {
            lblRespA.Text = String.Format("El precio mayor global es: {0} y el precio menor global:{1}", respA[1], respA[0]);
            lblRespB.Text = String.Format("Precios entre 100 y 1000 son: {0} y cantidades mayores a 100 global:{1}", respB[0], respB[1]);
            lblRespC.Text = String.Format("Promedio de Precios es: {0} y promedio de cantidades es: {1}", respC[0], respC[1]);
            LeerBinario();
        }
    }
}
