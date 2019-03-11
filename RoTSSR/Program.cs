﻿using System;
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

        public Form f = new Form();
        
       
       
        
   





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
            String[] s_tester = new string[10];
            Llist Linker = new Llist();

            
            StationCreator Stat = new StationCreator();
            Linker = Stat.DB_Station();


            //Linker.printList();

            s_tester[0] = "1";
            s_tester[1] = "2";
            s_tester[3] = "3";
            s_tester[4] = "4";

            PrintRow(s_tester);
            PrintLine();
            
            Console.Read();


           



         











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

            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";
            /*
            foreach(string column in columns)
            {
                row += AlignCentre(column, width) + "|";

            }
            */

            while()
            Console.WriteLine(row);
        }

        static string AlignCentre(string text, int width)
        {

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






























