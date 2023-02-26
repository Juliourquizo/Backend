namespace FACTURA.ViewModels
{
	public class ErrorObject
	{
        public int codigoError { get; set; }
        public string? Mensage { get; set; }

        public ErrorObject(int codigoError, string? mensage)
        {
            this.codigoError = codigoError;
            this.Mensage = mensage;
        }

        public ErrorObject()
        {

        }

    }
}
