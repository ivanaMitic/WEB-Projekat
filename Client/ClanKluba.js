export class ClanKluba{
    constructor(jb, ime, prezime, datumRodjenja, kategorija, nazivPK)
    {
        this.jb=jb;
        this.ime=ime;
        this.prezime=prezime;
        this.datumRodjenja=datumRodjenja;
        this.kategorija=kategorija;
        this.nazivPK=nazivPK;
        this.container==null;
    }

    crtajRed(host){

        let red=document.createElement("div");
        red.className="Red";
        host.appendChild(red);
        return red;

    }

    /* crtajClan(host){

        let el  =document.createElement("td");
        el.innerHTML=this.ime;
        el.className="tdClanarina";
        host.appendChild(el);

        el  =document.createElement("td");
        el.innerHTML=this.prezime;
        el.className="tdClanarina";
        host.appendChild(el);

    } */

    crtajTabelaClan(host){

        var tr = document.createElement("tr");
        tr.className="RedPodaciClan";
        host.appendChild(tr);

        el  =document.createElement("td");
        el.innerHTML=this.jb;
        el.className="tdClan";
        tr.appendChild(el);

        var el  =document.createElement("td");
        el.innerHTML=this.ime;
        el.className="tdClan";
        tr.appendChild(el);

        el  =document.createElement("td");
        el.innerHTML=this.prezime;
        el.className="tdClan";
        tr.appendChild(el);

        el  =document.createElement("td");
        el.innerHTML=this.datumRodjenja;
        el.className="tdClan";
        tr.appendChild(el);

        el  =document.createElement("td");
        el.innerHTML=this.kategorija;
        el.className="tdClan";
        tr.appendChild(el);
        
    }
}