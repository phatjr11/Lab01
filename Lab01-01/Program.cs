using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Chuong trinh doan so 3 chu so ===");

        Random random = new Random();
        int targetNumber = random.Next(100, 1000);
        string targetString = targetNumber.ToString();

        int attempt = 1;             // So lan doan
        const int MAX_GUESS = 7;     // So lan doan toi da
        string guess;                // Chuoi so nguoi choi doan
        string feedback = "";        // Phan hoi tu may tinh

        while (feedback != "+++" && attempt <= MAX_GUESS)
        {
            Console.Write("Lan doan thu {0}: ", attempt);
            guess = Console.ReadLine();

            // Kiem tra input dung 3 chu so
            if (guess.Length != 3 || !int.TryParse(guess, out _))
            {
                Console.WriteLine("Vui long nhap dung 3 chu so!");
                continue;
            }

            // Lay phan hoi tu may tinh
            feedback = GetFeedback(targetString, guess);

            Console.WriteLine("Phan hoi tu may tinh: {0}", feedback);

            attempt++;
        }

        // ================================
        // KẾT THÚC CHƯƠNG TRÌNH
        // ================================

        Console.WriteLine("\nNguoi choi da doan {0} lan. Tro choi ket thuc!", attempt - 1);

        if (attempt > MAX_GUESS)
        {
            Console.WriteLine("Nguoi choi thua cuoc. So can doan la: {0}", targetNumber);
        }
        else
        {
            Console.WriteLine("Nguoi choi thang cuoc!");
        }

        Console.ReadLine();
    }

    // Hàm tạo chuỗi feedback dựa trên số đoán và số mục tiêu
    static string GetFeedback(string target, string guess)
    {
        string feedback = "";

        for (int i = 0; i < target.Length; i++)
        {
            if (guess[i] == target[i])
            {
                feedback += "+";      // Đúng số, đúng vị trí
            }
            else if (target.Contains(guess[i].ToString()))
            {
                feedback += "?";      // Đúng số, sai vị trí
            }
        }

        return feedback;
    }
}
