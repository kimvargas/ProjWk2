using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjWk2
{
    class Program
    {
        static Dictionary<int, string> Resources = new Dictionary<int, string>()
            {   { 1001, "Programming Interviews Exposed" } ,
                { 1002, "Killer Game Programming" } ,
                { 1003, "Head First C#" } ,
                { 1004, "A Smarter Way to Learn JavaScript" } ,
                { 1005, "Implementing Responsive Design" } ,
                { 1006, "C# 5.0 For Dummies" } ,
                { 1007, "Assembly Language Tutor" } ,
                { 1008, "Mastering C Pointers" } ,
                { 1009, "Javascritpt For Kids" } ,
                { 1010, "Essential C# 6.0" } ,
                { 1011, "ASP.NET MVC 5" }};

        static Dictionary<string, int> Students = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
        {
            {"Quinn Bennett", 101 },
            {"Sirahn Butler", 102},
            {"Imari Childress", 103},
            {"Jennifer Evans", 104},
            {"Margaret Landefeld", 105},
            {"Jacob Lockyer", 106},
            {"Richard Raponi", 107},
            {"Cameron Robinson", 108},
            {"Krista Scholdberg", 109},
            {"Ashley Stewart", 110},
            {"Cadale Thomas", 111},
            {"Kimberly Vargas", 112},
            {"Mary Winkelman", 113},
            {"Lawrence Smith", 114}
        };


        static string menu = "\n\nMENU\n\n(Please type a number.)" +
            "\n\n1. View Students\n2. View Available Resources\n" +
            "3. View Student Accounts\n4. Checkout Item\n5. Return Item" +
            "\n6. Reset all Student Accounts \n7. Exit\n";
        static string menu1 = "\nLIST OF STUDENT NAMES\n\n";
        static string menu2 = "\nAVAILABLE RESOURCES\n\n";
        static string menu3 = "\nSTUDENT ACCOUNTS\n\n";
        static string menu4 = "\nITEM CHECKOUT\n\n";
        static string menu5 = "\nITEM RETURN\n\n";
        static string menu6 = "\nRESET ALL STUDENTS/RESOURCES\n\n";



        static Dictionary<int, string> CheckedOutDictionary = new Dictionary<int, string>(Resources);



        static void Main(string[] args)
        {


            string[] readTextLines = null;
            StreamReader CheckedOutResourcesSR = new StreamReader(@"CheckedOutResources.txt");
            using (CheckedOutResourcesSR)
            {

                readTextLines = CheckedOutResourcesSR.ReadToEnd().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in readTextLines)
                {
                    foreach (KeyValuePair<int, string> bookID in Resources)
                    {
                        if (line.Contains(bookID.Key.ToString()))
                        {
                            CheckedOutDictionary[bookID.Key] = bookID.Value + " (Checked Out)";
                        }
                    }
                }

            }



            while (true)
            {
                Header();
                Console.WriteLine(menu);

                int menuChoice = MenuCheck(Console.ReadLine());

                switch (menuChoice)
                {
                    //STUDENT LIST
                    case 1:
                        Header();
                        Console.WriteLine(menu1);
                        ListStudents(Students);
                        Footer();
                        break;

                    //RESOURCE LIST
                    case 2:
                        Header();
                        Console.WriteLine(menu2);
                        ListResources(CheckedOutDictionary);

                        Console.WriteLine("\n\nPlease select a number:\n\n1. View only Available Resources\n2. View Checked Out Resources\n3. Return to Menu");
                        int submenuChoice = int.Parse(Console.ReadLine());
                        switch (submenuChoice)
                        {
                            case 1:
                                int i = 1;
                                Header();
                                Console.WriteLine(menu2);
                                foreach (KeyValuePair<int, string> resource in CheckedOutDictionary)
                                {
                                    if (!resource.Value.Contains("(Checked Out)"))
                                    {
                                        StringBuilder availablebooksSB = new StringBuilder();
                                        availablebooksSB.Append(i);
                                        availablebooksSB.Append(". ");
                                        availablebooksSB.Append(resource.Value);
                                        Console.WriteLine(availablebooksSB);
                                        //Console.WriteLine(i + ". " + resource.Value);
                                        i++;
                                    }
                                }
                                break;
                            case 2:
                                Header();
                                Console.WriteLine(menu2);

                                //string[] sortThings = null;
                                //List<string> sortedList = new List<string>();
                                StreamReader CheckedOutResourcesSR2 = new StreamReader(@"CheckedOutResources.txt");
                                using (CheckedOutResourcesSR2)
                                {
                                    if (CheckedOutResourcesSR2.ReadToEnd()==null)
                                    {
                                        Console.WriteLine("No books have been checked out at this time.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("The following books have been checked out:");
                                        //Console.WriteLine(CheckedOutResourcesSR2.ReadToEnd());

                                        // List<string> objListOrder = CheckedOutResourcesSR2.ReadToEnd().Split(new List<string> { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                                        //sortedList = objListOrder.OrderByDescending(o => o.StartsWith).ToList();
                                        //Array.Sort(sortThings);
                                        //PrintArray(sortThings);

                                        //Resources.OrderBy(i => i.Value)
                                        int a = 1;
                                        foreach (KeyValuePair<int, string> resource in CheckedOutDictionary.OrderByDescending(j => j.Value))
                                        {
                                            //    //List<string> CheckedOutResourcesList = new List<string>();
                                            //    //StringBuilder CheckedOutResourcesListSB = new StringBuilder();
                                            //    //CheckedOutResourcesListSB.Append(CheckedOutResourcesSR2.ReadLine().Contains(book.Value));

                                            //    //CheckedOutResourcesList.Add(CheckedOutResourcesListSB.ToString());

                                            //    //Console.WriteLine(CheckedOutResourcesListSB.ToString());
                                            if (resource.Value.Contains("(Checked Out)"))
                                            {
                                                StringBuilder checkedoutSB = new StringBuilder();
                                                checkedoutSB.Append(a);
                                                checkedoutSB.Append(". ");
                                                checkedoutSB.Append(resource.Value);
                                                Console.WriteLine(checkedoutSB);
                                                //Console.WriteLine(i + ". " + resource.Value);
                                                a++;
                                            }
                                            //Console.WriteLine(a + ". " + "ID:" + book.Key + " " + book.Value);
                                            //a++;
                                        }
                                        

                                    }
                                }
                                
                                break;
                            case 3:
                                break;
                            default:
                                break;
                        }



                        Footer();
                        break;


                    //STUDENT ACCOUNTS
                    case 3:
                        Header();
                        Console.WriteLine(menu3);
                        Console.WriteLine("\n\nEnter student name:" + "\n-Type \"Help\" to see list of students.");
                        string userRequest = Console.ReadLine().ToUpper();

                        string validUserRequest = ValidName(userRequest);
                        int studentFileReq = Students[validUserRequest];


                        string fileName = studentFileReq + ".txt";  //Find some way to use SB for this
                        try
                        {
                            StreamReader srStudentAcct = new StreamReader(fileName);
                            Console.WriteLine("\n\nStudent Account for " + validUserRequest.ToUpper() + ": \n");
                            using (srStudentAcct)
                            {
                                Console.WriteLine(srStudentAcct.ReadToEnd());
                            }
                        }
                        catch (FileNotFoundException)
                        {
                            Console.Error.WriteLine("This student is not in the system. Please check spelling and try again or register new student.");
                        }
                        catch (IOException)
                        {
                            Console.Error.WriteLine("Cannot open the file {0}", fileName);
                        }


                        Footer();
                        break;





                    //CHECKOUT
                    case 4:
                        bool checkout = true;
                        int newsw = 0;
                        int rsidReq = 0;
                        Header();
                        Console.WriteLine(menu4);
                        Console.WriteLine("\n\nEnter student name:" + "\n--Type \"Help\" to see list of students.");
                        userRequest = Console.ReadLine();
                        string validatedRequest = ValidName(userRequest);
                        newsw = Students[validatedRequest];

                        while (checkout)
                        {
                            int lineCount = File.ReadLines(newsw + ".txt").Count();
                            if (lineCount == 3)
                            {
                                Console.WriteLine(userRequest.ToUpper() + " already has three items checked out. No more items are allowed.");
                                checkout = false;
                                break;
                            }
                            else
                            {
                                Header();
                                Console.WriteLine(menu4);
                                Console.WriteLine("Check-Out for " + userRequest.ToUpper() + "\n\n");

                                Console.WriteLine("Enter resource ID:");
                                Console.WriteLine("Type Help to see list of available resources.");
                                string numberCheckCO = Console.ReadLine();
                                rsidReq = ValidNumber2(numberCheckCO);
                                StreamWriter addToStudent = new StreamWriter(newsw + ".txt", true);
                                StreamWriter CheckedOutResourcesSW = new StreamWriter(@"CheckedOutResources.txt", true);
                                using (addToStudent)
                                using (CheckedOutResourcesSW)
                                {
                                    if (CheckedOutDictionary[rsidReq].Contains("(Checked Out)"))
                                    {
                                        Console.WriteLine("This item has already been Checked Out.");
                                        break;
                                    }
                                    else if (CheckedOutDictionary[rsidReq]==null)
                                    {
                                        Console.WriteLine("This item does not exist.");
                                        break;
                                    } else
                                    {
                                        addToStudent.WriteLine(rsidReq + " " + Resources[rsidReq]);
                                        CheckedOutResourcesSW.WriteLine(rsidReq + " " + Resources[rsidReq] + " (Checked Out)");
                                        CheckedOutDictionary[rsidReq] = Resources[rsidReq] + " (Checked Out)";

                                    }
                                }

                            }
                            Console.WriteLine("Check out another item for this student? Y/N");
                            if (Console.ReadLine().ToUpper() != "Y")
                            {
                                checkout = false;
                            }
                        }


                        Footer();
                        break;
                    //RETURNS
                    case 5:
                        Header();
                        Console.WriteLine(menu5);

                        Console.WriteLine("\n\nEnter student name:" /*+ "\n--Type \"Help\" to see list of students."*/);
                        string userReturnRequest = Console.ReadLine();

                        string validatedReturnRequest = ValidName(userReturnRequest);
                        newsw = Students[validatedReturnRequest];
                        

                        Header();
                        Console.WriteLine(menu5);
                        Console.WriteLine("Return for " + userReturnRequest.ToUpper() + "\n\n");
                        

                        fileName = newsw + ".txt";  
                        try
                        {
                            StreamReader srStudentAcct = new StreamReader(fileName);
                            Console.WriteLine(userReturnRequest.ToUpper() + " has the following books out: \n");
                            using (srStudentAcct)
                            {
                                Console.WriteLine(srStudentAcct.ReadToEnd());
                            }
                        }
                        catch (FileNotFoundException)
                        {
                            Console.Error.WriteLine("This student is not in the system. Please check spelling and try again or register new student.");
                        }
                        catch (IOException)
                        {
                            Console.Error.WriteLine("Cannot open the file {0}", fileName);
                        }




                        Console.WriteLine("Enter resource ID:");

                        string numberCheckR = Console.ReadLine();
                        rsidReq = ValidNumber(numberCheckR);

                        string fileNameReturns = Students[userReturnRequest].ToString() + ".txt"; //StringBuilder this sucker first
                        string deleteThisDANGIT = rsidReq.ToString() + " " + Resources[rsidReq];
                        


                                     
                        string[] studentAcct = System.IO.File.ReadAllLines(fileNameReturns);
                        IEnumerable<string> studentAcctUpdate = studentAcct.Where(line => !line.Contains(deleteThisDANGIT));
                        System.IO.File.WriteAllLines(fileNameReturns, studentAcctUpdate);

                        string[] checkedOutFile = System.IO.File.ReadAllLines(@"CheckedOutResources.txt");
                        IEnumerable<string> checkedOutFileUpdate = checkedOutFile.Where(line => !line.Contains(deleteThisDANGIT));
                        System.IO.File.WriteAllLines(@"CheckedOutResources.txt", checkedOutFileUpdate);



                        string[] updateResourceReturns = CheckedOutDictionary[rsidReq].Split('(');
                        CheckedOutDictionary[rsidReq] = updateResourceReturns[0].TrimEnd();
                        



                        Footer();
                        break;
                    case 6:
                        Header();
                        Console.WriteLine(menu6);
                        Console.WriteLine("\n\n\nWould you like to clear student accounts? Y/N \n\nThis will \"return\" all books.");
                        string clearChoice = Console.ReadLine().ToUpper();
                        if (clearChoice == "Y")
                        {
                            StudentFiles(Students);
                            StringBuilder printCleared = new StringBuilder();
                            foreach (KeyValuePair<string,int> student in Students)
                            {
                                printCleared.Append(student.Key);
                                printCleared.Append(" ");
                                printCleared.Append(student.Value.ToString());
                                printCleared.Append("\t--  File Cleared\n");
                            }
                            Console.WriteLine(printCleared);
                        }

                        Footer();

                        break;
                    case 7:
                    default:
                        break;
                }

                if (menuChoice.Equals(7))
                {
                    Header();
                    Console.WriteLine("\n\n\n\n\nGoodbye!");
                    System.Threading.Thread.Sleep(800);
                    return;
                }



            }
        }

        static void Header()
        {
            string title = "********************* BootCamp Lending Library Checkout *********************";
            Console.Clear();
            Console.WriteLine(title);
        }

        static void Footer()
        {
            Console.WriteLine("\n\nHit any key to return to menu");
            Console.ReadKey();
            Console.Clear();
        }

        static int MenuCheck(string choice)
        {
            string errorNum = "Please type a number.";
            int menuChoice = 0;
            bool menuNAN = true;
            menuNAN = int.TryParse(choice, out menuChoice);
            while (!menuNAN)
            {
                Console.WriteLine("\n" + errorNum);
                choice = Console.ReadLine();
                menuNAN = int.TryParse(choice, out menuChoice);
            }
            return menuChoice;
        }

        static void ListStudents(Dictionary<string, int> Students)
        {
            int a = 1;
            foreach (KeyValuePair<string, int> student in Students.OrderBy(i => i.Value))
            {
                Console.WriteLine(a + ". " + student.Key);
                a++;
            }
        }

        static void ListResources(Dictionary<int, string> Resources)
        {
            int a = 1;
            foreach (KeyValuePair<int, string> book in Resources.OrderBy(i => i.Value))
            {
                List<string> ListResourcesList = new List<string>();
                StringBuilder ListResourcesSB = new StringBuilder();
                ListResourcesSB.Append(a);
                ListResourcesSB.Append(". ");
                ListResourcesSB.Append("ID:");
                ListResourcesSB.Append(book.Key);
                ListResourcesSB.Append(" ");
                ListResourcesSB.Append(book.Value);

                ListResourcesList.Add(ListResourcesSB.ToString());

                Console.WriteLine(ListResourcesSB.ToString());

                //Console.WriteLine(a + ". " + "ID:" + book.Key + " " + book.Value);
                a++;
            }
        }

        static void StudentFiles(Dictionary<string, int> Students)
        {
            foreach (KeyValuePair<string, int> student in Students)
            {
                StreamWriter NewFile = new StreamWriter(student.Value + ".txt");
                NewFile.Close();
            }

            StreamWriter CleanDictionary = new StreamWriter("CheckedOutResources.txt");
            CleanDictionary.Close();

        }

        static string TestName(string name)
        {
            while (!Students.ContainsKey(name.ToUpper()))
            {
                Console.Clear();
                Header();
                Console.WriteLine(menu4);
                Console.WriteLine("\aError: Request Unavailable \n\n\nCheck yoself, afo u rek yoself.");
                Console.WriteLine("\n\nEnter student name:" /*+ "\n--Type \"Help\" to see list of students."*/);
                name = Console.ReadLine();
            }
            return name;

        }

        static string ValidName(string userRequest)
        {

            int studentFileReq = 0;
            bool validName = true;

            while (validName)
            {

                if (userRequest.Equals("help", StringComparison.CurrentCultureIgnoreCase))
                {
                    ListStudents(Students);
                    Console.WriteLine("\n\nEnter student name:");
                    userRequest = Console.ReadLine().ToUpper();
                } 
                try
                {
                    studentFileReq = Students[userRequest];
                    validName = false;
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("This student is not in the system. Please check spelling and try again or register new student.");
                    Console.WriteLine("\n\nEnter student name:" + "\n-Type \"Help\" to see list of students.");
                    userRequest = Console.ReadLine().ToUpper();
                }

                
            }
            return userRequest;
        }
        static int ValidNumber(string userRequest)
        {
            bool validNumber = true;
            int resIDReq = 0;
            while (validNumber)
            {

                if (userRequest.Equals("help", StringComparison.CurrentCultureIgnoreCase))
                {
                    ListResources(Resources);

                    Console.WriteLine("\n\nEnter Resource ID:");
                    userRequest = Console.ReadLine();
                }
                else
                {
                    try
                    {
                        resIDReq = int.Parse(userRequest);
                        validNumber = false;
                    }
                    catch (KeyNotFoundException)
                    {
                        Console.WriteLine("\a\nError: ID not entered correctly. \nPlease enter 5-digit resource ID.");
                        Console.WriteLine("\n\nEnter resource ID:" + "\n-Type \"Help\" to see list of resources.");
                        userRequest = Console.ReadLine();
                    }

                }
            }
            return resIDReq;
        }

        static int ValidNumber2(string userRequest)
        {
            bool validNumber = true;
            int resIDReq = 0;
            while (validNumber)
            {

                if (userRequest.Equals("help", StringComparison.CurrentCultureIgnoreCase))
                {
                    int i = 1;
                    foreach (KeyValuePair<int, string> resource in CheckedOutDictionary)
                    {
                        if (!resource.Value.Contains("(Checked Out)"))
                        {
                            StringBuilder availableSB = new StringBuilder();
                            availableSB.Append(i);
                            availableSB.Append(".  ID:");
                            availableSB.Append(resource.Key);
                            availableSB.Append(" ");
                            availableSB.Append(resource.Value);
                            Console.WriteLine(availableSB);
                            //Console.WriteLine(i + ". " + resource.Value);
                            i++;
                        }
                    }

                   Console.WriteLine("\n\nEnter Resource ID:");
                    userRequest = Console.ReadLine();
                }
                else
                {
                    try
                    {
                        resIDReq = int.Parse(userRequest);
                        validNumber = false;
                    }
                    catch (KeyNotFoundException)
                    {
                        Console.WriteLine("\a\nError: ID not entered correctly. \nPlease enter 5-digit resource ID.");
                        Console.WriteLine("\n\nEnter resource ID:" + "\n-Type \"Help\" to see list of resources.");
                        userRequest = Console.ReadLine();
                    }

                }
            }
            return resIDReq;
        }
        //Method to search StudentDictionary for a student name

        //Method to search Resources for a book

        static void PrintArray(string[] printme)
        {
            foreach (string line in printme)
            {
                Console.WriteLine(line);
            }

        }


    }
}
