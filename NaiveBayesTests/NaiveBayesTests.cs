using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace kNearestNeighborsTests
{
    [TestClass]
    public class NaiveBayesTests
    {
        [TestMethod]
        public void NaiveBayersSpamTrueTest()
        {
            NaiveBayes.NaiveBayes naiveBayes = new NaiveBayes.NaiveBayes();
            var result = naiveBayes.CheckEmail("Buy Cheap cialis Online");
            Assert.AreEqual(true, result);
            result = naiveBayes.CheckEmail("Enlarge Your Penis");
            Assert.AreEqual(true, result);
            result = naiveBayes.CheckEmail("accept VISA, MasterCard");
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void NaiveBayersNotSpamFalseTest()
        {
            NaiveBayes.NaiveBayes naiveBayes = new NaiveBayes.NaiveBayes();
            var result = naiveBayes.CheckEmail("Sincerely Mathias");
            Assert.AreEqual(false, result);
            result = naiveBayes.CheckEmail("Dear Graduates");
            Assert.AreEqual(false, result);
            result = naiveBayes.CheckEmail("Thanks in advance for your support");
            Assert.AreEqual(false, result);
            result = naiveBayes.CheckEmail("for it with my Mastercard");
            Assert.AreEqual(false, result);
        }
    }
}
