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
                if (document.getElementById("State_") != null)
                    document.getElementById("State_").value = data[0].state;
                if (document.getElementById("TownHall_") != null)
                    document.getElementById("TownHall_").value = data[0].municipality;

                var selectSettlement;

                selectSettlement = document.getElementById("Settlement");
                selectSettlement.innerHTML = "";
                if (data.length > 1) {
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
                    if (document.getElementById("SettlementAux") != undefined) {
                        if (element.settementType + " " + element.settement == document.getElementById("SettlementAux").value) {
                            option.selected = true;
                        }
                    }

                    selectSettlement.appendChild(option)
                });
            }
        })
}

document.addEventListener("DOMContentLoaded", function (event) {
    zipCode = document.getElementById("ZipCode").value
    if (zipCode.length == 5)
        searchZipcode(zipCode)
});