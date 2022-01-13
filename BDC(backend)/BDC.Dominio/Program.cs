using System;
using System.Collections.Generic;

namespace BDC.Dominio
{
    class Program
    {
        static void Main(string[] args)
        {
            Producto producto = new Producto();
            Guid guid = Guid.NewGuid();
            producto.nombre = "prueba";
            producto.id_producto = guid;
            Console.WriteLine(producto.nombre);
            Console.WriteLine(producto.id_producto);

            //prueba de estabilidad
            //30 analistas
            //4.000.000 de solicitudes a dicha base de datos 
            List<int> aux = new List<int>();
            for (int i = 0; i < 240000000; i++)
            {
                aux.Add(i);
            }
            List<int> aux2 = new List<int>();
            foreach (var item in aux)
            {
                if (item % 2 == 0)
                {
                    aux2.Add(item);
                }

            }
            Console.WriteLine("acabe");
            
        }
    }
}
