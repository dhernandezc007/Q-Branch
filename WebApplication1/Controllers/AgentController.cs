using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class AgentController : Controller
{
    // GET
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(AgentModel agent)
    {
        if (!ModelState.IsValid)
        {
            return View(agent);

        }
        
        string agentId = agent.Id;
        string agentName = agent.Name;
        string agentNationality = agent.Nationality;
        string agentOrganization = agent.Organization;
        
        return Content(
            $"Agent created: {agentName}, " +
            $"{agentNationality}, {agentOrganization}"
        );
    }
}