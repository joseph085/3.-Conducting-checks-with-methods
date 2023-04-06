namespace HRManagementProject
{
    internal class Program
    {
        //custom type
        public class Person
        {
            //fields (data)
            public string _firstName;
            public string _lastName;
            public string _fatherName;
            //public int _age;
            //public string _pin;
            //public string _phoneNumber;
            //public string _position;
            //public decimal _montlySalary;
        }

        public class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Person's count : ");
                int count = int.Parse(Console.ReadLine()!);
                Person[] persons = new Person[count];

                int i = 0;

                while (i < count)
                {
                    string firstName = GetAndValidateFirstName();
                    string lastName = GetAndValidateLastName();
                    string fatherName = GetAndValidateFatherName();
                    //int age = GetAndValidateAge();
                    //string pin = GetAndValidatePin();
                    //string phoneNumber = GetAndValidatePhoneNumber();
                    //string position = GetAndValidatePosition();
                    //decimal monthlySalary = GetAndValidateMonthlySalary();

                    Person human = new Person
                    {
                        _firstName = firstName,
                        _lastName = lastName,
                        _fatherName = fatherName,
                        //_age = age,
                        //_pin = pin,
                        //_phoneNumber = phoneNumber,
                        //_position = position,
                        //_montlySalary = monthlySalary
                    };

                    persons[i] = human;

                    //firstNames[i] = firstName;
                    //lastNames[i] = lastName;
                    //fatherNames[i] = fatherName;
                    //ages[i] = age;
                    //pins[i] = pin;
                    //phoneNumbers[i] = phoneNumber;
                    //positions[i] = position;
                    //monthlySalaries[i] = monthlySalary;

                    Console.WriteLine($"Məlumat Sistemə əlavə olundu");

                    i++;
                }

                PrintPersonsInfo(persons);
            }

            public static void PrintPersonsInfo(Person[] people)
            {
                for (int k = 0; k < people.Length; k++)
                {
                    Console.WriteLine($"First name : {people[k]._firstName}");
                    Console.WriteLine($"Last name : {people[k]._lastName}");
                    Console.WriteLine($"Father name : {people[k]._fatherName}");

                    //Console.WriteLine($"Age : {persons[k]}");
                    //Console.WriteLine($"Pin : {persons[k]}");
                    //Console.WriteLine($"Phone number : {persons[k]}");
                    //Console.WriteLine($"Position : {persons[k]}");
                    //Console.WriteLine($"Monthly salary : {persons[k]}");
                    //Console.WriteLine();
                }
            }

            #region First name

            static string GetAndValidateFirstName()
            {
                while (true)
                {
                    Console.WriteLine("Pls enter first name : ");
                    string firstName = Console.ReadLine()!;

                    if (IsValidFirstName(firstName))
                        return firstName;

                    Console.WriteLine("Some information is not correnct");
                }
            }
            static bool IsValidFirstName(string firstName)
            {
                int MIN_LENGTH = 2;
                int MAX_LENGTH = 20;

                return IsValidName(firstName, MIN_LENGTH, MAX_LENGTH);
            }

            #endregion

            #region Last name

            static string GetAndValidateLastName()
            {
                while (true)
                {
                    Console.WriteLine("Pls enter last name : ");
                    string lastName = Console.ReadLine()!;

                    if (IsValidLastName(lastName))
                        return lastName;

                    Console.WriteLine("Some information is not correnct");
                }
            }
            static bool IsValidLastName(string lastName)
            {
                int MIN_LENGTH = 2;
                int MAX_LENGTH = 30;

                return IsValidName(lastName, MIN_LENGTH, MAX_LENGTH);
            }

            #endregion

            #region Father name

            static string GetAndValidateFatherName()
            {
                while (true)
                {
                    Console.WriteLine("Pls enter father name : ");
                    string fatherName = Console.ReadLine()!;

                    if (IsValidFatherName(fatherName))
                        return fatherName;

                    Console.WriteLine("Some information is not correnct");
                }
            }
            static bool IsValidFatherName(string fatherName)
            {
                int MIN_LENGTH = 2;
                int MAX_LENGTH = 45;

                return IsValidName(fatherName, MIN_LENGTH, MAX_LENGTH);
            }

            #endregion

            #region Age

            static int GetAndValidateAge()
            {
                while (true)
                {
                    Console.WriteLine("Pls enter age : ");
                    var isParsable = TryParse(Console.ReadLine()!, out int age);
                    if (!isParsable)
                    {
                        continue;
                    }

                    //Early return 
                    if (IsLengthBetween(age, 18, 65))
                        return age;

                    Console.WriteLine("Some information is not correnct");
                }
            }

            #endregion

            #region PIN

            static string GetAndValidatePin()
            {
                while (true)
                {
                    Console.WriteLine("Pls enter pin : ");
                    string pin = Console.ReadLine()!;

                    if (IsValidPin(pin))
                        return pin;

                    Console.WriteLine("Some information is not correnct");
                }
            }
            static bool IsValidPin(string pin)
            {
                int PIN_LENGTH = 7;

                if (!IsExactLength(pin, PIN_LENGTH))
                {
                    return false;
                }

                bool isUpperLetter = false;
                bool isDigit = false;

                foreach (char character in pin)
                {
                    if (IsUpperLetter(character))
                    {
                        isUpperLetter = true;
                    }
                    else if (IsDigit(character))
                    {
                        isDigit = true;
                    }
                    else
                    {
                        return false;
                    }
                }

                return isUpperLetter && isDigit;
            }

            #endregion

            #region Phone number

            static string GetAndValidatePhoneNumber()
            {
                while (true)
                {
                    Console.WriteLine("Pls enter phone number : ");
                    string phoneNumber = Console.ReadLine()!;

                    if (IsValidPhoneNumber(phoneNumber))
                        return phoneNumber;

                    Console.WriteLine("Some information is not correnct");
                }
            }
            static bool IsValidPhoneNumber(string phoneNumber)
            {
                string[] prefixes = { "+99450", "+99455", "+99470" };

                int PHONE_NUMBER_LENGTH = 13;

                if (!IsExactLength(phoneNumber, PHONE_NUMBER_LENGTH))
                {
                    return false;
                }

                string phoneNumberPrefix = null;

                foreach (string prefix in prefixes)
                {
                    if (IsStartsWith(phoneNumber, prefix))
                    {
                        phoneNumberPrefix = prefix;
                    }
                }

                //+99450

                if (phoneNumberPrefix == null)
                    return false;

                string substring = Substring(phoneNumber, phoneNumberPrefix.Length, phoneNumber.Length - 1);

                if (!IsDigit(substring))
                {
                    return false;
                }

                return true;
            }

            #endregion

            #region Position

            static string GetAndValidatePosition()
            {
                while (true)
                {
                    Console.WriteLine("Pls enter position : ");
                    string position = Console.ReadLine()!;

                    if (IsValidPosition(position))
                        return position;


                    Console.WriteLine("Some information is not correnct");
                }
            }
            static bool IsValidPosition(string position)
            {
                //if (position == "HR")
                //{
                //    return true;
                //}
                //else if(position == "Audit")
                //{
                //    return true;
                //}
                //else if (position == "Engineer ")
                //{
                //    return true;
                //}
                //else
                //{
                //    return false;
                //}


                switch (position)
                {
                    case "HR":
                    case "Audit":
                    case "Engineer":
                        return true;

                    default:
                        return false;
                }
            }

            #endregion

            #region Monthly salary

            static decimal GetAndValidateMonthlySalary()
            {
                while (true)
                {
                    Console.WriteLine("Pls enter monthly salary : ");
                    decimal amount = decimal.Parse(Console.ReadLine()!);

                    //Early return 
                    if (IsLengthBetween(amount, 1500, 5000))
                        return amount;

                    Console.WriteLine("Some information is not correnct");
                }
            }

            #endregion

            #region Common

            static bool IsValidName(string name, int minLength, int maxLenght)
            {
                if (!IsLengthBetween(name, minLength, maxLenght))
                {
                    return false;
                }

                char firstLetter = name[0];

                if (!IsUpperLetter(firstLetter))
                {
                    return false;
                }

                for (int i = 1; i < name.Length; i++)
                {
                    if (IsUpperLetter(name[i]))
                    {
                        return false;
                    }
                }

                return true;
            }

            #endregion

            #region Utility

            public static bool TryParse(string text, out int number)
            {
                try
                {
                    number = int.Parse(text);
                    return true;
                }
                catch
                {
                    number = -1;
                    return false;
                }
            }
            public static bool IsStartsWith(string text, string startText)
            {
                if (startText.Length > text.Length)
                {
                    return false;
                }

                for (int i = 0; i < startText.Length; i++)
                {
                    if (text[i] != startText[i])
                    {
                        return false;
                    }
                }

                return true;
            }
            public static string Substring(string text, int startIdx, int endIdx)
            {
                string subString = "";

                for (int i = startIdx; i <= endIdx; i++)
                {
                    subString += text[i];
                }

                return subString;
            }
            public static string SubstringFromEnd(string text, int length)
            {
                if (text.Length <= length || length < 0)
                {
                    return default;
                }

                string subString = "";

                for (int i = text.Length - 1; i >= text.Length - length; i--)
                {
                    subString += text[i];
                }

                return Reverse(subString);
            }

            public static string Reverse(string text)
            {
                string reversed = "";

                for (int i = text.Length - 1; i >= 0; i--)
                {
                    reversed += text[i];
                }

                return reversed;
            }

            public static bool IsLengthBetween(decimal number, decimal min, decimal max)
            {
                return number > min && number < max;
            }
            public static bool IsLengthBetween(string text, int min, int max)
            {
                return text.Length > min && text.Length < max;
            }

            //Method overloading (static polymorphism)
            public static bool IsLengthBetween(int number, int min, int max)
            {
                return number > min && number < max;
            }
            public static bool IsUpperLetter(char letter)
            {
                char[] uppercaseLetters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
                                        'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

                foreach (char uppercaseLetter in uppercaseLetters) //while LOOP
                {
                    if (uppercaseLetter == letter)
                    {
                        return true;
                    }
                }

                //for (int i = 0; i < uppercaseLetters.Length; i++)
                //{
                //    if (uppercaseLetters[i] == lette)
                //    {
                //        return true;
                //    }
                //}

                return false;
            }


            public static bool IsDigit(string text)
            {
                foreach (char characted in text)
                {
                    if (!IsDigit(characted))
                    {
                        return false;
                    }
                }

                return true;
            }
            public static bool IsDigit(char digit)
            {
                char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

                foreach (char number in numbers) //Compiled to while LOOP in IL
                {
                    if (digit == number)
                    {
                        return true;
                    }
                }

                return false;
            }
            public static bool IsExactLength(string text, int length)
            {
                return text.Length == length;
            }

            #endregion
        }
    }
}
