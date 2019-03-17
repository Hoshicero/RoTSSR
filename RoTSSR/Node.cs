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
        public Room room;
        public Node(Room Room)
        {
            room = Room;
            next = null;
            previous = null;
        }
        public Node()
        {
            next = null;
            previous = null;
        }

        ~Node() { }

        public void N_Node(Room room, Node next, Node previous)
        {
            this.room = room;
            this.next = next;
            this.previous = previous;
        }


    }
}
