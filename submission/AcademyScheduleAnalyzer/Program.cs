using System.Globalization;
using System.Text;

namespace Academy_Schedule_Analyzer
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] sessionNames =
            {
                "C# Basics",
                "Arrays",
                "Functions",
                "Date and Time",
                "Exception Handling"
            };

            DateTime[] sessionDates =
            {
                new DateTime(2026, 9, 10, 18, 0, 0),
                new DateTime(2026, 9, 13, 18, 0, 0),
                new DateTime(2026, 9, 17, 18, 0, 0),
                new DateTime(2026, 9, 20, 18, 0, 0),
                new DateTime(2026, 9, 24, 18, 0, 0)
            };

            int[] sessionDurations = { 180, 240, 180, 240, 180 };





            int option;

            do
            {
                PrintMenu();
                option = ReadMenuOption();
                Console.WriteLine();

                switch (option)
                {
                    case 1:
                        DisplaySessions(sessionNames, sessionDates, sessionDurations);
                        break;
                    case 2:
                        Console.Write("Enter session name: ");
                        SearchSession(sessionNames, sessionDates, sessionDurations, Console.ReadLine() ?? string.Empty);
                        break;
                    case 3:
                        SortSessionNames(sessionNames);
                        break;
                    case 4:
                        ReverseSessionNames(sessionNames);
                        break;
                    case 5:
                        Console.Write("Enter session name: ");
                        FindSessionIndex(sessionNames, Console.ReadLine() ?? string.Empty);
                        break;
                    case 6:
                        Console.Write("Enter session name: ");
                        CheckSessionExists(sessionNames, Console.ReadLine() ?? string.Empty);
                        break;
                    case 7:
                        Console.Write("Enter keyword: ");
                        FindSessionByCondition(sessionNames, Console.ReadLine() ?? string.Empty);
                        break;
                    case 8:
                        Console.Write("Enter keyword: ");
                        FindSessionIndexByCondition(sessionNames, Console.ReadLine() ?? string.Empty);
                        break;
                    case 9:
                        DemonstrateArrayCopy(sessionNames);
                        break;
                    case 10:
                        DisplayDurations(sessionDurations);
                        break;
                    case 11:
                        ShowSessionDateDetails(sessionNames, sessionDates, sessionDurations);
                        break;
                    case 12:
                        ShowPastAndUpcomingSessions(sessionNames, sessionDates);
                        break;
                    case 13:
                        FindNextSession(sessionNames, sessionDates);
                        break;
                    case 14:
                        CompareSessionDates(sessionNames, sessionDates);
                        break;
                    case 15:
                        ShowDateFormats(sessionNames, sessionDates);
                        break;
                    case 16:
                        DateTime validDate = ReadSessionDate();
                        Console.WriteLine($"Accepted date: {validDate}");
                        break;
                    case 17:
                        SelectSessionByIndex(sessionNames, sessionDates, sessionDurations);
                        break;
                    case 18:
                        ValidateDurationInput();
                        break;
                    case 19:
                        DemonstrateRef();
                        break;
                    case 20:
                        DemonstrateOut(sessionNames, sessionDurations);
                        break;
                    case 21:
                        ReferenceTypeWithoutRef(sessionNames);
                        break;
                    case 22:
                        DemonstrateParams();
                        break;
                    case 23:
                        Console.WriteLine(BuildReportUsingString(sessionNames, sessionDates, sessionDurations));
                        break;
                    case 24:
                        Console.WriteLine(BuildReportUsingStringBuilder(sessionNames, sessionDates, sessionDurations));
                        break;
                    case 0:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

                Console.WriteLine();
            } while (option != 0);


        }












        // Menu

        private static void PrintMenu()
        {
            Console.WriteLine("===================================");
            Console.WriteLine("Academy Schedule Analyzer");
            Console.WriteLine("===================================");
            Console.WriteLine("1. Display all sessions");
            Console.WriteLine("2. Search for a session");
            Console.WriteLine("3. Sort session names");
            Console.WriteLine("4. Reverse session names");
            Console.WriteLine("5. Find session index");
            Console.WriteLine("6. Check if session exists");
            Console.WriteLine("7. Find session by condition (Array.Find)");
            Console.WriteLine("8. Find session index by condition (Array.FindIndex)");
            Console.WriteLine("9. Demonstrate Array.Copy independence");
            Console.WriteLine("10. Show duration statistics");
            Console.WriteLine("11. Show session date details");
            Console.WriteLine("12. Show past and upcoming sessions");
            Console.WriteLine("13. Find next session");
            Console.WriteLine("14. Compare two session dates");
            Console.WriteLine("15. Show date formats for a session");
            Console.WriteLine("16. Read and validate a custom date");
            Console.WriteLine("17. Select session by index");
            Console.WriteLine("18. Validate session duration");
            Console.WriteLine("19. Demonstrate ref parameter");
            Console.WriteLine("20. Demonstrate out parameter");
            Console.WriteLine("21. Demonstrate reference type without ref");
            Console.WriteLine("22. Demonstrate params keyword");
            Console.WriteLine("23. Generate report using string");
            Console.WriteLine("24. Generate report using StringBuilder");
            Console.WriteLine("0. Exit");
        }







        // Part 2: Display all sessions

        private static void DisplaySessions(string[] names, DateTime[] dates, int[] durations)
        {
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {names[i]}");
                DisplaySessionDetails(i, names, dates, durations);
                Console.WriteLine();
            }
        }

        private static void DisplaySessionDetails(int index, string[] names, DateTime[] dates, int[] durations)
        {
            Console.WriteLine($"Date: {dates[index]:dd MMMM yyyy}");
            Console.WriteLine($"Start Time: {dates[index]:hh:mm tt}");
            Console.WriteLine($"Duration: {durations[index]} minutes");
        }




        // Part 3: Search for a session


        // return the index of the found session if we need it in the future.
        private static int SearchSession(string[] names, DateTime[] dates, int[] durations, string sessionName)
        {
            int index = Array.IndexOf(names, sessionName);

            if (index == -1)
            {
                Console.WriteLine("Session not found.");
                return -1;
            }

            Console.WriteLine(names[index]);
            DisplaySessionDetails(index, names, dates, durations);
            return index;
        }




        // Part 4: Array methods practice


        //4.1
        private static void SortSessionNames(string[] names)
        {
            string[] sortedCopy = new string[names.Length];
            Array.Copy(names, sortedCopy, names.Length);
            Array.Sort(sortedCopy);

            Console.WriteLine("Sorted session names:");
            foreach (string name in sortedCopy)
                Console.WriteLine(name);
        }


        //4.2
        private static void ReverseSessionNames(string[] names)
        {
            string[] reversedCopy = new string[names.Length];
            Array.Copy(names, reversedCopy, names.Length);
            Array.Reverse(reversedCopy);

            Console.WriteLine("Reversed session names:");
            foreach (string name in reversedCopy)
                Console.WriteLine(name);
        }



        //4.3
        private static void FindSessionIndex(string[] names, string sessionName)
        {
            int index = Array.IndexOf(names, sessionName);
            Console.WriteLine(index == -1 ? "Session not found." : $"Index: {index}");
        }

        //4.4
        private static void CheckSessionExists(string[] names, string sessionName)
        {
            bool exists = Array.Exists(names, n => n == sessionName);
            Console.WriteLine(exists ? "Session exists." : "Session does not exist.");
        }

        //4.5
        private static void FindSessionByCondition(string[] names, string keyword)
        {
            string? found = Array.Find(names, n => n.Contains(keyword));
            Console.WriteLine(found != null ? $"Found: {found}" : "No matching session found.");
        }

        //4.6


        private static void FindSessionIndexByCondition(string[] names, string keyword)
        {
            int index = Array.FindIndex(names, n => n.Contains(keyword));
            Console.WriteLine(index != -1 ? $"Index: {index}" : "No matching session found.");
        }

        //4.7
        private static void DemonstrateArrayCopy(string[] names)
        {
            string[] copy = new string[names.Length];
            Array.Copy(names, copy, names.Length);

            if (copy.Length > 0)
                copy[0] = "MODIFIED SESSION (copy only)";

            Console.WriteLine("Original array:");
            foreach (string name in names)
                Console.WriteLine(name);

            Console.WriteLine("Copied array:");
            foreach (string name in copy)
                Console.WriteLine(name);
        }


        // Part 5: Duration analysis

        private static int GetTotalDuration(int[] durations)
        {
            int total = 0;

            for (int i = 0; i < durations.Length; i++)
                total += durations[i];

            return total;
        }

        private static double GetAverageDuration(int[] durations)
        {
            return (double)GetTotalDuration(durations) / durations.Length;
        }

        private static int GetShortestDuration(int[] durations)
        {
            int shortest = durations[0];

            for (int i = 1; i < durations.Length; i++)
                if (durations[i] < shortest)
                    shortest = durations[i];

            return shortest;
        }

        private static int GetLongestDuration(int[] durations)
        {
            int longest = durations[0];

            for (int i = 1; i < durations.Length; i++)
                if (durations[i] > longest)
                    longest = durations[i];

            return longest;
        }


        private static void opeartion(int[] durations)
        {

            int[] sortedCopy = new int[durations.Length];
            Array.Copy(durations, sortedCopy, durations.Length);
            Array.Sort(sortedCopy);

            Console.WriteLine("Sorted durations:");
            foreach (int d in sortedCopy)
                Console.WriteLine(d);



        }

        private static void DisplayDurations(int[] durations)
        {
            Console.WriteLine($"Total Duration: {GetTotalDuration(durations)} minutes");
            Console.WriteLine($"Average Duration: {GetAverageDuration(durations):0} minutes");
            Console.WriteLine($"Shortest Duration: {GetShortestDuration(durations)} minutes");
            Console.WriteLine($"Longest Duration: {GetLongestDuration(durations)} minutes");

            opeartion(durations);


        }



        // Part 6: supporting functions


        private static DateTime GetSessionEndTime(DateTime start, int durationMinutes)
        {
            return start.AddMinutes(durationMinutes);
        }

        private static DateTime ReadSessionDate()
        {
            const string format = "yyyy-MM-dd HH:mm";

            while (true)
            {
                Console.Write($"Enter date ({format}): ");
                string? input = Console.ReadLine();

                bool isValid = DateTime.TryParseExact(
                    input,
                    format,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime result);

                if (isValid)
                    return result;

                Console.WriteLine("Invalid date. Use the exact format yyyy-MM-dd HH:mm.");
            }
        }




        // Part 7: ref, out, reference type without ref


        private static void IncrementValue(ref int value)
        {
            value += 10;
        }

        private static void DemonstrateRef()
        {
            int value = 5;
            Console.WriteLine($"Before: {value}");
            IncrementValue(ref value);
            Console.WriteLine($"After: {value}");
        }

        private static bool TryGetSessionInfo(string[] names, int[] durations, string sessionName, out int index, out int duration)
        {
            index = Array.IndexOf(names, sessionName);

            if (index == -1)
            {
                duration = 0;
                return false;
            }

            duration = durations[index];
            return true;
        }

        private static void DemonstrateOut(string[] names, int[] durations)
        {
            Console.Write("Enter session: ");
            string sessionName = Console.ReadLine() ?? string.Empty;

            if (TryGetSessionInfo(names, durations, sessionName, out int index, out int duration))
            {
                Console.WriteLine($"Index: {index}");
                Console.WriteLine($"Duration: {duration} minutes");
            }
            else
            {
                Console.WriteLine("Session not found.");
            }
        }

        private static void change_element(string[] names)
        {

            if (names.Length > 0)
                names[0] = "CHANGED (no ref keyword used)";

        }
        private static void ReferenceTypeWithoutRef(string[] names)
        {

            Console.WriteLine("Before calling function:");
            foreach (string name in names)
                Console.WriteLine(name);


            change_element(names);



            Console.WriteLine("After calling function (element changed with no ref):");
            foreach (string name in names)
                Console.WriteLine(name);
        }





        // Part 8: params


        private static int CalculateTotalDuration(params int[] durations)
        {
            int total = 0;

            for (int i = 0; i < durations.Length; i++)
                total += durations[i];

            return total;
        }

        private static void DemonstrateParams()
        {
            Console.WriteLine($"Total: {CalculateTotalDuration(120, 180)} minutes");
            Console.WriteLine($"Total: {CalculateTotalDuration(120, 180, 240)} minutes");
            Console.WriteLine($"Total: {CalculateTotalDuration(60, 90, 120, 180, 240)} minutes");
        }


        // Part 9: session date details

        private static void ShowSessionDateDetails(string[] names, DateTime[] dates, int[] durations)
        {
            Console.Write("Enter session name: ");
            string sessionName = Console.ReadLine() ?? string.Empty;

            int index = Array.IndexOf(names, sessionName);
            if (index == -1)
            {
                Console.WriteLine("Session not found.");
                return;
            }

            DateTime date = dates[index];
            int duration = durations[index];
            DateTime endTime = GetSessionEndTime(date, duration);

            Console.WriteLine($"Session: {names[index]}");
            Console.WriteLine($"Date: {date:dd MMMM yyyy}");
            Console.WriteLine($"Day: {date.DayOfWeek}");
            Console.WriteLine($"Year: {date.Year}");
            Console.WriteLine($"Month: {date.Month}");
            Console.WriteLine($"Day Number: {date.Day}");
            Console.WriteLine($"Start Time: {date:hh:mm tt}");
            Console.WriteLine($"Duration: {duration} minutes");
            Console.WriteLine($"End Time: {endTime:hh:mm tt}");
        }



        // Part 10: date difference



        private static void CompareSessionDates(string[] names, DateTime[] dates)
        {
            Console.Write("First Session: ");
            string first = Console.ReadLine() ?? string.Empty;
            Console.Write("Second Session: ");
            string second = Console.ReadLine() ?? string.Empty;

            int firstIndex = Array.IndexOf(names, first);
            int secondIndex = Array.IndexOf(names, second);

            if (firstIndex == -1 || secondIndex == -1)
            {
                Console.WriteLine("One or both sessions were not found.");
                return;
            }

            TimeSpan difference = dates[secondIndex] - dates[firstIndex];

            if (difference < TimeSpan.Zero)
                difference = difference.Negate(); //if negative it will turn it to postive .

            Console.WriteLine("Difference:");
            Console.WriteLine($"{difference.Days} days");
            Console.WriteLine($"{(int)difference.TotalHours} hours");
        }





        // Part 11: past and upcoming sessions



        private static void ShowPastAndUpcomingSessions(string[] names, DateTime[] dates)
        {
            DateTime now = DateTime.Now;

            for (int i = 0; i < names.Length; i++)
            {
                string status = dates[i] < now ? "Past" : "Upcoming";

                Console.WriteLine($"{names[i]} {status}");
            }
        }



        // Part 12: find the next session


        private static void FindNextSession(string[] names, DateTime[] dates)
        {
            DateTime now = DateTime.Now;
            int nextIndex = -1;
            DateTime nearestDate = DateTime.MaxValue;

            for (int i = 0; i < dates.Length; i++)
            {
                if (dates[i] > now && dates[i] < nearestDate)
                {
                    nearestDate = dates[i];
                    nextIndex = i;
                }
            }

            if (nextIndex == -1)
            {
                Console.WriteLine("No upcoming sessions.");
                return;
            }

            TimeSpan remaining = dates[nextIndex] - now;

            Console.WriteLine("Next Session:");
            Console.WriteLine(names[nextIndex]);
            Console.WriteLine($"{dates[nextIndex]:dd MMMM yyyy}");
            Console.WriteLine($"{dates[nextIndex]:hh:mm tt}");
            Console.WriteLine("Time Remaining:");
            Console.WriteLine($"{remaining.Days} days");
            Console.WriteLine($"{remaining.Hours} hours");
        }


        // Part 13: date formatting


        private static void ShowDateFormats(string[] names, DateTime[] dates)
        {
            Console.Write("Enter session name: ");
            string sessionName = Console.ReadLine() ?? string.Empty;

            int index = Array.IndexOf(names, sessionName);
            if (index == -1)
            {
                Console.WriteLine("Session not found.");
                return;
            }

            DateTime date = dates[index];
            Console.WriteLine(date.ToString("yyyy-MM-dd"));
            Console.WriteLine(date.ToString("dd/MM/yyyy"));
            Console.WriteLine(date.ToString("dd MMMM yyyy"));
            Console.WriteLine(date.ToString("dddd, dd MMMM yyyy"));
            Console.WriteLine(date.ToString("hh:mm tt"));
        }



        // Part 15: reads a menu option

        private static int ReadMenuOption()
        {
            while (true)
            {
                Console.Write("Choose an option: ");
                string? input = Console.ReadLine();

                try
                {
                    int option = int.Parse(input ?? string.Empty);
                    return option;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid menu option. Enter a number.");
                }
            }
        }


        // Part 16: invalid array index handling

        private static void SelectSessionByIndex(string[] names, DateTime[] dates, int[] durations)
        {
            Console.Write("Enter session index: ");
            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int index))
            {
                Console.WriteLine("Invalid index format.");
                return;
            }

            try
            {
                Console.WriteLine($"Session: {names[index]}");
                DisplaySessionDetails(index, names, dates, durations);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("The selected session index is out of range.");
            }
        }





        // Part 17  Throw an Exception 

        private static void ValidateDuration(int duration)
        {
            if (duration <= 0)
                throw new ArgumentException("Duration must be greater than zero.");
        }


        // Part 18 finally

        private static void ValidateDurationInput()
        {
            Console.Write("Enter duration: ");
            string? input = Console.ReadLine();

            try
            {
                if (!int.TryParse(input, out int duration))
                {
                    Console.WriteLine("Invalid duration format.");
                    return;
                }

                ValidateDuration(duration);
                Console.WriteLine("Duration accepted.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Input operation finished.");
            }
        }



        // Part 19 & 20: report generation

        private static string BuildReportUsingString(string[] names, DateTime[] dates, int[] durations)
        {
            string result = "";

            for (int i = 0; i < names.Length; i++)
            {
                result += $"{names[i]} - {dates[i]:dd/MM/yyyy hh:mm tt} - {durations[i]} minutes\n";
            }

            return result;
        }

        private static string BuildReportUsingStringBuilder(string[] names, DateTime[] dates, int[] durations)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < names.Length; i++)
            {
                sb.AppendLine($"{names[i]} - {dates[i]:dd/MM/yyyy hh:mm tt} - {durations[i]} minutes");
            }

            return sb.ToString();

        }





















    }
}
