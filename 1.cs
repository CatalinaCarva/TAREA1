using System;
using System.Collections.Generic;
using System.Linq;

namespace EmpresaSalarios
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<string> cedulas = new List<string>();
            List<string> nombres = new List<string>();
            List<int> tipos = new List<int>();
            List<double> horasLaboradas = new List<double>();
            List<double> preciosPorHora = new List<double>();

            string opcion = "s";

            while (opcion.Equals("s"))
            {
                Console.WriteLine("Ingrese la cédula del empleado: ");
                cedulas[x] = Console.ReadLine();
                
                Console.WriteLine("Ingrese el nombre del empleado: ");
                nombres[x]= Console.ReadLine();
                
                int tipo;
                do
                {
                    Console.WriteLine("Ingrese el tipo de empleado (1-Operario, 2-Técnico, 3-Profesional): ");
                    tipo = int.Parse(Console.ReadLine());
                } while (tipo < 1 || tipo > 3);
                tipos(tipo);

                Console.WriteLine("Ingrese la cantidad de horas laboradas: ");
                horasLaboradas.[x] (double.Parse(Console.ReadLine()));
                
                Console.WriteLine("Ingrese el precio por hora: ");
                preciosPorHora.[x](double.Parse(Console.ReadLine()));

                Console.WriteLine("¿Desea continuar (s/n)?");
                opcion = Console.ReadLine().ToLower();
            }

            for (int i = 0; i < cedulas.Count; i++)
            {
                double salarioOrdinario = horasLaboradas[i] * preciosPorHora[i];
                double aumento = 0;
                switch (tipos[i])
                {
                    case 1:
                        aumento = salarioOrdinario * 0.15;
                        break;
                    case 2:
                        aumento = salarioOrdinario * 0.10;
                        break;
                    case 3:
                        aumento = salarioOrdinario * 0.05;
                        break;
                }
                double salarioBruto = salarioOrdinario + aumento;
                double deduccionCCSS = salarioBruto * 0.0917;
                double salarioNeto = salarioBruto - deduccionCCSS;

                string tipoEmpleado = tipos[i] switch
                {
                    1 => "Operario",
                    2 => "Técnico",
                    3 => "Profesional",
                    _ => "Desconocido"
                };

                Console.WriteLine("\nDatos del Empleado:");
                Console.WriteLine("Cédula: {cedulas[i]}");
                Console.WriteLine("Nombre Empleado: {nombres[i]}");
                Console.WriteLine("Tipo Empleado: {tipoEmpleado}");
                Console.WriteLine("Salario por Hora: {preciosPorHora[i]}");
                Console.WriteLine("Cantidad de Horas: {horasLaboradas[i]}");
                Console.WriteLine("Salario Ordinario: {salarioOrdinario}");
                Console.WriteLine("Aumento: {aumento}");
                Console.WriteLine("Salario Bruto: {salarioBruto}");
                Console.WriteLine("Deducción CCSS: {deduccionCCSS}");
                Console.WriteLine("Salario Neto: {salarioNeto}");
            }

            var estadisticas = tipos.Select((t, index) => new { Tipo = t, SalarioNeto = horasLaboradas[index] * preciosPorHora[index] })
                                    .GroupBy(e => e.Tipo)
                                    .Select(grupo => new
                                    {
                                        Tipo = grupo.Key,
                                        Cantidad = grupo.Count(),
                                        AcumuladoSalarioNeto = grupo.Sum(e => e.SalarioNeto),
                                        PromedioSalarioNeto = grupo.Average(e => e.SalarioNeto)
                                    });

            foreach (var est in estadisticas)
            {
                string tipoEmpleado = est.Tipo switch
                {
                    1 => "Operarios",
                    2 => "Técnicos",
                    3 => "Profesionales",
                
                };

                Console.WriteLine("\nEstadísticas para {tipoEmpleado}:");
                Console.WriteLine("Cantidad de Empleados: {est.Cantidad}");
                Console.WriteLine("Acumulado Salario Neto: {est.AcumuladoSalarioNeto}");
                Console.WriteLine("Promedio Salario Neto: {est.PromedioSalarioNeto}");
            }

            Console.ReadLine();
        }
    }
}