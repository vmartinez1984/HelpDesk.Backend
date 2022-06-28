// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function onkeyupZipCode(event) {
    zipCode = document.getElementById("ZipCode").value;
    if (zipCode.length == 5)
        searchZipcode(zipCode)
}

function searchZipcode(zipCode) {
    url = "/Api/zipcodes/" + zipCode

    console.log(zipCode)
    fetch(url)
        .then(response => {
            if (response.ok) {
                return response.json()
            } else {
                throw response.error
            }
        })
        .then(data => {
            console.log(data)
            if (data.length > 0) {
                document.getElementById("State").value = data[0].state;
                document.getElementById("TownHall").value = data[0].municipality;
                var selectSettlement;

                selectSettlement = document.getElementById("Settlement");
                selectSettlement.innerHTML = "";
                // for (i = 0; i < data.length; i++) {
                //     var option;

                //     option = document.createElement("option")
                //     option.value = data[i].settementType + " " + data[i].settement
                //     option.text = data[i].settementType + " " + data[i].settement
                //     selectSettlement.appendChild(option)
                // }
                if(data.length > 1){
                    option = document.createElement("option")
                    option.value = ""
                    option.text = "Seleccione"

                    selectSettlement.appendChild(option)
                }
                data.forEach(element => {
                    var option;

                    option = document.createElement("option")
                    option.value = element.settementType + " " + element.settement
                    option.text = element.settementType + " " + element.settement

                    selectSettlement.appendChild(option)
                });
            }
        })
}