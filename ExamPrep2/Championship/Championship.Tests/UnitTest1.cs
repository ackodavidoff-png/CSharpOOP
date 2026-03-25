using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Championship.Tests
{
    public class Tests
    {
        private League league;
        [SetUp]
        public void Setup()
        {
            league = new League();
        }

        //[Test]
        //public void TestAddTeam_Success()
        //{
        //    Assert.Pass();
        //}
        [Test]
        public void Test1_ConstructorShouldBeInizializedProperly()
        {
            Assert.IsNotNull(league);
            Assert.AreEqual(10, league.Capacity);
            Assert.AreEqual(0, league.Teams.Count);
        }
        [Test]
        public void Test2_AddTeamShouldAddTeamProperly()
        {
            Team LevskiSofia = new Team("Levski Sofia");
            league.AddTeam(LevskiSofia);
            Assert.AreEqual(1, league.Teams.Count);
            Assert.AreEqual("Levski Sofia", league.Teams[0].Name);
        }
        [Test]
        public void Test3_AddTeamShouldThrowExceptionWhenCapacityIsExceeded()
        {
            league.AddTeam(new Team("Levski Sofia"));
            league.AddTeam(new Team("CSKA"));
            league.AddTeam(new Team("Ludogorets"));
            league.AddTeam(new Team("Spartak Varna"));
            league.AddTeam(new Team("Tscherno more Varna"));
            league.AddTeam(new Team("Botev Plovdiv"));
            league.AddTeam(new Team("Lokomotiv Plovdiv"));
            league.AddTeam(new Team("Lokomotiv Sofia"));
            league.AddTeam(new Team("Litex Lovetsch"));
            league.AddTeam(new Team("Minjor Pernik"));
            Assert.Throws<InvalidOperationException>(() => league.AddTeam(new Team("Septemvri Tervel")));
        }
        [Test]
        public void Test4_AddTeamShouldThrowExceptionWhenAddingATeamWithTheSameName()
        {
            league.AddTeam(new Team("Levski Sofia"));
            Assert.Throws<InvalidOperationException>(() => league.AddTeam(new Team("Levski Sofia")));
        }
        [Test]
        public void Test5_RemoveTeamShouldReturnTrueIfTheTeamExists()
        {
            league.AddTeam(new Team("Levski Sofia"));
            bool result = league.RemoveTeam("Levski Sofia");
            Assert.IsTrue(result);
            Assert.AreEqual(0, league.Teams.Count);
        }
        [Test]
        public void Test6_RemoveTeamShouldReturnFalseIfTheTeamDoesNotExist()
        {
            league.AddTeam(new Team("Levski Sofia"));
            bool result = league.RemoveTeam("CSKA");
            Assert.IsFalse(result);
            Assert.AreEqual(1, league.Teams.Count);
        }
        [Test]
        public void Test7_PlayMatchShouldThrowExceptionWhenTheOneOrBothTeamsDoNotExist()
        {
            league.AddTeam(new Team("Levski Sofia"));
            Assert.Throws<InvalidOperationException>(() => league.PlayMatch("Levski Sofia", "CSKA", 1, 0));
            Assert.Throws<InvalidOperationException>(() => league.PlayMatch("Ludogorets", "CSKA", 1, 0));
        }
        [Test]
        public void Test8_PlayMatchShouldHandleDrawsCorrectly()
        {
            Team LevskiSofia = new Team("Levski Sofia");
            Team CSKA = new Team("CSKA");
            league.AddTeam(LevskiSofia);
            league.AddTeam(CSKA);
            league.PlayMatch("Levski Sofia", "CSKA", 1, 1);
            Assert.AreEqual(1, LevskiSofia.Points);
            Assert.AreEqual(1, CSKA.Points);
            Assert.AreEqual(1, LevskiSofia.Points);
            Assert.AreEqual(1, CSKA.Points);
        }
        [Test]
        public void Test9_PlayMatchShouldHandleHomeWinCorrectly()
        {
            Team LevskiSofia = new Team("Levski Sofia");
            Team CSKA = new Team("CSKA");
            league.AddTeam(LevskiSofia);
            league.AddTeam(CSKA);
            league.PlayMatch("Levski Sofia", "CSKA", 7, 1);
            Assert.AreEqual(1, LevskiSofia.Wins);
            Assert.AreEqual(1, CSKA.Loses);
            Assert.AreEqual(3, LevskiSofia.Points);
        }
        [Test]
        public void Test10_PlayMatchShouldHandleAwayWinCorrectly()
        {
            Team LevskiSofia = new Team("Levski Sofia");
            Team CSKA = new Team("CSKA");
            league.AddTeam(LevskiSofia);
            league.AddTeam(CSKA);
            league.PlayMatch("Levski Sofia", "CSKA", 0, 2);
            Assert.AreEqual(1, LevskiSofia.Loses);
            Assert.AreEqual(1, CSKA.Wins);
            Assert.AreEqual(3, CSKA.Points);
        }
        [Test]
        public void Test11_GetTeamInfoShouldReturnCorrectInfo()
        {
            Team LevskiSofia = new Team("Levski Sofia");
            league.AddTeam(LevskiSofia);
            string result = league.GetTeamInfo("Levski Sofia");
            Assert.AreEqual(LevskiSofia.ToString(), result);
        }
        [Test]
        public void Test12_GetTeamInfoShouldThrow_WhenTeamDoesNotExist()
        {
            league.AddTeam(new Team("Levski Sofia"));
            Assert.Throws<InvalidOperationException>(() => league.GetTeamInfo("CSKA"));
            Assert.AreEqual(1, league.Teams.Count);
        }
    }
}