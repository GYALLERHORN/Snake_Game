using System.Diagnostics;
using System.Drawing;

class SnakeGame
{
    static void Main()
    {
        // 공간 생성명령
        DrawWall();

        // 뱀
        Point point = new Point(10, 10, "*");
        Snake snake = new Snake(point, 5, Direction.RIGHT);
        snake.SnakeDraw();

        // 음식 생성명령
        FoodCreator foodCreator = new FoodCreator(50, 20, "!"); // x50, y20 중 무작위 칸에 음식!이 생성될 겁니다.
        Point food = foodCreator.CreateFoodPosition(); // x50, y20 중 무작위 칸에 생성될 음식의 위치를 정합니다.
        food.Draw(); // 정해진 칸에 음식을 그립니다.

        while (true)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        snake.direction = Direction.LEFT;
                        break;
                    case ConsoleKey.RightArrow:
                        snake.direction = Direction.RIGHT;
                        break;
                    case ConsoleKey.UpArrow:
                        snake.direction = Direction.UP;
                        break;
                    case ConsoleKey.DownArrow:
                        snake.direction = Direction.DOWN;
                        break;
                } 
            }

            if (snake.SnakeEatFood(food))
            {
                food.Draw();
                food = foodCreator.CreateFoodPosition();
                food.Draw();
            }
            else
            {
                snake.Move();
            }

            if (snake.SnakeHitTail() || snake.SnakeHitWall())
            {
                break;
            }

            Thread.Sleep(200);
        }
        Console.SetCursorPosition(1, 21);
        Console.WriteLine("GAMEOVER|GAMEOVER|GAMEOVER|GAMEOVER|GAMEOVER|GAMEOVER|GAMEOVER|GAMEOVER|GAMEOVER|GAMEOVER|");
    }
    enum Direction
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    }

    class Point
    {
        public int x { get; set; }
        public int y { get; set; }
        public string symbol { get; set; }

        public Point(int _x, int _y, string _symbol) // Point 클래스를 사용할 변수는 다음과 같은 자료형을 가집니다. 
        {
            x = _x; // x좌표와
            y = _y; // y좌표에
            symbol = _symbol; // _symbol이라는 모양을 넣을겁니다.
        }


        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
        }

        public void Clear()
        {
            symbol = " ";
            Draw();
        }

        public bool IsHit(Point point)
        {
            return point.x == x && point.y == y; // head.IsHit(food)로 호출하면 return foodx == headx && foody == heady; 이런 뜻이다.
        }
    }

    class Snake
    {
        public List<Point> body;
        public Direction direction;

        public Snake(Point bodyPoint, int bodyLength, Direction _direction)
        {
            body = new List<Point>();
            direction = _direction;
            for (int i = 0; i < bodyLength; i++)
            {
                Point p = new Point(bodyPoint.x, bodyPoint.y, "*");
                body.Add(p);
                bodyPoint.x += 1;
            }
        }

        public void SnakeDraw()
        {
            foreach (Point p in body)
            {
                p.Draw();
            }
        }

        public bool SnakeEatFood(Point food)
        {
            var head = FindHeadposition();
            if (head.IsHit(food))
            {
                food.symbol = head.symbol;
                body.Add(food);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SnakeHitTail()
        {
            Point head = body.Last();
            for (int i = 0; i < body.Count - 1; i++)
            {
                if (head.IsHit(body[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public bool SnakeHitWall()
        {
            Point head = body.Last();
            if (head.x <= 0 || head.y <= 0 || head.x >= 50 || head.y >= 20)
            {
                return true;
            }
            return false;
        }


        public void Move()
        {
            Point tail = body.First(); // 꼬리의 자리가
            body.Remove(tail); // 사라지고
            Point head = FindHeadposition(); // 머리의 자리가
            body.Add(head); // 생기고

            tail.Clear(); // 여기서 계속 업데이트 하면서
            head.Draw(); // 생긴자리에 그림 채우고 사라진자리에 그림 지우고
        }

        public Point FindHeadposition()
        {
            Point head = body.Last();
            Point headPoint = new Point(head.x, head.y, head.symbol);
            switch (direction)
            {
                case Direction.LEFT:
                    headPoint.x -= 1;
                    break;
                case Direction.RIGHT:
                    headPoint.x += 1;
                    break;
                case Direction.UP:
                    headPoint.y -= 1;
                    break;
                case Direction.DOWN:
                    headPoint.y += 1;
                    break;
            }
            return headPoint;
        }
    }
    


    class FoodCreator
    {
        public int FoodPositionX {  get; set; }
        public int FoodPositionY { get; set; }
        public string FoodMark { get; set; }
        public FoodCreator(int foodX, int foodY, string foodMark)
        {
            FoodPositionX = foodX;
            FoodPositionY = foodY;
            FoodMark = foodMark;
        }
        // 음식 생성
        public Point CreateFoodPosition()
        {
            Random random = new Random();
            int x = random.Next(1, FoodPositionX);
            int y = random.Next(1, FoodPositionY);
            return new Point(x, y, FoodMark);
        }
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