using System;
using System.Collections.Generic;
using Xunit;

namespace Salon
{
  public class StylistTest : IDisposable
  {
    public StylistTest()
    {
      DBConfiguration.ConnectionString="Data Source=(localdb)\\mssqllocaldb;Initial Catalog=salon_test;Integrated Security=SSPI;";
    }
    public void Test_DatabaseEmptyAtFirst()
    {
      //Arrange
      int countExpected = 0;
      // Act
      int countResult = Stylist.GetAll().Count;
      // Assert
      Assert.Equal(countExpected, countResult);
    }
    public void Dispose()
    {
      Stylist.DeleteAll();
    }
    [Fact]
    public void Test_Save_SavesToDatabase()
    {
      // Arrange
      Stylist testStylist = new Stylist("Doc Gonzo", "Brush");
      testStylist.Save();
      // Act
      List<Stylist> listResult = Stylist.GetAll();
      List<Stylist> listExpected = new List<Stylist>{testStylist};
      // Assert
      Assert.Equal(listExpected, listResult);
    }
    [Fact]
    public void Test_Save_AssignsIdToObject()
    {
      // Arrange
      Stylist testStylist = new Stylist("Doc Gonzo", "Haircut");
      // Act
      testStylist.Save();
      Stylist savedStylist = Stylist.GetAll()[0];
      int result = savedStylist.GetId();
      int testId = testStylist.GetId();
      // Assert
      Assert.Equal(testId, result);
    }
  }
}
