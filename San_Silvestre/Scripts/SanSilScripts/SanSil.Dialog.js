var CommonActions = new function () {

    this.ShowLoader = function () {
        $("#DimPageForLadingDiv").fadeIn(500);
    };

    this.HideLoader = function () {
        $("#DimPageForLadingDiv").fadeOut(500);
    };

    this.ShowMessageBox = function (header, body) {
        $("#CommonMessageBoxModalHeader").html(header);
        $("#CommonMessageBoxModalBody").html(body);
        $("#commonMessageBoxModal").modal();
    };

    this.ShowConfirmationBox = function (header, body, onConfirm, onCancel) {
        $("#CommonConfirmationBoxConfirmButton").off("click");
        $("#CommonConfirmationBoxCancelButton").off("click");
        $("#CommonConfirmationBoxModalHeader").html(header);
        $("#CommonConfirmationBoxModalBody").html(body);
        if (onConfirm != undefined)
            $("#CommonConfirmationBoxConfirmButton").on("click", onConfirm);
        if (onCancel != undefined)
            $("#CommonConfirmationBoxCancelButton").on("click", onCancel);
        $("#commonConfirmationBoxModal").modal();
    }

    this.HideConfirmationBox = function () {
        $("#commonConfirmationBoxModal").modal("hide");
        $("#CommonConfirmationBoxConfirmButton").off("click");
        $("#CommonConfirmationBoxCancelButton").off("click");
    };
};

var RunnerRefreshActions = new function () {

    this.OnRefreshClick = function (onLoad) {
        CommonActions.ShowLoader();
        $("#RunnerContainerId").fadeOut(500);
        //$(".TravelReportActionsTheme").fadeOut(500);
        $("#RunnerTarget").load(window.GetTravelReportPrtialView, function () {
            //TravelReportRefreshActions.FormatGrid();
            CommonActions.HideLoader();
            if (onLoad !== undefined)
                onLoad();
        });
    };
};

(function (SanSil, $) {
    SanSil.InsertRunnerSuccess = function () {
        BootstrapDialog.show({
            type: BootstrapDialog.TYPE_INFO,
            title: "San Silvestre - 2015",
            message: "Corredor correctamente inscrito",
            buttons: [
                {
                    cssClass: "btn-primary btn-md",
                    label: "Ok",
                    action: function (dialog) {
                        dialog.close();
                        SanSil.ClearInput();
                    }
                }
            ]
        });
    }

    SanSil.editUserFail = function (data) {
        $("#editUserError").show();
        $("#editUserError span:last").text(data.responseJSON);
    }

    SanSil.deleteUserSuccess = function () {
        SanSil.getUsers();
    }

    SanSil.ClearInput = function () {
        $("#InsertRunnerForm").find(':input,select').each(function () {
            var elemento = $(this);
            if (elemento[0].id == "IsLocalRunner") {
                elemento.removeAttr('checked');
                }
            else {
                if (elemento[0].id != "Submit") {
                    if (elemento[0].id != "Id") {
                        $(this).val('');
                    }
                }
            }
            
        })
    }

    SanSil.ClearInputVerificar = function () {
        $('#Name').val('');
        $('#Email').val('');
        $('#Club').val('');
        $('#YearBirthday').val('');
        $('#GenderId').val('');
        $('#PostalCode').val('');
        $('#Telephone').val('');
        $('#DNI2').val('');
    }


    SanSil.RefreshUserData = function (onLoad) {
        CommonActions.ShowLoader();
        $("#EmployeeDataContainerId").fadeOut(500);
        $(".EmployeeDataActionsTheme").fadeOut(500);
        $("#EmployeeDataTarget").load(window.RefreshUserDataLink, function () {
            CommonEmployeeFunctionality.FormatGrid();
            CommonActions.HideLoader();
            if (onLoad !== undefined)
                onLoad();
        });
    }


    SanSil.getUsers = function () {
        $.ajax({
            url: "/Admin/Users",
            async: false,
            error: function () {
                BootstrapDialog.show({
                    type: BootstrapDialog.TYPE_DANGER,
                    title: "Error",
                    message: "No se ha podido cargar ningún usuario",
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
                dialog.close();
            },
            success: function () {
                $("#userTable").fnDraw();
                $("#userTable").load("Admin.Index #userTable");
                //$("#userTable").fnReloadAjax();
                //    $("#userTable").DataTable().clear();
                //    $("#userTable").DataTable().rows.add(data).draw();
            }
        });
    }

    SanSil.valida_nif_cif_nie = function () {

        var temp = $("#DNI").val().toUpperCase();

        if ($("#DocumentTypeId").val() == "1") {
        
            var cadenadni = "TRWAGMYFPDXBNJZSQVHLCKE";
            //var temp = $('#DNI').toUpperCase();
            if (temp != '') {
                //si no tiene un formato valido devuelve error
                if ((!/^[A-Z]{1}[0-9]{7}[A-Z0-9]{1}$/.test(temp) && !/^[T]{1}[A-Z0-9]{8}$/.test(temp)) && !/^[0-9]{8}[A-Z]{1}$/.test(temp))
                    return 0;

                //comprobacion de NIFs estandar
                if (/^[0-9]{8}[A-Z]{1}$/.test(temp)) {
                    posicion = temp.substring(8, 0) % 23;
                    letra = cadenadni.charAt(posicion);
                    var letradni = temp.charAt(8);

                    if (letra == letradni) return 1;
                    else return -1;
                }

                //algoritmo
                suma = parseInt(a.charAt(2)) + parseInt(a.charAt(4)) + parseInt(a.charAt(6));

                for (i = 1; i < 8; i += 2) {
                    temp1 = 2 * parseInt(a.charAt(i));
                    temp1 += '';
                    temp1 = temp1.substring(0, 1);
                    temp2 = 2 * parseInt(a.charAt(i));
                    temp2 += '';
                    temp2 = temp2.substring(1, 2);
                    if (temp2 == '') temp2 = '0';

                    suma += (parseInt(temp1) + parseInt(temp2));
                }

                suma += '';
                n = 10 - parseInt(suma.substring(suma.length - 1, suma.length));

                //comprobacion de NIFs especiales (se calculan como CIFs)
                if (/^[KLM]{1}/.test(temp)) {
                    if (a.charAt(8) == String.fromCharCode(64 + n)) return 1;
                    else return -1;
                }
            }
            else {

                //comprobacion de NIEs
                //T
                if (/^[T]{1}[A-Z0-9]{8}$/.test(temp)) {
                    if (a.charAt(8) == /^[T]{1}[A-Z0-9]{8}$/.test(temp)) return 2;
                    else return -2;
                }
                //XYZ
                if (/^[XYZ]{1}/.test(temp)) {
                    temp = temp.replace('X', '0')
                    temp = temp.replace('Y', '1')
                    temp = temp.replace('Z', '2')
                    pos = temp.substring(0, 8) % 23;

                    if (a.toUpperCase().charAt(8) == cadenadni.substring(pos, pos + 1)) return 2;
                    else return -2;
                }

            }
        }

        return 0;
    }

}(window.SanSil = window.SanSil || {}, jQuery));
