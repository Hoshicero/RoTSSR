using System;
using System.Collections.Generic;

namespace RoTSSR
{
    /* The Room class is a container for the information of a particular room.
     * 
     * ******Variables******
     * 
     * 
     *  RoomType <-> THe RoomType variable holds a single int representation of one of the six RoomTypes: '0' = Accessway, '1' = Accomodations,
     * '2' = Corridor, '3' = Industrial, '4' = Service.
     * 
     *  Name <-> The Name variable holds the ID of the Room's Name.
     * 
     *
     * 
     *  Next_U\D\L\R <-> The Next_* variables of type String store the ID of a neighboring Room specific to the implicit rooms adjacency to   
     * that particular neighbor: 'U' = Up, 'D' = Down, 'L' = Left, 'R' = Right.
     * 
     *  Up, Down, Left, Right <-> These variables are of an object class named boundary, and refer to each of the four locational
     * boundary types of a given room: 'Door', 'Bulkhead', 'Deck Boundary'.
     * 
     * 
     ******Methods******
     * Setters()
     * Getters()
     *
     *
     * SetAllBounds <-> The SetAllBounds method takes 20 variables, every five out of the 20, data to be fed into the appropriate Boundary variable. 
     * The SetAllBounds method does this by calling the SetBoundary function a total of four times for the four Boundary variables. 
     * 
     *
     *


    */



    public class Room
    {
        public class Boundary : Object
        {
            public bool Locked { get; set; }
            public bool Electric { get; set; }
            public bool Blocked { get; set; }
            public Boundary() { Locked = false; Electric = false; Blocked = false; }

            public void Locker() { Locked = true; }
            public void Blocker() { Locked = true; }
            public void Unlocker() { Locked = false; }
            public void Unblocker() { Locked = false; }
           
        }
       
           
          

        


        public int Deck { get; set; } //The Deck this Room is on
        public int Num { get; set; } // The Room Number this room has.
        public int Floor { get; set;} //The Floor Number this Room is on.
        public String Name { get; set;} // The Name of this Room{Deck + Floor + Room Number}. 

        public String North_Neighbor {get; set;}
        public String South_Neighbor {get; set;}
        public String East_Neighbor {get; set;} 
        public String West_Neighbor {get; set;}

        public Boundary North_Bound = new Boundary();
        public Boundary South_Bound = new Boundary();
        public Boundary East_Bound = new Boundary();
        public Boundary West_Bound = new Boundary();




        public Room (int num, int fl, int deck)
        {
            North_Neighbor = null;
            South_Neighbor = null;
            East_Neighbor = null;
            West_Neighbor = null;
            Num = num;
            Floor = fl;
            Deck = deck;
            Name = String.Concat(Dk_retriever(deck), fl, num);
            //Console.WriteLine("Activating Room" + " " + Name);
        }

        public Room(){}

       ~Room() { }

        public String Dk_retriever(int num)
        {
            switch (num)
            {

                case 1:
                    return "A";

                case 2:
                    return "B";

                case 3:
                    return "C";

                case 4:
                    return "D";

                case 5:
                    return "E";

                case 6:
                    return "F";

                case 7:
                    return "G";

                case 8:
                    return "H";

                case 9:
                    return "I";

                case 10:
                    return "J";

                case 11:
                    return "K";

                case 12:
                    return "L";

                case 13:
                    return "M";

                case 14:
                    return "N";

                case 15:
                    return "O";

                case 16:
                    return "P";

                case 17:
                    return "Q";

                case 18:
                    return "R";

                case 19:
                    return "S";

                case 20:
                    return "T";

                case 21:
                    return "U";

                case 22:
                    return "V";

                case 23:
                    return "W";

                case 24:
                    return "X";

                case 25:
                    return "Y";

                case 26:
                    return "Z";
                default:
                    return null;
            }

        }

    }

}
    



 






