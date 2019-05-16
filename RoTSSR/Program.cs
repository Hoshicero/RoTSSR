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
            
            String node = "A30";
            String node2 = "C20";
            Occu_Node Occu = new Occu_Node("P");
            Room_Node  Start = new  Room_Node();
            Room_Node  Stop = new  Room_Node();

            
             //Start = Station.Llist.Search(node);
            //Stop = Station.Llist.Search(node2);
            Occu.Occupant.ID = "fsuif";
           // Start.Occupancies.Start(Occu);
            //Start.Occupancies.Rear_Add(new Occu_Node("P"));
            //Room_Node test = Station.Llist.Search(node);
            //Station.Llist.Search(node2).Occupancies.Start(Occu);
            Station.Llist.Search(node2).Occupancies.Front_Add(new Occu_Node("P"));
            Station.Llist.Search(node2).Occupancies.Rear_Add(new Occu_Node("F"));
            Station.Llist.Search(node2).Occupancies.PrintList();
            Station.Llist.Search(node).Occupancies.Rear_Add(Occu);
            //Station.Llist.Search(node).Occupancies.Delete("fsuif");
            //Console.WriteLine(Station.Llist.Occu_Search("fsuif").ID);
            //Station.Llist.Search(node2).Occupancies.PrintList();
            //Station.Llist.Occu_Pass(Station.Llist.Search(node), Station.Llist.Search(node2), Start.Occupancies.Search("fsuif"));
            //Console.WriteLine(Station.Llist.Occu_Search("fsuif").room.Name);
            //Console.WriteLine(Station.Llist.Search("A15").Occupancies.Search("Player").Occupant.ID);
            //Console.WriteLine(Station.Llist.Search("C35").Occupancies.Search("Foe").Occupant.ID);
            //Console.WriteLine(Station.Llist.Search("C35").Occupancies.Search("Blow").Occupant.ID);
            //Console.WriteLine("East" + Station.Llist.Search("A30").E_node.room.Name);
            //Console.WriteLine("West" + Station.Llist.Search("A30").W_node.room.Name);


            //Station.Llist.Search("C35").Occupancies.PrintList();
            //test.Occupancies.Front_Add(new Occu_Node("F"));
            //test.Occupancies.Front_Add(new Occu_Node("F"));
            //test.Occupancies.Front_Add(new Occu_Node("P"));
            //test.Occupancies.Front_Add(new Occu_Node("F"));
            //test.Occupancies.Delete("Foe");
            //test.Occupancies.PrintList(); 
            //test.Occupancies.Start(Occu);


            /*
             try
             {
                   Console.WriteLine("East" + Station.Llist.Search(node).E_node.room.Name);
                   Console.WriteLine("West" + Station.Llist.Search(node).W_node.room.Name);
                   //Console.WriteLine("South" + Station.Llist.Search(node).S_node.room.Name);
                   Console.WriteLine("North" + Station.Llist.Search(node).N_node.room.Name);
             }
             catch (NullReferenceException)
             {

             }
             */

            //Station.Llist.printList();

            //  Room_Node T_node = new Room_Node();
            //  T_node = Station.Llist.Search("C25");
            //T_node.selected = true;




            //  Node Help = new Node();
            //  Node Please = new Node();

            // Help = Station.Llist.Search("A15");
            // Please = Station.Llist.Search("C30");

            //  Help.East_Bound.Blocked = true;
            //  Help.West_Bound.Blocked = true;
            //  Help.North_Bound.Blocked = true;
            //  Help.South_Bound.Blocked = true;

            // Console.WriteLine("South Bound ==" + " " + Help.South_Bound.Blocked);
            //   Console.WriteLine(Station.Llist.Search("A15").South_Bound.Blocked);
            //  Station.Llist.Distance2(Help, Please);

            //Station.Llist.printList();


            //Station.Drawer("*");
            // Station.KeyListener();














            Console.Read();

     }


    }













          }


 









































