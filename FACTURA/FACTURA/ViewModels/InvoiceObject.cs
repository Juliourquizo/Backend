using FACTURA.Models;

namespace FACTURA.ViewModels
{
	public class InvoiceObject
	{

		public int IdHojaFactura { get; set; }
		public string? Name { get; set; }
		public DateTime Fecha { get; set; }
		public decimal CosteTotal { get; set; }
		public Linea linea { get; set; } = null!;

		public InvoiceObject(int idHojaFactura, string? name, DateTime fecha, decimal costeTotal, Linea linea)
		{
			this.IdHojaFactura = idHojaFactura;
			this.Name = name;
			this.Fecha = fecha;
			this.CosteTotal = costeTotal;
			this.linea = linea;
		}

        public InvoiceObject(int idHojaFactura, string? name, DateTime fecha, decimal costeTotal)
        {
            this.IdHojaFactura = idHojaFactura;
            this.Name = name;
            this.Fecha = fecha;
            this.CosteTotal = costeTotal;
        }

        public InvoiceObject()
		{

		}

	}
}
