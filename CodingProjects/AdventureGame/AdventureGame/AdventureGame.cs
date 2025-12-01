
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text.RegularExpressions;


/** 
*TODO - Make menu with mini games inside. 
- Initially the user gets asked if they want to play, if the answer it yes Play. to quit the game type :q which should end the loop 
- step 1: generate ur avatar 
    - Get superhero name 
    - Get random health 
    - Get random damage percentage
    - Max you can ever have is ten, initially 1-7 for both health and damage
- Sub Menu 
    - Get avatar info 
    - Play higher or lower = if win get 0-1 health, if lose lose 0-1 health
  *!  - Play seans hit game 
    - Answer maths questions 
    - Battle Monster 
        -   Generate monster wth random damage and health 
        - either let them attack you first and if you dont die you win or you attack them first and if you dont kill them you lose

*TODO Change words to attack points and defend points 
    - Colour planning 
    - General Instructions = Yellow 
    - Action Instruction = Blue 
    - Player Information = Green 
    - Menu = different for each  
    - Health and damage declaratuion = red 
    - Win = background green 
    - Lost = background red 

    Incorporating team battle
    when you start you generate a team and you go through the mini games to add to their points. 
    Battle means the battle against auto team is generated 
    *TODO Add names to each player , A for auto team and M for my team 
    *TODO change arrays to lists for teams 

**/
class AdventureGame
{
    Random randomNum= new Random();
    Player player;
    Monster monster;
    HigherOrLower higherOrLower;
    bool isRunning {get; set;} = true;
    List<string> autoTeamNames = LoadNames("./resources/fighter_names_A.txt");

    public static void Main(string[] args)
    {
        AdventureGame game = new AdventureGame();
        game.Play();

    }
    public void Play()
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("\n******CRASH******");
        Thread.Sleep(1000);
        Console.WriteLine("******BANG*******");
        Thread.Sleep(1000);
        Console.WriteLine("******CLANG******\n");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Yellow;
        List<Fighter> myTeam = new List<Fighter>{};
        List<Fighter> otherTeam =new List<Fighter>{};

    
        //generate name and points 
        // typeSlowly("\nWhenever someone new lands on Mopia the planets gods randomly allocate you and the monster a random number of attack an defence points\n");

        // System.Console.WriteLine("To get more health points you can play a maximum of 2 games of higher and lower");
        // System.Console.WriteLine("To get more damage points you can play a maximum of 2 games of Russian Roulette");
        // System.Console.WriteLine("Once you are happy with your attack and damage points you must go and battle the monster");
        System.Console.WriteLine("Good Luck");

        GameInfo();
        MakePlayer();
        myTeam = PickTeam(myTeam);
        //otherTeam = AutoTeam(otherTeam);
        while(isRunning){
            Menu();
        }
        

    }

    private void GameInfo()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        TypeSlowly("\nWELCOME TO BATTLE IT OUT\n");
        TypeSlowly("\nYou have just landed on a foreign planet called Mopia where the only way to escape is to beat the planets team of resident MONSTERRRRRRRSSS\n");
        TypeSlowly("\nYou will generate a player who will work through a number of mini games to earn points");
        TypeSlowly("\nOnce you are happy with your points you will generate a team of fighters to battle the team of monsters");
        TypeSlowly("\nThen you can use the points you earnt to level up your team");
    }

    public void MakePlayer()
    {
        player = new Player();
        Console.ForegroundColor = ConsoleColor.Yellow;
        TypeSlowly("\nBefore we start I neded to know what to call you\n");
        Console.ForegroundColor = ConsoleColor.Blue;
        System.Console.WriteLine("\nINPUT YOUR NAME HERE\n");
        player.characterName = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        TypeSlowly($"\nNice to meet you agent {player.characterName}\n");
        TypeSlowly($"\nLets see how lucky you are agent {player.characterName}\n");
        
        player.health = randomNum.Next(1,8);
        TypeSlowly($"\nYou received {player.health} health points\n");

    }

     public static List<Fighter> PickTeam(List<Fighter> Team)
        {
            bool autoTeam = false;
            int teamNum = 0;  
            TypeSlowly("There are three different types of fighters to choose from");
            Console.WriteLine("\nType 1 for Thor: A GREAT SWORD\nType 2 for SpiderMan: CUNNING AND AGILE\nType 3 for HawkEye: THE RANGE\nPlease Pick Your Team (input number now )");
            while(Team.Count != 5)
            {
                // int choosenWarrior = Convert.ToInt32(Console.ReadLine());
                int choosenWarrior = getValidNum();
                Team = createTeam(Team, choosenWarrior, teamNum, autoTeam);
                teamNum++;
            }
            return Team;
        }

         public static List<Fighter> createTeam(List<Fighter> Team, int choosenWarrior, int teamNum, bool autoTeam)
        {

            List<string> playerTeamNames = LoadNames("./resources/fighter_names_M.txt");
            
                if(choosenWarrior == 1)
                {
                    Fighter fighter = new Fighter("Thor");
                    fighter.name = GetUniqueName(playerTeamNames);
                    fighter.autoTeam = autoTeam;
                    Team.Add(fighter);
                    PrintStats(fighter);
                    // teamNum++;
                }else if(choosenWarrior == 2)
                {
                    Fighter fighter = new Fighter("SpiderMan");
                    fighter.autoTeam = autoTeam;
                    fighter.name = GetUniqueName(playerTeamNames);
                    Team.Add(fighter);
                    PrintStats(fighter);
                    // teamNum++;
                }
                else if(choosenWarrior == 3)
                {
                    Fighter fighter = new Fighter("HawkEye");
                    fighter.autoTeam = autoTeam;
                    fighter.name = GetUniqueName(playerTeamNames);
                    Team.Add(fighter);
                    PrintStats(fighter);
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
    

    public void Menu()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n******WELCOME TO THE MENU******\n");
        Console.ForegroundColor = ConsoleColor.Blue;
        TypeSlowly("\nTo get player info enter 1\n");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        TypeSlowly("\nTo play higher or lower enter 2\n");
        Console.ForegroundColor = ConsoleColor.Magenta;
        TypeSlowly("\nTo play russian roulette enter 3\n");
        Console.ForegroundColor = ConsoleColor.Gray;
        TypeSlowly("\nTo battle enter 4\n");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        TypeSlowly("\nTo exit the game enter 5\n");
        int userMenuChoice = getNumberInput();
        //int userMenuChoice = Int32.Parse(Console.ReadLine());
        if(userMenuChoice== 1)
        {
            ShowPlayerInfo();
        }
        else if(userMenuChoice == 2)
        {
            PlayHigherOrLower();
        }
        else if(userMenuChoice == 3)
        {
            RussianRoulette();
        }
        else if(userMenuChoice == 4)
        {
            BattleMonster();
        }
        else if(userMenuChoice == 5)
        {
            isRunning = false;
        }
    }

    public static void PrintStats(Fighter fighter)
    {  
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Name: " + fighter.name);
        Console.WriteLine("AutoTeam: " + fighter.autoTeam);
        Console.WriteLine("Type: " + fighter.Wtype);
        Console.WriteLine("Attack Points: " + fighter.att);
        Console.WriteLine("Defence Points: " + fighter.def);
        Console.WriteLine("Health Points: " + fighter.hp);
        Console.WriteLine("Speed Points: " + fighter.spe);
        Console.WriteLine("Weakness: " + fighter.weakness);
        Console.ResetColor();

    }

    public void ShowPlayerInfo()
    {
        System.Console.WriteLine($"Your player name is: {player.characterName}");
        System.Console.WriteLine($"Your health is: {player.health}");
        System.Console.WriteLine($"Your damage is: {player.damage}");
    }

    public void PlayHigherOrLower()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        System.Console.WriteLine("Wecome to higher or lower");
        System.Console.WriteLine("Each game contains 3 rounds. If you win 2/3 of the rounds you will gain a health point!");
        System.Console.WriteLine("You will be given a random number");
        System.Console.WriteLine("If you think the next number will be higher, type 'H'");
        System.Console.WriteLine("If you think the next number will be lower, type 'L'");    
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        HigherOrLower higherOrLower = new HigherOrLower();
        higherOrLower.PlayHigherOrLower(player);
        Menu();
    }

    public void RussianRoulette()
    {
        System.Console.WriteLine("Play Russian Roulette ");
    }

    public void MakeMonster()
    {
        monster = new Monster();
        monster.health = randomNum.Next(1,8);
        monster.damage = randomNum.Next(1,8);
    }
    public int getNumberInput()
    { 
        string userInput;
        while(true){
            userInput= Console.ReadLine();
            if (userInput.All(char.IsDigit))
            {
                int numberValue = Int32.Parse(userInput);
                if(numberValue>= 1 && numberValue <= 5)
                {
                    return numberValue;
                }
            }
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid input! Please enter digits only.");
        }

    }
    public void BattleMonster()
    {
        MakeMonster();
        Console.ForegroundColor = ConsoleColor.Magenta;
                
        System.Console.WriteLine("A monster with random health and attack damage has been generated");
        System.Console.WriteLine("You must now choose whether you want to attack or defend");
        System.Console.WriteLine("If you attack, you must use your damage points to kill the monster on your first go or you will automatically die from the counterattack and the game will end");
        System.Console.WriteLine("If you defend, you must have enough health points to survive. Otherwise the monster wins, you die and the game ends");
        System.Console.WriteLine("To Attack enter 1.");
        System.Console.WriteLine("To Defend enter 2.");
        // int attackOrDefend = Int32.Parse(Console.ReadLine());
        int attackOrDefend = getNumberInput();
        if (attackOrDefend == 1)
        {
            if(player.damage>= monster.health)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                System.Console.WriteLine("Congratulations you won the game ");
                System.Console.WriteLine($"You had {player.damage} damage points and the monster only had {monster.health} health points ");
                isRunning = false;
                // break;
            }
            else if(player.damage!> monster.health)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Damn it you lost");
                System.Console.WriteLine($"You had {player.damage} damage points but the monster had {monster.health} health points ");
                isRunning = false;
                // break;
            }
        }
        else if(attackOrDefend == 2)
        {
            if(player.health > monster.damage)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                System.Console.WriteLine("Congratulations you won the game ");
                System.Console.WriteLine($"You had {player.health} health points and the monster only had {monster.damage} damage points ");
                isRunning = false;
                // break;

            }
            else if(player.health !> monster.damage)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Damn it you lost");
                System.Console.WriteLine($"You had {player.health} damage points but the monster had {monster.damage} damage points ");
                isRunning = false;
                // break;
            }
        }
    }

    public static void TypeSlowly(string text)
    {
        Random randomNum= new Random();
        foreach(char c in text)
        {
            Console.Write(c);
            Thread.Sleep(randomNum.Next(30,80));
        }
    }

    public static void DisplayHealth(int health, int damage)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;

        if (health >=5 )
        {
            TypeSlowly("You got lucky!");
            Console.WriteLine($"\n*****DEFENCE IS {health}*****\n");
        }
        else
        {
            TypeSlowly("Unlucky your health is pretty low");
   
            Console.WriteLine($"\n*****DEFENCE IS {health}*****\n");
        }

        if (damage >=5 )
        {
            TypeSlowly("You got lucky!");
            Console.WriteLine($"\n*****ATTACK IS {damage}*****\n");
        }
        else
        {
            TypeSlowly("Unlucky your health is pretty low");
   
            Console.WriteLine($"\n*****ATTACK IS {damage}*****\n");
        }
    }

    public static string GetUniqueName(List <string> teamNamesArray)
    {
        Random random = new Random();
        int randomIndex = random.Next(teamNamesArray.Count());
        string chosenName = teamNamesArray[randomIndex];
        teamNamesArray.RemoveAt(randomIndex);

        return chosenName;
    }
    public static List<string> LoadNames(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        List<string> names = new List<string>{};
        foreach(string line in lines)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                names.Add(line);
            }
        }
        return names;
    }
}
    