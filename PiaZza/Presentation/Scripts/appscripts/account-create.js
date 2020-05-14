
$(document).ready(function ()
{
    $("#createAccountForm").on("submit", function (event)
    {
        event.preventDefault();
        var accountModel = {};
        accountModel.FirstName = $("#FirstName").val();
        accountModel.LastName = $("#LastName").val();
        accountModel.UserName = $("#UserName").val();
        accountModel.Email = $("#Email").val();
        accountModel.Password = $("#Password").val();
        accountModel.PhoneNumber = $("#PhoneNumber").val();
        accountModel.Adress = $("#Adress").val();
        $.ajax(
        {
            method: "POST",
            url: "/api/Account",
            contentType: "application/json",
            data: JSON.stringify(accountModel),
                success: function (result)
                {
                    if (result["HasError"] == true) {
                        $("#modalHeader").html("<h3>Something went wrong</h3><button type='button' class='close' data-dismiss='modal'>&times;</button>");
                        $("#modalBody").html(result["ErrorMessages"]);
                        $("#modalBody").addClass("text-danger");
                        $("#accountCreateModal").modal('show');
                    }
                    else {
                        $("modalHeader").html("");
                        $("#modalBody").html("<h3>You'll be redirected to login page.</h3>");
                        $("#modalFooter").html("");
                        $("#accountCreateModal").modal('show');
                        setTimeout(function () {
                            event.currentTarget.reset();
                            window.location.replace(window.origin + "/Account/Login");
                        }, 1000);
                    }
                },
                error: function (error)
                {
                    if (error.status == 409) {
                        $("#modalHeader").html("<h3>Something went wrong</h3><button type='button' class='close' data-dismiss='modal'>&times;</button>");
                        $("#modalBody").html("<h5>Username already exists.</h5>");
                        $("#modalBody").addClass("text-danger");
                        $("#accountCreateModal").modal('show');
                    }
                    else {
                        console.log(error);
                    }
                }
        });
    });
});