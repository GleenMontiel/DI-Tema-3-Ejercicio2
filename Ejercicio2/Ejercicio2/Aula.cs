using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{

    enum EAsignaturas
    {
        DI,
        AD,
        MOVIL,
        SERV
    }
    class Aula
    {
        Random r = new Random();
        private int[,] notas = new int[12, 4];
        public int this[int fila, int columna]
        {
            set
            {
                notas[fila, columna] = value;
            }
            get
            {
                return notas[fila, columna];
            }
        }

        private string[] nombreAlumnos = { "Tomas", "Roberto", "Kevin", "Jorge", "Matias", "Juan", "Adrian", "Gleen", "Jairo", "Raul", "Iris", "Emilio" };
        public string[] NombreAlumnos
        {
            set
            {
                nombreAlumnos = value;
            }
            get
            {
                return nombreAlumnos;
            }
        }

       

        public Aula()
        {
            for (int i = 0; i < this.notas.GetLength(0); i++)
            {
                for (int j = 0; j < this.notas.GetLength(1); j++)
                {
                    this.notas[i, j] = notaPonderada();
                }
            }
        }

        private int notaPonderada()
        {
            int n = r.Next(1, 101);
            if (n < 5)
            {
                return 0;
            }
            else if (n < 10)
            {
                return 1;
            }
            else if (n <= 15)
            {
                return 2;
            }
            else if (n <= 25)
            {
                return 3;
            }
            else if (n <= 40)
            {
                return 4;
            }
            else if (n <= 55)
            {
                return 5;
            }
            else if (n <= 70)
            {
                return 6;
            }
            else if (n <= 80)
            {
                return 7;
            }
            else if (n <= 90)
            {
                return 8;
            }
            else if (n <= 95)
            {
                return 9;
            }
            else
            {
                return 10;
            }
        }


        public List<int> Aprobados()
        {
            int cont = 0;

            List<int> aprobados = new List<int>();
            for (int i = 0; i < this.notas.GetLength(0); i++)
            {
                for (int j = 0; j < this.notas.GetLength(1); j++)
                {
                    if (Aprueba(this.notas[i, j]))
                    {
                        cont++;
                        if (cont == 4)
                        {
                            aprobados.Add(i);
                        }
                    }
                }
                cont = 0;
            }
            return aprobados;
        }

        public double MediaNotas()
        {
            double resultado = 0;
            int cantidad = 0;
            for (int i = 0; i < this.notas.GetLength(0); i++)
            {
                for (int j = 0; j < this.notas.GetLength(1); j++)
                {
                    resultado += this.notas[i, j];
                    cantidad = this.notas.GetLength(0) * this.notas.GetLength(1);
                }
            }
            return resultado / cantidad;
        }

        public double MediaNotas(int posicion, bool flag)
        {
            double resultado = 0;

            if (flag)
            {
                if (posicion >= 0 && posicion <= this.notas.GetLength(0))
                {
                    for (int i = 0; i < this.notas.GetLength(1); i++)
                    {
                        resultado += this.notas[posicion, i];
                    }
                }

                return resultado / this.notas.GetLength(1);

            }
            else
            {

                for (int i = 0; i < this.notas.GetLength(0); i++)
                {
                    resultado += this.notas[i, posicion];
                }

                return resultado / this.notas.GetLength(0);
            }
        }

        private bool Aprueba(int nota)
        {
            return nota >= 5;
        }

        public void MaximaYMinima(int alumno, out int maxima, out int minima)
        {
            maxima = 0;
            minima = 10;
            for (int i = 0; i < this.notas.GetLength(1); i++)
            {
                if (this.notas[alumno, i] > maxima)
                {
                    maxima = this.notas[alumno, i];
                }
                if (this.notas[alumno, i] < minima)
                {
                    minima = this.notas[alumno, i];
                }
            }
        }
    }
}
