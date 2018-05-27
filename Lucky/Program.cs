using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucky

{
    class Program
    {

        static void Main(string[] args)
        {

            // Declare ints for high and low values of random number range

            int lowValue = 0;
            int highValue = 0;
            int userGuess = 0;
            int matches = 0; // number of matched numbers
            double jackpot = 60000; // total jackpot value






            // Strings for output to UI variables

            string welcome = ("Welcome to the lottery! "); // Initial greeting
            string askToPlay = ("Do you want to play? The jackpot is $" + jackpot + "."); // String asks to play and presents jackpot
            string askLowValue = ("Enter a starting number."); // Ask for starting number
            string askHighValue = ("Enter an ending number that is higher than your starting number."); // Ask for ending number
            string thanks = ("Thanks for playing!"); // Exit response
            string askAgain = ("Play again?"); // Ask to play again
            
            // Strings for UI input

            string replay; // User input string for if playing again or not
            string exitResp; // User input string for initial ask about playing

            // Welcome user and ask to play
            
            Console.Write(welcome); // Output welcome string
            Console.WriteLine(askToPlay); // Ask if user wants to play
            exitResp = Console.ReadLine().ToLower(); // Accepts user input, converts to lowercase and stores to exitResp string
            while (exitResp.Equals("yes")) // If user responds "yes" then proceed to start game
            {
                // Instantiante user input and random arrays with index lengths of 6
                int[] randomNums = new int[6]; // array for randomly generated numbers
                int[] userNums = new int[6]; // array for user's guessed numbers



                // Asks for low and high values, saves them to lowValue and HighValue integers
                Console.WriteLine(askLowValue); // Outputs message asking for low value
                lowValue = int.Parse(Console.ReadLine()); // Accepts integer from user and stores to lowValue
                Console.WriteLine(askHighValue); // Outputs message asking for high value
                highValue = int.Parse(Console.ReadLine()); // Accepts integer from user and stores to highValue

                Random randNum = new Random(); // Create randNum variable
                int highValuePlusOne = highValue + 1; // Initialize highValuePlusOne and declare value of highValue +1 to correct for top range

                // Loop to accept guess in userGuess then populate to userNums array with user's guessed numbers

                for (int i = 0; i < userNums.Length; i++) // Increments through length of userNums index
                {
                    Console.WriteLine("Guess a number between " + lowValue + " and " + highValue + "."); // Use concatenated string to ask for guess between lowValue and highValue
                    userGuess = int.Parse(Console.ReadLine()); // Accept user's guess from console and set userGuess to that value
                        while (userNums.Contains(userGuess)) // Checks userNums to see if userGuess duplicates the value

                        {
                            Console.WriteLine("You can't guess the same number twice! Guess again."); // Outputs message that guess is outside the range
                            userGuess = int.Parse(Console.ReadLine()); // Accept user input from console and write to userGuess
                        }

                    userNums[i] = userGuess; // Populate userNums array with userGuess

                    // Checks userGuess against their range

                    while (userGuess < lowValue || userGuess > highValue) // Check to see if userGuess is within the range of lowValue and highValue
                    {
                        Console.WriteLine("That number is beyond your specified range! Enter a new number."); // Notify user that number is beyond the range
                        userGuess = int.Parse(Console.ReadLine()); // Accept user input from console and write to userGuess
                    }

                // Generate random numbers and compare against user generated numbers

                }

                for (int i = 0; i < randomNums.Length; i++) // For loop to populate randomNums array with randomly generated numbers for the length of randNums (six iterations)
                {
                    randomNums[i] = randNum.Next(lowValue, highValuePlusOne); // Generates random numbers from lowValue and highValuePlusOne and populates the randNum array
                                                                              
                    for (int j = 0; j < randomNums.Length; j++) // Increments through length of randomNums array
                    {
                        if (randomNums[i] == userNums[j]) // If a match is found between randomNums and userNums array...
                        {
                            matches++;                    // Increment matches integer by one.
                        }
                    }


                    Console.WriteLine("Lucky Number: " + randomNums[i]); // Outputs lucky numbers to console



                 // Count matches betwen randomNums and userNums
                    
                }

                Console.WriteLine("You guessed " + matches + " correctly."); // Output number of matches
                double winnings = (jackpot / 6) * matches; // calculates winnings
                Console.WriteLine("Your total winnings are $" + winnings + "."); // Output total winnings amount

                // Reset values

                matches = 0; // reset value of matches
                lowValue = 0; // reset lowValue
                highValue = 0; // reset highValue
                highValuePlusOne = 0; // reset highValuePlusOne
                userGuess = 0; // reset userGuess
                matches = 0; // reset number of matched numbers
                // Array.Clear(userNums, 0, userNums.Length); // Found this on dotnetpearls as a way to reset arrays but we haven't been given this tool yet. Should re-instantiatie when the program loops though.

                // Ask aobut playing again. Exit if user responds "no"

                Console.WriteLine(askAgain); // Ask about playing
                replay = Console.ReadLine().ToLower(); //  Take user input

                while (replay.Equals("no"))
                {
                    Console.WriteLine(thanks); // Output thank you message
                    return;
                }
            }
        } // main
      } // Program
    } // namespace