
using System;
var appPath = "phonebook.txt";

var Book=ReadFile(appPath);

PrintBook(Book);



Console.Read();

List<(string FirstName, string LastName, string PhoneNumber)> ReadFile(string path)
{
    try
    {
        File.OpenRead(path);
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex);
    }
    var lines = File.ReadAllLines(path);
    var book = new List<(string FirstName, string LastName, string PhoneNumber)>();
    foreach (var line in lines)
    {
        var split = line.Split(",");
        book.Add((split[0], split[1], split[2]));
    }
    return book;
}

void PrintBook (List < (string FirstName, string LastName, string PhoneNumber) > book) 
{
    int i = 0;
    foreach( var line in book)
    {
        Console.WriteLine(book[i]);
        i++;
    }
}

void AddPhoneBook(string path)
{
    Console.WriteLine("Enter FirstName:");
    var firstName = Console.ReadLine();
    Console.WriteLine("Enter LastName:");
    var lastName = Console.ReadLine();
    Console.WriteLine("Enter PhoneNumber:");
    var phoneNumber = Console.ReadLine();
    File.AppendAllLines(
        path,
        new[] { $"{firstName},{lastName},{phoneNumber}" });
}

(string, string, string) serch(string input, List<(string FirstName, string LastName, string PhoneNumber)> book)
{
    (string FirstName, string LastName, string PhoneNumber) result = (null,null,null);
    
    return book.FirstOrDefault(person =>person.Item1.Contains(input,StringComparison.OrdinalIgnoreCase) ||
                                        person.Item2.Contains(input, StringComparison.OrdinalIgnoreCase) ||
                                        person.Item3.Contains(input, StringComparison.OrdinalIgnoreCase));
}