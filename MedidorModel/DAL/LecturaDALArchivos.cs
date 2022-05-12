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

        
      
        








    }
}
