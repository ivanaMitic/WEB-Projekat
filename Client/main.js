import { Ples } from "./Ples.js";
import { PlesniKlub } from "./PlesniKlub.js";
import { Clanarina } from "./Clanarina.js";
import { ClanKluba } from "./ClanKluba.js";

var listaKlubova=[];
var listaPlesova=[];
var listaClanarina=[];

fetch("https:\\localhost:5001/PlesniKlub/PrikaziPlesniKlubSve/")
.then(p=>{
    if(p.ok){
        p.json().then(klubovi=>{
            klubovi.forEach(klub=>{
                listaKlubova.push(klub);
            })

        crtajPocetnu();
        
        function crtajPocetnu(){
        let glavna=document.createElement("div");
        glavna.className="GlavnaFormaPocetna";
        document.body.appendChild(glavna);

        let red=document.createElement("div");
         red.className="PocetnaNaslov";
         red.innerHTML="Izaberite svoj Plesni Klub!";
         glavna.appendChild(red);

         red=document.createElement("div");
         red.className="IzborPK";
         glavna.appendChild(red);

         let l = document.createElement("label")
         l.className="IzborLabela";
         l.innerHTML="Plesni Klubovi: ";
         red.appendChild(l);

         l=document.createElement("select");
         l.className="IzborUpisKlub";
         red.appendChild(l);

         let op;
         listaKlubova.forEach(klub=>{
             op=document.createElement("option");
             op.className="opcije";
             op.value=klub.nazivPK;
             op.innerHTML=klub.nazivPK;
             l.appendChild(op);
         })

         red=document.createElement("div");
         red.className="Password";
         glavna.appendChild(red);

         l = document.createElement("label")
         l.className="PasswordLabela";
         l.innerHTML="Password: ";
         red.appendChild(l);

         let poljePass=document.createElement("input");
         poljePass.type="password";
         poljePass.className="IzborUpisPass";
         red.appendChild(poljePass);

         let dugme = document.createElement("button");
         dugme.className="PrijaviSe";
         dugme.innerHTML="Prijavi se";
         red.appendChild(dugme);
         dugme.addEventListener("click", ulogujSe);
        }

         function ulogujSe(){
            
            let optionEl = document.body.querySelector(".IzborUpisKlub");
            const klub = optionEl.options[optionEl.selectedIndex].value;
            const pass = document.body.querySelector(".IzborUpisPass").value;

            listaKlubova.forEach(p=>{
                if(p.pass==pass && p.nazivPK==klub)
                {
                    fetch("https:\\localhost:5001/Ples/PrikaziPles/"+klub)
                    .then(p=>{
                        p.json().then(plesovi=>{
                            plesovi.forEach(ples=>{
                            var p = new Ples(ples.naziv, ples.nazivPK);
                            listaPlesova.push(p);
                            })

                            fetch("https:\\localhost:5001/Clanarina/PreuzmiClanarine/"+klub)
                            .then(p=>{
                                p.json().then(clanarine=>{
                                    clanarine.forEach(clanarina=>{
                                    var c = new Clanarina(clanarina.jb, clanarina.mesec, clanarina.godina, clanarina.ples, clanarina.cena, clanarina.nazivPK);
                                    listaClanarina.push(c);
                                    
                                    })
                                })
                                    var sadrzaj = document.querySelector(".GlavnaFormaPocetna");
                                    var roditelj=sadrzaj.parentNode;
                                    roditelj.removeChild(sadrzaj);
                                    
                                    var plesniKlub=new PlesniKlub(listaPlesova, listaClanarina, klub);
                                    plesniKlub.crtaj(document.body);
                                    alert("Uspešna prijava.");
                                    return;
                                })    
                            })
                    })  
                }
                else{
                    if(p.nazivPK==klub && p.pass!=pass){ 
                        alert("Upišite validan Password!");
                        return;
                    }
                }
            })
        }
        })
    }
})  

 








