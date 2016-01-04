



jQuery.fn.ForceNumericOnly = function () {
    return this.each(function () {
        $(this).keydown(function (e) {
            var key = e.charCode || e.keyCode || 0;
            // allow backspace, tab, delete, arrows, numbers and keypad numbers ONLY
            // home, end, period, and numpad decimal
            return (
                key == 8 ||
                key == 9 ||
                key == 46 ||
                key == 110 ||
                key == 190 ||
                (key >= 35 && key <= 40) ||
                (key >= 48 && key <= 57) ||
                (key >= 96 && key <= 105));
        });
    });
};

$.fn.validation = function () {
    var blnIsError = true;
    $('.req', this).each(function () {


        if ($(this).val() == "") {
            $(this).addClass("ErrorMessage");
            $(this)[0].title = 'Enter required field.';
            blnIsError = false;

        }
        if ($(this).val() == "0") {
            $(this).addClass("ErrorMessage");
            $(this)[0].title = 'Enter required field.';
            blnIsError = false;
        }
    });
    $('.req').bind("keyup", function () {
        if ($(this).val() != '') {
            $(this).removeClass('ErrorMessage');
            $(this)[0].title = '';
        }
        if ($(this).val() != "0") {
            $(this).addClass("ErrorMessage");
            $(this)[0].title = 'Enter required field.';
            blnIsError = false;
        }
    });

    return blnIsError;
};

function CheckFirstChar(key, txt) {
    if (key == 32 && txt.value.length <= 0 || txt.value.charCodeAt(0) == 8) {
        return false;
    }
    else if (txt.value.length > 0) {
        if (txt.value.charCodeAt(0) == 32) {
            txt.value = txt.value.substring(1, txt.value.length);
            return true;
        }
    }
    return true;
}