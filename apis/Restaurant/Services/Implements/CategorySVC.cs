using System;
using Db.Models;
using Models;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implements;

public class CategorySVC(ICategoryRES categoryRES) : ICategorySVC
{
    public Response Add(Category obj)
    {
        try
        {
            var result = categoryRES.Add(obj);
            return new Response(true, "Add new category successfully", result);
        }
        catch (Exception ex)
        {
            return new Response(false, "Errors occur from server", null, new List<string> { ex.Message });
        }
    }


    public Response Delete(Guid id)
    {
        try
        {
            var result = categoryRES.Delete(id);
            return new Response(true, "Delete the category successfully", result);
        }
        catch(Exception ex)
        {
            return new Response(false, "Errors occur from server", null, new List<string> { ex.Message });
        }

    }

    public Response Get()
    {
        try
        {
            var data = categoryRES.Get();
            return new Response(true, "Get all categories successfully", data);
        }
        catch (Exception ex)
        {
            return new Response(false, "Errors occur from server", null, new List<string> { ex.Message });
        }
    }

    // public Category? GetById(Guid id)
    // {
    //     return categoryRES.GetById(id);
    // }
    public Response GetById(Guid id)
    {
        try
        {
            var result = categoryRES.GetById(id);
            if (result is null)
                return new Response(true, "There are no categories matching the id");

            return new Response(true, "The category has been found", result);
        }
        catch (Exception ex)
        {
            return new Response(false, "Errors occur from server", null, new List<string> { ex.Message });
        }
    }

    public Response Update(Category obj, Guid id)
    {
        try
        {
            var result = categoryRES.Update(obj, id);
            return new Response(true, "Update the category successfully", result);
        }
        catch(Exception ex)
        {
            return new Response(false, "Errors occur from server", null, new List<string> { ex.Message });
        }
    }
}