using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoTSSR
{



    /***Linked List
     * Cameron Robinson 3/17/19
     * Class Summary: The LinkedList class is a class that is responsible for facilitating and performing operations on the LinkedList it generates. 
     * Variables: 
     *--head-- is of class Node and represents the head of the linked list. 
     *--rear-- is of class rear and points to the rear of the linked list.
     * 
     * 
     * 
     *
      */
    public class LinkedList
    {


        public Node head { get; set; } //head of list
        public Node rear { get; set; } //rear of list
        public LinkedList() //constuructor
        {
            head = new Node();
            rear = new Node();

        }


        public void printList()



        {
            Node n = new Node();
            Node p = new Node();

            p = rear;
            n = head;



            while (n != null)
            {
                Console.WriteLine("Printing.....");
                Console.WriteLine(n.room.Name + " ");
                n = n.next;

            }

        }




    



        public Node Search(String key)
        {

            Room room = new Room();

            if (head == null)

            {
                Console.WriteLine("Error -- Linked List not initialized");
                return head;

            }

            Node current = head;
            while (current != null)
            {

                if (current.room.Name == key)
                {
                    Console.WriteLine("The Name is" + current.room.Name);
                    Console.WriteLine("The North Neighbor is" + current.room.North_Neighbor);
                    Console.WriteLine("The South Neighbor is" + current.room.South_Neighbor);
                    Console.WriteLine("The East Neighbor is" + current.room.East_Neighbor);
                    Console.WriteLine("The West Neighbor is" + current.room.West_Neighbor);

                    return current;
                }

                if (current.next != null)
                {
                    current = current.next;
                }
                else
                    break;


            }

            return current;


        }

        public void Start(Room room)
        {

            Node node = new Node(room);
            head = node;
            rear = node;
            //Console.WriteLine("Leaving start and and the head equals" + head.room.GetName());

        }

        public void Front_Add(Room t_room)
        {
            Node node = new Node(t_room);
            Node Header = head;

            node.next = head;
            Header.previous = node;
            head = node;

            //Console.WriteLine("Okay I've replaced the head, my  next node is" + head.next.room.GetName());
        }

        public void Rear_Add(Room room)
        {
            Node node = new Node(room);
            Node end = rear;

            end.next = node;
            node.previous = end;
            node.next = null;
            rear = node;
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

 




