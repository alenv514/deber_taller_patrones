using PedidoApp.Application;
using PedidoApp.Domain;
using PedidoApp.Infrastructure;

IPedidoRepository repositorio = new PedidoRepositoryMemoria();
INotificadorPedido notificador = new NotificadorConsola();
RegistrarPedidoUseCase useCase = new RegistrarPedidoUseCase(repositorio, notificador);

IPoliticaDescuento sinDescuento = new SinDescuento();
IPoliticaDescuento descuentoVip = new DescuentoVip();

string caso = args.Length > 0 ? args[0] : "todos";

if (caso == "1" || caso == "todos")
{
    Console.WriteLine("CASO 1: Pedido NORMAL válido");
    try
    {
        Pedido pedidoNormal = new Pedido("Carlos Benitez");
        pedidoNormal.AgregarItem(new PedidoItem("Teclado Mecánico", 60.00m, 2));
        pedidoNormal.AgregarItem(new PedidoItem("Mouse Pad XL", 20.00m, 1));

        decimal totalNormal = useCase.Ejecutar(pedidoNormal, sinDescuento);
        Console.WriteLine($"Pedido procesado exitosamente. Total cobrado: ${totalNormal:F2}\n");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"[ERROR]: {ex.Message}\n");
    }
}

if (caso == "2" || caso == "todos")
{
    Console.WriteLine("CASO 2: Pedido VIP válido (Aplica 10% de descuento)");
    try
    {
        Pedido pedidoVip = new Pedido("Ana Morales (Cliente VIP)");
        pedidoVip.AgregarItem(new PedidoItem("Monitor Gamer 144Hz", 300.00m, 1));
        pedidoVip.AgregarItem(new PedidoItem("Auriculares Inalámbricos", 100.00m, 1));

        decimal totalVip = useCase.Ejecutar(pedidoVip, descuentoVip);
        Console.WriteLine($"Pedido VIP procesado con descuento. Total final: ${totalVip:F2}\n");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"[ERROR]: {ex.Message}\n");
    }
}

if (caso == "3" || caso == "todos")
{
    Console.WriteLine("CASO 3: Pedido con cantidad 0 (Debe ser rechazado)");
    try
    {
        Pedido pedidoInvalido = new Pedido("Cliente Inválido");
        Console.WriteLine("Intentando crear un PedidoItem con cantidad = 0...");
        PedidoItem itemInvalido = new PedidoItem("Memoria USB", 15.00m, 0);
        pedidoInvalido.AgregarItem(itemInvalido);

        useCase.Ejecutar(pedidoInvalido, sinDescuento);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"RECHAZADO POR DOMINIO: {ex.Message}");
        Console.WriteLine("El modelo de dominio protegió la regla de negocio y rechazó la cantidad 0.\n");
    }
}

if (caso == "4" || caso == "todos")
{
    Console.WriteLine("CASO 4: RetiroLocal (Cumplimiento de LSP)");
    try
    {
        MetodoEntrega retiro = new RetiroLocal();
        decimal costo = retiro.CalcularCosto();
        Console.WriteLine($"Método: {retiro.GetType().Name}");
        Console.WriteLine($"Costo de entrega calculado: ${costo:F2}");
        Console.WriteLine("Costo 0 calculado sin lanzar NotSupportedException (Principio LSP respetado).\n");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"[ERROR INESPERADO]: {ex.Message}\n");
    }
}
