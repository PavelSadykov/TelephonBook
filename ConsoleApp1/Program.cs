using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class Contact
    {
        public string Name { get; set; }
        public string Number1{ get; set; }
        public string Number2 { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Создаем список для хранения данных
            List<Contact>contacts= new List<Contact>();
            //Получаем данные контактов
            string tmp = "";
            do
            {
                Console.WriteLine("Введите имя до 20 символов : ");
                string name = Console.ReadLine();
                if (name.Length >20 || name.Length==0)
                    break;
                Console.WriteLine("Введите первый номер телефона от 4 до 11 символов: ");
                string number1 = Console.ReadLine();
                if (number1.Length < 4 || number1.Length >11)
                    break;
                Console.WriteLine("Введите второй номер телефона от 4 до 11 символов: ");
                string number2 = Console.ReadLine();
                if (number2.Length < 4 || number2.Length > 11)
                    break;

                Contact contact = new Contact()
                {
                    Name = name,
                    Number1 = number1,
                    Number2 = number2
                };
                contacts.Add(contact);
                Console.WriteLine("Для продолжения ввода нажмите '1', для завершения ввода нажмите любую клавишу:");
                 tmp = Console.ReadLine();

            } while (tmp=="1");
            //Сортируем контакты по имени
            contacts.Sort((a,b)=>a.Name.CompareTo(b.Name));

            Console.WriteLine("Список контактов:");
            foreach(Contact contact in contacts)
            {
                Console.WriteLine("\nИмя : (Тел1,  Тел2) \n"+ contact.Name + " : " + contact.Number1 + ",   " + contact.Number2);
            }
            
            //Записываем список контактов в файл
            using (StreamWriter writer = new StreamWriter("contacts.txt"))
            {
                foreach (Contact contact in contacts)     
                {
                    writer.WriteLine(contact.Name + ";" + contact.Number1 + ";" + contact.Number2);

                }
            }
            Console.ReadKey();
            
        }
    }
}
