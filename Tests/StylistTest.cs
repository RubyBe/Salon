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
      // Act
      // Assert
    }
    [Fact]
    public void Find_FindsAStylist_StylistFound()
    {
      // Arrange
      // Act
      // Assert
    }
    [Fact]
    public void Update_UpdatesAStylist_StylistUpdated()
    {
      // Arrange
      // Act
      // Assert
    }
    [Fact]
    public void Delete_DeletesASingleStylist_SingleStylistDeleted()
    {
      // Arrange
      // Act
      // Assert
    }
  }
}
