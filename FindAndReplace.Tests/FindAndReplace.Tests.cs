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
      FARP myFap = new FARP("This is a Test", "Test", "Fap");
      string expected = "This is a Fap";

      string actual = myFap.FindReplace();

      Assert.AreEqual(expected,actual);
    }

    [TestMethod]
    public void FindReplacePartials_ReplacePartialStringMatches_True()
    {
      FARP myFap = new FARP("I am walking my caT to the cAthedral.", "cat", "dog");
      string expected = "I am walking my dog to the doghedral.";

      string actual = myFap.FindReplacePartials();

      Assert.AreEqual(expected,actual);
    }
  }
}
