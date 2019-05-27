//$(document).ready(function () {
//    $('#table tr [type="checkbox"]').each(function (i, e) {
//        markCompleted(e);
//    });

//    $('.table table-hover');
$(document).ready(function () {
        $('#table tr [type="checkbox"]').each(function (i, e) {
            markCompletedLoad(e);
    });

    // Wire up all of the checkboxes to run markCompleted()
    $('.done-checkbox').on('click', function (e) {
        markCompleted(e.target);
    });
});

function markCompleted(checkbox) {
    var row = checkbox.closest('tr');
    if (checkbox.checked) {        
        $(row).addClass('done');
    } else {
        $(row).removeClass('done');
    }

    var form = checkbox.closest('form');
    form.submit();
}

function markCompletedLoad(checkbox) {
    var row = checkbox.closest('tr');
    if (checkbox.checked) {
        $(row).addClass('done');
    } else {
        $(row).removeClass('done');
    }
}
