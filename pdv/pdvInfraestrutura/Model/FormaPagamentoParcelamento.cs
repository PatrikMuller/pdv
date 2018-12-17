using System;
using System.Collections.Generic;
using System.Text;

namespace pdvInfraestrutura.Model
{
    public class FormaPagamentoParcelamento
    {
        public int Id { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public int QtdParcelas { get; set; }
        public double Juros { get; set; }
        public ParcelamentoStatus ParcelamentoStatus { get; set; }
    }
}
