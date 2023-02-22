using System;
using System.Collections.Generic;

namespace PencilApp
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        public long IdUsers { get; set; }
        public string Login { get; set; } = null!;
        public string Pass { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Role { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
