using Db.Models;
using Models;
using Repositories.Implements;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implements;

public class ComboDetailsSVC(IComboDetailsRES comboDetailsRES) : IComboDetailsSVC
{
    public Response Add(ComboDetails obj)
    {
        try
        {
            var result = comboDetailsRES.Add(obj);
            return new Response(true, "Added new combo details successfully.", result);
        }
        catch (Exception ex)
        {
            return new Response(false, "Error occurred while adding the new combo details.", null, new List<string> { ex.Message });
        }
    }

    public Response Delete(int id)
    {
        try
        {
            var result = comboDetailsRES.Delete(id);
            return new Response(true, "Deleted combo details successfully.", result);
        }
        catch (Exception ex)
        {
            return new Response(false, "Error occurred while deleting the combo details.", null, new List<string> { ex.Message });
        }
    }

    public Response GetByCombo(Guid id)
    {
        try
        {
            var result = comboDetailsRES.GetByProduct(id);
            return new Response(true, "Get combo details by product successfully.", result);
        }
        catch (Exception ex)
        {
            return new Response(false, "Error occurred while retriving the combo details of the product.", null, new List<string> { ex.Message });
        }
    }

    public Response GetById(int id)
    {
        try
        {
            var result = comboDetailsRES.GetById(id);
            return new Response(true, "Get combo detail successfully.", result);
        }
        catch (Exception ex)
        {
            return new Response(false, "Error occurred while retriving the combo detail.", null, new List<string> { ex.Message });
        }
    }

    public Response Update(ComboDetails obj, int id)
    {
        try
        {
            var result = comboDetailsRES.Update(obj, id);
            return new Response(true, "Update combo details successfully.", result);
        }
        catch (Exception ex)
        {
            return new Response(false, "Error occurred while updating the combo details.", null, new List<string> { ex.Message });
        }
    }
}