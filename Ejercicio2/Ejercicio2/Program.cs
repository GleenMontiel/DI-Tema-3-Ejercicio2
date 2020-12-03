using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{

    class Program
    {
        public static void MostrarTabla(Aula aula)
        {
            MostrarMaterias();
            for (int i = 0; i < 12; i++)
            {
                Console.Write("{0,9}", aula.NombreAlumnos[i]);
                for (int j = 0; j < 4; j++)
                {
                    Console.Write("{0,7}", aula[i, j]);
                }
                Console.WriteLine();
            }
        }

        public static void MostrarMaterias()
        {
            Console.WriteLine("{0,9}{1,7}{2,7}{3,7}{4,7}", "Alumno", EAsignaturas.DI, EAsignaturas.AD, EAsignaturas.MOVIL, EAsignaturas.SERV);
        }
        public static void MostrarNotasMaterias(Aula aula, int materia)
        {

            Console.WriteLine("{0,9}{1,7}", "Alumno", (EAsignaturas)materia);
            for (int i = 0; i < aula.NombreAlumnos.Length; i++)
            {
                Console.WriteLine("{0,9}{1,7}", aula.NombreAlumnos[i], aula[i, materia]);
            }
        }

        public static void TablaAlumnos(Aula aula)
        {
            for (int i = 0; i < aula.NombreAlumnos.Length; i++)
            {
                Console.WriteLine("{0,2}.- {1}", i + 1, aula.NombreAlumnos[i]);
            }
        }

        public static void TablaMaterias(Aula aula)
        {
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("{0,2}.- {1}", i + 1, (EAsignaturas)i);
            }
        }

        public static void MostrarNotasAlumno(Aula aula, int alumno, bool flag)
        {
            if (flag)
            {
                MostrarMaterias();
            }
            Console.Write("{0,9}", aula.NombreAlumnos[alumno]);
            for (int i = 0; i < 4; i++)
            {
                Console.Write("{0,7}", aula[alumno, i]);
            }
        }


        public static void MuestraAprobados(Aula aula)
        {
            List<int> aprobados = aula.Aprobados();
            if (aprobados.Count > 0)
            {
                MostrarMaterias();
            }
            else
            {
                Console.WriteLine("No hay aprobados :c");
            }
            foreach (int item in aprobados)
            {
                MostrarNotasAlumno(aula, item, false);
                Console.WriteLine();
            }
        }
        public static bool ComprobarRangos(int n, bool flag)
        {
            if (flag) return n > 0 && n < 13;
            else return n > 0 && n < 5;
        }
        static void Main(string[] args)
        {
            Aula aula = new Aula();
            int alumno;
            int materia;
            int opc = 0;
            bool flag;

            do
            {
                try
                {
                    Console.WriteLine("\n1.- Calcular la media de notas de toda la tabla.");
                    Console.WriteLine("2.- Media de un alumno.");
                    Console.WriteLine("3.- Media de una asignatura.");
                    Console.WriteLine("4.- Visualizar notas de un alumno.");
                    Console.WriteLine("5.- Visualizar notas de una asignatura.");
                    Console.WriteLine("6.- Nota máxima y mínima de un alumno.");
                    Console.WriteLine("7.- Tabla solo de aprobados.");
                    Console.WriteLine("8.- Visualizar tabla completa.");
                    Console.WriteLine("9.- Salir.");
                    Console.Write("Introduce opción: ");
                    opc = int.Parse(Console.ReadLine());

                    switch (opc)
                    {
                        case 1:
                            MostrarTabla(aula);
                            Console.WriteLine("La media de todas las notas del aula es: {0:F2}", aula.MediaNotas());
                            break;

                        case 2:
                            TablaAlumnos(aula);
                            flag = false;
                            do
                            {
                                try
                                {
                                    Console.WriteLine("¿De que alumno?");
                                    alumno = int.Parse(Console.ReadLine());
                                    if (ComprobarRangos(alumno, true))
                                    {
                                        Console.WriteLine("La media de {0} es: {1:F2}", aula.NombreAlumnos[alumno - 1], aula.MediaNotas(alumno - 1, true));
                                        flag = true;
                                    }
                                }
                                catch (OverflowException)
                                {
                                    Console.WriteLine("EPA");
                                }
                            } while (!flag);

                            break;

                        case 3:
                            TablaMaterias(aula);
                            flag = false;
                            do
                            {
                                try
                                {
                                    Console.WriteLine("¿De que materia?");
                                    materia = int.Parse(Console.ReadLine());
                                    if (ComprobarRangos(materia, false))
                                    {
                                        Console.WriteLine("La media de {0} es: {1:F2}", (EAsignaturas)materia - 1, aula.MediaNotas(materia - 1, false));
                                        flag = true;
                                    }
                                }
                                catch (OverflowException)
                                {
                                    Console.WriteLine("EPA");
                                }
                            } while (!flag);
                            break;

                        case 4:
                            TablaAlumnos(aula);
                            flag = false;
                            do
                            {
                                try
                                {

                                    Console.WriteLine("¿De que alumno?");
                                    alumno = int.Parse(Console.ReadLine());
                                    if (ComprobarRangos(alumno, true))
                                    {
                                        MostrarNotasAlumno(aula, alumno - 1, true);
                                        flag = true;
                                    }
                                }
                                catch (OverflowException)
                                {
                                    Console.WriteLine("EPA");
                                }
                            } while (!flag);

                            break;

                        case 5:
                            TablaMaterias(aula);
                            flag = false;
                            do
                            {
                                try
                                {
                                    Console.WriteLine("¿De que materia?");
                                    materia = int.Parse(Console.ReadLine());
                                    if (ComprobarRangos(materia, false))
                                    {
                                        MostrarNotasMaterias(aula, materia - 1);
                                        flag = true;
                                    }
                                }
                                catch (OverflowException)
                                {
                                    Console.WriteLine("EPA");
                                }
                            } while (!flag);
                            break;

                        case 6:
                            TablaAlumnos(aula);
                            flag = false;
                            do
                            {
                                try
                                {
                                    Console.WriteLine("¿De que alumno?");
                                    alumno = int.Parse(Console.ReadLine());
                                    if (ComprobarRangos(alumno, true))
                                    {
                                        aula.MaximaYMinima(alumno - 1, out int maxima, out int minima);
                                        Console.WriteLine("Alumno: {0} \nNota máxima: {1}\nNota mínima: {2}", aula.NombreAlumnos[alumno - 1], maxima, minima);
                                        flag = true;
                                    }
                                }
                                catch (OverflowException)
                                {
                                    Console.WriteLine("EPA");
                                }
                            } while (!flag);
                            break;
                        case 7:
                            MuestraAprobados(aula);
                            break;
                        case 8:
                            MostrarTabla(aula);
                            break;
                        case 9:
                            Console.WriteLine("Adios");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Introduce una opción válida");
                }

                catch (OverflowException)
                {
                    Console.WriteLine("EPA");
                }
            } while (opc != 9);
        }
    }
}
