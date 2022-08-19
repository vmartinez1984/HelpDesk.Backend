$(document).ready(function(){        
    $("#table").DataTable({
        "processing":true,
        "serverSide": true,
        "ajax":{
            "url": "/Api/Devices",
            "type":"GET",
            "datatype":"json"
            //, success: function(data){console.log(data)}
        },
        "pageLength": 10,                
        "columns":[
              {data:"name", name:"Nombre"}
            , {data:"serialNumber", name:"Número de serie"}
            , {data:"dateStart", name:"Fecha de inicio"} 
            , {data:"dateEnd", name:"Fecha fin"} 
            , {data:"deviceStateName", name:"Estado"}             
            , { "data" : null,
                "bSortable" : false,
                "mRender" : function (data, type,value){
                    return '<a href="/Devices/Details/' + value['id'] + '" class="btn btn-info text-white">'
                    + '     <i class="align-middle" data-feather="clipboard"></i>'
                    + '     <span class="align-middle">Detalles</span>'
                    + '</a>'
                    + ' <a href="/Devices/Edit/' + value['id'] + '" class="btn btn-warning text-white">'
                    + '     <i class="align-middle" data-feather="edit"></i> '
                    + '     <span class="align-middle">Editar</span>'
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