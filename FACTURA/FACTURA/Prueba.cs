/*
namespace prueba
{
	using Microsoft.Extensions.Options;
	using Microsoft.EntityFrameworkCore;
	using FACTURA.Data;
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Security.Cryptography;
	using System.Text;
	using System.Threading.Tasks;
	using prueba.Data;
	using prueba.Models;
	using Microsoft.EntityFrameworkCore.Query;
	using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

	public class Program
	{
		public static void Main(string[] args)
		{

			FacturaContext context = new FacturaContext();

			Console.WriteLine("Menú:");
			Console.WriteLine("0. Salir");
			Console.WriteLine("1. Nueva factura");
			Console.WriteLine("2. Buscar factura");

			Console.WriteLine("Elige:");
			string? opcion = Console.ReadLine();

			// Variables para añadir un cliente.
			string? nombreCliente;
			DateTime fecha;
			string? estado;
			string? comentario;
			int fk_idcliente = 0;
			int opcionLinea = 0;

			// Variables para añadir una nueva linea.
			string? concepto;
			int cantidad = 0;
			decimal precio = 0;
			int fk_hojafactura = 0;

			// Atributos para la union
			int idunion = 0;

			switch (opcion)
			{
				case "0":
					break;

				case "1":

					Console.WriteLine("Crear una factura");

					// Se le pide al usuario crear una factura completando los siguientes campos.
					Console.WriteLine("Fecha: ");
					fecha = DateTime.Parse(Console.ReadLine());
					Console.WriteLine("Estado: ");
					estado = Console.ReadLine();
					Console.WriteLine("Algun comentario: ");
					comentario = Console.ReadLine();

					// Se le pide al usuario el nombre del cliente para poder buscar su ID y añadirlo como FK a la factura.
					Console.WriteLine("Nombre del Cliente: ");
					nombreCliente = Console.ReadLine();

					// Query para obtener el objeto Cliente segun el nombre que introduzca el usuario.
					var filtroCliente = from a in context.Cliente
										where a.Name == nombreCliente
										select a;

					foreach (var ff in filtroCliente)
					{
						fk_idcliente = ff.IdCliente;
					}

					// Se crea un objeto con las variables obtenidas.
					HojaFactura factura = new HojaFactura(fecha, estado, comentario, fk_idcliente);
					context.Add(factura);
					context.SaveChanges();

					Console.WriteLine("Factura añadida");

					// Linea.
					Console.WriteLine("¿Quieres añadir una linea a la factura?");
					Console.WriteLine("Escribe 0 o 1. 0 = No, 1 = Si");
					opcionLinea = int.Parse(Console.ReadLine());

					while (opcionLinea == 1)
					{
						Console.WriteLine("Añadir línea a factura");

						Console.WriteLine("Concepto: ");
						concepto = Console.ReadLine();
						Console.WriteLine("Cantidad: ");
						cantidad = int.Parse(Console.ReadLine());
						Console.WriteLine("Precio: ");
						precio = decimal.Parse(Console.ReadLine());

						// Query para obtener el objeto HojaFactura segun los campos que ha introducido el
						// cliente previamente para crear la primera factura.
						var objetoFactura = from hf in context.HojaFactura
											where hf.Fecha == fecha
											where hf.Estado == estado
											where hf.Comentario == comentario
											select hf;

						// of = Objeto Factura.
						foreach (var of in objetoFactura)
						{
							fk_hojafactura = of.IdHojaFactura;
						}

						Linea linea = new Linea(concepto, cantidad, precio, fk_hojafactura);

						context.Add(linea);
						context.SaveChanges();
						Console.WriteLine("Linea añadida.");

						Console.WriteLine("¿Quieres añadir una linea a la factura?");
						Console.WriteLine("Escribe 0 o 1. 0 = No, 1 = Si");
						opcionLinea = int.Parse(Console.ReadLine());
					}

					if (opcionLinea == 0)
					{
						Console.WriteLine("No se añade linea.");
					}

					break;

				case "2":

					Console.WriteLine("Introduzca un nombre de cliente");
					nombreCliente = Console.ReadLine();

					var unionClienteHojaFactura = (from cl in context.Cliente
												   where cl.Name == nombreCliente
												   select cl.IdCliente).
									   Union
									   (from hoja in context.HojaFactura
										select hoja.IdCliente);

					// UCHF = Union Cliente Hoja Factura
					foreach (var uchf in unionClienteHojaFactura)
					{
						idunion = uchf;
					}

					// Union del objeto HojaFactura y Linea para obtener un objeto de linea filtrado.
					var unionHojaFacturaLinea = (from hojaf in context.HojaFactura
												 where hojaf.IdHojaFactura == idunion
												 select hojaf.IdHojaFactura).
												Union
												(from li in context.Linea
												 select li.IdHojaFactura);

					// UHFL = Union HojaFactura Linea
					foreach (var uhfl in unionHojaFacturaLinea)
					{
						idunion = uhfl;
					}

					var objetoLinea = from linead in context.Linea
									  where linead.IdHojaFactura == idunion
									  select linead;

					// Se obtiene el objeto Linea.
					foreach (var flin in objetoLinea)
					{
						Console.WriteLine("------------------------");
						Console.WriteLine($"ID: {flin.IdLinea}");
						Console.WriteLine($"Concepto: {flin.Concepto}");
						Console.WriteLine($"Cantidad: {flin.Cantidad}");
						Console.WriteLine($"Precio: {flin.Precio}");
					}

					break;
			}

			Console.WriteLine("Adios");
			Console.ReadLine();
		}
	}
}

*/