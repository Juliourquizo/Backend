namespace FACTURA.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	public class HojaFactura
	{
		[Key]
		public int IdHojaFactura { get; set; }

		public DateTime Fecha { get; set; }

		public string? Estado { get; set; }

		public string? Comentario { get; set; }

		// se puede borrar
		[ForeignKey("Cliente")]
		public int IdCliente { get; set; }

		public Cliente Cliente { get; set; } = null!;

		// declarar como una collecion vacia.
		public ICollection<Linea> Lineas { get; set; } = null!;

		public HojaFactura(DateTime fecha, string? estado, string? comentario, int idCliente)
		{
			this.Fecha = fecha;
			this.Estado = estado;
			this.Comentario = comentario;
			this.IdCliente = idCliente;
		}

		public HojaFactura() 
		{
			
		}

		public HojaFactura(int idHojaFactura, DateTime fecha, string? estado, string? comentario)
		{
			this.IdHojaFactura = idHojaFactura;
			this.Fecha = fecha;
			this.Estado = estado;
			this.Comentario = comentario;
		}


		// volver a hacerlo con el un objeto cliente.
	}

}
