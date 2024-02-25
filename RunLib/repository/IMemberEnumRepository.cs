using RunLib.model;

namespace RunLib.repository
{
    public interface IMemberEnumRepository
    {
        MemberEnum Add(MemberEnum m);
        MemberEnum Delete(int id);
        List<MemberEnum> GetAll();
        MemberEnum GetById(int id);
        MemberEnum Update(int id, MemberEnum member);
    }
}