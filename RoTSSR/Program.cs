using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


namespace ConsoleApp1
{
    public class MClass : StationCreator {
        public static object Fl_control { get; private set; }

        public static void Main(string[] args)

 /*
 Title: Main
 Type: Void
 Function: To facilitate the execution of appropriate class methods.
 Variables: 
 *(int)RoomSize -- The amount of Rooms a user would like to be included into the final board. 
 *(int)IndexHolder -- A variable designed to help the Hashtable keep track of it's indexes.
 *(Hashtable) valueTable The Hash table that stores a key and value.
*/
        {

           
            int RoomSize = 100;
            MClass.Rm_ControlNumMin = 100;
            int IndexHolder = 0; 
            IDictionary<String, int> valueTable = new Dictionary<String, int>();
            Room Roomtester = new Room();
            

            List<Room> RoomPopulator = new List<Room>();

            RoomPopulator = StationCreator(RoomSize);

           

          


            Console.ReadLine();


            List<Room> StationCreator(int Amt)
         
                
        



                            if (Dk_Retriever(HolderRoom.Get_Dk()) != 'X')
                            {   
                                RoomList.Add(new Room(Na: HolderRoom.Get_N(), NN: HolderRoom.NorthNeighbor, NE: HolderRoom.EastNeighbor, NW: HolderRoom.WestNeighbor, NS: HolderRoom.SouthNeighbor));
                                valueTable.Add(HolderRoom.Get_N(), IndexHolder);
                                //Console.Write(HolderRoom.Get_N());
                                //Console.Write(IndexHolder);

                                IndexHolder++;
                                
                                // System.Console.WriteLine(String.Concat(HolderRoom.Get_N(), "-", "(", HolderRoom.NorthNeighbor, ")", "(", HolderRoom.EastNeighbor, ")", "(", HolderRoom.WestNeighbor, ")", "(", HolderRoom.SouthNeighbor, ")"));
                            }

                          

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




        public static Room Rm_Get(String ind, List<Room> rm_List, IDictionary<String, int>hTable)
        //Searches Room list for a Room by first searching the k&v pair in the Dictionary object called "htable" by
        // the String key variable called "ind" and using the int value from that lookup as the index for the room to return.
        {
            var vTable = new Dictionary<string, int>(hTable);
     
        
            int xmFile = 0;
            xmFile = hTable[ind];
            return rm_List[xmFile];



        }



        public static void Screen_Draw(List<Room> Materials, IDictionary<string, int> tTable)
        { 
            IDictionary<String, int> valueTable = new Dictionary<String, int>(tTable);
            // var tempTable = new Dictionary<string, int>(tTable);
            int Columns = 11;
            const int rows = 0;
            for (int x = 0; x <= 3; x++)
            {
                for (int y = 0; y <= Columns; y++)
                {
                    Console.Write($"{Columns,rows}", "Hello");





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
            //If the current floor is equal to the minimum floor
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
            //If The current Deck is equal to the minimum Deck
            if (Deck == Min)
            {

                Dk_Min = true;

            }
            else if (Deck == max)
            {

                Dk_Max = true;

            }



        }



        //Constructor
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






























