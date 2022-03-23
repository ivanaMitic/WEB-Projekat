export class ZajednicaPK{
    constructor(listaKlubova)
    {
        this.listaKlubova=listaKlubova;
        this.container=null;

    }

    crtajRed(host){

        let red=document.createElement("div");
        red.className="Red";
        host.appendChild(red);
        return red;

    }

    crtajPocetna(host)
    {
        this.container=document.createElement("div");
        this.container.className="GlavnaFormaPocetna";
        host.appendChild(this.container);

        let glavniNaslov = document.createElement("div");
        glavniNaslov.className="GlavniNaslovPocetna";
        glavniNaslov.innerHTML="Izaberite svoj Plesni Klub";
        this.container.appendChild(glavniNaslov);

        let red = this.crtajRed(host);
        red.className="RedKlubovi";
        let l =document.createElement("label");
        l.innerHTML="Plesni Klubovi: ";
        l.className="PodacilabelaKlubovi";
        red.appendChild(l);

        red = this.crtajRed(host);
        red.className="RedKlubovi";
        l =document.createElement("label");
        l.innerHTML="Password: ";
        l.className="PodacilabelaKlub";
        red.appendChild(l);

        var poljePrezime = document.createElement("input");
        poljePrezime.type="password";
        poljePrezime.className="password";
        red.appendChild(poljePrezime);

    }

    izaberiKlub(host){
        let optionEl = this.container.querySelector(".Klubovi");
        const klub = optionEl.options[optionEl.selectedIndex].value;

        optionEl = this.container.querySelector(".password");
        const pass = optionEl.options[optionEl.selectedIndex].value;

        if(pass==1000 && klub=="PK Step by Step")
        {
            alert("step");
        }
        else{
            alert("pogresan");
        }
    }
}