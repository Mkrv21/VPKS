using System;
using System.Collections.Generic;

namespace PencilApp
{
    public partial class Order
    {
        public Order()
        {
            ProductsInOrders = new HashSet<ProductsInOrder>();
        }

        public long IdOrders { get; set; }
        public long IdUsers { get; set; }
        public long CostOrders { get; set; }
        public string Data { get; set; } = null!;
        public string? Adress { get; set; }
        public string Payment { get; set; } = null!;

        public virtual User IdUsersNavigation { get; set; } = null!;
        public virtual ICollection<ProductsInOrder> ProductsInOrders { get; set; }
    }
}
