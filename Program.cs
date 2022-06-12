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
                //Control para strings
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

            Console.WriteLine("\n---- Consultamos estado de las tareas ----");
            CambioDeEstado(TareaPendientes, TareaRealizadas);
            Console.WriteLine("\n---- Lista de tareas pendientes actualizada ----\n");
            foreach (Tareas tareaX in TareaPendientes)  
            {
                Mostrar(tareaX);
            }
            Console.WriteLine("\n---- Lista de tareas realizadas ----\n");
            foreach (Tareas tareaX in TareaRealizadas)
            {
                Mostrar(tareaX);
            }

            Console.WriteLine("\n---- Búsqueda de tareas por descripción ----\n");
            Console.WriteLine("\nPor favor ingrese la descripción de la tarea que quiere buscar: ");
                do
                {
                    descripcion = Console.ReadLine();
                } while (string.IsNullOrEmpty(descripcion));
            BusquedaDeTareas(TareaPendientes, descripcion);

            Console.WriteLine("\n---- Total de horas trabajadas por el empleado ----\n");
            HorasTrabajadas(TareaRealizadas);


            return 0;
        }

        public static void Mostrar(Tareas tareas){
            
            Console.WriteLine("\n-------------\n");
            Console.WriteLine("\n Tarea ID: " + tareas.TareaID);
            Console.WriteLine("\n Descripcion de tarea: " + tareas.Descripcion);
            Console.WriteLine("\n Duración de la tarea: " + tareas.Duracion);

        }

        public static void CambioDeEstado(List<Tareas> tareasPendientes, List <Tareas> tareasRealizadas){

            int controlador = 0, i = 0;

            while (i < tareasPendientes.Count)
            {
                
                Mostrar(tareasPendientes[i]);
                Console.WriteLine("\n¿Fue realizada esta tarea? 1) Sí. ---- 2) No.");
                do
                {
                controlador = Convert.ToInt32(Console.ReadLine());
                } while (controlador != 1 && controlador != 2);

                if (controlador == 1){   
                tareasRealizadas.Add(tareasPendientes[i]);
                //No me deja borrar utilizando foreach y remove
                tareasPendientes.RemoveAt(i);
                }else{
                i++;
                }
                
            }

        }

        public static void BusquedaDeTareas(List <Tareas> tareasPendientes, string descripcion){
            
            int controlador = 0;
            foreach (Tareas tareaX in tareasPendientes)
            {
                if (tareaX.Descripcion == descripcion)
                {
                    Console.WriteLine("\n¡Tarea encontrada!");
                    Mostrar(tareaX);
                    controlador++;
                }
            }
            if (controlador != 1)
            Console.WriteLine("\n¡Tarea no encontrada!");
        }

        public static void HorasTrabajadas(List <Tareas> tareasRealizadas){

            int sumador = 0;
            foreach (Tareas tareaX in tareasRealizadas)
            {
                sumador = sumador + tareaX.Duracion;

            }

            Console.WriteLine("\nCantidad de horas trabajadas por el empleado: " + sumador);

        }

    }
}