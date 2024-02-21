using Microsoft.VisualStudio.TestTools.UnitTesting;
using RunLib.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunLib.model.Tests
{
    [TestClass()]
    public class MemberTests
    {
        private Member _member;

        [TestInitialize]
        public void BeforeEachTest()
        {
            _member = new Member(1,"Peter","11223344","gul",50);
        }


        /*
         * 
         * Test af Id (ingen begrænsninger)
         * 
         */

        [TestMethod()]
        public void MemberIdTest()
        {
            // arrange - i initialisering


            // act - id er kun get


            // assert
            Assert.AreEqual(1, _member.Id);
        }


        /*
         * 
         * Test af Name (mindst 3 tegn og må ikke være null)
         * 
         */

        [TestMethod()]
        [DataRow("123")]
        [DataRow("Meget lang")]
        public void MemberNameOkTest(string name)
        {
            // arrange
            string expectedName = name;

            // act
            _member.Name = name;


            // assert
            Assert.AreEqual(expectedName, _member.Name);
        }

        [TestMethod()]
        [DataRow("12")]
        [DataRow("    ")]
        public void MemberNameNotOk(string name)
        {
            // arrange -- ikke nødvendig forventer exception

            // act en del af assert

            // assert
            Assert.ThrowsException<ArgumentException>(() => _member.Name = name);
        }

        [TestMethod()]
        [DataRow(null)]
        public void MemberNameNotOk2(string name)
        {
            // arrange -- ikke nødvendig forventer exception

            // act en del af assert

            // assert
            Assert.ThrowsException<ArgumentNullException>(() => _member.Name = name);
        }


        /*
         * 
         * Test af mobil skal være mellem 8-12 tegn (fx +45 66778899, eller 11223344)
         * 
         */

        [TestMethod()]
        [DataRow("12345678")]       // 8 tegn
        [DataRow("123456789012")]   // 12 tegn
        public void MemberMobilOkTest(string mobil)
        {
            // arrange
            string expectedMobil = mobil;

            // act
            _member.Mobile = mobil;


            // assert
            Assert.AreEqual(expectedMobil, _member.Mobile);
        }

        [TestMethod()]
        [DataRow("1234567")]        // 7 tegn
        [DataRow("1234567890123")]  // 13 tegn
        public void MemberMobilNotOk(string mobil)
        {
            // arrange -- ikke nødvendig forventer exception

            // act en del af assert

            // assert
            Assert.ThrowsException<ArgumentException>(() => _member.Mobile = mobil);
        }

        [TestMethod()]
        [DataRow(null)]
        public void MemberMobilNotOk2(string mobil)
        {
            // arrange -- ikke nødvendig forventer exception

            // act en del af assert

            // assert
            Assert.ThrowsException<ArgumentNullException>(() => _member.Mobile = mobil);
        }



        /*
         * 
         * Test af team skal indeholde en farve (sort, blå, grøn, gul, orange eller rød)
         * 
         */

        [TestMethod()]
        [DataRow("sort")]
        [DataRow("blå")]
        [DataRow("grøn")]
        [DataRow("gul")]
        [DataRow("orange")]
        [DataRow("rød")]
        public void MemberTeamOkTest(string team)
        {
            // arrange
            string expectedTeam = team;

            // act
            _member.Team = team;


            // assert
            Assert.AreEqual(expectedTeam, _member.Team);
        }

        [TestMethod()]
        [DataRow("Sort")]
        [DataRow("lysseblå")]
        [DataRow("grå")]
        public void MemberTeamNotOk(string team)
        {
            // arrange -- ikke nødvendig forventer exception

            // act en del af assert

            // assert
            Assert.ThrowsException<ArgumentException>(() => _member.Team = team);
        }

        [TestMethod()]
        [DataRow(null)]
        public void MemberTeamNotOk2(string team)
        {
            // arrange -- ikke nødvendig forventer exception

            // act en del af assert

            // assert
            Assert.ThrowsException<ArgumentNullException>(() => _member.Team = team);
        }



        /*
         * 
         * Test af Price skal være mere end 50,00 kr
         * 
         */

        [TestMethod()]
        [DataRow(50.0)]
        [DataRow(1000)]
        public void MemberPriceOkTest(double price)
        {
            // arrange
            double expectedPrice= price;

            // act
            _member.Price = price;


            // assert
            Assert.AreEqual(expectedPrice, _member.Price);
        }

        [TestMethod()]
        [DataRow(49.9999999999)]
        [DataRow(-52)]
        public void MemberPriceNotOk(double price)
        {
            // arrange -- ikke nødvendig forventer exception

            // act en del af assert

            // assert
            Assert.ThrowsException<ArgumentException>(() => _member.Price = price);
        }
    }
}