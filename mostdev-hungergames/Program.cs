using mostdev_hungergames.controller;
using mostdev_hungergames.model;
using System;

namespace mostdev_hungergames
{
    class Program
    {
        static void Main(string[] args)
        {
            new GameController().playGame();
        }
    }
}
