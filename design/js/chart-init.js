$( document ).ready(function() {

  var ctx1 = document.getElementById("weekChart").getContext("2d");
  var data1 = {
    labels: ["Jun 1", "Jun 2", "Jun 3", "Jun 4", "Today"],
    datasets: [{
      label: "My First dataset",
      fillColor: "rgb(13, 51, 115)",
      //   strokeColor: "rgba(255,118,118,0.8)",
      highlightFill: "rgb(30, 206, 145)",
      highlightStroke: "rgb(30, 206, 145)",
      data: [1000, 3000, 1200, 2000, 4000]
    }]
  };

  var chart1 = new Chart(ctx1).Bar(data1, {
    scaleBeginAtZero: true,
    scaleShowGridLines: true,
    scaleGridLineColor: "rgba(0,0,0,.005)",
    scaleGridLineWidth: 0,
    scaleShowHorizontalLines: true,
    scaleShowVerticalLines: true,
    barShowStroke: true,
    barStrokeWidth: 0,
    tooltipCornerRadius: 2,
    barDatasetSpacing: 3,
    legendTemplate: "<ul class=\"<%=name.toLowerCase()%>-legend\"><% for (var i=0; i<datasets.length; i++){%><li><span style=\"background-color:<%=datasets[i].fillColor%>\"></span><%if(datasets[i].label){%><%=datasets[i].label%><%}%></li><%}%></ul>",
    responsive: true
  });
  // Today Chart
  var ctx3 = document.getElementById("monthChart").getContext("2d");
  var data3 = {
    labels: ["Jun ", "July", "Aug", "Sep", "October"],
    datasets: [{
      label: "My First dataset",
      fillColor: "rgb(13, 51, 115)",
      //   strokeColor: "rgba(255,118,118,0.8)",
      highlightFill: "rgb(30, 206, 145)",
      highlightStroke: "rgb(30, 206, 145)",
      data: [1000, 3000, 1200, 2000, 4000]
    }]
  };

  var chart3 = new Chart(ctx3).Bar(data3, {
    scaleBeginAtZero: true,
    scaleShowGridLines: true,
    scaleGridLineColor: "rgba(0,0,0,.005)",
    scaleGridLineWidth: 0,
    scaleShowHorizontalLines: true,
    scaleShowVerticalLines: true,
    barShowStroke: true,
    barStrokeWidth: 0,
    tooltipCornerRadius: 2,
    barDatasetSpacing: 3,
    legendTemplate: "<ul class=\"<%=name.toLowerCase()%>-legend\"><% for (var i=0; i<datasets.length; i++){%><li><span style=\"background-color:<%=datasets[i].fillColor%>\"></span><%if(datasets[i].label){%><%=datasets[i].label%><%}%></li><%}%></ul>",
    responsive: true
  });

  // Today Chart
  var ctx2 = document.getElementById("todayChart").getContext("2d");
  var data2 = {
    labels: ["Jun 1", "Jun 2", "Jun 3", "Jun 4", "Today"],
    datasets: [{
      label: "My First dataset",
      fillColor: "rgb(13, 51, 115)",
      //   strokeColor: "rgba(255,118,118,0.8)",
      highlightFill: "rgb(30, 206, 145)",
      highlightStroke: "rgb(30, 206, 145)",
      
      data: [1000, 3000, 1200, 2000, 4000]
    }]
  };

  var chart2 = new Chart(ctx2).Bar(data2, {
    scaleBeginAtZero: true,
    scaleShowGridLines: true,
    scaleGridLineColor: "rgba(0,0,0,.005)",
    scaleGridLineWidth: 0,
    scaleShowHorizontalLines: true,
    scaleShowVerticalLines: true,
    barShowStroke: true,
    barStrokeWidth: 0,
    tooltipCornerRadius: 2,
    barDatasetSpacing: 3,
    legendTemplate: "<ul class=\"<%=name.toLowerCase()%>-legend\"><% for (var i=0; i<datasets.length; i++){%><li><span style=\"background-color:<%=datasets[i].fillColor%>\"></span><%if(datasets[i].label){%><%=datasets[i].label%><%}%></li><%}%></ul>",
    responsive: true
  });
  // Today Chart
     
  
});


  // Today Chart
  