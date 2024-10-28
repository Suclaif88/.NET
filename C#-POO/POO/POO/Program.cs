using System;

namespace ProyectoRacional
{
//---------------------------#1-----------------------------------------
    public class Racional
    {
        private int numerador;
        private int denominador;

        public Racional()
        {
            numerador = 0;
            denominador = 1;
        }

        public Racional(int numerador, int denominador)
        {
            if (denominador == 0)
                throw new ArgumentException("El denominador no puede ser cero.");

            this.numerador = numerador;
            this.denominador = denominador;
            Simplificar();
        }

        public int Numerador => numerador;
        public int Denominador => denominador;

        public void Leer()
        {
            Console.Write("Ingrese el numerador: ");
            numerador = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el denominador: ");
            denominador = int.Parse(Console.ReadLine());

            if (denominador == 0)
                throw new ArgumentException("El denominador no puede ser cero.");

            Simplificar();
        }

        public Racional Sumar(Racional otro)
        {
            int nuevoNumerador = numerador * otro.denominador + otro.numerador * denominador;
            int nuevoDenominador = denominador * otro.denominador;
            return new Racional(nuevoNumerador, nuevoDenominador);
        }

        public Racional Restar(Racional otro)
        {
            int nuevoNumerador = numerador * otro.denominador - otro.numerador * denominador;
            int nuevoDenominador = denominador * otro.denominador;
            return new Racional(nuevoNumerador, nuevoDenominador);
        }

        public Racional Multiplicar(Racional otro)
        {
            int nuevoNumerador = numerador * otro.numerador;
            int nuevoDenominador = denominador * otro.denominador;
            return new Racional(nuevoNumerador, nuevoDenominador);
        }

        public Racional Dividir(Racional otro)
        {
            if (otro.numerador == 0)
                throw new DivideByZeroException("No se puede dividir entre cero.");

            int nuevoNumerador = numerador * otro.denominador;
            int nuevoDenominador = denominador * otro.numerador;
            return new Racional(nuevoNumerador, nuevoDenominador);
        }

        private void Simplificar()
        {
            int gcd = MCD(numerador, denominador);
            numerador /= gcd;
            denominador /= gcd;

            if (denominador < 0)
            {
                numerador = -numerador;
                denominador = -denominador;
            }
        }

        private int MCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return Math.Abs(a);
        }

        public override string ToString()
        {
            return $"{numerador}/{denominador}";
        }
    }

    //----------------------------------------------------------------------

    //---------------------------#2-----------------------------------------

    public class Cuenta
    {
        private readonly long numeroCuenta;
        private long dni;
        private double saldo;
        private double interesAnual;

        public Cuenta()
        {
            numeroCuenta = GenerarNumeroCuenta();
            dni = 0;
            saldo = 0.0;
            interesAnual = 0.0;
        }

        public Cuenta(long dni, double saldo, double interesAnual)
        {
            numeroCuenta = GenerarNumeroCuenta();
            this.dni = dni;
            this.saldo = saldo;
            this.interesAnual = interesAnual;
        }

        public long NumeroCuenta => numeroCuenta;
        public long DNI
        {
            get => dni;
            set => dni = value;
        }

        public double Saldo
        {
            get => saldo;
            set => saldo = value;
        }

        public double InteresAnual
        {
            get => interesAnual;
            set => interesAnual = value;
        }

        public void ActualizarSaldo()
        {
            double interesDiario = interesAnual / 365;
            saldo += saldo * (interesDiario / 100);
        }

        public void Ingresar(double cantidad)
        {
            if (cantidad > 0)
            {
                saldo += cantidad;
            }
            else
            {
                Console.WriteLine("La cantidad ingresada debe ser mayor a cero.");
            }
        }

        public void Retirar(double cantidad)
        {
            if (cantidad > saldo)
            {
                Console.WriteLine("Saldo insuficiente para realizar el retiro.");
            }
            else
            {
                saldo -= cantidad;
            }
        }

        public void MostrarDatos()
        {
            Console.WriteLine("Número de Cuenta: " + numeroCuenta);
            Console.WriteLine("DNI: " + dni);
            Console.WriteLine("Saldo Actual: " + saldo);
            Console.WriteLine("Interés Anual: " + interesAnual + "%");
        }

        private long GenerarNumeroCuenta()
        {
            Random random = new Random();
            return random.NextInt64(100000000000, 999999999999);
        }
    }
    //-------------------------------------------------------------------------------

    //-----------------------------3--------------------------------------------------

    public class Motor
    {
        public bool Encendido { get; private set; }

        public void Arrancar()
        {
            if (!Encendido)
            {
                Encendido = true;
                Console.WriteLine("Motor arrancado.");
            }
            else
            {
                Console.WriteLine("El motor ya está encendido.");
            }
        }

        public void Apagar()
        {
            if (Encendido)
            {
                Encendido = false;
                Console.WriteLine("Motor apagado.");
            }
            else
            {
                Console.WriteLine("El motor ya está apagado.");
            }
        }
    }

    public class Rueda
    {
        public bool Inflada { get; private set; }

        public void Inflar()
        {
            if (!Inflada)
            {
                Inflada = true;
                Console.WriteLine("Rueda inflada.");
            }
            else
            {
                Console.WriteLine("La rueda ya está inflada.");
            }
        }

        public void Desinflar()
        {
            if (Inflada)
            {
                Inflada = false;
                Console.WriteLine("Rueda desinflada.");
            }
            else
            {
                Console.WriteLine("La rueda ya está desinflada.");
            }
        }
    }

    public class Ventana
    {
        public bool Abierta { get; private set; }

        public void Abrir()
        {
            if (!Abierta)
            {
                Abierta = true;
                Console.WriteLine("Ventana abierta.");
            }
            else
            {
                Console.WriteLine("La ventana ya está abierta.");
            }
        }

        public void Cerrar()
        {
            if (Abierta)
            {
                Abierta = false;
                Console.WriteLine("Ventana cerrada.");
            }
            else
            {
                Console.WriteLine("La ventana ya está cerrada.");
            }
        }
    }

    public class Puerta
    {
        public Ventana Ventana { get; } = new Ventana();
        public bool Abierta { get; private set; }

        public void Abrir()
        {
            if (!Abierta)
            {
                Abierta = true;
                Console.WriteLine("Puerta abierta.");
            }
            else
            {
                Console.WriteLine("La puerta ya está abierta.");
            }
        }

        public void Cerrar()
        {
            if (Abierta)
            {
                Abierta = false;
                Console.WriteLine("Puerta cerrada.");
            }
            else
            {
                Console.WriteLine("La puerta ya está cerrada.");
            }
        }
    }

    public class Coche
    {
        public Motor Motor { get; } = new Motor();
        public Rueda[] Ruedas { get; } = { new Rueda(), new Rueda(), new Rueda(), new Rueda() };
        public Puerta[] Puertas { get; } = { new Puerta(), new Puerta() };

        public void ArrancarMotor()
        {
            Motor.Arrancar();
        }

        public void ApagarMotor()
        {
            Motor.Apagar();
        }

        public void InflarTodasLasRuedas()
        {
            foreach (var rueda in Ruedas)
            {
                rueda.Inflar();
            }
        }

        public void DesinflarTodasLasRuedas()
        {
            foreach (var rueda in Ruedas)
            {
                rueda.Desinflar();
            }
        }

        public void AbrirTodasLasPuertas()
        {
            foreach (var puerta in Puertas)
            {
                puerta.Abrir();
            }
        }

        public void CerrarTodasLasPuertas()
        {
            foreach (var puerta in Puertas)
            {
                puerta.Cerrar();
            }
        }

        public void MostrarEstado()
        {
            Console.WriteLine($"Motor encendido: {Motor.Encendido}");
            for (int i = 0; i < Ruedas.Length; i++)
            {
                Console.WriteLine($"Rueda {i + 1} inflada: {Ruedas[i].Inflada}");
            }
            for (int i = 0; i < Puertas.Length; i++)
            {
                Console.WriteLine($"Puerta {i + 1} abierta: {Puertas[i].Abierta}");
                Console.WriteLine($"Ventana de la puerta {i + 1} abierta: {Puertas[i].Ventana.Abierta}");
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            //------------- Ejercicio 1: Operaciones con Fracciones-------------------------
            Console.WriteLine("Inicio del Ejercicio 1: Operaciones con Fracciones (Clase Racional)");

            Racional fraccion1 = new Racional(1, 2);
            Racional fraccion2 = new Racional(3, 4);

            Console.WriteLine($"Fracción 1: {fraccion1}");
            Console.WriteLine($"Fracción 2: {fraccion2}");

            Console.WriteLine($"Suma: {fraccion1.Sumar(fraccion2)}");
            Console.WriteLine($"Resta: {fraccion1.Restar(fraccion2)}");
            Console.WriteLine($"Multiplicación: {fraccion1.Multiplicar(fraccion2)}");
            Console.WriteLine($"División: {fraccion1.Dividir(fraccion2)}");

            Console.WriteLine("Fin del Ejercicio 1\n");
            //---------------------------------------------


            //----------------- Ejercicio 2: Operaciones con Cuenta Bancaria------------------------------
            Console.WriteLine("Inicio del Ejercicio 2: Operaciones con Cuenta Bancaria (Clase Cuenta)");

            Cuenta cuenta = new Cuenta(12345678, 5000, 3.5);

            Console.WriteLine("Datos de la cuenta inicial:");
            cuenta.MostrarDatos();

            cuenta.Ingresar(1000);
            Console.WriteLine("\nDespués de ingresar 1000:");
            cuenta.MostrarDatos();

            cuenta.Retirar(2000);
            Console.WriteLine("\nDespués de retirar 2000:");
            cuenta.MostrarDatos();

            cuenta.ActualizarSaldo();
            Console.WriteLine("\nDespués de actualizar saldo con interés diario:");
            cuenta.MostrarDatos();

            Console.WriteLine("Fin del Ejercicio 2\n");
            //------------------------------------------------------


            //----------------- Ejercicio 3: Operaciones con Coche------------------------------
            Console.WriteLine("Inicio del Ejercicio 3: Operaciones con Coche (Clase Coche)");

            Coche coche = new Coche();

            coche.ArrancarMotor();
            coche.InflarTodasLasRuedas();
            coche.AbrirTodasLasPuertas();
            coche.Puertas[0].Ventana.Abrir();

            Console.WriteLine("\nEstado del coche:");
            coche.MostrarEstado();

            coche.ApagarMotor();
            coche.CerrarTodasLasPuertas();
            coche.DesinflarTodasLasRuedas();

            Console.WriteLine("\nEstado del coche después de cerrar y apagar:");
            coche.MostrarEstado();

            Console.WriteLine("Fin del Ejercicio 3");
            //------------------------------------------------------
        }
    }
}