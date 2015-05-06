$(function () {

    $("#searchTeams").on("click", function () {
        $("#loader").removeClass("hidden");
        $("#teamNames").addClass("hidden");
        $("#stalk").addClass("hidden");
        $.ajax({
            url: "TeamStalker/SummonerTeams",
            type: "GET",
            data: "summonerName=" + $("#player").val()
        })
        .done(function (data) {
            $("#loader").addClass("hidden");
            $("#teamNames").html(data);
            $("#teamNames").removeClass("hidden");
        });
    });

    $("#teamNames").on("click", "#stalkTeam", function () {
        $("#errorMessage").addClass("hidden");
        $("#stalk tbody").empty();
        $("#stalkerLoader").removeClass("hidden");
        $("#stalk").addClass("hidden");
        $.ajax({
            url: "TeamStalker/TeamStats",
            type: "GET",
            data: {
                teamName: $("#team").val()
            }
        }).done(function (data) {
            $("#stalk").removeClass("hidden");
            $("#stalkerLoader").addClass("hidden");
            $("#stalk tbody").append(data);
        })
            .error(function () {
                $("#stalkerLoader").addClass("hidden");
                $("#errorMessage").removeClass("hidden");
            });

    });
})