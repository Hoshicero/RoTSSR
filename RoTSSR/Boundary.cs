using System;
namespace ConsoleApp1

/* The Boundary class stores allows for the initialization of various boundaries throughout the game.

 ******Variables******
 * 
 * Position <-> The position variable of type char serves as a representaton of the four different directional orientations of the room object:
 * 'U' = Up, 'D' = Down, 'L' = Left, 'R' = Right.
 * 
 * Open <-> The Open variable of type bool keeps track of if the boundary is considered open or closed. 'True' = Open, 'False' = Closed.
 * 
 * Passable <-> The Passable variable of type bool keeps track of if the boundary is considered passable or not. 'True' = passable, 'False' = !Passable.
 * 
 * Unlocked <-> The Unlocked variable of type bool keeps track of the Boundary's Unlocked status. 'True' = Unlocked, False = Locked;
 * 
 * Electrified <-> The Electrified variable of type bool keeps track of the Boundary's Electrified status. 'True' = Electrified, False = !Electrified.
 * 
 ******Methods******
 *
 *Setters()
 *
 *Getters()
 *
 *Constructors()
 *
 *~Destructor()
 *
 *
 *//////////////

{
    public class Boundary
    {


        private char Position;
        private bool Open;
        private bool Passable;
        private bool Unlocked;
        private bool Electrified;



        public void SetOpen(bool temp) { Open = temp; }
        public void SetPosition(char P) { Position = P; }
        public void SetPassable(bool temp) { Passable = temp; }
        public void SetUnlocked(bool temp) { Unlocked = temp; }
        public void SetElectrified(bool temp) { Electrified = temp; }

        public void SetDoor()
        {

            SetPassable(true);
            SetUnlocked(false);
            SetOpen(false);
        }


        public void SetBulkhead()
        {

            SetPassable(false);
            SetOpen(false);
            SetUnlocked(false);
            SetElectrified(false);

        }




        public bool GetOpen() { return Open; }
        public bool GetPassable() { return Passable; }
        public bool GetLocked() { return Unlocked; }
        public bool GetElectrified() { return Electrified; }
        public char GetPosition() { return Position; }


        public Boundary()
        {

            Position = 'N';
            Open = false;
            Passable = false;
            Unlocked = false;
            Electrified = false;

        }

        public Boundary(char Pos, bool O, bool P, bool L, bool E)
        {

            Position = Pos;
            Open = O;
            Passable = P;
            Unlocked = L;
            Electrified = E;


        }

        public Boundary(char Pos)
        {

            Position = Pos;
        }

      



    }
}
