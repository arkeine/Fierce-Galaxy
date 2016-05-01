using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FierceGalaxyInterface;
using FierceGalaxyServer;
using FierceGalaxyServer.GameModule;

namespace FierceGalaxyUnitTest
{
    [TestClass]
    public class SquadManagerTest
    {
        //======================================================
        // Global tool
        //======================================================

        //Global context
        private static INode n1;
        private static INode n2;
        private static IPlayer p1;
        private static IPlayer p2;

        //Context per test case
        private GameNode gn1;
        private GameNode gn2;
        private GameNodeManager nm;
        private SquadManager m;
        
        //Distance function for the test case
        public static TimeSpan TestFunctionDistance(IReadOnlyNode n1, IReadOnlyNode n2)
        {
            double dx = n1.X - n2.X;
            double dy = n1.Y - n2.Y;

            double d = Math.Sqrt(dx * dx + dy * dy);
            d = d - n1.Radius - n2.Radius;

            return TimeSpan.FromSeconds(d / 10);
        }
        
        //======================================================
        // Test initialization
        //======================================================

        [ClassInitialize]
        public static void GenerateGlobalContext(TestContext context)
        {
            n1 = new Node();
            n1.X = 0;
            n1.Y = 0;
            n1.Radius = 10;
            n1.MaxRessource = 50;
            n1.InitialRessource = 10;

            n2 = new Node();
            n2.X = 50;
            n2.Y = 0;
            n2.Radius = 5;
            n2.MaxRessource = 25;
            n2.InitialRessource = 10;

            p1 = new Player();
            p1.PublicPseudo = "p1";
            p2 = new Player();
            p2.PublicPseudo = "p2";
        }

        [TestInitialize]
        public void GenerateLocalContext()
        {
            gn1 = new GameNode(n1);
            gn1.CurrentOwner = p1;

            gn2 = new GameNode(n2);
            gn2.CurrentOwner = p2;

            nm = new GameNodeManager(
                    delegate (double t) { return t; }
                );

            m = new SquadManager(nm, TestFunctionDistance);
        }

        //======================================================
        // Test case
        //======================================================

        [TestMethod]
        public void SimpleSquadSend()
        {           
            //Use the context
            nm.Zero = DateTime.Now;
            nm.SetCurrentValue(gn1, n1.InitialRessource);
            nm.SetCurrentValue(gn2, n2.InitialRessource);
            
            m.SendSquad(5, gn2, gn1);

            System.Threading.Thread.Sleep(3400); //Check just before arrival
            m.Update();
            Assert.IsTrue(Tools.AreDoubleEqual(13.4, nm.GetCurrentValue(gn1), 0.1));
            Assert.IsTrue(Tools.AreDoubleEqual(8.4, nm.GetCurrentValue(gn2), 0.1));

            System.Threading.Thread.Sleep(200); //Check just after arrival
            m.Update();
            Assert.IsTrue(Tools.AreDoubleEqual(8.6, nm.GetCurrentValue(gn1), 0.1));
            Assert.IsTrue(Tools.AreDoubleEqual(8.6, nm.GetCurrentValue(gn2), 0.1));
        }

        [TestMethod]
        public void WillSendMoreThanPossible()
        {
            //Use the context
            nm.Zero = DateTime.Now;
            nm.SetCurrentValue(gn1, n1.InitialRessource);
            nm.SetCurrentValue(gn2, n2.InitialRessource);

            m.SendSquad(20, gn2, gn1);

            System.Threading.Thread.Sleep(3400); //Check just before arrival
            m.Update();
            Assert.IsTrue(Tools.AreDoubleEqual(13.4, nm.GetCurrentValue(gn1), 0.1));
            Assert.IsTrue(Tools.AreDoubleEqual(3.4, nm.GetCurrentValue(gn2), 0.1));

            System.Threading.Thread.Sleep(200); //Check just after arrival
            m.Update();
            Assert.IsTrue(Tools.AreDoubleEqual(3.6, nm.GetCurrentValue(gn1), 0.1));
            Assert.IsTrue(Tools.AreDoubleEqual(3.6, nm.GetCurrentValue(gn2), 0.1));
        }

        [TestMethod]
        [Timeout(5000)]
        public void DoubleSendInChain()
        {
            //Use the context
            nm.Zero = DateTime.Now;
            nm.SetCurrentValue(gn1, n1.InitialRessource);
            nm.SetCurrentValue(gn2, n2.InitialRessource);

            m.SendSquad(5, gn2, gn1);
            m.SendSquad(5, gn2, gn1);
            
            System.Threading.Thread.Sleep(3400); //Check just before arrival
            m.Update();
            Assert.IsTrue(Tools.AreDoubleEqual(13.4, nm.GetCurrentValue(gn1), 0.1));
            Assert.IsTrue(Tools.AreDoubleEqual(3.4, nm.GetCurrentValue(gn2), 0.1));

            System.Threading.Thread.Sleep(200); //Check just after arrival
            m.Update();
            Assert.IsTrue(Tools.AreDoubleEqual(3.6, nm.GetCurrentValue(gn1), 0.1));
            Assert.IsTrue(Tools.AreDoubleEqual(3.6, nm.GetCurrentValue(gn2), 0.1));
        }

        [TestMethod]
        public void SymetricSquadFight()
        {
            //Use the context
            nm.Zero = DateTime.Now;
            nm.SetCurrentValue(gn1, n1.InitialRessource);
            nm.SetCurrentValue(gn2, n2.InitialRessource);

            m.SendSquad(2, gn2, gn1);
            m.SendSquad(2, gn1, gn2);

            System.Threading.Thread.Sleep(3400); //Check just before arrival
            m.Update();
            Assert.IsTrue(Tools.AreDoubleEqual(11.4, nm.GetCurrentValue(gn1), 0.1));
            Assert.IsTrue(Tools.AreDoubleEqual(11.4, nm.GetCurrentValue(gn2), 0.1));

            System.Threading.Thread.Sleep(200); //Check just after arrival
            m.Update();
            Assert.IsTrue(Tools.AreDoubleEqual(11.6, nm.GetCurrentValue(gn1), 0.1));
            Assert.IsTrue(Tools.AreDoubleEqual(11.6, nm.GetCurrentValue(gn2), 0.1));
        }

        [TestMethod]
        public void AsymetricSquadFight1()
        {
            //Use the context
            nm.Zero = DateTime.Now;
            nm.SetCurrentValue(gn1, n1.InitialRessource);
            nm.SetCurrentValue(gn2, n2.InitialRessource);

            m.SendSquad(3, gn2, gn1);
            m.SendSquad(2, gn1, gn2);

            System.Threading.Thread.Sleep(3400); //Check just before arrival
            m.Update();
            Assert.IsTrue(Tools.AreDoubleEqual(11.4, nm.GetCurrentValue(gn1), 0.1));
            Assert.IsTrue(Tools.AreDoubleEqual(10.4, nm.GetCurrentValue(gn2), 0.1));

            System.Threading.Thread.Sleep(200); //Check just after arrival
            m.Update();
            Assert.IsTrue(Tools.AreDoubleEqual(10.6, nm.GetCurrentValue(gn1), 0.1));
            Assert.IsTrue(Tools.AreDoubleEqual(10.6, nm.GetCurrentValue(gn2), 0.1));
        }

        [TestMethod]
        public void AsymetricSquadFight2()
        {
            //Use the context
            nm.Zero = DateTime.Now;
            nm.SetCurrentValue(gn1, n1.InitialRessource);
            nm.SetCurrentValue(gn2, n2.InitialRessource);

            m.SendSquad(2, gn1, gn2); //This ligne differ from AsymetricSquadFight1
            m.SendSquad(3, gn2, gn1);

            System.Threading.Thread.Sleep(3400); //Check just before arrival
            m.Update();
            Assert.IsTrue(Tools.AreDoubleEqual(11.4, nm.GetCurrentValue(gn1), 0.1));
            Assert.IsTrue(Tools.AreDoubleEqual(10.4, nm.GetCurrentValue(gn2), 0.1));

            System.Threading.Thread.Sleep(200); //Check just after arrival
            m.Update();
            Assert.IsTrue(Tools.AreDoubleEqual(10.6, nm.GetCurrentValue(gn1), 0.1));
            Assert.IsTrue(Tools.AreDoubleEqual(10.6, nm.GetCurrentValue(gn2), 0.1));
        }

        [TestMethod]
        public void ChangeOwnership()
        {
            //Use the context
            nm.Zero = DateTime.Now;
            nm.SetCurrentValue(gn1, n1.InitialRessource);
            nm.SetCurrentValue(gn2, n2.InitialRessource-8);
            
            m.SendSquad(10, gn1, gn2);

            System.Threading.Thread.Sleep(3400); //Check just before arrival
            m.Update();
            Assert.IsTrue(Tools.AreDoubleEqual(3.4, nm.GetCurrentValue(gn1), 0.1));
            Assert.IsTrue(Tools.AreDoubleEqual(5.4, nm.GetCurrentValue(gn2), 0.1));
            Assert.AreEqual(p2, gn2.CurrentOwner);

            System.Threading.Thread.Sleep(200); //Check just after arrival
            m.Update();
            Assert.IsTrue(Tools.AreDoubleEqual(3.6, nm.GetCurrentValue(gn1), 0.1));
            Assert.IsTrue(Tools.AreDoubleEqual(4.4, nm.GetCurrentValue(gn2), 0.1));
            Assert.AreEqual(p1, gn2.CurrentOwner);
        }
    }
}
