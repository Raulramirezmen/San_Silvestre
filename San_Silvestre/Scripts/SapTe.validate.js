(function (sapte, $) {

    /* Constants */


    /* Init */
    sapte.initValidate = function () {
        var defaultOptions = {
            errorClass: "has-error",
            validClass: "has-success",
            highlight: function (element, errorClass, validClass) {
                $(element).closest(".form-group")
                    .addClass(errorClass)
                    .removeClass(validClass);
            },
            unhighlight: function (element, errorClass, validClass) {
                $(element).closest(".form-group")
                    .removeClass(errorClass)
                    .addClass(validClass);
            },
            ignore: ":hidden:not([class~=selectized],.validate-hidden),:hidden > .selectized, .selectize-control .selectize-input input, .validation-ignore"
        };

        $.validator.setDefaults(defaultOptions);

        $.validator.methods.date = function (value, element) {
            return this.optional(element) || /^(\d{4})\D?(0[1-9]|1[0-2])\D?([12]\d|0[1-9]|3[01])(\D?([01]\d|2[0-3])\D?([0-5]\d)\D?([0-5]\d)?)?$/.test(value);
        }
        $.validator.unobtrusive.options = {
            errorClass: "has-error",
            validClass: "has-success"
        };
    }

    /* Selectize */
    sapte.selectizeValidate = function (element, value, errMsgElement) {
        if (value !== "") {
            element.closest(".form-group").removeClass("has-error").addClass("has-success");
            if (errMsgElement != undefined) {
                errMsgElement.hide();
            }
        } else {
            element.closest(".form-group").removeClass("has-success").addClass("has-error");
            if (errMsgElement != undefined) {
                errMsgElement.show();
            }
        }
    }


    function retornar (id) {
        control = document.getElementById(id);
        document.getElementById(id).value = '';
        //document.getElementById(id).select();		
        //document.getElementById(id).focus();
        return;

    }

    //Funciones auxiliares
    function IsNumeric(cadena) {
        var ValidChars = "0123456789";
        var IsNumber = true;
        var Char;


        for (i = 0; i < cadena.length && IsNumber == true; i++) {
            Char = cadena.charAt(i);
            if (ValidChars.indexOf(Char) == -1) {
                IsNumber = false;
            }
        }
        return IsNumber;

    }


    // check to see if input is alphabetic
    function isAlphabetic(cadena) {
        if (cadena.match(/^[a-zA-Z]+$/)) {
            return true;
        }
        else {
            return false;
        }
    }

}(window.sapte = window.sapte || {}, jQuery));