using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User
    {
        public List<User> Friends { get; set; }
        public List<Asset> Assets { get; set; }
    }
}
