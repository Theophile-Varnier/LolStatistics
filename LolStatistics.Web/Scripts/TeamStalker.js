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

    $("#teamNames").on("click", "#stalkTeam", function () {
        $("#stalk").empty();
        $("#stalkerLoader").removeClass("hidden");
        $("#stalk").addClass("hidden");
        var summoners = 0;
        $.ajax({
            url: "TeamStalker/TeamMembers",
            type: "POST",
            data: {
                teamName: $("#team").val()
            }
        }).done(function (data) {
            var array = JSON.parse(data);
            $("#stalk").removeClass("hidden");
            for (var i in array) {
                $.ajax({
                    url: "TeamStalker/SummonerStats",
                    type: "GET",
                    data: "summonerId=" + array[i]
                })
                    .done(function (response) {
                        $("#stalk").append(response);
                        summoners++;
                        if (summoners == array.length) {
                            $("#stalkerLoader").addClass("hidden");
                        }
                    });
            }
        });

    });
})