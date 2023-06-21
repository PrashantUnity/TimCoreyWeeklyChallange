// Question
using WCH01;

var ls = new List<string> { "Prashant", "Priyadarshi", "Sagar", "Rahul" };
foreach (string s in ls)
{
    Console.WriteLine(s);
}

// Bonus
var person = new Person();
person.FirstName = "Prashant";
person.LastName = "Priyadarshi";

Console.WriteLine(person.ToString());