namespace Day4Generics
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Student's Task: Working with Generic Repositories ---");

            // --- Student's Task: Instantiate and use the repository for Students ---
            // TODO: Create an instance of the GenericRepository for Students.
            GenericRepository<Student> studentRepo = new GenericRepository<Student>();

            Student studentOne = new Student(1, "Alice", "Math");
            Student studentTwo = new Student(2, "Bob", "Engineering");
            Student studentThree = new Student(3, "Maxwell Edison", "Medicine");

            // TODO: Add at least two Student objects to the repository.
            studentRepo.Add(studentOne);
            studentRepo.Add(studentTwo);
            studentRepo.Add(studentThree);

            // TODO: Retrieve a student by ID and print their name.
            // Student retrievedStudent1 = studentRepo.GetById(1);
            // Console.WriteLine($"Retrieved Student with ID {retrievedStudent1.Id}, {retrievedStudent1.Name} majoring in {retrievedStudent1.Major}");
           
            // Student retrievedStudent2 = studentRepo.GetById(2);
            // Console.WriteLine($"Retrieved Student with ID {retrievedStudent2.Id}, {retrievedStudent2.Name} majoring in {retrievedStudent2.Major}");



            // TODO: Get all students and print their names.
            var allStudents = studentRepo.GetAll();
            foreach (var student in allStudents)
            {
                Console.WriteLine($"Students {student.Name} - {student.Major}");
            }

            // --- Student's Task: Instantiate and use the repository for Courses ---
            // TODO: Create an instance of the GenericRepository for Courses.
            // GenericRepository<Course> courseRepo = new GenericRepository<Course>();

            // Course mandatory1 = new Course(1, "Geography", 4);
            // Course elective1 = new Course(2, "Mandarin", 3);

            // TODO: Add at least two Course objects to the repository.
            // courseRepo.Add(mandatory1);
            // courseRepo.Add(elective1);

            // TODO: Retrieve a course by ID and print its title.
            // Course retrievedCourse = courseRepo.GetById(1);
            // Console.WriteLine($"Retrieved course with ID {retrievedCourse.Id}: {retrievedCourse.Title}");

            // --- Student's Task: Demonstrate generic method subclassing ---
            // TODO: Call the PrintAll<T>() method on both repositories to demonstrate its use.
            // studentRepo.PrintAll<Student>();
            // courseRepo.PrintAll<Course>();

            // --- Covariance & Contravariance (For your knowledge) ---
            // Covariance allows you to use a more derived type than that specified by the generic parameter.
            // This is supported for generic interfaces and delegates where the generic type is returned.
            // IEnumerable<Student> students = new List<Student>();
            // The following is valid because IEnumerable is covariant on its type parameter T.
            // IEnumerable<object> objects = students;

            // Contravariance allows you to use a more generic (less derived) type.
            // This is supported for generic interfaces and delegates where the generic type is used as a parameter.
            // IComparer<object> objectComparer = null; // A simple example
            // IComparer<Student> studentComparer = objectComparer;
        }
    }
}