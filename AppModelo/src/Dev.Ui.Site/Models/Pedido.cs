using System;

namespace Dev.Ui.Site.Models {
    public class Pedido {
        public Guid Id { get; set; }

        public Pedido() {
            Id = Guid.NewGuid();
        }
    }
}
