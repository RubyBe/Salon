using System;
using Xunit;

namespace Salon
{
  public class StylistTest
  {
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
      // Act
      // Assert
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
