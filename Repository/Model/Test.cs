using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Model
{
    public partial class Test
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime JoinDate { get; set; }
    }
}
