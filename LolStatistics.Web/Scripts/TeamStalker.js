$(function () {

    $("#searchTeams").on("click", function () {
        $("#loader").removeClass("hidden");
        $("#teamNames").addClass("hidden");
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

    $("#teamNames").on("click", "#stalkTeam" ,function () {
        $("#stalkerLoader").removeClass("hidden");
        $("#stalk").addClass("hidden");
        $.ajax({
            url: "TeamStalker/StalkTeam",
            type: "POST",
            data: {
                teamName: $("#team").val()
            }
        }).done(function (data) {
            $("#stalk").html(data);
            $("#stalkerLoader").addClass("hidden");
            $("#stalk").removeClass("hidden");
        });

    });
})