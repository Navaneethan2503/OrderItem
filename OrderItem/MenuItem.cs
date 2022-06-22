using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderItem
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool freeDelivery { get; set; }
        public Double Price { get; set; }
        public DateTime DateOfLaunch { get; set; }

        public bool Active { get; set; }
    }
}
