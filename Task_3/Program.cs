using static System.Console;
class Program
{    /// <summary>
     /// ввиду того что  на данном этапе обучения мы по идее 
     /// не должны знать функции польователя и что кроме функции Main 
     /// могут  быть другие я всю игру реализовал в данной функции
     /// </summary>
     /// <param name="args"></param>
    static void Main(string[] args)
    {
        //в этом цикле задаются длиина и ширина игрового поля, они ограничены значениями 5 и 17
        int length, width;
        while (true)
        {
            WriteLine("Enter lenght of your gaming field it must be between 10 and 20");
            length = Convert.ToInt32(ReadLine());
            if (length < 10 || length > 20)
            {
                WriteLine("Incorret lenght");
                continue;
            }
            WriteLine("Enter hight of your gaming field it must be between 10 and 60");
            width = Convert.ToInt32(ReadLine());
            if (width < 10 || width > 60)
            {
                Console.WriteLine("Incorrect higth");
                continue;
            }
            else break;

        }
        //само создание игрового поля и случайное заполнение бактериями
        bool[,] Petri = new bool[length, width];
        Random random = new Random();
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < width; j++)
            {
                int key  = random.Next(2);
                Petri[i, j] = (key == 0) ? true : false;
                Write(Petri[i, j] ? '0' :' ' );
            }
            WriteLine();
        }
        //Правила жизни бактерий:
        //1. если справа, слева ,сверху и снизу есть бактерии - бактерия умирает
        //2. если справа, слева, снизу и сверху нет бактерии - бактерия умирает
        while (true)
        {
            int alive = 0;
            WriteLine("tap 1 to see next generation or tap 0 to exit");
            int key = Convert.ToInt32(ReadLine());
            if (key == 0) break;
            else
            {
                //убираем прошлое поколение
                Clear();
                //проверяем правила 
                for(int i = 0; i < length; i++)
                {
                    for(int j = 0; j < width; j++)
                    {
                        if (i >= 1 && j >= 1 && i < length - 1 && j < width - 1)
                        {
                            if (Petri[i - 1, j] == true) alive++;
                            if (Petri[i + 1, j] == true) alive++;
                            if (Petri[i, j - 1] == true) alive++;
                            if (Petri[i, j + 1] == true) alive++;
                            switch (alive)
                            {
                                case 0:
                                    Petri[i, j] = false;
                                    break;
                                case 4: Petri[i, j ] = false;
                                    break;
                                default: Petri[i, j] = true;
                                    break;
                            }
                            alive = 0;
                               
                        }
                        else
                        {
                            //если клетка на верхней или левой границе


                            if(i==0||j==0)
                                //если на верхней
                                if (i == 0)
                                {
                                    if (j == 0||j==width-1) continue;
                                    if (Petri[i, j - 1] == true) alive++;
                                    if (Petri[i + 1, j] == true) alive++;
                                    if (Petri[i, j + 1] == true) alive++;
                                    switch (alive)
                                    {
                                        case 0:
                                            Petri[i, j] = false;
                                            break;
                                        case 3:
                                            Petri[i, j] = false;
                                            break;
                                        default:
                                            Petri[i, j] = true;
                                            break;
                                    }
                                    alive = 0;
                                }
                                //если на левой
                                else
                                {
                                    if (j == width - 1 || i == length - 1) continue;
                                    if (Petri[i + 1, j] == true) alive++;
                                    if (Petri[i - 1, j] == true) alive++;
                                    if (Petri[i, j + 1] == true) alive++;
                                    switch (alive)
                                    {
                                        case 0:
                                            Petri[i, j] = false;
                                            break;
                                        case 3:
                                            Petri[i, j] = false;
                                            break;
                                        default:
                                            Petri[i, j] = true;
                                            break;
                                    }
                                    alive = 0;
                                }
                            //если клетка на правой или нижней границе
                            else
                            {
                                //если на нижней
                                if (i == length - 1)

                                {
                                    if (j == width - 1) continue ;
                                    if (Petri[i - 1, j] == true) alive++;
                                    if (Petri[i, j - 1] == true) alive++;
                                    if (Petri[i, j + 1] == true) alive++;

                                    switch (alive)
                                    {
                                        case 0:
                                            Petri[i, j] = false;
                                            break;
                                        case 3:
                                            Petri[i, j] = false;
                                            break;
                                        default:
                                            Petri[i, j] = true;
                                            break;
                                    }
                                    alive = 0;
                                }
                                //если на правой
                                else
                                {
                                    if (Petri[i - 1, j] == true) alive++;
                                    if (Petri[i + 1, j] == true) alive++;
                                    if (Petri[i, j - 1] == true) alive++;
                                    switch (alive)
                                    {
                                        case 0:
                                            Petri[i, j] = false;
                                            break;
                                        case 3:
                                            Petri[i, j] = false;
                                            break;
                                        default:
                                            Petri[i, j] = true;
                                            break;
                                    }
                                    alive = 0;
                                }
                            }
                            

                        }
                        //рисуем новое поколение
                        Write(Petri[i, j] ? '0' : ' ');
                    }
                    WriteLine();
                }

            }
        }
    }
}
