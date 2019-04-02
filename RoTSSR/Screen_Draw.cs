using System;
namespace RoTSSR
{
    public class Screen_Draw
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
        public static void Drawer(int fl, int dk, int rpf, Node current, String data)
        {

            origRow = Console.CursorTop;
            origCol = Console.CursorLeft;


            try
            {

                for (int row = 0; row < (fl * dk); row++)
                {
                    for (int col = 0; col < rpf; col++)
                    {
                        current.Xcord = col * 2;
                        current.Ycord = row;


                        if (current.selected == true)
                        {
                            WriteAt("+", current.Xcord , current.Ycord);
                            current = current.next;
                        }

                        else
                            try
                            {
                                
                                WriteAt("*", current.Xcord, current.Ycord);
                                current = current.next;
                            }
                            catch (NullReferenceException e)
                            {
                                System.Console.WriteLine("error -- Current.next is null");

                            }


                    }



                }


            }
               catch (NullReferenceException t)
            {
                System.Console.WriteLine("error -- current is a null value");
                return;
            }

        }
    }
}
