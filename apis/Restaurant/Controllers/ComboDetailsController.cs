using Db.Models;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;

namespace Controllers;

[ApiController]
[Route("api/combodetails")]
public class ComboDetailsController(IComboDetailsSVC comboDetailsSVC) : ControllerBase
{
    [HttpGet("{id}")]
    public Response GetById(int id)
    {
        return comboDetailsSVC.GetById(id);
    }

    [HttpGet("product/{id}")]
    public Response GetByCombo(Guid id)
    {
        return comboDetailsSVC.GetByCombo(id);
    }

    [HttpPost()]
    public Response Add([FromBody]ComboDetails obj)
    {
        return comboDetailsSVC.Add(obj);
    }

    [HttpPut("{id}")]
    public Response Update([FromBody]ComboDetails obj, [FromRoute]int id)
    {
        return comboDetailsSVC.Update(obj, id);
    }

    [HttpDelete("{id}")]
    public Response Delete([FromRoute]int id)
    {
        return comboDetailsSVC.Delete(id);
    }
}