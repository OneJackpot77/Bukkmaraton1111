using ConsoleApp1;
using ConsoleApp1.Properties;

const int _indulokszama = 691;
List<Versenyzo> versenyzo = new();

//beolvasas

using StreamReader sr = new(@"..\..\..\Src\bukkm2019.txt");
_ = sr.ReadLine();
while (!sr.EndOfStream)
{
    versenyzo.Add(new Versenyzo(sr.ReadLine()));
}

Console.WriteLine("4.feladat" +
    " Versenytávot ne teljesitettek aránya: " +
    $"{100-versenyzo.Count / (double)_indulokszama * 100}%");

int rttnvsz = versenyzo.Count(x => x.Tav == "Rövid" && !x.Nem);
Console.WriteLine("5.feladat"+
    " Női cersenyzők száma a rövidtavu versenyen:" +
    $"{rttnvsz} fő");
//6.feladat
bool vetm6otv = versenyzo.Any(x => x.Ido.TotalHours > 6);
Console.WriteLine("6.feladat"+
    $"{(vetm6otv ? " Volt ilyen versenyzo" : "Nem volt ilyen versenyző")}");
//7.feladat
Console.WriteLine("7. feladat:" +
    " A felnott ferfi kategoria gyoztese rovid tavon: ");
Versenyzo rffgy = versenyzo
    .Where(x => x.Kategoria == "ff" && x.Nem && x.Tav== "Rövid")
    .OrderBy(x => x.Ido)
    .First();

Console.WriteLine(
    $"\t Rajtszám: {rffgy.Rajtszam}\n" +
    $"\t Név: {rffgy.Nev}\n" +
    $"{(string.IsNullOrWhiteSpace(rffgy.Egyesulet)  ? null : $"\t Egyesulet: {rffgy.Egyesulet}")}\n" +
    $"\t Idő: {rffgy.Ido}");
//8.feladat:
Console.WriteLine("8.feladat: " +
    "Statisztika");
var fks = versenyzo.Where(x => x.Nem)
    .GroupBy(x => x.Kategoria);

foreach (var item in fks)
{
    Console.WriteLine($"{item.Key} - {item.Count()} fő");
}