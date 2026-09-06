using PedidoApp.Application;
using PedidoApp.Domain;

namespace PedidoApp.Infrastructure;

public class PedidoRepositoryMemoria : IPedidoRepository
{
    private readonly List<string> _pedidos = new();

    public void Guardar(Pedido pedido, decimal total)
    {
        _pedidos.Add($"{pedido.Cliente} - {total:F2}");
    }

    public IReadOnlyList<string> ObtenerTodos() => _pedidos.AsReadOnly();
}
