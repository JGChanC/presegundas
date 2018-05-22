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

namespace ExamenU1Re
{
    public partial class Formulario1 : Form
    {
        Int16 cuantos = 0;
        String auxPrecio,auxSCan;
        Int16 claveSucursal = 0;
        String nombreSucursal="";
        decimal[] precios = new decimal[10];
        Int16[] cantidades = new Int16[10];
        decimal[] precios_globales = new decimal[10];
        Int16[] cantidades_globales = new Int16[10];
        Int16 auxCan = 0, auxPre = 0, auxCan_globales = 0, auxPre_globales = 0, auxSucursales =0;
        Libreria.Sucursal[] sucursales = new Libreria.Sucursal[100];
        decimal[] respA, respC;
        Int16[] respB;



        public Formulario1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtCuantos_TextChanged(object sender, EventArgs e)
        {
            cuantos = Convert.ToInt16(txtCuantos.Text);
        }

        private void txtSucursal_TextChanged(object sender, EventArgs e)
        {
            nombreSucursal= txtSucursal.Text;

        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
           auxPrecio = txtPrecio.Text;
           
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            auxSCan = txtCantidad.Text;
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (!(auxPre == 10))
            {
                precios[auxPre] = Convert.ToDecimal(auxPre);
                precios_globales[auxPre_globales] = Convert.ToDecimal(txtPrecio.Text);
                txtPrecio.Text = "";
                lblPrecios.Text = String.Format("Faltan {0} precios", 10 - (1 + auxPre));
                auxPre++;
                if (auxPre == 10)
                {
                    txtPrecio.Enabled = false;
                    MessageBox.Show("Ya ingresó todos los precios");
                }
            }
            else
            {
                txtPrecio.Enabled = false;
                MessageBox.Show("Ya ingresó todos los precios");
            }
        }

        private void btnNuevoCan_Click(object sender, EventArgs e)
        {
            if (!(auxCan == 10))
            {
                cantidades[auxCan] = Convert.ToInt16(auxSCan);
                cantidades_globales[auxCan_globales] = Convert.ToInt16(txtCantidad.Text);
                lblPrecios.Text = String.Format("Faltan {0} cantidades", 10 - (1 + auxCan));
                txtCantidad.Text = "";
               auxCan++;
                if ((auxCan == 10))
                {
                    txtCantidad.Enabled = false;
                    MessageBox.Show("Ya ingresó todas las cantidades");
                }
            }
            else
            {
                txtCantidad.Enabled = false;
                MessageBox.Show("Ya ingresó todas las cantidades");
            }
        }

        private void btnSigCaptura_Click(object sender, EventArgs e)
        {
            if (!(cuantos == auxSucursales))
            {

                Libreria.Sucursal objAuxSuc = new Libreria.Sucursal();
                objAuxSuc.PClaveSucursal = claveSucursal;
                objAuxSuc.PNombreSucursal = nombreSucursal;
                objAuxSuc.PPrecios = precios;
                objAuxSuc.Pcantidades = cantidades;
                sucursales[auxSucursales] = objAuxSuc;
                auxSucursales++;

                txtClave.Text = "";
                txtSucursal.Text = "";
                txtCantidad.Enabled = true;
                txtPrecio.Enabled = true;
                txtCantidad.Text = "";
                txtPrecio.Text = "";

                auxCan = 0;
                auxPre = 0;

                if ((cuantos == auxSucursales)) {
                    txtClave.Enabled = false;
                    txtSucursal.Enabled = false;
                    txtCantidad.Enabled = false;
                    txtPrecio.Enabled = false;
                    MessageBox.Show("Ya ingresó todas las sucursales");
                } 
            }
            else
            {

                MessageBox.Show("Ya ingresó todas las sucursales");
            }
        
    }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {
            txtCuantos.Enabled = false;
            claveSucursal= Convert.ToInt16("0"+txtClave.Text);
        }

        private void btnResultados_Click(object sender, EventArgs e)
        {
            Ventana2.Ventana2 obj = new Ventana2.Ventana2();
            obj.setResultados(respA, respB, respC);
            this.Hide();
            obj.Show();

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            EscribeBinario();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            Libreria.Sucursal obj = new Libreria.Sucursal();
           

            respA = obj.IncisoA(precios_globales);
            respB = obj.IncisoB(precios_globales, cantidades_globales);
            respC = obj.IncisoC(precios_globales, cantidades_globales);
            MessageBox.Show("Calculos Realizados");
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        public void EscribeBinario()
        {
           

            Stream registro;
            registro = File.Open("C://VS2015//U_5//archivosGenerados//Sucursales.bin", FileMode.Append, FileAccess.Write);
            BinaryWriter NIA = new BinaryWriter(registro); //Conexion con el archivo binario intermedio
          

            for (Int16 ciclo = 0; ciclo < cuantos; ciclo++)
            {

                //GRABAR LOS DATOS
                
                NIA.Write(sucursales[ciclo].PClaveSucursal);
                NIA.Write(sucursales[ciclo].PNombreSucursal);

                for (int i = 0; i < 10; i++) {
                    NIA.Write(sucursales[ciclo].PPrecios[i]);
                }

                for (int i = 0; i < 10; i++)
                {
                    NIA.Write(sucursales[ciclo].Pcantidades[i]);
                }
                
            }

            registro.Close();

            MessageBox.Show("Archivo Binario Generado");

        }


    }
}
