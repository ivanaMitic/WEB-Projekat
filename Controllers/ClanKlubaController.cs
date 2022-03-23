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
    public class ClanKlubaController : ControllerBase
    {
        public PlesniKluboviContext Context{get; set;}
        public ClanKlubaController(PlesniKluboviContext context)
        {
            Context = context;
        }

        [Route("PreuzmiClanoveKluba/{nazivPK}")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiSve(string nazivPK)
        {
            try
            {
                var format = Context.ClanoviKluba.Where(p=>p.PlesniKlub.Naziv==nazivPK)
                .Select(p=>
                new
                {
                    Jb=p.JB,
                    Ime=p.Ime,
                    Prezime=p.Prezime,
                    DatumRodjenja=p.DatumRodjenja,
                    Kategorija=p.Kategorija,/* 
                    Godina=p.Clanarina.Godina,
                    Mesec=p.Clanarina.Mesec, */
                    NazivPK=p.PlesniKlub.Naziv
                    
                });

                await format.ToListAsync();
                
                return Ok(format);

            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }    
        }

        [Route("PreuzmiClanKluba/{jbClana}")]
        [HttpGet]
        public async Task<ActionResult> Preuzmi(int jbClana)
        {
            var clanKluba = Context.ClanoviKluba.Where(p=>p.JB==jbClana).FirstOrDefault();
            if(clanKluba==null)
            {
                return BadRequest("Clan kluba sa datim jb ne postoji.");
            }
            try
            {
                var format = Context.ClanoviKluba.Where(p=>p.JB==jbClana).Select(p=>
                new
                {
                    JB=p.JB,
                    Ime=p.Ime,
                    Prezime=p.Prezime,
                    DatumRodjenja=p.DatumRodjenja,
                    Kategorija=p.Kategorija
                });
            
                await format.ToListAsync();
                return Ok(format);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }    
        }

        [Route("UpisClana/{ime}/{prezime}/{datumRodjenja}/{kategorija}/{nazivPK}")]
        [HttpPost]
        public async Task<ActionResult> UpisClana(string ime, string prezime, string datumRodjenja, string kategorija, string nazivPK)
        {
            var pk = Context.PlesniKlubovi.Where(p=>p.Naziv==nazivPK).FirstOrDefault();
        
           if(string.IsNullOrWhiteSpace(ime) || ime.Length>25)
           {
               return BadRequest("Unesite validno ime(maksimalno 25 karaktera) bez razmaka.");
           }
           if(string.IsNullOrWhiteSpace(prezime) || prezime.Length>25)
           {
               return BadRequest("Unesite validno Prezime(maksimalno 25 karaktera) bez razmaka.");
           }

            Random rand = new Random();
            int randbr = rand.Next(1000, 9999);
            var ck = Context.ClanoviKluba.Where(p=>p.JB==randbr).FirstOrDefault();
            while(Context.ClanoviKluba.Contains(ck))
            {
                randbr = rand.Next(1000, 9999);
                ck = Context.ClanoviKluba.Where(p=>p.JB==randbr).FirstOrDefault();
            }
           try
           {
                ClanKluba clanKluba = new ClanKluba
                {
                    JB=randbr,
                    Ime=ime,
                    Prezime=prezime,
                    DatumRodjenja=datumRodjenja,
                    Kategorija=kategorija,
                    PlesniKlub=pk
                };

                var format = Context.ClanoviKluba.Where(p=>p.PlesniKlub.Naziv==nazivPK && p.JB==randbr)
                .Select(p=>
                new
                {
                    Jb=p.JB,
                    Ime=p.Ime,
                    Prezime=p.Prezime,
                    DatumRodjenja=p.DatumRodjenja,
                    Kategorija=p.Kategorija,
                    NazivPK=p.PlesniKlub.Naziv
                });

                Context.ClanoviKluba.Add(clanKluba);
                await Context.SaveChangesAsync();

                return Ok(format);

           }
           catch(Exception e)
           {
               return BadRequest(e.Message);
           }
        }

        [Route("PromeniClana/{jb}/{kategorija}")]
        [HttpPut]
        public async Task<ActionResult> Promeni(int jb, string kategorija)
        {
            try
            {
                var ck = Context.ClanoviKluba.Where(c=> c.JB==jb).FirstOrDefault();
                if(ck.Kategorija==kategorija)
                {
                    return BadRequest("Clan je vec u datoj kategoriji");
                }
                if(ck!=null)
                {
                    ck.Kategorija=kategorija;

                    var format = Context.ClanoviKluba.Where(p=>p.JB==jb).Select(p=>
                    new
                    {
                        JB=p.JB,
                        Ime=p.Ime,
                        Prezime=p.Prezime,
                        DatumRodjenja=p.DatumRodjenja,
                        Kategorija=p.Kategorija
                    }); 

                    await Context.SaveChangesAsync();
                    return Ok(format);
                }
                else
                {
                    return BadRequest("Clan kluba nije pronadjen.");
                }
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("IspisiClana/{jb}")]
        [HttpDelete]
        public async Task<ActionResult> Ispisi(int jb)
        {
            var ck = Context.ClanoviKluba.Where(p=>p.JB==jb).FirstOrDefault();
            if(ck==null)
            {
                return BadRequest("Clan ne postoji.");
            }
            try
            {
                Context.ClanoviKluba.Remove(ck);

                var c = Context.ClanoviPlesovi.Where(p=>p.ClanKluba.JB==jb);

                foreach(var x in c)
                {
                    Context.ClanoviPlesovi.Remove(x);
                }

                var format = Context.ClanoviKluba.Where(p=>p.JB==jb).Select(p=>
                    new
                    {
                        JB=p.JB,
                        Ime=p.Ime,
                        Prezime=p.Prezime,
                        DatumRodjenja=p.DatumRodjenja,
                        Kategorija=p.Kategorija
                    });

                await Context.SaveChangesAsync();
                return Ok(format);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
