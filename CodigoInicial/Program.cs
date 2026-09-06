
Console.WriteLine(" EJECUCIÓN DEL CÓDIGO INICIAL (ANTES DE REFACTORIZAR)");

PedidoManager manager = new PedidoManager();

List<PedidoItem> items = new List<PedidoItem>
{
    new PedidoItem { Producto = "Laptop", Precio = 800m, Cantidad = 1 },
    new PedidoItem { Producto = "Mouse", Precio = 20m, Cantidad = 2 }
};

Console.WriteLine("--- Registrando Pedido Normal ---");
manager.Registrar("Juan Perez", "NORMAL", items);

Console.WriteLine("\n--- Registrando Pedido VIP ---");
manager.Registrar("Maria Gomez", "VIP", items);

Console.WriteLine("\n==================================================");

public class PedidoManager
{
    private readonly List<string> _pedidos = new();

    public decimal Registrar(
        string cliente,
        string tipoCliente,
        List<PedidoItem> items)
    {
        if (string.IsNullOrWhiteSpace(cliente))
            throw new Exception("Cliente obligatorio");

        if (items == null || items.Count == 0)
            throw new Exception("Pedido ");

        decimal total = 0m;

        foreach (PedidoItem item in items)
        {
            if (item.Cantidad <= 0)
                throw new Exception("Cantidad incorrecta");

            total += item.Precio * item.Cantidad;
        }

        if (tipoCliente == "VIP")
            total *= 0.90m;

        _pedidos.Add($"{cliente} - {total}");

        Console.WriteLine($"Pedido registrado: {cliente}");
        Console.WriteLine($"Total: {total}");

        return total;
    }
}

public class PedidoItem
{
    public string Producto { get; set; } = "";
    public decimal Precio { get; set; }
    public int Cantidad { get; set; }
}
