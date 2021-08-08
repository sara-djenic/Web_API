using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CourtTypeDataAccess;

namespace WebAPI.Controllers
{
    public class CourtTypesController : ApiController
    {
        public IEnumerable<CourtType> Get() 
        { 
            using (Entities entities = new Entities()) 
            { 
                return entities.CourtTypes.ToList(); 
            } 
        }

        public CourtType Get(int id)
        {
            using (Entities entities = new Entities())
            {
                return entities.CourtTypes.FirstOrDefault(c => c.Id == id);
            }
        }

        public void Post([FromBody] CourtType courtType)
        {
            using (Entities entities = new Entities())
            {
                entities.CourtTypes.Add(courtType);
                entities.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (Entities entities = new Entities())
            {
                var courtType = entities.CourtTypes.FirstOrDefault(c => c.Id == id);
                entities.CourtTypes.Remove(courtType);
                entities.SaveChanges();
            }
        }
    }
}
