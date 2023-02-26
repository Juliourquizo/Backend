namespace FACTURA.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using Microsoft.EntityFrameworkCore.Metadata.Internal;

	public class Linea
	{
		[Key]
		public int IdLinea { get; set; }

		public string? Concepto { get; set; }

		public int Cantidad { get; set; }

		[Column(TypeName = "decimal(6, 2)")]
		public decimal Precio { get; set; }

		[ForeignKey("HojaFactura")]
		public int IdHojaFactura { get; set; }

		public HojaFactura HojaFactura { get; set; } = null!;

		public Linea(string? concepto, int cantidad, decimal precio, int idHojaFactura)
		{
			this.Concepto = concepto;
			this.Cantidad = cantidad;
			this.Precio = precio;
			this.IdHojaFactura = idHojaFactura;
		}

		public Linea() 
		{ 
			
		}
	}
}
