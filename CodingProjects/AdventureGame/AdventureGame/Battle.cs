class Battle
{
    private List<Fighter> playerTeam;
    private List<Fighter> autoTeam;
    public static Random random = new Random();

    public Battle(List<Fighter> playerTeam)
    {
        this.playerTeam = playerTeam;
    }
    public static void RunBattle()
    {
        //get auto team player 
        //while both teams have alive fighters 
        //get random alive figher 
        //initiate battle 
            //fight
    }
    public static Fighter InitiateBattle(Fighter a, Fighter b)
    {
        if (a.spe > b.spe)
        {
            return Fight(a,b);
        }
        else if (b.spe > a.spe)
        {
            return Fight(a,b);
        }
        else
        {
            int randomIndex = random.Next(1);
            if(randomIndex == 0)
            {
                return Fight(a,b);
            }
            else
            {
                return Fight(b,a);
            }
        }
    }
    public static Fighter Fight(Fighter attacker, Fighter defender)
    {
        Fighter currentMyFighter = GetRandomAliveFighter()
    }
    public static Fighter GetRandomAliveFighter(List<Fighter> team)
    {
        //basically a for each that makes a new list of those that are alive
        List<Fighter> alive = team.Where(f=> f.isAlive).ToList();
        Fighter chosenFighter = alive[random.Next(alive.Count)];
        if(alive.Count == 0)
        {
            return null;
        }
        return chosenFighter;
    }
    public static bool TeamHasAlive(List<Fighter> team)
    {
        foreach(Fighter fighter in team)
        {
            if (fighter.isAlive)
            {
                return true;
            }
        }
        return false;
    }
}