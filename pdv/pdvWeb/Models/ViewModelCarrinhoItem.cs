using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pdvWeb.Models
{
    public class ViewModelCarrinhoItem
    {
        public int Id { get; set; }
        public int Ordem { get; set; }
        public string Nome { get; set; }
        public double Quantidade { get; set; }
        public double Preco { get; set; }
        public double Desconto { get; set; }
        public double Total { get; set; }

        //ci.Id, ci.Ordem, ci.Item.Nome, ci.Quantidade, ci.Preco, ci.Desconto, Total
    }
}
