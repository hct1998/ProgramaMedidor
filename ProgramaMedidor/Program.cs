using MedidorModel.DAL;
using MedidorModel.DTO;
using ProgramaMedidor.Comunicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProgramaMedidor
{
    class Program
    {
        private static ILecturaDAL lecturaDAL = LecturaDALArchivos.GetIntancia();
        private static IMedidorDAL medidorDAL = MedidorDALArchivos.GetIntancia();


        static bool Menu()
        {
            bool continuar = true;
            Console.WriteLine("Que accion desea realizar?");
            Console.WriteLine("1. Ingresar Medidor \n 2. Ingresar Lecturas \n 3. Mostrar Lecturas \n 4. Mostrar medidores \n 0. Salir ");
            switch (Console.ReadLine().Trim())
            {
                case "1": IngresarMedidor();
                    break;
                case "2": IngresarLectura();
                    break;
                case "3": MostrarLectura();
                    break;
                case "4": MostrarMedidores();
                    break;
                default: Console.WriteLine("Ingrese opcion de nuevo");
                    break;

            }
            return continuar;
        }













        static void Main(string[] args)
        {

            HebraServidor hebra = new HebraServidor();
            Thread t = new Thread(new ThreadStart(hebra.Ejecutar));
            t.Start();
            while (Menu()) ;


        }

        static void IngresarLectura()
        {
            Console.WriteLine("Ingrese Numero Medidor");
            string nummedidor = Console.ReadLine().Trim();
            Console.WriteLine("Ingrese fecha");
            string fecha = Console.ReadLine().Trim();
            Console.WriteLine("Ingrese consumo");
            string consumo = Console.ReadLine().Trim();
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


        }


        static void IngresarMedidor()
        {
            Console.WriteLine("Ingrese ID Medidor");
            string nummedidor = Console.ReadLine().Trim();
            Medidor medidor = new Medidor()
            {
                Nummedidor = nummedidor
            };

            lock (medidorDAL){
                medidorDAL.AgregarMedidor(medidor);

            }

        }


        static void MostrarLectura()
        {
            List<Lectura> lecturas = null;
            lock (lecturaDAL)
            {
                lecturas = lecturaDAL.ObtenerLecturas();
            }
            foreach (Lectura lectura in lecturas)
            {
                Console.WriteLine(lectura);
            }
        }


        static void MostrarMedidores()
        {
            List<Medidor> medidores = null;
            lock (medidorDAL)
            {
                medidores = medidorDAL.ObtenerMedidores();
            }
            foreach(Medidor medidor in medidores)
            {
                Console.WriteLine(medidor);
            }
        }






    }
}
