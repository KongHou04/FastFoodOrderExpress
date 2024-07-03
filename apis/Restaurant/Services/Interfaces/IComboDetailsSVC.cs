﻿using Db.Models;
using Models;

namespace Services.Interfaces;

/// <summary>
/// Interface for combo details services providing CRUD operations for combo details.
/// </summary>
public interface IComboDetailsSVC
{
    /// <summary>
    /// Retrieves all combo details for a specific combo by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the combo to retrieve details for.</param>
    /// <returns>A Response object containing the details of the specified combo and status information about the retrieval process.</returns>
    Response GetByCombo(Guid id);



    /// <summary>
    /// Adds a new combo detail.
    /// </summary>
    /// <param name="obj">The new combo detail to add.</param>
    /// <returns>A Response object indicating the result of the add operation and status information about the add process.</returns>
    Response Add(ComboDetails obj);



    /// <summary>
    /// Updates an existing combo detail.
    /// </summary>
    /// <param name="obj">The updated details of the combo detail.</param>
    /// <param name="id">The unique identifier of the combo detail to update.</param>
    /// <returns>A Response object indicating the result of the update operation and status information about the update process.</returns>
    Response Update(ComboDetails obj, int id);



    /// <summary>
    /// Deletes a specific combo detail by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the combo detail to delete.</param>
    /// <returns>A Response object indicating the result of the delete operation and status information about the delete process.</returns>
    Response Delete(int id);
}
