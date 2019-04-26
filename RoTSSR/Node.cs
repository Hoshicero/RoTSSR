using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoTSSR
{
 public abstract class Node<T>
    {


        public T Previous { get; set; }
        public T Next { get; set; }
        public T Data { get; set; }
        public Node() { }
        public T Xcord { get; set; }
        public T Ycord { get; set; }



    }


    public class Room_Node : Node<Room_Node>
    {
    
        public Room room { get; set; }
        public Room_Node N_node { get; set; }
        public Room_Node S_node { get; set; }
        public Room_Node E_node { get; set; }
        public Room_Node W_node { get; set; }
        public Room_Node(Room rm) { room = rm;}
        public Room_Node() { }
        public LinkedList<Occu_Node> Occupancies;
        ~Room_Node() { }
    }


    public class Occu_Node : Node<Occu_Node>
    {
       // public Occu_Node Next { get; set;}
       // public Occu_Node Previous { get; set;}
       public new Entity Data { get; set; }
    }




}



