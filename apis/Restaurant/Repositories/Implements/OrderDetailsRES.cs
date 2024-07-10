using Db.Contexts;
using Db.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Repositories.Interfaces;

namespace Repositories.Implements;

public class OrderDetailsRES(FFOEContext context) : BaseRES(context), IOrderDetailsRES
{
    public OrderDetails Add(OrderDetails obj)
    {
        using IDbContextTransaction transaction = context.Database.BeginTransaction();
        try
        {
            // Add the new orderdetail
            var entry = context.OrderDetails.Add(obj);
            var addedObj = entry.Entity;
            context.SaveChanges();

            // Commit the transaction
            transaction.Commit();
            return addedObj;
        }
        catch (Exception)
        {
            // Rollback the transaction if an error occurs
            transaction.Rollback();
            throw;
        }
    }

    public bool Delete(int id)
    {
        try
        {
            // Retrieve the Order Detail object by ID
            var odDt = context.Set<OrderDetails>().Find(id);

            if (odDt == null)
                return false;

            // Remove the Order Detail from DbSet and save changes
            context.Set<OrderDetails>().Remove(odDt);
            context.SaveChanges();

            return true;
        }
        catch (Exception ex)
        {
            // Handle any exception and log if necessary
            throw new Exception("Error deleting Order Detail.", ex);
        }
    }

    public OrderDetails? GetById(int id)
    {
        try
        {
            // Retrieve the Product object by ID
            var odDt = context.Set<OrderDetails>().Find(id);

            return odDt ?? throw new Exception($"Order detail with ID {id} not found.");
        }
        catch (Exception ex)
        {
            // Handle any exception and log if necessary
            throw new Exception("Error retrieving order detail by ID.", ex);
        }
    }

    public IEnumerable<OrderDetails> GetByOrder(Guid orderId)
    {
        try
        {
            // Retrieve the Product object by ID
            var odDt = context.Set<OrderDetails>().Where(x=>x.OrderId == orderId).ToList();  

            return odDt ?? throw new Exception($"Order detail with OrderID {orderId} not found.");
        }
        catch (Exception ex)
        {
            // Handle any exception and log if necessary
            throw new Exception("Error retrieving order detail by OrderID.", ex);
        }
    }

    public OrderDetails? Update(OrderDetails obj, int id)
    {
        if (obj == null)
        {
            throw new ArgumentNullException(nameof(obj), "Order Detail object cannot be null.");
        }    
        try
        {
            var existingOrderdetail = context.Set<OrderDetails>().FirstOrDefault(p => p.Id == id);

            if (existingOrderdetail is null)
                return null; // Product with given ID not found

            // Updates the existing product
            existingOrderdetail.ProductName = obj.ProductName;
            existingOrderdetail.UnitPrice = obj.UnitPrice;
            existingOrderdetail.Quantity = obj.Quantity;
            existingOrderdetail.Note = obj.Note;

            context.SaveChanges();
            return existingOrderdetail;
        }
        catch (Exception ex)
        {
            // Handle any exception and log if necessary
            throw new Exception($"Error updating Order Detail with ID {id}.", ex);
        }
    }
}