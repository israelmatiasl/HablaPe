using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System;

namespace SocialNetwork.DL.DM
{
    public class SocialNetworkDbContext
    {
        public IMongoDatabase database;

        public SocialNetworkDbContext()
        {
            var mongoClient = new MongoClient(ConfigurationDL.MongoConnection);
            database = mongoClient.GetDatabase(ConfigurationDL.DataBase);
        }

        public IMongoCollection<User> Users { get { return database.GetCollection<User>("User"); } }
        public IMongoCollection<Post> Posts { get { return database.GetCollection<Post>("Post"); } }
        public IMongoCollection<Image> Images { get { return database.GetCollection<Image>("Image"); } }
        public IMongoCollection<Follow> Follows { get { return database.GetCollection<Follow>("Follow"); } }
        
    }

    #region EFCore2.1
    //public class SocialNetworkContext : DbContext
    //{
    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    {
    //        optionsBuilder.UseSqlServer("Data Source=MSI;Initial Catalog=SocialNetworkDB;Trusted_Connection=True;User ID=sa;Password=98714731iml7;MultipleActiveResultSets=True");
    //    }

    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        #region Entities

    //        modelBuilder.Entity<User>()
    //            .HasKey(p => p.id);
    //        modelBuilder.Entity<User>()
    //            .Property(x => x.id)
    //            .HasColumnName("id");



    //        #endregion Entities
    //    }
    //}
    #endregion EFCore2.1
}
