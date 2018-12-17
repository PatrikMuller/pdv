using System;
using System.Collections.Generic;
using System.Text;

namespace pdvInfraestrutura.Model
{
    public class CarrinhoFormaPagamento
    {
        public int Id { get; set; }
        public Carrinho Carrinho { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public double ValorPagar { get; set; }
        public int QtdParcelas { get; set; }
        public double Juros { get; set; }
        public double ValorParcela { get; set; }
    }
}
