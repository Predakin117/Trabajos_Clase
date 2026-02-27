using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Tienda;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tienda
{
    internal class Telefono : Producto, IReportable
    {
        public string SistemaOperativo { get; set; }
        public int CamaraMP { get; set; }

        public Telefono(int id, string nombre, decimal precio, int stock, string sistemaOperativo, int camaraMP)
            : base(id, nombre, precio, stock)
        {
            this.SistemaOperativo = sistemaOperativo;
            this.CamaraMP = camaraMP;

        }
        public override decimal CalcularPrecioFinal()
        {
            if (CamaraMP >= 150)
            {
                return Precio * 0.95m; // 5% descuento
            }

            return Precio;
        }

        public override void MostrarInfo()
        {
            base.MostrarInfo();
            Console.WriteLine($"SistemaOpearivo: {SistemaOperativo} | CamaraMp: {CamaraMP}pixeles | Precio Final: ${CalcularPrecioFinal():F2}");
        }
        public string GenerarReporte()
        {
            return $"Reporte del Telefono: ID: {Id}, Nombre: {Nombre}, Precio Final: ${CalcularPrecioFinal():F2}, Stock: {Stock}, SistemaOperativo: {SistemaOperativo}, CamaraMP: {CamaraMP}";
        }
    }
}