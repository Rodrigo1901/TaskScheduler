using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskScheduler.Models;

namespace TaskScheduler.Controllers
{
    public class TarefaController : Controller
    {
        TarefaDAL tarefaDAL = new TarefaDAL();
        public IActionResult Index()
        {
            List<Tarefa> tarList = new List<Tarefa>();
            tarList = tarefaDAL.GetTarefas().ToList();
            return View(tarList);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Criar([Bind] Tarefa objTar)
        {
            if(ModelState.IsValid)
            {
                tarefaDAL.AddTarefa(objTar);
                return RedirectToAction("Index");
            }
            return View(objTar);
        }
     
        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            Tarefa tar = tarefaDAL.GetTarefaById(id);
            if(tar == null)
            {
                return NotFound();
            }
            return View(tar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id,[Bind] Tarefa objTar)
        {
            if(id == null)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                tarefaDAL.UpdateTarefa(objTar);
                return RedirectToAction("Index");
            }
            return View(tarefaDAL);
        }
        [HttpGet]
        public IActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Tarefa tar = tarefaDAL.GetTarefaById(id);
            if (tar == null)
            {
                return NotFound();
            }
            return View(tar);

        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Tarefa tar = tarefaDAL.GetTarefaById(id);
            if (tar == null)
            {
                return NotFound();
            }
            return View(tar);

        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteTar(int? id)
        {
            tarefaDAL.DeletarTarefa(id);
            return RedirectToAction("Index");
        }
        
    }
}
