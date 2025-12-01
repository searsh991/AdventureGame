

using System.Globalization;
using System.Reflection.Metadata;
using System.Security;
using System.Security.Cryptography.X509Certificates;

// TODO need ot asign each one a generated name so whe can keep track of each fighter 
// TODO make a battle class that keeps a list of the fighters on both teanms 
//TODO switch the players and make next rounf battle 
namespace fighting
{
    public class CodingChallengeProgram
    {

    //     public static void Main (String [] args)
    //     {
    //         Fighter[] myTeam = new Fighter[5];
    //         Fighter[] OtherTeam = new Fighter[5];

    //         Intro();
    //         myTeam = PickTeam(myTeam);
    //         OtherTeam = AutoTeam(OtherTeam);
    //         GeneralFight(myTeam, OtherTeam);
    //     }

        public static void GeneralFight(Fighter[] myTeam, Fighter[] OtherTeam)
        {

            Fighter myPlayer = getPlayer(myTeam);
            Fighter otherPlayer = getPlayer(OtherTeam);
            


            while(IsAlive(myTeam) && IsAlive(OtherTeam))
            {
                Fighter continuingFighter = InitiateBattle(myPlayer, otherPlayer);
                Fighter[] NextTeam = NextPlayerTeam(continuingFighter, myTeam, OtherTeam);
                Fight(continuingFighter, getPlayer(NextTeam));
            }
        
        
            
            
        //     while (playing)
        //     {


        //     if(myPlayer.spe > otherPlayer.spe)
        //     {
        //         //battle 
        //         while (myPlayer.isAlive == true && otherPlayer.isAlive == true)
        //         {
        //             bool playerDied = myPlayer.TakeAttack(otherPlayer);
        //             if(otherPlayer.hp > 0)
        //             {
        //                 playerDied = otherPlayer.TakeAttack(myPlayer);
        //             }
        //             if(playerDied = true)
        //                 {
                            
        //                 }
        //     }
        //     }
        //     else
        //     {
        //         while (otherPlayer.hp > 0 && myPlayer.hp > 0)
        //         {
        //             otherPlayer.TakeAttack(myPlayer);
        //             if(myPlayer.hp > 0)
        //             {
        //                 myPlayer.TakeAttack(otherPlayer);
        //             }
        //         }
        //     }
        // }

            // Console.WriteLine("my player");
            // PrintStats(myPlayer);
            // Console.WriteLine("Other player");
            // PrintStats(otherPlayer);

        }

        private static Fighter[] NextPlayerTeam(Fighter continuingFighter, Fighter[] myTeam, Fighter[] otherTeam)
        {
            if(continuingFighter.autoTeam == true)
            {
                return myTeam;
            }
            else
            {
                return otherTeam;
            }
        }

        public static void Intro()
        {
            Console.WriteLine("HELLO -- GAME STARTING --");
        }


        public static Fighter[] PickTeam(Fighter[] Team)
        {
            bool autoTeam = false;
            int teamNum = 0;  
            Console.WriteLine("Thor: A GREAT SWORD\nSpiderMan: CUNNING AND AGILE\nHawkEye: THE RANGE\nPlease Pick Your Team (input there number)");
            while(teamNum != 5)
            {
                // int choosenWarrior = Convert.ToInt32(Console.ReadLine());
                int choosenWarrior = getValidNum();
                Team = createTeam(Team, choosenWarrior, teamNum, autoTeam);
                teamNum++;
            }
            return Team;
        }
        public static Fighter[] createTeam(Fighter[] Team, int choosenWarrior, int teamNum, bool autoTeam)
        {
                if(choosenWarrior == 1)
                {
                    Team[teamNum] = new Fighter("Thor");
                    Team[teamNum].Wtype = "Thor";
                    Team[teamNum].autoTeam = false;
                    PrintStats(Team[teamNum]);
                    // teamNum++;
                }else if(choosenWarrior == 2)
                {
                    Team[teamNum] = new Fighter("SpiderMan");
                    Team[teamNum].Wtype = "SpiderMan";
                    Team[teamNum].autoTeam = false;
                    PrintStats(Team[teamNum]);
                    // teamNum++;
                }
                else if(choosenWarrior == 3)
                {
                    Team[teamNum] = new Fighter("HawkEye");
                    Team[teamNum].Wtype = "HawkEye";
                    Team[teamNum].autoTeam = false;
                    PrintStats(Team[teamNum]);
                    // teamNum++;
                }
            return Team;
        }

        public static int getValidNum()
        {
            while (true)
            {
            string userInput = Console.ReadLine();
            if (userInput.All(char.IsDigit)){
               int num = Int32.Parse(userInput);
                if(num < 4 && num > 0)
                {
                    return num;
                }
            }
            Console.WriteLine("Invalid input");
            }
        }
        public static void PrintStats(Fighter fighter)
        {  
            Console.WriteLine("Name: " + fighter.Wtype);
            Console.WriteLine("Attack Points: " + fighter.att);
            Console.WriteLine("Defence Points: " + fighter.def);
            Console.WriteLine("Health Points: " + fighter.hp);
            Console.WriteLine("Speed Points: " + fighter.spe);
            Console.WriteLine("Weakness: " + fighter.weakness);
        }

        public static Fighter[] AutoTeam(Fighter[] OtherTeam)
        {
            bool isAuto = true;
            Random random = new Random();
            int num = 0;
            while(num != 5)
            {
                int badTeamFighter = random.Next(1,4);
                OtherTeam = createTeam(OtherTeam, badTeamFighter, num, isAuto);
                num++;
            }
            return OtherTeam;
        }
              public static Fighter getPlayer(Fighter[] team)
        {
            Random random1 = new Random();
            int playerIndex = random1.Next(0, 4);
            while (team[playerIndex].wasChoosen == true)
            {
                playerIndex = random1.Next(0, 4);
            }
                team[playerIndex].wasChoosen = true;

            return team[playerIndex];
           
        }

        // Returns the fight method in the correct order 
        public static Fighter InitiateBattle(Fighter myPlayer, Fighter otherPlayer)
        {
            if(myPlayer.spe > otherPlayer.spe)
            {
                return Fight(myPlayer, otherPlayer);
            }
            else
            {
                return Fight(otherPlayer, myPlayer);
            }
        }

        public static Fighter Fight(Fighter attackFirst, Fighter defendFirst)
        {
            while(attackFirst.isAlive && defendFirst.isAlive)
            {
                defendFirst.TakeAttack(attackFirst);
                if(defendFirst.isAlive == false)
                {

                    return attackFirst;
      
                }
                attackFirst.TakeAttack(defendFirst);
                if(attackFirst.isAlive == false)
                {
                    return defendFirst;
                }      
            }
            if (attackFirst.isAlive)
            {
                return attackFirst;
            }
            else
            {
                return defendFirst;
            }
        }
        public bool PlayerDead(Fighter player1, Fighter player2){

            if (player1.isAlive==false || player2.isAlive == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsAlive(Fighter[] team)
        {
            for(int i=0; i < team.Length; i++)
            {
                if (team[i].isAlive)
                {
                    return true;
                }
            }
            return false;
        }
    }
}





