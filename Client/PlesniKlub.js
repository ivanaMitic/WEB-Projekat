import { ClanKluba } from "./ClanKluba.js";
import { Clanarina } from "./Clanarina.js";
export class PlesniKlub{
    constructor(listaPlesova,listaClanarina, nazivPK) {
        this.listaPlesova=listaPlesova;
        this.listaClanovaKluba=[];
        this.listaClanarina=listaClanarina;
        this.nazivPK=nazivPK;
        this.container=null;
    }

    crtaj(host){

        this.container=document.createElement("div");//crno
        this.container.className="GlavnaForma";
        host.appendChild(this.container);

        let glavniNaslov = document.createElement("div");//crveno clan naslov
        glavniNaslov.className="GlavniNaslov";
        glavniNaslov.innerHTML=this.nazivPK;
        this.container.appendChild(glavniNaslov);

        let formaClan = document.createElement("div");//crveno clan
        formaClan.className="FormaClan";
        this.container.appendChild(formaClan);

        let formaClanarina = document.createElement("div");//crveno clanarina
        formaClanarina.className="FormaClanarina";
        this.container.appendChild(formaClanarina);

        this.crtajClan(formaClan);
        this.crtajClanarina(formaClanarina);

    }


    crtajRed(host){

        let red=document.createElement("div");
        red.className="Red";
        host.appendChild(red);
        return red;

    }


    crtajClan(host){

        let clan = document.createElement("div");//plavo clan
        clan.className="Clan";
        host.appendChild(clan);

        let clanPrikaz = document.createElement("div");//plavo prikaz clana
        clanPrikaz.className="ClanPrikaz";
        host.appendChild(clanPrikaz);

        var tabela = document.createElement("table");
        tabela.className="TabelaClan";
        clanPrikaz.appendChild(tabela);

        var red = this.crtajRed(tabela);
        red.className="TabelaClanHeder";
        var tabelahead = document.createElement("thead");
        tabelahead.innerHTML="";
        red.appendChild(tabelahead);

        var tr = document.createElement("tr");
        tr.className="RedHederClan";
        tabelahead.appendChild(tr);

        let th;
        var zag=["JB: ", "Ime: ", "Prezime: ", "Datum rođenja: ", "Kategorija: "];
        zag.forEach(el=>{
            th = document.createElement("th");
            th.className="thClan"
            th.innerHTML=el;
            tr.appendChild(th);
        })

        var tabelabody = document.createElement("tbody");
        tabelabody.className="TabelaTeloPodaciClan";
        red.appendChild(tabelabody);

        this.crtajCK(clan);

    }


    crtajCK(host){

        //Član Kluba
        let red = this.crtajRed(host);
        red.className="RedNaslov";
        let l = document.createElement("label");
        l.innerHTML="Član Kluba";
        red.appendChild(l);

        //JB Clan Kluba
        red = this.crtajRed(host);
        red.className="RedClan";
        l =document.createElement("label");
        l.innerHTML="JB: ";
        l.className="PodacilabelaC";
        red.appendChild(l);

        var poljeJB = document.createElement("input");
        poljeJB.type="number";
        poljeJB.className="jb";
        red.appendChild(poljeJB);

        //Ime Clan Kluba
        red = this.crtajRed(host);
        red.className="RedClan";
        l =document.createElement("label");
        l.innerHTML="Ime: ";
        l.className="PodacilabelaC";
        red.appendChild(l);

        var poljeIme = document.createElement("input");
        poljeIme.type="text";
        poljeIme.className="ime";
        red.appendChild(poljeIme);

        //Prezime Clan Kluba
        red = this.crtajRed(host);
        red.className="RedClan";
        l =document.createElement("label");
        l.innerHTML="Prezime: ";
        l.className="PodacilabelaC";
        red.appendChild(l);

        var poljePrezime = document.createElement("input");
        poljePrezime.type="text";
        poljePrezime.className="prezime";
        red.appendChild(poljePrezime);

        //Datum Rodjenja
        red = this.crtajRed(host);
        red.className="RedClan";
        l =document.createElement("label");
        l.innerHTML="Datum Rođenja: ";
        l.className="PodacilabelaC";
        red.appendChild(l);

        var poljeDatum = document.createElement("input");
        poljeDatum.type="date";
        poljeDatum.className="datum";
        red.appendChild(poljeDatum);

        //Kategorija Clan Kluba
        red = this.crtajRed(host);
        red.className="RedClan";
        l =document.createElement("label");
        l.innerHTML="Kategorija: ";
        l.className="PodacilabelaC";
        red.appendChild(l);

        var listaKategorija=["Kids","Junior", "Senior", "Youth", "Adult"];
        let se = document.createElement("select");
        se.className="kategorija"
        red.appendChild(se);
        let op;
        listaKategorija.forEach(k=>{
            op=document.createElement("option");
            op.innerHTML=k;
            op.value=k;
            se.appendChild(op);
        })

        //Dugmad Upis, Izmeni i Ispisi
        //Upisi dugme
        red = this.crtajRed(host);
        red.className="RedDugmadi";
        l = document.createElement("button");
        l.innerHTML="Upiši";
        l.onclick=(ev=>this.upisi(poljeIme.value, poljePrezime.value, poljeDatum.value));
        red.appendChild(l);

        //Promeni kategoriju dugme
        l = document.createElement("button");
        l.innerHTML="Izmeni Kategoriju";
        l.onclick=(ev=>this.izmeni(poljeJB.value));
        red.appendChild(l);

        //Ispisi clana dugme    
        l = document.createElement("button");
        l.innerHTML="Ispiši člana";
        l.onclick=(ev=>this.ispisi(poljeJB.value));
        red.appendChild(l);

    }


    upisi(ime, prezime, datumRodjenja){

        let optionEl = this.container.querySelector(".kategorija");
        const kategorija = optionEl.options[optionEl.selectedIndex].value;
        
        
        if(!ime || !prezime)
        {
            alert("Moraju se uneti ime i prezime novog člana kluba!");
            return;
        }
        if(ime.length>25 || prezime.length>25)
        {
            alert("Ime i prezime moraju da ima manje od 25 karaktera!");
            return;
        }
        if(!datumRodjenja)
        {
            alert("Mora se uneti datum rođenja novog člana kluba!");
            return;
        }
        //console.log(this.listaClanovaKluba);

        var alr=0;
        

        if(alr==0){
        fetch("https://localhost:5001/ClanKluba/UpisClana/"+ime+"/"+prezime+"/"+datumRodjenja+"/"+kategorija+"/"+this.nazivPK,
        {
            method:"POST"
        }).then(s=> {
                if(s.ok){
                    var teloTabele=this.obrisiPrethodniSadrzajClana();
                    s.json().then(data=>{
                        //console.log(data);
                        data.forEach(d=>{
                            const clanKluba=new ClanKluba(d.jb, d.ime, d.prezime, d.datumRodjenja, d.kategorija, d.nazivPK);
                            this.listaClanovaKluba.push(clanKluba);
                            clanKluba.crtajTabelaClan(teloTabele);
                            alr=1;
                            this.listaClanovaKluba.forEach(p=>{
                                if(p.jb==clanKluba.jb){
                                    alr=0;
                                return;
                            }
                        })
                    })
                            
                    })
                    alert("Novi član kluba je uspešno upisan.");
                }
            }) 
        }
    } 

    izmeni(jb){

        //let ime = this.container.querySelector(".ime").value;
        //let prezime = this.container.querySelector(".prezime").value;
        //let datum = this.container.querySelector(".datum").value;
        let optionEl = this.container.querySelector(".kategorija");
        const kategorija = optionEl.options[optionEl.selectedIndex].value;

        if(!jb)
        {
            alert("Mora se upisati JB člana kluba!");
            return;
        }
        if(jb<1000 || jb>9999)
        {
            alert("JB članova kluba je četvorocifreni broj!");
            return;
        }
        /* if(ime || prezime || datum)
        {
            alert("Promena kategorije se vrši preko JB člana kluba!");
            return;
        } */

        fetch("https://localhost:5001/ClanKluba/PreuzmiClanoveKluba/"+this.nazivPK,
        {
            method:"GET"
        }).then(s=> {
                if(s.ok){
                    s.json().then(data=>{
                        data.forEach(d=>{
                            const clanKluba=new ClanKluba(d.jb, d.ime, d.prezime, d.datumRodjenja, d.kategorija, this.nazivPK);
                            this.listaClanovaKluba.push(clanKluba);
                        })
                            var alr=0;
                            var b=0;
                            this.listaClanovaKluba.forEach(p=>{
                                if(p.jb==jb){
                                    b=1;
                                    return;
                                }
                            })
                            if(b==0)
                            {
                            alert("Član kluba sa upisanim JB-om ne postoji.");
                                return;
                            }
                            this.listaClanovaKluba.forEach(p=>{
                                if(p.jb==jb && p.kategorija==kategorija){
                                        alr=1;    
                                }
                            })
                            if(alr==1)
                            {
                                alert("Član kluba je već u datoj kategoriji.");
                                return;
                            }


                            if(alr===0){
                                fetch("https://localhost:5001/ClanKluba/PromeniClana/"+jb+"/"+kategorija,
                                {
                                    method:"PUT"
                                }).then(s=> {
                                        if(s.ok){
                                            var teloTabele=this.obrisiPrethodniSadrzajClana();
                                            s.json().then(data=>{
                                                var clanKluba;
                                                data.forEach(r=>{
                                                    clanKluba = new ClanKluba(r.jb, r.ime, r.prezime, r.datumRodjenja, r.kategorija, this.nazivPK)
                                                })
                                                this.listaClanovaKluba.forEach(p=>{
                                                    if(p.jb==jb){
                                                        p.kategorija=kategorija;
                                                    }
                                                    
                                                })
                                                clanKluba.crtajTabelaClan(teloTabele);
                                            })
                                                
                                            alert("Kategorija člana kluba sa upisanim JB-om je uspešno promenjena.");
                                        }
                                    })
                            }


                    })
                }
            })

          
    }


    ispisi(jb){

        //let ime = this.container.querySelector(".ime").value;
       // let prezime = this.container.querySelector(".prezime").value;
        //let datum = this.container.querySelector(".datum").value;
        

        var alrt=0;
        if(!jb)
        {
            alert("Mora se upisati JB člana kluba!");
            alrt=1;
            return;
        }

        if(jb<1000 || jb>9999)
        {
            alert("JB članova kluba je četvorocifreni broj!");
            alrt=1;
            return;
        }

        var alr=0;
        this.listaClanovaKluba.forEach(p=>{
            if(p.jb==jb){
                alr=0;
            }
            else{
                alr=1;
            }
        })
        

        if(alrt==0 && alr==0){
        fetch("https://localhost:5001/ClanKluba/PreuzmiClanoveKluba/"+this.nazivPK,
        {
            method:"GET"
        }).then(s=> {
                if(s.ok){
                    s.json().then(data=>{
                        data.forEach(d=>{
                            const clanKluba=new ClanKluba(d.jb, d.ime, d.prezime, d.datumRodjenja, d.kategorija, this.nazivPK);
                            this.listaClanovaKluba.push(clanKluba);
                        })
                        var b=0;
                        this.listaClanovaKluba.forEach(p=>{
                            if(p.jb==jb){
                                b++;
                                return;
                            }
                        })

                        if(alr==0 && b>=1){
                            fetch("https://localhost:5001/ClanKluba/IspisiClana/"+jb,
                            {
                                method:"DELETE"
                            }).then(s=> {
                                    if(s.ok){
                                        s.json().then(data=>{
                                                var indeks;
                                                    for(let i=0;i<this.listaClanovaKluba.length; i++)
                                                    {
                                                        if(this.listaClanovaKluba[i].jb==data.jb)
                                                            indeks=i;
                                                    }
                                                    for(let i=indeks;i<this.listaClanovaKluba.length; i++)
                                                    {
                                                        this.listaClanovaKluba[i]=this.listaClanovaKluba[i+1];
                                                    }
                                                    this.listaClanovaKluba.pop();
                                                    
                                                
                                                this.listaClanarina.forEach(p=>{
                                                    
                                                    for(let i=0;i<this.listaClanarina.length; i++)
                                                    {
                                                        if(this.listaClanarina[i].jb==data.jb)
                                                        indeks=i;
                                                    }
                                                    for(let i=indeks;i<this.listaClanarina.length; i++)
                                                    {
                                                        this.listaClanarina[i]=this.listaClanarina[i+1];
                                                        
                                                    }
                                                    this.listaClanarina.pop();
                                                    
                                                    
                                                })
                                                b--;
                                                alr=1;
                                                this.obrisiPrethodniSadrzajClana(); 
                                        })
                                        alert("Član kluba sa upisanim JB-om je uspešno ispisan iz kluba.");
                                        alr=1;
                                        return; 
                                    }

                                })    
                        }
                    })
                }
            })
        }
        else{
            alert("Član kluba sa upisanim JB-om ne postoji.");
            return;

        }
    }


    crtajClanarina(host){

        let clanarina = document.createElement("div");//plavo clanarina
        clanarina.className="Clanarina";
        host.appendChild(clanarina);

        let clanarinaPrikaz = document.createElement("div");//plavo prikaz clanarine
        clanarinaPrikaz.className="ClanarinaPrikaz";
        host.appendChild(clanarinaPrikaz);

        var red = this.crtajRed(clanarinaPrikaz);
        var l = document.createElement("div");
        l.innerHTML="";
        l.className="Godina";
        red.appendChild(l);

        var red = this.crtajRed(clanarinaPrikaz);
        red.className="RedTabelaClanarina";
        var tabela = document.createElement("table");
        tabela.className="TabelaClanarina";
        red.appendChild(tabela);

        red = this.crtajRed(tabela);
        red.className="OvajRed";
        var tabelahead = document.createElement("thead");
        tabelahead.innerHTML="";
        tabelahead.className="TabelaHederPodaciClanarina";
        red.appendChild(tabelahead);

        var tr = document.createElement("tr");
        tr.className="RedHederClanarina";
        tabelahead.appendChild(tr);

        let th;
        var zag=["Mesec", "Godina", "Ime", "Prezime", "Ples", "Cena"];
        zag.forEach(el=>{
            th = document.createElement("th");
            th.innerHTML=el;
            th.className="thClanarina"
            tr.appendChild(th);
        })

        var tabelabody = document.createElement("tbody");
        tabelabody.className="TabelaTeloPodaciClanarina";
        red.appendChild(tabelabody);
        
        this.crtajCL(clanarina);

    }


    crtajCL(host){

        let c1 = document.createElement("div");//ljubicasto clanarina 1
        c1.className="Clanarina1";
        host.appendChild(c1);

        let c2 = document.createElement("div");//ljubicasto clanarina 2
        c2.className="Clanarina2";
        host.appendChild(c2);

        //Crtanje c1

        //Članarina
        let red = this.crtajRed(c1);
        red.className="RedNaslov";
        let l = document.createElement("label");
        l.innerHTML="Članarina";
        red.appendChild(l);

        //Mesec
        red = this.crtajRed(c1);
        red.className="RedRed";
        l =document.createElement("label");
        l.innerHTML="Mesec: ";
        l.className="Podacilabela";
        red.appendChild(l);

        var listaMeseci=["Januar","Februar", "Mart", "April", "Maj", "Jun", "Jul", "Avgust","Septembar","Oktobar","Novembar","Decembar"];
        let se = document.createElement("select");
        se.className="mesec"
        red.appendChild(se);
        let op;
        listaMeseci.forEach(k=>{
            op=document.createElement("option");
            op.innerHTML=k;
            op.value=k;
            se.appendChild(op);
        })

        //Godina
        red = this.crtajRed(c1);
        red.className="RedRed";
        l =document.createElement("label");
        l.innerHTML="Godina: ";
        l.className="Podacilabela";
        red.appendChild(l);

        let poljeGodina = document.createElement("input");
        poljeGodina.type="number";
        poljeGodina.className="godina";
        red.appendChild(poljeGodina);

        //JB
        red = this.crtajRed(c1);
        red.className="RedRed";
        red.className="RedJBClanarina";
        l =document.createElement("label");
        l.innerHTML="JB: ";
        l.className="PodacilabelaJB";
        red.appendChild(l);

        var poljeJBc = document.createElement("input");
        poljeJBc.type="number";
        poljeJBc.className="jbc";
        red.appendChild(poljeJBc);

        l = document.createElement("button");
        l.innerHTML="Pregled";
        l.onclick=(ev=>this.pregledaj(poljeJBc.value, poljeGodina.value));
        red.appendChild(l);

        //Crtanje c2

        this.crtajCl2(c2);

    }

    pregledaj(jb, godina){


        var alr=0;
        if(!godina)
        {
            alert("Morate uneti godinu!");
            alr=1;
            return;
        }
        if(!jb)
        {
            alert("Mora se upisati JB člana kluba!");
            alr=1;
            return;
        }
        if(jb<1000 || jb>9999)
        {
            alert("JB članova kluba je četvorocifreni broj!");
            alr=1;
            return;
        }

        /* var b=0;
        this.listaClanovaKluba.forEach(p=>{
            if(p.jb==jb){
                b=1;
            }
        })
        if(b==0)
        {
            alert("Član kluba sa upisanim JB-om ne postoji.");
            alr=1;
            return;
        } */

        var b=0;
        this.listaClanarina.forEach(p=>{
            if(p.godina==godina){
                b=1;
            }
        })
        if(b==0)
        {
            alr=1;
        }
        
        b=0;
        this.listaClanarina.forEach(p=>{
            if(p.godina==godina && p.jb==jb){
                b=1;
            }
        })
        if(b==0)
        {
            alr=1;
        }

        fetch("https://localhost:5001/ClanKluba/PreuzmiClanoveKluba/"+this.nazivPK,
        {
            method:"GET"
        }).then(s=> {
                if(s.ok){
                    s.json().then(data=>{
                        data.forEach(d=>{
                            const clanKluba=new ClanKluba(d.jb, d.ime, d.prezime, d.datumRodjenja, d.kategorija, this.nazivPK);
                            this.listaClanovaKluba.push(clanKluba);
                        })
                        b=0;
                        this.listaClanarina.forEach(p=>{
                            if(p.godina==godina){
                                b=1;
                            }
                        })
                        if(b==0)
                        {
                            alert("Članarine sa upisanom godinom ne postoje.");
                            alr=1;
                            return;
                        }
                        var b=0;
                        this.listaClanovaKluba.forEach(p=>{
                            if(p.jb==jb){
                                b=1;
                            }
                        })
                        if(b==0)
                        {
                            alert("Član kluba sa upisanim JB-om ne postoji.");
                            alr=1;
                            return;
                        }
                        b=0;
                        this.listaClanarina.forEach(p=>{
                            if(p.godina==godina && p.jb==jb){
                                b=1;
                            }
                        })
                        if(b==0)
                        {
                            alert("Član nije platio ni jednu članarinu u upisanoj godini.");
                            alr=1;
                            return;
                        }

                        if(alr===0){
                            fetch("https://localhost:5001/Clanarina/PrikaziClanarine/"+godina+"/"+jb+"/"+this.nazivPK,
                            {
                                method:"GET"
                            }).then(s=> {
                                if(s.ok){
                                    var teloTabele=this.obrisiPrethodniSadrzajClanarine();
                                    s.json().then(data=>{
                                        data.forEach(p=>{
                                            if(p.godina==godina){
                                                this.crtajTabelaClanarina(teloTabele, p.mesec, p.godina, p.ime, p.prezime, p.ples, p.cena);
                                                this.container.querySelector(".Godina").innerHTML="Članarine za godinu: "+this.container.querySelector(".godina").value;
                                                this.listaClanarina.forEach(p=>{
                
                                                })
                                            }
                                        })   
                                    })
                                }
                            })
                        }

                    })
                }
        })

    }


    crtajCl2(host){

        var cl1 = document.createElement("div");//svetlo plavo clanarina 2
        cl1.className="c2cl1";
        host.appendChild(cl1);

        let red = this.crtajRed(cl1);
        red.innerHTML="Plesovi:";
    
        //Radio buttons u cl1
        let rbt;
        this.listaPlesova.forEach((ples, index)=>
            {
                red = this.crtajRed(cl1);
                red.className="RedRadio"
                rbt=document.createElement("input");
                rbt.type="radio";
                rbt.value=ples.naziv;
                rbt.name="Plesovi";
                red.appendChild(rbt);
                let l=document.createElement("label");
                l.innerHTML=ples.naziv;
                l.className="ples";
                red.appendChild(l);

                if(index==0)
                    rbt.checked=true;
            })


        var cl2 = document.createElement("div");//svetlo plavo clanarina 2
        cl2.className="c2cl2";
        host.appendChild(cl2);

        //Deo u cl2
        red = this.crtajRed(cl2);
        let l = document.createElement("label");
        l.innerHTML="Cena: ";
        red.appendChild(l);

        red = this.crtajRed(cl2);
        red.className="RedCenaClanarina";
        let poljeCena = document.createElement("input");
        poljeCena.type="number";
        poljeCena.className="cena";
        red.appendChild(poljeCena);

        l = document.createElement("button");
        l.innerHTML="Uplati";
        l.onclick=(ev=>this.uplati(poljeCena.value));
        red.appendChild(l);

    }


    uplati(cena){

        let jb = this.container.querySelector(".jbc").value;
        let godina = this.container.querySelector(".godina").value;
        let ples = this.container.querySelector("input[type='radio']:checked").value;
        let optionEl = this.container.querySelector(".mesec");
        const mesec = optionEl.options[optionEl.selectedIndex].value;
        
        var alrt=0;
        if(!godina || !cena)
        {
            alert("Treba uneti sve podatke o uplati!");
            alrt=1;
            return;
        }
        if(!jb)
        {
            alert("Mora se upisati JB člana kluba!");
            alrt=1;
            return;
        }
        if(jb<1000 || jb>9999)
        {
            alert("JB članova kluba je četvorocifreni broj!");
            alrt=1;
            return;
        }
        if(cena<1400 || cena>3700)
        {
            alert("Cena članarine nije u opsegu!");
            alrt=1;
            return;
        }
        var b=0;
        this.listaClanovaKluba.forEach(p=>{
            if(p.jb=jb){
                b++;
              }
          })

          if(b==0){
              alert("Član kluba sa upisanim JB-om ne postoji.");
            alrt=1;
            return;
          }

          b=0;
          this.listaClanarina.forEach(p=>{
              if(p.jb==jb && p.mesec==mesec && p.godina==godina && p.ples==ples){
                  b++;
                  return;
              }
          })
          if(b>=1){
              alert("Član je već platio članarinu za dati mesec.");
              alrt=1;
              return; 
          }

        fetch("https://localhost:5001/ClanKluba/PreuzmiClanoveKluba/"+this.nazivPK,
        {
            method:"GET"
        }).then(s=> {
                if(s.ok){
                    s.json().then(data=>{
                        data.forEach(d=>{
                            const clanKluba=new ClanKluba(d.jb, d.ime, d.prezime, d.datumRodjenja, d.kategorija, this.nazivPK);
                            this.listaClanovaKluba.push(clanKluba);
                        })
                    })

                    b=0;
                    this.listaClanovaKluba.forEach(p=>{
                      if(p.jb=jb){
                          b++;
                        }
                    })

                    if(b==0){
                      alert("Član kluba sa upisanim JB-om ne postoji.");
                      alrt=1;
                      return;
                    }
                    b=0;
                    this.listaClanarina.forEach(p=>{
                        if(p.jb==jb && p.mesec==mesec && p.godina==godina && p.ples==ples){
                            b++;
                            return;
                        }
                    })
                    if(b>=1){
                        var teloTabele=this.obrisiPrethodniSadrzajClanarine();
                        alert("Član je već platio članarinu za dati mesec.");
                        alrt=1;
                        return; 
                    }
                    

                  if(alrt==0){
                      fetch("https://localhost:5001/Clanarina/PlatiClanarinu/"+mesec+"/"+godina+"/"+jb+"/"+ples+"/"+cena+"/"+this.nazivPK,
                      {
                          method:"POST"
                      }).then(s=> {
                                  if(s.ok){
                                  teloTabele=this.obrisiPrethodniSadrzajClanarine();
                                  s.json().then(data=>{
                                      //console.log(data);
                                      
                                      data.forEach(p=>{
                                          if(p.jb==jb){   
                                          const clanarina=new Clanarina(p.jb, p.mesec, p.godina, p.ples, p.cena);
                                          this.listaClanarina.push(clanarina);
                                          this.container.querySelector(".Godina").innerHTML="Sve plaćene članarine: ";
                                          this.crtajTabelaClanarina(teloTabele, p.mesec, p.godina, p.ime, p.prezime, p.ples, p.cena);
                                          }
                                          else{
                                              alert("Član kluba sa unetim JB-om ne postoji.");
                                              return;
                                          }
                                          
                                      })
                                  })

                                  alert("Članarina je plaćena.");
                                  return;
                              }
                              
                              
                      })    
                  }
                       

                    //})
                }
        })

         
    } 
   


    obrisiPrethodniSadrzajClana(){
        var teloTabele = document.querySelector(".TabelaTeloPodaciClan");
        var roditelj=teloTabele.parentNode;
        roditelj.removeChild(teloTabele);

        teloTabele=document.createElement("tbody");
        teloTabele.className="TabelaTeloPodaciClan";
        roditelj.appendChild(teloTabele);
        return teloTabele;
    }

    obrisiPrethodniSadrzajClanarine(){
        var teloTabele = document.querySelector(".TabelaTeloPodaciClanarina");
        var roditelj=teloTabele.parentNode;
        roditelj.removeChild(teloTabele);

        teloTabele=document.createElement("tbody");
        teloTabele.className="TabelaTeloPodaciClanarina";
        roditelj.appendChild(teloTabele);
        return teloTabele;
    }

    crtajTabelaClanarina(host, mesec, godina, ime, prezime, ples, cena){

        var tr = document.createElement("tr");
        tr.className="RedClanarina";
        host.appendChild(tr);

        let el  =document.createElement("td");
        el.innerHTML=mesec;
        el.className="tdClanarina";
        tr.appendChild(el);

        el  =document.createElement("td");
        el.innerHTML=godina;
        el.className="tdClanarina";
        tr.appendChild(el);

        el  =document.createElement("td");
        el.innerHTML=ime;
        el.className="tdClanarina";
        tr.appendChild(el);

        el  =document.createElement("td");
        el.innerHTML=prezime;
        el.className="tdClanarina";
        tr.appendChild(el);

        el  =document.createElement("td");
        el.innerHTML=ples;
        el.className="tdClanarina";
        tr.appendChild(el);

        el  =document.createElement("td");
        el.innerHTML=cena;
        el.className="tdClanarina";
        tr.appendChild(el);
    }

    
}

