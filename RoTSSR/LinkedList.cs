using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoTSSR
{



    /*** Title: Linked List
     * Type: Void
     * 
     * Class Summary: The LinkedList class is a class that is responsible for facilitating and performing operations on the LinkedList it generates. 
     * 
     *--head-- is of class Node and represents the head of the linked list. 
     *--rear-- is of class rear and points to the rear of the linked list.
     * 
     * 
     * 
     *
      */


    /* Sort algorithim notes: 
        * WHILE CURRENT DOES NOT EQUAL NULL
   1.) Start from the head of the list. 
   2.)Compare the deck of head node and next node.
    *Cond 1: If the Deck of comparison node is greater than head's deck, move the comparison to the comparison nodes neighbor node, recurse. 
    *Cond 1.0: If the Deck of comparison node is the same as head's deck, compare their floors.
          *Cond 1.0.0  If the comparison floor is greater than current's floor return with no swap, advance current and next.    
    *Cond 1.1: If their floors are the same check their rooms.
          * Cond 1.1.0: If the comparison node's room number is greater than currents, swap, return. 
          * Cond 1.1.1: If the comparison rooms are equal return without swap, advance current and next.  

          *Cond 2.0: If the comparison floor is greater than current return with no swap.
          *Cond 2.1: If the comparison floor is lesser than the current, return with swap. 
   * Cond 3: The comparison deck must be smaller than current, thus the data must be swapped. 
   3.) When the current.next node equals the rear node. Compare the two and then make head's node as next. 



    */


    public abstract class LinkedList<T>
    {

    public T head { get; set; } //head of list
    public T rear { get; set; } //rear of list
    //public abstract T printList();
    public abstract void Rear_Add(T Node);
    public abstract void Front_Add(T Node);
    public abstract void Delete(String key);
   // public  T Search(bool select);
   // public  T Search(int x, int y);
  //  public  T Search(String input);
    public abstract void Start(T Node);
    public LinkedList() { }

}

    public class OccuList : LinkedList<Occu_Node>
    {

        public Occu_Node head { get; set; }
        public Occu_Node rear { get; set; }
        public OccuList() { }
        public OccuList(Occu_Node Node) { head = Node; rear = Node; }
        public int Length_of()
        {
            Occu_Node current = new Occu_Node();
            int x = 0;

            current = head;

            while (current != null)
            {
                x++;
            }

            return x;
        }

        public void  PrintList()
        {  
            Occu_Node n = new Occu_Node();
            n = head;
            do
            {
                Console.WriteLine(n.Occupant.ID);
                try
                {
                    n = n.Next;
                }
                catch (ArgumentNullException)
                {
                    break;
                }
            }
            while (n != null);
     
          return;
        }
        public override void Start(Occu_Node Node)
        {
            head = Node;
            head.Next = rear;

        }
        public override void Front_Add(Occu_Node Node)
        {
            Occu_Node Front = new Occu_Node();
            Front = head;

            Front.Previous = Node;
            Node.Next = Front;
            Node.Previous = null;
            head = Node;

        }
        public override void Rear_Add(Occu_Node Node)
        {
            try
            {
                if (head == null && rear == null)
                {
                    Start(Node);
                    return;
                }

                Occu_Node end = new Occu_Node();
                end = rear;
                Node.Previous = end;
                Node.Next = null;
                end.Next = Node;
                rear = Node;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("ERROR --- ROOM IS NULL");

            }

        }
        public Occu_Node Search(String Input)
        {
            Occu_Node current = new Occu_Node();
            try
            {
                current = head;

                while (Input != current.Occupant.ID)
                {
                    try
                    {
                        current = current.Next;
                    }
                    catch (ArgumentNullException)
                    {
                        return null;
                    }
                }
            }
            catch (ArgumentNullException)
            {
                return null;
            }

            return current;
        }
        public override void Delete(string Key)
        {
            //Room_Node room = new Room_Node();
            Occu_Node current = head;

            if (current == head && current == rear)
            {
                return;
            }

            while (current != null)
            {

                if (current.Occupant.ID == Key)
                {

                    //Base Case

                    if (head == null)
                    {
                        return;
                    }

                    //If node to be deleted is head node

                    if (head == current)
                    {

                        head = current.Next;

                    }

                    //If node to be deleted is rear node
                    if (rear == current)
                    {
                        rear = current.Previous;

                    }
                    //Change next if Node to be deleted is not the last node
                    if (current.Next != null)
                    {

                        current.Next.Previous = current.Next;

                    }

                    if (current.Previous != null)
                    {

                        current.Previous.Next = current.Next;
                    }
                    return;
                }

                //Console.WriteLine("Here advancing the linker");

                current = current.Next;

            }

        }

    }
public class RoomList : LinkedList<Room_Node>
    {
        public Room_Node head { get; set; }
        public Room_Node rear { get; set; }
        public RoomList(Room_Node Node) { head = Node; rear = Node;}
        public RoomList() { }


        public void printList()
        /* Title: printList
         * Type: Void           
         * Class Summary: The printList function operates by establishing references to the rear and head locations on the Linked list.
         * From there it starts at the top of the list (head) and so long as the head isn't null, it will print the name of the room and then
         * iterate further down the list.     

         */


        {
            
            //Console.WriteLine("Head is " + " " + head.room.Name + "Rear is" + " " + rear.room.Name);
            Room_Node n = new Room_Node();
            Room_Node p = new Room_Node();

            p = rear;
            n = head;



            while (n != null)
            {
                Console.WriteLine("Printing");
                Console.WriteLine(n.room.Name + " ");
                //Console.WriteLine("previous is" + " " + n.previous.room.Name + "\n");
                //Console.WriteLine("next is" + " " + n.next.room.Name + "\n");
                n = n.Next;

            }

        }


/*
        public Room_Node Search(bool selected)
        {
            Room_Node room = new Room_Node();

            if (head == null)

            {
                Console.WriteLine("Error -- Search, bool does not detect an initialized list");
                return null;

            }

            Room_Node current = head;
            try
            {
                while (current != null)
                {
                    if (current.Search("h"))
                    {
                        
                        Console.WriteLine("The Name is" + current.room.Name);
                        Console.WriteLine("The North Neighbor is" + current.room.North_Neighbor);
                        Console.WriteLine("The South Neighbor is" + current.room.South_Neighbor);
                        Console.WriteLine("The East Neighbor is" + current.room.East_Neighbor);
                        Console.WriteLine("The West Neighbor is" + current.room.West_Neighbor);
                        
                        return current;
                    }
                    current = current.Next;
                }
            }
            catch (ArgumentNullException e)
            {
                return null;
            }

            return null;




        }
    */

        public Room_Node Search(int x, int y)
        {


            Room_Node room = new Room_Node();

            if (head == null)

            {
                Console.WriteLine("Error -- Search X, Y, does not detect a  Linked List ");
                return null;

            }

            Room_Node current = head;
            while (current != null)
            {
                try
                {
                    if (current.Xcord == x && current.Ycord == y)
                    {
                        /*
                        Console.WriteLine("The Name is" + current.room.Name);
                        Console.WriteLine("The North Neighbor is" + current.room.North_Neighbor);
                        Console.WriteLine("The South Neighbor is" + current.room.South_Neighbor);
                        Console.WriteLine("The East Neighbor is" + current.room.East_Neighbor);
                        Console.WriteLine("The West Neighbor is" + current.room.West_Neighbor);
                        */
                        return current;
                    }

                    current = current.Next;

                }
                catch (NullReferenceException e)
                {
                    return null;
                }


            }

            return null;




        }

        public Room_Node Search(String key)
        {
            /* Title: Search
             * Return: Node           
             * Arguments: key
             * Type: Node
             * Summary: The search function iterates through a linked-list to find a Node with a name that matches the key argument. It does this first by checking to see if the linked list is empty.
             * Once the linked list is determined to be populated, starting with the first node, the name variable of the room object is checked against the key argument. If theres a match a reference
             * to the node is returned. If there isn't, the list is iterated by 1.             
             *             
            */
            //Room_Node room = new Room_Node();
            /*
              if (head == null)

              {
                  Console.WriteLine("Error -- Search string, does not detect an initialized list");
                  return head;

              }
              */

            Room_Node current = new Room_Node();
            current = head;
            while (current != null)
            {
                try
                {
                    //Console.WriteLine("HERE GOES SEARCHING FOR" + key);
                    if (String.Equals(current.room.Name, key))
                    {

                        // Console.WriteLine("The Name is" + current.room.Name);
                        /*
                        Console.WriteLine("The North Neighbor is" + current.room.North_Neighbor);
                        Console.WriteLine("The South Neighbor is" + current.room.South_Neighbor);
                        Console.WriteLine("The East Neighbor is" + current.room.East_Neighbor);
                        Console.WriteLine("The West Neighbor is" + current.room.West_Neighbor);
                        */
                        return current;
                    }
                    current = current.Next;




                }
                catch (NullReferenceException e)
                {
                    continue;
                }

            }
            return new Room_Node("null");


        }

        

        public override void Start(Room_Node Node)
        /* Title: Start
         * Arguments: room
         * Type: Void
         * Summary: The start function begins the linked list.              
        */
        {


                rear = Node;
                head = Node;
                rear.Previous = head;

               

            //Console.WriteLine("Leaving start and and the head equals" + head.room.GetName());

        }



        public override void Front_Add(Room_Node room)
        {
            /*
            if (room.Dk_retriever(room.Deck) == null)
            {
                return;
            }
            */

            Room_Node node = new Room_Node();
            Room_Node Header = new Room_Node();
            Header = head;

            node.Next = Header;
            node.Previous = node;
            Header.Previous = node;
            head = node;

            //Console.WriteLine("Okay I've replaced the head, my  next node is" + head.next.room.GetName());
        }

        public override void  Rear_Add(Room_Node room)
        {

            try
            {
                if (head == null && rear == null)
                {
                    Start(room);
                    return;
                }
                    Room_Node end = new Room_Node();
                    end = rear;



                end.Next = room;
                room.Previous = end;
                room.Next = null;
                rear = room;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("ERROR --- ROOM IS NULL");
            }
        }

        public override void Delete(string Key)
        {

            //Room_Node room = new Room_Node();

            Room_Node current = head;

            if (current == head && current == rear)
            {
                return;
            }

            while (current != null)
            {

                if (current.room.Name == Key)
                {

                    //Base Case

                    if (head == null)
                    {
                        return;
                    }

                    //If node to be deleted is head node

                    if (head == current)
                    {

                        head = current.Next;

                    }

                    //If node to be deleted is rear node
                    if (rear == current)
                    {
                        rear = current.Previous;

                    }
                    //Change next if Node to be deleted is not the last node
                    if (current.Next != null)
                    {

                        current.Next.Previous = current.Next;

                    }

                    if (current.Previous != null)
                    {

                        current.Previous.Next = current.Next;
                    }
                    return;
                }

                //Console.WriteLine("Here advancing the linker");

                current = current.Next;

            }

        }


        /*
        public void Distance2(Room_Node start, Room_Node target)
        {
            //1.) Start with start
            //2.) Consider target.
            //3.) Current is equal to start. 
            //4.) Run a boundary check on all node neighbors, nodes that are blocked are removed from consideration.
            //5.) If the target's Deck is higher than current, look towards the south[current = current.S_Node].                 
            //6.) If the target's Deck is lower than current, look towards the north[current = current.N_Node].
            //7.) If the target's Deck is the same as current's deck:
            //7.a) If the target's Floor is the same as current:
            //a.)If the target's room is less than start, look east.
            //b.)If the target's room is greater than start, look west.
            //7.b) If the target's floor is greater than start, look south.
            //7.c) If the target's floor is less than start look north.
            
             1.) Iterate through nodes, determine which "sides" of nodes are inaccesible.
             2.) The sides themselves have to be interactable.
             3.) A possible array of sides?                     
             
            bool N_trigger = false;
            bool S_trigger = false;
            bool E_trigger = false;
            bool W_trigger = false;



            Room_Node current = new Room_Node();
            current = start;
            RoomList Invalids = new RoomList(current);

            System.Console.WriteLine("Starting with" + " " + current.room.Name + " " + "Ending with" + target.room.Name);

            while (current != target)
            {

                
                    if (Bound_assessment('n', current))
                    {
                        N_trigger = true;
                        //Console.WriteLine("N Triggered");

                    }

                    if (Bound_assessment('s', current))
                    {
                        S_trigger = true;
                        //Console.WriteLine("S Triggered");
                    }

                    if (Bound_assessment('e', current))
                    {
                        E_trigger = true;
                        //Console.WriteLine("E Triggered");
                    }

                    if (Bound_assessment('w', current))
                    {
                        W_trigger = true;
                        //Console.WriteLine("W Triggered");

                    }
                
        

                try
                {
                    //Does the current.S_Node exist? If the desired South nodes, North boundary is NOT locked or NOT blocked -> Proceed
                    if (current.S_node != null && S_trigger == false)
                    {
                        try
                        {


                            Console.WriteLine("The S_Node of" + " " + current.room.Name + " " + "exists," + " it is: " + " " + current.S_node.room.Name);
                            Console.WriteLine("Boundcheck2" + " " + "Current's name is:" + current.room.Name + " " + "and it's southbound blocked is" + " " + current.South_Bound.Blocked);
                            Console.WriteLine("\n");



                            if (current.South_Bound.Locked = false || current.South_Bound.Blocked == false)
                            {
                                if (BoundCheck2('s', current.S_node).Locked == false || BoundCheck2('s', current.S_node).Blocked == false)
                                {
                                    Console.WriteLine("Entering into" + " " + current.S_node.room.Name + " " + "North side, from the south side of" + " " + current.room.Name + " Is possible ");

                                    if (target.room.Deck > current.room.Deck)
                                    {
                                        Console.WriteLine("Comparing Decks:....");
                                        Console.WriteLine(target.room.Name + "'s" + "  " + "Deck is of a lower level than" + " " + current.room.Name);
                                        Console.WriteLine("\n");

                                        Console.WriteLine("Traveling into" + " " + current.S_node.room.Name + "'s " + " " + "from the south side of: " + " " + current.room.Name + " " + " as a result ");
                                        Console.WriteLine("\n");

                                        current = current.S_node;
                                    }


                                    else if (target.room.Floor > current.room.Floor)

                                    {
                                        Console.WriteLine("Comparing Floors:....");
                                        Console.WriteLine(target.room.Name + "'s" + "  " + "Floor is of a lower level than" + " " + current.room.Name);
                                        Console.WriteLine("\n");

                                        Console.WriteLine("Traveling into" + " " + current.S_node.room.Name + " 's" + " " + "North side from the south side of " + " " + current.room.Name + " " + "as a result ");
                                        Console.WriteLine("\n");

                                        current = current.S_node;
                                        //////////////////////
                                        continue;
                                        /////////////////////
                                    }

                                }

                                else if (BoundCheck2('s', current.S_node).Locked == true)
                                {


                                    Console.WriteLine(current.S_node.room.Name + "'s" + " " + "North Node is locked" + " " + "Making travel into it from" + " " + current.room.Name + "'s" + " " + " South side, impossible.");
                                    Invalids.Rear_Add(current.S_node);
                                    continue;




                                }
                                else if (current.South_Bound.Locked == true)
                                {
                                    Console.WriteLine(current.room.Name + "'s" + " " + "South side is locked" + " " + "Making travel into " + " " + current.S_node.room.Name + "'s" + " " + " North side, impossible.");
                                    Invalids.Rear_Add(current.S_node);

                                }

                            }



                            else if (current.South_Bound.Blocked == true)
                            {
                                Console.WriteLine(current.room.Name + "'s" + " " + "South side is Blocked" + " " + "Making travel into " + " " + current.S_node.room.Name + "'s" + " " + " North side, impossible.");
                                Invalids.Rear_Add(current.S_node);
                                continue;

                               
                            }
                            else if (BoundCheck2('s', current.S_node).Blocked == true)
                            {
                                Console.WriteLine(current.S_node.room.Name + "'s" + " " + "North Node is blocked" + " " + "Making travel into it from" + " " + current.room.Name + "'s" + " " + " South side, impossible.");
                                Invalids.Rear_Add(current.S_node);
                              

                                continue;
                            }








                            //If the desired north nodes, South boundary is NOT locked or NOT blocked -> Proceed.
                            if (current.N_node != null && N_trigger == false)
                            {
                                Console.WriteLine("The N_Node of" + " " + current.room.Name + " " + "exists," + " it is: " + " " + current.N_node.room.Name);

                                if (BoundCheck2('n', current.N_node).Locked == false || BoundCheck2('n', current.N_node).Blocked == false)
                                {
                                    Console.WriteLine("Entering into" + " " + current.N_node.room.Name + " " + "South side from the north side of" + " " + current.room.Name + " Is possible ");

                                    if (target.room.Deck < current.room.Deck)
                                    {
                                        Console.WriteLine("Comparing Decks:....");
                                        Console.WriteLine(target.room.Name + "'s" + "  " + "Deck is of a higher level than" + " " + current.room.Name);
                                        Console.WriteLine("Traveling into" + " " + current.N_node.room.Name + "'s" + " " + "South side from the North side of: " + " " + current.room.Name + "as a result ");

                                        current = current.N_node;
                                    }
                                    else if (target.room.Floor < current.room.Floor)
                                    {
                                        Console.WriteLine("Comparing Floors:....");
                                        Console.WriteLine(target.room.Name + "'s" + "  " + "Floor is of a higher level than" + " " + current.room.Name);
                                        Console.WriteLine("\n");

                                        Console.WriteLine("Traveling into" + " " + current.N_node.room.Name + "'s" + " " + " South side from the North side of:  " + " " + current.room.Name + "as a result ");
                                        Console.WriteLine("\n");

                                        current = current.N_node;
                                    }
                                    else if (BoundCheck2('n', current.N_node).Locked == true)
                                    {
                                        Console.WriteLine(current.N_node.room.Name + "'s" + " " + "South Node is locked" + " " + "Making travel into it from:" + " " + current.room.Name + "'s" + " " + " North side, impossible.");
                                        Invalids.Rear_Add(current.N_node);
                                        continue;

                                    }
                                    else if (current.North_Bound.Locked == true)
                                    {
                                        Console.WriteLine(current.room.Name + "'s" + " " + "North side is locked" + " " + "Making travel into " + " " + current.N_node.room.Name + "'s" + " " + " South side, impossible.");
                                        Invalids.Rear_Add(current.N_node);
                                        continue;

                                    }
                                    else if (current.North_Bound.Blocked == true)
                                    {
                                        Console.WriteLine(current.room.Name + "'s" + " " + "North side is Blocked" + " " + "Making travel into " + " " + current.N_node.room.Name + "'s" + " " + " South side, impossible.");
                                        Invalids.Rear_Add(current.N_node);

                                    }
                                    else if (BoundCheck2('n', current.N_node).Blocked == true)
                                    {
                                        Console.WriteLine(current.N_node.room.Name + "'s" + " " + "South Node is blocked" + " " + "Making travel into it from" + " " + current.room.Name + "'s" + " " + " North side, impossible.");
                                        Invalids.Rear_Add(current.N_node);
                                        continue;

                                    }

                                }


                                if (current.W_node != null && W_trigger == false)
                                {
                                    Console.WriteLine("The W_Node of" + " " + current.room.Name + " " + "exists," + " it is: " + " " + current.W_node.room.Name);

                                    //If the desired west nodes, East boundary is NOT locked or NOT blocked -> proceed. 
                                    if (BoundCheck2('w', current.W_node).Locked == false || BoundCheck2('w', current.W_node).Blocked == false)
                                    {
                                        Console.WriteLine("Entering into" + " " + current.W_node.room.Name + " 's" + " " + "East side from the West side of" + " " + current.room.Name + " Is possible ");

                                        if (target.room.Num > current.room.Num)
                                        {
                                            Console.WriteLine("Comparing Room_Node Numbers:....");
                                            Console.WriteLine(target.room.Name + "'s" + "  " + "Room_Node number is of a higher level than" + " " + current.room.Name);
                                            Console.WriteLine("\n");

                                            Console.WriteLine("Traveling into" + " " + current.W_node.room.Name + " 's" + " " + "East side from the West side of: " + " " + current.room.Name + "as a result ");
                                            Console.WriteLine("\n");

                                            current = current.W_node;
                                        }


                                    }
                                    else if (BoundCheck2('w', current.W_node).Locked == true)
                                    {
                                        Console.WriteLine(current.W_node.room.Name + "'s" + " " + "East Node is locked" + " " + "Making travel into it from" + " " + current.room.Name + "'s" + " " + " West side, impossible.");
                                    }
                                    else if (current.West_Bound.Locked == true)
                                    {
                                        Console.WriteLine(current.room.Name + "'s" + " " + "West side is locked" + " " + "Making travel into " + " " + current.W_node.room.Name + "'s" + " " + " East side, impossible.");

                                    }
                                    else if (current.West_Bound.Blocked == true)
                                    {
                                        Console.WriteLine(current.room.Name + "'s" + " " + "West side is Blocked" + " " + "Making travel into " + " " + current.W_node.room.Name + "'s" + " " + " East side, impossible.");

                                    }


                                    else if (BoundCheck2('w', current.W_node).Blocked == true)
                                    {
                                        Console.WriteLine(current.W_node.room.Name + "'s" + " " + "East Node is blocked" + " " + "Making travel into it from" + " " + current.room.Name + "'s" + " " + " West side, impossible.");
                                    }



                                }


                                if (current.E_node != null && E_trigger == false)
                                {
                                    Console.WriteLine("The E_Node of" + " " + current.room.Name + " " + "exists," + " it is: " + " " + current.E_node.room.Name);

                                    if (BoundCheck2('e', current.E_node).Locked == false || BoundCheck2('e', current.E_node).Blocked == false)
                                    {
                                        if (target.room.Num < current.room.Num)
                                        {
                                            Console.WriteLine("Comparing Rooms:....");
                                            Console.WriteLine(target.room.Name + "'s" + "  " + "Room_Node number is of a lower value than" + " " + current.room.Name);
                                            Console.WriteLine("\n");
                                            Console.WriteLine("Traveling into" + " " + current.E_node.room.Name + "'s " + " " + "West side from the east side of: " + " " + current.room.Name + "as a result ");
                                            Console.WriteLine("\n");
                                            current = current.E_node;
                                        }

                                    }
                                    else if (BoundCheck2('e', current.E_node).Locked == true)
                                    {


                                        Console.WriteLine(current.W_node.room.Name + "'s" + " " + "East Node is locked" + " " + "Making travel into it from" + " " + current.room.Name + "'s" + " " + " West side, impossible.");



                                    }
                                    else if (current.East_Bound.Locked == true)
                                    {
                                        Console.WriteLine(current.room.Name + "'s" + " " + "East side is locked" + " " + "Making travel into " + " " + current.E_node.room.Name + "'s" + " " + " West side, impossible.");

                                    }
                                    else if (current.South_Bound.Blocked == true)
                                    {
                                        Console.WriteLine(current.room.Name + "'s" + " " + "East side is Blocked" + " " + "Making travel into " + " " + current.E_node.room.Name + "'s" + " " + " West side, impossible.");

                                    }
                                    else if (BoundCheck2('e', current.E_node).Blocked == true)
                                    {
                                        Console.WriteLine(current.W_node.room.Name + "'s" + " " + "East Node is Blocked" + " " + "Making travel into it from" + " " + current.room.Name + "'s" + " " + " West side, impossible.");
                                    }
                                }
                            }
                        }
                        catch (ArgumentNullException)
                        {
                            Console.WriteLine("Error in Distance 2");
                            continue;

                        }
                    }

                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Error in Distance 2");
                }

            }
        }
        */

/*
        public void Move2(Room_Node Startpoint, Room_Node Endpoint)
        {

            if (Endpoint != null)
            {
                Startpoint.selected = false;
                Endpoint.selected = true;

            }

        }
*/
        public bool present (Room_Node node)
        {
            if (Search(node.room.Name) == node)
            {
                return true;
            }

            else
                return false;
        }

        public bool Bound_assessment(char direction, Room_Node current)
        {
            switch (direction)
            {
                case 'n':
                    if (current.room.North_Bound.Blocked == true || current.room.North_Bound.Locked == true)
                    {
                        return true;
                    }
                    else
                        return false;

                case 's':
                    if (current.room.South_Bound.Blocked == true || current.room.South_Bound.Locked == true)
                    {
                        return true;
                    }
                    else
                        return false;

                case 'w':
                    if (current.room.West_Bound.Blocked == true || current.room.West_Bound.Locked == true)
                    {
                        return true;
                    }
                    else
                        return false;
                case 'e':
                    if (current.room.East_Bound.Blocked == true || current.room.East_Bound.Locked == true)
                    {
                        return true;
                    }
                    else
                        return false;

                default:
                    return false;

            }

              
        }
            

        public Room.Boundary BoundCheck2(char cardinal, Room_Node desired)
        {
            /* 1.) Check the desired node.
             * 2.) If the desired node is North -> Return the desired node's south boundary.
             * 3.) If the desired node is South -> Return the desired node's north boundary.
             * 4.) If the desired node is East -> Return the desired node's west boundary.
             * 5.) If the deisred node is West -> Return the desired node's east boundary.
             *
              */

       

            try
            {

                if (cardinal == 'n' && desired.room.South_Bound != null)
                {
                    try
                    {
                        // Console.WriteLine("Returning South Bound of:" + " " + desired.room.Name);
                        return desired.room.South_Bound;
                    }
                    catch (ArgumentNullException e)
                    {

                    }
                }
                if (cardinal == 's' && desired.room.North_Bound != null)
                {
                    if (desired.room.North_Bound != null)
                    {
                        try
                        {
                            // Console.WriteLine("Returning North Bound of:" + " " + desired.room.Name);
                            return desired.room.North_Bound;
                        }
                        catch (ArgumentNullException e)
                        {

                        }
                    }
                }
                if (cardinal == 'e' && desired.room.East_Bound != null)
                {
                    try
                    {
                        // Console.WriteLine("Returning East Bound of:" + " " + desired.room.Name);
                        return desired.room.West_Bound;
                    }
                    catch (ArgumentNullException e)
                    {

                    }
                }
                if (cardinal == 'w' && desired.room.West_Bound != null)
                {
                    try
                    {
                        // Console.WriteLine("Returning West Bound of:" + " " + desired.room.Name);
                        return desired.room.East_Bound;
                    }
                    catch (ArgumentNullException e)
                    {

                    }
                }

                Console.WriteLine("ERROR -- Something went terribly wrong with the Bound check");
                return new Room.Boundary { Electric = true, Locked = true, Blocked = true };

            }
            catch (ArgumentNullException e)
            {

            }
            return new Room.Boundary { Electric = true, Locked = true, Blocked = true };
        }




    }









}


 




