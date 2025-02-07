$(document).on("click", "#DeleteEmployee", function () {
    var id = $(this).attr("data-id");
    $.ajax({
        url: "/../Employee/DeleteEmployee?id=" + id,
        type: "POST",
        cache: false,
        async: false,     
        success: function (data) {
            if (data.isSuccess) {
                window.location.reload();
            }            
        },
        error: function (xhr, textStatus, thrownError) {
            alert("Oops! Something went wrong in sign in.");
        }
    });

});