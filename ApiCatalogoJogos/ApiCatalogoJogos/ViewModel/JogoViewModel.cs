using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.ViewModel //qdo retornar esse jogo eu preciso saber o ID pelo menos
{
    public class JogoViewModel
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Produtora { get; set; }
        public double Preco { get; set; }
    }
}
