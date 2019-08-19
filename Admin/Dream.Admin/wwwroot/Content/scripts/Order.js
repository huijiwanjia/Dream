var OrderScript = (function () {
    var table;
    return {

        Init: function () {
            table = $('#orderTable')
                .dataTable({
                    "bAutoWidth": false,
                    "language": { "url": "/Content/scripts/JqTableChinese.json" },
                    "bServerSide": true,
                    "sAjaxSource": config.orderPaginationUrl,//数据接口。
                    'bPaginate': true,                      //是否分页。
                    "bProcessing": true,                    //当datatable获取数据时候是否显示正在处理提示信息。
                    'bFilter': true,                       //是否使用内置的过滤功能。
                    'bLengthChange': true,                  //是否允许用户自定义每页显示条数。
                    "bSort": false, // 排序功能
                    "bStateSave": false,// 状态保存
                    'sPaginationType': 'full_numbers',      //分页样式
                    "sServerMethod": "get",//请求方式
                    "fnServerParams": function (aoData) {
                        aoData.push(
                            { "name": "sDateTimeRange", "value": $('#reportrange span').html() }//时间参数
                        );
                    },
                    "dom":
                        "<'row'<'col-sm-5'l<'#refresh'>><'col-sm-7'<'#mytoolbox'>f>r>" +
                        "t" +
                        "<'row'<'col-sm-6'i><'col-sm-6'p>>",
                    "initComplete": OrderScript.InitComplete,
                    "fnDrawCallback": function (oSettings) { //重新加载回调
                        //开始受理
                        $(".btn-change").on(ace.click_event, function () {
                            var id = $(this).data("id");
                            var state = $(this).data("statu") == OrderState.已返利 ? OrderState.已结算 : OrderState.已返利;
                            bootbox.confirm("确定要改变返利状态吗?", function (result) {
                                if (result) {
                                    WaitDialog.show();
                                    $.ajax({
                                        url: config.orderChangeStatusUrl,
                                        type: "POST",
                                        data: { id: id, state: state }
                                    })
                                        .done(function (returnMsg) {
                                            //刷新列表
                                            $("#orderTable").dataTable().fnDraw(false);
                                            alert(returnMsg);
                                        })
                                        .error(function (ajaxContext) {
                                            alert("修改失败");
                                        })
                                        .complete(function () {
                                            WaitDialog.hide();
                                        });
                                }
                            });
                        });
                    },
                    "fnRowCallback": function (nRow, aData, iDisplayIndex) {// 当创建了行，但还未绘制到屏幕上的时候调用，通常用于改变行的class风格 
                        $('td:eq(3)', nRow).html($('td:eq(3)', nRow).html().substring(0, 10));
                        $('td:eq(6) span', nRow).attr("data-id", aData.Id);
                        return nRow;
                    },
                    "columns": [
                        { "data": "Id" },
                        { "data": "ShopName" },
                        { "data": "ItemId" },
                        { "data": "BuyDate" },
                        { "data": "BackPrice" }
                    ],
                    "columnDefs": [
                        {
                            "targets": [5],
                            "data": "State",
                            "render": function (data, type, full) {
                                var state;
                                var color;
                                switch (data) {
                                    case 0:
                                        state = "已付款";
                                        color = "primary";
                                        break;
                                    case 1:
                                        state = "已收货";
                                        color = "danger";
                                        break;
                                    case 2:
                                        state = "已结算";
                                        color = "warning";
                                        break;
                                    case 3:
                                        state = "已失效";
                                        color = "muted";
                                        break;
                                    case 4:
                                        state = "已返利";
                                        color = "success";
                                        break;
                                }
                                var html = "<span data-statu='" + data + "' class='label label-sm label-" + color + " arrowed-in'>" + state + "</span>";
                                return html;
                            }
                        },
                        //项目状态
                        {
                            "targets": [6],
                            "data": "State",
                            "render": function (data, type, full) {
                                var state = "当前未结算";
                                var color = "muted";
                                var html = "";
                                switch (data) {
                                    case 2:
                                        state = "设成已返利";
                                        color = "danger";
                                        html = "<span data-statu='" + data + "' class='btn btn-xs btn-" + color + " btn-change'><i class='ace-icon fa fa-check'></i>" + state + "</span>";
                                        break;
                                    case 4:
                                        state = "设成未返利";
                                        color = "success";
                                        html = "<span data-statu='" + data + "' class='btn btn-xs btn-" + color + " btn-change'><i class='ace-icon fa fa-undo'></i>" + state + "</span>";
                                        break;
                                }
                                var ret = "<div class='hidden-sm hidden-xs btn-group'>" + html + "</div>";
                                return ret;
                            }
                        }
                    ]
                });
        },

        GetNowFormatDate: function () {
            var date = new Date();
            var seperator1 = "-";
            var month = date.getMonth() + 1;
            var strDate = date.getDate();
            if (month >= 1 && month <= 9) {
                month = "0" + month;
            }
            if (strDate >= 0 && strDate <= 9) {
                strDate = "0" + strDate;
            }
            var currentdate = date.getFullYear() + seperator1 + month + seperator1 + strDate;
            return currentdate;
        },

        InitComplete: function (data) {
            var dataPlugin =
                '<div id="reportrange" style="cursor:pointer;margin-top:3px" class="dateRange pull-left"> ' +
                '按日期过滤：<i class="glyphicon glyphicon-calendar fa fa-calendar"></i> ' +
                '<span id="searchDateRange"></span>  ' +
                '<b class="caret"></b></div> ';
            $('#mytoolbox').append(dataPlugin);
            //刷新按钮
            var refreshButton = '<span class="btn btn-xs btn-white btn-info btn-round"><i class="ace-icon fa fa-refresh"></i>刷新</span>';
            $('#refresh').append(refreshButton);
            $(".dataTables_length").addClass("pull-left");
            $(".dataTables_length").attr("style", "margin-right:20px");
            $("#refresh span").on('click', function () {
                //重新加载
                table.fnDraw();
            });

            //时间插件
            //$('#reportrange span').html(moment().subtract('day', 1).format('YYYY-MM-DD HH:mm:ss') + ' - ' + moment().format('YYYY-MM-DD HH:mm:ss'));
            $('#reportrange span').html('2016-01-01 00:00:00' + ' - ' + '2099-01-01 00:00:00');
            $('#reportrange').daterangepicker(
                {
                    // startDate: moment().startOf('day'),
                    //endDate: moment(),
                    //minDate: '01/01/2012',    //最小时间
                    maxDate: moment(), //最大时间
                    //dateLimit: {
                    //    days: 30
                    //}, //起止时间的最大间隔
                    showDropdowns: true,
                    showWeekNumbers: false, //是否显示第几周
                    timePicker: true, //是否显示小时和分钟
                    timePickerIncrement: 1, //时间的增量，单位为分钟
                    timePicker12Hour: false, //是否使用12小时制来显示时间
                    ranges: {
                        //'最近1小时': [moment().subtract('hours',1), moment()],
                        '今日': [moment().startOf('day'), moment()],
                        '昨日': [moment().subtract('days', 1).startOf('day'), moment().subtract('days', 1).endOf('day')],
                        '最近7日': [moment().subtract('days', 6), moment()],
                        '最近30日': [moment().subtract('days', 29), moment()],
                    },
                    opens: 'right', //日期选择框的弹出位置
                    buttonClasses: ['btn btn-default'],
                    applyClass: 'btn-small btn-primary blue',
                    cancelClass: 'btn-small',
                    format: 'YYYY-MM-DD HH:mm:ss', //控件中from和to 显示的日期格式
                    separator: ' to ',
                    locale: {
                        applyLabel: '确定',
                        cancelLabel: '取消',
                        fromLabel: '起始时间',
                        toLabel: '结束时间',
                        customRangeLabel: '自定义',
                        daysOfWeek: ['日', '一', '二', '三', '四', '五', '六'],
                        monthNames: ['一月', '二月', '三月', '四月', '五月', '六月',
                            '七月', '八月', '九月', '十月', '十一月', '十二月'],
                        firstDay: 1
                    }
                }, function (start, end, label) {//格式化日期显示框
                    $('#reportrange span').html(start.format('YYYY-MM-DD HH:mm:ss') + ' - ' + end.format('YYYY-MM-DD HH:mm:ss'));
                });

            //设置日期菜单被选项  --开始--
            var dateOption;
            if ("${riqi}" == 'day') {
                dateOption = "今日";
            } else if ("${riqi}" == 'yday') {
                dateOption = "昨日";
            } else if ("${riqi}" == 'week') {
                dateOption = "最近7日";
            } else if ("${riqi}" == 'month') {
                dateOption = "最近30日";
            } else if ("${riqi}" == 'year') {
                dateOption = "最近一年";
            } else {
                dateOption = "自定义";
            }
            $(".daterangepicker").find("li").each(function () {
                if ($(this).hasClass("active")) {
                    $(this).removeClass("active");
                }
                if (dateOption == $(this).html()) {
                    $(this).addClass("active");
                }
            });
            //设置日期菜单被选项  --结束--

            //选择时间后触发重新加载的方法
            $("#reportrange").on('apply.daterangepicker', function () {
                //当选择时间后，出发dt的重新加载数据的方法
                table.fnDraw();
            });

            function getParam(url) {
                var data = decodeURI(url).split("?")[1];
                var param = {};
                var strs = data.split("&");

                for (var i = 0; i < strs.length; i++) {
                    param[strs[i].split("=")[0]] = strs[i].split("=")[1];
                }
                return param;
            }
        },
        Export: function () {
            WaitDialog.show();
            alert(config.dataProcessUrl);
            $.get(config.dataProcessUrl).done(WaitDialog.hide);
        },
        Import: function () {

        }
    };
})();