using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoTSSR
{
    public class Node
    {


        public Node previous { get; set; }
        public Node next { get; set; }

        public Node north { get; set;}
        public Node south { get; set;}
        public Node east { get; set;}
        public Node west { get; set;}

        public Room room;
        public Node(Room Room)
        {
            room = Room;
            next = null;
            previous = null;
            north = null;
            south = null;
            east = null;
            west = null;

        }
        public Node()
        {
            next = null;
            previous = null;
            north = null;
            south = null;
            east = null;
            west = null;
        }

        ~Node() { }

        public void N_Node(Room room, Node next, Node previous)
        {
            this.room = room;
            this.next = next;
            this.previous = previous;
        }


        public bool Hasnext()
        {
            if (this.next != null)
            {
                return true;
            }
            else
                return false;
        }

        public bool Hasprevious()
        {
            if (this.previous != null)
            {
                return true;
            }
            else
                return false;
        }


    }
}
