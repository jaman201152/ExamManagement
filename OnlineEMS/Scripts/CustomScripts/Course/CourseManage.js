

$(document).ready(function () {



    $("#CoursePartialCreate").click(function () {

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
                    setTimeout(function () {
                        $(".msgSaved").html("");
                        $('#CourseCreateForm').trigger("reset");
                        console.log(data);
                    }, 5000);

                } else {
                    $(".custom_loader").fadeOut();
                    $(".msgNotSaved").html(data);
                    $('#CourseCreateForm').trigger("reset");
                    setTimeout(function () { // setTimeout method of jquery for msg hide after 5 second
                        $(".msgNotSaved").html("");
                        console.log(data);
                    }, 5000);

                }


            }
        });


    });


});

/*
$("#Id").change(function () {
    var studentId = $(this).val();
    if (studentId != "") {

        var params = { id: studentId }
        $.ajax({
            type: "POST",
            url: "../../Student/GetSubjectsByStudentId",
            contentType: "application/JSON; charset=utf-8",
            data: JSON.stringify(params),
            success: function (rData) {
                if (rData != undefined && rData != "") {
                    $("#SubjectListDD").empty();
                    $("#SubjectListDD").append("<option value=''>--Select--</option>");

                    $.each(rData, function (k, v) {
                        var option = "<option value='" + v.Id + "'>" + v.Name + "</option>";
                        $("#SubjectListDD").append(option);
                    });

                } else {
                    $("#SubjectListDD").empty();
                    $("#SubjectListDD").append("<option value=''>--Select--</option>");

                }
            }

        });
    }
});


$("#ClickButton").click(function () {

    //1 Create Ajax Function
    $.ajax({

        //2. Type...
        type: "POST",

        //3. URL
        url: "../../Student/GetStudentName",

        //4. Content Type
        contentType: "application/JSON; charset=utf-8",

        //5. Data (Params)
        //data: JSON(),

        //6. success => Responce

        success: function (rData) {
            if (rData != undefined && rData != "") {
                $("#NameTextBox").val(rData.Name);
            }
        }

    });


    //$("#NameTextBox").val("Kamal");
    //$("#HiddenName").val("Jamal");


    //$("#NameTextBoxDiv").html("<input type='text'/>");

});


$("#ShowHiddenValue").click(function () {

    //var hiddenData = $("#HiddenName").val();

    //$("#NameTextBox").val(hiddenData);

});



*/