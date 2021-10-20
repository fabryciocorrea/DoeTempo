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
        public async Task<IActionResult> CadastroUsuario([Bind("User, Senha, Nome, Sobrenome, Idade, Email, Celular, EnderecoCep, EnderecoNumero, Estado")] TBUsuario usuario)
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
        public async Task<IActionResult> CadastroDoador([Bind("User, Senha, Nome, Sobrenome, Idade, Email, Celular, EnderecoCep, EnderecoNumero, Estado")] TBDoador doador)
        {
            double idAleatorio = double.Parse(DateTime.Now.ToString("ddMMyyHHmmssff"));
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
    }
}
