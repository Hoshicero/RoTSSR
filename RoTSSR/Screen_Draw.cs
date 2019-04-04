using System;
namespace RoTSSR
{
    public class Screen_Draw : LinkedList
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
       
    }
}
