$(function () {

    $(".pagination li a[page='0']").parent().addClass('active');

    $(".pagination li").on("click", function (e) {
        var elem = $(e.target);
        var page = elem.attr("page");
        if (!elem.parent().hasClass("disabled")) {
            if (page == "previous") {
                page = parseInt($($(".pagination li.active a")[0]).attr("page")) - 1;
            } else if (page == "next") {
                page = parseInt($($(".pagination li.active a")[0]).attr("page")) + 1;
            }
            $(".pagination li").removeClass("active");
            var next = $($(".pagination li a[page='" + page + "']")).parent();
            next.addClass("active");
            if (page == 0) {
                $($(".pagination li a[page='previous']").parent()).addClass("disabled");
            } else {
                $($(".pagination li a[page='previous']").parent()).removeClass("disabled");
            }
            if ($(next[0]).next().children().attr("page") == "next") {
                $($(".pagination li a[page='next']").parent()).addClass("disabled");
            } else {
                $($(".pagination li a[page='next']").parent()).removeClass("disabled");
            }

            $.ajax({
                url: "/LolStatistics.Web/Home/HistoryPage",
                type: "GET",
                data: {
                    "Page": page
                }
            }).done(function (partialView) {
                $(".match-history").html(partialView);
            });
        }
    });
})