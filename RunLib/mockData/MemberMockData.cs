using RunLib.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace RunLib.mockData
{
    public class MemberMockData
    {
        private static readonly IList<Member> _members = new Collection<Member>()
        {
            new Member(1,"peter","22334455", "rød", 55),
            new Member(2,"anders","11223344", "grøn", 60),
            new Member(3,"henrik","33445566", "blå", 66),
            new Member(4,"vibeke","44556677", "blå", 66),
            new Member(5,"ivan","55667788", "orange", 70),
            new Member(6,"per","66778899", "grøn", 60),
            new Member(7,"mikkel","77889900", "rød", 55),
            new Member(8,"jesper","99887766", "sort", 100),
            new Member(9,"jakob","88776655", "gul", 100),
            new Member(10,"jens peter","77665544", "gul", 100),
            new Member(11,"morten","66554433", "rød", 55),
            new Member(12,"homayoon","55443322", "sort", 60),
            new Member(13,"nilma","44332211", "grøn", 66)

        };

        private static readonly IList<MemberEnum> _membersEnum = new Collection<MemberEnum>()
        {
            new MemberEnum(1,"peter","22334455", TeamColorType.rød, 55),
            new MemberEnum(2,"anders","11223344", TeamColorType.grøn, 60),
            new MemberEnum(3,"henrik","33445566", TeamColorType.blå, 66),
            new MemberEnum(4,"vibeke","44556677", TeamColorType.blå, 66),
            new MemberEnum(5,"ivan","55667788", TeamColorType.orange, 70),
            new MemberEnum(6,"per","66778899", TeamColorType.grøn, 60),
            new MemberEnum(7,"mikkel","77889900", TeamColorType.rød, 55),
            new MemberEnum(8,"jesper","99887766", TeamColorType.sort, 100),
            new MemberEnum(9,"jakob","88776655", TeamColorType.gul, 100),
            new MemberEnum(10,"jens peter","77665544", TeamColorType.gul, 100),
            new MemberEnum(11,"morten","66554433", TeamColorType.rød, 55),
            new MemberEnum(12,"homayoon","55443322", TeamColorType.sort, 60),
            new MemberEnum(13,"nilma","44332211", TeamColorType.grøn, 66)

        };

        public static ICollection<MemberEnum> GetMembersEnum { get { return new Collection<MemberEnum>(_membersEnum); } }
        public static ICollection<Member> GetMembers { get { return new Collection<Member>(_members); } }



    }
}
