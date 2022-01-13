using System;


namespace BDC.Dominio
{
    public class Comentario
    {
        public Guid id_comentario { get; set; }
        public String titulo { get; set; }
        public String comentarioText { get; set; }
        public Guid id_usuario { get; set; }




    }
}
