

$(document).ready(function () {

    $(".custom_loader").hide();

    $("#BatchPartitalCreate").click(function () {

        $(".custom_loader").show();

        $.ajax({
            type: "POST",
            url: "../../Batch/GetBatchManageForm",
            contentType: "application/JSON; charset=utf-8",
            data: JSON.stringify(),
            success: function (data) {

                $("#pView").html(data);
                $(".custom_loader").hide();

            }

        });


    });

    $(document).on("submit", "#BatchCreateForm", function (e) {

        e.preventDefault();

        $(".custom_loader").show();

        $.ajax({
            type: "POST",
            url: "../../Batch/BatchCreateAdd",
            data: $(this).serialize(),
            datatype: "html",
            success: function (data) {
                if (data) {
                    $('.msgSaved').html(data);
                    $(".custom_loader").fadeOut();
                    $('#BatchCreateForm').trigger("reset");
                    setTimeout(function () {
                        $('.msgSaved').html("");
                        $('#BatchCreateForm').trigger("reset");
                        console.log(data);
                    }, 5000);

                } else {
                    $(".custom_loader").fadeOut();
                    $('.msgNotSaved').html(data);
                    $('#BatchCreateForm').trigger("reset");
                    setTimeout(function () { // this method for msg hide after 5 second
                        $('.msgNotSaved').html("");
                        console.log(data);
                    }, 5000);

                }


            }
        });


    });
     // Submit Form End





    $("#OrganizationId").change(function () {
        var organizationId = $(this).val();
    
        if (organizationId != "") {

            var params = { id: organizationId };
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
                       // console.log(option);

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




/*
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