using PedidoApp.Domain;

namespace PedidoApp.Application;

public class RegistrarPedidoUseCase
{
    private readonly IPedidoRepository _repository;
    private readonly INotificadorPedido? _notificador;

    public RegistrarPedidoUseCase(IPedidoRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public RegistrarPedidoUseCase(IPedidoRepository repository, INotificadorPedido notificador)
        : this(repository)
    {
        _notificador = notificador;
    }

    public decimal Ejecutar(Pedido pedido, IPoliticaDescuento politicaDescuento)
    {
        ArgumentNullException.ThrowIfNull(pedido);
        ArgumentNullException.ThrowIfNull(politicaDescuento);

        decimal subtotal = pedido.CalcularSubtotal();
        decimal total = politicaDescuento.AplicarDescuento(subtotal);
        _repository.Guardar(pedido, total);
        _notificador?.Notificar($"Pedido registrado: {pedido.Cliente}");
        _notificador?.Notificar($"Total: {total:F2}");

        return total;
    }
}
