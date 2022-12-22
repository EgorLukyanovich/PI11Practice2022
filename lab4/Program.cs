Console.Clear();

Maze m = new Maze(ConsoleColor.Red, ConsoleColor.Yellow);

while (true)
{   
    m.Print(3,15,"Вы оказались в лабиринте. У вас течет кровь ваше время ограниченно, найдите выход как можно скорее ");

    m.Print(3, 3);
    if (m.door)
    {
        Console.CursorVisible = false;
        Console.Clear();
        m.Print(3,35,"Вы выбрались из этого проклятого лабиринта. Поздравляю!!!");
        break;
    }
    if (m.score)
    {
        m.Print(3, 20, $"Ваше здоровье {m.hp}");  
    }else{
        m.Print(3,35, "Вы погибли так и не выбравшись из лабиринта");
        break;
    }


    ConsoleKeyInfo ki = Console.ReadKey(true);
    if (ki.Key == ConsoleKey.Escape)
    {
       
        Console.Clear();
        break;
    }
    if (ki.Key == ConsoleKey.LeftArrow) m.Move(-1, 0);
    if (ki.Key == ConsoleKey.RightArrow) m.Move(1, 0);
    if (ki.Key == ConsoleKey.UpArrow) m.Move(0, -1);
    if (ki.Key == ConsoleKey.DownArrow) m.Move(0, 1);
}
