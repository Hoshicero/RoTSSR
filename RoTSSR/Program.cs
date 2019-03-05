using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


namespace ConsoleApp1
{
    public class ClassCreator : StationCreator
    {
        public ClassCreator(int Flmin, int Flmax, int Rmmin, int Rmmax, int Dkmin, int Dkmax, int RmDiv, int Rmperfl, int Rm_Amt, int lnum)
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
        public static object Fl_control { get; private set; }

    
    public static void Main (string[] args)

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
        int IndexHolder = 0;
        IDictionary<String, int> valueTable = new Dictionary<String, int>();
            Room Roomtester = new Room();
            Room Roomtester2 = new Room();
            Room Roomtester3 = new Room();
            Room Roomtester4 = new Room();
            Llist Linker = new Llist();

            Roomtester.SetName("A1");
            Roomtester.SetNorth_Neighbor("I'm weenie A1");
           
            Linker.Start(Roomtester);
            Console.WriteLine("Head is.." + Linker.head.room.GetName());

            Roomtester2.SetName("A2");
            Roomtester2.SetNorth_Neighbor("I'm weenie A2");
            Linker.Front_Add(Roomtester2);
            Console.WriteLine("Head is.." + Linker.head.room.GetName());
            Console.WriteLine("Next is.." + Linker.head.next.room.GetName());
            Console.WriteLine("Rear is.." + Linker.rear.room.GetName());

            
            Roomtester3.SetName("A3");
            Roomtester3.SetNorth_Neighbor("I'm weenie A3");
            Linker.Front_Add(Roomtester3);
            Console.WriteLine("Head is.." + Linker.head.room.GetName());
            Console.WriteLine("Next is.." + Linker.head.next.room.GetName());
            Console.WriteLine("Rear is.." + Linker.rear.room.GetName());

            Roomtester4.SetName("A4");
            Roomtester4.SetNorth_Neighbor("I'm weenie A4");
            Linker.Rear_Add(Roomtester4);
            Console.WriteLine("Head is.." + Linker.head.room.GetName());
            Console.WriteLine("Next is.." + Linker.head.next.room.GetName());
            Console.WriteLine("Rear is.." + Linker.rear.room.GetName());
            Console.WriteLine("Previous is.." + Linker.rear.previous.room.GetName());

            Linker.printList();
            //Linker.Search("A3");
            Console.ReadLine();
            Linker.Delete("A2");
            Linker.printList();
            Console.WriteLine("Head is.." + Linker.head.room.GetName());
            Console.WriteLine("Rear is.." + Linker.rear.room.GetName());
            Console.ReadLine();
            Linker.Delete("A3");
            Linker.printList();
            Console.WriteLine("Head is.." + Linker.head.room.GetName());
            Console.WriteLine("Rear is.." + Linker.rear.room.GetName());
            Console.ReadLine();
            Linker.Delete("A1");
            Linker.printList();
            Console.WriteLine("Head is.." + Linker.head.room.GetName());
            Console.WriteLine("Rear is.." + Linker.rear.room.GetName());
            Console.ReadLine();
            Linker.Delete("A4");
            Linker.printList();
            Console.WriteLine("Head is.." + Linker.head.room.GetName());
            Console.WriteLine("Rear is.." + Linker.rear.room.GetName());



           



            /*
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


     */
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





    /*
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
        */

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
   
}






























