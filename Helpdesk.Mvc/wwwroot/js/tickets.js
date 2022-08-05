$(document).ready(function () {
    $("#table").DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": {
            "url": "/Api/Agencies",
            "type": "GET",
            "datatype": "json"
        },
        "pageLength": 10,
        "columns": [
            { "data": "code", "name": "Clave" }
            , { "data": "agencyType.name", "name": "Tipo" }
            , { "data": "name", "name": "Nombre" }
            , { "data": "state", "name": "Estado" }
            , {
                "data": "dateRegistration"
                , "name": "Fecha"
                , "mRender": function (data, type, row) {
                    return data.substring(0, 10) //Date.Parse(data).toString().format('DD/MM/YYYY');
                }
            }
            , {
                "data": null,
                "bSortable": false,
                "mRender": function (data, type, value) {
                    return '<button type="button" onclick="setAgency(' + value['id'] + ')" class="btn btn-info text-white">'
                        + '     <i class="align-middle" data-feather="clipboard"></i>'
                        + '     <span class="align-middle">Seleccionar</span>'
                        + '</button>'
                }
                , "autoWidth": true
            }
        ],
        lengthChange: true,
        "language": {
            "lengthMenu": "Mostrando _MENU_ registros por página",
            "zeroRecords": "Registro(s) no encontrado(s)",
            "info": "Página _PAGE_ de _PAGES_, _TOTAL_ elementos",
            "infoEmpty": "Registros no disponibles",
            "infoFiltered": "(de _MAX_ elementos en total)",
            "search": "Buscar",
            "processing": "<h2 class='text-info'>Cargando, espere un momento</h2>",
            paginate: {
                previous: '‹',
                next: '›'
            },
            aria: {
                paginate: {
                    previous: 'Anterior',
                    next: 'Siguiente'
                }
            }
        }
    })
})

function setAgency(agencyId) {
    document.getElementById('AgencyId').value = agencyId
    loadAgency(agencyId)
    loadPersons(agencyId)
    $('#modalSelecAgency').modal('hide')
}

function loadAgency(agencyId) {
    var url

    url = "/Api/Agencies/" + agencyId
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
            document.getElementById("agency").value = data.code + " " + data.name
        });
}

function loadPersons(agencyId) {
    var url

    url = "/Api/Agencies/" + agencyId + "/Persons"
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
                var select
                
                select = document.getElementById("PersonId");
                select.innerHTML = "";
                if (data.length > 1) {
                    option = document.createElement("option")
                    option.value = ""
                    option.text = "Seleccione"

                    select.appendChild(option)
                }
                data.forEach(element => {
                    var option;

                    option = document.createElement("option")
                    option.value = element.id
                    option.text = element.name + " " + element.lastName
                    // if (document.getElementById("SettlementAux") != undefined) {
                    //     if (element.settementType + " " + element.settement == document.getElementById("SettlementAux").value) {
                    //         option.selected = true;
                    //     }
                    // }
                    
                    select.appendChild(option)
                });
            }
        });
}

function loadSubcategories() {
    var url
    var categoryId

    categoryId = document.getElementById("CategoryId").value;
    url = "/Api/Categories/" + categoryId + "/Subcategories"
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
                var select
                
                select = document.getElementById("SubcategoryId");
                select.innerHTML = "";
                if (data.length > 1) {
                    option = document.createElement("option")
                    option.value = ""
                    option.text = "Seleccione"

                    select.appendChild(option)
                }
                data.forEach(element => {
                    var option;

                    option = document.createElement("option")
                    option.value = element.id
                    option.text = element.name
                    
                    select.appendChild(option)
                });
            }
        });
}