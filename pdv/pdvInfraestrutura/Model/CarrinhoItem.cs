using System;
using System.Collections.Generic;
using System.Text;

namespace pdvInfraestrutura.Model
{
    public class CarrinhoItem
    {
        public int Id { get; set; }
        public int Ordem { get; set; }
        public Carrinho Carrinho { get; set; }
        public Item Item { get; set; }
        public double Quantidade { get; set; }
        public double Preco { get; set; }
        public double Desconto { get; set; }
    }
}
