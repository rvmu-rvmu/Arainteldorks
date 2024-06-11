﻿using Araintelsoftware.Models;
using Microsoft.EntityFrameworkCore;

namespace Araintelsoft.Services.Search
{
    public class BuscadorService : IBuscadorLinkedinService
    {
        private readonly AraintelsqlContext _context;

        public BuscadorService(AraintelsqlContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Agendum>> GetContactos(string searchFirstname, string searchLastname, string searchCompany)
        {
            var contactos = from m in _context.Agenda
                            select m;

            if (!String.IsNullOrEmpty(searchFirstname))
            {
                contactos = contactos.Where(s => s.Firstname.Contains(searchFirstname));
            }

            if (!String.IsNullOrEmpty(searchLastname))
            {
                contactos = contactos.Where(s => s.Lastname.Contains(searchLastname));
            }

            if (!String.IsNullOrEmpty(searchCompany))
            {
                contactos = contactos.Where(s => s.Company.Contains(searchCompany));
            }

            return await contactos.ToListAsync();
        }
    }
}
