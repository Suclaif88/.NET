using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK1NET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("HOLA MUNDO");

            int n1 = 5;
            int n2 = 5;
            int final;
            final = n1 + n2;
            Console.WriteLine(final);

            //---------------------------------------

            string nombre;
            Console.WriteLine("Hola como te llamas?");
            nombre = Console.ReadLine();
            Console.WriteLine("Hola, " + nombre);

            //---------------------------------------

            string cadena, resultado;
            Console.WriteLine("Introduzca cadena de longitud > 2;");
            cadena = Console.ReadLine();
            resultado = "Longitud: " + cadena.Length +
                "\nSegundo caracter: " + cadena[1];
            Console.WriteLine(resultado);

        }
    }
}
