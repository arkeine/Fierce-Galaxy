using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FierceGalaxyInterface;
using FierceGalaxyServer;

namespace FierceGalaxyUnitTest
{
    [TestClass]
    public class LinkTransferManagerTest
    {
        //======================================================
        // Global tool
        //======================================================

        //Global context
        private static INode n1;
        private static INode n2;
        private static IReadOnlyPlayer p1;
        private static IReadOnlyPlayer p2;

        //Context per test case
        private GameNode gn1;
        private GameNode gn2;
        private FunctionDictionary<GameNode> nm;
        private LinkTransferManager m;
        
        //Distance function for the test case
        public static TimeSpan TestFunctionDistance(IReadOnlyNode n1, IReadOnlyNode n2)
        {
            double dx = n1.X - n2.X;
            double dy = n1.Y - n2.Y;

            double d = Math.Sqrt(dx * dx + dy * dy);
            d = d - n1.Radius - n2.Radius;

            return TimeSpan.FromSeconds(d / 10);
        }
        
        public static bool AreDoubleEqual(double d1, double d2, double epsylon=0.001)
        {
            if(Math.Abs(d1 - d2) < epsylon)
            {
                return true;
            }
            else
            {
                Console.WriteLine("AreDoubleEqual : " + d1 + "=" + d2 + " Fail");
                return false;
            }
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
            n1.MaxCapacity = 50;
            n1.InitialCapacity = 10;

            n2 = new Node();
            n2.X = 50;
            n2.Y = 0;
            n2.Radius = 5;
            n2.MaxCapacity = 25;
            n2.InitialCapacity = 10;

            p1 = new Player();
            p2 = new Player();
        }

        [TestInitialize]
        public void GenerateLocalContext()
        {
            gn1 = new GameNode();
            gn1.CurrentOwner = p1;
            gn1.NodeData = n1;

            gn2 = new GameNode();
            gn2.CurrentOwner = p2;
            gn2.NodeData = n2;

            nm = new FunctionDictionary<GameNode>(
                    delegate (double t) { return t; }
                );

            m = new LinkTransferManager(nm, TestFunctionDistance);
        }

        //======================================================
        // Test case
        //======================================================

        [TestMethod]
        public void GameSenario1()
        {           
            //Use the context
            nm.Zero = DateTime.Now;
            nm.SetCurrentValue(gn1, n1.InitialCapacity);
            nm.SetCurrentValue(gn2, n2.InitialCapacity);
            
            m.SendSquad(5, gn2, gn1);
            System.Threading.Thread.Sleep(3400); //Check just before arrival
            m.Update();
            Assert.IsTrue(AreDoubleEqual(13.4, nm.GetCurrentValue(gn1), 0.1));
            Assert.IsTrue(AreDoubleEqual(8.4, nm.GetCurrentValue(gn2), 0.1));
            System.Threading.Thread.Sleep(200); //Check just after arrival
            m.Update();
            Assert.IsTrue(AreDoubleEqual(8.6, nm.GetCurrentValue(gn1), 0.1));
            Assert.IsTrue(AreDoubleEqual(8.6, nm.GetCurrentValue(gn2), 0.1));
        }
    }
}
