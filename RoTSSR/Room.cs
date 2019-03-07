using System;
namespace ConsoleApp1
{
    /* The Room class is a container for the information of a particular room.
     * 
     * ******Variables******
     * 
     * 
     *  RoomType <-> THe RoomType variable holds a single int representation of one of the six RoomTypes: '0' = Accessway, '1' = Accomodations,
     * '2' = Corridor, '3' = Industrial, '4' = Service.
     * 
     *  Name <-> The Name variable holds the ID of the Room's Name.
     * 
     *
     * 
     *  Next_U\D\L\R <-> The Next_* variables of type String store the ID of a neighboring Room specific to the implicit rooms adjacency to   
     * that particular neighbor: 'U' = Up, 'D' = Down, 'L' = Left, 'R' = Right.
     * 
     *  Up, Down, Left, Right <-> These variables are of an object class named boundary, and refer to each of the four locational
     * boundary types of a given room: 'Door', 'Bulkhead', 'Deck Boundary'.
     * 
     * 
     ******Methods******
     * Setters()
     * Getters()
     *
     *
     * SetAllBounds <-> The SetAllBounds method takes 20 variables, every five out of the 20, data to be fed into the appropriate Boundary variable. 
     * The SetAllBounds method does this by calling the SetBoundary function a total of four times for the four Boundary variables. 
     * 
     *
     *


    */



    public class Room
    {

        
        public int RoomType;
        public int Deck { get; set; }
        public int Num { get; set; }
        public int Floor { get; set;}
        private String Name;
        private String North_Neighbor;
        private String South_Neighbor;
        private String East_Neighbor ;
        private String West_Neighbor ;
        
        

        private Boundary NorthBound;
        private Boundary SouthBound;
        private Boundary EastBound;
        private Boundary WestBound;



        public void SetName(String N) { Name = N; }

        public void SetRoomtype(Char R) { RoomType = R; }

        public void SetNorth_Neighbor(String Temp) { North_Neighbor = Temp; }

        public void SetSouth_Neighbor(String Temp) { South_Neighbor = Temp; }

        public void SetEast_Neighbor(String Temp) { East_Neighbor = Temp; }

        public void SetWest_Neighbor(String Temp) { West_Neighbor = Temp; }



        public String GetName() { return Name; }

        public int GetRoomType() { return RoomType; }

        public String GetNeighbor_N() { return North_Neighbor; }

        public String GetNeighbor_S() { return South_Neighbor; }

        public String GetNeighbor_E() { return East_Neighbor; }

        public String GetNeighbor_W() { return West_Neighbor; }

        public Boundary GetBoundary(char Direction)
        {

            switch (Direction)
            {
                case 'N':
                    return NorthBound;

                case 'S':
                    return SouthBound;

                case 'E':
                    return EastBound;

                case 'W':
                    return WestBound;


            }

            return null;

        }

        public Room (int num, int fl, int deck)
        {

            Num = num;
            Floor = fl;
            Deck = deck;

        }
        
        public Room()
        {

           // Name = null;
            North_Neighbor = null;
            South_Neighbor = null;
            East_Neighbor = null;
            West_Neighbor = null;

            NorthBound = new Boundary('N', false, false, false, false);
            SouthBound = new Boundary('S', false, false, false, false);
            EastBound = new Boundary('E', false, false, false, false);
            WestBound = new Boundary('W', false, false, false, false);


        }


        public void Roomer()
        {

            Name = null;
            North_Neighbor = null;
            South_Neighbor = null;
            East_Neighbor = null;
            West_Neighbor = null;

            NorthBound = new Boundary('N', false, false, false, false);
            SouthBound = new Boundary('S', false, false, false, false);
            EastBound = new Boundary('E', false, false, false, false);
            WestBound = new Boundary('W', false, false, false, false);


        }

        public Room(String Na, String NN, String NS, String NE, String NW)
        {

            Name = Na;
            North_Neighbor = NN;
            South_Neighbor = NS;
            East_Neighbor = NE;
            West_Neighbor = NW;


            NorthBound = new Boundary('N', false, false, false, false);
            SouthBound = new Boundary('S', false, false, false, false);
            EastBound = new Boundary('E', false, false, false, false);
            WestBound = new Boundary('W', false, false, false, false);



        }

    
       



    }
    public class Llist
    {
       public Node head { get; set; } //head of list
       public  Node rear { get; set; } //rear of list
        public Llist()
        {
            head = new Node();
            rear = new Node();

        }

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
        public void printList()
        {
            Node n = new Node();  
            Node p = new Node();

            p = rear;
            n = head;

            while (n != null)
            {
                Console.WriteLine("Printing.....");
                Console.WriteLine(n.room.GetName() + " ");
                n = n.next;
                
            }
           
        }

        public Room Search(String key)
        {
            
            Room room = new Room();

            if(head == null)

            {
                Console.WriteLine("Error -- Linked List not initialized");
                return room;

            }

            Node current = head;
            while (current != null)
            {
                
                if (current.room.GetName() == key)
                {
                    Console.WriteLine("The Name is" + current.room.GetName());
                    Console.WriteLine("The North Neighbor is" + current.room.GetNeighbor_N());
                    Console.WriteLine("The South Neighbor is" + current.room.GetNeighbor_S());
                    Console.WriteLine("The East Neighbor is" + current.room.GetNeighbor_E());
                    Console.WriteLine("The West Neighbor is" + current.room.GetNeighbor_W());

                    return current.room;
                }

                if (current.next != null)
                {
                    current = current.next;
                }
                else
                    break;
                   

            }

            return new Room();


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

                if (current.room.GetName() == Key)
                {

                    //Base Case

                    if(head == null)
                    {
                        return;
                    }

                    //If node to be deleted is head node

                    if(head == current)
                    {

                        head = current.next;

                    }

                    //If node to be deleted is rear node
                    if(rear == current)
                    {
                        rear = current.previous;

                    }
                    //Change next if Node to be deleted is not the last node
                    if(current.next != null)
                    {

                        current.next.previous = current.next;

                    }

                    if(current.previous != null)
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




