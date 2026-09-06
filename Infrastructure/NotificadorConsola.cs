using PedidoApp.Application;

namespace PedidoApp.Infrastructure;

public class NotificadorConsola : INotificadorPedido
{
    public void Notificar(string mensaje)
    {
        Console.WriteLine(mensaje);
    }
}
