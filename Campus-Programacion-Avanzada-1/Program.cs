using System;
using System.Collections.Generic;
using System.Linq;

namespace Campus_Programacion_Avanzada_1
{
    internal class Program
    {
        public delegate void Print();
        public delegate void PrintList<T>(T[] list);
        public delegate bool CheckNumber(int number);
        static void PrintEvenNumbers()
        {
            Console.WriteLine("Numeros Pares del 1 al 100:");
            for (int i = 1; i <= 100; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write(i+" ");
                }
            }
            Console.WriteLine("");
        }

        static void PrintOddNumbers()
        {
            Console.WriteLine("");
            Console.WriteLine("Numeros Impares del 1 al 100:");
            for (int i = 1; i <= 100; i++)
            {
                if (i % 2 == 1)
                {
                    Console.Write(i+" ");
                }
            }
            Console.WriteLine("");

        }
        
        static void PrintOrderedListASC<T>(T[] list)
        {
            Console.WriteLine("");
            Console.WriteLine("Lista despues de ser ordenada (ASC): ");
            Array.Sort(list);
            
            foreach(var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("");
        }

        static void PrintOrderedListDESC<T>(T[] list)
        {
            Console.WriteLine("");
            Console.WriteLine("Lista despues de ser ordenada (DESC): ");
            Array.Reverse(list);
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("");

        }

        static bool IsNumberMultipleOf3(int number)
        {
            return number % 3 == 0;
        }

        static void PrintToConsole(string text)
        {
            Console.WriteLine(text);
        }

        static void GetMaxValue(int[] list)
        {

        }

        static float RMS_Value(int[] arr)
        {
            int square = 0;
            float mean, root = 0;

            // Calculate square
            for (int i = 0; i < arr.Length; i++)
            {
                square += (int)Math.Pow(arr[i], 2);
            }

            // Calculate Mean
            mean = (square / (float)(arr.Length));

            // Calculate Root
            root = (float)Math.Sqrt(mean);

            return root;
        }
    static void Main(string[] args)
        {
            // Imprimir numeros pares e impares del 1 al 100
            Print prnt = PrintEvenNumbers;
            prnt += PrintOddNumbers;
            prnt();


            Console.WriteLine("");
            // Imprimir lista de nombres, seguido de ordenamiento por ascendiente y descendiente.
            List<string> nombres = new List<string>();
            nombres.Add("Beto");
            nombres.Add("Abraham");
            nombres.Add("Jonathan");
            nombres.Add("Carlos");
            nombres.Add("Miguel");
            nombres.Add("Fredo");
            nombres.Add("Roberto");
            Console.WriteLine("Lista antes de ser ordenada: ");
            foreach (string nombre in nombres) 
            {
                Console.Write(nombre + " ");
            }
            Console.WriteLine("");
            PrintList < string  > printList = PrintOrderedListASC;
            printList += PrintOrderedListDESC;
            printList.Invoke(nombres.ToArray());

            Console.WriteLine("");

            // Delegado para comprobar multiplos de 3
            int n = 30;

            CheckNumber checkNumber = IsNumberMultipleOf3;

            bool result = checkNumber.Invoke(n);

            Console.Write("El numero "+ n + " es multiplo de 3? "+ result);
            Console.WriteLine("");

            List<int> numbers = new List<int>() { 5, 2, 3, 4, 5, 6 , 20, 10};

            Console.WriteLine("Lista de numeros: ");

            foreach(int number in numbers)
            {
                Console.Write(number + " ");
            }

            // Funciones anonimas con delegados Func
            Func<List<int>, string> getMaxNumber = (numbers) => "El numero maximo de la lista es: " + numbers.Max();
            Func<List<int>, string> getMinNumber = (numbers) => "El numero minimo de la lista es: " + numbers.Min();
            Func<List<int>, string> getAverageNumber = (numbers) => "El numero promedio de la lista es: " + numbers.Average();

            Func<int[], float> getRMS = RMS_Value;

            Console.WriteLine(getMaxNumber.Invoke(numbers));
            Console.WriteLine();
            Console.WriteLine(getMinNumber.Invoke(numbers));
            Console.WriteLine();
            Console.WriteLine(getAverageNumber.Invoke(numbers));
            Console.WriteLine();
            int[] numbersArr = new int[] { 20, 8, 12, 16 };
            Console.WriteLine("Arreglo de numeros: ");

            foreach (int number in numbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
            Console.WriteLine("El RMS de la lista es igual a: " + getRMS.Invoke(numbersArr));
            

            // Un ejemplo de Action, Func, y Predicate.
            Action<string> imprimirTexto = (texto) => Console.WriteLine(texto);
            imprimirTexto.Invoke("Hola Mundo");

            Func<int, bool> esMayorQueDiez = (num) => num > 10;
            Console.WriteLine("Es 5 mayor a 10?"+esMayorQueDiez.Invoke(5));

            Predicate<int> esMayorQueCinco = (num) => num > 5;
            Console.WriteLine("Es 20 mayor a 5?" + esMayorQueCinco.Invoke(20));

            // Fin de ejecucion
            Console.ReadKey();
        }
    }
}
