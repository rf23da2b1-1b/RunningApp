using RunLib.mockData;
using RunLib.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunLib.repository
{
    public class MemberEnumRepository : IMemberEnumRepository
    {
        private readonly List<MemberEnum> _members;

        public MemberEnumRepository(bool withTestData = false)
        {
            _members = new List<MemberEnum>();

            if (withTestData)
            {
                _members.AddRange(MemberMockData.GetMembersEnum);
            }
        }

        /*
         * CRUD metoder
         */
        public List<MemberEnum> GetAll()
        {
            return new List<MemberEnum>(_members);
        }

        public MemberEnum GetById(int id)
        {
            MemberEnum? fundetMember = _members.Find(m => m.Id == id);
            if (fundetMember is null)
            {
                throw new KeyNotFoundException($"Member with id={id} is not found");
            }

            return fundetMember;
        }

        public MemberEnum Add(MemberEnum m)
        {
            // nu har vi ikke en set til Id 
            // => laver et nyt objekt med et genereret Id

            MemberEnum newMember = new MemberEnum(GenerateNextId(), m.Name, m.Mobile, m.Team, m.Price);
            _members.Add(newMember);
            return newMember;
        }

        public MemberEnum Delete(int id)
        {
            MemberEnum sletMember = GetById(id);
            _members.Remove(sletMember);
            return sletMember;
        }

        public MemberEnum Update(int id, MemberEnum member)
        {
            if (id != member.Id)
            {
                throw new ArgumentException($"Kan ikke updatere et id {id} med et andet {member.Id}");
            }
            MemberEnum updateMember = GetById(id);
            int ix = _members.IndexOf(updateMember);
            _members[ix] = member;

            return member;

        }

        public override string? ToString()
        {
            return "Members= [ " + string.Join(", ", _members) + " ]";

        }



        // utility method
        private int GenerateNextId()
        {
            return (_members.Count == 0) ? 1 : _members.Max(m => m.Id) + 1;
        }


    }
}
