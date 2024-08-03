using Db.Contexts;
using Db.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositories.Implements
{
    public class OrderRES : BaseRES, IOrderRES
    {
        public OrderRES(FFOEContext context) : base(context) { }

        public Order Add(Order obj)
        {
            using IDbContextTransaction transaction = context.Database.BeginTransaction();
            try
            {
                context.Orders.Add(obj);
                context.SaveChanges();
                transaction.Commit();
                return obj;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Error creating Order", ex);
            }
        }

        public Order? Cancel(Guid id)
        {
            using IDbContextTransaction transaction = context.Database.BeginTransaction();
            try
            {
                var order = context.Orders.Find(id);
                if (order == null) throw new Exception("Order not found");

                
                context.SaveChanges();
                transaction.Commit();
                return order;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Error canceling Order", ex);
            }
        }

        public bool Delete(Guid id)
        {
            using IDbContextTransaction transaction = context.Database.BeginTransaction();
            try
            {
                var order = context.Orders.Find(id);
                if (order == null) return false;

                context.Orders.Remove(order);
                context.SaveChanges();
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Error deleting Order", ex);
            }
        }

        public IEnumerable<Order> Get(int numberOfOrder)
        {
            try
            {
                return context.Orders.Take(numberOfOrder).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving Orders", ex);
            }
        }

        public Order? GetById(Guid id)
        {
            try
            {
                return context.Orders.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving Order by ID", ex);
            }
        }

        public IEnumerable<Order> GetByCustomer(Guid customerId)
        {
            try
            {
                return context.Orders.Where(o => o.CustomerId == customerId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving Orders by Customer ID", ex);
            }
        }

        public Order? Update(Order obj, Guid id)
        {
            using IDbContextTransaction transaction = context.Database.BeginTransaction();
            try
            {
                var order = context.Orders.Find(id);
                if (order == null) throw new Exception("Order not found");

                context.Entry(order).CurrentValues.SetValues(obj);
                context.SaveChanges();
                transaction.Commit();
                return order;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Error updating Order", ex);
            }
        }

        public Order? UpdateDeliveryStatus(int status, Guid id)
        {
            using IDbContextTransaction transaction = context.Database.BeginTransaction();
            try
            {
                var order = context.Orders.Find(id);
                if (order == null) throw new Exception("Order not found");

                order.DeliveryStatus = status;
                context.SaveChanges();
                transaction.Commit();
                return order;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Error updating Delivery Status", ex);
            }
        }

        public Order? UpdatePaymentStatus(int status, Guid id)
        {
            using IDbContextTransaction transaction = context.Database.BeginTransaction();
            try
            {
                var order = context.Orders.Find(id);
                if (order == null) throw new Exception("Order not found");

                order.PaymentStatus = status;
                context.SaveChanges();
                transaction.Commit();
                return order;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Error updating Payment Status", ex);
            }
        }

        public Order? UpdateOrderDetails(Order obj, Guid id)
        {
            throw new NotImplementedException();
        }

        public Order? UpdateDiscount(Guid couponCode, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
