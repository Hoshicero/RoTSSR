using System;
using System.IO;
using System.Collections;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;



namespace ConsoleApp1
{
    public class ClassCreator : StationCreator
    {

        /*
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
        */
        static int tableWidth = 77;

     
       
        
   





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

            


            Room Roomtester = new Room();
            Room Roomtester2 = new Room();
            Room Roomtester3 = new Room();
            Room Roomtester4 = new Room();
            Llist Linker = new Llist();
            String what;
            Llist.Node Bitchplease = new Llist.Node();
            
            StationCreator Stat = new StationCreator();
            Linker = Stat.DB_Station();


            D_Screen(Stat);


            //Linker.printList();
            //Bitchplease = Linker.Search("C30");
            //Bitchplease.room.selected = true;
            //PrintRow(s_tester);
            //Linker.PrintNodes();
            // PrintLine();

            //what = ;
            //Key_Listener(Console.ReadLine().ToString());
           // Console.Write(what);

           // Console.Read();
            

           


           



         











    }





        public static void D_Screen(StationCreator stat)
        {
            
            Llist Linker = new Llist();
            Linker = stat.DB_Station();
            Llist.Node current = new Llist.Node();
            current = Linker.rear;
            current.room.selected = true;
            Linker.PrintNodes();
            Key_Listener(Console.ReadLine().ToString(), Linker, current);
            Linker.PrintNodes();
            Console.Read();

        }

       public static void Key_Listener(string input, Llist T_list, Llist.Node search)
        {
            Llist.Node temp = new Llist.Node();
            temp = T_list.Search(search.room.GetName());

            switch (input)
            {

                case "w":
                    Console.WriteLine("up");
                    if(temp.room.GetNeighbor_N() != null)
                    {
                        temp.room.selected = false;
                        temp = T_list.Search(temp.room.GetNeighbor_N());
                        temp.room.selected = true;
                        Console.Clear();
                        break;
                    }
                   // Key_Listener(Console.ReadLine().ToString());
                    break;
                case "s":
                    Console.WriteLine("Down");


                    if (temp.room.GetNeighbor_S() != null)
                    {
                        temp.room.selected = false;
                        temp = T_list.Search(temp.room.GetNeighbor_S());
                        temp.room.selected = true;
                        Console.Clear();
                        break;
                    }
                    //Key_Listener(Console.ReadLine().ToString());
                    break;
                case "a":
                    Console.WriteLine("Left");
                    //Key_Listener(Console.ReadLine().ToString());
                    break;
                case "d":
                    Console.WriteLine("Right");
                   // Key_Listener(Console.ReadLine().ToString());
                    break;
                default:
                    break;

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

        static void PrintLine()
        {

            Console.WriteLine(new string('-', tableWidth));


        }

        static void PrintRow(params string[] columns)
        {
            /*
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";
            
            foreach(string column in columns)
            {
                row += AlignCentre(column, width) + "|";

            }
            */

            
            //Console.WriteLine(row);
        }

        static string AlignCentre(string text, int width)
        {
           // Console.WriteLine(text);

            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

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






























