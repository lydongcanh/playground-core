using Microsoft.EntityFrameworkCore;
using Playground.API.Core.Application.Models;
using File = Playground.API.Core.Application.Models.File;

namespace Playground.API.Core.Infrastructure.SqlDatabase;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<DataRoom> DataRooms { get; set; }
    public DbSet<Folder> Folders { get; set; }
    public DbSet<File> Files { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DataRoom>()
            .HasMany(dr => dr.Folders)
            .WithOne()
            .HasForeignKey(f => f.DataRoomId);

        modelBuilder.Entity<Folder>()
            .HasOne(f => f.ParentFolder)
            .WithMany(f => f.ChildrenFolders)
            .HasForeignKey(f => f.ParentFolderId);

        modelBuilder.Entity<Folder>()
            .HasMany(f => f.Files)
            .WithOne(d => d.Folder)
            .HasForeignKey(d => d.FolderId);

        modelBuilder.Entity<File>()
            .HasOne(f => f.Folder)
            .WithMany(f => f.Files)
            .HasForeignKey(f => f.FolderId);
    }
}