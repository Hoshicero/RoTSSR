using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoTSSR
{
    public class Node:Room
    {


        public Node previous { get; set; }
        public Node next { get; set; }
        public int Xcord { get; set;}
        public int Ycord { get; set;}
        public bool selected { get; set; } //Whether or not this Room is selected, subject to change. 
        public Node N_node { get; set;}
        public Node S_node { get; set;}
        public Node E_node { get; set;}
        public Node W_node { get; set;}

        public Room room;
        public Node(Room Room)
        {
           
            room = Room;
            next = null;
            previous = null;
            N_node = null;
            S_node = null;
            E_node = null;
            W_node = null;
            //Console.WriteLine("Activating Node:" + " " + room.Name);
        }
        public Node()
        {
            next = null;
            previous = null;
            N_node = null;
            S_node = null;
            E_node = null;
            W_node = null;
        }

        ~Node() { }
    

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
