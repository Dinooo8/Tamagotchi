using System;
using System.Collections.Generic;

public class Tamagotchi
{
    private int hunger;
    private int boredom;
    private List<string> words = new List<string>() { "Hewwo" };
    private bool isAlive;
    private Random generator;
    public string name;

    public Tamagotchi()
    {
        generator = new Random();
        isAlive = true;
    }

    public void Feed()
    {
        Console.WriteLine($" [{name}] blir mindre hungrig");
        hunger -= 2;
        if (hunger < 0)
        {
            hunger = 0;
        }
    }

    public void Hi()
    {
        int wordNum = generator.Next(words.Count);
        Console.WriteLine($" [{name}] säger: {words[wordNum]}");
        ReduceBoredom();
    }

    public void Teach(string word)
    {
        Console.WriteLine($" [{name}] learns: {word}");
        words.Add(word);
        ReduceBoredom();
    }

    public void Tick()
    {
        hunger++;
        boredom++;
        if (hunger > 10 || boredom > 10)
        {
            isAlive = false;
        }
    }

    public void PrintStats()
    {
        Console.WriteLine($"Name: {name} || Hunger: {hunger} || Boredom: {boredom} || Vocabulary: {words.Count} words");
    }

    public bool GetAlive()
    {
        return isAlive;
    }

    public void ReduceBoredom()
    {
        Console.WriteLine($" [{name}] är mindre uttråkad!");

        boredom -= 2;
        if (boredom < 0)
        {
            boredom = 0;
        }
        Console.WriteLine("Välommen till Tamagotchi spelet!");

        Tamagotchi myTama = new Tamagotchi();

        Console.WriteLine("Välj ett namn till din tamagotchi!");
        myTama.name = Console.ReadLine();

        Console.WriteLine($"Din tamogotchis namn är {myTama.name}!");

        while (myTama.GetAlive() == true)
        {
            Console.Clear();
            myTama.PrintStats();
            Console.WriteLine("Vad vill du göra nu?");
            Console.WriteLine($"1. lär {myTama.name} ett nytt ord");
            Console.WriteLine($"2. prata med {myTama.name}");
            Console.WriteLine($"3. ge mat till {myTama.name}");
            Console.WriteLine($"4. gör inget");

            string doWhat = Console.ReadLine();
            if (doWhat == "1")
            {
                Console.WriteLine("vilket ord?");
                string word = Console.ReadLine();
                myTama.Teach(word);
            }
            if (doWhat == "2")
            {
                myTama.Hi();
            }
            if (doWhat == "3")
            {
                myTama.Feed();
            }
            else
            {
                Console.WriteLine("Stillastående");
            }
            myTama.Tick();

        }

        Console.WriteLine($"oh nej! {myTama.name} är död!");
        Console.WriteLine("tryck på quit");
        Console.ReadLine();
    }
}