using System;
using System.IO;
using System.Collections;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;



namespace RoTSSR
{


    public class Driver : Screen_Draw
    {







   

        public static void Main(string[] args)
        {

            StationCreator Station = new StationCreator(50, 3, 3);

            //Console.Clear();




            //LinkedList monstar = new LinkedList();

            //monstar.Start(new Room(2,1,2));
            //monstar.Rear_Add(new Room(3, 2, 1));
            //monstar.Rear_Add(new Room(1, 2, 1));
            //monstar.Rear_Add(new Room(2, 1, 12));
            //monstar.Rear_Add(new Room(3, 1, 3));
            // monstar.Rear_Add(new Room(1, 3, 15));

            //monstar.printList();
            //monstar.DataSwap(monstar.Search("B12"), monstar.Search("A23"));
            //monstar.Sortv1();
            //monstar.printList();




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

            // Node T_node = new Node();
            //T_node = Station.Llist.Search("B11");
            //T_node.selected = true;
            //Station.Llist.N_pop();
            //Console.WriteLine(Station.Llist.Search("C315").room.Name);
            //System.Console.WriteLine(current.room.Name);

            //System.Console.WriteLine(T_node.room.Name);
            //System.Console.WriteLine(T_node.next.room.Name);
            //System.Console.WriteLine(Station.Llist.head.next.next.room.Name);
            Node Help = new Node();
            Node Please = new Node();
            Help = Station.Llist.Search("A15");
            Please = Station.Llist.Search("C30");
            Station.Distance(Help, Please);


             //String ky = Console.ReadKey.
             //Station.Drawer("*");

            //Station.KeyListener();

            //Console.WriteLine(ky);


       
         
            /*
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


            // Console.WriteLine(Station.Llist.head.room);
            // Console.WriteLine(Station.Llist.rear.room);
            //Station.Llist.rear.previous.previous.room.selected = true;
            //Station.Llist.printList();
            //Console.WriteLine(" ");
            //Console.WriteLine(" ");
            //Console.WriteLine(" ");
            //Station.Llist.Sortv1();
            //Station.Llist.printList();
            //Station.PrintNodes();





            Console.Read();

     }


    }













          }


 









































