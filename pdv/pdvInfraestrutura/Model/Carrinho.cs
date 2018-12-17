using System;
using System.Collections.Generic;
using System.Text;

namespace pdvInfraestrutura.Model
{
    public class Carrinho
    {
        public int Id { get; set; }
        public DateTime DataAbertura { get; set; }
        public string LoginUsuarioAbertura { get; set; }
        public DateTime? DataFechamento { get; set; }
        public string LoginUsuarioFechamento { get; set; }
    }
}
