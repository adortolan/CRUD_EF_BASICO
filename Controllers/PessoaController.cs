using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CRUD_EFCS.Models;
using CRUD_EFCS.Database;
using System.Threading.Tasks;

namespace CRUD_EFCS
{
    public class PessoaController: Controller
    {
        private readonly PessoaDBContext _database;
        public PessoaController(PessoaDBContext database)
        {
            _database = database;
        }
        
        public IActionResult Index()
        {           
            var pessoas = _database.Pessoas.ToList();
            return View(pessoas);
        }

        public IActionResult Deletar(int id)
        {
            Pessoa pessoa = _database.Pessoas.First( registro => registro.Id == id);
            _database.Pessoas.Remove(pessoa);
            _database.SaveChanges();
            return RedirectToAction("Index");
        }       

        public IActionResult Editar(int id)
        {
            Pessoa pessoa = _database.Pessoas.First(registro => registro.Id == id);
            return View("Cadastrar",pessoa);            
        }
        public IActionResult Cadastrar()
        {
            return View();
        }

        public IActionResult Salvar(Pessoa pessoa)
        {
            if (pessoa.Id == 0 )
            {
                _database.Add(pessoa);
            }else
            {
                Pessoa pessoa1 = _database.Pessoas.First(registro => registro.Id == pessoa.Id);
                pessoa1.Nome = pessoa.Nome;
                pessoa1.SobreNome = pessoa.SobreNome;
                pessoa1.Idade = pessoa.Idade; 
            }            
            _database.SaveChanges();
            return RedirectToAction("Index");            
        }        
    }
    
}