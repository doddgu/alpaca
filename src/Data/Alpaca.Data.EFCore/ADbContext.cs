using Alpaca.Data.Entities;
using Alpaca.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Alpaca.Data.EFCore
{
    public class ADbContext : DbContext
    {
        private string _connectionString = null;

        protected ADbContext(string connectionString)
        {
            _connectionString = connectionString;
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

        #region CRUD

        public TEntity Add<TEntity, TKey>(TEntity entity, int updateUserID)
            where TEntity : EntityBase<TKey>
        {
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

        #endregion

        #region Account

        public DbSet<User> User { get; set; }

        #endregion

        #region Config

        public DbSet<ConfigApp> ConfigApp { get; set; }

        public DbSet<ConfigEnvironment> ConfigEnvironment { get; set; }

        public DbSet<ConfigAppEnvironment> ConfigAppEnvironment { get; set; }

        public DbSet<ConfigDispatch> ConfigDispatch { get; set; }

        public DbSet<ConfigItem> ConfigItem { get; set; }

        public DbSet<ConfigItemSniffer> ConfigItemSniffer { get; set; }

        #endregion
    }
}
