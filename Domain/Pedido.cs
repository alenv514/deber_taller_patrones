namespace PedidoApp.Domain;

public class Pedido
{
    public string Cliente { get; private set; }
    private readonly List<PedidoItem> _items = new();

    public IReadOnlyCollection<PedidoItem> Items => _items.AsReadOnly();

    public Pedido(string cliente)
    {
        if (string.IsNullOrWhiteSpace(cliente))
            throw new ArgumentException("Cliente obligatorio");

        Cliente = cliente;
    }

    public void AgregarItem(PedidoItem item)
    {
        ArgumentNullException.ThrowIfNull(item, nameof(item));
        _items.Add(item);
    }

    public decimal CalcularSubtotal()
    {
        if (_items.Count == 0)
            throw new InvalidOperationException("El pedido debe contener al menos un producto.");

        return _items.Sum(item => item.CalcularSubtotal());
    }
}
