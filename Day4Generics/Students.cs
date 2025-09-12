namespace Day4Generics
{

    public interface IEntity
    {
        public int Id { get; set; }
    }

    public class Student: IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Major { get; set; }

        public Student(int id, string name, string major)
        {
            this.Id = id;
            this.Name = name;
            this.Major = major;
        }
    }

    public class Course : IEntity
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Credits { get; set; }

        public Course(int id, string title, int credits)
        {
            this.Id = id;
            this.Title = title;
            this.Credits = credits;
        }
    }
}