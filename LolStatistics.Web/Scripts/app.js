$(function () {
    var tab = window.location.pathname.split("/")[2];
    var tabs = $(".navbar-nav li a");
    for (var i in tabs) {
        if (tabs[i].pathname.split("/")[2] == tab) {
            $(tabs[i]).parent().addClass("active");
            break;
        }
    }

    $(".navbar-nav").on("click", "li", function() {
        $(".navbar-nav li").removeClass("active");
        $(this).addClass("active");
    });
})