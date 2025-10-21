namespace ComisionesWeb.ViewModels
{
    public class ResumenComisionesRow
    {
        public int VendedorId { get; set; }
        public string NombreVendedor { get; set; } = string.Empty;
        public string Cedula { get; set; } = string.Empty;
        public int TotalVentas { get; set; }
        public decimal TotalMontoVendido { get; set; }
        public decimal TotalComisiones { get; set; }
    }
}