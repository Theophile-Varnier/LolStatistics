$(function () {
    $("#Graphiques").on("click", function () {
        $("#ArrayStats").addClass("hidden");
        $("#Tableau").removeClass("active");

        $("#Graphe").removeClass("hidden");
        $("#Graphiques").addClass("active");
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

    $('#chart-container').highcharts({
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

        series: [{
            name: 'KDA',
            type: 'area',
            data: series,
            pointPlacement: 'on'
        }]
    });

});