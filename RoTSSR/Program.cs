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

            List<Room> StationCreator(int Roomamt)
            {


                int Roomtracker = 0; /*Floortracker is a counter that keeps track of how many rooms have been made, it will be used to trigger the next floor*/
                int Decktrigger = 0;/*Deck Trigger keeps track of how many floors have been made, it is increased by 1 after every three floors*/
                int Floortrigger = 3; /*Floortrigger keeps track of how many floors that have been made. Every fitieth floor, the trigger goes up by one, after three it resets.*/
                char Currentfloorletter = new char();  /*Floorletter marks the floor letter the room is on*/
                char Comparisonfloor;
                int Floortracker;

                String NorthNeighbor;
                String SouthNeighbor;
                String EastNeighbor;
                String WestNeighbor;

                const int Maxnumber = 50; //The maximum number a room can be at any given time.
                const int Leastnumber = 0;//The least number a room can be at any given time.



                List<Room> RoomList = new List<Room>();

                Random rnd = new Random();

                //RoomList.Add(new Room(Na: "C", NN: "B", NE: "C", NW: "C", NS: "P"));

                /* Calculates room neighbors*/

                for (int Roomcounter = 0; Roomcounter < Roomamt; Roomcounter++)
                {


                    /******
                     * 
                     * First and last room position finder.
                     * 
                     * 
                     * 
                     * 
                    ****/
                    if (Roomcounter == Leastnumber)
                    {

                        //If the room begins at zero of any floor, then it's west neighbor is equal to nothing. 

                        WestNeighbor = null;


                        if (Roomcounter == Maxnumber)
                        {

                            //If the room begins at maxnumber the one to its right is null.

                            EastNeighbor = null;




                        }


                        /**************************************If you are on the first floor, you have no south neighbor******************************************************/

                        if (String.Concat(Currentfloorletter.ToString(), Floortracker.ToString()) == "C3")
                        {


                            SouthNeighbor = null;


                        }


                        /********************************************If you are on the last deck, you have no north neighbor******************************************************/


                        if (String.Concat(Currentfloorletter.ToString(), Floortracker.ToString()) == "A1")
                        {

                            NorthNeighbor = null;


                        }


                        /*Switch statement that manually detects when to chnage particular neighbors of neighboring decks*/

                        switch(String.Concat(Currentfloorletter.ToString(), Floortracker.ToString())) {



                            case "A3":
                                SouthNeighbor = "B1" + "(" + Roomtracker + ")";
                                break;

                                          
                            case "B3":
                                SouthNeighbor = "C1" + "(" + Roomtracker + ")";
                                break;


                        }






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




                    return RoomList;





                }










            }









        }
    }

}


