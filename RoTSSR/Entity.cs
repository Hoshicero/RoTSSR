using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoTSSR
{
   public abstract class Entity  : Obj
    {
        public abstract String ID { get; set;}
    }

    public class Player : Entity
    {
        public override string ID { get; set; }
        public Player() { ID = "Player"; }

    }
    public class Foe : Entity
    {
        public override string ID { get; set; }
        public Foe() { ID = "Foe"; }

    }
}
