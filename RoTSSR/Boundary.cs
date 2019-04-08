using System;
namespace RoTSSR

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


        public bool Locked { get; set; }
        public bool Electric{ get; set; }
        public bool Blocked { get; set; }



       Boundary()
        {
            Locked = false;
            Electric = false;
            Blocked = false;
            
        }

        
      



    }
}
