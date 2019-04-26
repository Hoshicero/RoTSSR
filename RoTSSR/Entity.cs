using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoTSSR
{
   public abstract class Entity : Object
    {
        
    }

    public class Player : Entity
    {
        public Player() { ID = "Player"; }

    }
    public class Foe : Entity
    {
        public Foe() { ID = "Foe"; }

    }
}
