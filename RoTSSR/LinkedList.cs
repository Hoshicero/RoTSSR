﻿using System;
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
    public class LinkedList : Node
    {

        public Node head { get; set; } //head of list
        public Node rear { get; set; } //rear of list


        public LinkedList() //constructor
        {
            head = null;
            rear = null;

        }

        public LinkedList(Node node)
        {
            head = node;
            rear = node;
        }




        public void Sortv1()
        {
            Node current = new Node();
            Node next = new Node();
            try {
                while (current != null)
                {
                    /***********1.)*************/
                    current = head;
                    next = head.next;
                    /***********2.)*************/

                    /***********Cond 1)*************/
                    if (next.room.Deck > current.room.Deck)
                    {
                        current = current.next;
                        next = current.next;
                    }
                    /***********Cond 1.0)*************/
                    if (next.room.Deck == current.room.Deck)
                    {
                        /***********Cond 1.0.0)*************/

                        if (next.room.Floor > current.room.Floor)
                        {
                            current = current.next;
                            next = current.next;


                        }
                        /***********Cond 1.1)*************/
                        else if (next.room.Floor == current.room.Floor)
                        {
                            /***********Cond 1.1.0)*************/
                            if (next.room.Num > current.room.Num)
                            {

                                DataSwap(next, current);


                            }
                            /***********Cond 1.1.1)*************/

                            else if (next.room.Num == current.room.Num)
                            {
                                current = current.next;
                                next = current.next;


                            }
                            else return;

                        }

                        else
                            DataSwap(next, current);
                        current = current.next;
                        next = current.next;

                    }
                    else
                        DataSwap(next, current);
                    current = current.next;
                    next = current.next;



                }

            }
            catch (NullReferenceException)
            {
                return;
            }
        }





        public void DataSwap(Node one, Node two)
        {
            Room temp1 = new Room();
            Room temp2 = new Room();

            temp1 = one.room;
            temp2 = two.room;

            Console.WriteLine("Swapping" + temp1 + "With:" + temp2);

            one.room = temp2;
            two.room = temp1;
        }








        public void printList()
        /* Title: printList
         * Type: Void           
         * Class Summary: The printList function operates by establishing references to the rear and head locations on the Linked list.
         * From there it starts at the top of the list (head) and so long as the head isn't null, it will print the name of the room and then
         * iterate further down the list.             



         */


        {
            //Console.WriteLine("Head is " + " " + head.room.Name + "Rear is" + " " + rear.room.Name);
            Node n = new Node();
            Node p = new Node();

            p = rear;
            n = head;



            while (n != null)
            {
                Console.WriteLine("Printing.....");
                Console.WriteLine(n.room.Name + " ");
                //Console.WriteLine("previous is" + " " + n.previous.room.Name + "\n");
                //Console.WriteLine("next is" + " " + n.next.room.Name + "\n");
                n = n.next;

            }

        }




        public Node Search(bool selected)
        {


            Room room = new Room();

            if (head == null)

            {
                Console.WriteLine("Error -- Search, bool does not detect an initialized list");
                return null;

            }

            Node current = head;
            try
            {
                while (current != null)
                {


                    if (current.selected)
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
                    current = current.next;





                }
            }
            catch (ArgumentNullException e)
            {
                return null;
            }

            return null;




        }


        public Node Search(int x, int y)
        {


            Room room = new Room();

            if (head == null)

            {
                Console.WriteLine("Error -- Search X, Y, does not detect a  Linked List ");
                return null;

            }

            Node current = head;
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

                    current = current.next;

                }
                catch (NullReferenceException e)
                {
                    return null;
                }


            }

            return null;




        }

        public Node Search(String key)
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
            Room room = new Room();
            /*
              if (head == null)

              {
                  Console.WriteLine("Error -- Search string, does not detect an initialized list");
                  return head;

              }
              */

            Node current = head;
            while (current != null)
            {
                try
                {
                    //Console.WriteLine("HERE GOES SEARCHING FOR" + key);
                    if (current.room.Name == key)
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
                    current = current.next;




                }
                catch (NullReferenceException e)
                {
                    return head;
                }

            }
            return head;


        }

        public void Start(Room room)
        /* Title: Start
         * Arguments: room
         * Type: Void
         * Summary: The start function begins the linked list.              


        */
        {
            /*
             if (room.Dk_retriever(room.Deck) == null)
             {
                 return;
             }
             */

            Node node = new Node(room);
            node.next = null;
            node.previous = null;
            head = node;
            rear = node;

            //Console.WriteLine("Leaving start and and the head equals" + head.room.GetName());

        }



        public void Front_Add(Room room)
        {
            /*
            if (room.Dk_retriever(room.Deck) == null)
            {
                return;
            }
            */

            Node node = new Node(room);
            Node Header = new Node();
            Header = head;

            node.next = Header;
            node.previous = node;
            Header.previous = node;
            head = node;

            //Console.WriteLine("Okay I've replaced the head, my  next node is" + head.next.room.GetName());
        }

        public void Rear_Add(Room room)
        {

            try
            {
                if (head == null && rear == null)
                {
                    Start(room);
                    return;
                }
                Node node = new Node(room);
                Node end = rear;



                end.next = node;
                node.previous = end;
                node.next = null;
                rear = node;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("ERROR --- ROOM IS NULL");
            }
        }

        public void Delete(string Key)
        {

            Room room = new Room();

            if (head == null)

            {
                // Console.WriteLine("Error -- Linked List not initialized");


            }

            Node current = head;

            if (current == head && current == rear)
            {

                // Console.WriteLine("Error: Last node in the list");
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

                        head = current.next;

                    }

                    //If node to be deleted is rear node
                    if (rear == current)
                    {
                        rear = current.previous;

                    }
                    //Change next if Node to be deleted is not the last node
                    if (current.next != null)
                    {

                        current.next.previous = current.next;

                    }

                    if (current.previous != null)
                    {

                        current.previous.next = current.next;
                    }




                    return;
                }

                //Console.WriteLine("Here advancing the linker");

                current = current.next;


            }



        }



        public void Distance2(Node start, Node target)
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
            bool N_trigger = false;
            bool S_trigger = false;
            bool E_trigger = false;
            bool W_trigger = false;
            


            Node current = new Node();
            current = start;
            LinkedList Invalids = new LinkedList(current);

            System.Console.WriteLine("Starting with" + " " + current.room.Name + " " + "Ending with" + target.room.Name);

            while (current != target)
            {


                 N_trigger = false;
                 S_trigger = false;
                 E_trigger = false;
                 W_trigger = false;




                if (present(current))
                {
                    if(Bound_assessment('n', current))
                    {
                        N_trigger = true;
                        //Console.WriteLine("N Triggered");

                    }

                    if (Bound_assessment('s', current))
                    {
                        S_trigger = true;
                        //Console.WriteLine("S Triggered");
                    }

                    if(Bound_assessment('e', current))
                    {
                        E_trigger = true;
                        //Console.WriteLine("E Triggered");
                    }

                    if(Bound_assessment('w', current))
                    {
                        W_trigger = true;
                        //Console.WriteLine("W Triggered");

                    }
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
                            
                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine("Error in Invalids");
                        }

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
                                Console.WriteLine("Comparing Room Numbers:....");
                                Console.WriteLine(target.room.Name + "'s" + "  " + "Room number is of a higher level than" + " " + current.room.Name);
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
                                Console.WriteLine(target.room.Name + "'s" + "  " + "Room number is of a lower value than" + " " + current.room.Name);
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

                catch (ArgumentNullException)
                {

                }
                continue;
            }

        }


        public void Move2(Node Startpoint, Node Endpoint)
        {

            if (Endpoint != null)
            {
                Startpoint.selected = false;
                Endpoint.selected = true;

            }

        }

        public bool present (Node node)
        {
            if (Search(node.room.Name) == node)
            {
                return true;
            }

            else
                return false;
        }

        public bool Bound_assessment(char direction, Node current)
        {
            switch (direction)
            {
                case 'n':
                    if (current.North_Bound.Blocked == true || current.North_Bound.Locked == true)
                    {
                        return true;
                    }
                    else
                        return false;

                case 's':
                    if (current.South_Bound.Blocked == true || current.South_Bound.Locked == true)
                    {
                        return true;
                    }
                    else
                        return false;

                case 'w':
                    if (current.West_Bound.Blocked == true || current.West_Bound.Locked == true)
                    {
                        return true;
                    }
                    else
                        return false;
                case 'e':
                    if (current.East_Bound.Blocked == true || current.East_Bound.Locked == true)
                    {
                        return true;
                    }
                    else
                        return false;

                default:
                    return false;

            }

              
        }
            



            





        public Boundary BoundCheck2(char cardinal, Node desired)
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

                if (cardinal == 'n' && desired.South_Bound != null)
                {
                    try
                    {
                        // Console.WriteLine("Returning South Bound of:" + " " + desired.room.Name);
                        return desired.South_Bound;
                    }
                    catch (ArgumentNullException e)
                    {

                    }
                }
                if (cardinal == 's' && desired.North_Bound != null)
                {
                    if (desired.North_Bound != null)
                    {
                        try
                        {
                            // Console.WriteLine("Returning North Bound of:" + " " + desired.room.Name);
                            return desired.North_Bound;
                        }
                        catch (ArgumentNullException e)
                        {

                        }
                    }
                }
                if (cardinal == 'e' && desired.East_Bound != null)
                {
                    try
                    {
                        // Console.WriteLine("Returning East Bound of:" + " " + desired.room.Name);
                        return desired.West_Bound;
                    }
                    catch (ArgumentNullException e)
                    {

                    }
                }
                if (cardinal == 'w' && desired.West_Bound != null)
                {
                    try
                    {
                        // Console.WriteLine("Returning West Bound of:" + " " + desired.room.Name);
                        return desired.East_Bound;
                    }
                    catch (ArgumentNullException e)
                    {

                    }
                }



                Console.WriteLine("ERROR -- Something went terribly wrong with the Bound check");
                return new Boundary { Electric = true, Locked = true, Blocked = true };

            }
            catch (ArgumentNullException e)
            {

            }
            return new Boundary { Electric = true, Locked = true, Blocked = true };
        }




    }









}


 




