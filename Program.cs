using System;
using System.Collections.Generic;
using System.Linq;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a few challenges for our Adventurer's quest
            // The "Challenge" Constructor takes three arguments
            //   the text of the challenge
            //   a correct answer
            //   a number of awesome points to gain or lose depending on the success of the challenge
            List<string> colors = new List<string>();
            colors.Add("black");
            colors.Add("green");
            colors.Add("blue");

            Robe newRobe = new Robe();
            newRobe.Colors = colors;
            newRobe.Length = 200;
            newRobe.Colors.Add("silver");
            Hat newHat = new Hat();
            newHat.ShininessLevel= 10;
            Prize yourPrize = new Prize("Gold");
            int numberCorrect = 0;
            
            Console.WriteLine("Enter your name");
            string name = Console.ReadLine();
            Adventurer theAdventurer = new Adventurer(name, newRobe, newHat, numberCorrect);
            Console.WriteLine(theAdventurer.GetDescription(newRobe, name, newHat));
            Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10, numberCorrect);
            Challenge squareRoot = new Challenge("What is the square root of infinity?", 0, 50, numberCorrect);
            Challenge whatIsOne = new Challenge("What is one?", 1, 50, numberCorrect);
            Challenge theAnswer = new Challenge(
                "What's the answer to life, the universe and everything?", 42, 25, numberCorrect);
            Challenge whatSecond = new Challenge(
                "What is the current second?", DateTime.Now.Second, 50, numberCorrect);

            int randomNumber = new Random().Next() % 10;
            Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 25, numberCorrect);

            Challenge favoriteBeatle = new Challenge(
                @"Who's your favorite Beatle?
                    1) John
                    2) Paul
                    3) George
                    4) Ringo
                ",
                4, 20, numberCorrect
            );

            // "Awesomeness" is like our Adventurer's current "score"
            // A higher Awesomeness is better

            // Here we set some reasonable min and max values.
            //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
            //  If an Adventurer has an Awesomeness less than the min, they are terrible
            int minAwesomeness = 0;
            int maxAwesomeness = 100;

            // Make a new "Adventurer" object using the "Adventurer" class
            // Adventurer theAdventurer = new Adventurer(name);

            // A list of challenges for the Adventurer to complete
            // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
            List<Challenge> challenges = new List<Challenge>()
            {
                twoPlusTwo,
                theAnswer,
                whatSecond,
                guessRandom,
                favoriteBeatle,
                squareRoot
            };
            

            // Loop through all the challenges and subject the Adventurer to them
            string playAgain = "yes";
            while (playAgain == "yes")
            {
                List<Challenge> challengesIndex = new List<Challenge>();
                var random = new Random();
                while (challengesIndex.Count < 6) 
                {
                    int candidate = random.Next(challenges.Count);
                    if (!challengesIndex.Contains(challenges[candidate])) 
                    {
                    challengesIndex.Add(challenges[candidate]);
                    }
                }
                foreach (Challenge challenge in challengesIndex)
                {
                    challenge.RunChallenge(theAdventurer);
                }

                // This code examines how Awesome the Adventurer is after completing the challenges
                // And praises or humiliates them accordingly
                if (theAdventurer.Awesomeness >= maxAwesomeness)
                {
                    Console.WriteLine("YOU DID IT! You are truly awesome!");
                }
                else if (theAdventurer.Awesomeness <= minAwesomeness)
                {
                    Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
                }
                else
                {
                    Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
                }
                theAdventurer.Correct = theAdventurer.Correct * 10;
                Console.WriteLine();
                Console.WriteLine(yourPrize.ShowPrize(theAdventurer));
                Console.WriteLine(theAdventurer.Correct);
                Console.WriteLine(theAdventurer.Awesomeness);
                theAdventurer.Awesomeness = theAdventurer.Awesomeness + theAdventurer.Correct;
                Console.WriteLine(theAdventurer.Awesomeness);
                Console.WriteLine("Would you like to play again?");
                playAgain = Console.ReadLine();
            }


        }
    }
}