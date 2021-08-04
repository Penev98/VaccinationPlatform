$('#selectBookingDate, #selectDist, #selectTown, #selectHosp').change(function ClearData() {
    var inlineDiv = document.getElementById("checkAvailableButton");
    if (inlineDiv.childElementCount > 1) {
        inlineDiv.lastChild.remove();
    }
});

$(document).on('click', '#checkDateA', function CheckDate() {

    var inlineDiv = document.getElementById("checkAvailableButton");

    var hospitalField = document.getElementById("selectHosp");
    var hospitalId = hospitalField.options[hospitalField.selectedIndex].value;

    var bookingDate = document.getElementById("selectBookingDate").value;

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

$(document).one('click', '#selectDist', function GetAllDistricts() {
    var ele = document.getElementById('selectDist');

    while (ele.firstChild) {
        ele.removeChild(ele.firstChild);
    };

    $.ajax({
        type: "GET",
        url: "/Booking/GetAllDistrictsAjax",
        dataType: "json",
        success: function (result) {

            ele.innerHTML += '<option value=""></option>';

            for (var i = 0; i < result.length; i++) {
                ele.innerHTML = ele.innerHTML +
                    '<option value="' + result[i]['key'] + '">' + result[i]['value'] + '</option>'
            };
        },
        error: function (error) {
            alert(error);
        }
    });
});

$(document).on('change', '#selectDist', function GetTownsByDistrict() {

    var districtField = document.getElementById("selectDist");
    var districtId = districtField.options[districtField.selectedIndex].value;

    var ele = document.getElementById('selectTown');

    while (ele.firstChild) {
        ele.removeChild(ele.firstChild);
    };

    $.ajax({
        type: "GET",
        url: "/Booking/GetTownsByDistrictAjax",
        data: { districtId: districtId },
        dataType: "json",
        success: function (result) {

            ele.innerHTML += '<option value=""></option>';

            for (var i = 0; i < result.length; i++) {
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

    var townField = document.getElementById("selectTown");
    var townId = townField.options[townField.selectedIndex].value;
    var ele = document.getElementById('selectHosp');

    while (ele.firstChild) {
        ele.removeChild(ele.firstChild);
    };

    $.ajax({
        type: "GET",
        url: "/Booking/GetHospitalsByTownAjax",
        data: { townId: townId },
        dataType: "json",
        success: function (result) {

            ele.innerHTML += '<option value=""></option>';

            for (var i = 0; i < result.length; i++) {
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
    var ele = document.getElementById('selectDisease');

    while (ele.firstChild) {
        ele.removeChild(ele.firstChild);
    };

    $.ajax({
        type: "GET",
        url: "/Booking/GetAllDiseasesAjax",
        dataType: "json",
        success: function (result) {

            ele.innerHTML += '<option value=""></option>';

            for (var i = 0; i < result.length; i++) {
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
    var diseaseField = document.getElementById("selectDisease");
    var diseaseId = diseaseField.options[diseaseField.selectedIndex].value;
    var ele = document.getElementById('selectVaccine');

    while (ele.firstChild) {
        ele.removeChild(ele.firstChild);
    };

    $.ajax({
        type: "GET",
        url: "/Booking/GetVaccinesByDiseaseAjax",
        data: { diseaseId: diseaseId },
        dataType: "json",
        success: function (result) {

            for (var i = 0; i < result.length; i++) {
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

    var distSelect = document.getElementById('selectDistFilter');

    while (distSelect.firstChild) {
        distSelect.removeChild(distSelect.firstChild);
    };
    $.ajax({
        type: "GET",
        url: "/Locations/GetDistricts",
        dataType: "json",
        success: function (result) {
            distSelect.innerHTML += '<option value=""></option>';
            for (var i = 0; i < result.length; i++) {

                distSelect.innerHTML += '<option value="' + result[i]['key'] + '">' + result[i]['value'] + '</option>';
            }

        },
        error: function (error) {
            alert(error);
        }
    });
});

$(document).on('change', '#selectDistFilter', function GetDistricts() {

    var townsSelect = document.getElementById('selectTownFilter');

    var districtField = document.getElementById("selectDistFilter");
    var districtId = districtField.options[districtField.selectedIndex].value;

    while (townsSelect.firstChild) {
        townsSelect.removeChild(townsSelect.firstChild);
    };
    $.ajax({
        type: "GET",
        url: "/Locations/GetTowns",
        data: { districtId: districtId },
        dataType: "json",
        success: function (result) {

            for (var i = 0; i < result.length; i++) {

                townsSelect.innerHTML += '<option value="' + result[i]['key'] + '">' + result[i]['value'] + '</option>';
            }

        },
        error: function (error) {
            alert(error);
        }
    });
});

$(document).on('click', '#filterButton', function Filter() {

    var searchedTownId = document.getElementById('selectTownFilter').value;

    var allDiv = document.getElementById('allLocations');
    var allLocations = allDiv.getElementsByClassName('elementCard');

    //If there are any removed elements after filtering , reset them for the next filtering
    for (var i = 0; i < allLocations.length; i++) {

        var currentElement = allLocations[i];

        if (currentElement.classList.contains('hidden')) {

            currentElement.classList.remove('hidden');
        }
    }

    //Remove(add class = "hidden") the elements that don't match the filter criteria
    for (var i = 0; i < allLocations.length; i++) {

        var currentElement = allLocations[i];
        var hidden = currentElement.children[1];

        if (hidden.innerHTML != searchedTownId) {
            currentElement.classList.add('hidden');
            console.log("removed");
        }

    }
});

$(document).one('click', '#selectDiseaseFilter', function GetDiseases() {

    var diseaseSelect = document.getElementById('selectDiseaseFilter');

    while (diseaseSelect.firstChild) {
        diseaseSelect.removeChild(diseaseSelect.firstChild);
    };
    $.ajax({
        type: "GET",
        url: "/MedicalInfo/GetDiseases",
        dataType: "json",
        success: function (result) {
            diseaseSelect.innerHTML += '<option value=""></option>';
            for (var i = 0; i < result.length; i++) {

                diseaseSelect.innerHTML += '<option>' + result[i] + '</option>';
            }

        },
        error: function (error) {
            alert(error);
        }
    });
});

$(document).on('click', '#searchButton', function Search() {

    var allDiseases = document.getElementsByClassName('diseaseGroup');
    var searchedName = document.getElementById('selectDiseaseFilter').value;

    if (searchedName != "") {

        for (var i = 0; i < allDiseases.length; i++) {

            var currentElement = allDiseases[i];

            if (!currentElement.classList.contains('hidden')) {

                currentElement.classList.add('hidden');
            }
        }

        for (var i = 0; i < allDiseases.length; i++) {

            var currentElement = allDiseases[i];

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
