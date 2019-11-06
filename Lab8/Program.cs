using System;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            //Arrays
            string[] names = { "Michael Scott", "Jim Halpert", "Dwight Schrute" };
            string[] spouse = { "Holly Flax", "Pam Beesly", "Angela Martin" };
            string[] currentCity = { "Boulder, CO", "Austin, TX", "Scranton, PA" };
            string[] job = { "Department of Natural Resources", "Athleap", "Dunder Mifflin" };

            bool repeat = true, again = true;

            while (again)
            {
                Console.WriteLine("Who would you want to learn about?");
                for (int i = 0; i < names.Length; i++)
                {
                    Console.WriteLine(i + 1 + "." + names[i]);

                }
                //Taking in user input for which person
                string personName = Console.ReadLine();
                //Put the try catch into a method. method intakes the above string and array and will return an integer
                int person = Who(personName, names);


                //WriteLine($"You want to learn more about {ValidateIndex(names, person)}");
                Console.WriteLine($"You want to learn more about {names[person]}");
                Console.WriteLine("What would you like to learn about him?");
                Console.WriteLine("Spouse, Current City, Job, or would you like to quit?");
                //for spouse, city, job, and quiting/asking for another person. 

                while (repeat)
                {
                    string learn = Console.ReadLine().ToLower();
                    if (learn == "spouse")
                    {
                        Console.WriteLine($"{spouse[person]} is the spouse of {names[person]}.");
                        Console.WriteLine("What else would you like to know? Or would you like to quit?");
                        repeat = true;

                    }
                    else if (learn == "current city" || learn == "city")
                    {
                        Console.WriteLine($"{names[person]} lives in {currentCity[person]}.");
                        Console.WriteLine("What else would you like to know? Or would you like to quit?");
                        repeat = true;
                    }
                    else if (learn == "job")
                    {
                        Console.WriteLine($"{names[person]} works at {job[person]}.");
                        Console.WriteLine("What else would you like to know? Or would you like to quit?");
                        repeat = true;
                    }
                    else if (learn == "quit")
                    {
                        Console.WriteLine("Would you like to learn about someone else? [y/n]: ");
                        string ans = Console.ReadLine();

                        if (ans == "n" || ans == "no")
                        {
                            //quiting the whole program
                            Console.WriteLine("Goodbye!");
                            repeat = false;
                            again = false;
                        }
                        else if (ans == "y" || ans == "yes")
                        {
                            //going back to first while loop to ask new person
                            again = true;
                            repeat = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid response");
                        repeat = true;
                    }
                }
                repeat = true;//resets repeat while loop

            }


        }
        /// <summary>
        /// This method was derived to return an int using Int.Parse
        /// The reason it has to intake an array is because so the second catch will work.
        /// the second catch is to make sure that you do not go outside of the index when selecting a person. 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int Who(string input, string[] array)
        {


            int person = 0;
            bool again = true;
            string test = "";
            while (again)
            {

                try
                {
                    person = int.Parse(input) - 1;
                    test = array[person];
                    again = false;
                }

                catch (FormatException ex)
                {
                    Console.WriteLine("Please enter a number");
                    input = Console.ReadLine();
                    again = true;
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine("That person does not exist. Please enter a valid number");
                    input = Console.ReadLine();
                    again = true;

                }
                //again = true;
            }
            return person;

        }
        
    }
}
