using System;
namespace TheRoom
{
    class Program
        {
            static int Getint(string s, int min, int max) //Система выбора а также проверка игрока 
            {
                int result = min;
                bool valid = false;

                do
                {
                    Console.WriteLine(s);
                    valid = int.TryParse(Console.ReadLine(), out result);
                }
                while (!valid || result < min || result > max);
                return result;
            }

            static void Main(string[] args)
            {
                //Локи
                const int door = 1;
                const int picture = 2;
                const int trashOfRock = 3 ;
                const int table = 4;

                //Данные
                Random rnd = new Random();
                int loc = door;
                int code = rnd.Next(1000, 10000);// код от сейфа
                bool door_unlocked = false;
                bool key_get = false;
                bool door_stage_1 = false;
                bool note_pick = false;

                // Вход в игру 
                Console.Clear();
                Console.WriteLine("После буйной ночки в баре вы просыпаетесь в непонятной комнате, чем то похожей на подвал");
                Console.WriteLine("По всюду воняет сыростью, но оглядываяясь по комнате вы замечаете что в ней есть дверь, картина, стол, гора мусора ");
                Console.WriteLine("Вам нужно выбраться как можно скорее");
                Console.WriteLine("");
                //Действия игрока
                while(true){
                    Console.WriteLine();
                    if (loc == door){
                        Console.WriteLine("Перед вами дверь, на вид походит на тюремную дверь времен 20-го века");
                        Console.WriteLine("Перед вами стоит выбор куда подойти");
                        Console.WriteLine("1. Стол ");
                        Console.WriteLine("2. Картина");
                        Console.WriteLine("3. Гора мусора");
                        if (!door_unlocked){
                            Console.WriteLine("4. Попытаться ее выбить");
                        }else{
                            Console.WriteLine("4. Открыть дверь и выйти");
                        }
                    
                    //Сам по себе выбор
                    int choise = Getint("Вы выбираете", 1, 4);
                    //Исход 
                    if (choise == 1){
                        loc = table;
                    }else if (choise == 2){
                        loc = picture;
                    }else if (choise == 3){
                        loc = trashOfRock;
                    }else if (choise == 4){
                        if (!door_unlocked){
                            Console.WriteLine("Вы пытаетесь ее выбить, она не поддается, попытаться еще раз?");
                            Console.WriteLine("1. Да ");
                            Console.WriteLine("2. Нет ");
                            door_stage_1 = true;
                            
                            int break_door = Getint("Вы выбираете", 1, 2);

                            if (break_door == 1){
                                if (door_stage_1){
                                    Console.WriteLine("Вы еще больше разгоняетесь и врезаетесь в дверь со всей силы");
                                    Console.WriteLine("У вас кружиться голова");
                                    Console.WriteLine("Вы теряете сознание после такого удара");
                                    Console.WriteLine(".");
                                    Console.WriteLine("..");
                                    Console.WriteLine("...");
                                    Console.WriteLine("Вы не проснулись");
                                    Console.WriteLine("Вы проиграли!");
                                    break;
                                }
                            }else if (break_door == 2){
                                Console.WriteLine("Вы понимаете что эта идея того не стоит и отступаете");
                            }
                        }else if (door_unlocked && key_get){
                            Console.WriteLine("Вы открываете дверь и сбегаете");
                            Console.WriteLine("Ура победа!");
                            break;
                        }
                    }
                }else if (loc == table){
                    Console.WriteLine("Вы подошли к столу. ");
                    Console.WriteLine("Что делать?");
                    Console.WriteLine("1. Идти к двери");
                    Console.WriteLine("2. Идти к картине");
                    Console.WriteLine("3. Идти к столу ");
                    Console.WriteLine("4. Осмотреть стол ");
                    

                    int choise = Getint("Вы выбираете", 1, 4);

                    if (choise == 1 ){
                        loc = door;
                    }else if (choise == 2){
                        loc = picture;
                    }else if (choise == 3){
                        loc = table;
                    }else if (choise == 4){
                        Console.WriteLine($"На столе еле разборчиво нацарапаны четыре цифры {code}, вы думаете от чего он же они ");
                    }

                }else if (loc == picture){
                    Console.WriteLine("Вы подошли к картине.");
                    Console.WriteLine("Что делать?");
                    Console.WriteLine("1. Идти к двери");
                    Console.WriteLine("2. Идти к горе мусора");
                    Console.WriteLine("3. Идти к столу ");
                    if (!note_pick){
                        Console.WriteLine("4. Осмотреть картину ");
                    }else{
                        Console.WriteLine("4. Отодвинуть и посмортреть за картину ");
                    }
                    

                    int choise = Getint("Вы выбираете", 1, 4);

                    if (choise == 1 ){
                        loc = door;
                    }else if (choise == 2){
                        loc = trashOfRock;
                    }else if (choise == 3){
                        loc = table;
                    }else if (choise == 4){
                        if (!note_pick){
                            Console.WriteLine("Перед вами картина Маяковского Константина – Дети, бегущие от грозы ");
                        }else{
                            Console.WriteLine("");
                            Console.WriteLine("За картиной есть сейф который требует четырехзначный код");
                            int password = Getint("Вы вводите", 1000, 9999);

                            if (password == code){
                                Console.WriteLine("Вы открыли сейф и за ним лежал ключ по всей видимости от двери ");
                                key_get = true;
                                door_unlocked = true;
                            }else{
                                Console.WriteLine("Better luck next time !");
                            }
                        }
                    }

                }else if (loc == trashOfRock){
                    Console.WriteLine("Вы подошли к горе мусора.");
                    Console.WriteLine("Что делать?");
                    Console.WriteLine("1. Идти к двери");
                    Console.WriteLine("2. Идти к картине");
                    Console.WriteLine("3. Идти к столу ");
                    Console.WriteLine("4. Порыться в мусоре");

                    int choise = Getint("Вы выбираете", 1, 4);

                    if (choise == 1 ){
                        loc = door;
                    }else if (choise == 2){
                        loc = picture;
                    }else if (choise == 3){
                        loc = table;
                    }else if (choise == 4){
                        Console.WriteLine("");
                        Console.WriteLine("В горе мусора вы находите записку с точно такой же картиной которая висит напротив,и на ней изображенна стрелка указывающая за эту картину");
                        Console.WriteLine("Вы смекаете что к чему");
                        note_pick = true;
                    }
                }
            }
        }
    }
}