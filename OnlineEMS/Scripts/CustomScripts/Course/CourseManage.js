

$(document).ready(function () {



    $("#CoursePartialCreate").click(function () {
        $(".custom_loader").show();
        $.ajax({
            type: "GET",
            url: "../../Course/EntryForm",
            contentType: "application/JSON; charset=utf-8",
            data: JSON.stringify(),
            success: function (Data) {

                $("#pView").html(Data);
                $(".custom_loader").hide();

            }

        });


    });

    $(document).on("submit", "#CourseCreateForm", function (e) {

        e.preventDefault();
        $(".custom_loader").show();

        $.ajax({
            type: "POST",
            url: "../../Course/AddCourse",
            data: $(this).serialize(),
            datatype: "html",
            success: function (data) {
                if (data) {
                    $(".msgSaved").html(data);
                    $(".custom_loader").fadeOut();
                    $('#CourseCreateForm').trigger("reset");
                    CourseDetails();
                    setTimeout(function () {
                        $(".msgSaved").html("");
                        $('#CourseCreateForm').trigger("reset");
                        console.log(data);
                    }, 5000);

                } else {
                    $(".custom_loader").fadeOut();
                    $(".msgNotSaved").html(data);
                    $('#CourseCreateForm').trigger("reset");
                    CourseDetails();
                    setTimeout(function () { // setTimeout method of jquery for msg hide after 5 second
                        $(".msgNotSaved").html("");
                        console.log(data);
                    }, 5000);

                }


            }
        });


    });


    function CourseDetails() {

        $.ajax({
            type: "POST",
            url: "../../Course/GetCourseLastFive",
            contentType: "application/JSON; charset=utf-8",
            data: JSON.stringify(),
            success: function (data) {

                $("#CourseDetails").html(data);
                $(".custom_loader").hide();

            }

        });

    }

    CourseDetails();


});

