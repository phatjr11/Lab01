using System;

namespace Lab01_03
{
    public class Teacher : Person
    {
        private string address;

        public string Address { get => address; set => address = value; }

        public Teacher() : base() { }
        public Teacher(string id, string fullName, string address)
            : base(id, fullName)
        {
            this.address = address;
        }

        // Override Input
        public override void Input()
        {
            base.Input();
            Console.Write("Nhập Địa chỉ: ");
            Address = Console.ReadLine();
        }

        // Override Show
        public override void Show()
        {
            base.Show();
            Console.WriteLine(" | {0,-30}", Address);
        }
    }
}
