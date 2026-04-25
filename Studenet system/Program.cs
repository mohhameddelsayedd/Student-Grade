namespace Studenet_system
{
    internal class Program
    {
        static void Main(string[] args)

        {
           student s = new student();
          Console.Write("Enter number of students ID: ");
            int count = int.Parse(Console.ReadLine());
            List<student> students = new List<student>();
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"\nStudent {i + 1}");
                Console.Write("Enter the name of student: ");
                string name = Console.ReadLine();
                int grade;
                Console.Write("Enter the grade of student(0-100) : ");
                while (!int.TryParse(Console.ReadLine(), out grade) || grade < 0 || grade > 100)
                {
                    Console.Write("Invalid input. Please enter a grade between 0 and 100: ");
                }
                students.Add(new student { name = name, grade = grade });
                int choice;
                do
                {
                    Console.Write("\n==============Menu==============================");
                    Console.WriteLine("1. Show all students");
                    Console.WriteLine("2. Show average grade");
                    Console.WriteLine("3. Show highest grade");
                    Console.WriteLine("4. Show failed students");
                    Console.WriteLine("5. Exit");
                    Console.Write("Enter your choice: ");

                    int.TryParse(Console.ReadLine(), out choice);
                    switch (choice)
                    {
                        case 1:
                            ShowAllStudents(students);
                            break;

                        case 2:
                            ShowAverage(students);
                            break;

                        case 3:
                            ShowHighest(students);
                            break;

                        case 4:
                            ShowFailedStudents(students);
                            break;

                        case 5:
                            Console.WriteLine("Goodbye 👋");
                            break;

                        default:
                            Console.WriteLine("Invalid choice!");
                            break;
                    }

                } while (choice != 5);
            }
            // Grade Success
            static string GetClassification(int grade)
            {
                if (grade >= 90) return "Excellent";
                else if (grade >= 75) return "Very Good";
                else if (grade >= 60) return "Good";
                else if (grade >= 50) return "Pass";
                else return "Fail";
            }
            static void ShowAllStudents(List<student> students)
            {
                Console.WriteLine("\n--- Students ---");

                foreach (var s in students)
                {
                    Console.WriteLine($"Name: {s.name}, Grade: {s.grade}, Class: {GetClassification(s.grade)}");
                }
            }

            // 5. Calculations (while loop) - Average
            static void ShowAverage(List<student> students)
            {
                int i = 0;
                int sum = 0;

                while (i < students.Count)
                {
                    sum += students[i].grade;
                    i++;
                }

                double avg = (double)sum / students.Count;
                Console.WriteLine($"Average Grade = {avg:F2}");
            }

            static void ShowHighest(List<student> students)
            {
                int i = 0;
                int max = students[0].grade;

                while (i < students.Count)
                {
                    if (students[i].grade > max)
                        max = students[i].grade;

                    i++;
                }

                Console.WriteLine($"Highest Grade = {max}");
            }
            static void ShowFailedStudents(List<student> students)
            {
                Console.WriteLine("\n--- Failed Students ---");

                foreach (var s in students)
                {
                    if (s.grade < 50)
                    {
                        Console.WriteLine($"Name: {s.name}, Grade: {s.grade}");
                    }
                }
            }
        }
    }
  }

