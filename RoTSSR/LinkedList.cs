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
    public class LinkedList : Node
    {

        public Node head { get; set; } //head of list
        public Node rear { get; set; } //rear of list
        

        public LinkedList() //constructor
        {
            head = null;
            rear = null;

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
            catch(ArgumentNullException e)
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
                catch(NullReferenceException e)
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

            if (head == null)

            {
                Console.WriteLine("Error -- Search string, does not detect an initialized list");
                return head;

            }

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
                catch(NullReferenceException e)
                {
                    return null;
                }

            }
            return null;


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
            catch(NullReferenceException e)
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







    }
}

 




