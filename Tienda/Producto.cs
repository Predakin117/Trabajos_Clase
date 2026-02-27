using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda
{
    public abstract class Producto
    {
        // Atributos privados (encapsulamiento)
        private int _id;
        private string _nombre;
        private decimal _precio;
        private int _stock;

        // Constructor
        public Producto(int id, string nombre, decimal precio, int stock)
        {
            _id = id;
            _nombre = nombre;
            _precio = precio > 0 ? precio : throw new ArgumentException("El precio debe ser positivo");
            _stock = stock >= 0 ? stock : 0;
        }

        // Propiedades (getters y setters)
        public int Id { get => _id; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public decimal Precio { get => _precio; set => _precio = value > 0 ? value : _precio; }
        public int Stock { get => _stock; set => _stock = value >= 0 ? value : _stock; }

        // Método abstracto (polimorfismo - abstracción)
        public abstract decimal CalcularPrecioFinal();

        // Método virtual para mostrar información
        public virtual void MostrarInfo()
        {
            Console.WriteLine($"ID: {Id} | Nombre: {Nombre} | Precio base: ${Precio:F2} | Stock: {Stock}");
        }
    }
}