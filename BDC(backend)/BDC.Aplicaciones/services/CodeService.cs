using System;
using System.Collections.Generic;

using BDC.Dominio;
using BDC.Dominio.Interfaces.Repository;
using BDC.Aplicaciones.Interfaces;


namespace BDC.Aplicaciones.services
{
    public class CodeService : IServices_base<Codigo, Guid>
    {
        private readonly IRepository_Binfo<Codigo, Guid> repoCodigo;


        public CodeService(IRepository_Binfo<Codigo, Guid> _repoCodigo)
        {
            repoCodigo = _repoCodigo;

        }
        public List<Codigo> Listar()
        {
            return repoCodigo.Listar();
        }

        public Codigo SeleccionarPorID(Guid x)
        {
            return repoCodigo.SeleccionarPorID(x);
        }












        public List<Codigo> AgregarVarios(List<Codigo> x)
        {
            var resultcodigo = repoCodigo.AgregarVarios(x);
            repoCodigo.Guardar();
            return resultcodigo;
        }


        public Codigo Agregar(Codigo x)
        {
            var resultcodigo = repoCodigo.Agregar(x);
            repoCodigo.Guardar();
            return resultcodigo;
        }



       

    }
}
