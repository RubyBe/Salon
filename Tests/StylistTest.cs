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
    [Fact]
    public void Test_Updated_UpdatesStylistInDatabase()
    {
      // Arrange
      string name = "Doctor Gonzo";
      Stylist testStylist = new Stylist(name, "Cuts");
      testStylist.Save();
      string newName = "Dr. Gonzo";
      // Act
      testStylist.Update(newName);
      string result = testStylist.GetName();
      // Assert
      Assert.Equal(newName, result);
    }
    [Fact]
    public void Test_Delete_DeletesStylistFromDatabase()
    {
      // Arrange
      string name = "Doctor Gonzo";
      Stylist testStylist = new Stylist(name, "Cuts");
      testStylist.Save();
      string name2 = "Mouse";
      Stylist testStylist2 = new Stylist(name, "Brushes");
      testStylist2.Save();
      Client testClient = new Client("Sid", "Cut", testStylist.GetId());
      testClient.Save();
      Client testClient2 = new Client("Yousef", "Color", testStylist2.GetId());
      testClient2.Save();
      // Act
      testStylist.Delete();
      List<Stylist> resultStylists = Stylist.GetAll();
      List<Stylist> testStylistList = new List<Stylist> {testStylist2};
      List<Client> resultClients = Client.GetAll();
      List<Client> testClientList = new List<Client> {testClient2};
      // Assert
      Assert.Equal(testStylistList, resultStylists);
      Assert.Equal(testClientList, resultClients);
    }
  }
}
