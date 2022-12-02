$(document).ready(function(){        
    $("#table").DataTable({
        "processing":true,
        "serverSide": true,
        "ajax":{
            "url": "/Api/Agencies",
            "type":"GET",
            "datatype":"json"
        },
        "pageLength": 10,                
        "columns":[
              {"data":"code", "name":"Clave de agencia"}
            , {"data":"agencyType.name", "name":"Tipo"}
            , {"data":"name", "name":"Nombre"} 
            , {"data":"state", "name":"Estado"} 
            , { "data" : "dateRegistration"
                , "name" : "Fecha"
                , "mRender" : function (data, type, row) {
                    return data.substring(0,10) //Date.Parse(data).toString().format('DD/MM/YYYY');
                }               
            }
            , { "data" : null,
                "bSortable" : false,
                "mRender" : function (data, type,value){
                    return '<a href="/Agencies/Details/' + value['id'] + '" class="btn btn-info text-white">'
                    + '     <i class="align-middle" data-feather="clipboard"></i>'
                    + '     <span class="align-middle">Detalles</span>'
                    + '</a>'
                    + ' <a href="/Agencies/Edit/' + value['id'] + '" class="btn btn-warning text-white">'
                    + '     <i class="align-middle" data-feather="edit"></i> '
                    + '     <span class="align-middle">Editar</span>'
                    + ' </a>'
                    + ' <a href="/Agencies/Delete/' + value['id'] + '" class="btn btn-danger">'
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