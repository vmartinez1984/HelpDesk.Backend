var listDevices;
var listDevicesOrigin;
var agencySelected;

listDevices = new Array();
listDevicesOrigin = new Array();
function onkeyup_searchDevice(event) {

}

function onclick_searchDevice() {
    var name;
    var url;

    name = document.getElementById("searchDevice").value;
    url = "/Api/Devices?Name=" + name + "&SerialNumber=" + name + "&RecordsPerPage=25";
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
            listDevicesOrigin = data
            setButtons()
        })
}

function setButtons() {
    document.getElementById("listDevices").innerHTML = ""
    listDevicesOrigin.forEach(item => {
        code = "<button class='btn btn-primary ms-1' type='button' id='device_" + item.id + "' onclick='onclick_addDevice(" + item.id + ")'>"
        code += "[" + item.id + "] " + item.name + "<br/>"
        if (code.serialNumber != null)
            code += code.serialNumber + "<br/>"
        code += '<i class="align-middle" data-feather="search"></i>'
        code += '<span class="align-middle">Agregar</span>'
        code += "</button>";
        document.getElementById("listDevices").innerHTML += code
    })
}

function onclick_addDevice(deviceId) {
    var device

    device = listDevicesOrigin.find(x => x.id == deviceId);
    listDevices.push(device)
    document.getElementById("device_" + deviceId).remove();
    addDevice()
}

function addDevice() {
    document.getElementById("listDevicesAdds").innerHTML = ""
    listDevices.forEach(item => {
        code = "<button class='btn btn-info ms-1' type='button' id='device_" + item.id + "' onclick='onclick_removeDevice(" + item.id + ")'>"
        code += "[" + item.id + "] " + item.name + "<br/>"
        if (code.serialNumber != null)
            code += code.serialNumber + "<br/>"
        code += '<i class="align-middle" data-feather="search"></i>'
        code += '<span class="align-middle">Remover</span>'
        code += "</button>";
        document.getElementById("listDevicesAdds").innerHTML += code
    })
    setInputDevices()
}

function onclick_removeDevice(deviceId) {
    var device

    document.getElementById("device_" + deviceId).remove()
    onclick_searchDevice()
    device = listDevices.find(x => x.id == deviceId)
    index = listDevices.indexOf(device)
    listDevices.splice(index, 1)
    setInputDevices()
}

function setInputDevices() {
    i = 0;
    listDevices.forEach(item => {
        code = "<input type='hidden' name='ListDeviceIds[" + i + "]' value='" + item.id + "'/>"
        document.getElementById("inputDevices").innerHTML += code
        i++
    })
}

function onclick_searchAgency() {
    var code;
    var name;
    var url;

    code = document.getElementById("agencySearchCode").value
    name = document.getElementById("Name").value
    url = "/Api/Agencies?code=" + code + "&name=" + name
    fetch(url)
        .then(response => {
            if (response.ok) {
                return response.json()
            } else {
                throw response.error
            }
        })
        .then(data => {
            setAgencies(data)
        })
}

function setAgencies(data) {
    //console.log(data)
    document.getElementById("group").innerHTML = ""
    data.forEach(item => {
        code = '<input type="radio" class="btn-check" name="agencyId" id="agencyId_' + item.id + '" value="' + item.id + '" autocomplete="off" >'
        code += '<label class="btn btn-outline-info" for="agencyId_' + item.id + '">' + item.code + ' ' + item.name + '</label>'
        document.getElementById("group").innerHTML += code
    })
}

function selectAgency() {
    const radios = document.getElementsByName('agencyId');
    var agencyId;

    agencyId = 0;
    for (var i = 0; i < radios.length; i++) {
        if (radios[i].checked) {
            console.log(radios[i].value)
            agencyId = radios[i].value
            break;
        }
    }
    if (agencyId == 0) {
        document.getElementById("agencyIdNoSelect").style.display = "block";
    } else {
        setAgencySelected(agencyId);
    }
}

function setAgencySelected(agencyId) {

    url = "/Api/Agencies/" + agencyId;
    fetch(url)
        .then(response => {
            if (response.ok) {
                return response.json()
            } else {
                throw response.error
            }
        })
        .then(data => {
            agencySelected = data
            setAgencyToForm(data)
            console.log(data)
            $('#modalSelecAgency').modal('hide')
        })
}

function setAgencyToForm(agency) {    
    document.getElementById("AgencyId").value = agency.id
    document.getElementById("ProjectId").value = agency.projectId
    document.getElementById("AgencyTypeId").value = agency.agencyTypeId
    document.getElementById("Code").value = agency.code
    document.getElementById("Name").value = agency.name
    document.getElementById("Phone").value = agency.phone
    document.getElementById("email").value = agency.email
}

function cleanForm(){
    document.getElementById("AgencyId").value = ""
    document.getElementById("ProjectId").value = ""
    document.getElementById("AgencyTypeId").value = ""
    document.getElementById("Code").value = ""
    document.getElementById("Name").value = ""
    document.getElementById("Phone").value = ""
    document.getElementById("email").value = ""
    document.getElementById("Notes").value = ""
}