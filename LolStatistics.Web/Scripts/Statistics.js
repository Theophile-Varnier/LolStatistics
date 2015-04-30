$(function () {

    $(".nav.nav-tabs li").removeClass("active");
    $("#Graphiques").addClass("active");


    var labels = Object.keys(datas.ChampionStatistics);

    var series = [];
    for (var i in datas.ChampionStatistics) {
        series.push(datas.ChampionStatistics[i][$("#displayedData").val()]);
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
                var res = '';
                if (currentDatas == datas.ChampionStatistics) {
                    res = '<img src="../medias/img/' + champTitle + '_Square_0.png" width="42" height="42"/>';
                }
                res = res + '<span>' + this.x + '</span><br/>'
                    + '<span style="color:' + this.points[0].series.color + ';">' + this.points[0].series.name + ': <b>' + this.y
                if ($("input[name=average]").is(':checked') && !$("input[name=average]").attr("disabled")) {
                    res += '/game';
                }
                res += '</b>';
                return res;
            }
        },

        series: [
            {
                name: $("#displayedData").val(),
                type: 'area',
                data: series,
                pointPlacement: 'on'
            }
        ]
    };
    $('#chart-container').highcharts(graph);

    //$(window).resize();

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
        chart.destroy();
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
        graph.xAxis.categories = Object.keys(currentDatas);
        graph.series[0].data = newSerie;
        $('#chart-container').highcharts(graph);
    });

    function changeCheckBoxStatus(field) {
        var denied = ["KDA", "Wins", "Loses", "WinRate", "TotalGames", "LargestKillingSpree"];
        if (_.contains(denied, field)) {
            $("input[name=average]").attr("disabled", true);
            $("input[name=average]").parent().parent().addClass("disabled");
        } else {
            $("input[name=average]").removeAttr("disabled");
            $("input[name=average]").parent().parent().removeClass("disabled");
        }
    }
});