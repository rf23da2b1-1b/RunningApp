using Microsoft.VisualStudio.TestTools.UnitTesting;
using RunLib.model;
using RunLib.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunLib.repository.Tests
{
    [TestClass()]
    public class MemberRepositoryTests
    {
        private MemberRepository _emptyRepo;
        private MemberRepository _repo3members;
        private Member _member2;

        [TestInitialize]
        public void BeforeEachTest()
        {
            _emptyRepo = new MemberRepository();

            _repo3members = new MemberRepository();
            _repo3members.Add(new Member(1, "peter", "11223344", "gul", 67));
            _repo3members.Add(new Member(2, "jakob", "22334455", "blå", 75.5));
            _repo3members.Add(new Member(3, "henrik", "33445566", "sort", 82));

            _member2 = new Member(2, "jakob", "22334455", "grøn", 95.5);
        }

        /*
         * 
         * GetAll
         * 
         */
        [TestMethod()]
        public void MemberRepositoryGetAllTest()
        {
            // arrange 
            int expectedEmptyCount = 0;
            int expected3Count = 3;

            // act
            int actualEmptyCount = _emptyRepo.GetAll().Count;
            int actual3Count = _repo3members.GetAll().Count;



            // assert
            Assert.AreEqual(expectedEmptyCount, actualEmptyCount);
            Assert.AreEqual(expected3Count, actual3Count);
        }

        

        [TestMethod()]
        [DataRow(1, "peter", "11223344", "gul", 67)]
        public void GetByIdTest(int id, string expectedName, string expectedMobile, string expectedTeam, double expectedPrice)
        {
            //arrange
            int expectedId = id;

            // act
            Member fundet = _repo3members.GetById(id);

            // assert
            Assert.AreEqual(expectedId, fundet.Id);
            Assert.AreEqual(expectedName, fundet.Name);
            Assert.AreEqual(expectedMobile, fundet.Mobile);
            Assert.AreEqual(expectedTeam, fundet.Team);
            Assert.AreEqual(expectedPrice, fundet.Price);

        }

        [TestMethod()]
        [DataRow(4)]
        public void GetByIdNotFoundTest(int id)
        {
            //arrange

            // act

            // assert
            Assert.ThrowsException<KeyNotFoundException>(() => _emptyRepo.GetById(id));
            Assert.ThrowsException<KeyNotFoundException>(() => _repo3members.GetById(id));
        }



        [TestMethod()]
        [DataRow("new", "99887766", "grøn", 51)]
        public void AddTest(string newName, string newMobile, string newTeam, double newPrice)
        {
            // arrange 
            Member newMemberEmpty = new Member(newName,newMobile, newTeam, newPrice);
            int expectedIdEmpty = 1;
            int expectedLengthEmpty = 1;

            Member newMember3Member = new Member(newName, newMobile, newTeam, newPrice);
            int expectedId3member = 4;
            int expectedLength3Member = 4;

            //act
            Member addMemberEmpty = _emptyRepo.Add(newMemberEmpty);
            Member addMember3member = _repo3members.Add(newMember3Member);

            int actualLengthEmpty = _emptyRepo.GetAll().Count();
            int actualLength3Member = _repo3members.GetAll().Count();


            //assert
            Assert.AreEqual(expectedIdEmpty,addMemberEmpty.Id);
            Assert.AreEqual(expectedLengthEmpty, actualLengthEmpty);
            Assert.AreEqual(expectedId3member, addMember3member.Id);
            Assert.AreEqual(expectedLength3Member, actualLength3Member);


        }

        [TestMethod()]
        public void DeleteOKTest()
        {
            // arrange
            int expectedLength1 = 2; 
            int expectedLength2 = 1;


            // act
            Member deletedMember1 = _repo3members.Delete(2);
            int actualLength1 = _repo3members.GetAll().Count;
            Member deletedMember2 = _repo3members.Delete(3);
            int actualLength2 = _repo3members.GetAll().Count;

            // assert
            Assert.IsNotNull(deletedMember1);
            Assert.IsNotNull(deletedMember2);
            Assert.AreEqual(expectedLength1, actualLength1);
            Assert.AreEqual(expectedLength2, actualLength2);
        }

        [TestMethod()]
        public void DeleteNOTOKTest()
        {
            // arrange
            


            // act
            

            // assert
            Assert.ThrowsException<KeyNotFoundException>( ()=> _emptyRepo.Delete(2));
            Assert.ThrowsException<KeyNotFoundException>(() => _repo3members.Delete(4));

        }

        [TestMethod()]
        public void UpdateOKTest()
        {
            // arrange
            Member expectedMember = new Member(_member2.Id, _member2.Name, _member2.Mobile, _member2.Team, _member2.Price);


            // act
            Member actualUpdatedMember = _repo3members.Update(2, expectedMember);
            Member actualMember = _repo3members.GetById(2);


            // assert
            Assert.AreEqual(expectedMember.Id, actualUpdatedMember.Id);
            Assert.AreEqual(expectedMember.Name, actualUpdatedMember.Name);
            Assert.AreEqual(expectedMember.Mobile, actualUpdatedMember.Mobile);
            Assert.AreEqual(expectedMember.Team, actualUpdatedMember.Team);
            Assert.AreEqual(expectedMember.Price, actualUpdatedMember.Price);

            Assert.AreEqual(expectedMember.Id, actualMember.Id);
            Assert.AreEqual(expectedMember.Name, actualMember.Name);
            Assert.AreEqual(expectedMember.Mobile, actualMember.Mobile);
            Assert.AreEqual(expectedMember.Team, actualMember.Team);
            Assert.AreEqual(expectedMember.Price, actualMember.Price);



        }

        [TestMethod()]
        public void UpdateNotOKTest()
        {
            // arrange
            int idDoNotExists = 4;
            Member updateMember = new Member(idDoNotExists, _member2.Name, _member2.Mobile, _member2.Team, _member2.Price);

            // act

            // assert

            // findes ikke 
            Assert.ThrowsException<KeyNotFoundException>(() => _repo3members.Update(idDoNotExists, updateMember));
            Assert.ThrowsException<KeyNotFoundException>(() => _emptyRepo.Update(idDoNotExists, updateMember));

            // id ikke det samme
            Assert.ThrowsException<ArgumentException>(() => _repo3members.Update(3, _member2));

        }

        [TestMethod()]
        public void ToStringTest()
        {
            // den tester vi ikke
            Assert.IsTrue(true);
        }
    }
}