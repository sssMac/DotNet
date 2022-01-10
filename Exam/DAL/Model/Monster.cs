namespace DAL.Model
{
    public class Monster
    {
        public Guid Id { get; set; }
        public string MonsterName { get; set; }
        public int HitPoints { get; set; }
        public int AttackModifiere { get; set; }
        public int AttackPerRound { get; set; }
        public int Damage { get; set; }
        public int DamageModifiere { get; set; }
        public int Weapon { get; set; }
        public int ArmorClass { get; set; }
        public int MinAC { get; set; }
        public int DamagePerRound { get; set; }

    }
}
