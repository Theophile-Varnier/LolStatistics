$(function () {

    $("#Graphiques").on("click", function () {
        $("#ArrayStats").addClass("hidden");
        $("#Tableau").removeClass("active");

        $("#Graphe").removeClass("hidden");
        $("#Graphiques").addClass("active");

        $(window).resize();
    });

    $("#Tableau").on("click", function () {
        $("#ArrayStats").removeClass("hidden");
        $("#Graphiques").removeClass("active");
        $("#Graphe").addClass("hidden");
        $("#Tableau").addClass("active");
    });

    var labels = Object.keys(datas.ChampionStatistics);

    var series = [];
    for (var i in datas.ChampionStatistics) {
        series.push(datas.ChampionStatistics[i].KDA);
    }

    var currentDatas = datas.ChampionStatistics;

    var graph = {
        chart: {
            polar: true,
            type: 'line'
        },
        title: {
            text: 'Ranked Stats'
        },
        xAxis: {
            categories: labels,
            tickmarkPlacement: 'on',
        },
        yAxis: {
            gridLineInterpolation: 'polygon',
            endOnTick: false
        },

        tooltip: {
            useHTML: true,
            shared: true,
            formatter: function () {
                var champTitle = this.x.replace(/\s+/g, "").replace("'", "");
                return '<img src="medias/img/' + champTitle + '_Square_0.png" width="42" height="42"/>'
                    + '<span>' + this.x + '</span><br/>'
                    + '<span style="color:' + this.points[0].series.color + ';">' + this.points[0].series.name + ': <b>' + this.y + '</b>';
            }
        },

        series: [
            {
                name: 'KDA',
                type: 'area',
                data: series,
                pointPlacement: 'on'
            }
        ]
    };
    $('#chart-container').highcharts(graph);

    $("#displayedData").change(function () {
        var field = this.value;
        changeCheckBoxStatus(field);
        var newSerie = [];
        var chart = $("#chart-container").highcharts();
        for (var i in currentDatas) {
            var newVal = currentDatas[i][field];
            if ($("input[name=average]").is(':checked') && !$("input[name=average]").attr("disabled")) {
                newVal /= currentDatas[i].TotalGames;
                newVal = parseFloat(newVal.toFixed(2));
            }

            newSerie.push(newVal);
        }
        chart.series[0].update({ 'name': field }, true);
        chart.series[0].setData(newSerie);
    });

    $("input[name=average]").change(function () {
        var chart = $("#chart-container").highcharts();
        var field = $("#displayedData").val();
        var newSerie = [];
        for (var i in currentDatas) {
            var newVal = currentDatas[i][field];
            if ($(this).is(':checked')) {
                newVal /= currentDatas[i].TotalGames;
                newVal = parseFloat(newVal.toFixed(2));
            }
            newSerie.push(newVal);
        }
        chart.series[0].setData(newSerie);
    });

    $("#type").change(function () {
        var field = this.value;
        var newSerie = [];
        var chart = $("#chart-container").highcharts();
        if (field == "Champions") {
            currentDatas = datas.ChampionStatistics;
        } else {
            currentDatas = datas.RoleStatistics;
        }
        field = $("#displayedData").val();
        for (var i in currentDatas) {
            var newVal = currentDatas[i][field];
            if ($("input[name=average]").is(':checked') && !$("input[name=average]").attr("disabled")) {
                newVal /= currentDatas[i].TotalGames;
                newVal = parseFloat(newVal.toFixed(2));
            }

            newSerie.push(newVal);
        }
        chart.xAxis[0].update({ 'categories': Object.keys(currentDatas) }, true);
        chart.series[0].setData(newSerie);
    });

    function changeCheckBoxStatus(field) {
        var denied = ["KDA", "Wins", "WinRate", "TotalGames"];
        if (_.contains(denied, field)) {
            $("input[name=average]").attr("disabled", true);
            $("input[name=average]").parent().parent().addClass("disabled");
        } else {
            $("input[name=average]").removeAttr("disabled");
            $("input[name=average]").parent().parent().removeClass("disabled");
        }
    }
});