using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 12;
            Console.WindowWidth = 22;
            int screenwidth = Console.WindowWidth;
            int screenheight = Console.WindowHeight;
            int playfieldWidth = screenwidth - 1;
            int playfieldHeight = screenheight - 1;

            Random randomnummer = new Random();
            int score = 5;
            int gameover = 0;
            int highscore = 0;

            int[] xpos = new int[50];
            int[] ypos = new int[50];

            int berryx = randomnummer.Next(0, playfieldWidth);
            int berryy = randomnummer.Next(0, playfieldHeight);

            string input = "right";
            int velocity = 1;
            int previousshiftx;
            int previousshihty;

            for (int i = 0; i < score; i++)
            {
                xpos[i] = 10;
                ypos[i] = 10;
            }

            while (true)
            {
                if (xpos[0] == playfieldWidth - 1 || xpos[0] == 0 || ypos[0] == playfieldHeight - 1 || ypos[0] == 0)
                {
                    gameover = 1;
                    break;
                }

                for (int i = score; i > 0; i--)
                {
                    xpos[i] = xpos[i - 1];
                    ypos[i] = ypos[i - 1];
                }
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo inputKey = Console.ReadKey();
                    switch (inputKey.Key)
                    {
                        case ConsoleKey.UpArrow:
                            if (input != "down")
                            {
                                input = "up";
                            }
                            break;

                        case ConsoleKey.DownArrow:
                            if (input != "up")
                            {
                                input = "down";
                            }
                            break;

                        case ConsoleKey.LeftArrow:
                            if (input != "right")
                            {
                                input = "left";
                            }
                            break;

                        case ConsoleKey.RightArrow:
                            if (input != "left")
                            {
                                input = "right";
                            }
                            break;
                    }
                }
                switch (input)
                {
                    case "up":
                        ypos[0]--;
                        break;

                    case "down":
                        ypos[0]++;
                        break;

                    case "left":
                        xpos[0]--;
                        break;

                    case "right":
                        xpos[0]++;
                        break;
                }
                for (int i = 1; i < score; i++)
                {
                    if (xpos[i] == xpos[0] && ypos[i] == ypos[0])
                    {
                        gameover = 1;
                    }
                }
                if (xpos[0] == berryx && ypos[0] == berryy)
                {
                    score++;
                    berryx = randomnummer.Next(1, playfieldWidth);
                    berryy = randomnummer.Next(1, playfieldHeight);
                }
                Console.Clear();
                if (gameover == 0)
                {
                    for (int i = 0; i < playfieldWidth; i++)
                    {
                        Console.SetCursorPosition(i, 0);
                        Console.Write("■");
                    }
                    for (int i = 0; i < playfieldWidth; i++)
                    {
                        Console.SetCursorPosition(i, playfieldHeight);
                        Console.Write("■");
                    }
                    for (int i = 0; i < playfieldHeight; i++)
                    {
                        Console.SetCursorPosition(0, i);
                        Console.Write("■");
                    }
                    for (int i = 0; i < playfieldHeight; i++)
                    {
                        Console.SetCursorPosition(playfieldWidth, i);
                        Console.Write("■");
                    }
                    for (int i = 0; i < score; i++)
                    {
                        if (i == 0)
                        {
                            Console.SetCursorPosition(xpos[i], ypos[i]);
                            Console.Write("■");
                        }
                        else
                        {
                            Console.SetCursorPosition(xpos[i], ypos[i]);
                            Console.Write("■");
                        }
                    }
                    Console.SetCursorPosition(berryx, berryy);
                    Console.Write("■");
                }
                if (gameover == 1)
                {
                    Console.WriteLine("게임 오버!");
                    Console.ReadLine();
                    if (score > highscore)
                    {
                        highscore = score;
                    }
                    break;
                }
                Thread.Sleep(100);
            }
        }
    }
}