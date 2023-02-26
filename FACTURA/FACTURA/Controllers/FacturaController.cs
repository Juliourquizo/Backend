using FACTURA.Data;
using FACTURA.Models;
using Microsoft.AspNetCore.Mvc;
using FACTURA.ViewModels;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace FACTURA.Controllers
{
	[ApiController]
	[Route("Factura")]
	public class FacturaController : ControllerBase
	{

		FacturaContext context = new FacturaContext();

		// Prueba
		Factura factura = new Factura();

		// Listas
		List<HojaFactura> listaHojaFactura = new List<HojaFactura>();
		List<Factura> listaFactura = new List<Factura>();
		List<Linea> listaLinea = new List<Linea>();
		List<InvoiceObject> listaInvoiceObject = new List<InvoiceObject>();
		List<InvoiceLineObject> listaInvoiceLineObject = new List<InvoiceLineObject>();
		List<Cliente> listaCliente = new List<Cliente>();

		// Objeto factura simple.
		InvoiceObject invoiceObject = new InvoiceObject();
		// Objeto linea factura simple.
		InvoiceLineObject invoiceLineObject = new InvoiceLineObject();
		ErrorObject errorObject = new ErrorObject();

		// Listar facturas.
		[HttpGet("ListarFacturas")]
		public dynamic ListarFacturas()
		{

			listaHojaFactura = context.HojaFactura.ToList();

			if (!listaHojaFactura.ToList().Any())
			{
				return Ok("No se encuentra ninguna factura registrada.");
			} else
			{
				foreach (var x in listaHojaFactura)
				{
					// Prueba
					factura  = new Factura(x.IdHojaFactura, x.Fecha, x.Estado, x.Comentario);
					listaFactura.Add(factura);

					// Modelo-Objeto linea factura
					listaInvoiceLineObject = GetInvoiceLineObject(x.IdHojaFactura);

				}
				return Tuple.Create(listaFactura.ToList(), listaInvoiceLineObject.ToList());
				//return (factura + " - " + invoiceLineObject);
			}
		}


		// Metodo para obtener InvoiceObject
		/*private List<InvoiceObject> GetInvoiceObject(int id)
		{

		}*/

		// Metodo para obtener una lista de lineas segun el id de la factura.
		private List<InvoiceLineObject> GetInvoiceLineObject(int id)
		{
			listaLinea = context.Linea.ToList();

			var lineaFiltrada = from lineaF in listaLinea
								where lineaF.IdHojaFactura == id
								select lineaF;

			foreach (var x in lineaFiltrada)
			{
				if (x.IdLinea != 0)
				{
					invoiceLineObject = new InvoiceLineObject(x.IdLinea, x.Concepto, x.Cantidad, x.Precio);
					listaInvoiceLineObject.Add(invoiceLineObject);
				}
			}
			return (listaInvoiceLineObject);
		}

		// Listar las facturas segun el nombre del cliente que se el usuario detalle.

		[HttpGet("ListarInvoiceObject")]
		public dynamic ListarFacturas_NombreCliente()
		{
			string cadena;
			if (!context.HojaFactura.ToList().Any())
			{
				return Ok("No se encuentra ninguna factura registrada.");
			}
			else
			{

				cadena = GetInvoiceObject();
				return (cadena);
			}
		}
		
		private string GetInvoiceObject()
		{
			string json;
            ErrorObject errorObject400 = new ErrorObject(400, "El valor no es decimal.");
            listaCliente = context.Cliente.ToList();
			listaHojaFactura = context.HojaFactura.ToList();
			listaLinea = context.Linea.ToList();
			listaInvoiceObject = new List<InvoiceObject>();

            var opciones = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            var invoice_object = from cliente in listaCliente  
								 join hojafactura in listaHojaFactura on cliente.IdCliente equals hojafactura.IdCliente
								 join linea in listaLinea on hojafactura.IdHojaFactura equals linea.IdHojaFactura
								 select new { hojafactura.IdHojaFactura, cliente.Name, hojafactura.Fecha, valorTotal=linea.Cantidad * linea.Precio, linea };

            foreach (var x in invoice_object)
            {
				if (!(x.valorTotal is decimal))
				{
					json = errorObject400.ToString();
					return json;
				}
				else
				{
                    invoiceObject = new InvoiceObject(x.IdHojaFactura, x.Name, x.Fecha, x.valorTotal, x.linea);
                    listaInvoiceObject.Add(invoiceObject);
                }
            }

            json = JsonSerializer.Serialize(listaInvoiceObject, opciones);
            return json;
		}
		


		// Listar facturas segun el amount greater than.
		/*
		[HttpGet(Name = "Listar Facturas por coste total")]
		public dynamic ListarFacturas_PrecioFactura()
		{

		}
		*/

		// Crear factura.
		
		[HttpPost("CrearInvoiceObject")]
		public dynamic CreateInvoiceObject(InvoiceObject invoiceObject)
		{

            ErrorObject errorObject400 = new ErrorObject(400, "El objeto creado no es valido.");

			if (invoiceObject == null) 
			{
				return errorObject400;
			}
			else
			{
                return new
                {
                    success = true,
                    message = "Invoice object created",
                    result = invoiceObject
                };
            }
		}

		
		// Eliminar factura.
		[HttpDelete("EliminarInvoiceObject")]
		public dynamic DeleteInvoiceObject(InvoiceObject invoiceObject)
		{
			int idInvoice = 0;
            listaInvoiceObject = new List<InvoiceObject>();


            ErrorObject errorObject400 = new ErrorObject(400, "Error al eliminar invoice: El ID proporcionado no es un numero entero.");
            ErrorObject errorObject404 = new ErrorObject(404, "Error al eliminar invoice: No existe el ID proporcionado.");

			if (!(idInvoice is int))
			{
				return errorObject400;
			}

			var deleteInvoiceObject = from invoice in listaInvoiceObject
									  where invoice.IdHojaFactura == idInvoice
									  select invoice;

			if (deleteInvoiceObject == null) 
			{
				return errorObject404;
			}


            return ("La factura: ", invoiceObject, " ha sido eliminado");
		}
		
	}

}
