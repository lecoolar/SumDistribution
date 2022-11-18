using SumDistribution;


Console.Write("Введите тип распределения: ");
string type = Console.ReadLine();
Console.Write("Введите сумму для распределения: ");
string sum = Console.ReadLine();
Console.Write("Введите суммы для распределения(через запятую): ");
string sums = Console.ReadLine();
Distribution distribution = new Distribution(type, sum, sums);
Console.WriteLine("{0} {1}", type, String.Join(";", distribution.GetDistribution()));

