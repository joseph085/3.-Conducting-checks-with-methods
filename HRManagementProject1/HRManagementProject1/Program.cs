namespace HRManagementProject1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string[] currencies = { "USD", "EUR", "RUB" };
            //decimal[] currencyRates = { 1.70M, 1.82M, 0.02M };

            //string SHOW_CURRENCY_RATES_COMMAND = "/show-currency-rates";
            //string FIND_CURRENCY_RATE_BY_CODE = "/find-currency-rate-by-cod";
            //string CAULCULATE_AMOUNT_BY_CURRENCY_RATE_BY_CODE = "/calculate-amount-by-currecy-code";
            //string EXIT_COMMAND = "/exit";


            //Console.WriteLine("Available commands : ");
            //Console.WriteLine(SHOW_CURRENCY_RATES_COMMAND);
            //Console.WriteLine(FIND_CURRENCY_RATE_BY_CODE);
            //Console.WriteLine(CAULCULATE_AMOUNT_BY_CURRENCY_RATE_BY_CODE);
            //Console.WriteLine(EXIT_COMMAND);

            //while (true)
            //{
            //    Console.WriteLine();
            //    Console.Write("Pls enter command : ");
            //    string command = Console.ReadLine();
            //    Console.WriteLine();

            //    if (command == SHOW_CURRENCY_RATES_COMMAND)
            //    {
            //        ExecuteShowCurrencyRatesCommand(currencyRates, currencies); //METHOD CALL
            //    }
            //    else if (command == FIND_CURRENCY_RATE_BY_CODE)
            //    {
            //        ExecuteFindCurrencyRateByCodeCommand(currencyRates, currencies);
            //    }
            //    else if (command == CAULCULATE_AMOUNT_BY_CURRENCY_RATE_BY_CODE)
            //    {
            //        ExecuteCalculateAmountByCurrencyRateByCode(currencyRates, currencies);
            //    }
            //    else if (command == EXIT_COMMAND)
            //    {
            //        ExecuteExitCommand();

            //        break;
            //    }
            //    else
            //    {
            //        Console.WriteLine("Specified command not found");
            //    }
            //}

        }


        /// <summary>
        /// Executes show currency rates functionality
        /// </summary>
        public static void ExecuteShowCurrencyRatesCommand(decimal[] currencyRates, string[] currencies)
        {
            for (int idx = 0; idx < currencyRates.Length; idx++)
            {
                Console.WriteLine($"Currency : {currencies[idx]}, Rate : {currencyRates[idx]}");
            }
        }
        public static void ExecuteFindCurrencyRateByCodeCommand(decimal[] currencyRates, string[] currencies)
        {
            Console.Write("Pls enter code : ");
            string currencyCode = Console.ReadLine();

            decimal currencyRate = FindCurrenyRateByCode(currencyRates, currencies, currencyCode);
            if (currencyRate == -1)
            {
                Console.WriteLine("Alpha3 code not found");
            }
            else
            {
                Console.WriteLine($"Currency code : {currencyCode}, rate : {currencyRate}");
            }
        }
        public static void ExecuteCalculateAmountByCurrencyRateByCode(decimal[] currencyRates, string[] currencies)
        {
            decimal amount = 0;
            string amountInput;

            do
            {
                Console.Write("Pls enter amount : ");
                amountInput = Console.ReadLine();

            } while (!TryConvert(amountInput, out amount));


            Console.Write("Pls enter code : ");
            string currencyCode = Console.ReadLine();

            decimal currencyRate = FindCurrenyRateByCode(currencyRates, currencies, currencyCode);
            if (currencyRate == -1)
            {
                Console.WriteLine("Alpha3 code not found");
            }
            else
            {
                Console.WriteLine($"Amount in target currency rate : {amount / currencyRate}");
            }

        }
        public static void ExecuteExitCommand()
        {
            Console.WriteLine("Thanks for using, bye-bye");
        }

        public static decimal FindCurrenyRateByCode(decimal[] argCurrencyRates, string[] argCurrencies, string argSpecifiedCode)
        {
            decimal DEFAULT_CURRENCY_RATE = -1;

            for (int i = 0; i < argCurrencies.Length; i++)
            {
                if (argCurrencies[i] == argSpecifiedCode)
                {
                    return argCurrencyRates[i];
                }
            }

            return DEFAULT_CURRENCY_RATE;
        }


        static bool TryConvert(string input, out decimal amount)
        {
            decimal DEFAULT_AMOUNT = -1;

            try
            {
                amount = int.Parse(input);
                return true;
            }
            catch
            {
                amount = DEFAULT_AMOUNT;
                return false;
            }
        }
    }
}