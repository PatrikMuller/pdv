using pdvInfraestrutura.Database;
using pdvInfraestrutura.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pdvInfraestrutura.Access
{
    public class CarrinhoAccess
    {

        public CarrinhoAccess()
        {

        }

        public void Gravar(Carrinho carrinho)
        {
            try
            {
                using (var context = new pdvContext())
                {
                    context.Add(carrinho);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                //
            }
        }

        public Carrinho Ler(int id)
        {
            using (var context = new pdvContext())
            {
                return context.Carrinhos.Where(o => o.Id == id).SingleOrDefault();
            }
        }

        public List<Carrinho> Listar(int id)
        {
            using (var context = new pdvContext())
            {
                return (from ci in context.Carrinhos
                        //where ci.Id == id
                        select ci).ToList();
            }
        }

    }
}
