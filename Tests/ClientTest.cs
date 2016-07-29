using System;
using Xunit;


namespace Salon
{
  public class ClientTest
  {
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
      Assert.Equal(instancesExpected, instancesResult);
    }
    [Fact]
    public void GetAll_GetsAllClients_AllClientsReturned()
    {
    }
    [Fact]
    public void DeleteAll_DeletesAllClients_AllClientsDeleted()
    {
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
