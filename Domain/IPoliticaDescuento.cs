namespace PedidoApp.Domain;

public interface IPoliticaDescuento
{
    decimal AplicarDescuento(decimal subtotal);
}

public class SinDescuento : IPoliticaDescuento
{
    public decimal AplicarDescuento(decimal subtotal) => subtotal;
}

public class DescuentoVip : IPoliticaDescuento
{
    public decimal AplicarDescuento(decimal subtotal) => subtotal * 0.90m;
}
