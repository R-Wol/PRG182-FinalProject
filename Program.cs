using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Media;
using PRG182_FinalProject.Properties;


namespace Project_Testing
{    
    internal class Program
    {
        private static string CompareAges(Dictionary<string, List<string>> collection)
        {
            int[] allAges = new int[collection["Name:"].Count];
            for (int i = 0; i < collection["Name:"].Count; i++)
            {
                allAges[i] = Convert.ToInt32(collection["Age:"][i]);
            }

            int temp = 0;

            for (int i = 0; i < allAges.Length; i++)
            {
                for (int j = 0; j < allAges.Length - 1; j++)
                {
                    if (allAges[j] > allAges[j + 1])
                    {
                        temp = allAges[j + 1];
                        allAges[j + 1] = allAges[j];
                        allAges[j] = temp;
                    }
                } 
            }

            return $"Youngest Applicant: {allAges[0]}\nOldest Applicant: {allAges[allAges.Length - 1]}";
        }

        private static string AveragePizza(Dictionary<string, List<string>> collection)
        {
            if(collection == null || collection.Count == 0)
            {
                return "There is no data to calculate the Average Pizzas consumed since first visit";
            }
            
            double avgPizza = 0;
            double totalPizza = 0;

            for (int i = 0; i <= collection["Name:"].Count - 1; i++)
            {
                totalPizza += Convert.ToInt32(collection["Pizzas Consumed since first visit:"][i]);
                avgPizza = Math.Round((totalPizza / collection["Name:"].Count), 2);
            }

            return $"The average number of pizzas consumed per first visit is {avgPizza} Pizzas.";
        }

        private static bool HasSpecialChar(string input)
        {
            return input.Any(ch => !char.IsLetterOrDigit(ch));
        }

        private static Dictionary<string, List<string>> AddAplicants()
        {
            var Spinner = new Spinner();
            // variables to just store the user input
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            bool done = false;
            bool validate = false;
            string finished;
            string name;
            string ageOfPerson;
            string highRankScore;
            string startDate;
            string numberOfPizzas;
            string bowlingScore;
            string employmentStatus = "";
            string slushPuppy;
            string numberOfSlushPuppies;
            string parentEmploymentStatus = "";

            // the use of lists to store multiple users/items to each key
            List<string> allNames = new List<string>();
            List<string> ages = new List<string>();
            List<string> highScoreRanks = new List<string>();
            List<string> startDateAsLoyalCustomer = new List<string>();
            List<string> nrOfPizzasConsumed = new List<string>();
            List<string> bowlingHighScore = new List<string>();
            List<string> currentEmploymentStatus = new List<string>();
            List<string> slushPuppyPreference = new List<string>();
            List<string> slushPuppiesConsumed = new List<string>();
            List<string> currentParentEmploymentStatus = new List<string>();

            // Populating each list and doing validation checks
            while (!done)
            {
                Console.Clear();
                Console.WriteLine("Welcome! Add some potential applicants...");

                Console.WriteLine("Name: ");
                name = textInfo.ToTitleCase(Console.ReadLine());
                while (validate != true)
                {
                    if (name.Any(char.IsDigit) == true || name == "" || HasSpecialChar(name))
                    {
                        Console.WriteLine("Please enter a valid name:");
                        Console.WriteLine("Name: ");
                        name = textInfo.ToTitleCase(Console.ReadLine());
                        Console.Clear();
                    }
                    else
                    {
                        validate = true;
                    }
                }
                allNames.Add(name);
                Console.Clear();
                validate = false;

                Console.WriteLine("Age: ");
                ageOfPerson = Console.ReadLine();
                while (validate != true)
                {
                    if (ageOfPerson == "" || ageOfPerson.All(char.IsDigit) != true || Convert.ToInt32(ageOfPerson) < 0)
                    {
                        Console.WriteLine("Please enter a valid age:");
                        Console.WriteLine("Age: ");
                        ageOfPerson = Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        validate = true;
                    }
                }
                ages.Add(ageOfPerson);
                Console.Clear();
                validate = false;

                Console.WriteLine("High Rank Score: ");
                highRankScore = Console.ReadLine();
                while (validate != true)
                {
                    if (highRankScore == "" || highRankScore.All(char.IsDigit) != true || Convert.ToInt32(highRankScore) < 0)
                    {
                        Console.WriteLine("Please enter a valid High Rank Score:");
                        Console.WriteLine("High Rank Score: ");
                        highRankScore = Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        validate = true;
                    }
                }
                highScoreRanks.Add(highRankScore);
                Console.Clear();
                validate = false;

                Console.WriteLine("Starting Date as loyal customer: dd/mm/yyyy");
                startDate = Console.ReadLine();
                while (validate != true)
                {
                    string myDate = startDate;
                    string format = "dd/MM/yyyy";
                    DateTime d;
                    bool chValidity = DateTime.TryParseExact(myDate, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out d);
                    if (startDate == "" || chValidity != true)
                    {
                        Console.WriteLine("Please enter a valid date: Example format = 18/09/2003");
                        Console.WriteLine("Starting Date as loyal customer: dd/mm/yyyy");
                        startDate = Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        validate = true;
                    }
                }
                startDateAsLoyalCustomer.Add(startDate);
                Console.Clear();
                validate = false;

                Console.WriteLine("Number of pizzas consumed since first visit: ");
                numberOfPizzas = Console.ReadLine();
                while (validate != true)
                {
                    if (numberOfPizzas == "" || numberOfPizzas.All(char.IsDigit) != true || Convert.ToInt32(numberOfPizzas) < 0)
                    {
                        Console.WriteLine("Please enter a valid number:");
                        Console.WriteLine("Number of pizzas consumed since first visit: ");
                        numberOfPizzas = Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        validate = true;
                    }
                }
                nrOfPizzasConsumed.Add(numberOfPizzas);
                Console.Clear();
                validate = false;

                Console.WriteLine("Bowling High Score:");
                bowlingScore = Console.ReadLine();
                while (validate != true)
                {
                    if (bowlingScore == "" || bowlingScore.All(char.IsDigit) != true || Convert.ToInt32(bowlingScore) < 0)
                    {
                        Console.WriteLine("Please enter a valid score:");
                        Console.WriteLine("Bowling High Score:");
                        bowlingScore = Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        validate = true;
                    }
                }
                bowlingHighScore.Add(bowlingScore);
                Console.Clear();
                validate = false;

                Console.WriteLine("Current Employment Status:\nType either '1' for Employed OR '2' for Not Employed...");
                string selfChoice = Console.ReadLine();
                while (validate != true)
                {
                    if(selfChoice == "" || selfChoice.All(char.IsDigit) != true || selfChoice.Length > 1 || selfChoice.Length < 1 || Convert.ToInt32(selfChoice) < 1 || Convert.ToInt32(selfChoice) > 2)
                    {
                        Console.WriteLine("Invalid Entry:");
                        Console.WriteLine("Current Employment Status:\n'1' for Employed, '2' for Not Employed...");
                        selfChoice = Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        if (selfChoice == "1")
                        {
                            employmentStatus = "Employed";
                            validate = true;   
                        }
                        else if (selfChoice == "2")
                        {
                            employmentStatus = "Not Employed";
                            validate = true;
                        }
                    }
                }
                currentEmploymentStatus.Add(employmentStatus);
                Console.Clear();
                validate = false;

                Console.WriteLine("Parent's current Employment status:\n'1' for Employed, '2' for Not Employed...");
                string parentChoice = Console.ReadLine();
                while (validate != true)
                {
                    if (parentChoice == "" || parentChoice.All(char.IsDigit) != true || parentChoice.Length > 1 || parentChoice.Length < 1 || Convert.ToInt32(parentChoice) < 1 || Convert.ToInt32(parentChoice) > 2)
                    {
                        Console.WriteLine("Invalid Entry:");
                        Console.WriteLine("Current Employment Status:\n'1' for Employed, '2' for Not Employed...");
                        parentChoice = Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        if (parentChoice == "1")
                        {
                            parentEmploymentStatus = "Employed";
                            validate = true;
                        }
                        else if (parentChoice == "2")
                        {
                            parentEmploymentStatus = "Not Employed";
                            validate = true;
                        }
                    }
                }
                currentParentEmploymentStatus.Add(parentEmploymentStatus);
                Console.Clear();
                validate = false;

                Console.WriteLine("Slush Puppy Preference:");
                slushPuppy = textInfo.ToTitleCase(Console.ReadLine());
                while (validate != true)
                {
                    if (slushPuppy == "" || slushPuppy.Any(char.IsDigit) == true)
                    {
                        Console.WriteLine("Invalid Entry:");
                        Console.WriteLine("Slush Puppy Preference:");
                        slushPuppy = textInfo.ToTitleCase(Console.ReadLine());
                        Console.Clear();
                    }
                    else
                    {
                        validate = true;
                    }
                }
                slushPuppyPreference.Add(slushPuppy);
                Console.Clear();
                validate = false;

                Console.WriteLine("Number of Slush Puppies Consumed since first visit:");
                numberOfSlushPuppies = Console.ReadLine();
                while (validate != true)
                {
                    if (numberOfSlushPuppies == "" || numberOfSlushPuppies.All(char.IsDigit) != true || Convert.ToInt32(numberOfSlushPuppies) < 0)
                    {
                        Console.WriteLine("Please enter a valid number:");
                        Console.WriteLine("Number of Slush Puppies Consumed since first visit:");
                        numberOfSlushPuppies = Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        validate = true;
                    }
                }
                slushPuppiesConsumed.Add(numberOfSlushPuppies);
                Console.Clear();
                validate = false;

                Console.WriteLine("Do you want to capture any more applicants? Y/N: ");
                finished = Console.ReadLine();
                while (validate != true)
                {
                    if (finished == "N")
                    {
                        done = true;
                        validate = true;
                    }
                    else if (finished == "Y")
                    {
                        done = false;
                        validate = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter either 'Y' or 'N':");
                        finished = Console.ReadLine();
                    }
                }

            }

            // creating the dictionary which has a {Key: Value} pair with the key being the category and the values being the lists with all the applicant's info
            // Each value in the lists is corresponded via their index value
            var applicants = new Dictionary<string, List<string>>()
            {
                {"Name:", allNames },
                {"Age:", ages },
                {"High Score Rank:", highScoreRanks },
                {"Start Date as Loyal Customer:", startDateAsLoyalCustomer },
                {"Pizzas Consumed since first visit:", nrOfPizzasConsumed },
                {"Bowling High Score:", bowlingHighScore },
                {"Current Employment Status:", currentEmploymentStatus },
                {"Parent's Employment Status:", currentParentEmploymentStatus },
                {"Slush Puppy Preference:", slushPuppyPreference },
                {"Slush Puppies Consumed since first visit:", slushPuppiesConsumed }
            };

            
            return applicants;


        }

        private static List<string> LoyaltyAward(Dictionary<string, List<string>> collection)
        {
            List<string> awarded = new List<string>();

            var Spinner = new Spinner();

            DateTime dateTime = DateTime.Now;
            int currentYear = dateTime.Year;

            DateTime loyaltyAward;
            int loyaltyYear, loyaltyMonth;
            int totalMonths;

            string result = "";

            for (int i = 0; i <= collection["Name:"].Count - 1; i++)
            {
                loyaltyAward = DateTime.ParseExact(collection["Start Date as Loyal Customer:"][i], "dd/MM/yyyy", null);
                loyaltyYear = loyaltyAward.Year;
                loyaltyMonth = loyaltyAward.Month;

                totalMonths = (loyaltyYear * 12) + loyaltyMonth;

                if ((collection["Current Employment Status:"][i] == "Employed" || collection["Parent's Employment Status:"][i] == "Employed" && Convert.ToInt32(collection["Age:"][i]) < 18) && (currentYear - loyaltyYear >= 10) && (Convert.ToDouble(collection["High Score Rank:"][i]) > 2000 || Convert.ToDouble(collection["Bowling High Score:"][i]) > 1500 || Convert.ToDouble(collection["High Score Rank:"][i] + collection["Bowling High Score:"][i]) / 2 > 1200 && (Convert.ToInt32(collection["Pizzas Consumed since first visit:"][i]) / totalMonths) >= 3))
                {
                    result = "Granted";
                    if (Convert.ToInt32(collection["Slush Puppies Consumed since first visit:"][i]) <= 4 || collection["Slush Puppy Preference:"][i] == "Gooey Gulp Galore")
                    {
                        result = "Denied";
                    }

                }
                else
                {
                    result = "Denied";
                }

                if(result == "Granted")
                {
                    awarded.Add(collection["Name:"][i]);
                }
            }

           
            return awarded;
        }

        // METHOD FOR CHECKING TOKEN QUALIFICATION by the use of a dictionary aswell
        private static List<string> TokenQualification(Dictionary<string, List<string>> collection)
        {
            string result = "";

            var Spinner = new Spinner();

            DateTime dateTime = DateTime.Now;
            int currentYear = dateTime.Year;

            DateTime loyalCustomer;
            int loyalYear, loyalMonth;
            int totalMonths;


            List<string> qualify = new List<string>();

            for (int i = 0; i <= collection["Name:"].Count - 1; i++)
            {
                loyalCustomer = DateTime.ParseExact(collection["Start Date as Loyal Customer:"][i], "dd/MM/yyyy", null);
                loyalYear = loyalCustomer.Year;
                loyalMonth = loyalCustomer.Month;

                totalMonths = (loyalYear * 12) + loyalMonth;

                if ((collection["Current Employment Status:"][i] == "Employed" || collection["Parent's Employment Status:"][i] == "Employed" && Convert.ToInt32(collection["Age:"][i]) < 18) && (currentYear - loyalYear >= 2) && (Convert.ToDouble(collection["High Score Rank:"][i]) > 2000 || Convert.ToDouble(collection["Bowling High Score:"][i]) > 1500 || Convert.ToDouble(collection["High Score Rank:"][i] + collection["Bowling High Score:"][i]) / 2 > 1200 && (Convert.ToInt32(collection["Pizzas Consumed since first visit:"][i]) / totalMonths) >= 3))
                {
                    result = "Granted";
                    if (Convert.ToInt32(collection["Slush Puppies Consumed since first visit:"][i]) <= 4 || collection["Slush Puppy Preference:"][i] == "Gooey Gulp Galore")
                    {
                        result = "Denied";
                    }

                }
                else
                {
                    result = "Denied";
                }

                if (result == "Granted")
                {
                    qualify.Add(collection["Name:"][i]);
                }

            }

           
            return qualify;
        }


        //MENU SYSTEM
        enum Menu
        {
            Details = 1,
            Tokens,
            Stats,
            Exit
        }
        static void Main(string[] args)
        {
            SoundPlayer player = new SoundPlayer(resources.RetroSlice);
            player.Play();

            var Spinner = new Spinner();
            var applicants = new Dictionary<string, List<string>>();
            string[] headings =
            {
                "Name:",
                "Age:",
                "High Score Rank:",
                "Start Date as Loyal Customer:",
                "Pizzas Consumed since first visit:",
                "Bowling High Score:",
                "Current Employment Status:",
                "Parent's Employment Status:",
                "Slush Puppy Preference:",
                "Slush Puppies Consumed since first visit:"
            };
            string exit = "no";
            string retry = "yes";
            while (retry != "no")
            {
                Console.WriteLine("Please select a menu option: ");

                foreach (Menu option in Enum.GetValues(typeof(Menu)))
                {
                    Console.WriteLine($"To choose {option.ToString()}, press {(int)option}");
                }

                Console.WriteLine("=================================");
                Console.WriteLine();

                string pick = Console.ReadLine();
                if(pick == "" || pick.All(char.IsDigit) != true || HasSpecialChar(pick) == true || Convert.ToInt32(pick) < 1 || Convert.ToInt32(pick) > 4)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid entry");
                    continue;
                }
                Spinner.Start();
                Thread.Sleep(1000);
                Spinner.Stop();

                {
                    Console.Clear();
                    switch (Convert.ToInt32(pick))
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Add a user");
                            applicants = AddAplicants();
                            break;
                        case 2:
                            Console.Clear();
                            int qualifiedAmount = 0;
                            int notQualifiedAmount = 0;
                            
                            if(applicants.Count == 0)
                            {
                                Console.WriteLine("No applicants have been added.");
                            }
                            else
                            {
                                var qualified = TokenQualification(applicants);
                                Console.WriteLine("Congratulations! The following people have been granted a token:");
                                Console.WriteLine("=================================================================");

                                foreach (string item in qualified)
                                {
                                    qualifiedAmount++;
                                    int myIndex = applicants["Name:"].FindIndex(a => a.Contains(item));
                                    foreach (string key in headings)
                                    {
                                        Console.WriteLine($"{key} {applicants[key][myIndex]}");
                                    }
                                    Console.WriteLine("==============================================================");
                                }
                                notQualifiedAmount = applicants["Name:"].Count - qualifiedAmount;
                                Console.WriteLine($"{qualifiedAmount} applicants have qualified for a token.\n{notQualifiedAmount} applicants did not qualify for a token.");
                                Console.WriteLine();
                                Console.WriteLine("Loyalty Award for unlimited credits:\n==========================================================");
                                

                                var loyalAward = LoyaltyAward(applicants);
                                if (loyalAward.Count == 0)
                                {
                                    Console.WriteLine("No applicants have been been granted a loyalty award.");
                                }
                                else
                                {
                                    foreach (string obj in loyalAward)
                                    {
                                        int myIndex2 = applicants["Name:"].FindIndex(a => a.Contains(obj));
                                        foreach (string key in headings)
                                        {
                                            Console.WriteLine($"{key} {applicants[key][myIndex2]}");
                                        }
                                        Console.WriteLine("==============================================================");
                                    }
                                }

                            }
                            Console.ReadLine();
                            Console.Clear();

                            break;
                        case 3:
                            Console.Clear();
                            if (applicants.Count == 0)
                            {
                                Console.WriteLine("No applicants have been added.");
                            }
                            else
                            {
                                for (int i = 0; i < applicants["Name:"].Count; i++)
                                {
                                    Console.WriteLine("==============================================================");
                                    for (int j = 0; j < applicants.Count; j++)
                                    {
                                        Console.WriteLine($"{headings[j]} {applicants[headings[j]][i]}");
                                    }
                                }

                                Console.WriteLine();
                                Console.WriteLine("==============================================================");
                                Console.WriteLine(CompareAges(applicants));
                                Console.WriteLine("==============================================================");
                                Console.WriteLine();
                                Console.WriteLine(AveragePizza(applicants));
                            }
                            
                            Console.ReadLine();
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("You sure you want to close the program? yes or no");
                            exit = Console.ReadLine();
                            if (exit == "yes")
                            {
                                retry = "no";
                            }
                            else
                            {
                                retry = "yes";
                            }
                            break;
                        default:
                            Console.WriteLine("Do you want to return to main menu? yes or no");
                            retry = Console.ReadLine();
                            break;
                    }
                    if (exit != "yes")
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Do you want to return to main menu? yes or no");
                        retry = Console.ReadLine();
                        Spinner.Start();
                        Thread.Sleep(1000);
                        Spinner.Stop();
                        Console.Clear();
                    }
                }
            }
        }
        public class Spinner
        {

            private readonly int delay;
            private bool isRunning = false;
            private Thread thread;
            public Spinner(int delay = 25)
            {
                this.delay = delay;
            }

            public void Start()
            {
                if (!isRunning)
                {
                    isRunning = true;
                    thread = new Thread(Spin);
                    thread.Start();
                }
            }
            public void Stop()
            {
                Console.WriteLine();
                isRunning = false;
            }

            private void Spin()
            {
                while (isRunning)
                {
                    Console.Write("█");
                    Thread.Sleep(delay);
                }
            }
        }
    }
}
