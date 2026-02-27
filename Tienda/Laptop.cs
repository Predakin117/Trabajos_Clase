using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tienda
{
    internal class Laptop : Producto, IReportable
    {
        private int marca;
        private string ramGB;

        public string Marca { get; set; }
        public int RamGB { get; set; }


        public Laptop(int id, string nombre, decimal precio, int stock,
                      string marca, int ramGB)
            : base(id, nombre, precio, stock) // llamada al constructor padre
        {
            Marca = marca;
            RamGB = ramGB;
        }

        public override decimal CalcularPrecioFinal()
        {
            if (RamGB >= 16)
            {
                return Precio * 0.92m; // 8% descuento
            }

            return Precio;
        }

        public override void MostrarInfo()
        {
            base.MostrarInfo();
            Console.WriteLine($"Marca: {Marca} | RAM: {RamGB}GB | Precio Final: ${CalcularPrecioFinal():F2}");
        }
        public string GenerarReporte()
        {
            return $"Reporte de la Laptop: ID: {Id}, Nombre: {Nombre}, Precio Final: ${CalcularPrecioFinal():F2}, Stock: {Stock}, Marca: {Marca}, RAM: {RamGB}GB";
        }
    }
}
