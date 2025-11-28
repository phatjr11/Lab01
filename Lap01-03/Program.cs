using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab01_03
{
    class Program
    {
        static void Main(string[] args)
        {
            // Thiết lập UTF-8 hiển thị tiếng Việt
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            List<Student> students = new List<Student>();
            List<Teacher> teachers = new List<Teacher>();

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("===== MENU QUẢN LÝ =====");
                Console.WriteLine("1. Thêm sinh viên");
                Console.WriteLine("2. Thêm giáo viên");
                Console.WriteLine("3. Xuất danh sách sinh viên");
                Console.WriteLine("4. Xuất danh sách giáo viên");
                Console.WriteLine("5. Số lượng từng danh sách");
                Console.WriteLine("6. Xuất sinh viên theo khoa");
                Console.WriteLine("7. Xuất giáo viên theo địa chỉ");
                Console.WriteLine("8. Sinh viên điểm cao nhất theo khoa");
                Console.WriteLine("9. Thống kê xếp loại sinh viên");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng: ");
                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        AddStudent(students);
                        break;
                    case "2":
                        AddTeacher(teachers);
                        break;
                    case "3":
                        DisplayStudents(students);
                        break;
                    case "4":
                        DisplayTeachers(teachers);
                        break;
                    case "5":
                        CountLists(students, teachers);
                        break;
                    case "6":
                        DisplayStudentsByFaculty(students);
                        break;
                    case "7":
                        DisplayTeachersByAddress(teachers);
                        break;
                    case "8":
                        DisplayTopStudentByFaculty(students);
                        break;
                    case "9":
                        StatisticRank(students);
                        break;
                    case "0":
                        exit = true;
                        Console.WriteLine("Kết thúc chương trình.");
                        break;
                    default:
                        Console.WriteLine("Chọn không hợp lệ, vui lòng nhập lại.");
                        break;
                }

                Console.WriteLine();
            }
        }

        // =================== FUNCTIONS ===================

        static void AddStudent(List<Student> list)
        {
            Console.WriteLine("=== Nhập thông tin sinh viên ===");
            Student sv = new Student();
            sv.Input();
            list.Add(sv);
            Console.WriteLine("Thêm sinh viên thành công!");
        }

        static void AddTeacher(List<Teacher> list)
        {
            Console.WriteLine("=== Nhập thông tin giáo viên ===");
            Teacher gv = new Teacher();
            gv.Input();
            list.Add(gv);
            Console.WriteLine("Thêm giáo viên thành công!");
        }

        static void DisplayStudents(List<Student> list)
        {
            Console.WriteLine("=== DANH SÁCH SINH VIÊN ===");
            Console.WriteLine("{0,-10} | {1,-25} | {2,-10} | {3,-5}", "MSSV", "Họ Tên", "Khoa", "ĐTB");
            Console.WriteLine(new string('-', 60));
            foreach (var sv in list)
                sv.Show();
        }

        static void DisplayTeachers(List<Teacher> list)
        {
            Console.WriteLine("=== DANH SÁCH GIÁO VIÊN ===");
            Console.WriteLine("{0,-10} | {1,-25} | {2,-30}", "Mã GV", "Họ Tên", "Địa chỉ");
            Console.WriteLine(new string('-', 70));
            foreach (var gv in list)
                gv.Show();
        }

        static void CountLists(List<Student> students, List<Teacher> teachers)
        {
            Console.WriteLine($"Tổng số sinh viên: {students.Count}");
            Console.WriteLine($"Tổng số giáo viên: {teachers.Count}");
        }

        static void DisplayStudentsByFaculty(List<Student> list)
        {
            Console.Write("Nhập tên khoa: ");
            string faculty = Console.ReadLine();
            var result = list.Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase)).ToList();
            if (result.Count == 0)
            {
                Console.WriteLine("Không có sinh viên thuộc khoa này.");
                return;
            }

            Console.WriteLine($"\n=== SINH VIÊN KHOA {faculty.ToUpper()} ===");
            Console.WriteLine("{0,-10} | {1,-25} | {2,-10} | {3,-5}", "MSSV", "Họ Tên", "Khoa", "ĐTB");
            Console.WriteLine(new string('-', 60));
            foreach (var sv in result)
                sv.Show();
        }

        static void DisplayTeachersByAddress(List<Teacher> list)
        {
            Console.Write("Nhập địa chỉ: ");
            string addr = Console.ReadLine();
            var result = list.Where(t => t.Address.IndexOf(addr, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            if (result.Count == 0)
            {
                Console.WriteLine("Không có giáo viên nào ở địa chỉ này.");
                return;
            }

            Console.WriteLine($"\n=== GIÁO VIÊN ĐỊA CHỈ {addr} ===");
            Console.WriteLine("{0,-10} | {1,-25} | {2,-30}", "Mã GV", "Họ Tên", "Địa chỉ");
            Console.WriteLine(new string('-', 70));
            foreach (var gv in result)
                gv.Show();
        }

        static void DisplayTopStudentByFaculty(List<Student> list)
        {
            Console.Write("Nhập tên khoa: ");
            string faculty = Console.ReadLine();
            var result = list.Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase)).ToList();
            if (result.Count == 0)
            {
                Console.WriteLine("Không có sinh viên thuộc khoa này.");
                return;
            }

            float maxScore = result.Max(s => s.AverageScore);
            var topStudents = result.Where(s => s.AverageScore == maxScore).ToList();

            Console.WriteLine($"\n=== SINH VIÊN ĐIỂM CAO NHẤT KHOA {faculty.ToUpper()} ===");
            Console.WriteLine("{0,-10} | {1,-25} | {2,-10} | {3,-5}", "MSSV", "Họ Tên", "Khoa", "ĐTB");
            Console.WriteLine(new string('-', 60));
            foreach (var sv in topStudents)
                sv.Show();
        }

        static void StatisticRank(List<Student> list)
        {
            int xs = 0, gioi = 0, kha = 0, tb = 0, yeu = 0, kem = 0;

            foreach (var sv in list)
            {
                if (sv.AverageScore >= 9.0 && sv.AverageScore <= 10.0) xs++;
                else if (sv.AverageScore >= 8.0 && sv.AverageScore < 9.0) gioi++;
                else if (sv.AverageScore >= 7.0 && sv.AverageScore < 8.0) kha++;
                else if (sv.AverageScore >= 5.0 && sv.AverageScore < 7.0) tb++;
                else if (sv.AverageScore >= 4.0 && sv.AverageScore < 5.0) yeu++;
                else kem++;
            }

            Console.WriteLine("=== THỐNG KÊ XẾP LOẠI SINH VIÊN ===");
            Console.WriteLine($"Xuất sắc  : {xs}");
            Console.WriteLine($"Giỏi      : {gioi}");
            Console.WriteLine($"Khá       : {kha}");
            Console.WriteLine($"Trung bình: {tb}");
            Console.WriteLine($"Yếu       : {yeu}");
            Console.WriteLine($"Kém       : {kem}");
        }
    }
}
