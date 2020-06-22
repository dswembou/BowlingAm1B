using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ActionManagerTest
    {
        private ActionManager actionManager;
        private ActionManager.Action endTurn = ActionManager.Action.Endturn;
        private ActionManager.Action tidy = ActionManager.Action.Tidy;
        private ActionManager.Action reset = ActionManager.Action.Reset;

        [SetUp]
        public void Setup()
        {
            actionManager = new ActionManager();
        }
        
        [Test]
        public void PassingTest()
        {
            // Use the Assert class to test conditions
            Assert.AreEqual(1, 1);
        }
        [Test]
        public void T01StrikeReturnsEndTurn()
        {
            int[] rolls = { 10 };
            Assert.AreEqual(endTurn, actionManager.Bowl(rolls.ToList()));
        }
        [Test]
        public void T02Pin9ReturnsTidy()
        {
            int[] rolls = { 9 };
            Assert.AreEqual(tidy, actionManager.Bowl(rolls.ToList()));
        }
        [Test]
        public void T03Pin24ReturnsEndTurn()
        {
            int[] rolls = { 2 , 4 };
            Assert.AreEqual(endTurn, actionManager.Bowl(rolls.ToList()));
        }
        [Test]
        public void T04ExtraTurnAfter20Strikes()
        {
            int[] rolls = { 1,1, 1,1 , 1,1 , 1,1 , 1,1 , 1,1, 1,1 , 1,1 , 1,1 , 10,10 };
            Assert.AreEqual(reset, actionManager.Bowl(rolls.ToList()));
        }
    }
}
