using System.Collections.Specialized;

namespace TestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
            // testeamos la connection string Data Source=//localhost:1521/xe;User Id=sys;Password=ReCoilGammer;DBA Privilege=SYSDBA
            // testeamos la conexión a la base de datos

            Assert.IsTrue(new OracleConnection("Data Source=//localhost:1521/xe;User Id=sys;Password=ReCoilGammer;DBA Privilege=SYSDBA"))
        }
    }
}