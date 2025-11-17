// See https://aka.ms/new-console-template for more information
using System.ComponentModel.Design;
using System.Globalization;

class HigherOrLower
{
    //if you win 2 / 3 of the rounds you get a chance to win a point so if you win 2/3 wonGame = true
    public bool wonGame {get; set;}
    Random randomGenerator = new Random();
    //int gamesPlayed = 0;
    public void PlayHigherOrLower(Player player){
        Console.ForegroundColor = ConsoleColor.Green;
        int roundsWon = 0;
        bool keepPlaying = true;
        int rounds = 1;
        if (player.holGamesPlayed >= 2)
        {
            System.Console.WriteLine("Cheeky trying to play again. You can only play 2 rounds ");
            keepPlaying = false;
        }
        while(keepPlaying == true&& rounds<=3){
            for(;rounds<=3; rounds++){
                //setting the first 2 numbers 
                List<int> numbers = new List <int>{1,2,3,4,5,6,7,8,9,10};
                int firstNumIndex = randomGenerator.Next(0,numbers.Count);
                int firstNum = numbers[firstNumIndex];
                numbers.RemoveAt(firstNumIndex);
                int secondNumIndex = randomGenerator.Next(0,numbers.Count);
                int secondNum =numbers[secondNumIndex];

                System.Console.WriteLine("games played: " + player.holGamesPlayed);

                // System.Console.WriteLine(firstNum + " " + secondNum);
                System.Console.WriteLine("You are now playing round " + rounds);
                System.Console.WriteLine("Your number is: " + firstNum);
                System.Console.WriteLine("Enter H for higher or L for lower");
                //user enters H or L 
                string userInput = Console.ReadLine().ToUpper();
                char higherOrLower = char.Parse(userInput);
                if (higherOrLower == 'H')
                {
                    System.Console.WriteLine("Higher entered");
                    if (secondNum > firstNum)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        System.Console.WriteLine("You win! The next number was: " + secondNum);
                        roundsWon++;

                    }
                    else if(firstNum> secondNum)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        System.Console.WriteLine("You lose! The next number was: " + secondNum);
                    }
                    
                } else if (higherOrLower == 'L')
                {
                    if (firstNum > secondNum)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        System.Console.WriteLine("You win! The next number was: " + secondNum);
                        roundsWon++;
                    }
                    else if(secondNum> firstNum)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        System.Console.WriteLine("You lose! The next number was: " + secondNum);
                    }
                }
            }

            if(roundsWon >= 2)
            {
                wonGame = true;
                Console.BackgroundColor = ConsoleColor.Green;
                System.Console.WriteLine($"You won {roundsWon} rounds. Congratulations you have won an extra health point");
                player.holGamesPlayed ++;
            }
            else if (roundsWon < 2)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                System.Console.WriteLine($"You have only won {roundsWon} rounds. Unfortunately you habe not won am extra health point");
                wonGame = false;
                player.holGamesPlayed ++;
            }
            else
            {
                System.Console.WriteLine("this is an ese statement");
            }
            GainHealth(player);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
            //TODO add if they have played less than 2 games
            System.Console.WriteLine("Do you want to play again? Enter Y for yes or N for No");
            char userYesOrNo = char.Parse(Console.ReadLine());
            //keepPlaying = char.Parse(Console.ReadLine());
            if(userYesOrNo == 'Y'&& player.holGamesPlayed<2)
            {
                keepPlaying = true;
                PlayHigherOrLower(player);
            }
            else if(userYesOrNo== 'N')
            {
                keepPlaying = false;
                // break;
            }
            else if (userYesOrNo == 'Y'&& player.holGamesPlayed>=2)
            {
                keepPlaying = false;
                System.Console.WriteLine("You can only play 2 games. You will now go back to the menu");
                System.Console.WriteLine("games played: " + player.holGamesPlayed);
                //break;
            }
        }
    }
    public void GainHealth(Player player)
    {
        if (wonGame)
        {
            player.health += 1;
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            System.Console.WriteLine($"Your player now has {player.health} health points");
        }
    }
    }
