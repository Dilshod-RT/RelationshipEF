using RelationshipEF;

using (ApplicationContext db = new ApplicationContext())
{
    Console.WriteLine("Hello world!");
}

using (ApplicationContext context = new ApplicationContext())
{
    Company microsoft = new Company { Name = "Microsoft" };
    Company google = new Company { Name = "Google" };
    context.Companies.AddRange(microsoft, google);
    context.SaveChanges();

    User tom = new User { Name = "Tom", Company = microsoft };
    User bob = new User { Name = "Bob", Company = google };
    User alice = new User { Name = "Alice", Company = microsoft };
    User kate = new User { Name = "Kate", Company = google };
    context.Users.AddRange(tom, bob, alice, kate);
    context.SaveChanges();

    var users = context.Users.ToList();
    foreach(var user in users) Console.WriteLine($"{user.Name}");

    var company = context.Companies.FirstOrDefault();
    context.Companies.Remove(company);
    context.SaveChanges();
    Console.WriteLine("\nAfter deleting\n");

    users = context.Users.ToList();
    foreach (var user in users) Console.WriteLine($"{user.Name}");
}