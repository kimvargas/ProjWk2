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
            {   { 100001, "Programming Interviews Exposed" } ,
                { 100002, "Killer Game Programming" } ,
                { 100003, "Head First C#" } ,
                { 100004, "A Smarter Way to Learn JavaScript" } ,
                { 100005, "Implementing Responsive Design" } ,
                { 100006, "C# 5.0 For Dummies" } ,
                { 100007, "Assembly Language Tutor" } ,
                { 100008, "Mastering C Pointers" } ,
                { 100009, "Javascritpt For Kids" } ,
                { 100010, "Essential C# 6.0" } ,
                { 100011, "ASP.NET MVC 5" }};

        static Dictionary<string, int> Students = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
        {
            {"Quinn Bennett", 10001 },
            {"Sirahn Butler", 10002},
            {"Imari Childress", 10003},
            {"Jennifer Evans", 10004},
            {"Margaret Landefeld", 10005},
            {"Jacob Lockyer", 10006},
            {"Richard Raponi", 10007},
            {"Cameron Robinson", 10008},
            {"Krista Scholdberg", 10009},
            {"Ashley Stewart", 10010},
            {"Cadale Thomas", 10011},
            {"Kim Vargas", 10012},
            {"Mary Winkelman", 10013},
            {"Lawrence Smith", 10014}
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





        static void Main(string[] args)
        {



            string[] readTextLines = null;
            StreamReader CheckedOutResourcesSR = new StreamReader(@"CheckedOutResources.txt");
            Dictionary<int, string> CheckedOutDictionary = new Dictionary<int, string>(Resources);
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



            //List<string> ChOutResourcesList = new List<string>();

            //StringBuilder ChOutResourcesSB = new StringBuilder();
            //foreach (KeyValuePair<int, string> books in Resources)
            //{
            //    if (!ResourceListHolder.Contains(books.Value))
            //    {

            //        BookOptions.Append(books.Key);
            //        BookOptions.Append(" ");
            //        BookOptions.AppendLine(books.Value);
            //    }
            //}
            //BookOptions.ToString();
            ////Console.WriteLine(BookOptions);














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
                                        Console.WriteLine(i + ". " + resource.Value);
                                        i++;
                                    }
                                }
                                break;
                            case 2:
                                i = 1;
                                Header();
                                Console.WriteLine(menu2);

                                string[] sortThings = null;
                                StreamReader CheckedOutResourcesSR2 = new StreamReader(@"CheckedOutResources.txt");
                                using (CheckedOutResourcesSR2)
                                {
                                    if (CheckedOutResourcesSR2.ReadToEnd() == null)
                                    {
                                        Console.WriteLine("No books have been checked out at this time.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("The following books have been checked out:");
                                        sortThings = CheckedOutResourcesSR2.ReadToEnd().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                                        Array.Sort(sortThings);
                                        PrintArray(sortThings);
                                    }
                                }


                                //foreach (KeyValuePair<int, string> resource in Resources)
                                //{
                                //    if (resource.Value.Contains("(Checked Out)"))
                                //    {
                                //        Console.WriteLine(i + ". " + resource.Value);
                                //        i++;
                                //    }
                                //}
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

                        int studentFileReq = ValidName(userRequest);



                        string fileName = studentFileReq + ".txt";  //Find some way to use SB for this
                        try
                        {
                            StreamReader srStudentAcct = new StreamReader(fileName);
                            Console.WriteLine("\n\nStudent Account for " + userRequest.ToUpper() + ": \n");
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
                        Console.WriteLine("\n\nEnter student name:" /*+ "\n--Type \"Help\" to see list of students."*/);
                        userRequest = Console.ReadLine();
                        newsw = ValidName(userRequest);
                        while (checkout)
                        {
                            int lineCount = File.ReadLines(newsw + ".txt").Count();
                            if (lineCount == 3)
                            {
                                Console.WriteLine(userRequest.ToUpper() + " already has three items checked out. No more items are allowed.");
                                checkout = false; 
                            }
                            else
                            {
                                Header();
                                Console.WriteLine(menu4);
                                Console.WriteLine("Check-Out for " + userRequest.ToUpper() + "\n\n");

                                Console.WriteLine("Enter resource ID:");
                                Console.WriteLine("Type Help to see list of available resources.");
                                string numberCheckCO = Console.ReadLine();
                                rsidReq = ValidNumber(numberCheckCO);
                                StreamWriter addToStudent = new StreamWriter(newsw + ".txt", true);
                                StreamWriter CheckedOutResources = new StreamWriter(@"CheckedOutResources.txt", true);
                                using (addToStudent)
                                using (CheckedOutResources)
                                {
                                    addToStudent.WriteLine(rsidReq + " " + Resources[rsidReq]);
                                    CheckedOutResources.WriteLine(rsidReq + " " + Resources[rsidReq]);
                                    Resources[rsidReq] = (Resources[rsidReq] + " (Checked Out)"); //StringBuilder this sucker first

                                }

                            }
                            Console.WriteLine("Check out another item for this student? Y/N");
                            if (Console.ReadLine().ToUpper() == "Y")
                            {

                            }
                        }


                        Footer();
                        break;
                    //RETURNS
                    case 5:
                        Header();
                        Console.WriteLine(menu5);

                        Console.WriteLine("\n\nEnter student name:" /*+ "\n--Type \"Help\" to see list of students."*/);
                        userRequest = Console.ReadLine();
                        //Add ValidNameCheck                       
                        newsw = Students[userRequest];

                        Header();
                        Console.WriteLine(menu5);
                        Console.WriteLine("Return for " + userRequest.ToUpper() + "\n\n");
                        Console.WriteLine("Enter resource ID:");
                        /*Console.WriteLine("Type Help to see list of available resources.");*/

                        string numberCheckR = Console.ReadLine();
                        rsidReq = ValidNumber(numberCheckR);

                        string fileNameReturns = Students[userRequest].ToString() + ".txt"; //StringBuilder this sucker first
                        string deleteThisDANGIT = rsidReq.ToString() + " " + Resources[rsidReq];
                        //StreamWriter removeFromStudent = new StreamWriter(newsw + ".txt", true);  


                        ////////*********************   //DOES NOT FREAKING WORK YET....                      
                        var studentAcct = System.IO.File.ReadAllLines(fileNameReturns);
                        var studentAcctUpdate = studentAcct.Where(line => !line.Contains(deleteThisDANGIT));
                        System.IO.File.WriteAllLines(fileNameReturns, studentAcctUpdate);

                        var checkedOutFile = System.IO.File.ReadAllLines(@"CheckedOutResources.txt");
                        var checkedOutFileUpdate = checkedOutFile.Where(line => !line.Contains(deleteThisDANGIT));
                        System.IO.File.WriteAllLines(@"CheckedOutResources.txt", checkedOutFileUpdate);





                        //Make a method for this thing: 

                        string[] updateResourceReturns = CheckedOutDictionary[rsidReq].Split('(');
                        CheckedOutDictionary[rsidReq] = updateResourceReturns[0].TrimEnd();

                        //if (line.Contains(bookID.Key.ToString()))
                        //{
                        //    CheckedOutDictionary[bookID.Key] = bookID.Value + " (Checked Out)";
                        //}



                        //For Returns:
                        //First iteration 
                        //- type in student
                        //- type in resID
                        //- remove from SW
                        //- update dictionary (Remove "Checked Out")




                        Footer();
                        break;
                    case 6:
                        Header();
                        Console.WriteLine("\n\n\nWould you like to clear student accounts? Y/N \n\nThis will \"return\" all books.");
                        string clearChoice = Console.ReadLine().ToUpper();
                        if (clearChoice == "Y")
                        {
                            StudentFiles(Students);
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
                Console.WriteLine(a + ". " + "ID:" + book.Key + " " + book.Value);
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

        static int ValidName(string userRequest)
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
                else
                {
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
            }
            return studentFileReq;
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
