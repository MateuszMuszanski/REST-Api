using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Excepions
{
    public class NotFoundExcepion : Exception
    {
        public NotFoundExcepion(string exception) : base(exception)
        {

        }
    }
}
