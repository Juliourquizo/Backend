using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FACTURA.ViewModels
{
	public class InvoiceLineObject
	{
		private InvoiceLineObject invoiceLineObject;

		[Key]
		public int IdLinea { get; set; }

		public string? Concepto { get; set; }

		public int Cantidad { get; set; }

		[Column(TypeName = "decimal(6, 2)")]
		public decimal Precio { get; set; }

		public InvoiceLineObject() 
		{
			
		}

		public InvoiceLineObject(int idLinea, string? concepto, int cantidad, decimal precio)
		{
			this.IdLinea = idLinea;
			this.Concepto = concepto;
			this.Cantidad = cantidad;
			this.Precio = precio;
		}

		public InvoiceLineObject(InvoiceLineObject invoiceLineObject)
		{
			this.invoiceLineObject = invoiceLineObject;
		}
	}
}
