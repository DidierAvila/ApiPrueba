using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPrueba.Services.Utilities
{
    public class UtilService : IUtilService
    {
        /// <summary>
        /// Ordena de manera ascendente un arreglo de numero aleatorios tipo int
        /// </summary>
        /// <returns></returns> <summary>
        /// 
        /// </summary>
        /// <returns>Arreglo ordenado</returns>
        public int[] ArrayAscOrder()
        {
            int[] CurrentUser = new int[7];
            Random random = new();

            for (int i = 0; i < CurrentUser.Length; i++)
            {
                CurrentUser[i] = random.Next(100);        
            }
            Array.Sort(CurrentUser);
        
            return CurrentUser;
        }
    }
}