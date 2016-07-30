using System;
using System.Collections.Generic;
using Xunit;

namespace Salon
{
  public class StylistTest : IDisposable
  {
    public void Dispose()
    {
      Stylist.DeleteAll();
    }
    [Fact]
    public void New_CreatesNewStylist_StylistCreated()
    {
      // Arrange
      string name = "Doc Gonzo";
      string speciality = "Fur";
      // Act
      Stylist testStylist = new Stylist(name, speciality);
      string testName = testStylist.GetName();
      // Assert
      Console.WriteLine(testStylist);
      Assert.Equal(name, testName);
    }
    [Fact]
    public void Saves_SavesNewStylist_StylistSaved()
    {
      // Arrange
      string name = "Doc Gonzo";
      string speciality = "Fur";
      int instancesExpected = 1;
      Stylist testStylist = new Stylist(name, speciality);
      // Act
      testStylist.Save();
      int instancesResult = Stylist.GetCount();
      // Assert
      Assert.Equal(instancesExpected, instancesResult);
    }
    [Fact]
    public void GetAll_GetsAllStylists_AllStylistsReturned()
    {
      // Arrange
      string name1 = "Doc Gonzo";
      string speciality1 = "Fur";
      string name2 = "Mouse";
      string speciality2 = "Shedding";
      Stylist testStylist1 = new Stylist(name1, speciality1);
      Stylist testStylist2 = new Stylist(name2, speciality2);
      List<Stylist> listExpected = new List<Stylist>{ testStylist1, testStylist2};
      testStylist1.Save();
      testStylist2.Save();
      // Act
      List<Stylist> listResult = Stylist.GetAll();
      // Assert
      Assert.Equal(listExpected, listResult);
    }
    [Fact]
    public void DeleteAll_DeletesAllStylists_AllStylistsDeleted()
    {
      // Arrange
      string name1 = "Doc Gonzo";
      string speciality1 = "Fur";
      string name2 = "Mouse";
      string speciality2 = "Shedding";
      Stylist testStylist1 = new Stylist(name1, speciality1);
      Stylist testStylist2 = new Stylist(name2, speciality2);
      testStylist1.Save();
      testStylist2.Save();
      List<Stylist> listExpected = new List<Stylist>(){};
      // Act
      Stylist.DeleteAll();
      List<Stylist> listResult = Stylist.GetAll();
      // Assert
      Assert.Equal(listExpected, listResult);
    }
    [Fact]
    public void FindById_FindsAStylistById_StylistFoundById()
    {
      // Arrange
      string name1 = "Doc Gonzo";
      string speciality1 = "Fur";
      string name2 = "Mouse";
      string speciality2 = "Shedding";
      Stylist testStylist1 = new Stylist(name1, speciality1);
      Stylist testStylist2 = new Stylist(name2, speciality2);
      testStylist1.Save();
      testStylist2.Save();
      string nameExpected = testStylist1.GetName();
      // Act
      Stylist resultStylist = Stylist.FindById(1);
      string nameResult = resultStylist.GetName();
      // Assert
      Assert.Equal(nameExpected, nameResult);
    }
    [Fact]
    public void Update_UpdatesAStylist_StylistUpdated()
    {
      // Arrange
      string name1 = "Doc Gonzo";
      string speciality1 = "Fur";
      Stylist testStylist1 = new Stylist(name1, speciality1);
      testStylist1.Save();
      string name2 = "Doctor Gonzo";
      string nameExpected = name2;
      // Act
      testStylist1.Update(name2);
      string nameResult = testStylist1.GetName();
      // Assert
      Assert.Equal(nameExpected, nameResult);
    }
    [Fact]
    public void Delete_DeletesASingleStylist_SingleStylistDeleted()
    {
      // Arrange
      string name1 = "Doc Gonzo";
      string speciality1 = "Fur";
      Stylist testStylist1 = new Stylist(name1, speciality1);
      testStylist1.Save();
      int countExpected = 0;
      // Act
      Stylist.DeleteById(testStylist1.GetId());
      int countResult = Stylist.GetCount();
      // Assert
      Assert.Equal(countExpected, countResult);
    }
    public void GetAllClients_GetsAllClientsForStylists_AllStylistClientsReturned()
    {
      // Arrange
      string nameStylist = "Doc Gonzo";
      string specialityStylist = "Fur";
      string nameClient = "Mouse";
      string serviceClient = "Shedding";
      Stylist testStylist = new Stylist(nameStylist, specialityStylist);
      Client testClient = new Client(nameClient, serviceClient, 1);
      testStylist.Save();
      testClient.Save();
      List<Client> listExpected = new List<Client> {testClient};
      // Act
      List<Client> listResult = testStylist.GetClients();
      // Assert
      Assert.Equal(listExpected, listResult);
    }
  }
}
