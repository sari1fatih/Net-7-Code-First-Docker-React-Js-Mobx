using Common.Enums;
using Common.Enums.EntityGroup;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Persistence.Generate;
using RealEstate.Domain.Entities;

namespace Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Entity> Entities { get; set; }
        public DbSet<EntityGroup> EntityGroups { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPhoto> ProductPhotos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Seed Data
            modelBuilder.Entity<EntityGroup>()
                .HasData(
                    new EntityGroup()
                    {
                        id = (short)EntityGroupEnum.PropertyType,
                        value = "Emlak Tipi"
                    },
                    new EntityGroup()
                    {
                        id = (short)EntityGroupEnum.FurnitureCondition,
                        value = "Eşya Durumu"
                    },
                    new EntityGroup()
                    {
                        id = (short)EntityGroupEnum.NumberOfRooms,
                        value = "Oda Sayısı"
                    },
                    new EntityGroup()
                    {
                        id = (short)EntityGroupEnum.FloorLevel,
                        value = "Bulunduğu Kat"
                    },
                    new EntityGroup()
                    {
                        id = (short)EntityGroupEnum.BuildingAge,
                        value = "Bina Yaşı"
                    }
            );

            modelBuilder.Entity<Entity>()
                .HasData(
                    new Entity()
                    {
                        id = (short)PropertyTypeEnum.Sale,
                        entityGroupId = (short)EntityGroupEnum.PropertyType,
                        value = "Satılık"
                    },
                    new Entity()
                    {
                        id = (short)PropertyTypeEnum.Rent,
                        entityGroupId = (short)EntityGroupEnum.PropertyType,
                        value = "Kiralık"
                    },
                    new Entity()
                    {
                        id = (short)PropertyTypeEnum.Daily,
                        entityGroupId = (short)EntityGroupEnum.PropertyType,
                        value = "Günlük"
                    },
                    new Entity()
                    {
                        id = (short)FurnitureConditionEnum.Furnished,
                        entityGroupId = (short)EntityGroupEnum.FurnitureCondition,
                        value = "Eşyalı"
                    },
                    new Entity()
                    {
                        id = (short)FurnitureConditionEnum.Unfurnished,
                        entityGroupId = (short)EntityGroupEnum.FurnitureCondition,
                        value = "Eşyasız"
                    },
                    new Entity()
                    {
                        id = (short)NumberOfRoomsEnum.OnePlusZero,
                        entityGroupId = (short)EntityGroupEnum.NumberOfRooms,
                        value = "1 + 0"
                    },
                    new Entity()
                    {
                        id = (short)NumberOfRoomsEnum.OnePlusOne,
                        entityGroupId = (short)EntityGroupEnum.NumberOfRooms,
                        value = "1 + 1"
                    },
                    new Entity()
                    {
                        id = (short)NumberOfRoomsEnum.TwoPlusOne,
                        entityGroupId = (short)EntityGroupEnum.NumberOfRooms,
                        value = "2 + 1"
                    },
                    new Entity()
                    {
                        id = (short)NumberOfRoomsEnum.ThreePlusOne,
                        entityGroupId = (short)EntityGroupEnum.NumberOfRooms,
                        value = "3 + 1"
                    },
                    new Entity()
                    {
                        id = (short)NumberOfRoomsEnum.ThreePlusTwo,
                        entityGroupId = (short)EntityGroupEnum.NumberOfRooms,
                        value = "3 + 2"
                    },
                    new Entity()
                    {
                        id = (short)NumberOfRoomsEnum.FourPlusTwo,
                        entityGroupId = (short)EntityGroupEnum.NumberOfRooms,
                        value = "4 + 2"
                    },
                    new Entity()
                    {
                        id = (short)FloorLevelEnum.GardenFloor,
                        entityGroupId = (short)EntityGroupEnum.FloorLevel,
                        value = "Bahçe Katı"
                    },
                    new Entity()
                    {
                        id = (short)FloorLevelEnum.EntranceFloor,
                        entityGroupId = (short)EntityGroupEnum.FloorLevel,
                        value = "Giriş Katı"
                    },
                    new Entity()
                    {
                        id = (short)FloorLevelEnum.FirstFloor,
                        entityGroupId = (short)EntityGroupEnum.FloorLevel,
                        value = "1. Kat"
                    },
                    new Entity()
                    {
                        id = (short)FloorLevelEnum.SecondFloor,
                        entityGroupId = (short)EntityGroupEnum.FloorLevel,
                        value = "2. Kat"
                    },
                    new Entity()
                    {
                        id = (short)FloorLevelEnum.ThirdFloor,
                        entityGroupId = (short)EntityGroupEnum.FloorLevel,
                        value = "3. Kat"
                    },
                    new Entity()
                    {
                        id = (short)FloorLevelEnum.FourthFloor,
                        entityGroupId = (short)EntityGroupEnum.FloorLevel,
                        value = "4. Kat"
                    },
                    new Entity()
                    {
                        id = (short)FloorLevelEnum.FifthFloor,
                        entityGroupId = (short)EntityGroupEnum.FloorLevel,
                        value = "5. Kat"
                    },
                    new Entity()
                    {
                        id = (short)BuildingAgeEnum.BuildingAgeZero,
                        entityGroupId = (short)EntityGroupEnum.BuildingAge,
                        value = "0"
                    },
                    new Entity()
                    {
                        id = (short)BuildingAgeEnum.BuildingAgeOne,
                        entityGroupId = (short)EntityGroupEnum.BuildingAge,
                        value = "1"
                    },
                    new Entity()
                    {
                        id = (short)BuildingAgeEnum.BuildingAgeTwo,
                        entityGroupId = (short)EntityGroupEnum.BuildingAge,
                        value = "2"
                    },
                    new Entity()
                    {
                        id = (short)BuildingAgeEnum.BuildingAgeThree,
                        entityGroupId = (short)EntityGroupEnum.BuildingAge,
                        value = "3"
                    },
                    new Entity()
                    {
                        id = (short)BuildingAgeEnum.BuildingAgeFour,
                        entityGroupId = (short)EntityGroupEnum.BuildingAge,
                        value = "4"
                    },
                    new Entity()
                    {
                        id = (short)BuildingAgeEnum.BuildingAgeFive,
                        entityGroupId = (short)EntityGroupEnum.BuildingAge,
                        value = "5"
                    },
                    new Entity()
                    {
                        id = (short)BuildingAgeEnum.BuildingAgeFromFiveToTen,
                        entityGroupId = (short)EntityGroupEnum.BuildingAge,
                        value = "5 - 10"
                    },
                    new Entity()
                    {
                        id = (short)BuildingAgeEnum.BuildingAgeFromTenToFifteen,
                        entityGroupId = (short)EntityGroupEnum.BuildingAge,
                        value = "10 - 15"
                    },
                    new Entity()
                    {
                        id = (short)BuildingAgeEnum.BuildingAgeFromFifteenToTwenty,
                        entityGroupId = (short)EntityGroupEnum.BuildingAge,
                        value = "15 - 20"
                    },
                    new Entity()
                    {
                        id = (short)BuildingAgeEnum.BuildingAgePlusTwenty,
                        entityGroupId = (short)EntityGroupEnum.BuildingAge,
                        value = " > 20"
                    }
              );
            modelBuilder.Entity<Product>()
                   .HasData(
                      RandomGenerate.GenerateRandomProductList()
                 );

            modelBuilder.Entity<ProductPhoto>()
                  .HasData(
                      RandomGenerate.GenerateRandomProductPhotoList()
                );

            #endregion

            modelBuilder.Entity<ProductPhoto>()
               .HasOne(c => c.product)
               .WithMany(d => d.productPhoto);

            modelBuilder.Entity<Entity>()
               .HasOne(c => c.entityGroup)
               .WithMany(d => d.entity);

            modelBuilder.Entity<Product>()
               .HasOne(c => c.propertyTypeEntity)
               .WithMany(d => d.propertyTypeEntity);

            modelBuilder.Entity<Product>()
               .HasOne(c => c.furnitureConditionEntity)
               .WithMany(d => d.furnitureConditionEntity);

            modelBuilder.Entity<Product>()
              .HasOne(c => c.numberOfRoomsEntity)
              .WithMany(d => d.numberOfRoomsEntity);

            modelBuilder.Entity<Product>()
              .HasOne(c => c.floorLevelEntity)
              .WithMany(d => d.floorLevelEntity);

            modelBuilder.Entity<Product>()
              .HasOne(c => c.buildingAgeEntity)
              .WithMany(d => d.buildingAgeEntity);
        }

    }
}

