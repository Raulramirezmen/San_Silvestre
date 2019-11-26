(function (sapte, $) {
    sapte.editUserSuccess = function () {

        sapte.getUsers();
    }

    sapte.editUserFail = function (data) {
        alert(data.result);
        $("#editUserError").show();
        $("#editUserError span:last").text(data.responseJSON);
    }

    sapte.editRunnerFail = function (data) {
        alert(data.result);
        $("#InsertRunnerFormError").show();
        $("#InsertRunnerFormError span:last").text(data.responseJSON);
    }

    sapte.deleteUserSuccess = function () {
        alert("Empezamos get Users");
        sapte.getUsers();
        alert("Terminamos get Users")
    }


    sapte.RefreshUserData = function (onLoad) {
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


    sapte.getUsers = function () {
        debugger
        $.ajax({
            url: "/Admin/Users",
            async: false,
            error: function () {
                BootstrapDialog.show({
                    type: BootstrapDialog.TYPE_DANGER,
                    title: "Error",
                    message: "Couldn't load users",
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

}(window.sapte = window.sapte || {}, jQuery));
