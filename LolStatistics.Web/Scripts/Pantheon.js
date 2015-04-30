$(function () {

    $(".nav.nav-tabs li").removeClass("active");
    $("#Pantheon").addClass("active");

    var labels = ['NaN', 'NaN', 'NaN'];

    var series = [1 / 2, 1, 1 / 3];

    var values = [
        -10000,
        -10000,
        -10000
    ];

    var audioElement = document.createElement('audio');
    audioElement.setAttribute('autoplay', 'autoplay');

    updateValues($("#displayedData").val());

    var chartOptions = {
        colors: ["#c0c0c0", "#FFD700", "#cd7f32"],
        chart: {
            type: 'column'
        },
        title: {
            text: 'Pantheon'
        },
        xAxis: {
            type: 'category',
            categories: labels
        },
        legend: {
            enabled: false
        },
        tooltip: {
            enabled: false
        },
        plotOptions: {
            series: {
                borderWidth: 0,
                pointPadding: 0,
                groupPadding: 0.01,
                dataLabels: {
                    enabled: true,
                    useHTML: true,
                    formatter: function(){
                        var champTitle = this.x.replace(/\s+/g, "").replace("'", "");
                        var res = '<img src="../medias/img/' + champTitle + '_Square_0.png" width="50" height="50"/>';
                        return res;
                }
                }
            }
        },

        series: [{
            name: $("#displayedData").val(),
            colorByPoint: true,
            data: series
        }]
    };

    $("#chart-container").highcharts(chartOptions);

    $("#displayedData").change(function () {
        var field = this.value;
        changeCheckBoxStatus(field);
        var chart = $("#chart-container").highcharts();
        chart.destroy();
        updateValues(field);
        chartOptions.xAxis.categories = labels;
        chartOptions.series[0].name = field;
        chartOptions.series[0].data = series;
        $("#chart-container").highcharts(chartOptions);
    });

    $("input[name=average]").change(function () {
        var chart = $("#chart-container").highcharts();
        chart.destroy();
        var field = $("#displayedData").val();
        updateValues(field);
        chartOptions.xAxis.categories = labels;
        chartOptions.series[0].data = series;
        $("#chart-container").highcharts(chartOptions);
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

    function updateValues(field)
    {
        for (var i in datas.ChampionStatistics) {
            var tempData = datas.ChampionStatistics[i][field];
            if ($("input[name=average]").is(':checked') && !$("input[name=average]").attr("disabled")) {
                tempData /= datas.ChampionStatistics[i].TotalGames;
                tempData = parseFloat(tempData.toFixed(2));
            }
            if (tempData > values[1]) {
                values[2] = values[0];
                values[0] = values[1];
                values[1] = tempData;
                labels[2] = labels[0];
                labels[0] = labels[1];
                labels[1] = i;
            } else if (tempData > values[0]) {
                values[2] = values[0];
                values[0] = tempData;
                labels[2] = labels[0];
                labels[0] = i;
            } else if (tempData > values[2]) {
                values[2] = tempData;
                labels[2] = i;
            }
        }
        audioElement.setAttribute('src', '../Medias/sounds/' + labels[1].replace(/\s+/g, "").replace("'", "") + '.mp3');

        audioElement.play();
        values = [-10000,-10000,-10000];
    }

})