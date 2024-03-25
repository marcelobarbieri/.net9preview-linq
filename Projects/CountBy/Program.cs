var students = new List<Student>
{
    new ("André","Luis"),
    new ("André","Baltieri"),
    new ("Ana", "Clara")
};

foreach (var item in students.CountBy(x => x.FirstName))
{
    Console.WriteLine($"Existem {item.Value} aluno(s) com o nome {item.Key}");
}

public record Student (string FirstName, string LastName);