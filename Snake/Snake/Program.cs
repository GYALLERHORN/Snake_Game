class SnakeGame
{
    static void Main()
    {
        DrawWall();
        for (int i = 0; i < 10; i++)
        {
            Thread.Sleep(500);
        }
    }
    class Snake
    {

    }


    static void DrawWall()
    {
        for (int i = 0; i < 50; i++)
        {
            Console.SetCursorPosition(i, 0);
            Console.Write("#");
            Console.SetCursorPosition(i, 20);
            Console.Write("#");
        }
        for (int i = 0; i < 21; i++)
        {
            Console.SetCursorPosition(0, i);
            Console.Write("#");
            Console.SetCursorPosition(50, i);
            Console.Write("#");
        }
    }

    class Food
    {

    }

    
}