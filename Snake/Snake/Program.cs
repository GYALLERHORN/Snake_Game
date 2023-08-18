using System.Drawing;

class SnakeGame
{
    static void Main()
    {
        // 공간 생성명령
        DrawWall();
        // 뱀 생성명령

        // 음식 생성명령
        // 뱀 동작명령
        // 뱀 충돌 감지
        // 


        
    }
    enum Direction
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    }

    class Coordinate
    {
        public int x { get; set; }
        public int y { get; set; }
        public string symbol { get; set; }

        public Coordinate(int _x, int _y, string _symbol)
        {
            x = _x;
            y = _y;
            symbol = _symbol;
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
        }
    }

    class Snake
    {
        // 뱀 생성
        public List<Coordinate> wholeBody;
        public Direction direction;

        public Snake( Coordinate coordinate, int bodyLength,  Direction _direction )
        {
            direction = _direction;
            wholeBody = new List<Coordinate>();

        }
        // 뱀 동작
        // 뱀 충돌 판별&상황별 동작
    }



    class Food
    {
        // 음식 생성
        // 음식 재생성
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
}