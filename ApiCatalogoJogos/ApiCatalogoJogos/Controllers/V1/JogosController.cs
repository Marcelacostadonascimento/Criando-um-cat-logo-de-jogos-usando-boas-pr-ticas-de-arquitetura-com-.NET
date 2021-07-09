using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]

    //aqui dentro da API rest temos que usar de forma padronizada os verbos em Http: GET(consulta), PUT(atualizações), PATCH(atualizações),
    //POOL(criar recurso), POST, DELETE
    public class JogosController : ControllerBase
    {
        // 2 - para gerenciar toda essa lógica vamos precisar de contratos, entramos na questão de injeção de dependência diz que temos que depender de
        //contratos e não de implementações, ao invez de criar um classe service eu recebo um contrato que no caso é uma interface onde eu consigo
        //manipular o serviço que foi implementado e isso me garante um desacoplamento, temos uma garantia melhor de código

        //vamos criar nossa propriedade

        private readonly IJogoService _jogoService; // readonly - não é de nossa responsabilidade dá uma instancia para ela, o proprio aspnet é que vai gerenciar
        //vamos criar um construtor
        public JogosController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }

        [HttpGet] // 1 - indica que é um método GET
        //vamos criar métodos como formas de interagir com nossa controller
        public async Task<ActionResult<List<JogoViewModel>>> Obter() //Task garante uma melhor performance em requisições web por conta do gerenciamento das
                                                              //aplicações
                                                              //se colocar apenas TASK ele vai esperar um retorno de Task, se adicionar ASYNC ele vai
                                                              //esperar um ActionResult<List<object>
                                                              //ActionResult é um tipo de retorno que vai indicar qual é o status http, qual é o headers
        {
            var result = await _jogoService.Obter(1, 5); // o await espera o comando seguinte ser executado, ele vira um list de JogoViewModel
            return Ok(result);
        }

        //vamos estabelece recursos através da rota

        [HttpGet("{idJogo:guid}")] //guid é um tipo, struct, é uma maneira de idenficar gerando um valor aleatório e único
        public async Task<ActionResult<JogoViewModel>> Obter(Guid idJogo) //quero obter 1 jogo através da rota
        {
            return Ok();
        }

        [HttpPost] //inserir jogo
        public async Task<ActionResult<JogoViewModel>> InserirJogo(JogoInputModel jogo)
        {
            return Ok();
        }

        [HttpPut("{idJogo:guid}")] //atualiza o recurso inteiro, tudo de uma vez só
        public async Task<ActionResult> AtualizarJogo(Guid idJogo, JogoInputModel jogo)
        {
            return Ok();
        }

        [HttpPatch("{idJogo:guid}/preco/{preco:double}")] //atualiza um item específico. Estou dizendo que quero receber o Id e o preço
        public async Task<ActionResult> AtualizarJogo(Guid idJogo, double preco)
        {
            return Ok();
        }

        [HttpDelete("{idJogo:guid}")]
        public async Task<ActionResult> ApagarJogo(Guid idJogo)
        {
            return Ok(); //aqui ele vai retornar um status 200
        }
    }
}
