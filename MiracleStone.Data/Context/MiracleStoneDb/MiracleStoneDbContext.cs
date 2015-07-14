
using MiracleStone.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;


namespace MiracleStone.Data.Context
{
    public class MiracleStoneDbContext : DbContext, IUnitOfWork
    {
        public DbSet<TblUser> TblUser { get; set; }
        public DbSet<TblCategories> TblCategories { get; set; }
        public DbSet<TblCompanyInfo> TblCompanyInfo { get; set; }
        public DbSet<TblContactUs> TblContactUs { get; set; }
        public DbSet<TblImage> TblImage { get; set; }
        public DbSet<TblProduct> TblProduct { get; set; }
        public DbSet<TblProjects> TblProjects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        
            base.OnModelCreating(modelBuilder);
        }
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException validationException)
            {
                foreach (var error in validationException.EntityValidationErrors)
                {
                    var entry = error.Entry;
                    foreach (var err in error.ValidationErrors)
                    {
                        Debug.WriteLine(err.PropertyName + " " + err.ErrorMessage);
                    }
                }
                return -1;
            }
            catch (DbUpdateConcurrencyException concurrencyException)
            {
                foreach (var entry in concurrencyException.Entries)
                {
                    Debug.WriteLine(entry.Entity);
                }
                return -1;
            }
            catch (DbUpdateException updateException)
            {
                if (updateException.InnerException != null)
                    Debug.WriteLine(updateException.InnerException.Message);
                foreach (var entry in updateException.Entries)
                {
                    Debug.WriteLine(entry.Entity);
                }
                return -1;
            }
        }
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            return base.Entry<TEntity>(entity);
        }
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
        
    }
}
