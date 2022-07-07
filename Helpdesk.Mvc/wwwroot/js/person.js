// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function onchange_SelectProject() {
    var selectProject

    selectProject = document.getElementById("selectProject")
    url = "/Api/agencies/" +  selectProject.value

    console.log(selectProject.value)
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
                var selectAgency
                
                selectAgency = document.getElementById("selectAgency");
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

                    selectAgency.appendChild(option)
                });
            }
        })
}