using HostLocal.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HostLocal.API.Data;

public class AppDbContext : IdentityDbContext<Usuario>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        SeedUsuarioPadrao(builder);
        SeedCategoriaPadrao(builder);
        SeedProdutoPadrao(builder);
    }

    private static void SeedUsuarioPadrao(ModelBuilder builder)
    {
        #region Populate Roles - Perfis de Usuário
        List<IdentityRole> roles =
        [
            new IdentityRole() {
               Id = "0b44ca04-f6b0-4a8f-a953-1f2330d30894",
               Name = "Administrador",
               NormalizedName = "ADMINISTRADOR"
            },
            new IdentityRole() {
               Id = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
               Name = "Cliente",
               NormalizedName = "CLIENTE"
            },
        ];
        builder.Entity<IdentityRole>().HasData(roles);
        #endregion

        #region Populate Usuário
        List<Usuario> usuarios = [
            new Usuario(){
                Id = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
                Email = "andreluiz@email.com",
                NormalizedEmail = "ANDRELUIZ@EMAIL.COM",
                UserName = "andreluiz@email.com",
                NormalizedUserName = "ANDRELUIZ@EMAIL.COM",
                LockoutEnabled = true,
                EmailConfirmed = true,
                Nome = "Lucas Theodosio",
                DataNascimento = DateTime.Parse("04/01/2001"),
                Foto = "/img/usuarios/avatar.png"
            }
        ];
        foreach (var user in usuarios)
        {
            PasswordHasher<Usuario> pass = new();
            user.PasswordHash = pass.HashPassword(user, "123456");
        }
        builder.Entity<Usuario>().HasData(usuarios);
        #endregion

        #region Populate UserRole - Usuário com Perfil
        List<IdentityUserRole<string>> userRoles =
        [
            new IdentityUserRole<string>() {
                UserId = usuarios[0].Id,
                RoleId = roles[0].Id
            }
        ];
        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        #endregion
    }

    private static void SeedCategoriaPadrao(ModelBuilder builder)
    {
        List<Categoria> categorias = new()
        {
            new Categoria { Id = 1, Nome = "Headset" },
            new Categoria { Id = 2, Nome = "Monitor" },
            new Categoria { Id = 3, Nome = "Mouse" },
            new Categoria { Id = 4, Nome = "Teclado" },
        };
        builder.Entity<Categoria>().HasData(categorias);
    }

    private static void SeedProdutoPadrao(ModelBuilder builder)
    {
        List<Produto> produtos = new()
        {
            new Produto { Id = 1, CategoriaId = 1, Nome = "", Descricao = "", ValorCusto = 699.00m,  Qtde = 10, Foto = "/img/produtos/fone.1.png" },
            new Produto { Id = 2, CategoriaId = 1, Nome = "", Descricao = "", ValorCusto = 799.00m,  Qtde = 15, Foto = "/img/produtos/fone.2.png" },
            new Produto { Id = 3, CategoriaId = 2, Nome = "", Descricao = "", ValorCusto = 529.00m,  Qtde = 20, Foto = "/img/produtos/monitor.1.png" },
            new Produto { Id = 4, CategoriaId = 2, Nome = "", Descricao = "", ValorCusto = 479.00m,  Qtde = 12,  Foto = "/img/produtos/monitor.2.png" },
            new Produto { Id = 5, CategoriaId = 3, Nome = "", Descricao = "", ValorCusto = 300.00m,  Qtde = 8, Foto = "/img/produtos/mouse.1.png" },
            new Produto { Id = 6, CategoriaId = 3, Nome = "", Descricao = "", ValorCusto = 400.00m,  Qtde = 8,  Foto = "/img/produtos/mouse.2.png" },
            new Produto { Id = 7, CategoriaId = 4, Nome = "", Descricao = "", ValorCusto = 469.00m,  Qtde = 8,  Foto = "/img/produtos/teclado.1.png" },
            new Produto { Id = 8, CategoriaId = 4, Nome = "", Descricao = "", ValorCusto = 349.00m,  Qtde = 8, Foto = "/img/produtos/teclado.2.png" },
        };
        builder.Entity<Produto>().HasData(produtos);
    }

}