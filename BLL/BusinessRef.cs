using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using CORE;

namespace BLL
{
    public class BusinessRef
    {
        realestats_dbEntities _cnx = new realestats_dbEntities();

        public List<DtoTypeRealStat> GetAllTypeeRealStats()
        {

            List<DtoTypeRealStat> dtoTypeRealStats = new List<DtoTypeRealStat>();
            var entTypeRealStat = _cnx.typerealstat_table.ToList();
            foreach(var item in entTypeRealStat)
            {
                dtoTypeRealStats.Add(new DtoTypeRealStat
                {
                    id_type = item.id_type,
                    type_ar = item.type_ar,
                    type_fr = item.type_fr,
                });

            }

            return dtoTypeRealStats;


        }

         
        // BusinessRef end
    }
}
