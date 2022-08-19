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