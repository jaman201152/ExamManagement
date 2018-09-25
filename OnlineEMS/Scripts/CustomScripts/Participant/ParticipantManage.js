

$(document).ready(function () {

    $(".custom_loader").hide();



    $(document).on("submit", "#ParticipantCreateForm", function (e) {

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
                    $('#ParticipantCreateForm').trigger("reset");
                    setTimeout(function () {
                        $('.msgSaved').html("");
                        $('#ParticipantCreateForm').trigger("reset");
                        console.log(data);
                    }, 5000);

                } else {
                    $(".custom_loader").fadeOut();
                    $('.msgNotSaved').html(data);
                    $('#ParticipantCreateForm').trigger("reset");
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

            var params = { id: courseId };
            $.ajax({
                type: "POST",
                url: "../../Participant/GetBatchByCourseId",
                contentType: "application/JSON; charset=utf-8",
                data: JSON.stringify(params),
                success: function (rData) {
                    if (rData != undefined && rData != "") {
                        $("#BatchId").empty();
                        $("#BatchId").append("<option value=''>--Select--</option>");

                        $.each(rData, function (k, v) {
                            var option = "<option value='" + v.Id + "'>" + v.BatchNo + "</option>";
                            $("#BatchId").append(option);
                        });
                       // console.log(option);

                    } else {
                        $("#BatchId").empty();
                        $("#BatchId").append("<option value=''>--Select--</option>");

                    }
                }

            });
        }
    });

    // Select Couse By Organization End


});



