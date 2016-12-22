using System;
using System.IO;
using Windows.Storage;
using Microsoft.EntityFrameworkCore;

namespace EFCoreUWP {
  public class BingeContext : DbContext {
    public DbSet<CookieBinge> Binges { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options) {
#if WINDOWS_UWP
      var databaseFilePath = "CookieBinge.db";
      try {
           databaseFilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, databaseFilePath);
      }
      catch (InvalidOperationException) {
      }

      options.UseSqlite($"Data source={databaseFilePath}");
    }
  }
}