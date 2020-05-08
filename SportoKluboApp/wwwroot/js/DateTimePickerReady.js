$(function () {
    $.datetimepicker.setDateFormatter('moment');
    $(".datetimefield").datetimepicker({
        format: ' HH:mm DD-MM-YYYY',
        formatTime: 'HH:mm '
    });
});