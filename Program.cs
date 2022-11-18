// See https://aka.ms/new-console-template for more information
using SumDistribution;

string type1 = "ПРОП";
string type2 = "ПЕРВ";
string type3 = "ПОСЛ";
string sum = "10000";
string sums = "1000;2000;3000;5000;8000;5000";

Distribution distribution1 = new Distribution(type1, sum, sums);
Distribution distribution2 = new Distribution(type2, sum, sums);
Distribution distribution3 = new Distribution(type3, sum, sums);

Console.WriteLine("{0} {1}", type1, String.Join(";", distribution1.GetDistribution()));
Console.WriteLine("{0} {1}", type2, String.Join(";", distribution2.GetDistribution()));
Console.WriteLine("{0} {1}", type3, String.Join(";", distribution3.GetDistribution()));
Console.WriteLine("Hello, World!");
