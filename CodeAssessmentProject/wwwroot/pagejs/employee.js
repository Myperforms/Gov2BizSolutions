
$(document).ready(function () {

});


$(document).on("click", "#btn-submit", function () {
    if (validateform()) {

        var id = $("#ID").val();
        var name = $("#Name").val();
        var department = $("#Department").val();
        var jobTittle = $("#JobTittle").val();
        var salary = $("#Salary").val();
        var remotestatus = $("input[name='remotestatus']:checked").val();

        var obj = {};

        obj.ID = id;
        obj.Name = name;
        obj.Department = department;
        obj.JobTittle = jobTittle;
        obj.Salary = salary;
        obj.RemoteWorkStatus = remotestatus == 1;

        $.ajax({
            url: "/../Employee/UpdateEmployeeDetails",
            type: "POST",
            cache: false,
            async: false,
            contentType: 'application/json; charset=utf-8',
            dataType: 'Json',
            data: JSON.stringify(obj),
            success: function (data) {
                if (data.isSuccess) {
                    if (id > 0) {
                        $("#returnMessage").text("Employee details are saved..");
                    }
                    else {
                        $("#returnMessage").text("Created new Employee");
                        $(".cls-common").val("");
                        $("input[name='remotestatus'][value='0']").prop('checked', true);
                    }

                    $("#returnMessage").show();
                    setTimeout(function () {
                        $("#returnMessage").hide();

                    }, 3000);
                }
                else {


                }
            },
            error: function (xhr, textStatus, thrownError) {
                alert("Oops! Something went wrong in sign in.");
            }
        });
    }
});


function validateform() {

    var name = $("#Name").val().trim();
    var department = $("#Department").val().trim();
    var jobTittle = $("#JobTittle").val().trim();
    var salary = $("#Salary").val().trim();

    $(".cls-errormessage").text("");
    var isSuccess = true;
    if (name == "") {
        $("#Error-Name").text("Name is Required.");
        isSuccess = false;
    }
    else {
        var regex = /^[a-zA-Z\s]+$/;

        if (!regex.test(name)) {
            $("#Error-Name").text("Name allows only string value");
            isSuccess = false;
        }
    }

    if (department == "") {
        $("#Error-Department").text("Department is Required.");
        isSuccess = false;
    }
    else {
        var regex = /^[a-zA-Z0-9\s]+$/;

        if (!regex.test(department)) {
            $("#Error-Department").text("Department allows only alphanumeric value");
            isSuccess = false;
        }
    }

    if (jobTittle == "") {
        $("#Error-JobTittle").text("JobTittle is Required.");
        isSuccess = false;
    }
    else {
        var regex = /^[a-zA-Z0-9\s]+$/;

        if (!regex.test(jobTittle)) {
            $("#Error-JobTittle").text("JobTittle allows only alphanumeric value");
            isSuccess = false;
        }
    }

    if (salary == "") {
        $("#Error-Salary").text("Salary is Required.");
    }

    return isSuccess;
}



$('.decimalInput').on('input', function (e) {
    let value = this.value.replace(/[^0-9.]/g, ''); // Remove anything that is not a number or decimal
    let decimalCount = (value.match(/\./g) || []).length; // Count decimal points

    // If there is more than one decimal point, remove the extra ones
    if (decimalCount > 1) {
        value = value.substring(0, value.lastIndexOf('.'));
    }

    this.value = value;
});
