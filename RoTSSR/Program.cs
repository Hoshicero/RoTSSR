﻿using System;
using System.IO;
using System.Collections;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;



namespace RoTSSR
{


    public class Driver
    {


        protected static int origRow;
        protected static int origCol;

        protected static void WriteAt(String s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(origCol + x, origRow + y);
                Console.Write(s);

            }
            catch (ArgumentOutOfRangeException e)
            {

                Console.Clear();
                Console.WriteLine(e.Message);

            }

        }




   

        public static void Main(string[] args)
        {

            StationCreator Station = new StationCreator(100, 3, 3);

            Console.Clear();
            origRow = Console.CursorTop;
            origCol = Console.CursorLeft;










            /*
            while(Station.Llist.head.next != null)
            {
                int top = 0;


                for(int col = 0; col <= 5; col++)
                {

                    WriteAt(Station.Llist.head.room.Name, col+5, 0);
                    Station.Llist.head = Station.Llist.head.next;
                    top++;
                }


            }
            */





            /*
            WriteAt("A333", 0, 0);
            WriteAt("A444", 5, 0);
            WriteAt("A555", 10, 0);
            WriteAt("A666", 15, 0);
            WriteAt("A333", 20, 0);
            WriteAt("A444", 25, 0);
            WriteAt("A555", 30, 0);
            WriteAt("A666", 35, 0);
            WriteAt("A333", 40, 0);
            WriteAt("A444", 45, 0);
            WriteAt("A555", 50, 0);
            WriteAt("A666", 55, 0);
            WriteAt("A333", 60, 0);
            WriteAt("A444", 65, 0);
            WriteAt("A555", 70, 0);
            WriteAt("A666", 75, 0);
            WriteAt("A333", 80, 0);
            WriteAt("A444", 85, 0);
            WriteAt("A555", 90, 0);
            WriteAt("A666", 95, 0);
            WriteAt("A333", 100, 0);
            WriteAt("A444", 105, 0);
            WriteAt("A555", 110, 0);
            WriteAt("A666", 115, 0);
            */

            //
            // Console.WriteLine(Station.Llist.head.room);
            // Console.WriteLine(Station.Llist.rear.room);
            Station.Llist.rear.room.selected = true;
            Station.PrintNodes();





            Console.Read();

     }


    }













          }


 









































