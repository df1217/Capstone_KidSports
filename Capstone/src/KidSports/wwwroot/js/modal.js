
    $(document).ready(function () {
        $("#edit").click(function () {
            $("#myModal").modal("toggle");
        });
    });

    $(document).ready(function () {
        $("#mytable #checkall").click(function () {
            if ($("#mytable #checkall").is(':checked')) {
                $("#mytable input[type=checkbox]").each(function () {
                    $(this).prop("checked", true);
                });

            } else {
                $("#mytable input[type=checkbox]").each(function () {
                    $(this).prop("checked", false);
                });
            }
        });
    //    $("[data-toggle=tooltip]".tooltip())
    });