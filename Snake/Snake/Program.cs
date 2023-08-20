using System.Drawing;

class SnakeGame
{
    static void Main()
    {
        // 공간 생성명령
        DrawWall();

        // 뱀 생성명령
        Point p = new Point(10, 10, "*"); // 뱀의 머리 위치와 뱀의 몸통 모양을 정합니다. 이 c는 Point 클래스(객체)의 변수입니다.
        Snake snake = new Snake(p, 7, Direction.RIGHT);
        snake.SnakeDraw();

        FoodCreator foodCreator = new FoodCreator(50, 20, "!");
        Point foodPosition = foodCreator.CreateFoodPosition();
        foodPosition.Draw();

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
    }

    class Snake
    {
        // 뱀 생성
        public List<Point> wholeBody; // 뱀의 몸통 전체를 리스트 컬랙션으로 선언합니다. 리스트의 구성원은 몸통 한칸씩입니다.
        public Direction direction; // 뱀의 진행 방향입니다.

        public Snake( Point body, int bodyLength,  Direction _direction ) // 뱀의 생김새
        {
            direction = _direction;
            wholeBody = new List<Point>();
            for (int i = 0; i < bodyLength; i++)
            {
                Point point = new Point(body.x, body.y, "*");
                wholeBody.Add(point);
                body.x -= 1;
            }

        }

        public void SnakeDraw()
        {
            foreach (Point bodyPoint in wholeBody)
            {
                bodyPoint.Draw();
            }
        }
        // 뱀 동작
        // 뱀 충돌 판별&상황별 동작
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