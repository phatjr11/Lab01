using System;

namespace Lab01_03
{
    public class Person
    {
        // Fields
        protected string id;
        protected string fullName;

        // Properties
        public string ID { get => id; set => id = value; }
        public string FullName { get => fullName; set => fullName = value; }

        // Constructors
        public Person() { }
        public Person(string id, string fullName)
        {
            this.id = id;
            this.fullName = fullName;
        }

        // Virtual method để các lớp con override
        public virtual void Input()
        {
            Console.Write("Nhập Mã số: ");
            ID = Console.ReadLine();
            Console.Write("Nhập Họ tên: ");
            FullName = Console.ReadLine();
        }

        public virtual void Show()
        {
            Console.Write("{0,-10} | {1,-25}", ID, FullName);
        }
    }
}
