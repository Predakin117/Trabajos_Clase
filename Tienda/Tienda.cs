using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using Tienda;

namespace Tienda
{
    internal class TiendaTech
    {
        // Lista privada de productos
        private List<Producto> productos;

        // Constructor
        public TiendaTech()
        {
            productos = new List<Producto>();
        }

        // 1️⃣ AgregarProducto()
        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
        }

        // 2ListarProductos()
        public void ListarProductos()
        {
            foreach (var producto in productos)
            {
                producto.MostrarInfo(); // POLIMORFISMO
                Console.WriteLine("------------------------");
            }
        }

        // 3️⃣ BuscarPorId(int id)
        public Producto BuscarPorId(int id)
        {
            foreach (var producto in productos)
            {
                if (producto.Id == id)
                {
                    return producto;
                }
            }

            return null; // si no lo encuentra
        }

        public double CalcularTotalInventario()
        {
            double total = 0;

            foreach (var producto in productos)
            {
               
                total += (double)(producto.CalcularPrecioFinal() * producto.Stock);
            }

            return total;
        }

        // 5️⃣ GenerarReporteTodos()
        public void GenerarReporteTodos()
        {
            foreach (var producto in productos)
            {
                if (producto is IReportable reportable)
                {
                    Console.WriteLine(reportable.GenerarReporte());
                }
            }
        }
    }
}