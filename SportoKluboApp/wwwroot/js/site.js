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

