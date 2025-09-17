using CadastroEvento.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CadastroEvento.Controllers
{
    public class EventoController : Controller
    {
        // GET: /Evento/Create
        // Retorna o formulário vazio para o usuário preencher
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Evento/Salvar
        // Recebe os dados do formulário via POST
        [HttpPost]
        public IActionResult Salvar(EventoViewModel info)
        {
            // Valida o modelo com base nas Data Annotations definidas no ViewModel
            if (!ModelState.IsValid)
            {
                // Se houver erros de validação, retorna para a mesma view (Create)
                // com os dados preenchidos e as mensagens de erro.
                return View("Create", info);
            }

            // Aplica a regra de negócio solicitada
            if (info.NumeroParticipantes > 100)
            {
                ViewData["Mensagem"] = "Evento de grande porte";
            }
            else
            {
                ViewData["Mensagem"] = "Evento cadastrado com sucesso";
            }

            // Retorna a view de Resultado, passando os dados tratados explicitamente
            return View("Resultado", info);
        }
    }
}