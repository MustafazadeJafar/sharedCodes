
function GetCountries(link = "https://restcountries.com/v3.1/all"){
    return fetch(link)
    .then(res=>res.json());
}

async function FillTheScreen(){
    let rawdata = await GetCountries();
    Compile(rawdata);
}

function Compile(RawJsData){
    // let RawJsData = GetCountries("https://restcountries.com/v3.1/all");
    let PutHere = document.getElementById("list1");
    let ToPut = "";

    RawJsData.forEach(elem => {
        ToPut +=
        `<div class="card" style="width: 18rem;">
            <img src="${elem.flags.svg}" class="card-img-top" style="height:150px;" alt="...">
            <div class="card-body">
                <h5 class="card-title">${elem.name.common}\nf</h5>
                <p class="card-text">common</p>
                <a href="#" class="btn btn-primary">Detail</a>
            </div>
        </div>`
    })

    PutHere.innerHTML = ToPut;
}

FillTheScreen();
