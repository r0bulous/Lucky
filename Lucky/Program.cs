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



            // Instantiante two int arrays with six index locations

            int[] randomNums = new int[6]; // array for randomly generated numbers
            int[] userNums = new int[6]; // array for user's guessed numbers

            // Strings for output to UI variables

            string welcome = ("Welcome to the lottery! "); // Initial greeting
            string askToPlay = ("Do you want to play? The jackpot is $" + jackpot + "."); // String asks to play and presents jackpot
            string askLowValue = ("Enter a starting number."); // Ask for starting number
            string askHighValue = ("Enter an ending number that is higher than your starting number."); // Ask for ending number




            string exitresp; // Exit response
            string again; // Play again


            Console.Write(welcome);
            Console.WriteLine(askToPlay);
            exitresp = Console.ReadLine().ToLower();
            while (exitresp.Equals("yes"))
            {
                Console.WriteLine(askLowValue);
                lowValue = int.Parse(Console.ReadLine());
                Console.WriteLine(askHighValue);
                highValue = int.Parse(Console.ReadLine());

                Random randNum = new Random(); // Create randNum variable
                int highValuePlusOne = highValue + 1; // Initialize highValuePlusOne and declare value of highValue +1 to correct for top range


                // Test display of values (low, high plus one, and single random number within the range)
                //Console.WriteLine(lowValue); // Test display of low value
                //Console.WriteLine(highValuePlusOne); // Test display of high value plus one
                //Console.WriteLine(randNum.Next(lowValue, highValuePlusOne)); // Output random number to console





                for (int i = 0; i < userNums.Length; i++) // Loop to accept guess in userGuess then send to userNums array with guessed numbers
                {
                    Console.WriteLine("Guess a number between " + lowValue + " and " + highValue + "."); // Use concatenated string to ask for guess between lowValue and highValue
                    userGuess = int.Parse(Console.ReadLine()); // Accept user's guess from console and set userGuess to that value
                        while (userNums.Contains(userGuess)) // Checks userNums to see if userGuess duplicates the value

                        {
                            Console.WriteLine("You can't guess the same number twice! Guess again.");
                            userGuess = int.Parse(Console.ReadLine()); // Accept user input from console and write to userGuess
                        }

                    userNums[i] = userGuess; // Populate userNums array with userGuess


                    //while (dupCheck == true)

                    //{
                    //    Console.WriteLine("You can't guess the same number twice! Guess again.");
                    //    userGuess = int.Parse(Console.ReadLine()); // Accept user input from console and write to userGuess
                    //}


                    while (userGuess < lowValue || userGuess > highValue) // Check to see if userGuess is within the range of lowValue and highValue
                    {
                        Console.WriteLine("That number is beyond your specified range! Enter a new number."); // Notify user that number is beyond the range
                        userGuess = int.Parse(Console.ReadLine()); // Accept user input from console and write to userGuess
                    }

                    //// Check for duplicate guess

                    //bool dupCheck = userNums.Contains(userGuess);

                    //while (dupCheck == true)
                    
                    //{
                    //    Console.WriteLine("You can't guess the same number twice! Guess again.");
                    //    userGuess = int.Parse(Console.ReadLine()); // Accept user input from console and write to userGuess
                    //}

                }

                for (int i = 0; i < randomNums.Length; i++) // For loop to populate randomNums array with randomly generated numbers for the length of randNums (six iterations)
                {
                    randomNums[i] = randNum.Next(lowValue, highValuePlusOne); // Generates random numbers from lowValue and highValuePlusOne and populates the randNum array
                                                                              // if (userNums[i] == randomNums[i]) checks match against same index position
                    for (int j = 0; j < randomNums.Length; j++)
                    {
                        if (randomNums[i] == userNums[j])
                        {
                            matches++;
                        }
                    }

                    // {
                    //    if (randomNums.Contains(userNums))
                    // }

                    //while (userNums.Contains(userGuess))

                    // {
                    //    matches ++;
                    // }
                    Console.WriteLine("Lucky Number: " + randomNums[i]); // Outputs lucky numbers to console



                    // Count matches betwen randomNums and userNums
                    
                    
                }

                Console.WriteLine("You guessed " + matches + " correctly."); // Output number of matches
                double winnings = (jackpot / 6) * matches; // calculates winnings
                Console.WriteLine("Your total winnings are $" + winnings + ".");
                Array.Clear(userNums, 0, userNums.Length); // Resets arrary, found on dotnetpearls -- couldn't find another way to do this
                matches = 0; // reset value of matches

                Console.WriteLine("Play again?");
                again = Console.ReadLine().ToLower();

                while (again.Equals("no"))
                {
                    Console.WriteLine("Thanks for playing!");
                    return;
                }
            }
        } // main
      } // Program
    } // namespace