(function (sapte, $) {
    /* Dialogs */
    sapte.showError = function (message, title) {
        BootstrapDialog.show({
            type: BootstrapDialog.TYPE_DANGER,
            title: title === undefined ? "Error" : title,
            message: message,
            buttons: [
                {
                    cssClass: "btn-primary btn-sm",
                    label: "Ok",
                    action: function (dialog) {
                        dialog.close();
                    }
                }
            ]
        });
    }

    sapte.showWarning = function (message, title, buttonCaption, buttonAction) {
        BootstrapDialog.show({
            title: title,
            type: BootstrapDialog.TYPE_WARNING,
            message: message,
            buttons: [
                {
                    cssClass: "btn-default btn-sm",
                    hotkey: 27,
                    label: "Cancelar",
                    action: function (dialog) {
                        dialog.close();
                    }
                },
                {
                    cssClass: "btn-danger btn-sm",
                    hotkey: 13,
                    label: buttonCaption,
                    action: function (dialog) {
                        buttonAction(dialog);
                    }
                }
            ],
            autodestroy: true,
            draggable: true,
            size: BootstrapDialog.SIZE_SMALL,
            closable: true
        });
    }

    sapte.showCustom = function (message, title, buttonCaption, buttonAction, onshown) {
        message = message.replace(/\n/g, "").replace(/\r/g, "").replace(/<br.*?>/g, "");
        BootstrapDialog.show({
            title: title,
            message: message,
            buttons: [
                {
                    cssClass: "btn-default btn-sm",
                    hotkey: 27,
                    label: "Cancelar",
                    action: function (dialog) {
                        dialog.close();
                    }
                },
                {
                    cssClass: "btn-primary btn-sm",
                    hotkey: 13,
                    label: buttonCaption,
                    action: function (dialog) {
                        buttonAction(dialog);
                    }
                }
            ],
            draggable: true,
            size: BootstrapDialog.SIZE_SMALL,
            onshown: function () {
                onshown();
            }
        });
    }
}(window.sapte = window.sapte || {}, jQuery));
