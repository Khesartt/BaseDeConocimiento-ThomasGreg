using System;


namespace BDC.Dominio
{
    public class Usuario
    {

        public Guid id_usuario { get; set; }

        public string nombres { get; set; }

        public string apellidos { get; set; }

        public string usuario { get; set; }

        public string contraseña { get; set; }

        public string correo { get; set; }

        public string rol { get; set; }

        public Boolean activo { get; set; }





    }
}
