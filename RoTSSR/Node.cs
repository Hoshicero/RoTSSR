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
        public int Xcord { get; set; }
        public int Ycord { get; set; }



    }


    public class Room_Node : Node<Room_Node>
    {
      
        public String ID { get; set; }
        public Room room { get; set; }
        public Room_Node N_node { get; set; }
        public Room_Node S_node { get; set; }
        public Room_Node E_node { get; set; }
        public Room_Node W_node { get; set; }
        public OccuList Occupancies = new OccuList();
        public Room_Node(Room rm) { room = rm; ID = rm.Name;}
        public Room_Node(String empty) { N_node = null; S_node = null; E_node = null; W_node = null; room = null;}
        public Room_Node()
        {


        }
        ~Room_Node() { }
    }


    public class Occu_Node : Node<Occu_Node>
    {
        public Occu_Node Next { get; set;}
        public Occu_Node Previous { get; set;}
        public Entity Occupant { get; set;}
        public Occu_Node() { }
        public Occu_Node(String en)
        {
            if(String.Equals(en, "P"))
            {
                Occupant = new Player();
            }
            if(String.Equals(en, "F"))
            {
                Occupant = new Foe();
            }
        }
    }




}



