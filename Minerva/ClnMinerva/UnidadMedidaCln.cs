using CadMinerva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnMinerva
{
    public class UnidadMedidaCln
    {
        public static List<UnidadMedida> listar()
        {
            using(var context = new MinervaEntities())
            {
                return context.UnidadMedida.Where(x => x.estado != -1).ToList();
            }
        }
    }
}
