namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Exception[] exception = new Exception[5];
            exception[0] = new FormatException("Format Exception");
            exception[1] = new DivideByZeroException("Divide by zero");
            exception[2] = new ArgumentException("Argument Exception");
            exception[3] = new DirectoryNotFoundException("Directory Not Found");
            exception[4] = new MyException("Exception text");
            try
            {
                throw exception[4];

            }
            catch (MyException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
    public class MyException : Exception
    {
        public MyException(string message): base(message)
        { 

        }
    }
}