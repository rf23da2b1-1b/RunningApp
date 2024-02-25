using RunLib.mockData;
using RunLib.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RunLib.repository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly List<Member> _members;

        public MemberRepository(bool withTestData = false)
        {
            _members = new List<Member>();

            if (withTestData)
            {
                _members.AddRange(MemberMockData.GetMembers);
            }
        }

        /*
         * CRUD metoder
         */
        public List<Member> GetAll()
        {
            return new List<Member>(_members);
        }

        public Member GetById(int id)
        {
            Member? fundetMember = _members.Find(m => m.Id == id);
            if (fundetMember is null)
            {
                throw new KeyNotFoundException($"Member with id={id} is not found");
            }

            return fundetMember;
        }

        public Member Add(Member m)
        {
            // nu har vi ikke en set til Id 
            // => laver et nyt objekt med et genereret Id

            Member newMember = new Member(GenerateNextId(), m.Name, m.Mobile, m.Team, m.Price);
            _members.Add(newMember);
            return newMember;
        }

        public Member Delete(int id)
        {
            Member sletMember = GetById(id);
            _members.Remove(sletMember);
            return sletMember;
        }

        public Member Update(int id, Member member)
        {
            if (id != member.Id)
            {
                throw new ArgumentException($"Kan ikke updatere et id {id} med et andet {member.Id}");
            }
            Member updateMember = GetById(id);

            // alternativit
            //updateMember.Name = member.Name;
            //updateMember.Mobile = member.Mobile;
            //updateMember.Team = member.Team;
            //updateMember.Price = member.Price;


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
