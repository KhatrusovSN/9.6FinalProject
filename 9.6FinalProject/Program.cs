namespace _9._6FinalProject
{
    public class MyException : Exception
    {
        public MyException(string message) : base(message)
        {
            
        }
    }

    class Sort
    {
        public event Action<string[]>? EventSort; // Создаем событие.
        public void SortOptions(string[] names)
        {
            if ( names != null)
            {
                EventSort?.Invoke(names);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] secondNames = { "Смирнов", "Антонов", "Галкин", "Киркоров", "Петров" };

            Sort sort = new();

            Console.Write("Введите '1' для сортировки от А-Я, и '2' для сортировки от Я-А: ");
            try
            {
                int value = Convert.ToInt32(Console.ReadLine());
                
                switch (value)
                {
                    case 1:
                        sort.EventSort += SortOrderBy; // Подписка на событие.
                        sort.SortOptions(secondNames);
                        break;
                    case 2:
                        sort.EventSort += SortOrderByDescending; // Подписка на событие.
                        sort.SortOptions(secondNames);
                        break;
                    default:
                        value = 3;
                        break;
                }

                if (value==3)
                {
                    throw new MyException("Сообщение исключения. ");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Неверный формат. " + ex.Message);
            }
            catch(MyException ex)
            {
                Console.WriteLine("Вызван мой метод ислючения. " + ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void SortOrderBy(string[] secondNames) // Сортировка по возврастанию
        {
            IEnumerable<string> sortNames = from names in secondNames
                                            orderby names[..1], names.Length
                                            select names;
            foreach (var name in sortNames)
            {
                Console.WriteLine(name);
            }
        }
        static void SortOrderByDescending(string[] secondNames) // Сортировка по убыванию
        {
            IEnumerable<string> sortNames = from names in secondNames
                                              orderby names[..1] descending, names.Length
                                              select names;
            foreach (var name in sortNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}