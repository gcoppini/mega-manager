using Microsoft.VisualStudio.TestTools.UnitTesting;
using MegaManager.Data.Main;
using System.Linq;

namespace MegaManager.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            using (DataContext ctx = new DataContext())
            {
                var gabaritos = ctx.Gabaritos.ToList();
            }
        }
    }
}
