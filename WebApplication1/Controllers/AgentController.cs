using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class AgentController : Controller
{
    private static readonly List<AgentModel> Agents = new(); // A list of Agents


    [HttpGet]
    public IActionResult Create()
    {
        return View(Agents);
    }

    [HttpPost]
    public IActionResult Create(
        string id,
        string name,
        string nationality,
        string organization,
        string status)
    {
        if (!string.IsNullOrWhiteSpace(id) &&
            !string.IsNullOrWhiteSpace(name) &&
            !string.IsNullOrWhiteSpace(nationality) &&
            !string.IsNullOrWhiteSpace(organization))
        {
            // Accept only the two supported status values.
            if (status != "Active" && status != "Inactive")
            {
                status = "Active";
            }

            Agents.Add(new AgentModel
            {
                Id = id,
                Name = name,
                Nationality = nationality,
                Organization = organization,
                Status = status
            });
        }

        return RedirectToAction(nameof(Create));
    }

    [HttpGet]
    public IActionResult Edit(string id)
    {
        var agent = Agents.FirstOrDefault(x => x.Id == id);
        
        if (agent == null)
        {
            return NotFound();
        }
        
        return View(agent);
    }

    [HttpPost]
    public IActionResult Edit(AgentModel updated)
    {
        var agent = Agents.FirstOrDefault(x => x.Id == updated.Id);

        if (agent == null)
        {
            return NotFound();
        }

        if (updated.Status != "Active" && updated.Status != "Inactive")
        {
            ModelState.AddModelError(nameof(updated.Status), "Invalid agent status.");

            return View(updated);
        }

        agent.Status = updated.Status;

        return RedirectToAction(nameof(Create));
    }
}