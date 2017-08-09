using FindAndReplace.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

namespace FindAndReplace.Tests
{
  [TestClass]
  public class FindAndReplaceTest
  {
    [TestMethod]
    public void FindReplace_ReplaceAWordInASentenceWithAnotherWord_True()
    {
      FAP myFap = new FAP("This is a Test", "Test", "Fap");
      string expected = "This is a Fap";

      string actual = myFap.FindReplace();

      Assert.AreEqual(expected,actual);
    }
  }
}
