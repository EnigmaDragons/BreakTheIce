public class Runner
{
    public int Money;
    public int MaxHP;
    public int BrainDamage;
    public int Hp;
    
    public Runner(int hp, int money = 0)
    {
        MaxHP = hp;
        BrainDamage = 0;
        Hp = hp;
        Money = money;
    }
}
