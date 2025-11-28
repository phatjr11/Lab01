using System;

namespace Lab01_03
{
    public class Student : Person
    {
        private float averageScore;
        private string faculty;

        public float AverageScore { get => averageScore; set => averageScore = value; }
        public string Faculty { get => faculty; set => faculty = value; }

        public Student() : base() { }

        public Student(string id, string fullName, float averageScore, string faculty)
            : base(id, fullName)
        {
            this.averageScore = averageScore;
            this.faculty = faculty;
        }

        // Override phương thức Input từ Person
        public override void Input()
        {
            base.Input(); // Nhập id và fullName
            Console.Write("Nhập Khoa: ");
            Faculty = Console.ReadLine();
            Console.Write("Nhập Điểm TB: ");
            AverageScore = float.Parse(Console.ReadLine());
        }

        // Override phương thức Show từ Person
        public override void Show()
        {
            base.Show();
            Console.WriteLine(" | {0,-10} | {1,-5}", Faculty, AverageScore);
        }
    }
}
