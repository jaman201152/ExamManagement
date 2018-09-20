

$(document).ready(function () {

    $(".custom_loader").hide();



    $(document).on("submit", "#BatchCreateForm", function (e) {

        e.preventDefault();
        $(".custom_loader").show();

        $.ajax({
            type: "POST",
            url: "../../Batch/BatchCreate",
            data: $(this).serialize(),
            datatype: "html",
            success: function (data) {
                if (data) {
                    $('.msgSaved').html(data);
                    $(".custom_loader").fadeOut();
                    $('#organizationCreateForm').trigger("reset");
                    setTimeout(function () {
                        $('.msgSaved').html("");
                        $('#organizationCreateForm').trigger("reset");
                        console.log(data);
                    }, 5000);

                } else {
                    $(".custom_loader").fadeOut();
                    $('.msgNotSaved').html(data);
                    $('#organizationCreateForm').trigger("reset");
                    setTimeout(function () { // this method for msg hide after 5 second
                        $('.msgNotSaved').html("");
                        console.log(data);
                    }, 5000);

                }


            }
        });


    });
    // Submit Form End





    $("#CourseId").change(function () {
        var courseId = $(this).val();


        if (courseId != "") {

            var params = { id: courseId }
            $.ajax({
                type: "POST",
                url: "../../Batch/GetCourseByOrganizationId",
                contentType: "application/JSON; charset=utf-8",
                data: JSON.stringify(params),
                success: function (rData) {
                    if (rData != undefined && rData != "") {
                        $("#CourseId").empty();
                        $("#CourseId").append("<option value=''>--Select--</option>");

                        $.each(rData, function (k, v) {
                            var option = "<option value='" + v.Id + "'>" + v.Name + "</option>";
                            $("#CourseId").append(option);
                        });
                        console.log(option);

                    } else {
                        $("#CourseId").empty();
                        $("#CourseId").append("<option value=''>--Select--</option>");

                    }
                }

            });
        }
    });

    // Select Couse By Organization End


});



