using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


namespace ConsoleApp1
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            int RoomSize = 81;

            List<Room> RoomPopulator = new List<Room>();

            RoomPopulator = StationCreator(RoomSize);

            /*   
              for(int x = 0; x <= RoomSize; x++)
           {

               System.Console.WriteLine(RoomPopulator[x].GetNeighbor_S().ToString());
               System.Console.WriteLine(RoomPopulator[x].GetNeighbor_E().ToString());
               System.Console.WriteLine(RoomPopulator[x].GetNeighbor_W().ToString());



           }

           */

            /*

                  Station Creator's purpose is to take parameters denoting amount of rooms. It will then randoml assign door statuses to various 
                  corners of a room based on a randomly generated value. 

 It does this by firstly creating a List of Rooms, secondly inducting a forloop that iterates through the random number generator sequences, assigning door values 




             */

            List<Room> StationCreator(int Amt)

            /* Station Creator is a long ass method. I may at a later date break it up into smaller pieces, but for right now the goal is to dynamically automate the population of decks, and floors.
               I will do this by reading in the amt from the Amt variable, dividing the read-in amt by the Roomdivisor, and then proceeding through a series of loops that will check each room as it's being created,
               and associate the proper neighbor credentials to it. I will have a few control systems in place. The first will monitor decks, and as soon as it recieves word that three floors are filled it will trigger itself to begin another deck
               The second control system is the floor system which will monitor floors, as soon as a floor reaches the value stored in Roomamt it will reset itself to zero, increment the floor control, and continue. 
         */
            {

                /***************CONTROL VARIABLES****************/
                int Fl_ControlNumMin = 1; /*The least amount of floors desired.*/
                int Fl_ControlNumMax = 3;/*The amount of  desired*/
                int Dk_ControlNumMin = 1; /*The least amount of Decks desired*/
                int Dk_ControlNumMax = 3; /*The Most amount of Decks desired. */
                int Rm_Divisor = 9;/*Room Divisor is the total amount of floors on the gameboard. For our game the board consists of three decks with three floors each, thus netting a total 9 floors*/
                int Rm_Amount = Amt / Rm_Divisor; /*By dividing the toatal of Amt by the total number of floors, we can arrive at the total number of rooms requested for the gameboard.*/
                const int Maxnumber = 50; //The maximum number a room can be at any given time.
                const int Leastnumber = 0;//The least number a room can be at any given time.


                /***************CONTAINER VARIABLES*******************************/



                /************************COUNTER VARIABLES*************************************/

                int Rm_Tracker = 0; /*Floortracker is a counter that keeps track of how many rooms have been made, it will be used to trigger the next floor*/
                int Fl_Monitor = 3; /*Keeps track of the current level of floor It starts out as three because the numbers go up in ascending order*/
                int Dk_Monitor = Dk_ControlNumMax; /*Keeps track of the current Deck*/
                int Fl_Tracker = Fl_ControlNumMax;



                /*****************************************************************************/




                List<Room> RoomList = new List<Room>();

                Random rnd = new Random();

                for (int x = 0; x < Rm_Divisor; x++)
                {
                    Dk_Monitor = Dk_ControlNumMax;

                    for (int y = 0; y < Dk_ControlNumMax; y++)
                    {
                        

                        for (int z = 0; z < Rm_Amount; z++)
                        {
                            /*A new Current_Room Object is created: int, char, int*/
                            Current_Room HolderRoom = new Current_Room(Fl_Tracker, Dk_Monitor, Rm_Tracker, Dk_Retriever(Dk_Monitor).ToString());


                            /*Now it's time to initialize a method that has Current_Room check itself to see if it matches any special room requirements. */

                            HolderRoom.Fl_Minmaxcheck(Fl_ControlNumMin, Fl_ControlNumMax);
                            HolderRoom.Dk_Minmaxcheck(Dk_ControlNumMin, Dk_ControlNumMax);



                            /****************************NORTH FLOOR CALCULATIONS*******************************/

                            /*"X" Is a default value that I set to act as a gatekeeper*/


                            if (HolderRoom.NorthNeighbor == "X")
                            {

                                /*IF YOU ARE ON THE TOP DECK ON THE TOP FLOOR, YOU HAVE NO NORTH*/

                                if (HolderRoom.Dk_Min && HolderRoom.Fl_Min)
                                {


                                    HolderRoom.NorthNeighbor = "X";


                                }

                                /*OR IF you are on the highest floor of your deck,
                                Your N_Neighbor will be equal to a string that is a concatenation of the result of your current Deck Minus one,
                                 The Max Floor Control value, and your current room number. 
                                 Ex: CurrentRoom is B123, B123's North Neighbor would be: (*B*(2) - 1) = (1)*A*), Fl_Max = 3, and 123 giving a total value of : A3123 *
                                 */

                                else if (HolderRoom.Fl_Min)
                                {


                                    HolderRoom.NorthNeighbor = String.Concat(Dk_Retriever(HolderRoom.Get_Dk() - 1), Fl_ControlNumMax, HolderRoom.CurrentRoom);

                                }

                                //OTHERWISE YOUR NORTH NEIGHBOR CONSISTS OF YOUR DECK, YOUR FLOOR - 1, AND YOUR CURRENT ROOM NUMBER. 

                                else
                                    HolderRoom.NorthNeighbor = String.Concat(Dk_Retriever(HolderRoom.Get_Dk()), (HolderRoom.Get_Fl() - 1), HolderRoom.CurrentRoom);

                            }



                            /****************************SOUTH FLOOR CALCULATIONS*******************************/


                            if (HolderRoom.SouthNeighbor == "X")
                            {

                                /*IF YOU ARE THE LOWEST DECK ON THE LOWEST FLOOR, YOU HAVE NO SOUTH NEIGHBOR*/
                                if (HolderRoom.Dk_Max && HolderRoom.Fl_Max)
                                {


                                    HolderRoom.SouthNeighbor = "X";


                                }

                                else if (HolderRoom.Fl_Max)
                                {
                                    HolderRoom.SouthNeighbor = String.Concat(Dk_Retriever(HolderRoom.Get_Dk() + 1), Fl_ControlNumMin, HolderRoom.CurrentRoom);
                                }

                                else
                                    HolderRoom.SouthNeighbor = String.Concat(Dk_Retriever(HolderRoom.Get_Dk()), (HolderRoom.Get_Fl() + 1), HolderRoom.CurrentRoom);




                            }

                            /****************************EAST FLOOR CALCULATIONS*******************************/

                            if (HolderRoom.EastNeighbor == "X")
                            {

                                /*IF YOU ARE THE LAST ROOM ON YOUR FLOOR, YOU HAVE NO EAST NEIGHBOR*/
                                if (HolderRoom.CurrentRoom == Maxnumber)
                                {


                                    HolderRoom.EastNeighbor = "X";

                                }


                                else
                                    HolderRoom.EastNeighbor = String.Concat(Dk_Retriever(HolderRoom.Get_Dk()), HolderRoom.Get_Fl(), (HolderRoom.CurrentRoom + 1));


                            }


                            /****************************WEST FLOOR CALCULATIONS*******************************/


                            if (HolderRoom.WestNeighbor == "X")
                            {

                                /*IF YOU ARE THE FIRST ROOM ON YOUR FLOOR, YOU HAVE NO EAST NEIGHBOR*/
                                if (HolderRoom.CurrentRoom == Leastnumber)
                                {


                                    HolderRoom.WestNeighbor = "X";

                                }


                                else
                                    HolderRoom.WestNeighbor = String.Concat(Dk_Retriever(HolderRoom.Get_Dk()), HolderRoom.Get_Fl(), (HolderRoom.CurrentRoom - 1));


                            }


                            /**********************************************************************************/




                            //RoomList.Add(new Room(Na: "YAH", NN: "YAH", NE: "YAH", NW: "YAH", NS: "YAH"));
                            RoomList.Add(new Room(Na: HolderRoom.Get_N(), NN: HolderRoom.NorthNeighbor, NE: HolderRoom.EastNeighbor, NW: HolderRoom.WestNeighbor, NS: HolderRoom.SouthNeighbor));

                            System.Console.WriteLine(String.Concat(HolderRoom.Get_N(), "-", "(", HolderRoom.NorthNeighbor, ")", "(", HolderRoom.EastNeighbor, ")", "(", HolderRoom.WestNeighbor, ")", "(", HolderRoom.SouthNeighbor, ")"));


                            /*                    
                               int N_wall = rnd.Next(1, 7);
                               int S_wall = rnd.Next(1, 7);
                               int E_wall = rnd.Next(1, 7);
                               int W_wall = rnd.Next(1, 7);


                               Boundary Boundpoop = new Boundary();
                               Boundpoop = RoomList[0].GetBoundary('N');
                               System.Console.WriteLine("Counter is" + Counter);
                               System.Console.WriteLine("Roomlist is" + Boundpoop.GetPosition());
                               /* Random Number Generator sequences */












                            Rm_Tracker++;



                        }

                        Fl_Tracker--;
                    }

                    Dk_Monitor--;
                }

                return RoomList;



                char Dk_Retriever(int num)
                {

                    switch (num)
                    {


                        case 1:
                            return 'A';

                        case 2:
                            return 'B';
                        case 3:
                            return 'C';

                        default:
                            return 'X';


                    }

                }











            }

        }
    }


    public struct Current_Room
    {


        private readonly String Name;
        public String NorthNeighbor;
        public String SouthNeighbor;
        public String EastNeighbor;
        public String WestNeighbor;
        public int CurrentRoom;
        public String Dk_Name;
        private int Floor { get; set; }
        private int Deck { get; set; }
        public bool Fl_Min;
        public bool Fl_Max;
        public bool Dk_Min;
        public bool Dk_Max;


        public int Get_Fl() { return Floor; }
        public int Get_Dk() { return Deck; }
        public void Set_Fl(int Fl) { Floor = Fl; }
        public void Set_Dk(int Dk) { Deck = Dk; }
        public String Get_N() { return Name; }

        public void Fl_Minmaxcheck(int Min, int max)
        {
            if (Floor == Min)
            {

                Fl_Min = true;

            }
            else if (Floor == max)
            {

                Fl_Max = true;

            }



        }


        public void Dk_Minmaxcheck(int Min, int max)
        {
            if (Deck == Min)
            {

                Dk_Min = true;

            }
            else if (Deck == max)
            {

                Dk_Max = true;

            }



        }




        public Current_Room(int Fl, int Dk, int Ro, String Dk_N)
        {


            Floor = Fl;
            Deck = Dk;
            CurrentRoom = Ro;



            NorthNeighbor = "X";
            SouthNeighbor = "X";
            EastNeighbor = "X";
            WestNeighbor = "X";


            Fl_Min = false;
            Fl_Max = false;
            Dk_Min = false;
            Dk_Max = false;

            Dk_Name = Dk_N;



            Name = String.Concat(Dk_Name, Floor.ToString(), CurrentRoom.ToString());








        }
    }
}








    


 


            



                     
                            
                









           
