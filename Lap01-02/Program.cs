using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    // 1. Field (nếu dùng auto-property thì không cần field, nhưng theo hướng dẫn thì cần)
    private string studentID;
    private string fullName;
    private float averageScore;
    private string faculty;

    // 2. Property
    public string StudentID { get => studentID; set => studentID = value; }
    public string FullName { get => fullName; set => fullName = value; }
    public float AverageScore { get => averageScore; set => averageScore = value; }
    public string Faculty { get => faculty; set => faculty = value; }

    // 3. Constructor
    public Student() { }

    public Student(string studentID, string fullName, float averageScore, string faculty)
    {
        this.studentID = studentID;
        this.fullName = fullName;
        this.averageScore = averageScore;
        this.faculty = faculty;
    }

    // 4. Methods
    public void Input()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.Write("Nhập MSSV: ");
        StudentID = Console.ReadLine();

        Console.Write("Nhập Họ tên Sinh viên: ");
        FullName = Console.ReadLine();

        Console.Write("Nhập Điểm TB: ");
        AverageScore = float.Parse(Console.ReadLine());

        Console.Write("Nhập Khoa: ");
        Faculty = Console.ReadLine();
    }

    public void Show()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("{0,-10} | {1,-25} | {2,-10} | {3,-5}",
                          StudentID, FullName, Faculty, AverageScore);
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        List<Student> studentList = new List<Student>();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("===== MENU QUẢN LÝ SINH VIÊN =====");
            Console.WriteLine("1. Thêm sinh viên");
            Console.WriteLine("2. Hiển thị danh sách sinh viên");
            Console.WriteLine("3. Xuất sinh viên theo khoa nhập từ bàn phím");
            Console.WriteLine("4. Xuất SV có điểm TB >= 5");
            Console.WriteLine("5. Sắp xếp theo điểm TB tăng dần");
            Console.WriteLine("6. SV có ĐTB >= 5 và theo khoa nhập vào");
            Console.WriteLine("7. SV có điểm cao nhất theo khoa nhập vào");
            Console.WriteLine("8. Thống kê số lượng xếp loại");
            Console.WriteLine("0. Thoát");

            Console.Write("Chọn chức năng (0-8): ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    AddStudent(studentList);
                    break;
                case "2":
                    DisplayStudentList(studentList);
                    break;
                case "3":
                    DisplayByFaculty(studentList);
                    break;
                case "4":
                    DisplayAvgAbove5(studentList);
                    break;
                case "5":
                    SortByAverage(studentList);
                    break;
                case "6":
                    DisplayAvgAbove5AndFaculty(studentList);
                    break;
                case "7":
                    DisplayMaxScoreByFaculty(studentList);
                    break;
                case "8":
                    StatisticRank(studentList);
                    break;
                case "0":
                    exit = true;
                    Console.WriteLine("Kết thúc chương trình.");
                    break;
                default:
                    Console.WriteLine("Tùy chọn không hợp lệ. Vui lòng chọn lại!");
                    break;
            }

            Console.WriteLine();
        }
    }

    // ================== FUNCTIONS ==================

    static void AddStudent(List<Student> list)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("=== Nhập thông tin sinh viên ===");
        Student sv = new Student();
        sv.Input();
        list.Add(sv);
        Console.WriteLine("Thêm sinh viên thành công!");
    }

    static void DisplayStudentList(List<Student> list)
    {
        Console.WriteLine("=== DANH SÁCH SINH VIÊN ===");
        PrintHeader();

        foreach (Student sv in list)
            sv.Show();
    }

    static void DisplayByFaculty(List<Student> list)
    {
        Console.Write("Nhập tên khoa cần lọc: ");
        string faculty = Console.ReadLine();

        var result = list.Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase)).ToList();

        if (result.Count == 0)
        {
            Console.WriteLine("Không có sinh viên nào thuộc khoa này.");
            return;
        }

        Console.WriteLine($"\n=== SINH VIÊN KHOA {faculty.ToUpper()} ===");
        PrintHeader();

        foreach (var sv in result)
            sv.Show();
    }

    static void DisplayAvgAbove5(List<Student> list)
    {
        var result = list.Where(s => s.AverageScore >= 5).ToList();

        Console.WriteLine("=== SINH VIÊN CÓ ĐTB >= 5 ===");
        PrintHeader();
        foreach (var sv in result)
            sv.Show();
    }

    static void SortByAverage(List<Student> list)
    {
        var result = list.OrderBy(s => s.AverageScore).ToList();

        Console.WriteLine("=== DANH SÁCH SẮP XẾP THEO ĐTB TĂNG DẦN ===");
        PrintHeader();
        foreach (var sv in result)
            sv.Show();
    }

    static void DisplayAvgAbove5AndFaculty(List<Student> list)
    {
        Console.Write("Nhập tên khoa: ");
        string faculty = Console.ReadLine();

        var result = list.Where(s => s.AverageScore >= 5 &&
                                     s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase)).ToList();

        Console.WriteLine($"\n=== SV ĐTB >= 5 & KHOA {faculty.ToUpper()} ===");
        PrintHeader();
        foreach (var sv in result)
            sv.Show();
    }

    static void DisplayMaxScoreByFaculty(List<Student> list)
    {
        Console.Write("Nhập tên khoa: ");
        string faculty = Console.ReadLine();

        var result = list.Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase)).ToList();

        if (result.Count == 0)
        {
            Console.WriteLine("Không có sinh viên nào thuộc khoa này.");
            return;
        }

        float max = result.Max(s => s.AverageScore);

        var bestList = result.Where(s => s.AverageScore == max).ToList();

        Console.WriteLine($"\n=== SV ĐIỂM CAO NHẤT KHOA {faculty.ToUpper()} ===");
        PrintHeader();
        foreach (var sv in bestList)
            sv.Show();
    }

    static void StatisticRank(List<Student> list)
    {
        int xs = 0, gioi = 0, kha = 0, tb = 0, yeu = 0, kem = 0;

        foreach (var sv in list)
        {
            if (sv.AverageScore >= 9) xs++;
            else if (sv.AverageScore >= 8) gioi++;
            else if (sv.AverageScore >= 7) kha++;
            else if (sv.AverageScore >= 5) tb++;
            else if (sv.AverageScore >= 4) yeu++;
            else kem++;
        }

        Console.WriteLine("=== THỐNG KÊ XẾP LOẠI ===");
        Console.WriteLine($"Xuất sắc: {xs}");
        Console.WriteLine($"Giỏi     : {gioi}");
        Console.WriteLine($"Khá      : {kha}");
        Console.WriteLine($"Trung bình: {tb}");
        Console.WriteLine($"Yếu      : {yeu}");
        Console.WriteLine($"Kém      : {kem}");
    }

    // ================== BẢNG HEADER ==================

    static void PrintHeader()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("{0,-10} | {1,-25} | {2,-10} | {3,-5}",
                         "MSSV", "Họ Tên", "Khoa", "ĐTB");
        Console.WriteLine(new string('-', 60));
    }
}