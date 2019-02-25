using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public  class StationCreator
    {

        /*Title: StationCreator
             *Arguments:
             * (int)Rm_Amt -- The amountof rooms requested by the operator.
             * Variables:
             * (int)Fl_ControlNumMin -- The least amount of floors desired
             * (int)Fl_ControlNumMax -- The max amount of floors desired
             * (int)DK_ControlNumMin -- The least amount of Decks desired
             * (int)Dk_ControlNumMax -- The Most amount of Decks desired.
             * (int)Rm_Divisior -- Room Divisor is the total number of desired floors for the gameboard. 
             * (int)Rm_PerFloor -- Is the calculated result of the division 
         */
            

               /***************CONTROL VARIABLES****************/
       public int Fl_ControlNumMin { get; set;}
       public  int Fl_ControlNumMax { get; set;}
       public  int Rm_ControlNumMin { get; set;}
       public int Rm_ControlNumMax { get;set;}
       public int Dk_ControlNumMin { get; set;}
       public int Dk_ControlNumMax { get; set;}
       public int Rm_Divisor { get; set;}
       public int Rm_PerFloor { get; set;} /*By dividing the total amount of rooms by the total number of floors, we can arrive at the total number of rooms per floor.*/
       public int Rm_Amt { get; set;}
       public int Leastnumber{get; set;}//The least number a room can be at any given time.
       public StationCreator() { } /*Constructor*\

        /***************CONTAINER VARIABLES*******************************/

        /*
             public StationCreator(int Flmin, int Flmax, int Rmmin, int Rmmax, int Dkmin, int Dkmax, int RmDiv, int Rmperfl, int Rm_Amt, int lnum)
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


        /************************COUNTER VARIABLES*************************************/

        int Rm_Tracker { get; set; } /*Floortracker is a counter that keeps track of how many rooms have been made, it will be used to trigger the next floor*/
        int Fl_Monitor { get; set; } /*Keeps track of the current level of floor It starts out as three because the numbers go up in ascending order*/
        int Dk_Monitor { get; set; } /*Keeps track of the current Deck*/
        int Fl_Tracker { get; set; }



        /*****************************************************************************/


       

        String nNeighborCalculations(String HolderRoom)
        {
            /*"X" Is a default value that I set to act as a gatekeeper*/

            if (HolderRoom == "X")
            {

                /*IF YOU ARE ON THE TOP DECK ON THE TOP FLOOR, YOU HAVE NO NORTH*/

                if ((Dk_Monitor == Dk_ControlNumMin) && (Fl_Monitor == Fl_ControlNumMin))
                {


                    return "X";


                }

                /*OR IF you are on the highest floor of your deck,
                Your N_Neighbor will be equal to a string that is a concatenation of the result of your current Deck Minus one,
                 The Max Floor Control value, and your current room number. 
                 Ex: CurrentRoom is B123, B123's North Neighbor would be: (*B*(2) - 1) = (1)*A*), Fl_Max = 3, and 123 giving a total value of : A3123 *
                 */

                else if (Fl_Monitor == Fl_ControlNumMin)
                {


                    return String.Concat(Dk_Retriever(Dk_Monitor - 1), Fl_ControlNumMin);

                }


                else
                    return String.Concat(Dk_Retriever(Dk_Monitor), (Fl_Monitor - 1));
                //OTHERWISE YOUR NORTH NEIGHBOR CONSISTS OF YOUR DECK, YOUR FLOOR - 1, AND YOUR CURRENT ROOM NUMBER.

            }

            else
                return null;


        }

        String sNeighborCalculations(String HolderRoom)

        {
            if (HolderRoom == "X")
            {

                /*IF YOU ARE THE LOWEST DECK ON THE LOWEST FLOOR, YOU HAVE NO SOUTH NEIGHBOR*/
                if ((Dk_Monitor == Dk_ControlNumMax) && (Fl_Monitor == Fl_ControlNumMax))
                {


                    return "X";


                }
                /*IF YOU HAPPEN TO BE ON THE FLOOR OF A DECK RIGHT ABOVE THE TOP FLOOR OF ANOTHER DECK */
                else if (Fl_Tracker == Fl_ControlNumMax)
                {
                    return String.Concat(Dk_Retriever(Dk_Monitor + 1), Fl_ControlNumMin);
                }

                else
                    return String.Concat(Dk_Retriever(Dk_Monitor), (Fl_Monitor + 1));


            }

            else
                return null;

        }


        public String wNeighborCalculations(String HolderRoom, int Lnumber)
        {

            if (HolderRoom == "X")
            {

                /*IF YOU ARE THE FIRST ROOM ON YOUR FLOOR, YOU HAVE NO EAST NEIGHBOR*/
                if (Lnumber == Rm_ControlNumMin)
                {


                    return "X";

                }


                else
                    return String.Concat(Dk_Retriever(Dk_Monitor), Fl_Monitor);


            }
            else return null;

        }


        public String eNeighborCalculations(String HolderRoom, int Rm_PerFloor)
        {


            if (HolderRoom == "X")
            {

                /*IF YOU ARE THE LAST ROOM ON YOUR FLOOR, YOU HAVE NO EAST NEIGHBOR*/
                if (Rm_PerFloor == Rm_ControlNumMax)
                {


                    return "X";

                }


                else
                    return String.Concat(Dk_Retriever(Dk_Monitor), Fl_Monitor);


            }

            else return null;


        }




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
