// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function onchange_SelectProject() {
    var projectId

    projectId = document.getElementById("selectProject").value
    //console.log(projectId)
    if(projectId == "")
        return
    url = "/Api/Projects/" + projectId + "/Agencies"
    fetch(url)
        .then(response => {
            if (response.ok) {
                return response.json()
            } else {
                throw response.error
            }
        })
        .then(data => {
            //console.log(data)
            if (data.length > 0) {   
                var selectAgency
                
                selectAgency = document.getElementById("AgencyId");
                selectAgency.innerHTML = "";
                if (data.length > 1) {
                    option = document.createElement("option")
                    option.value = ""
                    option.text = "Seleccione"

                    selectAgency.appendChild(option)
                }
                data.forEach(element => {
                    var option;

                    option = document.createElement("option")
                    option.value = element.id
                    option.text = element.code + " " + element.name
                    if (document.getElementById("SettlementAux") != undefined) {
                        if (element.settementType + " " + element.settement == document.getElementById("SettlementAux").value) {
                            option.selected = true;
                        }
                    }
                    
                    selectAgency.appendChild(option)
                });
            }
        })
}