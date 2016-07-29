using System;
using System.Collections.Generic;
using Xunit;


namespace Salon
{
  public class ClientTest : IDisposable
  {
    public void Dispose()
    {
      Client.DeleteAll();
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
    public void Saves_SavesNewClient_ClientSaved()
    {
      // Arrange
      string name = "Doc Gonzo";
      string service = "Fur";
      int instancesExpected = 1;
      Client testClient = new Client(name, service);
      // Act
      testClient.Save();
      int instancesResult = Client.GetCount();
      // Assert
      Console.WriteLine(instancesResult);
      Assert.Equal(instancesExpected, instancesResult);
    }
    [Fact]
    public void GetAll_GetsAllClients_AllClientsReturned()
    {
      // Arrange
      string name1 = "Doc Gonzo";
      string service1 = "Fur";
      string name2 = "Mouse";
      string service2 = "Shedding";
      Client testClient1 = new Client(name1, service1);
      Client testClient2 = new Client(name2, service2);
      List<Client> listExpected = new List<Client>{ testClient1, testClient2};
      testClient1.Save();
      testClient2.Save();
      // Act
      List<Client> listResult = Client.GetAll();
      // Assert
      Assert.Equal(listExpected, listResult);
    }
    [Fact]
    public void DeleteAll_DeletesAllClients_AllClientsDeleted()
    {
      // Arrange
      string name1 = "Doc Gonzo";
      string service1 = "Fur";
      string name2 = "Mouse";
      string service2 = "Shedding";
      Client testClient1 = new Client(name1, service1);
      Client testClient2 = new Client(name2, service2);
      testClient1.Save();
      testClient2.Save();
      List<Client> listExpected = new List<Client>(){};
      // Act
      Client.DeleteAll();
      List<Client> listResult = Client.GetAll();
      // Assert
      Assert.Equal(listExpected, listResult);
    }
    [Fact]
    public void FindById_FindsAClientById_ClientFoundById()
    {
    }
    [Fact]
    public void Update_UpdatesAClient_ClientUpdated()
    {
    }
    [Fact]
    public void Delete_DeletesASingleClient_SingleClientDeleted()
    {
    }
  }
}
