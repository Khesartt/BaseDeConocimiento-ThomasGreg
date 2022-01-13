using System;


namespace BDC.Dominio
{
    public class Codigo
    {
        public Guid id_codigo { get; set; }

        public String nombre { get; set; }

        public String categoria { get; set; }

        public String descripcion { get; set; }

        public String codigo { get; set; }

        public String codigo_aux1 { get; set; }

        public String codigo_aux2 { get; set; }

        public String codigo_aux3 { get; set; }

        public String observaciones { get; set; }

        public Guid id_producto { get; set; }
        public Guid id_aplicativo { get; set; }
   


    }
}
