using mostdev_hungergames.controller;
using mostdev_hungergames.model;
using System;

namespace mostdev_hungergames
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the HungerGames");

            GameController controller = new GameController();
            controller.playGame();
            Contestent winner = controller.Winner;
            Console.WriteLine("The winner is: " + winner.Name);
            Console.WriteLine(Environment.NewLine + "President Snow kills the winner: " + winner.Name);
            Console.ReadLine();

        }
    }
}
