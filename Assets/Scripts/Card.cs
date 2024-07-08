public class Card
{
    public int id;
    public string cardName;
    public Card(int _id,string _cardName)
    {
        this.id = _id;
        this.cardName = _cardName;
    }
}
public class CharacterCard:Card
{
    public int health;
    public int healthMax;
    public int erosion;
    public int lucky;
    public string skill;
    public CharacterCard(int _id,string _cardName, int _healthMax, int _erosion, int _lucky,string _skill):base(_id,_cardName)
    {
        this.health = _healthMax;
        this.healthMax = _healthMax;
        this.erosion = _erosion;
        this.lucky = _lucky;
        this.skill = _skill;
    }
}
public class BasicActionCard : Card
{
    public int damage;
    public int defense;
    public BasicActionCard(int _id,string _cardName,int _damage, int _defense):base(_id,_cardName) 
    {
        this.damage = _damage;
        this.defense = _defense;
    }
}
public class EffectCard:Card
{
    public string effect;
    public int erosionAccumulation;
    public EffectCard(int _id,string _cardName,string _effect,int erosionAccumulation):base(_id,_cardName) 
    {
        this.effect = _effect;
        this.erosionAccumulation = erosionAccumulation;
    }
}