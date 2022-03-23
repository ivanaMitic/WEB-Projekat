using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace PlesniKlub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClanarinaController : ControllerBase
    {
        public PlesniKluboviContext Context{get; set;}
        public ClanarinaController(PlesniKluboviContext context)
        {
            Context = context;
        }

        [Route("PreuzmiClanarine/{nazivPK}")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiSve(string nazivPK)
        {
            try
            {
                var format =await Context.ClanoviPlesovi
                .Include(p=>p.PlesniKlub).Where(p=>p.PlesniKlub.Naziv==nazivPK)
                .Include(p=>p.Clanarina)
                .Include(p=>p.ClanKluba)
                .Include(p=>p.Ples)
                .Select(p=>
                new
                {
                    Mesec=p.Clanarina.Mesec,
                    Godina=p.Clanarina.Godina,
                    Jb=p.ClanKluba.JB,
                    Ples=p.Ples.Naziv,
                    Cena=p.Cena,
                    NazivPK=p.PlesniKlub.Naziv
                    
                }).ToListAsync();
                return Ok(format);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }    
        }

        [Route("PrikaziClanarine/{godina}/{jbClana}/{nazivPK}")]
        [HttpGet]
        public async Task<ActionResult> Prikazi(int godina, int jbClana, string nazivPK)
        {
            var clanKluba =await Context.ClanoviKluba.Where(p=>p.JB==jbClana).FirstOrDefaultAsync();
            var clanarina =await Context.Clanarine.Where(p=>p.Godina==godina).FirstOrDefaultAsync();
            var pk = await Context.PlesniKlubovi.Where(p=>p.Naziv==nazivPK).FirstOrDefaultAsync();

            if(!Context.Clanarine.Contains(clanarina))
            {
                return BadRequest("Uneta je navalidna clanarina");
            }

            if(!Context.ClanoviKluba.Contains(clanKluba))
            {
                return BadRequest("Clan kluba sa unetim JB-om ne postoji.");
            }

            if(!Context.PlesniKlubovi.Contains(pk))
            {
                return BadRequest("Plesni Klub ne postoji.");
            }

           try
           {
               var placeneClanarine = await Context.ClanoviPlesovi
               .Include(p=>p.PlesniKlub)
               .Include(p=>p.ClanKluba)
               .Include(p=>p.Clanarina)
               .Include(p=>p.Ples)
               .Where(p=>p.Clanarina.Godina==godina && p.ClanKluba.JB==jbClana && p.PlesniKlub.Naziv==nazivPK)
               .Select(p=>
               new
               {
                   Mesec=p.Clanarina.Mesec,
                   Godina=p.Clanarina.Godina,
                   Ime=p.ClanKluba.Ime,
                   Prezime=p.ClanKluba.Prezime,
                   Ples=p.Ples.Naziv,
                   Cena=p.Cena
               })
               .ToListAsync();

                var provera =placeneClanarine.FirstOrDefault();

               if(provera==null)
               {
                   return BadRequest("Nema placenih clanarina za datu godinu.");
               }
              
                return Ok(placeneClanarine); 
               
           }
           catch(Exception e)
           {
               return BadRequest(e.Message);
           }
        } 

        [Route("PlatiClanarinu/{mesec}/{godina}/{jb}/{ples}/{cena}/{nazivPK}")]
        [HttpPost]
        public async Task<ActionResult> Plati(string mesec,int godina, int jb, string ples, int cena, string nazivPK)
        {
           try
           {
                var clanKluba = await Context.ClanoviKluba.Where(p=>p.JB==jb && p.PlesniKlub.Naziv==nazivPK).FirstOrDefaultAsync();
                var pl = await Context.Plesovi.Where(p=>p.Naziv==ples).FirstOrDefaultAsync();
                var clanarina =await Context.Clanarine.Where(p=>p.Mesec==mesec && p.Godina==godina).FirstOrDefaultAsync();
                var pk = await Context.PlesniKlubovi.Where(p=>p.Naziv==nazivPK).FirstOrDefaultAsync();

                if(!Context.Clanarine.Contains(clanarina))//provera da li ima kombinacija mesec godina
                {//ne postoji prosledjena kombinacija

                    var pr =await Context.Clanarine.Where(p=>p.Godina==godina).FirstOrDefaultAsync();  //ima prosledjenu godinu, godina postoji u bazi 
                    if(pr!=null)
                    {//nasao je godinu
                        var pr2 = await Context.Clanarine.Where(p=>p.Mesec==mesec).FirstOrDefaultAsync();
                        /* if(pr2!=null)//ima li sa tom godinom prosledjeni mesec
                        {
                            return BadRequest("Unet nevalidan mesec.");
                        } */
                        Clanarina nc = new Clanarina//pravi novu clanarinu za prosledjeni mesec i postojecu godinu
                        {
                            Mesec=mesec,
                            Godina=godina
                        };
                        await Context.Clanarine.AddAsync(nc);
                        await Context.SaveChangesAsync(); 
                    }//nije nasao godinu
                    else
                    {
                        Clanarina nclanarina = new Clanarina//pravi novu clanarinu za prosledjeni mesec i prosledjenu novu godinu
                        {
                            Mesec=mesec,
                            Godina=godina
                        };
                        await Context.Clanarine.AddAsync(nclanarina);
                        await Context.SaveChangesAsync();
                    }
                }
                /* if(!Context.Plesovi.Contains(ples))
                {
                    return BadRequest("Unet nevalidan ples.");
                } */
                if(!Context.ClanoviKluba.Contains(clanKluba))
                {
                    return BadRequest("Clan kluba ne postoji.");
                }

                var cl = Context.Clanarine.Where(p=>p.Mesec==mesec && p.Godina==godina).FirstOrDefault();

                var platioClanarinu = await Context.ClanoviPlesovi
                .Include(p=>p.ClanKluba)
                .Include(p=>p.Ples)
                .Where(p=>p.ClanKluba.ID==clanKluba.ID && p.Ples.ID==pl.ID && p.Clanarina.Mesec==mesec && p.Clanarina.Godina==godina)
                .FirstOrDefaultAsync();

                if (platioClanarinu!=null)
                {
                    return BadRequest("Clan je vec platio clanarinu.");
                }
                Placanje p = new Placanje
                {
                    ClanKluba=clanKluba,
                    Ples=pl,
                    Clanarina=cl,
                    Cena=cena,
                    PlesniKlub=pk
                };

                await Context.ClanoviPlesovi.AddAsync(p);
                await Context.SaveChangesAsync();

                var podaciOClanu = await Context.ClanoviPlesovi
                .Include(p=>p.ClanKluba)
                .Include(p=>p.Ples)
                .Include(p=>p.Clanarina)
                .Where(p=>p.ClanKluba.JB==jb)
                .Select(p=>
                new
                {
                    Jb=p.ClanKluba.JB,
                    Ime=p.ClanKluba.Ime,
                    Prezime=p.ClanKluba.Prezime,
                    DatumRodjenja=p.ClanKluba.DatumRodjenja,
                    Kategorija=p.ClanKluba.Kategorija,
                    Mesec=p.Clanarina.Mesec,
                    Godina=p.Clanarina.Godina,
                    Ples=p.Ples.Naziv,
                    Cena=p.Cena,
                    NazivPK=p.PlesniKlub.Naziv
                }).ToListAsync();

                return Ok(podaciOClanu);
           }
           catch(Exception e)
           {
               return BadRequest(e.Message);
           }
        }
    }
}