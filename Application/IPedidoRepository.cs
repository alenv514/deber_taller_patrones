using PedidoApp.Domain;

namespace PedidoApp.Application;

public interface IPedidoRepository
{
    void Guardar(Pedido pedido, decimal total);
}
