using RunLib.model;

namespace RunLib.repository
{
    public interface IMemberRepository
    {
        Member Add(Member m);
        Member Delete(int id);
        List<Member> GetAll();
        Member GetById(int id);
        Member Update(int id, Member member);
    }
}