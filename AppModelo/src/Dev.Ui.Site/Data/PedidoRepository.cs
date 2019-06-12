using Dev.Ui.Site.Models;

namespace Dev.Ui.Site.Data {
    public class PedidoRepository : IPedidoRepository {
        public Pedido ObterPedido() {
            return new Pedido();
        }
    }

    public interface IPedidoRepository {
        Pedido ObterPedido();
    }
}
