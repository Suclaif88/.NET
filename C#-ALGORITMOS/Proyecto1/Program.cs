using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Proyecto1
{
    internal class Actividad
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n--------------Punto 1------------------------");


            Console.WriteLine("Ingrese el primer número:");
            int num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el segundo número:");
            int num2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el tercer número:");
            int num3 = int.Parse(Console.ReadLine());

            int suma = num1 + num2 + num3;

            Console.WriteLine("La suma de los tres números es: " + suma);

            Console.WriteLine("\n---------------------------------------------");

            Console.WriteLine("\n--------------Punto 2------------------------");

            int suma, resta, multi;
            double div;

            Console.WriteLine("INGRESE EL PRIMER NUMERO:");
            int no1 = int.Parse(Console.ReadLine());
            Console.WriteLine("INGRESE EL SEGUNDO NUMERO:");
            int no2 = int.Parse(Console.ReadLine());

            suma = no1 + no2;
            resta = no1 - no2;
            multi = no1 * no2;

            if (no2 != 0)
            {
                div = (double)no1 / no2;
                Console.WriteLine($"La suma es: {suma}, La resta es: {resta}, La multiplicacion es: {multi}, La division es: {div}");
            }
            else
            {
                Console.WriteLine($"La suma es: {suma}, La resta es: {resta}, La multiplicacion es: {multi}, La division no se puede realizar porque el segundo número es 0");
            }

            Console.WriteLine("\n---------------------------------------------");


            Console.WriteLine("\n--------------Punto 3------------------------");


            Console.WriteLine("Ingrese la primera nota:");
            double nota1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la segunda nota:");
            double nota2 = double.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la tercera nota:");
            double nota3 = double.Parse(Console.ReadLine());

            double definitiva = (nota1 + nota2 + nota3) / 3;

            Console.WriteLine("La nota definitiva de la asignatura es: " + definitiva);

            Console.WriteLine("\n---------------------------------------------");

            Console.WriteLine("\n--------------Punto 4------------------------");

            Console.WriteLine("Ingrese la primera nota (20%):");
            double nota1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la segunda nota (30%):");
            double nota2 = double.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la tercera nota (50%):");
            double nota3 = double.Parse(Console.ReadLine());

            double definitiva = (nota1 * 0.2) + (nota2 * 0.3) + (nota3 * 0.5);

            Console.WriteLine($"La nota definitiva es: {definitiva}");

            Console.WriteLine("\n---------------------------------------------");


            Console.WriteLine("\n--------------Punto 5------------------------");


            Console.WriteLine("Ingrese la distancia recorrida en kilómetros:");
            double distancia = double.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el tiempo en horas:");
            double tiempo = double.Parse(Console.ReadLine());

            if (tiempo > 0)
            {
                double velocidad = distancia / tiempo;
                Console.WriteLine("La velocidad del auto es: " + velocidad + " km/h");
            }
            else
            {
                Console.WriteLine("El tiempo debe ser mayor que cero para calcular la velocidad.");
            }

            Console.WriteLine("\n---------------------------------------------");

            Console.WriteLine("\n--------------Punto 6------------------------");

            Console.WriteLine("Ingrese el valor de la compra:");
            double valorCompra = double.Parse(Console.ReadLine());

            double descuento = valorCompra * 0.10;
            double valorConDescuento = valorCompra - descuento;

            double iva = valorConDescuento * 0.19;

            double totalFactura = valorConDescuento + iva;

            Console.WriteLine($"Valor de la compra original: {valorCompra}");
            Console.WriteLine($"Descuento aplicado (10%): {descuento}");
            Console.WriteLine($"Valor después del descuento: {valorConDescuento}");
            Console.WriteLine($"IVA (19%): {iva}");
            Console.WriteLine($"Valor total de la factura: {totalFactura}");


            Console.WriteLine("\n---------------------------------------------");


            Console.WriteLine("\n--------------Punto 7------------------------");


            Console.WriteLine("Ingrese la cantidad de tiempo:");
            double tiempo2 = double.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la unidad de tiempo (horas, minutos, o segundos):");
            string unidad = Console.ReadLine().ToLower();

            double Segundos, Minutos, Horas;

            if (unidad == "horas")
            {
                Horas = tiempo2;
                Minutos = tiempo2 * 60;
                Segundos = tiempo2 * 3600;
            }
            else if (unidad == "minutos")
            {
                Horas = tiempo2 / 60;
                Minutos = tiempo2;
                Segundos = tiempo2 * 60;
            }
            else if (unidad == "segundos")
            {
                Horas = tiempo2 / 3600;
                Minutos = tiempo2 / 60;
                Segundos = tiempo2;
            }
            else
            {
                Console.WriteLine("Unidad no válida. Por favor, ingrese 'horas', 'minutos' o 'segundos'.");
                return;
            }

            Console.WriteLine("Equivalencias:");
            Console.WriteLine("Horas: " + Horas);
            Console.WriteLine("Minutos: " + Minutos);
            Console.WriteLine("Segundos: " + Segundos);

            Console.WriteLine("\n---------------------------------------------");

            Console.WriteLine("\n--------------Punto 8------------------------");

            Console.WriteLine("Ingrese el capital que desea invertir:");
            double capital = double.Parse(Console.ReadLine());

            double interes = capital * 0.02;
            double total = capital + interes;

            Console.WriteLine($"Interés ganado después de un mes: {interes}");
            Console.WriteLine($"Total después de un mes: {total}");


            Console.WriteLine("\n---------------------------------------------");


            Console.WriteLine("\n--------------Punto 9------------------------");


            Console.WriteLine("Ingrese el sueldo base del vendedor:");
            double sueldoBase = double.Parse(Console.ReadLine());

            double totalComisiones = 0;
            double porcentajeComision = 0.10;

            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"Ingrese el monto de la venta {i}:");
                double venta = double.Parse(Console.ReadLine());
                totalComisiones += venta * porcentajeComision;
            }

            double totalMes = sueldoBase + totalComisiones;

            Console.WriteLine("Comisiones por las tres ventas: $" + totalComisiones);
            Console.WriteLine("Total a recibir en el mes: $" + totalMes);

            Console.WriteLine("\n---------------------------------------------");

            Console.WriteLine("\n--------------Punto 10------------------------");

            Console.WriteLine("Ingrese el valor total de la compra:");
            double totalCompra = double.Parse(Console.ReadLine());

            double descuento = totalCompra * 0.15;
            double totalPagar = totalCompra - descuento;

            Console.WriteLine($"Descuento aplicado (15%): {descuento}");
            Console.WriteLine($"Total a pagar después del descuento: {totalPagar}");


            Console.WriteLine("\n---------------------------------------------");


            Console.WriteLine("\n--------------Punto 11------------------------");


            double sumaParciales = 0;
            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"Ingrese la calificación parcial {i}:");
                double calificacionParcial = double.Parse(Console.ReadLine());
                sumaParciales += calificacionParcial;
            }

            double promedioParciales = sumaParciales / 3;

            Console.WriteLine("Ingrese la calificación del examen final:");
            double examenFinal = double.Parse(Console.ReadLine());


            Console.WriteLine("Ingrese la calificación del trabajo final:");
            double trabajoFinal = double.Parse(Console.ReadLine());


            double calificacionFinal = (promedioParciales * 0.55) + (examenFinal * 0.30) + (trabajoFinal * 0.15);

            Console.WriteLine("La calificación final en la materia de Algoritmos es: " + calificacionFinal);

            Console.WriteLine("\n---------------------------------------------");

            Console.WriteLine("\n--------------Punto 12------------------------");

            Console.WriteLine("Ingrese el número de hombres en el grupo:");
            int hombres = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el número de mujeres en el grupo:");
            int mujeres = int.Parse(Console.ReadLine());

            int totalAlumnos = hombres + mujeres;
            double porcentajeHombres = ((double)hombres / totalAlumnos) * 100;
            double porcentajeMujeres = ((double)mujeres / totalAlumnos) * 100;

            Console.WriteLine($"Porcentaje de hombres: {porcentajeHombres}%");
            Console.WriteLine($"Porcentaje de mujeres: {porcentajeMujeres}%");


            Console.WriteLine("\n---------------------------------------------");


            Console.WriteLine("\n--------------Punto 13------------------------");


            Console.WriteLine("Ingrese el número de horas trabajadas:");
            double horasTrabajadas = double.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el valor por hora:");
            double valorPorHora = double.Parse(Console.ReadLine());

            double salario = horasTrabajadas * valorPorHora;

            Console.WriteLine("El salario es: $" + salario);

            Console.WriteLine("\n---------------------------------------------");

            Console.WriteLine("\n--------------Punto 14------------------------");

            double totalCompra = 0;

            for (int i = 1; i <= 4; i++)
            {
                Console.WriteLine($"Ingrese el precio del artículo {i}:");
                double precio = double.Parse(Console.ReadLine());

                Console.WriteLine($"Ingrese la cantidad de unidades del artículo {i}:");
                int cantidad = int.Parse(Console.ReadLine());

                double subtotal = precio * cantidad;
                totalCompra += subtotal;

                Console.WriteLine($"Subtotal del artículo {i}: {subtotal}");
            }

            double iva = totalCompra * 0.19;
            double totalFactura = totalCompra + iva;

            Console.WriteLine($"\nResumen de la factura:");
            Console.WriteLine($"Total sin IVA: {totalCompra}");
            Console.WriteLine($"IVA (19%): {iva}");
            Console.WriteLine($"Total a pagar: {totalFactura}");


            Console.WriteLine("\n---------------------------------------------");


            Console.WriteLine("\n--------------Punto 15------------------------");


            const double IVA = 0.19; 

            Console.WriteLine("Ingrese el monto de la venta:");
            double montoVenta = double.Parse(Console.ReadLine());

            double montoIVA = montoVenta * IVA;
            double totalPagar = montoVenta + montoIVA;

            Console.WriteLine("IVA (19%): $" + montoIVA);
            Console.WriteLine("Total a pagar: $" + totalPagar);

            Console.WriteLine("Ingrese la cantidad con la que paga el cliente:");
            double pagoCliente = double.Parse(Console.ReadLine());

            if (pagoCliente >= totalPagar)
            {
                double cambio = pagoCliente - totalPagar;
                Console.WriteLine("Cambio a entregar: $" + cambio);
            }
            else
            {
                Console.WriteLine("El monto ingresado es insuficiente para cubrir el total.");
            }

            Console.WriteLine("\n---------------------------------------------");

            Console.WriteLine("\n--------------Punto 16------------------------");

            Console.WriteLine("Ingrese el total recaudado en el día:");
            double totalRecaudado = double.Parse(Console.ReadLine());

            double porcentajeConductor = totalRecaudado * 0.19;

            Console.WriteLine($"Al conductor le corresponde: {porcentajeConductor}");


            Console.WriteLine("\n---------------------------------------------");


            Console.WriteLine("\n--------------Punto 17------------------------");


            const double porcentajeSalud = 0.125;
            const double porcentajePensiones = 0.16; 

            Console.WriteLine("Ingrese el salario del empleado:");
            double salarioEmpleado = double.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el valor de ahorro mensual programado:");
            double ahorroMensual = double.Parse(Console.ReadLine());

            double deduccionSalud = salarioEmpleado * porcentajeSalud;
            double deduccionPensiones = salarioEmpleado * porcentajePensiones;

            double totalDeducciones = deduccionSalud + deduccionPensiones;
            double totalRecibir = salarioEmpleado - totalDeducciones - ahorroMensual;

            Console.WriteLine("\n--- Colilla de Pago ---");
            Console.WriteLine($"Salario del Empleado: ${salarioEmpleado}");
            Console.WriteLine($"Valor de Ahorro Mensual Programado: ${ahorroMensual}");
            Console.WriteLine($"Deducción por Salud (EPS): ${deduccionSalud}");
            Console.WriteLine($"Deducción por Fondo de Pensiones: ${deduccionPensiones}");
            Console.WriteLine($"Total a Recibir: ${totalRecibir}");

            Console.WriteLine("\n---------------------------------------------");

            Console.WriteLine("\n--------------Punto 18------------------------");

            Console.WriteLine("Ingrese el valor total de la matrícula:");
            double valorMatricula = double.Parse(Console.ReadLine());

            double primeraCuota = valorMatricula * 0.40;
            double segundaCuota = valorMatricula * 0.25;
            double terceraCuota = valorMatricula * 0.20;
            double cuartaCuota = valorMatricula * 0.15;

            Console.WriteLine($"Primera cuota (40%): {primeraCuota}");
            Console.WriteLine($"Segunda cuota (25%): {segundaCuota}");
            Console.WriteLine($"Tercera cuota (20%): {terceraCuota}");
            Console.WriteLine($"Cuarta cuota (15%): {cuartaCuota}");

            Console.WriteLine("\n---------------------------------------------");


            Console.WriteLine("\n--------------Punto 19------------------------");

            Console.WriteLine("Ingrese el nombre del estudiante:");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el programa de formación:");
            string programa = Console.ReadLine();

            Console.WriteLine("Ingrese la ficha del estudiante:");
            string ficha = Console.ReadLine();

            double sumaNotas = 0;

            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"Ingrese la nota {i}:");
                double nota = double.Parse(Console.ReadLine());
                sumaNotas += nota;
            }

            double promedioFinal = sumaNotas / 5;

            Console.WriteLine("\n--- Resultados del Estudiante ---");
            Console.WriteLine($"Nombre: {nombre}");
            Console.WriteLine($"Programa de Formación: {programa}");
            Console.WriteLine($"Ficha: {ficha}");
            Console.WriteLine($"Promedio Final: {promedioFinal}");

            Console.WriteLine("\n---------------------------------------------");

            Console.WriteLine("\n--------------Punto 20------------------------");

            Console.WriteLine("Ingrese el precio de compra unitario del producto:");
            double precioUnitario = double.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la cantidad de compra:");
            int cantidad = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el descuento en porcentaje:");
            double descuentoPorcentaje = double.Parse(Console.ReadLine());

            double subtotal = precioUnitario * cantidad;
            double descuento = subtotal * (descuentoPorcentaje / 100);
            double subtotalConDescuento = subtotal - descuento;
            double iva = subtotalConDescuento * 0.19;
            double precioNeto = subtotalConDescuento + iva;

            Console.WriteLine($"Subtotal: {subtotal}");
            Console.WriteLine($"Descuento: {descuento}");
            Console.WriteLine($"Subtotal con Descuento: {subtotalConDescuento}");
            Console.WriteLine($"IVA (19%): {iva}");
            Console.WriteLine($"Precio Neto: {precioNeto}");

            Console.WriteLine("\n---------------------------------------------");

            Console.WriteLine("\n--------------Punto 21------------------------");


            Console.WriteLine("Ingrese el nombre del aprendiz:");
            string nombre1 = Console.ReadLine();

            Console.WriteLine("Ingrese la dirección del aprendiz:");
            string direccion = Console.ReadLine();

            Console.WriteLine("Ingrese el año de nacimiento del aprendiz:");
            int añoNacimiento = int.Parse(Console.ReadLine());

            int añoActual = DateTime.Now.Year;
            int edad = añoActual - añoNacimiento;

            Console.WriteLine("\n--- Información del Aprendiz ---");
            Console.WriteLine($"Nombre: {nombre1}");
            Console.WriteLine($"Dirección: {direccion}");
            Console.WriteLine($"Año de Nacimiento: {añoNacimiento}");
            Console.WriteLine($"Edad: {edad} años");

            Console.WriteLine("\n---------------------------------------------");

            Console.WriteLine("\n--------------Punto 22------------------------");

            double tiempoLlenado1Litro = 1.5;
            double tasaLlenado = 1.0 / tiempoLlenado1Litro;

            double balde3Litros = 3.0;
            double balde5Litros = 5.0;

            double tiempoBalde3 = balde3Litros / tasaLlenado;
            double tiempoBalde5 = balde5Litros / tasaLlenado;

            Console.WriteLine($"Tiempo para llenar el balde de 3 litros: {tiempoBalde3} horas");
            Console.WriteLine($"Tiempo para llenar el balde de 5 litros: {tiempoBalde5} horas");

            Console.WriteLine("\n---------------------------------------------");


            Console.WriteLine("\n--------------Punto 23------------------------");


            double alturaOriginal = 7.0;
            double tiempoOriginal = 5.0;

            double tasaSubida = alturaOriginal / tiempoOriginal;

            Console.WriteLine("Ingrese la altura de la montaña que desea subir (en metros):");
            double alturaDeseada = double.Parse(Console.ReadLine());

            double tiempoNecesario = alturaDeseada / tasaSubida;

            Console.WriteLine($"Para subir {alturaDeseada} metros, tardará {tiempoNecesario} horas.");

            Console.WriteLine("\nPunto 24");

            Console.WriteLine("\n---------------------------------------------");

            Console.WriteLine("\n--------------Punto 24------------------------");

            Console.WriteLine("Ingrese el monto del préstamo:");
            double montoPrestamo = double.Parse(Console.ReadLine());

            double tasaInteres = 0.05;
            double tiempoAnual = 1.0;
            double tiempoTrimestre = 3.0 / 12;
            double tiempoMes = 1.0 / 12;
            double plazoTotal = 5.0;

            double interesAnual = montoPrestamo * tasaInteres * tiempoAnual;
            double interesTrimestre = montoPrestamo * tasaInteres * tiempoTrimestre;
            double interesMes = montoPrestamo * tasaInteres * tiempoMes;

            double totalIntereses = interesAnual * plazoTotal;
            double totalAPagar = montoPrestamo + totalIntereses;

            Console.WriteLine($"Intereses pagados en un año: {interesAnual}");
            Console.WriteLine($"Intereses pagados en el tercer trimestre: {interesTrimestre}");
            Console.WriteLine($"Intereses pagados en el primer mes: {interesMes}");
            Console.WriteLine($"Total a pagar del préstamo incluyendo intereses: {totalAPagar}");

            Console.WriteLine("\n---------------------------------------------");
        }
    }
}
