using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunLib.model
{
    public class Member
    {
		// instans felter
		private double _price;
		private string _team;
		private string _mobile;
		private string _name;
		private int _id;


		// properties
		public int Id
		{
			get { return _id; }
			// evt. private set { _id = value; } så kan den kun tilgås inde i klassen selv
		}


		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}


		public string Mobile
		{
			get { return _mobile; }
			set { _mobile = value; }
		}


		public string Team
		{
			get { return _team; }
			set { _team = value; }
		}


		public double Price
		{
			get { return _price; }
			set { _price = value; }
		}


		// konstruktører
        public Member():
			this(-1,"","","",0.0)
        {
        }

        public Member(string name, string mobile, string team, double price): 
			this(-1, name, mobile, team, price)
        {
        }

        public Member(int id, string name, string mobile, string team, double price)
        {
            _id = id;
            Name = name;
            Mobile = mobile;
            Team = team;
            Price = price;
        }





        // To String
        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id}, {nameof(Name)}={Name}, {nameof(Mobile)}={Mobile}, {nameof(Team)}={Team}, {nameof(Price)}={Price}}}";
        }
    }
}
