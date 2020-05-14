using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach_Web_Dyachkov.Dal.CodeFirst.Repository
{
    public class BaseRepository
    {
        protected void WithContext(Action<RabotaContext> handler)
        {
            using (var context = new RabotaContext())
            {
                handler(context);
            }
        }
    }
}
