using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Создаем словарь для хранения стоимости посещения городов.
        Dictionary<string, double> cities = new Dictionary<string, double>
        {
            {"Берлин", 399},
            {"Прага", 300},
            {"Париж", 350},
            {"Рига", 250},
            {"Лондон", 390},
            {"Ватикан", 500},
            {"Палермо", 230},
            {"Варшава", 300},
            {"Кишинёв", 215},
            {"Мадрид", 260},
            {"Будапешт", 269}
        };

        Console.WriteLine("Доступные города:");
        foreach (var city in cities.Keys)
        {
            Console.WriteLine(city);
        }

        Console.Write("Выберите город отправления: ");
        string departureCity = Console.ReadLine();

        Console.Write("Сколько городов посетить (от 1 до 3): ");
        int citiesToVisitCount = int.Parse(Console.ReadLine());

        if (citiesToVisitCount < 1 || citiesToVisitCount > 3)
        {
            Console.WriteLine("Вы можете посетить только от 1 до 3 городов.");
            return;
        }

        // Создаем список для хранения городов для посещения.
        List<string> citiesToVisit = new List<string>();

        for (int i = 0; i < citiesToVisitCount; i++)
        {
            Console.Write($"Введите город #{i + 1}: ");
            string city = Console.ReadLine();
            citiesToVisit.Add(city);
        }

        double totalCost = 0;

        // Проверяем дополнительные условия для города отправления.
        if (departureCity == "Мадрид")
        {
            if (!citiesToVisit.Contains("Париж"))
            {
                Console.WriteLine("Поездка из Мадрида обязательно включает в себя Париж.");
                return;
            }
        }

        if (departureCity == "Кишинёв")
        {
            if (!citiesToVisit.Contains("Будапешт"))
            {
                Console.WriteLine("Поездка из Кишинёва обязательно включает в себя Будапешт.");
                return;
            }
        }

        // Вычисляем общую стоимость посещения выбранных городов.
        foreach (var city in citiesToVisit)
        {
            totalCost += cities[city];
        }

        // Применяем дополнительные налоги и условия для каждого города.
        if (citiesToVisit.Contains("Ватикан"))
        {
            totalCost += 0.5 * totalCost; // Дополнительный налог на пребывание в Ватикане.
        }

        if (departureCity == "Палермо" || citiesToVisit.Contains("Палермо"))
        {
            if (departureCity == "Лондон")
            {
                totalCost += 0.07 * totalCost; // Дополнительный налог для туристов из Лондона.
            }
            else if (departureCity == "Кишинёв")
            {
                totalCost += 0.11 * totalCost; // Дополнительный налог для туристов из Кишинёва.
            }
        }

        if (departureCity == "Рига" && citiesToVisit.Contains("Париж"))
        {
            totalCost += 0.09 * totalCost; // Дополнительный налог для туристов из Парижа.
        }

        if (departureCity == "Палермо" && citiesToVisit.Contains("Рига"))
        {
            totalCost += 0.13 * totalCost; // Дополнительный налог для туристов из Риги.
        }

        if (IsNonEUCitizen(departureCity))
        {
            totalCost += 0.04 * totalCost; // Налог 4% для туристов не из ЕС.
        }

        if (departureCity == "Ватикан" || citiesToVisit.Contains("Ватикан"))
        {
            totalCost += 0.5 * totalCost; // Дополнительный налог на пребывание в Ватикане.
        }

        if (departureCity == "Берлин" || citiesToVisit.Contains("Берлин"))
        {
            totalCost += 0.13 * totalCost; // Дополнительный налог в Берлине 13%.
        }

        // Выводим итоговую стоимость поездки.
        Console.WriteLine($"Стоимость поездки: {totalCost:F2}");
    }

    // Функция для определения, является ли город отправления не из ЕС.
    static bool IsNonEUCitizen(string city)
    {
        // Здесь можно добавить условия для определения, является ли город отправления туриста из-за пределов Европейского Союза.
        // Например, если город не в ЕС, то вернуть true, иначе false.
        // В этом примере предполагается, что города не в ЕС.
        return city == "Мадрид" || city == "Палермо";
    }
}