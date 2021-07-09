using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.InputModel
{
    //qdo estamos criando um jogo o ID não é de responsabilidade do usuario
    //a entrada é diferente da saida
    public class JogoInputModel
    {
        //data annotations é uma forma de vc decorar um atributo e ai ele valida o modo state dessa model, isso é feito no próprio pipeline (middler)
        //do .NET CORE 
        [required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome do jogo deve ter entre 3 e 100 caracteres")] //regras
        public string Nome { get; set; }
        [required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O nome do jogo deve ter entre 1 e 100 caracteres")]
        public String Produtora { get; set; }
        [required]
        [Range(1,100, ErrorMessage = "O preço deve ser no mínimo 1 real e no máximo 100 reais")]
        public double Preco { get; set; }
    }
}
