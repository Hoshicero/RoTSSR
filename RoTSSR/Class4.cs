using System;

public class StationCreator
{
    public Class1() { }
    /***************CONTROL VARIABLES****************/
    private int FloorControl { get; set; } /*The total amount of Floors desired Since we are counting down from Floormonitor, the zero means that we want three rooms*/
    private int DeckControl { get; set; }/*The total amount of Decks desired*/
    private bool Decktrigger { get; set; } /*Decktrigger activates(true) when it is time to go to a new Deck*/
    private int Roomdivisor { get; set; }/*Room Divisor is the total amount of floors on the gameboard. For our game the board consists of three decks with three floors each, thus netting a total 9 floors*/
    private int Roomamt { get; set; } /*By dividing the toatal of Amt by the total number of floors, we can arrive at the total number of rooms requested for the gameboard.*/
    private const int Maxnumber = 30; //The maximum number a room can be at any given time.
    private const int Leastnumber = 0; //The least number a room can be at any given time.


    /***************CONTAINER VARIABLES*******************************/
    private String NorthNeighbor = null;
    private String SouthNeighbor = null;
    private String EastNeighbor = null;
    private String WestNeighbor = null;
    private String CurrentRoom = null;
    private char CurrentDeck { get; set; }/*CurrentDeck marks the Deck letter the room is on*/
    private char Comparisonfloor { get; set; }

    /************************COUNTER VARIABLES*************************************/

    private int Roomtracker {get; set;} /*Floortracker is a counter that keeps track of how many rooms have been made, it will be used to trigger the next floor*/
    private int Floortracker {get; set;} /*Floortrigger keeps track of how many floors that have been made. Every fitieth floor, the trigger goes up by one, after three it resets.*/
    private int FloorMonitor { get; set; } /*Keeps track of the current level of floor It starts out as three because the numbers go up in ascending order*/
    private int DeckMonitor { get; set; } /*Keeps track of the current Deck*/
    private int DoLoopControl { get; set;} /*The control that keeps track of how many times the loop has ran. */







    public Gatekeeper1(int )



   


}
