// See https://aka.ms/new-console-template for more information
using RunLib.model;
using RunLib.repository;

Console.WriteLine("Hello, World!");

Member m1 = new Member(1, "peter", "22334455", "gul", 100);
Member m2 = new Member(2, "jakob", "99775533", "rød", 110);
Member m3 = new Member(3, "vibeke", "66118822", "blå", 90);

Console.WriteLine(m1);
Console.WriteLine(m2);
Console.WriteLine(m3);

Console.WriteLine("---> Repository <---");
MemberRepository repo = new MemberRepository();
Console.WriteLine("---> Repository ADD <---");

Member member = repo.Add(m1);
Console.WriteLine(member);
member = repo.Add(m2);
Console.WriteLine(member);
member = repo.Add(m3);
Console.WriteLine(member);

Console.WriteLine("---> Repository ToString <---");
Console.WriteLine(repo);

Console.WriteLine("---> Repository GetById findes <---");
Console.WriteLine(repo.GetById(1));
try
{
    Console.WriteLine("---> Repository GetById findes IKKE <---");

    repo.GetById(19);
}
catch (KeyNotFoundException knfe)
{
    Console.WriteLine(  knfe.Message );
}

Console.WriteLine("---> Repository Update <---");
Member m2update = new Member(2, "jakob", "11122233", "sort", 150);
Console.WriteLine(repo.Update(2, m2update));

Console.WriteLine("---> Repository Delete <---");
Console.WriteLine(repo.Delete(3));

Console.WriteLine("---> Repository GetAll <---");
foreach (Member m in repo.GetAll())
{
    Console.WriteLine(m);
}
















