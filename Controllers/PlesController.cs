using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace PlesniKlubovi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlesController : ControllerBase
    {
        public PlesniKluboviContext Context{get; set;}
        public PlesController(PlesniKluboviContext context)
        {
            Context = context;
        }

        [Route("DodajPles/{naziv}/{nazivPK}")]
        [HttpPost]
        public async Task<ActionResult> DodajPLes(string naziv, string nazivPK)
        {
            var pl = Context.Plesovi.Where(p=>p.Naziv==naziv && p.PlesniKlub.Naziv==nazivPK).FirstOrDefault();
            var pk = Context.PlesniKlubovi.Where(p=>p.Naziv==nazivPK).FirstOrDefault();
        
            
            if(!Context.PlesniKlubovi.Contains(pk))
            {
                return BadRequest("Klub ne postoji.");
            }
            if(Context.Plesovi.Contains(pl))
            {
                return BadRequest("Ples za dati klub već postoji.");
            }
           try
           {
                Ples ples = new Ples
                {
                    Naziv=naziv,
                    PlesniKlub=pk
                };

                var format = Context.Plesovi.Where(p=>p.PlesniKlub.Naziv==nazivPK && p.Naziv==naziv)
                .Select(p=>
                new
                {
                    Naziv=p.Naziv,
                    NazivPK=p.PlesniKlub.Naziv
                });

                Context.Plesovi.Add(ples);
                await Context.SaveChangesAsync();

                return Ok(format);

           }
           catch(Exception e)
           {
               return BadRequest(e.Message);
           }
        }

        [Route("PrikaziPles/{nazivPK}")]
        [HttpGet]
        public async Task<ActionResult> PrikaziPlesove(string nazivPK)
        {
           try
           {
                var pl = Context.Plesovi.Where(p=>p.PlesniKlub.Naziv==nazivPK).FirstOrDefault();
                if(pl==null)
                {
                return BadRequest("Plesni Klub ne postoji.");
                }

               var plesovi = await Context.Plesovi.Where(p=>p.PlesniKlub.Naziv==nazivPK)
               .Include(p=>p.PlesniKlub)
               .Select(p=>
               new
               {
                   Naziv=p.Naziv,
                   NazivPK=p.PlesniKlub.Naziv

               }).ToListAsync();
               return Ok(plesovi);
           }
           catch(Exception e)
           {
               return BadRequest(e.Message);
           }
        }

        

        
    }
}