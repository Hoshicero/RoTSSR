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


            int Rowstarter = 1;
            const int RoomSize = 2;


            List<Room> RoomPopulator = new List<Room>();

            RoomPopulator = StationCreator(RoomSize);




            for (int x = 1; x <= RoomSize; x++)
            {

                //int Writer = x+2;

                if (Rowstarter == 5)
                {

                    System.Console.WriteLine(RoomPopulator[x].GetName() + "'s North Neighbor is" + RoomPopulator[x].GetNeighbor_N());
                    System.Console.WriteLine(RoomPopulator[x].GetName() + "'s South Neighbor is" + RoomPopulator[x].GetNeighbor_S());
                    System.Console.WriteLine(RoomPopulator[x].GetName() + "'s East Neighbor is" + RoomPopulator[x].GetNeighbor_E());
                    System.Console.WriteLine(RoomPopulator[x].GetName() + "'s West Neighbor is" + RoomPopulator[x].GetNeighbor_W());
                    //System.Console.WriteLine(CreateRoom(RoomPopulator[x]));
                    Rowstarter = 0;


                }
                else
                {
                    System.Console.WriteLine(RoomPopulator[x].GetName() + "'s North Neighbor is" + RoomPopulator[x].GetNeighbor_N());
                    System.Console.WriteLine(RoomPopulator[x].GetName() + "'s South Neighbor is" + RoomPopulator[x].GetNeighbor_S());
                    System.Console.WriteLine(RoomPopulator[x].GetName() + "'s East Neighbor is" + RoomPopulator[x].GetNeighbor_E());
                    System.Console.WriteLine(RoomPopulator[x].GetName() + "'s West Neighbor is" + RoomPopulator[x].GetNeighbor_W());
                    //System.Console.Write(CreateRoom(RoomPopulator[x]));
                    Rowstarter++;
                }



            }








            //****Trying to make it so that final string will be a string concatenation of all of the necessary elements of the room,**\\\


            System.Console.ReadLine();


            String CreateRoom(Room Temp)
            {

                string finalstring = null;

                if (Temp.GetBoundary('W').GetPassable() == true)
                {

                    finalstring = finalstring + PrintWestWall(true);

                }
                else finalstring = finalstring + PrintWestWall(false);



                if (Temp.GetBoundary('N').GetPassable() == true)
                {

                    finalstring = finalstring + PrintNorthWall(true);

                }
                else finalstring = finalstring + PrintNorthWall(false);



                if (Temp.GetBoundary('S').GetPassable() == true)
                {


                    finalstring = finalstring + PrintSouthWall(true);

                }
                else finalstring = finalstring + PrintSouthWall(false);


                if (Temp.GetBoundary('E').GetPassable() == true)
                {

                    finalstring = finalstring + PrintEastWall(true);

                }
                else finalstring = finalstring + PrintEastWall(false);




                return finalstring;


            }
            String PrintNorthWall(bool tf)
            {

                if (tf == true)
                {

                    return (" ");

                }
                else return ("^");



            }


            String PrintWestWall(bool tf)
            {
                if (tf == true)
                {

                    return (" ");

                }
                else return ("[");

            }


            String PrintEastWall(bool tf)
            {
                if (tf == true)
                {

                    return (" ");

                }
                else return ("]");




            }

            String PrintSouthWall(bool tf)
            {

                if (tf == true)
                {

                    return (" ");

                }
                else return ("_");


            }

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
                bool Dk_Trigger = false; /*Dktrigger activates(true) when it is time to go to a new Deck*/
                int Rm_Divisor = 9;/*Room Divisor is the total amount of floors on the gameboard. For our game the board consists of three decks with three floors each, thus netting a total 9 floors*/
                int Rm_Amount = Amt / Rm_Divisor; /*By dividing the toatal of Amt by the total number of floors, we can arrive at the total number of rooms requested for the gameboard.*/
                const int Maxnumber = 50; //The maximum number a room can be at any given time.
                const int Leastnumber = 0;//The least number a room can be at any given time.


                /***************CONTAINER VARIABLES*******************************/


                char Dk_Current = new char();  /*CurrentDeck marks the Deck letter the room is on*/
                char Fl_Comparison;
                char Dk_NNeighbor = '|';

                /************************COUNTER VARIABLES*************************************/

                int Rm_Tracker = 0; /*Floortracker is a counter that keeps track of how many rooms have been made, it will be used to trigger the next floor*/
                int Fl_Tracker = 0; /**/
                int Fl_Monitor = 3; /*Keeps track of the current level of floor It starts out as three because the numbers go up in ascending order*/
                int Dk_Monitor = 3; /*Keeps track of the current Deck*/
                int DoLoopControl = 0; /*The control that keeps track of how many times the loop has ran. */


                /*****************************************************************************/




                List<Room> RoomList = new List<Room>();

                Random rnd = new Random();





                do
                {
                    /*A new Current_Room Object is created: int, char, int*/
                    Current_Room HolderRoom = new Current_Room(Fl_Monitor, Dk_Monitor, Dk_Monitor);


                    /*Now it's time to initialize a method that has Current_Room check itself to see if it matches any special room requirements. */

                    HolderRoom.Fl_Minmaxcheck(Fl_ControlNumMin, Fl_ControlNumMax);
                    HolderRoom.Dk_Minmaxcheck(Dk_ControlNumMin, Dk_ControlNumMax);



                    /****************************NORTH FLOOR CALCULATIONS*******************************/

                    /*"X" Is a default value that I set to act as a gatekeeper*/


                    if (HolderRoom.NorthNeighbor == "X")
                    {

                        /*IF YOU ARE ON THE FIRST DECK ON THE FIRST FLOOR, YOU HAVE NO NORTH*/

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
                        

                            HolderRoom.NorthNeighbor = String.Concat(Dk_Retriever(HolderRoom.Get_Dk() - 1).ToString(), Fl_ControlNumMax.ToString(), HolderRoom.CurrentRoom.ToString());

                        }

                        //OTHERWISE YOUR NORTH NEIGHBOR CONSISTS OF YOUR DECK, YOUR FLOOR - 1, AND YOUR CURRENT ROOM NUMBER. 

                        else
                            HolderRoom.NorthNeighbor = String.Concat(Dk_Retriever(HolderRoom.Get_Dk()).ToString(), (HolderRoom.Get_Fl()- 1).ToString(), HolderRoom.CurrentRoom.ToString());

                    }



                    /****************************SOUTH FLOOR CALCULATIONS*******************************/







                    CurrentRoom = String.Concat(CurrentDeck.ToString(), Floortracker.ToString()); /*CurrentRoom reflects the title of the Currentroom*/

                    NorthNeighbor = String.Concat(CurrentDeck.ToString(), (Floortracker - 1).ToString(), Roomtracker.ToString()); /*North Neighbor = The Currentroom - 1*/
                    SouthNeighbor = String.Concat(CurrentDeckController(DeckMonitor - 1).ToString(), (Floortracker + 1).ToString(), Roomtracker.ToString()); /*SouthNeighbor equals the result of the CurrentDeck controller method with the variable of the current deck -1*/
                                                                                                                                                             /*This doesnt work, we need additional statements yo.*/

                    /*******
                     * 
                     * 
                     * CONDITIONAL STATEMENTS 
                     * 
                     */




                    /******
                     * 
                     * First and last room position finder.
                     * 
                     * 
                     * 
                     * 
                    ****/
                    if (Roomtracker == Leastnumber)
                    {

                        //If the room begins at zero of any floor, then it's west neighbor is equal to nothing. 

                        WestNeighbor = null;


                        if (Roomtracker == Maxnumber)
                        {

                            //If the room begins at maxnumber the one to its right is null.

                            EastNeighbor = null;




                        }


                        /**************************************If you are on the first floor, you have no south neighbor******************************************************/

                        if (CurrentRoom == "C3")
                        {


                            SouthNeighbor = null;


                        }


                        /********************************************If you are on the last deck, you have no north neighbor******************************************************/


                        if (CurrentRoom == "A1")
                        {

                            NorthNeighbor = null;


                        }


                        /*Switch statement that manually detects when to change particular neighbors of neighboring decks*/

                        switch (CurrentRoom)
                        {


                            //IF YOU ARE ON THE THIRD FLOOR OF THE THIRD DECK, BELOW YOU IS B1

                            case "A3":
                                SouthNeighbor = "B1" + "(" + Roomtracker + ")";
                                break;

                            //IF YOU ARE ON THE THIRD FLOOR OF THE SECOND DECK, THE NEIGHBOR BELOW YOU IS C1.

                            case "B3":
                                SouthNeighbor = "C1" + "(" + Roomtracker + ")";
                                break;


                        }



                        /*Base neighbor calculation*/






                        RoomList.Add(new Room(Na: Currentfloorletter + "(" + Floortrigger + ")" + Roomcounter, NN: "B" + Roomcounter, NE: "C" + (Roomcounter + 1), NW: "C" + (counter - 1), NS: "P"));


                        System.Console.WriteLine("Pass" + Roomcounter);

                        int N_wall = rnd.Next(1, 7);
                        int S_wall = rnd.Next(1, 7);
                        int E_wall = rnd.Next(1, 7);
                        int W_wall = rnd.Next(1, 7);


                        Boundary Boundpoop = new Boundary();
                        Boundpoop = RoomList[0].GetBoundary('N');
                        System.Console.WriteLine("Counter is" + Roomcounter);
                        System.Console.WriteLine("Roomlist is" + Boundpoop.GetPosition());
                        /* Random Number Generator sequences */

                        if (N_wall >= 5)
                        {

                            //System.Console.WriteLine("North wall is" + N_wall);

                            //RoomList[count].GetBoundary('N').SetDoor();

                        }
                        else //RoomList[count].GetBoundary('N').SetBulkhead();




                        if (S_wall >= 5)
                        {

                            RoomList[0].GetBoundary('S').SetDoor();


                            //System.Console.WriteLine("S wall is" + S_wall);

                        }
                        else RoomList[0].GetBoundary('S').SetBulkhead();






                        if (W_wall >= 5)
                        {

                            RoomList[Roomcounter].GetBoundary('W').SetDoor();


                            //System.Console.WriteLine("W wall is" + W_wall);


                        }
                        else RoomList[Roomcounter].GetBoundary('W').SetBulkhead();



                        if (W_wall >= 5)
                        {

                            RoomList[Roomcounter].GetBoundary('E').SetDoor();

                            //System.Console.WriteLine("E wall is" + E_wall);

                        }
                        else RoomList[Roomcounter].GetBoundary('E').SetBulkhead();














                    }

                } while (DoLoopControl <= Amt);



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
            struct Current_Room {

            public String NorthNeighbor;
            public String SouthNeighbor;
            public String EastNeighbor;
            public String WestNeighbor;
            public int CurrentRoom;
            private int Floor {get; set; }
            private int Deck { get; set; }
            public bool Fl_Min;
            public bool Fl_Max;
            public bool Dk_Min;
            public bool Dk_Max;

            
            public int Get_Fl() { return Floor;}
            public int Get_Dk() { return Deck;}
            public void Set_Fl(int Fl) { Floor = Fl;}
            public void Set_Dk(int Dk) { Deck = Dk;}

            public void Fl_Minmaxcheck(int Min, int max)
            {
                if(Floor == Min)
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




            public Current_Room (int Fl, int Dk, int Ro)
            {


                Floor = Fl;
                Deck = Dk;
                CurrentRoom = Ro;



                NorthNeighbor = null;
                SouthNeighbor = "X";
                EastNeighbor = "X";
                WestNeighbor = "X";
                
               
                Fl_Min = false;
                Fl_Max = false;
                Dk_Min = false;
                Dk_Max = false;





            }





        }







                //}
            } 


            



                     
                            
                



            }





           



        }

       
    }

}


