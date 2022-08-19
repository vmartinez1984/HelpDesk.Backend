// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function(){        
    $("#table").DataTable({
        "processing":true,
        "serverSide": true,
        "ajax":{
            "url": "/Api/Persons",
            "type":"GET",
            "datatype":"json"
        },
        "pageLength": 10,                
        "columns":[
            {"data":"name", "name":"Nombre"}
            , {"data":"lastName", "name":"Apellidos"} 
            , {"data":"agencyName", "name":"Agency"} 
            , { "data" : "dateRegistration"
                , "name" : "Fecha"
                , "mRender" : function (data, type, row) {
                    return data.substring(0,10) //Date.Parse(data).toString().format('DD/MM/YYYY');
                }               
            }
            , { "data" : null,
                "bSortable" : false,
                "mRender" : function (data, type,value){
                    return '<a href="/Persons/Details/' + value['id'] + '" class="btn btn-info text-white">'
                    + '     <i class="align-middle" data-feather="clipboard"></i>'
                    + '     <span class="align-middle">Detalles</span>'
                    + '</a>'
                    + ' <a href="/Persons/Edit/' + value['id'] + '" class="btn btn-warning text-white">'
                    + '     <i class="align-middle" data-feather="edit"></i> '
                    + '     <span class="align-middle">Editar</span>'
                    + ' </a>'
                    + ' <a href="/Persons/Delete/' + value['id'] + '" class="btn btn-danger">'
                    + '     <i class="align-middle" data-feather="delete"></i> '
                    + '     <span class="align-middle">Borrar</span>'
                    + ' </a>'
                }
                , "autoWidth":true
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