using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Simple_Level_Designer
{
    class Program
    {
        /*
         * Level Key:
         * 
         * 0 - Empty
         * W - Wall
         * I - Invisible Wall
         * M - Mirror
         * E - Enemy
         * P - Player
         * 
         */

        static void Main(string[] args)
        {
            //Variables
            string userInput;
            int columns;
            int rows;
            StreamWriter output;
            string filepath;
            string welcome = @"   _____                   _        _   Welcome to the   _   _____            _                       
  / ____\                 | |      | |                  | | |  __ \          (_)                      
 | (___  _ _ __ ___  _ __ | | ___  | |     _____   _____| | | |  | | ___  ___ _  __ _ _ __   ___ _ __ 
  \___ \| | '_ ` _ \| '_ \| |/ _ \ | |    / _ \ \ / / _ \ | | |  | |/ _ \/ __| |/ _` | '_ \ / _ \ '__|
  ____) | | | | | | | |_) | |  __/ | |___|  __/\ V /  __/ | | |__| |  __/\__ \ | (_| | | | |  __/ |   
 |_____/|_|_| |_| |_| .__/|_|\___| |______\___| \_/ \___|_| |_____/ \___||___/_|\__, |_| |_|\___|_|   
                    | |                                                          __/ |                
                    |_|               by Jackson Majewski                       |___/                 
";

            //Print welcome message
            Console.WriteLine(welcome + "\n");

            System.IO.Directory.CreateDirectory("levels"); //Create levels directory if it doesn't exist

            //Set level file
            Console.Write("Level Name> ");
            userInput = Console.ReadLine();
            filepath = "levels\\" + userInput + ".sslvl";
            output = new StreamWriter(filepath);

            //Get width of room in tiles
            Console.Write("width> ");
            userInput = Console.ReadLine();
            columns = int.Parse(userInput);

            //Get height of room in tiles
            Console.Write("height> ");
            userInput = Console.ReadLine();
            rows = int.Parse(userInput);

            output.WriteLine("{0}, {1}", rows, columns);

            //Top row
            for (int i = 0; i < columns; i++)
                output.Write("W");
            output.WriteLine();

            for (int i = 1; i < rows - 1; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (j == 0 || j == columns - 1)
                    {
                        output.Write('W');
                    }
                    else
                        output.Write('0'); //Not a wall
                }
                output.WriteLine();
            }

            //Bottom row
            for (int i = 0; i < columns; i++)
                output.Write("W");

            //Close
            output.Close();

            System.Diagnostics.Process.Start(@filepath);
        }
    }
}
