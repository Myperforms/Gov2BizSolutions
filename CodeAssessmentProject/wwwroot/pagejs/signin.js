$("#btn-submit").click(function () {
    var emailAddress = $("#EmailAddress").val();
    var password = $("#Password").val();

    var message = "";
    if (emailAddress != "") {
        var expr = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([a-z]{2,9})$/;
        if (!expr.test(emailAddress)) {
            $("#Error-EmailAddress").html("Invalid Email Address");
            message = message + "Invalid Email";
        }
        else {
            $("#Error-EmailAddress").html("");
        }
    }
    else {
        $("#Error-EmailAddress").html("Email Address is required");
        message = "Email is Empty";
    }

    if (password == "") {
        $("#Error-Password").html("Password is required");
        message = message + "Password is Empty";
    }
    else {
        $("#Error-Password").html("");
    }

    if (message != "") {
        return false;
    }

    $('#btn-submit').prop('disabled', true);
    var obj = {};
    obj.EmailAddress = emailAddress;
    obj.Password = password;
   
    $.ajax({
        url: '/../Employee/Login',
        type: 'POST',
        cache: false,
        async: false,      
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: JSON.stringify(obj),
        success: function (result) {
            if (result.isSuccess) {
                window.location.href = "/../Employee/AllEmployees";
            }
            else {
                $("#returnMessage").html(result.returnMessage);
                $('#btn-submit').removeAttr('disabled');
            }
        },
        error: function (xhr, textStatus, thrownError) {
            alert("Oops! Something went wrong in sign in.");
        }
    });
});