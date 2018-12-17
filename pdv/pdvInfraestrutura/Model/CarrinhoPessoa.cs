using System;
using System.Collections.Generic;
using System.Text;

namespace pdvInfraestrutura.Model
{
    public class CarrinhoPessoa
    {
        public int Id { get; set; }
        public Carrinho Carrinho { get; set; }
        public Pessoa Pessoa { get; set; }
        public CarrinhoPessoaTipo CarrinhoPessoaTipo { get; set; }
    }
}
