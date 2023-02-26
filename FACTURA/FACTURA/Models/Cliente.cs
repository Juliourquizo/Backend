namespace FACTURA.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	public class Cliente
	{

		[Key]
		public int IdCliente { get; set; }

		public string? Name { get; set; }

		public string? Proveedor { get; set; }

		public ICollection<HojaFactura> HojaFacturas { get; set; } = null!;

		public Cliente()
		{

		}

	}
}
