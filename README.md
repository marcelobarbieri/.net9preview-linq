# 3 novos métodos do Link no .NET 9 Preview 1

[![](./Assets/Images/youtube.png)](https://www.youtube.com/watch?v=J_YTQEmMaGU&t=398s)

```
dotnet --version
9.0.100-preview.1.24101.2
```

## 1. CountBy

```
dotnet new console -o CountBy
```

Program.cs:

```c#
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
```

```
dotnet run

Existem 2 aluno(s) com o nome André
Existem 1 aluno(s) com o nome Ana
```

## 2. Index

```
dotnet new console -o Index
```

### .NET 8

Program.cs:

```c#
var students = new List<Student>
{
    new ("André","Luis"),
    new ("André","Baltieri"),
    new ("Ana", "Clara")
};

foreach (var (item,index) in 
    students
        .Select((item,index) => (item,index)))
{
    Console.WriteLine($"Item {index}: {item.FirstName}");
}

public record Student (string FirstName, string LastName);
```

```
dotnet run

Item 0: André
Item 1: André
Item 2: Ana
```

### .NET 9

Program.cs:

```c#
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
```

```
dotnet run

Item 0: André
Item 1: André
Item 2: Ana
```

## 3. AggregateBy

```
dotnet new console -o AggregateBy
```

Program.cs

```c#
var users = new List<User>
{
    new User("Alice","Admin",10),
    new User("Bob","Member",5),
    new User("Charlie","Admin",20),
    new User("David","Member",5),
    new User("Eve","Guest",1),
    new User("Frank","Admin",10)
};

var result = users.AggregateBy(
    user => user.Role,
    seed: 0,
    (currentTotal,user) => currentTotal + user.AccessLevel
);

foreach (var item in result) 
{
    Console.WriteLine($"Total níveis de acesso para o perfil {item.Key} é {item.Value}");
}

public record User(
    string Name,
    string Role,
    int AccessLevel);
```

```
dotnet run

Total níveis de acesso para o perfil Admin é 40
Total níveis de acesso para o perfil Member é 10
Total níveis de acesso para o perfil Guest é 1
```