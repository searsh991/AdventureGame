public class Fighter
{
    public int att;
    public int def;
    public int spe;
    public int hp;
    public string Wtype;
    public string weakness;
    public bool wasChoosen = false;
    public bool isAlive => hp>0;
    public bool autoTeam;
    public string name;

    public bool defenceLowered = false;

    public Fighter(string Wtype)
    {
        this.Wtype = Wtype;
        getStats();
    }


    public void getStats()
    {
        Random myRan = new Random();
        if(this.Wtype == "Thor")
        {
            this.hp = myRan.Next(90, 101);
            this.att = myRan.Next(60, 71);
            this.def = myRan.Next(20, 41);
            this.spe = myRan.Next(10, 31);
            this.weakness = "HawkEye";
        }else if(this.Wtype == "SpiderMan")
        {
            this.hp = myRan.Next(100, 111);
            this.att = myRan.Next(50, 66);
            this.def = myRan.Next(10, 26);
            this.spe = myRan.Next(29, 51);
            this.weakness = "Thor";
        }
        else
        {
            this.hp = myRan.Next(85, 96);
            this.att = myRan.Next(60, 71);
            this.def = myRan.Next(10, 26);
            this.spe = myRan.Next(25, 41);
            this.weakness = "SpiderMan";
        }
    }

    public string LoweredDefence()
    {
        string text = "";
        if (this.def>10)
        {
            this.def = this.def - 10;
            text += $"Defence is lowered by 10, defence is now{this.def}";
            return text;
        }
        else
        {
            this.def = 0;
            text +=$"Defence is lowered by 10, defence is now{this.def}";
            return text;
        }
    }
    public void TakeAttack(Fighter attacker)
    {
        bool PlayerDied;
        
        if(this.weakness == attacker.Wtype && this.defenceLowered)
        {
           this.def = this.def - 10;
           Console.WriteLine($"\n{this.Wtype} is weak to {attacker.Wtype}. {this.LoweredDefence()}");
           
        }
        this.hp = this.hp -(attacker.att - this.def);
        if(this.hp >0)
        {
            Console.WriteLine($"\n{this.Wtype} has taken attack damage of {attacker.att - this.def}, hp is now {this.hp}\n");
        }
        else if (this.hp<= 0)
        {   
            Console.WriteLine($"\n{this.Wtype} has taken attack damage of {attacker.att - this.def}, {this.Wtype} has died\n");
            System.Console.WriteLine($"{this.Wtype} is dead");
            System.Console.WriteLine($"{attacker.Wtype} stays on");
        }



        //add if health here 

    }


}  