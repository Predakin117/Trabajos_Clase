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
    internal class Accesorio : Producto, IReportable
    {
        public string categoria { get; set; }
        public bool esGaming { get; set; }
        public Accesorio(int id, string nombre, decimal precio, int stock,
                          string categoria, bool esGaming)
            : base(id, nombre, precio, stock) // llamada al constructor padre
        {
            this.categoria = categoria;
            this.esGaming = esGaming;
        }
        public override decimal CalcularPrecioFinal()
        {
            if (esGaming)
            {
                return Precio * 0.88m; // 12% descuento
            }
            return Precio;
        }
        public override void MostrarInfo()
        {
            base.MostrarInfo();
            Console.WriteLine($"categoria: {categoria} | esGaming: {esGaming} | Precio Final: ${CalcularPrecioFinal():F2}");
        }
        public string GenerarReporte()
        {
            return $"Reporte del Accesorio: ID: {Id}, Nombre: {Nombre}, Precio Final: ${CalcularPrecioFinal():F2}, Stock: {Stock}, Categoria: {categoria}, Es Gaming: {esGaming}";
        }
    }
}