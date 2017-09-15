using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Stack_PushIsNull_ThrowsAnException()
        {
            
        }
    }
}
