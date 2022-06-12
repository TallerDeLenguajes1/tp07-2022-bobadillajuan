namespace tp07_2022_bobadillajuan
{
    public class Tareas
    {
        private int tareaID;
        private string? descripcion;
        private int duracion;

        //Encapsulamiento de todas las variables.
        public int TareaID { get => tareaID; set => tareaID = value; }
        public string? Descripcion { get => descripcion; set => descripcion = value; }
        public int Duracion { get => duracion; set => duracion = value; }
    }

}