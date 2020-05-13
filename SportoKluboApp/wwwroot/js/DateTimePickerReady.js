

$(function () {

    var format = function formatDate(date) {
        var d = new Date(date),
            month = '' + (d.getMonth() + 1),
            day = '' + d.getDate(),
            year = d.getFullYear(),
            hours = d.getHours(),
            minutes = d.getMinutes();

        if (month.length < 2)
            month = '0' + month;
        if (day.length < 2)
            day = '0' + day;
        if (hours.length < 2)
            hours = '0' + hours;
        if (minutes.length < 2)
            minutes = '0' + minutes;

        return hours + ":" + minutes + " " + [year, month, day].join('-');
    }
    var logic = function (currentDateTime) {
        // 'this' is jquery object datetimepicker
        var dtField = $(".datetimefield");
        //dtField[0].setAttribute('Value', format(currentDateTime));//.value = format(currentDateTime);//.toString(' HH DD - MM - YYYY');
        dtField[0].value = format(currentDateTime);
        //dtField.val(currentDateTime);
    };
    $.datetimepicker.setDateFormatter('moment');
    $(".datetimefield").datetimepicker({
        format: ' HH:mm DD-MM-YYYY',
        formatTime: 'HH:mm',
        onChangeDateTime: logic,
    });

});