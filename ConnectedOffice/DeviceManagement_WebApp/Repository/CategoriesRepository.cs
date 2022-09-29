using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;

public class CategoriesRepository : GenericRepository<Category>, ICategoriesRepository
{
    private new readonly ConnectedOfficeContext _context = new ConnectedOfficeContext();
    
    public CategoriesRepository(ConnectedOfficeContext context) : base(context)
    {

    }

    public Category GetMostRecentCategory()
    {
        return _context.Category.OrderByDescending(category => category.DateCreated).FirstOrDefault();
    }
}
