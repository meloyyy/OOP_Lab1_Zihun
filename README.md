# OOP_Lab1_Zihun

## Практична робота №1

##Мета роботи
- навчитися:
- аналізувати предметну область і виявляти класи;
- використовувати принцип абстракції виділення характеристик і поведінки класів;
- реалізовувати класи мовою C#;
- створювати і працювати з обʼєктами класів.

### Опис завдання

На основі отриманого на лекції 1 теоретичного матеріалу розробити консольну програму, яка:

1.	Має опис деякого класу (предметну область обрати самостійно, будьте креативними!), клас повинен мати закриті (private) і загальнодоступні (public) поля*, які описують характеристики класу, та методи, які задають поведінку класу"**.

*хоча б одне поле має бути типу елит, також для характеристик класу треба використовувати не менше 4-5 різних типів даних
**реалізувати enum і клас в окремих файлах *.cs.

2.	Для кожної характеристики класу сформувати обмеження. Перевірка зазначених обмежень має відбуватися в основній програмі (файл Program.cs). Характеристикам обʼєктів можна привласнювати тільки коректні значення.

3.	У програмі має бути передбачена можливість зберігати до N обʼєктів класу (N>0 i задається користувачем, наприклад, при старті програми***).

*** має бути реалізована перевірка введення коректного значення N.

Примітка: для зберігання використання N обʼєктів можна використовувати масив

4.	В програмі має бути реалізоване наступне меню:
1 - Додати обʼєкт
2 - Переглянути всі обʼєкти
3 - Знайти обʼєкт
4 - Продемонструвати поведінку
5 - Видалити обʼєкт
0 - Вийти з програми

Під час додавання обʼєкта користувачем всі його поля мають заповнюватися обовʼязково в ручному режимі, а також можуть заповнюватися і в автоматичному режимі. Передбачити неможливість введення більше ніж N обʼєктів.
При перегляді всіх доданих обʼєктів детальну інформацію про них треба виводити у табличній формі. Передбачити нумерацію обʼєктів в таблиці виводу.
Пошук реалізувати по будь-яким двом характеристикам, у програмі передбачити вибір користувачем характеристики для пошуку (наприклад, шукаємо або за кольору, або за ціною). Якщо введеному значенню характеристики відповідають декілька обʼєктів, то всі вони мають бути виведені як результат пошуку у табличній формі.
При демонстрації поведінки необхідно показати виконання всіх реалізованих public методів класу: одним з можливих варіантів реалізації є використання підменю.
Видалення обʼєкта реалізувати за порядковим номером у таблиці виводу, а також за однією з характеристик. При видаленні за значенням характеристики мають видалятися всі обʼєкти, які мають введене користувачем значення.
Якщо при перегляді, пошуку, видаленні не знайдено жодного обʼєкта, то користувач повинен отримати відповідне повідомлення!
Програма має завершувати свою роботу тільки після вибору користувачем пункту меню «Вийти з програми».


### Технології

Мова програмування: **C#**
Тип застосунку: **Консольний**

### Код:

####Genre.cs
```
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab1_Zihun
{
    enum Genre
    {
        Action,
        Comedy,
        Drama,
        SciFi,
        Horror,
        Fantasy
    }
}
```
####Movie.cs
```
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab1_Zihun
{
    class Movie
    {
        private int id;

        public int Id
        {
            get { return id; }
        }

        public string Title { get; set; }
        public Genre MovieGenre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double Rating { get; set; }
        public int Duration { get; set; }

        public Movie(int id, string title, Genre genre, DateTime date, double rating, int duration)
        {
            this.id = id;
            Title = title;
            MovieGenre = genre;
            ReleaseDate = date;
            Rating = rating;
            Duration = duration;
        }

        public void ShowInfo()
        {
            Console.WriteLine(Id + " | " + Title + " | " + MovieGenre + " | " + ReleaseDate.ToShortDateString() + " | " + Rating + " | " + Duration + " хв");
        }
    }
}
```
####Program.cs
```
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab1_Zihun
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            List<Movie> movies = new List<Movie>();
            int nextId = 1;

            Console.Write("Введіть кількість фільмів: ");
            int maxMovies = int.Parse(Console.ReadLine());

            while (true)
            {
                Console.WriteLine("1 - Додати об'єкт");
                Console.WriteLine("2 - Переглянути всі об'єкти");
                Console.WriteLine("3 - Знайти об'єкт");
                Console.WriteLine("4 - Продемонструвати поведінку");
                Console.WriteLine("5 - Видалити об'єкт");
                Console.WriteLine("0 - Вийти з програми");

                Console.Write("Ваш вибір: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    if (movies.Count >= maxMovies)
                    {
                        Console.WriteLine("Досягнуто ліміт фільмів");
                        continue;
                    }

                    Console.Write("Назва: ");
                    string title = Console.ReadLine();

                    Genre genre;
                    do
                    {
                        Console.Write("Жанр (Action, Comedy, Drama, SciFi, Horror, Fantasy): ");
                        string input = Console.ReadLine();

                        try
                        {
                            genre = (Genre)Enum.Parse(typeof(Genre), input, true);

                            if (!Enum.IsDefined(typeof(Genre), genre))
                                throw new ArgumentException();

                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Такого жанру немає в списку");
                        }

                    } while (true);

                    DateTime ReleaseDate;
                    do
                    {
                        Console.Write("Дата виходу (yyyy-mm-dd): ");
                        try
                        {
                            ReleaseDate = DateTime.Parse(Console.ReadLine());

                            if (ReleaseDate > DateTime.Now)
                            {
                                Console.WriteLine("Неправильний формат дати");
                                continue;
                            }
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Неправильний формат дати");
                        }
                    }
                    while (true);

                    double rating;
                    do
                    {
                        Console.Write("Рейтинг 0 - 10: ");
                        try
                        {
                            rating = double.Parse(Console.ReadLine());

                            if (rating < 0 || rating > 10)
                                throw new ArgumentOutOfRangeException();

                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Некоректне число");
                        }
                    }
                    while (true);

                    int duration;
                    do
                    {
                        Console.Write("Тривалість (у хвилинах): ");
                        try
                        {
                            duration = int.Parse(Console.ReadLine());

                            if (duration <= 0)
                            {
                                Console.WriteLine("Введіть додатнє число");
                                continue;
                            }

                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Введіть ціле число");
                        }
                    }
                    while (true);

                    try
                    {
                        Movie newMovie = new Movie(nextId, title, genre, ReleaseDate, rating, duration);
                        movies.Add(newMovie);
                        nextId++;
                        Console.WriteLine("Фільм додано");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Помилка: " + ex.Message);
                    }
                }
                else if (choice == "2")
                {
                    if (movies.Count == 0)
                        Console.WriteLine("Пусто");
                    else
                    {
                        foreach (var movie in movies)
                            movie.ShowInfo();
                    }
                }
                else if (choice == "3")
                {
                    Console.WriteLine("Знайти фільм за ");
                    Console.WriteLine("1 - Жанр");
                    Console.WriteLine("2 - Рейтинг");
                    Console.WriteLine("3 - Тривалість");

                    int searchType = int.Parse(Console.ReadLine());

                    if (searchType == 1)
                    {
                        Console.Write("Жанр (Action, Comedy, Drama, SciFi, Horror, Fantasy): ");
                        Genre genre = (Genre)Enum.Parse(typeof(Genre), Console.ReadLine(), true);

                        bool found = false;
                        foreach (var movie in movies)
                        {
                            if (movie.MovieGenre == genre)
                            {
                                movie.ShowInfo();
                                found = true;
                            }
                        }

                        if (!found)
                            Console.WriteLine("Фільми з такими парамнтрами відсутні");
                    }
                    else if (searchType == 2)
                    {
                        Console.Write("Мінімальний рейтинг: ");
                        double minRating = double.Parse(Console.ReadLine());

                        bool found = false;
                        foreach (var movie in movies)
                        {
                            if (movie.Rating >= minRating)
                            {
                                movie.ShowInfo();
                                found = true;
                            }
                        }

                        if (!found)
                            Console.WriteLine("Фільми з такими парамнтрами відсутні");
                    }
                    else if (searchType == 3)
                    {
                        Console.Write("Мінімальна тривалість: ");
                        int minDuration = int.Parse(Console.ReadLine());

                        bool found = false;
                        foreach (var movie in movies)
                        {
                            if (movie.Duration >= minDuration)
                            {
                                movie.ShowInfo();
                                found = true;
                            }
                        }

                        if (!found)
                            Console.WriteLine("Фільми з такими парамнтрами відсутні");
                    }
                }
                else if (choice == "4")
                {
                    if (movies.Count == 0)
                    {
                        Console.WriteLine("Фільми відсутні");
                    }
                    else
                    {
                        Console.WriteLine("Інформація про фільми:");

                        foreach (var movie in movies)
                        {
                            movie.ShowInfo();

                            if (movie.ReleaseDate.Year >= DateTime.Now.Year - 5)
                                Console.WriteLine(" - Фільм новий");
                            else
                                Console.WriteLine(" - Це класичний фільм");

                            if (movie.Duration > 120)
                                Console.WriteLine(" - Фільм довше за звичайний");

                            if (movie.Rating >= 8)
                                Console.WriteLine(" - Фільм має високий рейтинг");
                            else if (movie.Rating >= 6)
                                Console.WriteLine(" - Фільм має середній рейтинг");
                            else
                                Console.WriteLine(" - Фільм має низький рейтинг");
                        }
                    }
                }
                else if (choice == "5")
                {
                    Console.Write("ID для видалення: ");
                    int deleteId = int.Parse(Console.ReadLine());
                    bool removed = false;

                    foreach (var movie in movies)
                    {
                        if (movie.Id == deleteId)
                        {
                            movies.Remove(movie);
                            Console.WriteLine("Фільм видалено");
                            removed = true;
                            break;
                        }
                    }

                    if (!removed)
                        Console.WriteLine("Фільм не знайдено");
                }
                else if (choice == "0")
                {
                    break;
                }
            }
        }
    }
}
```
