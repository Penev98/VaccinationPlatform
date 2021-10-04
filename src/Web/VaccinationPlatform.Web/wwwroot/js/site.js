$('#selectBookingDate, #selectDist, #selectTown, #selectHosp').change(function ClearData() {
    let inlineDiv = document.getElementById("checkAvailableButton");
    if (inlineDiv.childElementCount > 1) {
        inlineDiv.lastChild.remove();
    }
});

$(document).on('click', '#checkDateA', function CheckDate() {

    let inlineDiv = document.getElementById("checkAvailableButton");

    let hospitalField = document.getElementById("selectHosp");
    let hospitalId = hospitalField.options[hospitalField.selectedIndex].value;

    let bookingDate = document.getElementById("selectBookingDate").value;

    $.ajax({
        type: "GET",
        url: "/Booking/CheckDate",
        data: { hospitalId: hospitalId, bookingDate: bookingDate },
        dataType: "json",
        success: function (result) {

            if (result == 0) {
                if (inlineDiv.childElementCount > 1) {
                    inlineDiv.lastChild.removeChild();
                }
                inlineDiv.innerHTML = inlineDiv.innerHTML + '<a class="btn btn-success">Available</a>';
            }
            else {
                if (inlineDiv.childElementCount > 1) {
                    inlineDiv.lastChild.removeChild();
                }
                inlineDiv.innerHTML = inlineDiv.innerHTML + '<a class="btn btn-danger">Not Available</a>';
            }
        },
        error: function (error) {
            alert(error);
        }
    });
});

//GET Districts AJAX
$(document).one('click', '#selectDist', function GetAllDistricts() {
    let ele = document.getElementById('selectDist');

    while (ele.firstChild) {
        ele.removeChild(ele.firstChild);
    };

    $.ajax({
        type: "GET",
        url: "/api/data/districts",
        dataType: "json",
        success: function (result) {

            ele.innerHTML += '<option value=""></option>';

            for (let i = 0; i < result.length; i++) {
                ele.innerHTML = ele.innerHTML +
                    '<option value="' + result[i]['key'] + '">' + result[i]['value'] + '</option>'
            };
        },
        error: function (error) {
            alert(error);
        }
    });
});

//GET Towns AJAX
$(document).on('change', '#selectDist', function GetTownsByDistrict() {

    let districtField = document.getElementById("selectDist");
    let districtId = districtField.options[districtField.selectedIndex].value;

    let ele = document.getElementById('selectTown');

    while (ele.firstChild) {
        ele.removeChild(ele.firstChild);
    };

    $.ajax({
        type: "GET",
        url: "/api/data/towns",
        data: { districtId: districtId },
        dataType: "json",
        success: function (result) {

            ele.innerHTML += '<option value=""></option>';

            for (let i = 0; i < result.length; i++) {
                ele.innerHTML = ele.innerHTML +
                    '<option value="' + result[i]['key'] + '">' + result[i]['value'] + '</option>'
            };
        },
        error: function (error) {
            alert(error);
        }
    });
});

$('#selectTown, #selectDist').change(function GetHospitalsByTown() {

    let townField = document.getElementById("selectTown");
    let townId = townField.options[townField.selectedIndex].value;
    let ele = document.getElementById('selectHosp');

    while (ele.firstChild) {
        ele.removeChild(ele.firstChild);
    };

    $.ajax({
        type: "GET",
        url: "/api/data/hospitals",
        data: { townId: townId },
        dataType: "json",
        success: function (result) {

            ele.innerHTML += '<option value=""></option>';

            for (let i = 0; i < result.length; i++) {
                ele.innerHTML = ele.innerHTML +
                    '<option value="' + result[i]['key'] + '">' + result[i]['value'] + '</option>'
            };
        },
        error: function (error) {
            alert(error);
        }
    });
});

$(document).one('click', '#selectDisease', function GetAllDiseases() {
    let ele = document.getElementById('selectDisease');

    while (ele.firstChild) {
        ele.removeChild(ele.firstChild);
    };

    $.ajax({
        type: "GET",
        url: "/api/data/diseases",
        dataType: "json",
        success: function (result) {

            ele.innerHTML += '<option value=""></option>';

            for (let i = 0; i < result.length; i++) {
                ele.innerHTML = ele.innerHTML +
                    '<option value="' + result[i]['key'] + '">' + result[i]['value'] + '</option>'
            };
        },
        error: function (error) {
            alert(error);
        }
    });
});

$(document).on('change', '#selectDisease', function GetVaccinesByDisease() {
    let diseaseField = document.getElementById("selectDisease");
    let diseaseId = diseaseField.options[diseaseField.selectedIndex].value;
    let ele = document.getElementById('selectVaccine');

    while (ele.firstChild) {
        ele.removeChild(ele.firstChild);
    };

    $.ajax({
        type: "GET",
        url: "/api/data/vaccines",
        data: { diseaseId: diseaseId },
        dataType: "json",
        success: function (result) {

            for (let i = 0; i < result.length; i++) {
                ele.innerHTML = ele.innerHTML +
                    '<option value="' + result[i]['key'] + '">' + result[i]['value'] + '</option>'
            };
        },
        error: function (error) {
            alert(error);
        }
    });
});

$(document).one('click', '#selectDistFilter', function GetDistricts() {

    let distSelect = document.getElementById('selectDistFilter');

    while (distSelect.firstChild) {
        distSelect.removeChild(distSelect.firstChild);
    };
    $.ajax({
        type: "GET",
        url: "/api/data/districts",
        dataType: "json",
        success: function (result) {
            distSelect.innerHTML += '<option value=""></option>';
            for (let i = 0; i < result.length; i++) {

                distSelect.innerHTML += '<option value="' + result[i]['key'] + '">' + result[i]['value'] + '</option>';
            }

        },
        error: function (error) {
            alert(error);
        }
    });
});

$(document).on('change', '#selectDistFilter', function GetTowns() {

    let townsSelect = document.getElementById('selectTownFilter');

    let districtField = document.getElementById("selectDistFilter");
    let districtId = districtField.options[districtField.selectedIndex].value;

    while (townsSelect.firstChild) {
        townsSelect.removeChild(townsSelect.firstChild);
    };
    $.ajax({
        type: "GET",
        url: "/api/data/towns",
        data: { districtId: districtId },
        dataType: "json",
        success: function (result) {

            for (let i = 0; i < result.length; i++) {

                townsSelect.innerHTML += '<option value="' + result[i]['key'] + '">' + result[i]['value'] + '</option>';
            }

        },
        error: function (error) {
            alert(error);
        }
    });
});

$(document).on('click', '#filterButton', function Filter() {

    let searchedTownId = document.getElementById('selectTownFilter').value;

    let allDiv = document.getElementById('allLocations');
    let allLocations = allDiv.getElementsByClassName('elementCard');

    //If there are any removed elements after filtering , reset them for the next filtering
    for (let i = 0; i < allLocations.length; i++) {

        let currentElement = allLocations[i];

        if (currentElement.classList.contains('hidden')) {

            currentElement.classList.remove('hidden');
        }
    }

    //Remove(add class = "hidden") the elements that don't match the filter criteria
    for (let i = 0; i < allLocations.length; i++) {

        let currentElement = allLocations[i];
        let hidden = currentElement.children[1];

        if (hidden.innerHTML != searchedTownId) {
            currentElement.classList.add('hidden');
            console.log("removed");
        }

    }
});

$(document).one('click', '#selectDiseaseFilter', function GetDiseases() {

    let diseaseSelect = document.getElementById('selectDiseaseFilter');

    while (diseaseSelect.firstChild) {
        diseaseSelect.removeChild(diseaseSelect.firstChild);
    };
    $.ajax({
        type: "GET",
        url: "/MedicalInfo/GetDiseases",
        dataType: "json",
        success: function (result) {
            diseaseSelect.innerHTML += '<option value=""></option>';
            for (let i = 0; i < result.length; i++) {

                diseaseSelect.innerHTML += '<option>' + result[i] + '</option>';
            }

        },
        error: function (error) {
            alert(error);
        }
    });
});

$(document).on('click', '#searchButton', function Search() {

    let allDiseases = document.getElementsByClassName('diseaseGroup');
    let searchedName = document.getElementById('selectDiseaseFilter').value;

    if (searchedName != "") {

        for (let i = 0; i < allDiseases.length; i++) {

            let currentElement = allDiseases[i];

            if (!currentElement.classList.contains('hidden')) {

                currentElement.classList.add('hidden');
            }
        }

        for (let i = 0; i < allDiseases.length; i++) {

            let currentElement = allDiseases[i];

            if (currentElement.innerHTML.includes(searchedName)) {
                currentElement.classList.remove('hidden');
                console.log("removed");
            }
        }
    }
});

$(function () {
    $('[data-toggle="tooltip"]').tooltip()
})

$('.confirmCancel').on('click', function () {
    return confirm('Are you sure you want to cancel this appointment?');
});

$('.confirmRemove').on('click', function () {
    return confirm('If the booking is active this will cancel and delete it. Are you sure you want to remove this booking completely?');
});
$('.confirmChanges').on('click', function () {
    return confirm('Do you want to save these changes?');
});
