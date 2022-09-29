using System;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public class GenericRepository<T> : IGenericRepository<T>  where T : class
{
    protected readonly ConnectedOfficeContext _context;

    public GenericRepository(ConnectedOfficeContext context)
    {
        _context = context;
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
        Save();
    }

    public void AddRange(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
    }

    public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression);
    }

    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public T GetById(Guid? id)
    {
        return _context.Set<T>().Find(id);
    }

    public void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
        Save();
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
    }

    public void Save()
    {
         _context.SaveChangesAsync();
    }

    public bool CategoryEX(Guid id)
    {
       return _context.Category.Any(e => e.CategoryId == id);
    }

    public bool ZoneEX(Guid id)
    {
        return _context.Zone.Any(e => e.ZoneId == id);
    }

    public bool DeviceEX(Guid id)
    {
        return _context.Device.Any(e => e.DeviceId == id);
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
        Save();
    }
}