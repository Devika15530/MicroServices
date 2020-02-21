using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Repositiories
{
    interface IOrder
    {

        List<Orders> GetAllItems();
    }
}
