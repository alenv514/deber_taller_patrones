namespace PedidoApp.Domain;

public class PedidoItem
{
    public string Producto { get; private set; }
    public decimal Precio { get; private set; }
    public int Cantidad { get; private set; }

    public PedidoItem(string producto, decimal precio, int cantidad)
    {
        if (string.IsNullOrWhiteSpace(producto))
            throw new ArgumentException("El producto es obligatorio.");

        if (precio < 0)
            throw new ArgumentException("El precio no puede ser negativo.");

        if (cantidad <= 0)
            throw new ArgumentException("Cantidad incorrecta");

        Producto = producto;
        Precio = precio;
        Cantidad = cantidad;
    }

    public decimal CalcularSubtotal()
    {
        return Precio * Cantidad;
    }
}
