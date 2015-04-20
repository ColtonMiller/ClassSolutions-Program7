using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatSim
{
    class Program
    {
        static bool isPlaying = true;
        static int playerHP = 100;
        static int enemyHP = 200;
        static Random rng = new Random();
        static void Main(string[] args)
        {
            DisplayWelcome();
            System.Threading.Thread.Sleep(1000);
            while(isPlaying)
            {
                Console.Clear();
                DisplayGameInfo();
                string weaponChoice = Console.ReadLine();
                if(ValidInput(weaponChoice))
                {
                    // valid weapon choice
                    EnemyTurn();
                    PlayerTurn(weaponChoice);
                } else
                {
                    // invalid input
                    Console.WriteLine("Invalid input");
                    System.Threading.Thread.Sleep(800);
                }

                // Check for win
                CheckForWin();
            }

            // Someone has won
            if(enemyHP > 0)
            {
                // enemy won
                Console.WriteLine("Damn the enemy beat you");
            } else
            {
                // player won
                Console.WriteLine("Good job");
            }
            Console.ReadKey();
        }

        static void CheckForWin()
        {
            if (enemyHP < 0 || playerHP < 0)
                isPlaying = false;
        }

        static void PlayerTurn(string playerChoice)
        {
            switch (playerChoice)
            {
                case "1":
                    double chance = rng.NextDouble();
                    if (chance <= 0.7)
                    {
                        // attacking
                        int damage = rng.Next(20, 36);
                        enemyHP -= damage;
                        Console.WriteLine("Player hit enemy with {0} damage", damage);
                    }
                    else
                    {
                        // missed
                        Console.WriteLine("You missed");
                    }
                    break;
                case "2":
                    int magicDamage = rng.Next(10, 16);
                    Console.WriteLine("Player hit enemy with {0} damage", magicDamage);
                    break;
                case "3":
                    int healHP = rng.Next(10, 21);
                    playerHP += healHP;
                    Console.WriteLine("You healed {0} points", healHP);
                    break;
            }
            System.Threading.Thread.Sleep(500);
        }
        static void EnemyTurn()
        {
            double chance = rng.NextDouble();
            if (chance <= 0.8)
            {
                int randomHit = rng.Next(5, 16);
                playerHP -= randomHit;
                Console.WriteLine("The enemy hit with {0} damage", randomHit);
                System.Threading.Thread.Sleep(500);
            } else
            {
                // missed
                Console.WriteLine("The enemy missed");
            }
        }
        static bool ValidInput(string userInput)
        {
            switch (userInput)
            {
                case "1":
                case "2":
                case "3":
                    return true;
            }
            return false;
        }

        static void DisplayGameInfo()
        {
            Console.WriteLine("Enemy HP: {0}", enemyHP);
            Console.WriteLine("Player HP: {0}", playerHP);
            Console.WriteLine("1. sword\n2. magic\n3. heal");
            Console.Write("pick your weapon choice: ");
        }

        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to combat sim");
        }
        
    }
}
