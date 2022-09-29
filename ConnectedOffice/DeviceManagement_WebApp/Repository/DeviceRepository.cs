using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;

public class DeviceRepository : GenericRepository<Device>, IDeviceRepository
{
    private new readonly ConnectedOfficeContext _context = new ConnectedOfficeContext();

    public DeviceRepository(ConnectedOfficeContext context) : base(context)
    {

    }

    public Device GetMostRecentDevice()
    {
        return _context.Device.OrderByDescending(Device => Device.DateCreated).FirstOrDefault();
    }
}
