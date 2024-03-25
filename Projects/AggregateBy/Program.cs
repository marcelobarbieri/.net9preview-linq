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