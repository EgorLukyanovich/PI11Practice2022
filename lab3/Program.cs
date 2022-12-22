using static System.Console;

const int Room = 1;
const int LockedPicture = 2;
const int Table = 3;
const int LockDoor = 4;
const int OpenPicture = 5;
const int Note = 6;
const int Safe = 7;
const int WrongNumber = 8;
const int RightNumber = 9;
const int Key = 10;
const int RightNumber_2 = 11;
const int OpenSafe = 12;
bool tale = false;

Story story = new StoryBuilder()
    .SetupStory("Вы каким то чудом оказались в закрытой комнате, перед собой вы видите закрытую дверь, картину и стол", "Вы сбежали", Room)
    .AddLocation(Room, "Куда подойти?")
    .AddLocation(LockedPicture, "Вы стоите у картины. Под ней лежат 2 гильзы. Блягодаря им вы вспоминаете сценку из шпионского фильма. ")
    .AddLocation(Table, "На столе лежит записка с непонятными каракулями, обгоревшая свеча и разбитая тарелка.")
    .AddLocation(LockDoor, "Дверь с надписью выход, около нее лежит 5 сломаных ключей")
    .AddLocation(OpenPicture, "За картиной оказался сейф с 3-х знычным кодом")
    .AddLocation(Note, "В записке написанно вот это 'Нсж ахс нсолъзфхес тузжпзхсе снсос нгухлрю, фхсог, жезул', справа сверху цифра 3 и изображение салата ")
    .AddLocation(Safe, "Перед вами сейф и 6 кнопок ввода")
    .AddLocation(WrongNumber, "Сейф пищит сбрасывая все цифры")
    .AddLocation(RightNumber, "Первая цифра подошла")
    .AddLocation(RightNumber_2, "Вторая цифра подошла цифра подошла")
    .AddLocation(OpenSafe, "Сейф открылся и там лежит ключ")
    .AddLocation(Key, "Ключ подходит к двери и вы ее открываете")
    //Картина 
    .AddOption(Room, LockedPicture, "К картине")
    .AddOption(LockedPicture, Room, "Отойти от картины")
    .AddOption(LockedPicture, OpenPicture, "Отодвинуть картину")
    .AddOption(OpenPicture, Room, "Отойти")
    //Стол
    .AddOption(Room, Table, "К столу")
    .AddOption(Table, Room, "Отойти от стола ")
    .AddOption(Table, Note, "Попытаться прочитать текст в записке ")
    .AddOption(Note, Room, "Отойти от стола ")
    //Дверь
    .AddOption(Room, LockDoor, "К двери")
    .AddOption(LockDoor, Room, "Отойти от двери")
    //.AddOption(Key, final, "Вы сбежали")
    //Код
    .AddOption(OpenPicture,Safe, "Попытаться ввести код")
    .AddOption(WrongNumber, Safe, "Попытаться снова")
    .AddOption(WrongNumber, Room, "Отойти от сейфа")

    .AddOption(Safe, WrongNumber, "1")
    .AddOption(Safe, RightNumber, "2")
    .AddOption(Safe, WrongNumber, "3")
    .AddOption(Safe, WrongNumber, "4")
    .AddOption(Safe, WrongNumber, "5")
    .AddOption(Safe, WrongNumber, "6")

    .AddOption(RightNumber, WrongNumber, "1")
    .AddOption(RightNumber, WrongNumber, "2")
    .AddOption(RightNumber, RightNumber_2, "3")
    .AddOption(RightNumber, WrongNumber, "4")
    .AddOption(RightNumber, WrongNumber, "5")
    .AddOption(RightNumber, WrongNumber, "6")

    .AddOption(RightNumber_2, WrongNumber, "1")
    .AddOption(RightNumber_2, WrongNumber, "2")
    .AddOption(RightNumber_2, WrongNumber, "3")
    .AddOption(RightNumber_2, WrongNumber, "4")
    .AddOption(RightNumber_2, OpenSafe, "5")
    .AddOption(RightNumber_2, WrongNumber, "6")

    //Выход
    .AddOption(OpenSafe, "Подобрать ключ и бежать к двери", DoLeave)
    

    .Build();

////////////
// engine //
////////////
Clear();
WriteLine(story.Intro);
while(!tale)
{
    Location loc = story.Locations.First(item => item.Id == story.CurrentLocationId);
    WriteLine();
    WriteLine(loc.Description);

    for (int i=0; i<loc.Options.Count; i++)
        WriteLine($"{i+1}) {loc.Options[i].Title}");

    int n = GetInt("Ваш выбор: ", 1, loc.Options.Count) - 1;

    loc.Options[n].Work();
}
WriteLine(story.Final);

int GetInt(string msg, int min, int max)
{
    int result = min;
    bool valid = false;
    do
    {
        Write(msg);
        valid = int.TryParse(ReadLine(), out result);
    } while(!valid || result < min || result > max);
    return result;
}

void DoLeave ()
    {
        tale = true;
        Console.WriteLine("Вы открываете дверь");
    }

//Код это количество предметов около картины, стола, двери