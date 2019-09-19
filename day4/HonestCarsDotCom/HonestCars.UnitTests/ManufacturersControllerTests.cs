using System;
using HonestCars.DataModel;
using HonestCars.WebApplication.Controllers;
using Xunit;
using Moq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HonestCars.UnitTests
{
    public class ManufacturersControllerTests {

      [Fact]
      public void CreatingMfrRedirectsToIndexPage() {
        var mockDatabase = new Mock<HonestCarsDbContext>();
        var bucket = new Mock<DbSet<Manufacturer>>();
        mockDatabase.SetupGet(db => db.Manufacturers).Returns(bucket.Object);
        mockDatabase.Setup(m => m.SaveChanges()).Verifiable();

        var c = new ManufacturersController(mockDatabase.Object);
        var result = c.Create(new Manufacturer() { Name = "Doesn't Matter" } );
        Assert.True(result is Microsoft.AspNetCore.Mvc.RedirectToActionResult);
      }

      [Fact]
      public void CreatingManufacturerAddsManufacturerToDatabase() {

        Manufacturer verifiedManufacturer = null;

        var mockDatabase = new Mock<HonestCarsDbContext>();
        var bucket = new Mock<DbSet<Manufacturer>>();

        bucket.Setup(b => b.Add(It.IsAny<Manufacturer>())).Callback<Manufacturer>(m => {
          verifiedManufacturer = m;
        });

        mockDatabase.SetupGet(db => db.Manufacturers).Returns(bucket.Object);
        mockDatabase.Setup(m => m.SaveChanges()).Verifiable();
        
        var c = new ManufacturersController(mockDatabase.Object);
        var mfr = new Manufacturer { Name = "Test Manufacturer" };

        var result = c.Create(mfr);

        mockDatabase.Verify();

        Assert.NotNull(verifiedManufacturer);
      }
    }
}