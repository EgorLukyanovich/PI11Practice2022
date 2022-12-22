class Maze
{   
    //Данные
    public int hp = 10;
    public bool door = false;
    public bool score = true;
    int playerx=1;
    int playery=1;
    public int[,] maze = new int[,]
    {
        {1,1,1,1,1,1,1,1,1,1},
        {1,0,1,0,2,0,1,0,0,1},
        {1,0,1,0,1,0,1,0,1,1},
        {1,0,0,2,1,0,0,2,1,1},
        {1,0,1,1,1,0,1,0,0,1},
        {1,2,0,0,1,0,1,1,3,1},
        {1,1,1,2,0,1,1,0,0,1},
        {1,0,1,1,0,0,2,0,1,1},
        {1,0,2,0,0,1,1,0,2,1},
        {1,1,1,1,1,1,1,1,1,1}
    };
    ConsoleColor ink;
    ConsoleColor paper;

    public Maze(ConsoleColor i, ConsoleColor p)
    {
        ink = i;
        paper = p;
    }
    //методы
    public void Move(int dx, int dy)
    {   
        int nx = playerx + dx;
        int ny = playery + dy;
        

        if(maze[ny,nx]>maze.Length){
            Console.WriteLine("Выход за пределы массива");
            
        }
        
        if (hp > 0){
            if (maze[ny,nx] == 0 || maze[ny,nx] == 2 || maze[ny,nx] == 3 )
            {
                playerx = nx;
                playery = ny;
                hp--;
            }

            if(maze[ny,nx] == 2){
                maze[ny,nx] = 0;
                hp = hp + 3;
            }

            if(maze[ny,nx] == 3)
            {
                door = true;
            }
        }else{
            score = false;
        }
    }


    public void Print(int shiftx, int shifty)
    {
        for (int y=0; y<10; y++)
            for (int x=0; x<10; x++)
            {
                double dist = Math.Sqrt((playerx-x)*(playerx-x) + (playery-y)*(playery-y));
                if (dist > 2)
                {
                    Print(shiftx + x, shifty + y, " ", ConsoleColor.Gray, ConsoleColor.DarkGray);
                }
                else
                {
                    if (maze[y,x] == 0) Print(shiftx + x, shifty + y, ".");
                    else if (maze[y,x] == 1) Print(shiftx + x, shifty + y, "#", ink, paper);
                    else if (maze[y,x] == 2) Print(shiftx + x, shifty + y, "*");
                    else if (maze[y,x] == 3) Print(shiftx + x, shifty + y, "/");
                }
            }

        Print(shiftx + playerx, shifty + playery, "@");
    }

    public void Print(int x, int y, string s, ConsoleColor ink = ConsoleColor.White, ConsoleColor paper = ConsoleColor.Black)
    {
        Console.ForegroundColor = ink;
        Console.BackgroundColor = paper;
        Console.CursorLeft = x;
        Console.CursorTop = y;
        Console.Write(s);
    }
}
