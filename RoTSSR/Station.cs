using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoTSSR
{
    public class Station : Screen_Draw
    {
        public int Rm_max { get; set; }
        public int Rm_min { get; set; }
        public int Dk_max { get; set; }
        public int Dk_min { get; set; }
        public int Fl_max { get; set; }
        public int Fl_min { get; set; }
        public int Rm_perfloor { get; set; }

        public int Rm_container { get; set; }
        public int Fl_container { get; set; }
        public int Dk_container { get; set; }
        public Station() { }




    }

    public class StationCreator : Station
    {
        public RoomList Llist = new RoomList();


        public StationCreator(int RmAmt, int DkAmt, int FlAmt)
        {
            Rm_max = RmAmt;
            Dk_max = DkAmt;
            Fl_max = FlAmt;
            Rm_min = 0;
            Dk_min = 1;
            Fl_min = 1;
            Rm_container = Rm_min;
            Dk_container = Dk_max;
            Fl_container = Fl_max;
            Rm_perfloor = ((RmAmt / DkAmt) / Fl_max);

            Creation();
            Roommaker(Llist);
            //N_populator();




            //Sortv1();
        }


        public StationCreator() { }

        public void NneighborCalculations(Room_Node HolderRoom)

        {
            //Room_Node HolderRoom = new Room_Node();
            //HolderRoom = Holder;

            // Console.WriteLine("Activating" + " " + HolderRoom.Name + " " + "In Nneighbor");
            if (HolderRoom.N_node == null)
            {

                //Console.WriteLine("Hello" + "\n" + HolderRoom.North_Neighbor);
                /*IF YOU ARE ON THE TOP DECK ON THE TOP FLOOR, YOU HAVE NO NORTH*/



                if ((HolderRoom.room.Deck == Dk_min) && (HolderRoom.room.Floor == Fl_min))
                {
                    
                    //Console.WriteLine("Activating Node:" + " " + room.Name + "'s" + " N Neighbor" + HolderRoom.North_Neighbor + " " + " Dk = min & Fl = min");

                    return;




                }

                /*OR IF you are on the highest floor of your deck,
                Your N_Neighbor will be equal to a string that is a concatenation of the result of your current Deck Minus one,
                 The Max Floor Control value, and your current room number. 
                 Ex: CurrentRoom is B123, B123's North Neighbor would be: (*B*(2) - 1) = (1)*A*), Fl_Max = 3, and 123 giving a total value of : A3123 *
                 */

                else if (HolderRoom.room.Floor == Fl_min)
                {
                    try
                    {
                        HolderRoom.N_node = Llist.Search((String.Concat(HolderRoom.room.Dk_retriever(HolderRoom.room.Deck - 1), Fl_max, HolderRoom.room.Num)));
                        //Console.WriteLine("Activating Node:" + " " + room.Name + "'s" + " N Neighbor" + HolderRoom.North_Neighbor + " " + " Fl = min");
                    }
                    catch (NullReferenceException)
                    {

                    }
                    return;

                }


                else //if (HolderRoom.Floor != Fl_min && HolderRoom.Deck != Dk_min)
                {

                    // Console.WriteLine(HolderRoom.North_Neighbor = (String.Concat(Dk_retriever(HolderRoom.Deck), (HolderRoom.Floor - 1), HolderRoom.Num)));
                    //Console.WriteLine("Activating Node:" + " " + room.Name + "'s" + " N Neighbor" + HolderRoom.North_Neighbor + " " + "else...");


                    //Console.WriteLine("TAAAAg" + HolderRoom.Name + " " + HolderRoom.North_Neighbor);

                    //OTHERWISE YOUR NORTH NEIGHBOR CONSISTS OF YOUR DECK, YOUR FLOOR - 1, AND YOUR CURRENT ROOM NUMBER.
                    HolderRoom.N_node = Llist.Search(String.Concat(HolderRoom.room.Dk_retriever(HolderRoom.room.Deck), HolderRoom.room.Floor - 1, HolderRoom.room.Num));
                    return;

                }
            }

            else
            HolderRoom.N_node = Llist.Search(String.Concat(HolderRoom.room.Dk_retriever(HolderRoom.room.Deck), HolderRoom.room.Floor - 1, HolderRoom.room.Num));
            return;



        }

        public void SneighborCalculations(Room_Node HolderRoom)
        {
            if (HolderRoom.S_node == null)
            {

                //IF YOU ARE THE LOWEST DECK ON THE LOWEST FLOOR, YOU HAVE NO SOUTH NEIGHBOR
                if ((HolderRoom.room.Deck == Dk_max) && (HolderRoom.room.Floor == Fl_max))
                {


                   
                    return ;


                }
                //IF YOU HAPPEN TO BE ON THE FLOOR OF A DECK RIGHT ABOVE THE TOP FLOOR OF ANOTHER DECK 
                else if (HolderRoom.room.Floor == Fl_max)
                {
                    HolderRoom.S_node = Llist.Search((String.Concat(HolderRoom.room.Dk_retriever(HolderRoom.room.Deck + 1), Fl_min, HolderRoom.room.Num)));
                    return;
                }

                else
                    HolderRoom.S_node =  Llist.Search((String.Concat(HolderRoom.room.Dk_retriever(HolderRoom.room.Deck), (HolderRoom.room.Floor + 1), HolderRoom.room.Num)));
                return;

            }

            else
                HolderRoom.S_node = Llist.Search((String.Concat(HolderRoom.room.Dk_retriever(HolderRoom.room.Deck), (HolderRoom.room.Floor + 1), HolderRoom.room.Num)));
            return;
        }

        public void WneighborCalculations(Room_Node HolderRoom)
        {

            if (HolderRoom.W_node == null)
            {

                //IF YOU ARE THE First ROOM ON YOUR FLOOR, YOU HAVE NO West NEIGHBOR
                if (HolderRoom.room.Num == Rm_min)
                {     
                  return;
                }
                else
                HolderRoom.W_node = Llist.Search((String.Concat(HolderRoom.room.Dk_retriever(HolderRoom.room.Deck), HolderRoom.room.Floor, HolderRoom.room.Num - 1)));
                return;

            }
            else
            HolderRoom.W_node = Llist.Search(String.Concat(HolderRoom.room.Dk_retriever(HolderRoom.room.Deck), HolderRoom.room.Floor, HolderRoom.room.Num - 1)));
            return;

        }
        
        public void EneighborCalculations(Room_Node HolderRoom)
        {
            if (HolderRoom.E_node == null)
            {
                //IF YOU ARE THE Last ROOM ON YOUR FLOOR, YOU HAVE NO EAST NEIGHBOR
                if (HolderRoom.room.Num == Rm_max)
                {

                    return;

                }


                else
                    HolderRoom.E_node = Llist.Search((String.Concat(HolderRoom.room.Dk_retriever(HolderRoom.room.Deck), HolderRoom.room.Floor, HolderRoom.room.Num + 1)));
                return;
            }

            else
                HolderRoom.E_node = Llist.Search((String.Concat(HolderRoom.room.Dk_retriever(HolderRoom.room.Deck), HolderRoom.room.Floor, HolderRoom.room.Num + 1)));
            return;


        }







        public void Roommaker(RoomList Llist)
        {

            Room_Node current = Llist.head;

            while (current != null)
            {

                try
                {
                    NneighborCalculations(current);
                    SneighborCalculations(current);
                    EneighborCalculations(current);
                    WneighborCalculations(current);
                }


                catch (NullReferenceException)
                {
                    current = current.Next;

                }

                finally
                {
                    current = current.Next;

                }

            }


        }


        public void Creation()
        {


            for (int x = Dk_max; x >= Dk_min; x--)
            {

                for (int y = Fl_max; y >= Fl_min; y--)
                {

                    for (int z = 0; z <= Rm_perfloor; z++)
                    {
                        //Console.WriteLine(x + " " + y + " " + z);
                        Llist.Rear_Add(new Room_Node(new Room ((z), y, x)));


                    }

                }


            }




        }

        public void PrintNodes2()
        {
            for (int i = 3; i >= this.Dk_max; i--)
            {
                for (int k = 1; k <= this.Rm_max; k++)
                {


                }

            }

        }
        /*
        public void PrintNodes()
        {
            List<Room_Node> columns = new List<Room_Node>();
            int tableWidth = this.Rm_max;

            int temp = 0;

            Node n = new Node();
            Node p = new Node();

            p = Llist.rear;
            n = Llist.head;
            /*
             while (n != null)
             {

                 columns.Add(n.room.GetName());
                 n = n.next;


             }
             

            while (p != null)
            {

                columns.Add(p.room);
                p = p.previous;


            }



            int width = (tableWidth - columns.ToArray().Length) / columns.ToArray().Length;
            //int width = this.Rm_max;
            /*
            Console.WriteLine("tableWidth" + tableWidth);
            Console.WriteLine("columns.toarray" + columns.ToArray().Length);
            Console.WriteLine("Equation" + (tableWidth - columns.ToArray().Length / columns.ToArray().Length));
            
            string row = "|";

            foreach (Room_Node column in columns)
            {


                if (temp == Rm_perfloor)
                {
                    temp = 0;
                    if (column.selected)
                    {
                        row += AlignCentreNode("*", width) + "|" + "\n";
                        // return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
                    }
                   
                    else
                        row += AlignCentreNode(column.Name, width) + "|" + "\n";

                }
                else
                {
                    try
                    {
                        if (column.selected == null);



                    }
                    catch(Exception ne)
                    {
                        continue; //skips the rest
                    }

                    //temp++;
                    if (column.selected)
                    {
                        row += AlignCentreNode("*", width) + "|";

                        Console.WriteLine("\n");
                        Console.WriteLine("\n");
                        Console.WriteLine("Name:" + " " + column.Name + "\n");
                        Console.WriteLine("North:" + " " + column.North_Neighbor + "\n");
                        Console.WriteLine("South:" + " " + column.South_Neighbor + "\n");
                        Console.WriteLine("East:" + " " + column.East_Neighbor + "\n");
                        Console.WriteLine("West:" + " " + column.West_Neighbor + "\n");


                        column.selected = false;
                    }
                    else
                        row += AlignCentreNode(column.Name, width) + "|";

                }




            }



            Console.WriteLine(row);
           
        }
        */

        public static string AlignCentreNode(string text, int width)
        {


            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {

                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);

            }

        }


        public void Harbor()
        {
           Room_Node current = new Room_Node();
            current = Llist.head;

            while (current != null)
            {

                //Console.WriteLine(current.room.Name);
                current = current.Next;
            }


        }

        public void D_Console(int x, int y)
        {


        }



        /*
        public void Drawer(String data)
        {
            Console.Clear();
            Room_Node current = new Room_Node();
            current = Llist.rear;

            origRow = Console.CursorTop;
            origCol = Console.CursorLeft;

            try
            {

                for (int row = 0; row < (Fl_max * Dk_max); row++) // - 9
                {
                    for (int col = 0; col <= Rm_perfloor; col++)// - 4
                    {
                        //current.Xcord = col * 4;
                        current.Xcord = col * 2;
                        current.Ycord = row;



                        if (current.selected)
                        {
                            WriteAt("-", current.Xcord, current.Ycord);
                            current = current.previous;
                        }

                        else
                        {
                            try
                            {

                                //WriteAt(current.room.Name, current.Xcord, current.Ycord);
                                WriteAt(data, current.Xcord, current.Ycord);
                                current = current.previous;
                            }
                            catch (NullReferenceException e)
                            {
                                System.Console.WriteLine("error -- Current.next is null");

                            }

                        }
                    }



                }

                Node node = Llist.Search(true);
                try
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("Node" + " " + node.room.Name);
                }
                catch (NullReferenceException e) { }
                try
                {
                    Console.WriteLine("North:" + " " + node.N_node.room.Name);
                    //WriteAt("Node:" + " " +  node.room.Name, 0, Llist.head.Ycord + 1);
                    //Console.WriteLine("\n");
                    //WriteAt("North:" + " " + node.N_node.room.Name, 0, Llist.head.Ycord + 2);
                }
                catch (NullReferenceException e) { }
                try
                {
                    Console.WriteLine("South:" + " " + node.S_node.room.Name);
                    //WriteAt("South:" + " " + node.S_node.room.Name, 0, Llist.rear.Ycord + 11);
                }
                catch (NullReferenceException e) { }
                try
                {
                    //WriteAt("East:" + " " +  Llist.Search(true).E_node.room.Name, 0, Llist.rear.Ycord + 30);
                    Console.WriteLine("East:" + " " + node.E_node.room.Name);
                    //WriteAt("West:" + " " +  Llist.Search(true).W_node.room.Name, 0, Llist.rear.Ycord + 15);
                }
                catch (NullReferenceException e) { }
                try
                {
                    //WriteAt("West:" + " " +  Llist.Search(true).W_node.room.Name, 0, Llist.rear.Ycord + 15);
                    Console.WriteLine("West:" + " " + node.W_node.room.Name);
                }
                catch (NullReferenceException e)
                {
                    //System.Console.WriteLine("ERROR ----");

                }





            }
            catch (NullReferenceException t)
            {
                System.Console.WriteLine("error -- current is a null value");
                //return;
            }



        }

*/



/*
        public void N_populator()
        {
            Node current = new Node();
            current = Llist.head;
            while (current != null)

            {
                //Console.WriteLine(current.room.Name);
                try
                {

                    //Console.WriteLine(current.room.Name + " " + current.room.North_Neighbor);

                    // Console.WriteLine(current.room.Name);
                    current.N_node = Llist.Search(current.room.North_Neighbor);
                    //System.Console.WriteLine("North_N" + " " + current.north.room.Name);
                    current = current.next;
                }
                catch (NullReferenceException n)
                {
                    Console.WriteLine("ERROR --- No:" + " " + "North");
                    continue;

                }
                try
                {
                    //Console.WriteLine(current.room.Name);

                    current.S_node = Llist.Search(current.room.South_Neighbor);
                    //System.Console.WriteLine("South_N" + " " + current.south.room.Name);
                    current = current.next;
                }
                catch (NullReferenceException s)
                {
                    continue;
                    //Console.WriteLine("ERROR --- No:" + " " + "South");
                }


                try
                {
                    //Console.WriteLine(current.room.Name + " " + current.room.East_Neighbor);

                    current.E_node = Llist.Search(current.room.East_Neighbor);
                    //System.Console.WriteLine("East_N" + " " + current.east.room.Name);
                    current = current.next;
                }
                catch (NullReferenceException e)
                {
                    continue;
                    //Console.WriteLine("ERROR --- No:" + " " + "East");
                }


                try
                {
                    //Console.WriteLine(current.room.Name);

                    current.W_node = Llist.Search(current.room.West_Neighbor);
                    //System.Console.WriteLine("West_N" + " " + current.west.room.Name);
                    current = current.next;
                }
                catch (NullReferenceException w)
                {
                    continue;
                    //Console.WriteLine("ERROR --- No:" + " " + "West");
                }

                
                try
                {
                    current = current.previous;
                }
                catch (NullReferenceException x)
                {
                    return;
                }
                
            }
        }
*/

        /*Djikstra's Algorithm 
         * 
         * 1.) Mark all rooms as unvisited, create unvisited list.
         * 2.) Assign each room a distance value. Set to zero for our initial node.
         * 3.)
         * 
         * *
         * 
         *
         
             
             */


/*
        public void Distance(ref Node start, ref Node target)
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



            Node current = new Node();
            current = start;
            System.Console.WriteLine("Starting with" + " " + current.room.Name + " " + "Ending with" + target.room.Name);

            while (current != target)
            {
                try
                {
                    //Does the current.S_Node exist? If the desired South nodes, North boundary is NOT locked or NOT blocked -> Proceed
                    if (current.S_node != null)
                    {
                        Console.WriteLine("The S_Node of" + " " + current.room.Name + " " + "exists," + " it is: " + " " + current.S_node.room.Name);

                        if (BoundCheck('s', current.S_node).Locked == false || BoundCheck('s', current.S_node).Blocked == false)
                        {
                            Console.WriteLine("Entering" + " " + current.S_node.room.Name + " " + "from the south side of" + " " + current.room.Name + " Is possible ");

                            if (target.room.Deck > current.room.Deck)
                            {
                                Console.WriteLine("Comparing Decks:....");
                                Console.WriteLine(target.room.Name + "'s" + "  " + "Deck is of a lower level than" + " " + current.room.Name);
                                Console.WriteLine("\n");

                                Console.WriteLine("Traveling to" + " " + current.S_node.room.Name + " " + "from: " + " " + current.room.Name + " " + " as a result ");
                                Console.WriteLine("\n");

                                current = current.S_node;
                            }


                            else if (target.room.Floor > current.room.Floor)

                            {
                                Console.WriteLine("Comparing Floors:....");
                                Console.WriteLine(target.room.Name + "'s" + "  " + "Floor is of a lower level than" + " " + current.room.Name);
                                Console.WriteLine("\n");

                                Console.WriteLine("Traveling to" + " " + current.S_node.room.Name + " " + "from: " + " " + current.room.Name + " " + "as a result ");
                                Console.WriteLine("\n");

                                current = current.S_node;
                            }

                        }
                        else if (BoundCheck('s', current.S_node).Locked == true)
                        {


                            Console.WriteLine(current.S_node.room.Name + "'s" + " " + "North Node is locked" + " " + "Making travel from" + " " + current.room.Name + "'s" + " " + " South side, impossible.");


                        }
                        else if (BoundCheck('s', current.S_node).Blocked == true)
                        {
                            Console.WriteLine(current.S_node.room.Name + "'s" + " " + "North Node is blocked" + " " + "Making travel from" + " " + current.room.Name + "'s" + " " + " South side, impossible.");
                        }
                    }
                    //If the desired north nodes, South boundary is NOT locked or NOT blocked -> Proceed.
                    if (current.N_node != null)
                      {
                        Console.WriteLine("The N_Node of" + " " + current.room.Name + " " + "exists," + " it is: " + " " + current.N_node.room.Name);

                        if (BoundCheck('n', current.N_node).Locked == false || BoundCheck('n', current.N_node).Blocked == false)
                        {
                            Console.WriteLine("Entering" + " " + current.N_node.room.Name + " " + "from the north side of" + " " + current.room.Name + " Is possible ");

                            if (target.room.Deck < current.room.Deck)
                            {
                                Console.WriteLine("Comparing Decks:....");
                                Console.WriteLine(target.room.Name + "'s" + "  " + "Deck is of a higher level than" + " " + current.room.Name);
                                Console.WriteLine("Traveling to" + " " + current.N_node.room.Name + " " + "from: " + " " + current.room.Name + "as a result ");

                                current = current.N_node;
                            }
                            else if (target.room.Floor < current.room.Floor)
                            {
                                Console.WriteLine("Comparing Floors:....");
                                Console.WriteLine(target.room.Name + "'s" + "  " + "Floor is of a higher level than" + " " + current.room.Name);
                                Console.WriteLine("\n");

                                Console.WriteLine("Traveling to" + " " + current.N_node.room.Name + " " + "from: " + " " + current.room.Name + "as a result ");
                                Console.WriteLine("\n");

                                current = current.N_node;
                            }
                        else if (BoundCheck('n', current.N_node).Locked == true)
                        {
                            Console.WriteLine(current.N_node.room.Name + "'s" + " " + "South Node is locked" + " " + "Making travel from" + " " + current.room.Name + "'s" + " " + " North side, impossible.");

                        }
                        else if (BoundCheck('n', current.N_node).Blocked == true)
                            {
                              Console.WriteLine(current.N_node.room.Name + "'s" + " " + "South Node is blocked" + " " + "Making travel from" + " " + current.room.Name + "'s" + " " + " North side, impossible.");

                            }

                        }

                    if (target.room.Deck == current.room.Deck)
                    {
                        Console.WriteLine(target.room.Name + "'s" + "  " + "Deck is of a level equal with" + " " + current.room.Name + "'s");
                        Console.WriteLine("Because of this, I will compare the Floor value");

                        if (target.room.Floor == current.room.Floor)
                        {

                            Console.WriteLine( target.room.Name + "'s" + "  " + "Floor is of a level equal with" + " " + current.room.Name + "'s");


                            if (current.W_node != null)
                            {
                                Console.WriteLine("The W_Node of" + " " + current.room.Name + " " + "exists," + " it is: " + " " + current.W_node.room.Name);

                                    //If the desired west nodes, East boundary is NOT locked or NOT blocked -> proceed. 
                                    if (BoundCheck('w', current.W_node).Locked == false || BoundCheck('w', current.W_node).Blocked == false)
                                    {
                                        Console.WriteLine("Entering" + " " + current.W_node.room.Name + " " + "from the East side of" + " " + current.room.Name + " Is possible ");

                                        if (target.room.Num > current.room.Num)
                                        {
                                            Console.WriteLine("Comparing Room_Node Numbers:....");
                                            Console.WriteLine(target.room.Name + "'s" + "  " + "Room_Node number is of a higher level than" + " " + current.room.Name);
                                            Console.WriteLine("\n");

                                            Console.WriteLine("Traveling to" + " " + current.W_node.room.Name + " " + "from: " + " " + current.room.Name + "as a result ");
                                            Console.WriteLine("\n");

                                            current = current.W_node;
                                        }


                                    }
                                    else if (BoundCheck('w', current.W_node).Locked == true)
                                    {
                                        Console.WriteLine(current.W_node.room.Name + "'s" + " " + "East Node is locked" + " " + "Making travel from" + " " + current.room.Name + "'s" + " " + " West side, impossible.");
                                    }
                                    else if(BoundCheck('w', current.W_node).Blocked == true)
                                    {
                                        Console.WriteLine(current.W_node.room.Name + "'s" + " " + "East Node is blocked" + " " + "Making travel from" + " " + current.room.Name + "'s" + " " + " West side, impossible.");
                                    }
                            }
                            if (current.E_node != null)
                            {
                                Console.WriteLine("The E_Node of" + " " + current.room.Name + " " + "exists," + " it is: " + " " + current.E_node.room.Name);

                                if (BoundCheck('e', current.E_node).Locked == false || BoundCheck('e', current.E_node).Blocked == false)
                                {
                                    if (target.room.Num < current.room.Num)
                                    {
                                            Console.WriteLine("Comparing Rooms:....");
                                            Console.WriteLine(target.room.Name + "'s" + "  " + "Room_Node number is of a lower value than" + " " + current.room.Name);
                                            Console.WriteLine("\n");
                                            Console.WriteLine("Traveling to" + " " + current.E_node.room.Name + " " + "from: " + " " + current.room.Name + "as a result ");
                                            Console.WriteLine("\n");
                                            current = current.E_node;
                                    }
                                   
                                }
                                else if (BoundCheck('e', current.E_node).Locked == true)
                                {


                                    Console.WriteLine(current.W_node.room.Name + "'s" + " " + "West Node is locked" + " " + "Making travel from" + " " + current.room.Name + "'s" + " " + " East side, impossible.");



                                }
                                else if (BoundCheck('e', current.E_node).Blocked == true)
                                        Console.WriteLine(current.W_node.room.Name + "'s" + " " + "West Node is locked" + " " + "Making travel from" + " " + current.room.Name + "'s" + " " + " East side, impossible.");

                            }
                        }
                    }
                   
                       

                    }
                }

                catch (ArgumentNullException)
                {

                }
                continue;
            }

        }

        */


/*
        public void Move(Node Startpoint, Node Endpoint)
        {

            if (Endpoint != null)
            {
                Startpoint.selected = false;
                Endpoint.selected = true;

            }

        }


*/

/*
        public void KeyListener()
        {
            String ky = null;
            bool quit = false;
            Node T_node = new Node();



            while (quit == false)

            {
                T_node = Llist.Search(true);
                ky = Console.ReadKey().KeyChar.ToString();


                if (ky == "w")
                {

                    //T_node = Station.Llist.Search(true);
                    try
                    {

                        Move(T_node, T_node.N_node);
                        //T_node.N_node.selected = true;
                        // Console.WriteLine(" " + "Yo" + T_node.N_node.selected);
                        //T_node.selected = false;
                        ////Console.WriteLine(Station.Llist.Search(true).room.Name);
                        //Console.WriteLine("All dat shit " + Llist.Search(T_node.N_node.room.Name).Name);
                        //Station.Drawer("*");
                    }
                    catch (NullReferenceException e)
                    {

                        Console.WriteLine("ERROR --- NO W");
                        Drawer("*");

                    }
                    //Console.Clear();
                    // Station.Drawer("*");


                }

                else if (ky == "s")
                {
                    T_node = Llist.Search(true);
                    try
                    {
                        Move(T_node, T_node.S_node);

                        //T_node.S_node.selected = true;
                        // Console.WriteLine(" " + "Yo" + T_node.N_node.selected);
                        //T_node.selected = false;
                        //Console.WriteLine(Station.Llist.Search(true).room.Name);
                        //Console.WriteLine("All dat shit " + Station.Llist.Search(T_node.N_node.room.Name).Name);
                        //Station.Drawer("*");
                    }
                    catch (NullReferenceException e)
                    {

                        //Console.WriteLine("ERROR --- NO ");
                        //Station.Drawer("*");

                    }
                    //Console.Clear();
                    // Station.Drawer("*");


                }

                else if (ky == "d")
                {
                    //T_node = Station.Llist.Search(true);
                    try
                    {
                        Move(T_node, T_node.E_node);

                        //T_node.E_node.selected = true;
                        // Console.WriteLine(" " + "Yo" + T_node.N_node.selected);
                        // T_node.selected = false;
                        //Console.WriteLine(Station.Llist.Search(true).room.Name);
                        //Console.WriteLine("All dat shit " + Station.Llist.Search(T_node.N_node.room.Name).Name);
                        //Station.Drawer("*");
                    }
                    catch (NullReferenceException e)
                    {

                        //Console.WriteLine("ERROR --- NO ");
                        //Station.Drawer("*");

                    }
                    //Console.Clear();
                    // Station.Drawer("*");


                }



                else if (ky == "a")
                {
                    T_node = Llist.Search(true);
                    try
                    {
                        Move(T_node, T_node.W_node);

                        //T_node.W_node.selected = true;
                        // Console.WriteLine(" " + "Yo" + T_node.N_node.selected);
                        //T_node.selected = false;
                        //Console.WriteLine(Station.Llist.Search(true).room.Name);
                        //Console.WriteLine("All dat shit " + Station.Llist.Search(T_node.N_node.room.Name).Name);
                        //Station.Drawer("*");
                    }
                    catch (NullReferenceException e)
                    {

                        //Console.WriteLine("ERROR --- NO ");
                        //Station.Drawer("*");

                    }
                    //Console.Clear();
                    // Station.Drawer("*");


                }

                else if (ky == "i")
                {
                    try
                    {
                        Console.WriteLine("North" + T_node.North_Neighbor);
                        Console.WriteLine("South" + T_node.South_Neighbor);
                        Console.WriteLine("East" + T_node.East_Neighbor);
                        Console.WriteLine("West" + T_node.West_Neighbor);
                    }
                    catch (NullReferenceException e) { }



                }



                else if (ky == "q")
                {
                    quit = true;


                }



                Drawer("*");

            }
            return;
        }


        */

/*
        public Boundary BoundCheck(char cardinal, Node desired)
        {
             1.) Check the desired node.
             2.) If the desired node is North -> Return the desired node's south boundary.
             3.) If the desired node is South -> Return the desired node's north boundary.
             4.) If the desired node is East -> Return the desired node's west boundary.
             5.) If the deisred node is West -> Return the desired node's east boundary.
             
              
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

    */


    }
    
}








    




