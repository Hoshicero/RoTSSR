using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoTSSR
{
    public class Station : Room
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
            Rm_perfloor = RmAmt / DkAmt;
            
            Creation();
            }

        public void NneighborCalculations(Room HolderRoom)

        {
            //Console.WriteLine("HELLO FROM NNEIGHBOR" + HolderRoom.GetNeighbor_N());
            /*"C1" Is a default value that I set to act as a gatekeeper*/

            if (HolderRoom.North_Neighbor == null || HolderRoom.North_Neighbor == "X")
            {
                /*IF YOU ARE ON THE TOP DECK ON THE TOP FLOOR, YOU HAVE NO NORTH*/

                if ((HolderRoom.Deck == Dk_max) && (HolderRoom.Floor == Fl_min))
                {
                    HolderRoom.North_Neighbor= "X";
                }

                /*OR IF you are on the highest floor of your deck,
                Your N_Neighbor will be equal to a string that is a concatenation of the result of your current Deck Minus one,
                 The Max Floor Control value, and your current room number. 
                 Ex: CurrentRoom is B123, B123's North Neighbor would be: (*B*(2) - 1) = (1)*A*), Fl_Max = 3, and 123 giving a total value of : A3123 *
                 */

                else if (HolderRoom.Floor == Fl_min)
                {
                    HolderRoom.North_Neighbor = (String.Concat(Dk_retriever(HolderRoom.Deck - 1), Fl_min, HolderRoom.Num));
                }


                else
                    HolderRoom.North_Neighbor = (String.Concat(Dk_retriever(Dk_container), (Fl_container - 1), HolderRoom.Num));
                //OTHERWISE YOUR NORTH NEIGHBOR CONSISTS OF YOUR DECK, YOUR FLOOR - 1, AND YOUR CURRENT ROOM NUMBER.

            }

            else
                return;


        }


        public void SneighborCalculations(Room HolderRoom)
        {
            if (HolderRoom.South_Neighbor == "X" || HolderRoom.South_Neighbor == null)
            {

                /*IF YOU ARE THE LOWEST DECK ON THE LOWEST FLOOR, YOU HAVE NO SOUTH NEIGHBOR*/
                if ((HolderRoom.Deck == Dk_max) && (HolderRoom.Floor == Fl_max))
                {


                    HolderRoom.South_Neighbor = "X";


                }
                /*IF YOU HAPPEN TO BE ON THE FLOOR OF A DECK RIGHT ABOVE THE TOP FLOOR OF ANOTHER DECK */
                else if (HolderRoom.Floor == Fl_max)
                {
                    HolderRoom.South_Neighbor = (String.Concat(Dk_retriever(HolderRoom.Deck + 1), HolderRoom.Floor, HolderRoom.Num));

                }

                else
                    HolderRoom.South_Neighbor = (String.Concat(Dk_retriever(HolderRoom.Deck), (HolderRoom.Floor + 1), HolderRoom.Num));


            }

            else
                return;
        }


        public void WneighborCalculations(Room HolderRoom)
        {

            if (HolderRoom.West_Neighbor == "X" || HolderRoom.West_Neighbor == null)
            {

                /*IF YOU ARE THE FIRST ROOM ON YOUR FLOOR, YOU HAVE NO EAST NEIGHBOR*/
                if (HolderRoom.Num == 0)
                {


                    HolderRoom.West_Neighbor = "X";

                }


                else
                    HolderRoom.West_Neighbor = (String.Concat(Dk_retriever(HolderRoom.Deck), HolderRoom.Floor, HolderRoom.Num - 1));


            }
            else return;

        }


        public void EneighborCalculations(Room HolderRoom)
        {


            if (HolderRoom.East_Neighbor == "X" || HolderRoom.East_Neighbor == null)
            {

                /*IF YOU ARE THE LAST ROOM ON YOUR FLOOR, YOU HAVE NO EAST NEIGHBOR*/
                if (HolderRoom.Num == Rm_max)
                {


                    HolderRoom.East_Neighbor = "X";

                }


                else
                    HolderRoom.East_Neighbor = (String.Concat(Dk_retriever(HolderRoom.Deck), HolderRoom.Floor, HolderRoom.Num + 1));


            }

            else return;


        }

        public Room Roommaker(Room Rom)
        {
            Rom.Name = (String.Concat(Dk_retriever(Dk_max), Fl_container));
            NneighborCalculations(Rom);
            SneighborCalculations(Rom);
            EneighborCalculations(Rom);
            WneighborCalculations(Rom);

            return Rom;
        }


        public void Creation ()
        {
            Console.WriteLine(Fl_max);
            Llist.Start(new Room(Dk_container, Fl_container, Rm_container));
            
            for(int x = Dk_max; x >= Dk_min; x--)
            {
                
                for (int y = Fl_max; y >= Fl_min; y--)
                {
                    
                    for (int z = 0; z <= Rm_perfloor; z++)
                    {
                        //Console.WriteLine(x + " " + y + " " + z);
                        Llist.Rear_Add((new Room(z,y,x)));


                    }

                }


            }




        }

        public void PrintNodes()
        {
            List<Room> columns = new List<Room>();
            int tableWidth = 100;

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
             */

            while (p != null)
            {

                columns.Add(p.room);
                p = p.previous;


            }



            int width = (tableWidth - columns.ToArray().Length) / columns.ToArray().Length;


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
                    temp++;
                    if (column.selected)
                    {
                        row += AlignCentreNode("*", width) + "|" + "\n";


                        column.selected = false;
                    }
                    else
                        row += AlignCentreNode(column.Name, width) + "|";

                }




            }



            Console.WriteLine(row);
        }


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


    }



}








    




