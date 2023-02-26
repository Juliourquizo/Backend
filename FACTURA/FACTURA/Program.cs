var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


namespace FACTURA
{

    using FACTURA.Models;
    using FACTURA.ViewModels;
    using FACTURA.Controllers;
    using FACTURA.Data;



    public class Program
    {
        public static void Main(string[] args)
        {

            FacturaContext context = new FacturaContext();
            FacturaController facturaController = new FacturaController();

            int opcion = 0;
            int idhojafactura = 0;
            string nombreCliente;
            DateTime fecha;
            decimal costeTotal;
            Linea linea = new Linea();
            InvoiceObject invoiceObject = new InvoiceObject();

            Console.WriteLine("Menu para crear y/o eliminar un 'Invoice object':");
            Console.WriteLine("1 = Crear, 2 = Eliminar");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("ID de la factura");
                    idhojafactura = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Nombre del cliente");
                    nombreCliente = Console.ReadLine();
                    Console.WriteLine("Fecha (dd/mm/aaaa)");
                    fecha = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Coste total");
                    costeTotal = decimal.Parse(Console.ReadLine());
                
                    invoiceObject = new InvoiceObject(idhojafactura, nombreCliente, fecha, costeTotal);

                    facturaController.CreateInvoiceObject(invoiceObject);

                    Console.WriteLine("Quiere salir? (3 = Seguir, Otro numero = Salir)");
                    opcion = int.Parse(Console.ReadLine());
                    break;

                case 2:

                    Console.WriteLine("Escriba el ID del Invoice Object que quiera eliminar");


                    Console.WriteLine("Quiere salir? (3 = Seguir, Otro numero = Salir)");
                    opcion = int.Parse(Console.ReadLine());
                    break;

                case 3:
                    break;
            }

        }
    }

}

