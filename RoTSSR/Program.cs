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

           



             Node T_node = new Node();
             T_node = Station.Llist.Search("C25");
             T_node.selected = true;
          

         
        
            Node Help = new Node();
            Node Please = new Node();
      
            Help = Station.Llist.Search("A15");
            Please = Station.Llist.Search("C30");

           // Help.East_Bound.Blocked = true;
            //Help.West_Bound.Blocked = true;
            Help.North_Bound.Blocked = true;
            Help.South_Bound.Blocked = true;

            Console.WriteLine("South Bound ==" + " " + Help.South_Bound.Blocked);
            Console.WriteLine(Station.Llist.Search("A15").South_Bound.Blocked);
            Station.Llist.Distance2(Help, Please);


         
             //Station.Drawer("*");

            // Station.KeyListener();



       
         
           







            Console.Read();

     }


    }













          }


 









































