using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;

public class ZoneRepository : GenericRepository<Zone>, IZonesRepository
{
    private new readonly ConnectedOfficeContext _context = new ConnectedOfficeContext();

    public ZoneRepository(ConnectedOfficeContext context) : base(context)
    {

    }

    public Zone GetMostRecentZone()
    {
        return _context.Zone.OrderByDescending(Zone => Zone.DateCreated).FirstOrDefault();
    }
}
