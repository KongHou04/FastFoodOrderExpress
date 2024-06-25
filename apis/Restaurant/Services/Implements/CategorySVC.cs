using Db.Models;
using Models;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implements;

public class CategorySVC(ICategoryRES categoryRES) : ICategorySVC
{
    public string Add(Category obj)
    {
        var result = categoryRES.Add(obj);
        if (result is null)
            return "Cannot add new category";
        return "Add new category successfully";
    }

    public string Delete(Guid id)
    {
        var result = categoryRES.Delete(id);
        if (result is null || result == false)
            return "Cannot delete the category or the category does not exist";
        return "Delete the category successfully";
    }

    public IEnumerable<Category> Get()
    {
        return categoryRES.Get();
    }

    // public Category? GetById(Guid id)
    // {
    //     return categoryRES.GetById(id);
    // }
    public Response GetById(Guid id)
    {
        try{
            var result = categoryRES.GetById(id);
            if (result is null)
                return new Response(true, "There are no categories matching the id", null, null);

            return new Response(true, "The category has been found", result, null);
        }
        catch(Exception ex)
        {
            return new Response(false, "Errors occur from server", null, new List<string> { ex.Message });
        }
    }

    public string Update(Category obj, Guid id)
    {
        var result = categoryRES.Update(obj, id);
        if (result is null)
            return "Cannot update the category";
        return "Update the category successfully";
    }
}