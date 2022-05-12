using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedidorModel.DTO;

namespace MedidorModel.DAL
{
   public class LecturaDALArchivos : ILecturaDAL
    {
        private LecturaDALArchivos()
        {

        }

        private static LecturaDALArchivos instancia;

        public static ILecturaDAL GetIntancia()
        {
            if(instancia == null)
            {
                instancia = new LecturaDALArchivos();

            }
            return instancia;
        }

        private static string url = Directory.GetCurrentDirectory();
        private static string archivo = url + "/lecturas.txt";

        public void AgregarLectura(Lectura lectura)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(archivo, true))
                {
                    writer.WriteLine(lectura.Nummedidor + ";" + lectura.Fecha + ";" + lectura.Consumo);
                    writer.Flush();
                }
            }
            catch (Exception ex)
            {

            }
        }
      
        public List<Lectura> ObtenerLecturas()
        {
            List<Lectura> lista = new List<Lectura>();
            try
            {
                using (StreamReader reader = new StreamReader(archivo))
                {
                    string consumo = "";
                    do
                    {
                        consumo = reader.ReadLine();
                        if (consumo != null)
                        {
                            string[] arr = consumo.Trim().Split(';');
                            Lectura lectura = new Lectura()
                            {
                                Nummedidor = arr[0],
                                Fecha = arr[1],
                                Consumo = arr[2]
                            };
                            lista.Add(lectura);
                        }
                    } while (consumo != null);
                }
            } catch (Exception ex)
            {
                lista = null;
            }
            return lista;            
        }








    }
}
