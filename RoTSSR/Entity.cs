using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoTSSR
{
   public abstract class Entity <T> : Object
    {
          public T Data { get; set; }
          public String ID { get; set;}
    }

    public class Player : Entity<String>
    {
        public Player() { ID = "Player"; }

    }
    public class Foe : Entity<String>
    {
        public Foe() { ID = "Foe"; }

    }
}
