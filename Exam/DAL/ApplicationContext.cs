using DAL.Model;
using Microsoft.EntityFrameworkCore;
public class ApplicationContext : DbContext
{
    public DbSet<Player> Players { get; set; } = null!;
    public DbSet<Monster> Monsters { get; set; } = null!;
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
        Database.EnsureCreated();   // создаем базу данных при первом обращении
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Random rnd = new Random();

        List<Monster> mobs = new List<Monster>()
        {
             new Monster
                {
                    Id = Guid.NewGuid(),
                    MonsterName = "ShadowAssasin",
                    HitPoints = rnd.Next(40,150),
                    AttackModifiere = rnd.Next(10,40),
                    AttackPerRound = rnd.Next(1,6),
                    Damage = rnd.Next(1,6),
                    DamageModifiere = rnd.Next(1,6),
                    Weapon = rnd.Next(1,6),
                    ArmorClass = rnd.Next(1,30),
                    MinAC =  10,
                    DamagePerRound = 10,
                },
             new Monster
                {
                    Id = Guid.NewGuid(),
                    MonsterName = "Dragonsoul",
                    HitPoints = rnd.Next(40,150),
                    AttackModifiere = rnd.Next(10,40),
                    AttackPerRound = rnd.Next(1,6),
                    Damage = rnd.Next(1,6),
                    DamageModifiere = rnd.Next(1,6),
                    Weapon = rnd.Next(1,6),
                    ArmorClass = rnd.Next(1,30),
                    MinAC =  10,
                    DamagePerRound = 10,
                },
             new Monster
                {
                    Id = Guid.NewGuid(),
                    MonsterName = "Revenant",
                    HitPoints = rnd.Next(40,150),
                    AttackModifiere = rnd.Next(10,40),
                    AttackPerRound = rnd.Next(1,6),
                    Damage = rnd.Next(1,6),
                    DamageModifiere = rnd.Next(1,6),
                    Weapon = rnd.Next(1,6),
                    ArmorClass = rnd.Next(1,30),
                    MinAC =  10,
                    DamagePerRound = 10,
                }
        };
        modelBuilder.Entity<Monster>().HasData(mobs);
    }
}