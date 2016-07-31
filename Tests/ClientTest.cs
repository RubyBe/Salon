using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Xunit;


namespace Salon
{
  public class ClientTest : IDisposable
  {
    public ClientTest()
    {
      DBConfiguration.ConnectionString="Data Source=(localdb)\\mssqllocaldb;Initial Catalog=salon_test;Integrated Security=SSPI;";
    }
    public void Test_DatabaseEmptyAtFirst()
    {
      //Arrange
      int countExpected = 0;
      // Act
      int countResult = Client.GetAll().Count;
      // Assert
      Assert.Equal(countExpected, countResult);
    }
    public void Dispose()
    {
      Client.DeleteAll();
    }
    [Fact]
    public void Test_Save_SavesToDatabase()
    {
      // Arrange
      Client testClient = new Client("Doc Gonzo", "Brush", 1);
      testClient.Save();
      // Act
      List<Client> listResult = Client.GetAll();
      List<Client> listExpected = new List<Client>{testClient};
      // Assert
      Assert.Equal(listExpected, listResult);
    }
    [Fact]
    public void Test_Save_AssignsIdToObject()
    {
      // Arrange
      Client testClient = new Client("Doc Gonzo", "Haircut", 1);
      // Act
      testClient.Save();
      Client savedClient = Client.GetAll()[0];
      int result = savedClient.GetId();
      int testId = testClient.GetId();
      // Assert
      Assert.Equal(testId, result);
    }
    [Fact]
    public void FindById_FindsAClientById_ClientFoundById()
    {
      // Arrange
      Client testClient = new Client("Doc Gonzo", "Brush", 1);
      testClient.Save();
      // Act
      Client foundClient = Client.Find(testClient.GetId());
      // Assert
      Assert.Equal(testClient, foundClient);
    }
    [Fact]
    public void Update_UpdatesAClient_ClientUpdated()
    {
      // Arrange
      string name1 = "Doc Gonzo";
      string service1 = "Fur";
      Client testClient1 = new Client(name1, service1, 1);
      testClient1.Save();
      string name2 = "Doctor Gonzo";
      string nameExpected = name2;
      // Act
      testClient1.Update(name2);
      string nameResult = testClient1.GetName();
      // Assert
      Assert.Equal(nameExpected, nameResult);
    }
    [Fact]
    public void Test_NamesAreEqual_ReturnsTrueIfNamesAreTheSame()
    {
      // Arrange, Act
      Client firstClient = new Client("Doc Gonzo", "Brush", 1);
      Client secondClient = new Client("Doc Gonzo", "Brush", 1);
      //Assert
      Assert.Equal(firstClient, secondClient);
    }
    [Fact]
    public void Test_Delete_DeletesClientFromDatabase()
    {
      // Arrange
      string name = "Yousef";
      Client testClient = new Client(name, "Cuts", 1);
      testClient.Save();
      string name2 = "John";
      Client testClient2 = new Client(name, "Brushes", 1);
      testClient2.Save();
      // Act
      testClient.Delete();
      List<Client> resultClients = Client.GetAll();
      List<Client> testClientList = new List<Client> {testClient2};
      // Assert
      Assert.Equal(testClientList, resultClients);
    }
  }
}
