$(document).ready(function () {
    $('.join-button').on('click', function (e) {
        markJoined(e.target);
    });
});

function markJoined(button) {
    button.disabled = true;

    var form = button.closest('form');
    form.submit();
}

$(document).ready(function () {
    $(function () {
        $(".date-picker").datetimepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: "-100:+0",
            dateFormat: 'dd-MM-yyyy',
            controlType: 'select',
            timeFormat: 'HH:mm'
        });

    });

    jQuery.validator.methods.date = function (value, element) {
        var isChrome = /Chrome/.test(navigator.userAgent) && /Google Inc/.test(navigator.vendor);
        if (isChrome) {
            var d = new Date();
            return this.optional(element) || !/Invalid|NaN/.test(new Date(d.toLocaleDateString(value)));
        } else {
            return this.optional(element) || !/Invalid|NaN/.test(new Date(value));
        }
    };