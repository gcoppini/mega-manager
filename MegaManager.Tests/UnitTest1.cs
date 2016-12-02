using Microsoft.VisualStudio.TestTools.UnitTesting;
using MegaManager.Data.Main;
using System.Linq;
using MegaManager.Infra.Data;

namespace MegaManager.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            using (MegaManagerContext ctx = new MegaManagerContext())
            {
                var gabaritos = ctx.Gabaritos.ToList();
            }
        }
    }
}
