using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GarageApplication
{
    /// <summary>
    ///  Class that prevents crashes in the program from user input errors.
    ///  If the user makes wrong input (ie. a string when expected input was an int) it will
    ///  just print an error msg in console and ask the user to try again instead of crashing the program.
    /// </summary>
    public class UserInputHelper
    {
        string input;
        int intOutput = 0;
        bool successfulParse = false;
        /// <summary>
        /// Method that handles user inputs that are supposed to be an int.
        /// </summary>
        public int ParseIntInput()
        {
            while (!successfulParse)
            {
                input = Console.ReadLine();
                if (input.All(char.IsNumber))
                {
                    int.TryParse(input, out intOutput);
                    successfulParse = true;
                }
                else
                {
                    Console.WriteLine("\nInput needs to be an int, please try again!\n");
                }
            }
            successfulParse = false;
            return intOutput;
        }
        /// <summary>
        /// Method that handles user inputs that are supposed to be an int.
        /// And correctly changes the user input when they are asked to make a choice that
        /// is based in a list or an array, where index starts at 0 but the
        /// printed summary of the container sets starting number at 1.
        /// </summary>
        public int FixIndexPosParseIntInput()
        {
            while (!successfulParse)
            {
                input = Console.ReadLine();
                if (input.All(char.IsNumber))
                {
                    int.TryParse(input, out intOutput);
                    intOutput--;
                    successfulParse = true;
                }
                else
                {
                    Console.WriteLine("\nInput needs to be an int, please try again!\n");
                }
            }
            successfulParse = false;
            return intOutput;
        }
        /// <summary>
        /// Method that handles user inputs that are supposed to be a string.
        /// </summary>
        public string ParseStringInput()
        {
            while (!successfulParse)
            {
                input = Console.ReadLine();
                if (input.All(char.IsLetter))
                {
                    successfulParse = true;
                }
                else
                {
                    Console.WriteLine("\nInput needs to be a string, please try again!\n");
                }
            }
            successfulParse = false;
            return input;
        }
    }
}
