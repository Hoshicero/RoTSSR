﻿using System;
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
        public LinkedList Llist = new LinkedList();


        public StationCreator (int RmAmt, int DkAmt, int FlAmt)
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
            Rm_perfloor = ((RmAmt / DkAmt)/Fl_max);
            
            Creation();
            Roommaker(ref Llist);
            N_populator();

            //Sortv1();
        }


        public StationCreator() { }

        public String NneighborCalculations(ref Room Holder)

        {
            Room HolderRoom = new Room();
            HolderRoom = Holder;

           // Console.WriteLine("Activating" + " " + HolderRoom.Name + " " + "In Nneighbor");
            if (HolderRoom.North_Neighbor.Name == null || HolderRoom.North_Neighbor.Name == "X")
            {

                //Console.WriteLine("Hello" + "\n" + HolderRoom.North_Neighbor);
                /*IF YOU ARE ON THE TOP DECK ON THE TOP FLOOR, YOU HAVE NO NORTH*/



                if ((HolderRoom.Deck == Dk_min) && (HolderRoom.Floor == Fl_min))
                {
                    HolderRoom.North_Neighbor.Name = null;
                    //Console.WriteLine("Activating Node:" + " " + room.Name + "'s" + " N Neighbor" + HolderRoom.North_Neighbor + " " + " Dk = min & Fl = min");

                    return null;




                }

                /*OR IF you are on the highest floor of your deck,
                Your N_Neighbor will be equal to a string that is a concatenation of the result of your current Deck Minus one,
                 The Max Floor Control value, and your current room number. 
                 Ex: CurrentRoom is B123, B123's North Neighbor would be: (*B*(2) - 1) = (1)*A*), Fl_Max = 3, and 123 giving a total value of : A3123 *
                 */

                else if (HolderRoom.Floor == Fl_min)
                {

                    HolderRoom.North_Neighbor.Name = (String.Concat(Dk_retriever(HolderRoom.Deck - 1), Fl_max, HolderRoom.Num));
                    //Console.WriteLine("Activating Node:" + " " + room.Name + "'s" + " N Neighbor" + HolderRoom.North_Neighbor + " " + " Fl = min");

                    return String.Concat(Dk_retriever(HolderRoom.Deck - 1), Fl_max, HolderRoom.Num);

                }


                else //if (HolderRoom.Floor != Fl_min && HolderRoom.Deck != Dk_min)
                {

                    // Console.WriteLine(HolderRoom.North_Neighbor = (String.Concat(Dk_retriever(HolderRoom.Deck), (HolderRoom.Floor - 1), HolderRoom.Num)));
                    //Console.WriteLine("Activating Node:" + " " + room.Name + "'s" + " N Neighbor" + HolderRoom.North_Neighbor + " " + "else...");


                    //Console.WriteLine("TAAAAg" + HolderRoom.Name + " " + HolderRoom.North_Neighbor);

                    //OTHERWISE YOUR NORTH NEIGHBOR CONSISTS OF YOUR DECK, YOUR FLOOR - 1, AND YOUR CURRENT ROOM NUMBER.
                    HolderRoom.North_Neighbor.Name = String.Concat(Dk_retriever(HolderRoom.Deck), HolderRoom.Floor - 1, HolderRoom.Num);
                    return String.Concat(Dk_retriever(HolderRoom.Deck), HolderRoom.Floor - 1, HolderRoom.Num);
                    
                }
            }

            else
                HolderRoom.North_Neighbor.Name = String.Concat(Dk_retriever(HolderRoom.Deck), HolderRoom.Floor - 1, HolderRoom.Num);
            return (String.Concat(Dk_retriever(HolderRoom.Deck), HolderRoom.Floor - 1, HolderRoom.Num));



        }


        public String SneighborCalculations(ref Room HolderRoom)
        {
            if (HolderRoom.South_Neighbor.Name == "X" || HolderRoom.South_Neighbor.Name == null)
            {

                /*IF YOU ARE THE LOWEST DECK ON THE LOWEST FLOOR, YOU HAVE NO SOUTH NEIGHBOR*/
                if ((HolderRoom.Deck == Dk_max) && (HolderRoom.Floor == Fl_max))
                {

                    
                    HolderRoom.South_Neighbor.Name = null;

                    return null;


                }
                /*IF YOU HAPPEN TO BE ON THE FLOOR OF A DECK RIGHT ABOVE THE TOP FLOOR OF ANOTHER DECK */
                else if (HolderRoom.Floor == Fl_max)
                {
                    HolderRoom.South_Neighbor.Name = (String.Concat(Dk_retriever(HolderRoom.Deck + 1), Fl_min, HolderRoom.Num));
                    return String.Concat(Dk_retriever(HolderRoom.Deck + 1), Fl_min, HolderRoom.Num);
                }

                else
                HolderRoom.South_Neighbor.Name = (String.Concat(Dk_retriever(HolderRoom.Deck), (HolderRoom.Floor + 1), HolderRoom.Num));
                return String.Concat(Dk_retriever(HolderRoom.Deck), (HolderRoom.Floor + 1), HolderRoom.Num);

            }

            else
            HolderRoom.South_Neighbor.Name = (String.Concat(Dk_retriever(HolderRoom.Deck), (HolderRoom.Floor + 1), HolderRoom.Num));
            return String.Concat(Dk_retriever(HolderRoom.Deck), (HolderRoom.Floor + 1), HolderRoom.Num);
        }


        public String WneighborCalculations(ref Room HolderRoom)
        {

            if (HolderRoom.West_Neighbor.Name == "X" || HolderRoom.West_Neighbor.Name == null)
            {

                /*IF YOU ARE THE Last ROOM ON YOUR FLOOR, YOU HAVE NO West NEIGHBOR*/
                if (HolderRoom.Num == Rm_perfloor)
                {


                    HolderRoom.West_Neighbor.Name = null;
                    return null;

                }


                else
                    HolderRoom.West_Neighbor.Name = (String.Concat(Dk_retriever(HolderRoom.Deck), HolderRoom.Floor, HolderRoom.Num + 1));
                return String.Concat(Dk_retriever(HolderRoom.Deck), HolderRoom.Floor, HolderRoom.Num + 1);

            }
            else

            HolderRoom.West_Neighbor.Name = String.Concat(Dk_retriever(HolderRoom.Deck), HolderRoom.Floor, HolderRoom.Num + 1);
            return String.Concat(Dk_retriever(HolderRoom.Deck), HolderRoom.Floor, HolderRoom.Num + 1);

        }


        public String EneighborCalculations(ref Room HolderRoom)
        {


            if (HolderRoom.East_Neighbor.Name == "X" || HolderRoom.East_Neighbor.Name == null)
            {

                /*IF YOU ARE THE First ROOM ON YOUR FLOOR, YOU HAVE NO EAST NEIGHBOR*/
                if (HolderRoom.Num == Rm_min)
                {

                    
                    HolderRoom.East_Neighbor.Name = null;
                    return null;

                }


                else
                 HolderRoom.East_Neighbor.Name = (String.Concat(Dk_retriever(HolderRoom.Deck), HolderRoom.Floor, HolderRoom.Num - 1));
                return String.Concat(Dk_retriever(HolderRoom.Deck), HolderRoom.Floor, HolderRoom.Num - 1);


            }

            else
            HolderRoom.East_Neighbor.Name = (String.Concat(Dk_retriever(HolderRoom.Deck), HolderRoom.Floor, HolderRoom.Num - 1));
            return String.Concat(Dk_retriever(HolderRoom.Deck), HolderRoom.Floor, HolderRoom.Num - 1);


        }

        public void Roommaker(ref LinkedList Llist)
        {
            


            Node current = Llist.head;

            while (current != null)
            {

                try
                {
                current.North_Neighbor.Name = NneighborCalculations(ref current.room);
                current.South_Neighbor.Name = SneighborCalculations(ref current.room);
                //Console.WriteLine("South: " + current.South_Neighbor);
                current.East_Neighbor.Name = EneighborCalculations(ref current.room);
                //Console.WriteLine("East: " + current.East_Neighbor);
                current.West_Neighbor.Name = WneighborCalculations(ref current.room);
                //Console.WriteLine("West: " + current.West_Neighbor);

                current.N_node = Llist.Search(current.North_Neighbor.Name);
                current.S_node = Llist.Search(current.South_Neighbor.Name);
                current.E_node = Llist.Search(current.East_Neighbor.Name);
                current.W_node = Llist.Search(current.West_Neighbor.Name);
             
                    //Console.WriteLine("Node:" + " " + current.room.Name + " " + "North: " + current.N_node.room.Name);
                    //Console.WriteLine("Node:" + " " + current.room.Name + " " + "South: " + current.S_node.room.Name);
                   // Console.WriteLine("Node:" + " " + current.room.Name + " " + "East: " + current.E_node.room.Name);
                    //Console.WriteLine("Node:" + " " + current.room.Name + " " + "West: " + current.W_node.room.Name);








                    current = current.next;
                    /*
                     NneighborCalculations(Rom);
                     SneighborCalculations(Rom);
                     EneighborCalculations(Rom);
                     WneighborCalculations(Rom);
                     */

                }
                catch(NullReferenceException)
                {
                    current = current.next;

                }

            }

        }


        public void Creation ()
        {
            
            
            for(int x = Dk_max; x >= Dk_min; x--)
            {
                
                for (int y = Fl_max; y >= Fl_min; y--)
                {
                    
                    for (int z = 0; z <= Rm_perfloor; z++)
                    {
                        //Console.WriteLine(x + " " + y + " " + z);
                        Llist.Rear_Add(new Room((z),y,x)); 


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
            List<Room> columns = new List<Room>();
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

            foreach (Room column in columns)
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
            Node current = new Node();
            current = Llist.head;

            while(current != null)
            {

                //Console.WriteLine(current.room.Name);
                current = current.next;
            }


        } 

        public void D_Console(int x, int y)
        {


        }




        public void Drawer(String data)
        {
            Console.Clear();
            Node current = new Node();
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
                    current.N_node = Llist.Search(current.room.North_Neighbor.Name);
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

                    current.S_node = Llist.Search(current.room.South_Neighbor.Name);
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

                    current.E_node = Llist.Search(current.room.East_Neighbor.Name);
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

                    current.W_node = Llist.Search(current.room.West_Neighbor.Name);
                    //System.Console.WriteLine("West_N" + " " + current.west.room.Name);
                    current = current.next;
                }
                catch (NullReferenceException w)
                {
                    continue;
                    //Console.WriteLine("ERROR --- No:" + " " + "West");
                }

                /*
                try
                {
                    current = current.previous;
                }
                catch (NullReferenceException x)
                {
                    return;
                }
                */
            }
        }


    }
 



}








    




