using MedidorModel.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorModel.DAL
{
    public class MedidorDALArchivos : IMedidorDAL
    {

        private MedidorDALArchivos()
        {

        }

        private static MedidorDALArchivos instancia;

        public static IMedidorDAL GetIntancia()
        {
            if(instancia == null)
            {
                instancia = new MedidorDALArchivos();
            }
            return instancia;
        }

        private static string url = Directory.GetCurrentDirectory();

        private static string archivo = url + "/medidor.txt";

        public void AgregarMedidor(Medidor Medidor)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(archivo, true))
                {
                    writer.WriteLine(Medidor.Nummedidor + ";");
                }
            }
            catch (Exception ex)
            {

            }
        } 


        public List<Medidor> ObtenerMedidores()
        {
            List<Medidor> lista = new List<Medidor>();
            try
            {
                using (StreamReader reader = new StreamReader(archivo))
                {
                    string nummedidor = "";
                    do
                    {
                        nummedidor = reader.ReadLine();
                        if (nummedidor != null)
                        {
                            string[] arr = nummedidor.Trim().Split(';');
                            Medidor medidor = new Medidor();
                            {
                                Nummedidor = arr[0],
                            };
                            lista.Add(medidor);

                        }
                    } while (nummedidor != null);

                }
            } catch (Exception ex)
            {
                lista = null;
            }
            return lista;
        }
        




    }
}
