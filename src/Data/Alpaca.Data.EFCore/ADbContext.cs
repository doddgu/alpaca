using Alpaca.Data.Entities;
using Alpaca.Data.Entities.Configurations;
using Alpaca.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alpaca.Data.EFCore
{
    public class ADbContext : DbContext
    {
        private string _connectionString = null;

        protected ADbContext(string connectionString)
        {
            _connectionString = connectionString;
            //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            //ChangeTracker.AutoDetectChangesEnabled = false;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            // https://docs.microsoft.com/zh-cn/ef/core/dbcontext-configuration/
            => options.UseSqlServer(_connectionString);

        public static ADbContext Create()
        {
            return Create(null);
        }

        public static ADbContext Create(string connectionString)
        {
            return new ADbContext(connectionString ?? AlpacaConfigWrapper.GetConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserPermissionConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        #region CRUD

        public TEntity Add<TEntity, TKey>(TEntity entity, int updateUserID)
            where TEntity : EntityBase<TKey>
        {
            entity.CreateTime = DateTime.Now;
            entity.UpdateTime = DateTime.Now;
            entity.CreateUserID = entity.UpdateUserID = updateUserID;

            Set<TEntity>().Add(entity);

            SaveChanges();

            return entity;
        }

        public List<TEntity> AddRange<TEntity, TKey>(List<TEntity> entities, int updateUserID)
            where TEntity : EntityBase<TKey>
        {
            entities.ForEach(entity =>
            {
                entity.CreateTime = DateTime.Now;
                entity.UpdateTime = DateTime.Now;
                entity.CreateUserID = entity.UpdateUserID = updateUserID;

                Set<TEntity>().Add(entity);
            });

            SaveChanges();

            return entities;
        }

        public TEntity Update<TEntity, TKey>(TEntity entity, int updateUserID)
            where TEntity : EntityBase<TKey>
        {
            entity.UpdateTime = DateTime.Now;
            entity.UpdateUserID = updateUserID;

            Set<TEntity>().Update(entity);

            SaveChanges();

            return entity;
        }

        public void Delete<TEntity, TKey>(TEntity entity, int updateUserID)
            where TEntity : EntityBase<TKey>
        {
            entity.IsDeleted = true;
            entity.UpdateTime = DateTime.Now;
            entity.UpdateUserID = updateUserID;

            Set<TEntity>().Update(entity);

            SaveChanges();
        }

        public void DeleteAll<TEntity, TKey>(List<TEntity> lstEntity, int updateUserID)
            where TEntity : EntityBase<TKey>
        {
            lstEntity.ForEach(entity =>
            {
                entity.IsDeleted = true;
                entity.UpdateTime = DateTime.Now;
                entity.UpdateUserID = updateUserID;

                Set<TEntity>().Update(entity);
            });

            SaveChanges();
        }

        #endregion

        #region Account

        public DbSet<User> User { get; set; }

        public DbSet<Permission> Permission { get; set; }

        public DbSet<UserPermission> UserPermission { get; set; }

        #endregion

        #region Config

        public DbSet<ConfigApp> ConfigApp { get; set; }

        public DbSet<ConfigEnvironment> ConfigEnvironment { get; set; }

        public DbSet<ConfigAppEnvironment> ConfigAppEnvironment { get; set; }

        public DbSet<ConfigItem> ConfigItem { get; set; }

        public DbSet<ConfigItemSniffer> ConfigItemSniffer { get; set; }

        #endregion
    }
}
