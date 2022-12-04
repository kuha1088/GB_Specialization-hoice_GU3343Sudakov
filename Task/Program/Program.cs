/* Задача:
Написать программу, которая из имеющегося массива строк формирует массив из строк, длина которых меньше либо равна 3 символа.
Первоначальный массив можно ввести с клавиатуры, либо задать на старте выполнения алгоритма.
При решении не рекомендуется пользоваться коллекциями, лучше обойтись исключительно массивами.

Примеры:
["hello","2","world",":-)"] -> ["2",":-)"]
["1234","1567","-2","computer science"] -> ["-2"]
["Russia","Denmark","Kazan"] -> []
*/

int GetNumber(string msg)
{
    Console.Write(msg);
    int userNumber = Convert.ToInt32(Console.ReadLine());;
    return userNumber;
}

string[] InitArray(int arrayLength)
{
    string[] tempArray = new string[arrayLength];
    tempArray[0] = ":-)"; // Для проверки
    
    for (int i = 1; i < tempArray.Length; i++)
    {
        tempArray[i] = InitString();
    }

    return tempArray;
}

string InitString()
{
    char[] symbols = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H',
    'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
    'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 
    'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r',
    's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3',
    '4', '5', '6', '7', '8', '9', '-', ':', ')'};

    Random rnd = new Random();
    int rndElementLength = rnd.Next(2, 10);
    string element = string.Empty;
    char rndSymbol = new char();

    for (int i = 0; i < rndElementLength; i++)
    {
        if (i == 0 || i == rndElementLength - 1) element += '"'; 
        /*
        В каждом элементе будут еще кавычки как символ =>
        нужно условие не меньше или равно 3 символа, а меньше или равно 5 символов
        */
        else
        {
            int rndSymbolNumber = rnd.Next(0, symbols.Length - 1);
            rndSymbol = symbols[rndSymbolNumber];
            element += rndSymbol;
        } 
    }

    return element;
}

void PrintUnivariateArray(string msg, string [] tempArray)
{
    Console.WriteLine($"{msg}: {string.Join(", ", tempArray)}");
}

int ElementsCount(string[] tempArray)
{
    int newArrayLength = new int();
    for(int i = 0; i < tempArray.Length; i++)
    {
        if(tempArray[i].Length <= 5 && tempArray[i].Length > 2) newArrayLength += 1;
    }

    return newArrayLength;
}


string[] ChangeArray(string [] tempArray)
{
    
    string[] newArray = new string[ElementsCount(tempArray: tempArray)];
    int count = new int();

    for(int i = 0; i < tempArray.Length; i++)
    {
        if(tempArray[i].Length <= 5 && tempArray[i].Length > 2)
        {
            count += 1;
            newArray[count - 1] = tempArray[i];
        }
    }

    return newArray;
}

int arrayLength = GetNumber(msg: "Введите длину массива: ");
Console.WriteLine();
string[] array = InitArray(arrayLength: arrayLength);
PrintUnivariateArray(msg: "Первоначальный массив", tempArray: array);
Console.WriteLine();
string[] newArray = ChangeArray(tempArray: array);
PrintUnivariateArray(msg: "Измененный массив", tempArray: newArray);
