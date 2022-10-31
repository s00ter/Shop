using Core;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Extensions;

public static class ModelBuilderExtensions
{
    private const string AdminRoleId = "5308d50d-775c-4b13-be96-0915605d59ca";
    private const string CourierRoleId = "78590424-271b-4ac9-b33a-0dcdd02e3a82";

    private const string AdminUserId = "25bbb18b-5c7b-4e74-ae67-96a3a9ce5880";

    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder
            .UserSeed()
            .RoleSeed()
            .UserRoleSeed()
            .ShopSeed()
            .CustomerSeed();
    }

    private static ModelBuilder CustomerSeed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasData(new List<Customer>
        {
            new()
            {
                Id = 1,
                Address = "Пушкина д. 14",
                Name = "Иванов Иван Иванович",
            }
        });

        return modelBuilder;
    }
    
    private static ModelBuilder UserRoleSeed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            UserId = AdminUserId,
            RoleId = AdminRoleId
        });

        return modelBuilder;
    }
    
    private static ModelBuilder UserSeed(this ModelBuilder modelBuilder)
    {
        var admin = new IdentityUser
        {
            Id = AdminUserId,
            UserName = DefaultAdminConstants.UserName,
            NormalizedUserName = DefaultAdminConstants.UserName.ToUpper()
        };
        admin.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(admin, DefaultAdminConstants.Password);

        modelBuilder.Entity<IdentityUser>().HasData(admin);

        return modelBuilder;
    }
    
    private static ModelBuilder RoleSeed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityRole>()
            .HasData(new List<IdentityRole>
            {
                new()
                {
                    Id = AdminRoleId,
                    Name = RoleConstants.Admin, 
                    NormalizedName = RoleConstants.Admin.ToUpper()
                },
                new()
                {
                    Id = CourierRoleId,
                    Name = RoleConstants.Courier,
                    NormalizedName = RoleConstants.Courier.ToUpper()
                }
            });

        return modelBuilder;
    }
    
    private static ModelBuilder ShopSeed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Shop>()
            .HasData(new List<Shop>
            {
                new()
                {
                    Id = 1,
                    Address = "Пушкина д. 2",
                    Name = "Пятёрочка"
                },
                new()
                {
                    Id = 2,
                    Address = "Пушкина д. 3",
                    Name = "Четверочка"
                },
                new()
                {
                    Id = 1,
                    Address = "Пушкина д. 4",
                    Name = "Троечка"
                }
            });

        return modelBuilder;
    }
}