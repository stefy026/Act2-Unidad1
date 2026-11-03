using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppConsole2
{
    class Producto
    {
        public int Id;
        public string Nombre;
        public Producto(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
        public void Mostrar()
        {
            Console.WriteLine($"Id: {Id}, Nombre: {Nombre}");
        }
    }
    class Program
    {
        static void Main()
        {
            int cantidad;
            Console.Write("Cantidad de productos (mayor que 0): ");
            while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad <= 0)
                Console.Write("Valor inválido, debe ser un entero mayor que 0: ");

            // El arreglo se crea en tiempo de ejecución y solo guarda referencias; los objetos Producto viven en el Heap.
            Producto[] productos = new Producto[cantidad];

            for (int i = 0; i < productos.Length; i++)
            {
                Console.Write($"Nombre del producto {i + 1}: ");
                productos[i] = new Producto(i + 1, Console.ReadLine());
            }

            Console.WriteLine("\nProductos almacenados:");
            foreach (Producto p in productos) p.Mostrar();

            //"a" y "b" son variables distintas (la referencia), pero apuntan al MISMO objeto
            Producto a = productos[0];
            Producto b = a;
            Console.WriteLine($"\n ¿Mismo objeto? {ReferenceEquals(a, b)}");

            Console.Write("Nuevo nombre para el primer producto (usando 'b'): ");
            b.Nombre = Console.ReadLine();
            Console.WriteLine("Leído con 'a': " + a.Nombre);
            Console.WriteLine("Leído en el arreglo: " + productos[0].Nombre);

        }
    }
}

