using System;
using System.Text.RegularExpressions;
using Tienda;
using Tienda;

TiendaTech tienda = new TiendaTech();
bool salir = false;

while (!salir)
{
    Console.WriteLine("\n===== TIENDATECH - GESTIÓN DE INVENTARIO =====");
    Console.WriteLine("1. Registrar Laptop");
    Console.WriteLine("2. Registrar Teléfono");
    Console.WriteLine("3. Registrar Accesorio");
    Console.WriteLine("4. Listar todos los productos");
    Console.WriteLine("5. Buscar producto por ID");
    Console.WriteLine("6. Ver total del inventario ($)");
    Console.WriteLine("7. Generar reporte completo");
    Console.WriteLine("0. Salir");
    Console.Write("Seleccione una opción: ");

    string opcion = Console.ReadLine();

    try
    {
        switch (opcion)
        {
            case "1":
                RegistrarLaptop();
                break;

            case "2":
                RegistrarTelefono();
                break;

            case "3":
                RegistrarAccesorio();
                break;

            case "4":
                tienda.ListarProductos();
                break;

            case "5":
                Console.Write("Ingrese ID a buscar: ");
                int idBuscar = int.Parse(Console.ReadLine());

                var producto = tienda.BuscarPorId(idBuscar);

                if (producto != null)
                    producto.MostrarInfo();
                else
                    Console.WriteLine("Producto no encontrado.");
                break;

            case "6":
                Console.WriteLine($"Total inventario: ${tienda.CalcularTotalInventario():F2}");
                break;

            case "7":
                tienda.GenerarReporteTodos();
                break;

            case "0":
                salir = true;
                break;

            default:
                Console.WriteLine("Opción inválida.");
                break;
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Error: Entrada inválida. Debe ingresar un número válido.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error inesperado: {ex.Message}");
    }
}

void RegistrarTelefono()
{
    Console.Write("ID: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Nombre: ");
    string nombre = Console.ReadLine();
    Console.Write("Precio: ");
    decimal precio = decimal.Parse(Console.ReadLine());
    Console.Write("Stock: ");
    int stock = int.Parse(Console.ReadLine());
    Console.Write("Sistema Operativo: ");
    string sistemaOperativo = Console.ReadLine();
    Console.Write("Cámara (MP): ");
    int camaraMP = int.Parse(Console.ReadLine());
    tienda.AgregarProducto(new Telefono(id, nombre, precio, stock, sistemaOperativo, camaraMP));
    Console.WriteLine("Teléfono registrado correctamente.");
}

void RegistrarAccesorio()
{
    Console.Write("ID: ");
    int id = int.Parse(Console.ReadLine());

    Console.Write("Nombre: ");
    string nombre = Console.ReadLine();

    Console.Write("Precio: ");
    decimal precio = decimal.Parse(Console.ReadLine());

    Console.Write("Stock: ");
    int stock = int.Parse(Console.ReadLine());

    Console.Write("Categoría: ");
    string categoria = Console.ReadLine();

    Console.Write("¿Es gaming? (true/false): ");
    bool esGaming = bool.Parse(Console.ReadLine());

    tienda.AgregarProducto(new Accesorio(id, nombre, precio, stock, categoria, esGaming));

    Console.WriteLine("Accesorio registrado correctamente.");
}

void RegistrarLaptop()
{
    Console.Write("ID: ");
    int id = int.Parse(Console.ReadLine());

    Console.Write("Nombre: ");
    string nombre = Console.ReadLine();

    Console.Write("Precio: ");
    decimal precio = decimal.Parse(Console.ReadLine());

    Console.Write("Stock: ");
    int stock = int.Parse(Console.ReadLine());

    Console.Write("Marca: ");
    String Marca = (Console.ReadLine());

    Console.Write("RAM (GB): ");
    int RamGB = int.Parse(Console.ReadLine());

    tienda.AgregarProducto(new Laptop(id, nombre, precio, stock, Marca, RamGB));

    Console.WriteLine("Laptop registrada correctamente.");
}