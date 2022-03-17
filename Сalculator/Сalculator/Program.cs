namespace Calculator
{
    class Program
    {
        public static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите операцию:");
                Console.WriteLine("1. Сложение");
                Console.WriteLine("2. Вычитание");
                Console.WriteLine("3. Умножение");
                Console.WriteLine("4. Деление");
                int operation;
                decimal operand1;
                decimal operand2;
                try
                {
                    operation = Convert.ToInt32(Console.ReadLine());

                    if (operation < 1 || operation > 5)
                    {
                        Console.WriteLine("Неверный номер операции");
                        PressAnyKey();
                        continue;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверный формат номера операции");
                    PressAnyKey();
                    continue;
                }

                try
                {
                    Console.WriteLine("Введите первый операнд");
                    operand1 = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Введите второй операнд");
                    operand2 = Convert.ToDecimal(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверный формат операнда");
                    PressAnyKey();
                    continue;
                }

                decimal result = 0;
                switch (operation)
                {
                    case 1:
                        result = Addition(operand1, operand2);
                        break;
                    case 2:
                        result = Subtraction(operand1, operand2);
                        break;
                    case 3:
                        result = Multiplication(operand1, operand2);
                        break;
                    case 4:
                        try
                        {
                            result = Division(operand1, operand2);
                        }
                        catch (DivideByZeroException)
                        {
                            Console.WriteLine("Деление на ноль");
                            PressAnyKey();
                            continue;
                        }
                        break;
                }

                Console.WriteLine("Результат: " + result);
                PressAnyKey();
            }
        }

        private static decimal Addition(decimal operand1, decimal operand2)
        {
            return operand1 + operand2;
        }

        private static decimal Subtraction(decimal operand1, decimal operand2)
        {
            return operand1 - operand2;
        }

        private static decimal Multiplication(decimal operand1, decimal operand2)
        {
            return operand1 * operand2;
        }

        private static decimal Division(decimal operand1, decimal operand2)
        {
            if (operand2 == 0)
            {
                throw new DivideByZeroException();
            }
            return operand1 / operand2;
        }

        private static void PressAnyKey()
        {
            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }
}