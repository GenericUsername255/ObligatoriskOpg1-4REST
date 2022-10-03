using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObligatoriskOpg1_4.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObligatoriskOpg1_4.Models;

namespace ObligatoriskOpg1_4.Managers.Tests
{
    [TestClass()]
     
    public class FootballPlayersManagerTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            FootballPlayersManager manager = new FootballPlayersManager();
            List<FootballPlayer> footballPlayersCount = manager.GetAll();

            Assert.AreEqual(2, footballPlayersCount.Count);
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            FootballPlayersManager manager = new FootballPlayersManager();
            FootballPlayer footballPlayer1 = manager.GetById(1);

            Assert.AreEqual("Hans Otto", footballPlayer1.Name);
            Assert.AreEqual(22, footballPlayer1.Age);
            Assert.AreEqual(33, footballPlayer1.ShirtNumber);

            //Assert.ThrowsException<Exception>(() => manager.GetById(1000)); //Nope
            Assert.IsNull(manager.GetById(1000));
        }

        //[TestMethod()]
        //public void AddTest()
        //{
        //    throw new NotImplementedException();
        //}

        //[TestMethod()]
        //public void DeleteTest()
        //{
        //    throw new NotImplementedException();
        //}

        //[TestMethod()]
        //public void UpdateTest()
        //{
        //    throw new NotImplementedException();
        //}
    }
}