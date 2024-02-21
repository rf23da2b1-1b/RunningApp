// See https://aka.ms/new-console-template for more information
using RunLib.model;
using RunLib.repository;


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



/*
 * MED ENUM
*/
Console.ReadLine();
Console.Clear();

MemberEnum me1 = new MemberEnum(1, "peter", "22334455", TeamColorType.gul, 100);
MemberEnum me2 = new MemberEnum(2, "jakob", "99775533", TeamColorType.rød, 110);
MemberEnum me3 = new MemberEnum(3, "vibeke", "66118822", TeamColorType.blå, 90);

Console.WriteLine(me1);
Console.WriteLine(me2);
Console.WriteLine(me3);

Console.WriteLine("---> Repository <---");
MemberEnumRepository repoEnum = new MemberEnumRepository();
Console.WriteLine("---> Repository ADD <---");

MemberEnum membere = repoEnum.Add(me1);
Console.WriteLine(membere);
membere = repoEnum.Add(me2);
Console.WriteLine(membere);
membere = repoEnum.Add(me3);
Console.WriteLine(membere);

Console.WriteLine("---> Repository ToString <---");
Console.WriteLine(repoEnum);

Console.WriteLine("---> Repository GetById findes <---");
Console.WriteLine(repoEnum.GetById(1));
try
{
    Console.WriteLine("---> Repository GetById findes IKKE <---");

    repoEnum.GetById(19);
}
catch (KeyNotFoundException knfe)
{
    Console.WriteLine(knfe.Message);
}

Console.WriteLine("---> Repository Update <---");
MemberEnum me2update = new MemberEnum(2, "jakob", "11122233", TeamColorType.sort, 150);
Console.WriteLine(repoEnum.Update(2, me2update));

Console.WriteLine("---> Repository Delete <---");
Console.WriteLine(repoEnum.Delete(3));

Console.WriteLine("---> Repository GetAll <---");
foreach (MemberEnum m in repoEnum.GetAll())
{
    Console.WriteLine(m);
}









