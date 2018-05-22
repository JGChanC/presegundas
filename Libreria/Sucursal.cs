using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    public class Sucursal
    {
        Int16 claveSucursal;
        String nombreSucursal; 
        decimal[] precios;
        Int16[] cantidades;

        //Própriedad de claveSucursal

        public Int16 PClaveSucursal
        {
            get {

                return claveSucursal;
            }

            set {
                claveSucursal = value;
            }
        }

        public String PNombreSucursal
        {
            get
            {

                return nombreSucursal;
            }

            set
            {
                nombreSucursal = value;
            }
        }


        public decimal[] PPrecios {
            get {
                return precios;
            }

            set {
                precios = value;
            }

        }


        public Int16[] Pcantidades
        {
            get
            {
                return cantidades;
            }

            set
            {
                cantidades = value;
            }
        }



        //Metodos para Calcular

        public decimal[] IncisoA(decimal[] precios) {
            decimal[] respuestas = new decimal[2];
            decimal menor = 100000000, mayor=0;

            for (int i = 0; i < precios.Length; i++) {

                if (menor > precios[i]) menor = precios[i];
                if (mayor < precios[i]) mayor = precios[i];

            }

            respuestas[0] = menor;
            respuestas[1] = mayor;
            return respuestas;
        }

        public Int16[] IncisoB(decimal[] precios, Int16[] cantidades)
        {
            Int16[] respuesta = new Int16[2];
            Int16 cuantos=0,cuantos_can=0;

            for (int i = 0; i < precios.Length; i++)
            {

                if (precios[i] > 100 && precios[i] <= 1000) cuantos++;
                if (cantidades[i] > 100) cuantos_can++;


            }

            respuesta[0] = cuantos;
            respuesta[1] = cuantos_can;
            return respuesta;
        }

        public decimal[] IncisoC(decimal[] precios, Int16[] cantidades)
        {
            Int16 suma_can=0;
            decimal suma_pre = 0;
         
            decimal[] respuesta = new decimal[2];

            for (int i = 0; i < precios.Length; i++)
            {
                suma_pre += precios[i];
            }

            for (int i = 0; i < cantidades.Length; i++)
            {
                suma_can += cantidades[i];
            }

            respuesta[0] = suma_pre / precios.Length;
            respuesta[1] = suma_can / cantidades.Length;

            return respuesta;
        }


    }
}
