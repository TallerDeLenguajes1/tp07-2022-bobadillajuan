using System;
using System.Collections.Generic;

namespace tp07_2022_bobadillajuan
{
    class Program
    {
        static int Main(string[] args){

            int contadorTarea = 0;
            
            Console.WriteLine("\nPor favor, ingrese la cantidad de Tareas a cargar: ");
            contadorTarea = Convert.ToInt32(Console.ReadLine());

            List<Tareas> TareaPendientes = new List<Tareas>();
            List<Tareas> TareaRealizadas = new List<Tareas>();

            string? descripcion;
            Random duracionRandom = new Random();

            for (int i = 1; i <= contadorTarea; i++)
            {
                do
                {
                    Console.WriteLine("Ingrese la descripcion de la tarea: " + i);
                    descripcion = Console.ReadLine();

                } while (string.IsNullOrEmpty(descripcion));

                Tareas NTarea = new Tareas();
                NTarea.Descripcion = descripcion;
                NTarea.Duracion = duracionRandom.Next(10,101);
                NTarea.TareaID = i;

                TareaPendientes.Add(NTarea);

            }

            Console.WriteLine("\n---- Mostramos la lista de Tareas Pendientes ----");
            foreach (Tareas tareaX in TareaPendientes)
            {
                Mostrar(tareaX);
            }

            return 0;
        }

        public static void Mostrar(Tareas tareas){
            
            Console.WriteLine("\n-------------\n");
            Console.WriteLine("\n Tarea ID: " + tareas.TareaID);
            Console.WriteLine("\n Descripcion de tarea: " + tareas.Descripcion);
            Console.WriteLine("\n Duración de la tarea: " + tareas.Duracion);

        }

    }
}