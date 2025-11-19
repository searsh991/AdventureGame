
using System.Runtime.InteropServices;
using System.Security;
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

**/
class AdventureGame
{
    Random randomNum= new Random();
    Player player;
    Monster monster;
    HigherOrLower higherOrLower;
    bool isRunning {get; set;} = true;

    public static void Main(string[] args)
    {
        AdventureGame game = new AdventureGame();
        game.Play();

    }
    public void Play()
    {
        // while (isRuning && !player.isDead())
        // {
        //     System.Console.WriteLine("Welcome to the best game known to man");
        // }

        //Instructions 
        System.Console.WriteLine("This is a battle game with mini games inside");
        System.Console.WriteLine("First you will generate a player name");
        System.Console.WriteLine("Both you and the monster will be given random health and damage points ranging from 1-10");
        System.Console.WriteLine("To get more health points you can play a maximum of 2 games of higher and lower");
        System.Console.WriteLine("To get more damage points you can play a maximum of 2 games of Russian Roulette");
        System.Console.WriteLine("Once you are happy with your attack and damage points you must go and battle the monster");
        System.Console.WriteLine("Good Luck");

        MakePlayer();
        while(isRunning){
            Menu();
        }
        

    }

    public void MakePlayer()
    {
        player = new Player();
        Console.ForegroundColor = ConsoleColor.Yellow;
        System.Console.WriteLine("The first step to making your player is generating your superplayer name");
        System.Console.WriteLine("To generate your name you need to answer 3 questions. The first letter should be capital");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        System.Console.WriteLine("Firstly, please enter your favourite soft drink");
        string favSoftDrink = Console.ReadLine();
        System.Console.WriteLine("Now enter your favourite animal");
        string favAnimal = Console.ReadLine();
        System.Console.WriteLine("Now please enter an adjective of your choice");
        string adjective = Console.ReadLine();

        string playerName = adjective+favSoftDrink+favAnimal;
        player.characterName = playerName;
        player.health = randomNum.Next(1,8);
        player.damage = randomNum.Next(1,8);

        Console.ForegroundColor = ConsoleColor.Yellow;
        System.Console.WriteLine("Here comes your player informaton. Lets see how lucky you got with your health and damage points");
        Console.ForegroundColor = ConsoleColor.Cyan;
        ShowPlayerInfo();
    }

    public void Menu()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        //Console.BackgroundColor = ConsoleColor.Red;
        System.Console.WriteLine("Welcome to the menu");
        Console.ForegroundColor = ConsoleColor.Blue;
        System.Console.WriteLine("To get player info enter 1");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        System.Console.WriteLine("To play higher or lower enter 2");
        Console.ForegroundColor = ConsoleColor.Magenta;
        System.Console.WriteLine("To play russian roulette enter 3");
        Console.ForegroundColor = ConsoleColor.Gray;
        System.Console.WriteLine("To battle enter 4");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        System.Console.WriteLine("To exit the game enter 5");
        //string userInput = Console.ReadLine();


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
        System.Console.WriteLine("You will play 3 rounds");
        System.Console.WriteLine("You will be given a number and you must guess if the next number is higher or lower");
        System.Console.WriteLine("If you win 2/3 of the rounds you will gain a health point ");
    
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
            //TODO add try catch statement here
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
    }