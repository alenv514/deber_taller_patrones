namespace PedidoApp.Application;

public interface INotificadorPedido
{
    void Notificar(string mensaje);
}

public interface IRegistradorPedido
{
    void Registrar();
}

public interface IGeneradorPdfPedido
{
    void GenerarPdf();
}
