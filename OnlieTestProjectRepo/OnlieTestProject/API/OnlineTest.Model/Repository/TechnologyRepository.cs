using OnlineTest.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Models.Repository
{
    public class TechnologyRepository : ITechnologyRepository
    {
        private readonly OnlineTestContext _context;
        public TechnologyRepository(OnlineTestContext context)
        {
            _context = context;
        }

        public int AddTechnology(Technology technology)
        {
            _context.Technologies.Add(technology);
            return _context.SaveChanges();
        }

        public bool UpdateTechnology(Technology technology)
        {
            _context.Technologies.Update(technology);
            return _context.SaveChanges() > 0;
        }
        public bool DeleteTechnology(Technology technology)
        {
            _context.Entry(technology).Property("IsActive").IsModified = true;
            return _context.SaveChanges() > 0;
        }
        public IEnumerable<Technology> GetTechnologiesPaginated(int pageNumber, int pageSize)
        {
            return _context.Technologies.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }
        
        public IEnumerable<Technology> GetTechnologies()
        {
            return _context.Technologies.ToList();
        }

        IEnumerable<Technology> ITechnologyRepository.GetTechnologiesPaginated(int pageNumber, int pageSize)
        {
            return _context.Technologies.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }

        public Technology GetTechnologyById(int id)
        {
            return (Technology)_context.Technologies.FirstOrDefault(u => u.Id == id);
        }
        public Technology GetTechnologyByName(string name) 
        {
            return (Technology)_context.Technologies.FirstOrDefault(u => u.TechName == name);
        }
    }
}

