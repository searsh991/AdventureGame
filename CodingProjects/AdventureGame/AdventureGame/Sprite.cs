class Sprite
{
    public string characterName {get;set;}    
    public int health{get;set;}
    public int maxHealth{get; set;} = 10;
    public int damage{get; set;}
    public int maxDamage{get;set;} =10;

    public bool isDead()
    {
        return false;
    }

    public int takeDamage(int damageDealt)
    {
        return 0;
    }

    public int heal(int healthDealt)
    {
        return 0;
    }
}