namespace PedidoApp.Domain;

public abstract class MetodoEntrega
{
    public abstract decimal CalcularCosto();
}

public interface IEntregaConDireccion
{
    void ProgramarDireccion(string direccion);
}

public class RetiroLocal : MetodoEntrega
{
    public override decimal CalcularCosto() => 0m;
}

public class EnvioDomicilio : MetodoEntrega, IEntregaConDireccion
{
    public string Direccion { get; private set; } = string.Empty;

    public override decimal CalcularCosto() => 5.00m;

    public void ProgramarDireccion(string direccion)
    {
        if (string.IsNullOrWhiteSpace(direccion))
            throw new ArgumentException("Dirección obligatoria");

        Direccion = direccion;
    }
}
