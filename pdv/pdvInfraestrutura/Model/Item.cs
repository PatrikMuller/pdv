using System;
using System.Collections.Generic;
using System.Text;

namespace pdvInfraestrutura.Model
{
    public class Item
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Fabricante Fabricante { get; set; }
        public UnidadeMedida UnidadeMedida { get; set; }
        public double Quantidade { get; set; }
        public double Preco { get; set; }
        public double Desconto { get; set; }
    }
}
