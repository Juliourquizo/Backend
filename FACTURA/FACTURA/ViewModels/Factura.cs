namespace FACTURA.ViewModels
{
	public class Factura
	{
		public int IdHojaFactura { get; set; }

		public DateTime Fecha { get; set; }

		public string? Estado { get; set; }

		public string? Comentario { get; set; }

		public Factura() 
		{ 
		
		}

		public Factura(int idHojaFactura, DateTime fecha, string? estado, string? comentario)
		{
			this.IdHojaFactura = idHojaFactura;
			this.Fecha = fecha;
			this.Estado = estado;
			this.Comentario = comentario;
		}
	}
}
