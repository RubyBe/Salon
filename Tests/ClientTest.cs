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
      // Client.DeleteAll();
    }
    [Fact]
    public void Test_Save_SavesToDatabase()
    {
      // Arrange
      Client testClient = new Client("Doc Gonzo", "Brush");
      List<Client> listExpected = new List<Client>{testClient};
      // Act
      testClient.Save();
      List<Client> listResult = Client.GetAll();
      // Assert
      Assert.Equal(listExpected, listResult);
    }
    [Fact]
    public void Test_Save_AssignsIdToObject()
    {
      // Arrange
      Client testClient = new Client("Doc Gonzo", "Haircut");
      // Act
      testClient.Save();
      Client savedClient = Client.GetAll()[0];
      int result = savedClient.GetId();
      int testId = testClient.GetId();
      // Assert
      Assert.Equal(testId, result);
    }
    [Fact]
    public void New_CreatesNewClient_ClientCreated()
    {
      // Arrange
      string name = "Doc Gonzo";
      string service = "Haircut";
      // Act
      Client testClient = new Client(name, service);
      string testName = testClient.GetName();
      // Assert
      Console.WriteLine(testClient);
      Assert.Equal(name, testName);
    }
    [Fact]
    public void GetAll_GetsAllClients_AllClientsReturned()
    {
      // // Arrange
      // string name1 = "Doc Gonzo";
      // string service1 = "Fur";
      // string name2 = "Mouse";
      // string service2 = "Shedding";
      // Client testClient1 = new Client(name1, service1);
      // Client testClient2 = new Client(name2, service2);
      // List<Client> listExpected = new List<Client>{ testClient1, testClient2};
      // testClient1.Save();
      // testClient2.Save();
      // // Act
      // List<Client> listResult = Client.GetAll();
      // // Assert
      // Assert.Equal(listExpected, listResult);
    }
    [Fact]
    public void DeleteAll_DeletesAllClients_AllClientsDeleted()
    {
      // // Arrange
      // string name1 = "Doc Gonzo";
      // string service1 = "Fur";
      // string name2 = "Mouse";
      // string service2 = "Shedding";
      // Client testClient1 = new Client(name1, service1);
      // Client testClient2 = new Client(name2, service2);
      // testClient1.Save();
      // testClient2.Save();
      // List<Client> listExpected = new List<Client>(){};
      // // Act
      // Client.DeleteAll();
      // List<Client> listResult = Client.GetAll();
      // // Assert
      // Assert.Equal(listExpected, listResult);
    }
    [Fact]
    public void FindById_FindsAClientById_ClientFoundById()
    {
      // // Arrange
      // string name1 = "Doc Gonzo";
      // string service1 = "Fur";
      // string name2 = "Mouse";
      // string service2 = "Shedding";
      // Client testClient1 = new Client(name1, service1);
      // Client testClient2 = new Client(name2, service2);
      // testClient1.Save();
      // testClient2.Save();
      // string nameExpected = testClient1.GetName();
      // // Act
      // Client resultClient = Client.FindById(1);
      // string nameResult = resultClient.GetName();
      // // Assert
      // Assert.Equal(nameExpected, nameResult);
    }
    [Fact]
    public void Update_UpdatesAClient_ClientUpdated()
    {
      // Arrange
      string name1 = "Doc Gonzo";
      string service1 = "Fur";
      Client testClient1 = new Client(name1, service1);
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
    public void Delete_DeletesASingleClient_SingleClientDeleted()
    {
      // Arrange
      string name1 = "Doc Gonzo";
      string service1 = "Fur";
      Client testClient1 = new Client(name1, service1);
      testClient1.Save();
      int countExpected = 0;
      // Act
      Client.DeleteById(testClient1.GetId());
      int countResult = Client.GetCount();
      // Assert
      Assert.Equal(countExpected, countResult);
    }
    [Fact]
    public void Test_NamesAreEqual_ReturnsTrueIfNamesAreTheSame()
    {
      // Arrange, Act
      Client firstClient = new Client("Doc Gonzo", "Brush");
      Client secondClient = new Client("Doc Gonzo", "Brush");
      //Assert
      Assert.Equal(firstClient, secondClient);
    }
  }
}
