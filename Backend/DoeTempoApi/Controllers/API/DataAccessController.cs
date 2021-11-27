using DoeTempoApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoeTempoApi.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class DataAccessController : ControllerBase
    {

        private readonly Contexto _context;

        public DataAccessController(Contexto context)
        {
            _context = context;
        }

        [HttpGet] //Tipo de requisição
        [ActionName("TestingApi")] //Nome da funçao, onde vai ser chamado na API
        public string RetornaString()
        {
            return "teste";
        }

        [HttpPost]
        [ActionName("CadastroUsuario")]
        public async Task<IActionResult> CadastroUsuario([Bind("Email, Senha, Nome, Sobrenome, Idade, Celular, EnderecoCep, EnderecoNumero,Cidade, Estado")] TBUsuario usuario)
        {
            double idAleatorio = double.Parse(DateTime.Now.ToString("ddMMyyHHmmssff"));
            usuario.Id = idAleatorio;
            string errorMessage = "";
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(usuario);
                    await _context.SaveChangesAsync();
                    return StatusCode(200);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    errorMessage = $"Erro ao salvar cadastro: {e.InnerException.Message}";
                }
            }
            return StatusCode(400, errorMessage);
        }

        [HttpPost]
        [ActionName("CadastroDoador")]
        public async Task<IActionResult> CadastroDoador([Bind("Email, Senha, Nome, Sobrenome, Idade, Celular, EnderecoCep, EnderecoNumero, Cidade, Estado, Competencia1, Competencia2, Competencia3, Competencia4, Competencia5")] TBDoador doador)
        {
            double idAleatorio = double.Parse(DateTime.Now.ToString("ddMMyyHHmmssff"));
            string senhaCriptografada; //criptografar a senha
            doador.Id = idAleatorio;
            string errorMessage = "";
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(doador);
                    await _context.SaveChangesAsync();
                    return StatusCode(200);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    errorMessage = $"Erro ao salvar cadastro: {e.InnerException.Message}";
                }
            }
            return StatusCode(400, errorMessage);
        }

        [HttpPost]
        [ActionName("LoginUsuario")]
        public IActionResult LoginUsuario(string email, string senha)
        {
            try
            {
                var usuario = _context.TBUsuario
                   .Where(s => s.Email == email)
                   .Where(s => s.Senha == senha)
                   .ToList();
                if (usuario.Count == 1)
                {
                    return StatusCode(200, usuario[0].Id.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return StatusCode(401, "Erro ao Autorizar, e-mail ou senha incorretos");
        }

        [HttpPost]
        [ActionName("LoginDoador")]
        public IActionResult LoginDoador(string email, string senha)
        {
            try
            {
                var doador = _context.TBDoador
                   .Where(s => s.Email == email)
                   .Where(s => s.Senha == senha)
                   .ToList();
                if (doador.Count == 1)
                {
                    return StatusCode(200, doador[0].Id.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return StatusCode(401, "Erro ao Autorizar, e-mail ou senha incorretos");
        }

        [HttpPost]
        [ActionName("BuscarDoacao")]
        public List<RetornoDoador> BuscarDoacao(double id, string competencia)
        {
            //Busca os dados do usuário baseado no input de ID que ele manda no request
            var usuario = _context.TBUsuario
                .Where(s => s.Id == id)
                .ToList();

            //Busca os doadores do mesmo estado que o usuário
            var doadores = _context.TBDoador
                .Where(s => s.Estado == usuario[0].Estado.ToString())
                .Where(s => s.Competencia1 == competencia ||
                            s.Competencia2 == competencia ||
                            s.Competencia3 == competencia ||
                            s.Competencia4 == competencia ||
                            s.Competencia5 == competencia)
                .ToList();

            List<RetornoDoador> listaDoadores = new List<RetornoDoador>();
            for(int i = 0; i < doadores.Count; i++)
            {
                listaDoadores.Add(new RetornoDoador(doadores[i].Id, doadores[i].Nome, doadores[i].Sobrenome, doadores[i].Email, doadores[i].Celular, doadores[i].Cidade, doadores[i].Estado, competencia));
            }

            //entityCollection.Where(entity => entity.Property1 == 1 || entity.Property1 == 2 || entity.Property1 == 3);

            return listaDoadores;
        }

        [HttpPost]
        [ActionName("AdicionarDoador")]
        public IActionResult AdicionarDoador(double idUsuario, double idDoador, string competencia)
        {
            try { 
            var usuario = _context.TBUsuario
                .Where(s => s.Id == idUsuario)
                .ToList();

            var doador = _context.TBDoador
                .Where(s => s.Id == idDoador)
                .Where(s => s.Competencia1 == competencia ||
                            s.Competencia2 == competencia ||
                            s.Competencia3 == competencia ||
                            s.Competencia4 == competencia ||
                            s.Competencia5 == competencia)
                .ToList();


            TBUsuarioDoacao user = new TBUsuarioDoacao(usuario[0].Id, doador[0].Id, doador[0].Nome);

                return StatusCode(200);
            }
            catch
            {

            }

            return StatusCode(401);
        }
    }
}
