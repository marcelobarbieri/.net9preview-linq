var students = new List<Student>
{
    new ("André","Luis"),
    new ("André","Baltieri"),
    new ("Ana", "Clara")
};

foreach (var (item,index) in students.Index())
{
    Console.WriteLine($"Item {item}: {index.FirstName}");
}

public record Student (string FirstName, string LastName);