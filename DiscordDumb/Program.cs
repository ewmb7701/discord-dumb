using System;
using System.Threading;
using System.Windows.Forms;

namespace SINe.DiscordDumb
{
    class Program
    {
        /// <summary>
        /// Main method;
        /// Entry point;
        /// </summary>
        /// <param name="words"></param>
        static void Main(string[] words)
        {
            string input;
            while (true)
            {
                input = Console.ReadLine().ToLower();

                Console.Clear(); // clear console after reading new

                string built = "";
                foreach (char character in input) // for all the characters
                {
                    if(character != ' ') // if not a space
                    {
                        built += string.Format(":regional_indicator_{0}: ", character); // use regional indicator
                    }
                    else // is a space
                    {
                        built += string.Format("{0} ", SPACE_CHAR); // use 
                    }
                }

                Console.Out.WriteLine(built); // write it
                setClipboard(built); // set to clipboard
            }
        }

        /// <summary>
        /// Set the value to the clipboard;
        /// </summary>
        /// <param name="value">The value to put in the clipboard;</param>
        static void setClipboard(string value)
        {
            Thread thread = new Thread(() => Clipboard.SetText(value));
            thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA
            thread.Start();
            thread.Join();
        }

        /// <summary>
        /// Constant for the emoticon for spaces;
        /// </summary>
        const string SPACE_CHAR = ":white_large_square:";
    }
}
