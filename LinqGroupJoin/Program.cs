namespace LinqGroupJoin
{
    class Program
    {
        static void Main(string[] args)
        {
            // Öğrenci listesi
            List<Student> students = new List<Student>
            {
                new Student { StudentId = 1, StudentName = "Billie", ClassId = 1 },
                new Student { StudentId = 2, StudentName = "Selin", ClassId = 2 },
                new Student { StudentId = 3, StudentName = "Finneas", ClassId = 1 },
                new Student { StudentId = 4, StudentName = "Pirate", ClassId = 3 },
                new Student { StudentId = 5, StudentName = "Baird", ClassId = 2 }
            };

            // Sınıf listesi
            List<Class> classes = new List<Class>
            {
                new Class { ClassId = 1, ClassName = "Matematik" },
                new Class { ClassId = 2, ClassName = "Türkçe" },
                new Class { ClassId = 3, ClassName = "Kimya" }
            };

            // Group Join işlemi
            var result = classes.GroupJoin(
                students,
                c => c.ClassId,
                s => s.ClassId,
                (c, studentGroup) => new
                {
                    ClassName = c.ClassName,
                    Students = studentGroup.ToList()
                }
            );

            // Sonuçları yazdır
            foreach (var item in result)
            {
                Console.WriteLine($"Sınıf: {item.ClassName}");
                foreach (var student in item.Students)
                {
                    Console.WriteLine($"Öğrenci: {student.StudentName}");
                }
                Console.WriteLine();
            }
        }
    }
}
