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
    public class PlesniKlubController : ControllerBase
    {
        public PlesniKluboviContext Context{get; set;}
        public PlesniKlubController(PlesniKluboviContext context)
        {
            Context = context;
        }
    

        [Route("PrikaziPlesniKlubSve")]
        [HttpGet]
        public async Task<ActionResult> PrikaziPlesneKluboveSve()
        {
           try
           {
               var pk = await Context.PlesniKlubovi
               .Select(p=>
               new
               {
                   NazivPK=p.Naziv,
                   Pass=p.Password

               }).ToListAsync();
               return Ok(pk);
           }
           catch(Exception e)
           {
               return BadRequest(e.Message);
           }
        }

        [Route("PrikaziPlesniKlub/{nazivPK}")]
        [HttpGet]
        public async Task<ActionResult> PrikaziPlesneKlubove(string nazivPK)
        {
            var pk = Context.PlesniKlubovi.Where(p=>p.Naziv==nazivPK).FirstOrDefault();
            if(!Context.PlesniKlubovi.Contains(pk))
            {
                return BadRequest("Klub ne postoji.");
            }
           try
           {
                var format = await Context.PlesniKlubovi.Where(p=>p.Naziv==nazivPK)
               .Select(p=>
               new
               {
                   NazivPK=p.Naziv,
                   Pass=p.Password

               }).ToListAsync();
               return Ok(format);
           }
           catch(Exception e)
           {
               return BadRequest(e.Message);
           }
        }

       /*  [Route("DodajPlesniKlub/{nazivPK}/{password}")]
        [HttpPost]
        public async Task<ActionResult> Dodaj(string nazivPK, string password)
        {
            var pk = Context.PlesniKlubovi.Where(p=>p.Naziv==nazivPK && p.Password==password).FirstOrDefault();
        
            
            if(Context.PlesniKlubovi.Contains(pk))
            {
                return BadRequest("Klub već postoji.");
            }
            if(password.Length>50)
            {
                return BadRequest("Password je predugačak.");
            }
            if(nazivPK.Length>50)
            {
                return BadRequest("Ime kluba je predugačko.");
            }

           try
           {
                PlesniKlub plesni = new PlesniKlub
                {
                    Naziv=nazivPK,
                    Password=password
                };

                var format = Context.PlesniKlubovi.Where(p=>p.Naziv==nazivPK && p.Password==password)
                .Select(p=>
                new
                {
                    NazivPK=p.Naziv,
                    Password=p.Password
                });

                await Context.PlesniKlubovi.AddAsync(plesni);
                await Context.SaveChangesAsync();

                return Ok(format);
               

           }
           catch(Exception e)
           {
               return BadRequest(e.Message);
           }
        } */
        
    }
}