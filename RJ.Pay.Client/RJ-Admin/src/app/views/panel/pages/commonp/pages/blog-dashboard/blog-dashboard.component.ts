import { Component, OnInit } from '@angular/core';
import {
  IChartistData,
  ILineChartOptions,
  IPieChartOptions,
  IBarChartOptions
} from 'chartist';
import { ChartEvent, ChartType } from 'ng-chartist';
import * as Chartist from 'chartist';
import { TicketContent } from 'src/app/data/models/ticketContent';
import { Subscription } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { PersianCalendarService } from 'src/app/core/_base/pipe/PersianDatePipe/persian-date.service';

import 'src/app/shared/extentions/bool.extentions';
import { BlogDashboard } from 'src/app/data/models/common/blogDashboard';

@Component({
  selector: 'app-blog-dashboard',
  templateUrl: './blog-dashboard.component.html',
  styleUrls: ['./blog-dashboard.component.css']
})
export class BlogDashboardComponent implements OnInit {

  blogDashboard: BlogDashboard;
  subManager = new Subscription();
  //#region TotalBlog
  TotalBlogChartType: ChartType = 'Line';
  TotalBlogChartData: IChartistData;

  TotalBlogChartOptions: ILineChartOptions = {
    low: 0,
    fullWidth: true,
    showArea: true,
    axisY: {
      showGrid: true,
      low: 0,
      scaleMinSpace: 10,
      showLabel: true
    },
    axisX: {
      showGrid: true,
      showLabel: true
    },
    lineSmooth: Chartist.Interpolation.simple({
      divisor: 2
    })
  };

  TotalBlogChartEvents: ChartEvent = {
    created: (data) => {
      const defs = data.svg.elem('defs');
      defs.elem('linearGradient', {
        id: 'wGradient',
        x1: 0,
        y1: 1,
        x2: 0,
        y2: 0
      }).elem('stop', {
        offset: 0,
        'stop-color': 'rgba(130,73,232, 1)'
      }).parent().elem('stop', {
        offset: 1,
        'stop-color': 'rgba(41,123,249, 1)'
      });
      // const targetLineX =
      //   data.chartRect.x1 +
      //   (data.chartRect.width() - data.chartRect.width() / data.bounds.step);
      // data.svg.elem(
      //   'line',
      //   {
      //     x1: targetLineX,
      //     x2: targetLineX,
      //     y1: data.chartRect.y1,
      //     y2: data.chartRect.y2
      //   },
      //   data.options.targetLine.class
      // );
    }
  };
  //#endregion
  //#region  ApprovedBlog
  ApprovedBlogChartType: ChartType = 'Line';
  ApprovedBlogChartData: IChartistData;

  ApprovedBlogChartOptions: ILineChartOptions = {
    low: 0,
    fullWidth: true,
    showArea: true,
    axisY: {
      showGrid: true,
      low: 0,
      scaleMinSpace: 10,
      showLabel: true
    },
    axisX: {
      showGrid: true,
      showLabel: true
    },
    lineSmooth: Chartist.Interpolation.simple({
      divisor: 2
    })
  };

  ApprovedBlogChartEvents: ChartEvent = {
    created: (data) => {
      const defs = data.svg.elem('defs');
      defs.elem('linearGradient', {
        id: 'wGradient1',
        x1: 0,
        y1: 0,
        x2: 0,
        y2: 1
      }).elem('stop', {
        offset: 0,
        'stop-color': 'rgba(252,157,48, 1)'
      }).parent().elem('stop', {
        offset: 1,
        'stop-color': 'rgba(250,91,76, 1)'
      });
    }
  };
  //#endregion
  //#region UnApprovedBlog
  UnApprovedBlogChartType: ChartType = 'Line';
  UnApprovedBlogChartData: IChartistData;

  UnApprovedBlogChartOptions: ILineChartOptions = {
    low: 0,
    fullWidth: true,
    showArea: true,
    axisY: {
      showGrid: true,
      low: 0,
      scaleMinSpace: 10,
      showLabel: true
    },
    axisX: {
      showGrid: true,
      showLabel: true
    },
    lineSmooth: Chartist.Interpolation.simple({
      divisor: 2
    })
  };

  UnApprovedBlogChartEvents: ChartEvent = {
    created: (data) => {
      const defs = data.svg.elem('defs');
      defs.elem('linearGradient', {
        id: 'wGradient2',
        x1: 0,
        y1: 0,
        x2: 0,
        y2: 1
      }).elem('stop', {
        offset: 0,
        'stop-color': 'rgba(120, 204, 55, 1)'
      }).parent().elem('stop', {
        offset: 1,
        'stop-color': 'rgba(0, 75, 145, 1)'
      });
    }
  };
  //#endregion

  //#region BlogSummary
  BlogSummaryChartType: ChartType = 'Pie';
  BlogSummaryChartData: IChartistData

  BlogSummaryChartOptions: IPieChartOptions = {
    donut: true,
    startAngle: 310,
    donutSolid: true,
    donutWidth: 30,
    showLabel: false

  };

  BlogSummaryChartEvents: ChartEvent = {
    created: (data) => {
      const defs = data.svg.elem('defs');
      defs.elem('linearGradient', {
        id: 'donutGradient1',
        x1: 0,
        y1: 1,
        x2: 0,
        y2: 0
      }).elem('stop', {
        offset: 0,
        'stop-color': 'rgba(155, 60, 183,1)'
      }).parent().elem('stop', {
        offset: 1,
        'stop-color': 'rgba(255, 57, 111, 1)'
      });
      defs.elem('linearGradient', {
        id: 'donutGradient2',
        x1: 0,
        y1: 1,
        x2: 0,
        y2: 0
      }).elem('stop', {
        offset: 0,
        'stop-color': 'rgba(0, 75, 145,0.8)'
      }).parent().elem('stop', {
        offset: 1,
        'stop-color': 'rgba(120, 204, 55, 0.8)'
      });
      defs.elem('linearGradient', {
        id: 'donutGradient3',
        x1: 0,
        y1: 1,
        x2: 0,
        y2: 0
      }).elem('stop', {
        offset: 0,
        'stop-color': 'rgba(132, 60, 247,1)'
      }).parent().elem('stop', {
        offset: 1,
        'stop-color': 'rgba(56, 184, 242, 1)'
      });
    }
  };
  //#endregion

  //#region UserBlogsChart
  UserBlogsChartType: ChartType = 'Line';
  UserBlogsChartData: IChartistData

  UserBlogsChartOptions: ILineChartOptions = {
    low: 0,
    fullWidth: true,
    chartPadding: {
      right: 20
    },
    axisY: {
      low: 0,
      scaleMinSpace: 60,
      labelInterpolationFnc: function labelInterpolationFnc(value) {
        return value
      }
    },
    axisX: {
      showGrid: false
    },
    lineSmooth: Chartist.Interpolation.simple({
      divisor: 2
    })
  };

  UserBlogsChartEvents: ChartEvent = {
    created: (data) => {
      const defs = data.svg.elem('defs');
      defs.elem('linearGradient', {
        id: 'linear1',
        x1: 1,
        y1: 1,
        x2: 1,
        y2: 0
      }).elem('stop', {
        offset: 0,
        'stop-color': 'rgba(185,168,231, 1)'
      }).parent().elem('stop', {
        offset: 1,
        'stop-color': 'rgba(118,74,233, 1)'
      });
      defs.elem('linearGradient', {
        id: 'linear2',
        x1: 1,
        y1: 1,
        x2: 1,
        y2: 0
      }).elem('stop', {
        offset: 0,
        'stop-color': 'rgba(32,201,151, 1)'
      }).parent().elem('stop', {
        offset: 1,
        'stop-color': 'rgba(40,167,69, 1)'
      });
      defs.elem('linearGradient', {
        id: 'linear3',
        x1: 1,
        y1: 1,
        x2: 1,
        y2: 0
      }).elem('stop', {
        offset: 0,
        'stop-color': 'rgba(247,140,153, 1)'
      }).parent().elem('stop', {
        offset: 1,
        'stop-color': 'rgba(255,73,97, 1)'
      });
      
    },
    draw: (data) => {
      const circleRadius = 10;
      if (data.type === 'point') {
        const circle = new Chartist.Svg('circle', {
          cx: data.x,
          cy: data.y,
          r: circleRadius,
          class:
            data.value.y === 0 || data.value.y === 6800
              ? 'ct-circle-transperent'
              : 'ct-circle'
        });
        data.element.replace(circle);
      }
    }
  };
  //#endregion

  constructor(private route: ActivatedRoute,
    private persianCalendarService: PersianCalendarService) { }

  ngOnInit() {
    this.loadblogDashboard();
    this.loadTotalBlogChart();
    this.loadApprovedBlogChart();
    this.loadUnApprovedBlogChart();
    this.loadBlogSummary();
    this.loadUserBlogsChart();
  }
  loadblogDashboard() {
    this.subManager.add(
      this.route.data.subscribe(data => {
        this.blogDashboard = data.blogDashboard;
      })
    )
  }
  loadTotalBlogChart() {
    const dt1 = new Date();
    const dt2 = new Date();
    const dt3 = new Date();
    const dt4 = new Date();
    const dt5 = new Date();
    dt2.setDate(dt2.getDate() - 1);
    dt3.setDate(dt3.getDate() - 2);
    dt4.setDate(dt4.getDate() - 3);
    dt5.setDate(dt5.getDate() - 4);
    this.TotalBlogChartData = {
      labels: [
        this.persianCalendarService.PersianCalendarVerySmall(dt5),
        this.persianCalendarService.PersianCalendarVerySmall(dt4),
        this.persianCalendarService.PersianCalendarVerySmall(dt3),
        this.persianCalendarService.PersianCalendarVerySmall(dt2),
        '*'
      ],
      series: [[
        this.blogDashboard.totalBlog5Days.day5,
        this.blogDashboard.totalBlog5Days.day4,
        this.blogDashboard.totalBlog5Days.day3,
        this.blogDashboard.totalBlog5Days.day2,
        this.blogDashboard.totalBlogCount
      ]]
    };
  }
  loadApprovedBlogChart() {
    const dt1 = new Date();
    const dt2 = new Date();
    const dt3 = new Date();
    const dt4 = new Date();
    const dt5 = new Date();
    dt2.setDate(dt2.getDate() - 1);
    dt3.setDate(dt3.getDate() - 2);
    dt4.setDate(dt4.getDate() - 3);
    dt5.setDate(dt5.getDate() - 4);
    this.ApprovedBlogChartData = {
      labels: [
        this.persianCalendarService.PersianCalendarVerySmall(dt5),
        this.persianCalendarService.PersianCalendarVerySmall(dt4),
        this.persianCalendarService.PersianCalendarVerySmall(dt3),
        this.persianCalendarService.PersianCalendarVerySmall(dt2),
        '*'
      ],
      series: [[
        this.blogDashboard.approvedBlog5Days.day5,
        this.blogDashboard.approvedBlog5Days.day4,
        this.blogDashboard.approvedBlog5Days.day3,
        this.blogDashboard.approvedBlog5Days.day2,
        this.blogDashboard.approvedBlogCount
      ]]
    };
  }
  loadUnApprovedBlogChart() {
    const dt1 = new Date();
    const dt2 = new Date();
    const dt3 = new Date();
    const dt4 = new Date();
    const dt5 = new Date();
    dt2.setDate(dt2.getDate() - 1);
    dt3.setDate(dt3.getDate() - 2);
    dt4.setDate(dt4.getDate() - 3);
    dt5.setDate(dt5.getDate() - 4);
    this.UnApprovedBlogChartData = {
      labels: [
        this.persianCalendarService.PersianCalendarVerySmall(dt5),
        this.persianCalendarService.PersianCalendarVerySmall(dt4),
        this.persianCalendarService.PersianCalendarVerySmall(dt3),
        this.persianCalendarService.PersianCalendarVerySmall(dt2),
        '*'
      ],
      series: [[
        this.blogDashboard.unApprovedBlog5Days.day5,
        this.blogDashboard.unApprovedBlog5Days.day4,
        this.blogDashboard.unApprovedBlog5Days.day3,
        this.blogDashboard.unApprovedBlog5Days.day2,
        this.blogDashboard.unApprovedBlogCount
      ]]
    };
  }
  loadBlogSummary() {
    this.BlogSummaryChartData = {
      series: [
        {
          name: 'تایید شده',
          className: 'ct-progress',
          value: this.getPersent(this.blogDashboard.approvedBlogCount)
        },
        {
          name: 'تایید نشده',
          className: 'ct-done',
          value: this.getPersent(this.blogDashboard.unApprovedBlogCount)
        }
      ]
    };
  }
  loadUserBlogsChart() {
    this.UserBlogsChartData = {
      labels: [
        this.blogDashboard.last12UserBlogInfo[11] ? this.blogDashboard.last12UserBlogInfo[11].name : '-',
        this.blogDashboard.last12UserBlogInfo[10] ? this.blogDashboard.last12UserBlogInfo[10].name : '-',
        this.blogDashboard.last12UserBlogInfo[9] ? this.blogDashboard.last12UserBlogInfo[9].name : '-',
        this.blogDashboard.last12UserBlogInfo[8] ? this.blogDashboard.last12UserBlogInfo[8].name : '-',
        this.blogDashboard.last12UserBlogInfo[7] ? this.blogDashboard.last12UserBlogInfo[7].name : '-',
        this.blogDashboard.last12UserBlogInfo[6] ? this.blogDashboard.last12UserBlogInfo[6].name : '-',
        this.blogDashboard.last12UserBlogInfo[5] ? this.blogDashboard.last12UserBlogInfo[5].name : '-',
        this.blogDashboard.last12UserBlogInfo[4] ? this.blogDashboard.last12UserBlogInfo[4].name : '-',
        this.blogDashboard.last12UserBlogInfo[3] ? this.blogDashboard.last12UserBlogInfo[3].name : '-',
        this.blogDashboard.last12UserBlogInfo[2] ? this.blogDashboard.last12UserBlogInfo[2].name : '-',
        this.blogDashboard.last12UserBlogInfo[1] ? this.blogDashboard.last12UserBlogInfo[1].name : '-',
        this.blogDashboard.last12UserBlogInfo[0] ? this.blogDashboard.last12UserBlogInfo[0].name : '-'
      ],
      series: [[
        this.blogDashboard.last12UserBlogInfo[11] ? this.blogDashboard.last12UserBlogInfo[11].totalBlog : 0,
        this.blogDashboard.last12UserBlogInfo[10] ? this.blogDashboard.last12UserBlogInfo[10].totalBlog : 0,
        this.blogDashboard.last12UserBlogInfo[9] ? this.blogDashboard.last12UserBlogInfo[9].totalBlog : 0,
        this.blogDashboard.last12UserBlogInfo[8] ? this.blogDashboard.last12UserBlogInfo[8].totalBlog : 0,
        this.blogDashboard.last12UserBlogInfo[7] ? this.blogDashboard.last12UserBlogInfo[7].totalBlog : 0,
        this.blogDashboard.last12UserBlogInfo[6] ? this.blogDashboard.last12UserBlogInfo[6].totalBlog : 0,
        this.blogDashboard.last12UserBlogInfo[5] ? this.blogDashboard.last12UserBlogInfo[5].totalBlog : 0,
        this.blogDashboard.last12UserBlogInfo[4] ? this.blogDashboard.last12UserBlogInfo[4].totalBlog : 0,
        this.blogDashboard.last12UserBlogInfo[3] ? this.blogDashboard.last12UserBlogInfo[3].totalBlog : 0,
        this.blogDashboard.last12UserBlogInfo[2] ? this.blogDashboard.last12UserBlogInfo[2].totalBlog : 0,
        this.blogDashboard.last12UserBlogInfo[1] ? this.blogDashboard.last12UserBlogInfo[1].totalBlog : 0,
        this.blogDashboard.last12UserBlogInfo[0] ? this.blogDashboard.last12UserBlogInfo[0].totalBlog : 0
      ],
        [
          this.blogDashboard.last12UserBlogInfo[11] ? this.blogDashboard.last12UserBlogInfo[11].approvedBlog : 0,
          this.blogDashboard.last12UserBlogInfo[10] ? this.blogDashboard.last12UserBlogInfo[10].approvedBlog : 0,
          this.blogDashboard.last12UserBlogInfo[9] ? this.blogDashboard.last12UserBlogInfo[9].approvedBlog : 0,
          this.blogDashboard.last12UserBlogInfo[8] ? this.blogDashboard.last12UserBlogInfo[8].approvedBlog : 0,
          this.blogDashboard.last12UserBlogInfo[7] ? this.blogDashboard.last12UserBlogInfo[7].approvedBlog : 0,
          this.blogDashboard.last12UserBlogInfo[6] ? this.blogDashboard.last12UserBlogInfo[6].approvedBlog : 0,
          this.blogDashboard.last12UserBlogInfo[5] ? this.blogDashboard.last12UserBlogInfo[5].approvedBlog : 0,
          this.blogDashboard.last12UserBlogInfo[4] ? this.blogDashboard.last12UserBlogInfo[4].approvedBlog : 0,
          this.blogDashboard.last12UserBlogInfo[3] ? this.blogDashboard.last12UserBlogInfo[3].approvedBlog : 0,
          this.blogDashboard.last12UserBlogInfo[2] ? this.blogDashboard.last12UserBlogInfo[2].approvedBlog : 0,
          this.blogDashboard.last12UserBlogInfo[1] ? this.blogDashboard.last12UserBlogInfo[1].approvedBlog : 0,
          this.blogDashboard.last12UserBlogInfo[0] ? this.blogDashboard.last12UserBlogInfo[0].approvedBlog : 0
        ],
        [
        this.blogDashboard.last12UserBlogInfo[11] ? this.blogDashboard.last12UserBlogInfo[11].unApprovedBlog : 0,
        this.blogDashboard.last12UserBlogInfo[10] ? this.blogDashboard.last12UserBlogInfo[10].unApprovedBlog : 0,
        this.blogDashboard.last12UserBlogInfo[9] ? this.blogDashboard.last12UserBlogInfo[9].unApprovedBlog : 0,
        this.blogDashboard.last12UserBlogInfo[8] ? this.blogDashboard.last12UserBlogInfo[8].unApprovedBlog : 0,
        this.blogDashboard.last12UserBlogInfo[7] ? this.blogDashboard.last12UserBlogInfo[7].unApprovedBlog : 0,
        this.blogDashboard.last12UserBlogInfo[6] ? this.blogDashboard.last12UserBlogInfo[6].unApprovedBlog : 0,
        this.blogDashboard.last12UserBlogInfo[5] ? this.blogDashboard.last12UserBlogInfo[5].unApprovedBlog : 0,
        this.blogDashboard.last12UserBlogInfo[4] ? this.blogDashboard.last12UserBlogInfo[4].unApprovedBlog : 0,
        this.blogDashboard.last12UserBlogInfo[3] ? this.blogDashboard.last12UserBlogInfo[3].unApprovedBlog : 0,
        this.blogDashboard.last12UserBlogInfo[2] ? this.blogDashboard.last12UserBlogInfo[2].unApprovedBlog : 0,
        this.blogDashboard.last12UserBlogInfo[1] ? this.blogDashboard.last12UserBlogInfo[1].unApprovedBlog : 0,
        this.blogDashboard.last12UserBlogInfo[0] ? this.blogDashboard.last12UserBlogInfo[0].unApprovedBlog : 0
        ]
      ]
    };
  }


  getPersent(number: number) {
    return Math.floor((100 * number) / this.blogDashboard.totalBlogCount);
  }


}
