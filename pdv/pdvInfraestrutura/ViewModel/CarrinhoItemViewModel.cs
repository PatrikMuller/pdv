using System;
using System.Collections.Generic;
using System.Text;

namespace pdvInfraestrutura.ViewModel
{
    public class CarrinhoItemViewModel
    {
        public int Id { get; set; }
        public int Ordem { get; set; }
        public string Nome { get; set; }
        public double Quantidade { get; set; }
        public double Preco { get; set; }
        public double Desconto { get; set; }
        public double Total { get; set; }
    }
}
