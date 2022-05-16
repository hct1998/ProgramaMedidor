using MedidorModel.DAL;
using MedidorModel.DTO;
using ServerUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaMedidor.Comunicacion
{
    class HebraCliente
    {
        private ILecturaDAL lecturaDAL = LecturaDALArchivos.GetIntancia();
        private ClienteCom clienteCom;

        public HebraCliente(ClienteCom clienteCom)
        {
            this.clienteCom = clienteCom;
        }

        public void Ejecutar()
        {
            clienteCom.Escribir("Ingresar Lecturas Medidor");
            clienteCom.Escribir("Ingrese ID Medidor");
            string nummedidor = clienteCom.Leer();
            clienteCom.Escribir("Ingrese fecha");
            string fecha = clienteCom.Leer();
            clienteCom.Escribir("Ingrese consumo");
            string consumo = clienteCom.Leer();

            Lectura lectura = new Lectura()
            {
                Nummedidor = nummedidor,
                Fecha = fecha,
                Consumo = consumo,
            };
            lock (lecturaDAL)
            {
                lecturaDAL.AgregarLectura(lectura);
            }
            
            clienteCom.Desconectar();

        }


    }
}