using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public  class StationCreator 
    {

        /*Title: StationCreator
             *Arguments:
             * (int)Rm_Amt -- The amountof rooms requested by the operator.
             * Variables:
             * (int)Fl_ControlNumMin -- The least amount of floors desired
             * (int)Fl_ControlNumMax -- The max amount of floors desired
             * (int)DK_ControlNumMin -- The least amount of Decks desired
             * (int)Dk_ControlNumMax -- The Most amount of Decks desired.
             * (int)Rm_Divisior -- Room Divisor is the total number of desired floors for the gameboard. 
             * (int)Rm_PerFloor -- Is the calculated result of the division 
         */
            

               /***************CONTROL VARIABLES****************/
       public int Fl_ControlNumMin { get;  set;}
       public  int Fl_ControlNumMax { get; set;}
       public  int Rm_ControlNumMin { get; set;}
       public int Rm_ControlNumMax { get;  set;}
       public int Dk_ControlNumMin { get; set;}
       public int Dk_ControlNumMax { get; set;}
       public int Rm_Divisor { get;  set;}
       public int Rm_PerFloor { get; set;} /*By dividing the total amount of rooms by the total number of floors, we can arrive at the total number of rooms per floor.*/
       public int Rm_Amt { get;  set;}
       public int Leastnumber{get;  set;}//The least number a room can be at any given time.
       public StationCreator() { } /*Constructor*\

        /***************CONTAINER VARIABLES*******************************/

        
             public StationCreator(int Flmin, int Flmax, int Rmmin, int Rmmax, int Dkmin, int Dkmax, int RmDiv, int Rmperfl, int Rm_Amt, int lnum)
             {

                 Fl_ControlNumMin = Flmin;
                 Fl_ControlNumMax = Flmax;
                 Rm_ControlNumMin = Rmmin;
                 Rm_ControlNumMax = Rmmax;
                 Dk_ControlNumMin = Dkmin;
                 Dk_ControlNumMax = Dkmax;
                 Rm_Divisor = RmDiv;
                 Rm_PerFloor = Rmperfl;
                 Leastnumber = lnum;

             }

    

     


        /************************COUNTER VARIABLES*************************************/

        int Rm_Tracker { get; set; } /*Floortracker is a counter that keeps track of how many rooms have been made, it will be used to trigger the next floor*/
        int Fl_Monitor { get; set; } /*Keeps track of the current level of floor It starts out as three because the numbers go up in ascending order*/
        int Dk_Monitor { get; set; } /*Keeps track of the current Deck*/
        int Fl_Tracker { get; set; }



        /*****************************************************************************/


       

        public void  nNeighborCalculations(Room HolderRoom)

              
        {
            //Console.WriteLine("HELLO FROM NNEIGHBOR" + HolderRoom.GetNeighbor_N());
            /*"C1" Is a default value that I set to act as a gatekeeper*/

            if (HolderRoom.GetNeighbor_N() == null || HolderRoom.GetNeighbor_N() == "X") 
            {
                /*IF YOU ARE ON THE TOP DECK ON THE TOP FLOOR, YOU HAVE NO NORTH*/

                if ((HolderRoom.Deck == Dk_ControlNumMin) && (HolderRoom.Floor == Fl_ControlNumMin))
                {


                    HolderRoom.SetNorth_Neighbor("X");


                }

                /*OR IF you are on the highest floor of your deck,
                Your N_Neighbor will be equal to a string that is a concatenation of the result of your current Deck Minus one,
                 The Max Floor Control value, and your current room number. 
                 Ex: CurrentRoom is B123, B123's North Neighbor would be: (*B*(2) - 1) = (1)*A*), Fl_Max = 3, and 123 giving a total value of : A3123 *
                 */

                else if (HolderRoom.Floor == Fl_ControlNumMin)
                {

                    HolderRoom.SetNorth_Neighbor(String.Concat(Dk_Retriever(HolderRoom.Deck - 1), Fl_ControlNumMin, HolderRoom.Num));

                }


                else
                    HolderRoom.SetNorth_Neighbor(String.Concat(Dk_Retriever(Dk_Monitor), (Fl_Monitor - 1), HolderRoom.Num));
                //OTHERWISE YOUR NORTH NEIGHBOR CONSISTS OF YOUR DECK, YOUR FLOOR - 1, AND YOUR CURRENT ROOM NUMBER.

            }

            else
                return;


        }

        public void  sNeighborCalculations(Room HolderRoom)

        {
            if (HolderRoom.GetNeighbor_S() == "X" || HolderRoom.GetNeighbor_S() == null)
            {

                /*IF YOU ARE THE LOWEST DECK ON THE LOWEST FLOOR, YOU HAVE NO SOUTH NEIGHBOR*/
                if ((HolderRoom.Deck == Dk_ControlNumMax) && (HolderRoom.Floor == Fl_ControlNumMax))
                {


                    HolderRoom.SetSouth_Neighbor("X");


                }
                /*IF YOU HAPPEN TO BE ON THE FLOOR OF A DECK RIGHT ABOVE THE TOP FLOOR OF ANOTHER DECK */
                else if (HolderRoom.Floor == Fl_ControlNumMax)
                {
                    HolderRoom.SetSouth_Neighbor(String.Concat(Dk_Retriever(HolderRoom.Deck + 1), HolderRoom.Floor, HolderRoom.Num));
                   
                }

                else
                    HolderRoom.SetSouth_Neighbor(String.Concat(Dk_Retriever(HolderRoom.Deck), (HolderRoom.Floor + 1),HolderRoom.Num));


            }

            else
                return;
        }


        public void wNeighborCalculations(Room HolderRoom)
        {

            if (HolderRoom.GetNeighbor_W() == "X" || HolderRoom.GetNeighbor_W() == null)
            {

                /*IF YOU ARE THE FIRST ROOM ON YOUR FLOOR, YOU HAVE NO EAST NEIGHBOR*/
                if (HolderRoom.Num == 0)
                {


                    HolderRoom.SetWest_Neighbor("X");

                }


                else
                   HolderRoom.SetWest_Neighbor(String.Concat(Dk_Retriever(HolderRoom.Deck), HolderRoom.Floor, HolderRoom.Num - 1));


            }
            else return;

        }


        public void eNeighborCalculations(Room HolderRoom)
        {


            if (HolderRoom.GetNeighbor_E() == "X" || HolderRoom.GetNeighbor_E() == null)
            {

                /*IF YOU ARE THE LAST ROOM ON YOUR FLOOR, YOU HAVE NO EAST NEIGHBOR*/
                if (HolderRoom.Num == Rm_ControlNumMax)
                {


                    HolderRoom.SetEast_Neighbor("X");

                }


                else
                    HolderRoom.SetEast_Neighbor(String.Concat(Dk_Retriever(HolderRoom.Deck), HolderRoom.Floor, HolderRoom.Num + 1));


            }

            else return;


        }




String Dk_Retriever(int num)
        {

            switch (num)
            {


                case 1:
                    return "A";

                case 2:
                    return "B";

                case 3:
                    return "C";

                default:
                    return "X";


            }

        }

        public Room Roommaker(Room Rom)
        {
            Rom.SetName(String.Concat(Dk_Retriever(Dk_Monitor),Fl_Tracker));
            nNeighborCalculations(Rom);
            sNeighborCalculations(Rom);
            eNeighborCalculations(Rom);
            wNeighborCalculations(Rom);

            return Rom;
        }


        public Llist DB_Station()
        {

            Llist Llstation = new Llist();
            Room Rom = new Room();


            Fl_ControlNumMin = 1;
            
            Rm_ControlNumMin = 1;

            Dk_ControlNumMin = 1;
         
            
  
            Rm_Amt = 50;
            Dk_ControlNumMax = 3;
            Fl_ControlNumMax = 3;
            //Figure out  Rm per floor by dividng desired number of decks against the rm_amt and then the desired amount of floors by the remaineder.  
            Rm_PerFloor = Rm_Amt/Dk_ControlNumMax;
            Rm_PerFloor = Rm_PerFloor / Fl_ControlNumMax;
            Rm_ControlNumMax = Rm_PerFloor;
            Rm_Tracker = 1; /*Floortracker is a counter that keeps track of how many rooms have been made, it will be used to trigger the next floor*/
            Fl_Monitor = 3;
            Dk_Monitor = 3;
            Fl_Tracker = 3;
            
            Rom = Roommaker(Rom);
            Llstation.Start(Rom);

            for (int z = 3; z > 0; z--)
            {

                for (int y = 3; y > 0; y--)
                {
                   
                    for (int x = 0; x <= Rm_PerFloor; x++)
                    {
                        
                        
                            Room ne = new Room(x,y,z);

                            ne = Roommaker(ne);
                            ne.SetName(String.Concat(Dk_Retriever(ne.Deck), ne.Floor, x));
                        /*
                            Console.WriteLine(ne.GetName());
                            Console.WriteLine("North of " + " " + ne.GetName() + " " + ne.GetNeighbor_N());
                            Console.WriteLine("South of " + " " + ne.GetName() + " " + ne.GetNeighbor_S());
                            Console.WriteLine("East of" + " " + ne.GetName() + " " + ne.GetNeighbor_E());
                            Console.WriteLine("West of" + " " + ne.GetName() + " " + ne.GetNeighbor_W());
                        */
                        Llstation.Rear_Add(ne);
                    }

                    Fl_Monitor = Fl_Monitor - 1;

                }

                Dk_Monitor = Dk_Monitor - 1;

            }

            Fl_Monitor = Fl_ControlNumMin;
            Dk_Monitor = Dk_ControlNumMax;
           

           
            return Llstation;

        }

       
    }
}
