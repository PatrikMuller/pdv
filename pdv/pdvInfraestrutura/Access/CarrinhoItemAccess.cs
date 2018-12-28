using pdvInfraestrutura.Database;
using pdvInfraestrutura.Model;
using pdvInfraestrutura.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pdvInfraestrutura.Access
{
    public class CarrinhoItemAccess
    {

        public CarrinhoItemAccess()
        {

        }


        public void Gravar(CarrinhoItem carrinhoItem)
        {
            try
            {
                using (var context = new pdvContext())
                {
                    context.Add(carrinhoItem);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                //
            }
        }

        public CarrinhoItem Ler(int id)
        {
            using (var context = new pdvContext())
            {
                return context.CarrinhoItems.Where(o => o.Id == id).SingleOrDefault();
            }
        }

        public List<CarrinhoItemViewModel> Listar(int idCarrinho)
        {
            using (var context = new pdvContext())
            {
                return (from ci in context.CarrinhoItems
                        where ci.Carrinho.Id == idCarrinho
                        select new CarrinhoItemViewModel
                        {
                            Id = ci.Id,
                            Ordem = ci.Ordem,
                            Nome = ci.Item.Nome,
                            Quantidade = ci.Quantidade,
                            Preco = ci.Preco,
                            Desconto = ci.Desconto,
                            Total = (ci.Quantidade * (ci.Preco - ci.Desconto))
                        }).ToList();
            }
        }


    }
}
