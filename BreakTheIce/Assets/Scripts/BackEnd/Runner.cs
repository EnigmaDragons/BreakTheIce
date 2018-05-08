public class Runner
{
    public int Money { get; private set; }
    public int MaxHP { get; private set; }
    public int Hp { get; private set; }
    public int BrainDamage { get; private set; }
    public int Tags { get; private set; }
    
    public Runner(int hp, int money = 0)
    {
        Money = money;
        MaxHP = hp;
        Hp = hp;
        BrainDamage = 0;
        Tags = 0;
    }
}
