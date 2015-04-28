$(function () {

    $(".pagination li a[page='0']").parent().addClass('active');

    $(".pagination li").on("click", function (e) {
        $(".pagination li").removeClass("active");
        var elem = $(e.target);
        var page = elem.attr("page");
        if (page == "previous") {
            page = $(".pagination li.active")[0].children()[0].attr("page") - 1;
        } else if (page == "next") {
            
        }
        $($(".pagination li a[page='" + page + "']").parent()).addClass("active");
        $.ajax({
            url: "/LolStatistics.Web/Home/HistoryPage",
            type: "GET",
            data: {
                "Page": page
            }
        }).done(function (partialView) {
            $(".match-history").html(partialView);
        });
    });
})