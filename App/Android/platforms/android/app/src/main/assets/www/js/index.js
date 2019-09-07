﻿/*
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements.  See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership.  The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License.  You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */

var app = {
    // Application Constructor
    initialize: function () {
        this.RouteInit();
        this.bindEvents();
    },
    // Bind Event Listeners
    //
    // Bind any events that are required on startup. Common events are:
    // 'load', 'deviceready', 'offline', and 'online'.
    bindEvents: function () {
        document.addEventListener('deviceready', this.onDeviceReady, false);
        // disable back button in andriod
        //document.addEventListener("backbutton", this.BackButtonCallback, false);
    },
    // deviceready Event Handler
    //
    // The scope of 'this' is the event. In order to call the 'receivedEvent'
    // function, we must explicitly call 'app.receivedEvent(...);'
    onDeviceReady: function () {
        app.receivedEvent('deviceready');
    },
    // Update DOM on a Received Event
    receivedEvent: function (id) {
        StatusBar.styleDefault();
        StatusBar.overlaysWebView(true);
        //init fast click
        FastClick.attach(document.body);
    },
    BackButtonCallback: function () { },
    RouteInit: function () {
        angular.module('ngRouteScApp', ['ui.router', 'ngAnimate'])
            .config(function ($stateProvider, $urlRouterProvider, $httpProvider) {
                $stateProvider
                    .state('guide', {
                        url: "/guide",
                        views: {
                            'other': {
                                templateUrl: 'views/guide.html',
                                controller: 'GuideController'
                            }
                        }
                    })
                    .state('map', {
                        url: "/map",
                        cache: true,
                        views: {
                            'content': {
                                templateUrl: 'views/map.html',
                                controller: 'MapController'
                            },
                            'footer': {
                                templateUrl: 'views/footer.html',
                                controller: 'FooterController'
                            }
                        }

                    })
                    .state('login', {
                        url: "/login",
                        views: {
                            'other': {
                                templateUrl: 'views/login.html',
                                controller: 'LoginController'
                            }
                        }
                    })

                    .state('userpage', {
                        url: "/userpage",
                        views: {
                            'other': {
                                templateUrl: 'views/userpage.html',
                                controller: 'UserpageController'
                            }
                        },
                        params: {
                            userId: null,
                            returnUrl: null
                        }
                    })
                    .state('userinfo', {
                        url: "/userinfo",
                        views: {
                            'other': {
                                templateUrl: 'views/userinfo.html',
                                controller: 'UserinfoController'
                            }
                        }
                    })
                    .state('team', {
                        url: "/team",
                        views: {
                            'other': {
                                templateUrl: 'views/team.html',
                                controller: 'TeamController'
                            }
                        }
                    })
                    .state('withdraw', {
                        url: "/withdraw",
                        views: {
                            'other': {
                                templateUrl: 'views/withdraw.html',
                                controller: 'WithdrawController'
                            }
                        }
                    })
                    .state('agency', {
                        url: "/agency",
                        views: {
                            'other': {
                                templateUrl: 'views/agency.html',
                                controller: 'AgencyController'
                            }
                        }
                    })
                    .state('update', {
                        url: "/update",
                        views: {
                            'other': {
                                templateUrl: 'views/update.html',
                                controller: 'UpdateController'
                            }
                        },
                        params: {
                            obj: { title: null, type: null, value: null }
                        }
                    })
                    .state('qrcode', {
                        url: "/qrcode",
                        views: {
                            'other': {
                                templateUrl: 'views/qrcode.html',
                                controller: 'QrcodeController'
                            }
                        }
                    })
                    .state('profits', {
                        url: "/agency",
                        views: {
                            'other': {
                                templateUrl: 'views/profits.html',
                                controller: 'ProfitsController'
                            }
                        }
                    })
                    .state('success', {
                        url: "/success",
                        views: {
                            'other': {
                                templateUrl: 'views/success.html',
                                controller: 'SuccessController'
                            }
                        },
                        params: {
                            obj: { header: null, title: null, details: null, amount: null }
                        }
                    })
                    .state('contacts', {
                        url: "/contacts",
                        cache: true,
                        views: {
                            'content': {
                                templateUrl: 'views/contacts.html',
                                controller: 'ContactsController'
                            },
                            'footer': {
                                templateUrl: 'views/footer.html',
                                controller: 'FooterController'
                            }
                        }
                    })
                    .state('my', {
                        url: "/my",
                        cache: true,
                        views: {
                            'content': {
                                templateUrl: 'views/my.html',
                                controller: 'MyController',
                            },
                            'footer': {
                                templateUrl: 'views/footer.html',
                                controller: 'FooterController'
                            }
                        }
                    })

                $urlRouterProvider.otherwise('/login');
            })
            .animation('.fade', function () {
                return {
                    enter: function (element, done) {
                        element.css({
                            opacity: 0
                        });
                        element.animate({
                            opacity: 1
                        }, 150, done);
                    },
                    leave: function (element, done) {
                        element.css({
                            opacity: 1
                        });
                        element.animate({
                            opacity: 0
                        }, 150, done);
                    }
                };
            })
            .factory('ls', ['$window', function ($window) {
                return {
                    set: function (key, value) {
                        $window.localStorage[key] = value;
                    },
                    get: function (key, defaultValue) {
                        return $window.localStorage[key] || defaultValue;
                    },
                    setObject: function (key, value) {
                        $window.localStorage[key] = JSON.stringify(value);
                    },
                    getObject: function (key) {
                        return JSON.parse($window.localStorage[key] || '{}');
                    },
                    clear: function () {
                        $window.localStorage.clear();
                    }
                }
            }])
            .service('sc', function ($state, ls, $http, $rootScope, $window) {
                this.checkTicketStillActive = function () {
                    var loginTime = ls.get('loginTime');
                    if (loginTime) {
                        var curTime = new Date();
                        var diff = curTime.getTime() - new Date(loginTime).getTime();
                        var diffDays = diff / (24 * 3600 * 1000);//相差天数
                        //判断凭证是否过期
                        if (diffDays < DreamConfig.tokenExpireTime) {
                            $state.go('map');
                        }
                        else {
                            ls.clear();
                        }
                    }
                };
                this.ValidateLogin = function () {
                    var userId = ls.getObject('userInfo').UserId;
                    if (typeof (userId) == "undefined") $state.go('login');
                };
                this.Login = function () {
                    //get from tencent
                    try {
                        Wechat.isInstalled(function (installed) {
                            var scope = "snsapi_userinfo",
                                state = "_" + (+new Date());
                            Wechat.auth(scope, state, function (response) {
                                alert(response);
                                // you may use response.code to get the access token.
                                //get access_token
                                $.get("https://api.weixin.qq.com/sns/oauth2/access_token?appid=" + DreamConfig.appId + "&secret=" + DreamConfig.appSecret + "&code=" + response.code + "&grant_type=authorization_code", function (data) {
                                    var rerturnData = JSON.parse(data);
                                    //get userinfo
                                    $.get("https://api.weixin.qq.com/sns/userinfo?access_token=" + rerturnData.access_token + "&openid=" + rerturnData.openid, function (userInfo) {
                                        var user_info = JSON.parse(userInfo);
                                        var user = { openId: user_info.openid, avatarUrl: user_info.headimgurl, unionId: rerturnData.unionid, name: user_info.nickname, sex: user_info.sex };
                                        $state.go('map');
                                        //check user
                                        $http({
                                            method: "post",
                                            url: DreamConfig.accountUrl,
                                            contentType:"application/json",
                                            data: { openId: user.openId, avatarUrl: user.avatarUrl, name: user.name, sex: user.sex, unionid: user.unionId },
                                            timeout: 30000,
                                        }).success(function (d, textStatu, xhr) {
                                            ls.setObject('userInfo', d);
                                            ls.set('loginTime', new Date());
                                            DeviceEvent.SpinnerHide();
                                            $state.go('map');
                                        }).error(function (error, textStatu, xhr) {
                                            DeviceEvent.SpinnerHide();
                                            DeviceEvent.Toast("网络异常");
                                        });
                                    });
                                });
                            }, function (reason) {
                                DeviceEvent.SpinnerHide();
                                DeviceEvent.Toast("Failed: " + reason);
                            });
                        }, function (reason) {
                            DeviceEvent.SpinnerHide();
                            DeviceEvent.Toast("Failed: " + reason);
                        });
                    }
                    catch (e) {
                        DeviceEvent.SpinnerHide();
                        DeviceEvent.Toast("网络错误");
                    }

                    //var userInfo = { OpenId: "opaKA1SkGI3-qLqMSPW_Nlpz4byY", AvatarUrl: "http://thirdwx.qlogo.cn/mmopen/vi_32/DYAIOgq83eqKNWm1GAstFo4C5Zmwmwtl1nH8GNqTMGGJUMIIsR06bHULD6b1kGDaGEsdBiardvErKWwnw4ibibb6A/132", UnionId: "oMicm5ntgIaYSRsxMGg4KUgEQr5E", Name: "蜡笔小新", Sex: 0, UserId: 3 };
                    //ls.setObject('userInfo', userInfo);
                    //ls.set('loginTime', new Date());
                    //$state.go('map');

                };
                this.logOut = function () {
                    DeviceEvent.Confirm("退出之后需要重新登陆",
                        function (buttonIndex) {
                            if (buttonIndex == 1) {
                                ls.clear();
                                ls.set('guideIsChecked', true);
                                $state.go('login');
                            }
                        }, "请确认退出", ['确认', '取消']);
                };
            })
            .controller('GuideController', function ($scope, ls, $state) {
                var swiper = new Swiper('.swiper-container', {
                    pagination: '.swiper-pagination',
                    paginationClickable: true,
                    loop: false,
                    onSlideChangeEnd: function (swiper) {
                        if (3 == swiper.activeIndex) {
                            ls.set('guideIsChecked', true);
                            $state.go('login');
                        }
                    }
                });
            })
                
            .controller('UserpageController', function ($scope, $http, $state, sc, $stateParams) {
                sc.ValidateLogin();
                $scope.back = function () {
                    $state.go($stateParams.returnUrl);
                };
                $http({
                    method: "GET",
                    url: DreamConfig.userInfoUrl + "getbyid?userId=" + $stateParams.userId,
                    timeout: 30000,
                })
                    .success(function (userInfo, textStatu, xhr) {
                        $scope.userInfo = userInfo;
                    })
                    .error(function (error, textStatu, xhr) {
                        DeviceEvent.SpinnerHide();
                        DeviceEvent.Toast("网络异常");
                    });
            })
            .controller('UpdateController', function ($scope, $http, $state, sc, ls, $stateParams) {
                sc.ValidateLogin();
                $scope.back = function () {
                    $state.go('userinfo');
                };
                var enableSubmit = false;
                $scope.updateInfo = $stateParams.obj;
                $scope.save = function () {
                    if (enableSubmit) {
                        DeviceEvent.SpinnerShow();
                        var userInfo = {};
                        switch ($scope.updateInfo.type) {
                            case "name":
                                userInfo = { UserId: ls.getObject("userInfo").UserId, Name: $scope.updateInfo.value };
                                break;
                            case "alipay":
                                userInfo = { UserId: ls.getObject("userInfo").UserId, AliPay: $scope.updateInfo.value };
                                break;
                            case "alipayName":
                                userInfo = { UserId: ls.getObject("userInfo").UserId, AliPayName: $scope.updateInfo.value };
                                break;
                        }
                        $http({
                            method: "POST",
                            url: DreamConfig.userInfoUrl,
                            contentType: "application/json",
                            data: userInfo,
                            timeout: 30000,
                        })
                            .success(function (user, textStatu, xhr) {
                                ls.setObject("userInfo", user);
                                DeviceEvent.SpinnerHide();
                                $state.go('userinfo');
                            })
                            .error(function (error, textStatu, xhr) {
                                DeviceEvent.SpinnerHide();
                                DeviceEvent.Toast("网络异常");
                            });
                    }
                };

                $('.input-box input').bind('input propertychange', function () {
                    if ($(this).val().length > 0 && $.trim($('.input-box input').val()) != "") {
                        $('.input-box i').show();
                        $('.yes-btn').css('opacity', '1');
                        enableSubmit = true;
                    } else {
                        $('.input-box i').hide();
                        $('.yes-btn').css('opacity', '0.8');
                        enableSubmit = false;
                    }
                });
                $('.input-box i').click(function () {
                    $('.input-box input').val('');
                    $('.input-box i').hide();
                    $('.yes-btn').css('opacity', '0.8');
                    enableSubmit = false;
                })
            })
            .controller('UserinfoController', function ($scope, $state, ls, sc) {
                sc.ValidateLogin();
                $scope.back = function () {
                    $state.go('my');
                };
                $scope.userInfo = ls.getObject("userInfo");
                $scope.updateName = function () {
                    $state.go('update', { obj: { title: "设置你的昵称", type: "name", value: $scope.userInfo.Name } });
                }
                $scope.updateAlipay = function () {
                    $state.go('update', { obj: { title: "设置支付宝账号", type: "alipay", value: $scope.userInfo.AliPay } });
                }
                $scope.updateAlipayName = function () {
                    $state.go('update', { obj: { title: "设置支付宝姓名", type: "alipayName", value: $scope.userInfo.AliPayName } });
                }
            })
            .controller('TeamController', function ($scope, $state, sc, ls) {
                sc.ValidateLogin();
                $scope.back = function () {
                    $state.go('my');
                };
                $scope.goUserpage = function (userId) {
                    $state.go('userpage', { userId: userId, returnUrl: "team" })
                }
                DeviceEvent.SpinnerShow();
                $.get(DreamConfig.teamUrl.concat("?userId=" + ls.getObject("userInfo").UserId), function (members) {
                    $scope.$apply(function () {
                        $scope.teamInfo = members;
                        DeviceEvent.SpinnerHide();
                    });
                });
            })
            .controller('WithdrawController', function ($scope, $http, $state, sc, ls) {
                sc.ValidateLogin();
                var enableSubmit = false;
                $scope.userInfo = ls.getObject("userInfo");
                $scope.back = function () {
                    $state.go('my');
                };
                $scope.updateAlipay = function () {
                    $state.go('update', { obj: { title: "设置支付宝账号", type: "alipay", value: $scope.userInfo.AliPay } });
                };
                DeviceEvent.SpinnerShow();
                $scope.withdrawInfo = { totalAmount: null, withdrawAmount: null };
                $http({
                    method: "GET",
                    url: DreamConfig.profitUrl.concat("GetRemainAmount?userId=" + $scope.userInfo.UserId),
                    timeout: 30000,
                })
                    .success(function (totalAmount, textStatu, xhr) {
                        $scope.withdrawInfo = { totalAmount: totalAmount, withdrawAmount: totalAmount };
                        if (totalAmount >= 0.1) {
                            enableSubmit = true;
                            $(".btn").css("background", "#ff8569");
                        }
                        DeviceEvent.SpinnerHide();
                    })
                    .error(function (error, textStatu, xhr) {
                        DeviceEvent.SpinnerHide();
                        DeviceEvent.Toast("网络异常");
                    });

                $scope.submit = function () {
                    if (enableSubmit) {
                        DeviceEvent.SpinnerShow();
                        $http({
                            method: "POST",
                            url: DreamConfig.profitUrl.concat("WithdrawApply/?userId=" + $scope.userInfo.UserId),
                            contentType: "application/json",
                            timeout: 30000
                        })
                            .success(function (user, textStatu, xhr) {
                                DeviceEvent.SpinnerHide();
                                $state.go('success', { obj: { header: "提现成功", title: "提现申请已提交", details: "二个工作日内到账", amount: $scope.withdrawInfo.withdrawAmount } });
                            })
                            .error(function (error, textStatu, xhr) {
                                DeviceEvent.SpinnerHide();
                                DeviceEvent.Toast("网络异常");
                            });
                    }
                }
                    
                $scope.withdrawAll = function () {
                    $scope.withdrawInfo.withdrawAmount = $scope.withdrawInfo.totalAmount;
                    if ($scope.withdrawInfo.withdrawAmount != null && $scope.withdrawInfo.withdrawAmount >= 0) {
                        enableSubmit = true;
                        $(".btn").css("background", "#ff8569");
                    }
                };

                validateAmount($('.pay-box input'));

                $('.pay-box input').bind('keyup', function () {
                    if ($(this).val() <= $scope.withdrawInfo.totalAmount && $(this).val() > 0) {
                        enableSubmit = true;
                        $(".btn").css("background", "#ff8569");
                    }
                    else {
                        $(this).val("");
                        enableSubmit = false;
                        $(".btn").css("background", "#b3b3b3");
                    }
                });
            })
            .controller('AgencyController', function ($scope, $state, $http, sc, ls) {
                sc.ValidateLogin();
                $scope.back = function () {
                    $state.go('my');
                };

                $scope.buyAgency = function (type) {
                    DeviceEvent.SpinnerShow();
                    var title = "";
                    var amount = 0;
                    var subject = "";
                    var payInfo = "";

                    if (type == 1) {
                        if (ls.getObject("userInfo").AgencyType == 1 || ls.getObject("userInfo").AgencyType == 2) {
                            DeviceEvent.Toast("您已经是代理");
                            DeviceEvent.SpinnerHide();
                            return;
                        }
                        title = "市区代理已生效";
                        subject = "市区代理";
                        amount = 0.01;
                    }
                    else {
                        if (ls.getObject("userInfo").AgencyType == 2) {
                            DeviceEvent.Toast("您已经是全国代理");
                            DeviceEvent.SpinnerHide();
                            return;
                        }
                        title = "全国代理已生效";
                        subject = "全国代理";
                        amount = 0.01;
                    }
                    // 第一步：订单在服务端签名生成订单信息，具体请参考官网进行签名处理 https://docs.open.alipay.com/204/105465/
                    $http({
                        method: "post",
                        url: DreamConfig.alipayUrl,
                        contentType: "application/json",
                        data: { subject: subject, totalAmount: amount},
                        timeout: 30000,
                    }).success(function (d, textStatu, xhr) {
                        payInfo = d;
                        DeviceEvent.Toast(payInfo);
                        // 第二步：调用支付插件            
                        cordova.plugins.alipay.payment(payInfo, function success(e) {
                            DeviceEvent.SpinnerHide();
                            $state.go('success', { obj: { header: "购买成功", title: title, details: "您已完成本次交易", amount: amount } });
                        }, function error(e) {
                            DeviceEvent.SpinnerHide();
                            DeviceEvent.Toast("支付失败");
                        });
                    }).error(function (error, textStatu, xhr) {
                        DeviceEvent.SpinnerHide();
                        DeviceEvent.Toast("网络异常");
                    });


                    $.post(DreamConfig.alipayUrl + "?subject=" + subject + "&&totalAmount=" + amount, function (data) {
                        payInfo = data;
                        // 第二步：调用支付插件            
                        cordova.plugins.alipay.payment(payInfo, function success(e) {
                            var userInfo = { UserId: ls.getObject("userInfo").UserId, AgencyType: type };
                            $.post(DreamConfig.userInfoUrl, userInfo, function (user) {
                                DeviceEvent.SpinnerHide();
                                //update user info
                                ls.setObject("userInfo", user);
                                $state.go('success', { obj: { header: "购买成功", title: title, details: "您已完成本次交易", amount: amount } });
                            })
                        }, function error(e) {
                            DeviceEvent.SpinnerHide();
                            DeviceEvent.Toast("支付失败");
                        });
                    });
                }
                $('.tab-box .col-md-6').click(function () {
                    $(this).find('.item-box').addClass('active').parents('.col-md-6').siblings().find('.item-box').removeClass('active');
                    $('.tab-conter .item-box').eq($(this).index()).addClass('active').siblings().removeClass('active');
                })
            })
            .controller('ProfitsController', function ($scope, $state, sc, ls) {
                sc.ValidateLogin();
                $scope.back = function () {
                    $state.go('my');
                };
                $.get(DreamConfig.profitUrl.concat("?userId=" + ls.getObject("userInfo").UserId), function (data) {
                    $scope.profits = data;
                });
            })
            .controller('QrcodeController', function ($scope, $state, sc, ls) {
                sc.ValidateLogin();
                $scope.back = function () {
                    $state.go('my');
                };
                $scope.userAvatar = ls.getObject("userInfo").AvatarUrl;
                //二维码生成
                $("#qrCode").empty();
                $("#qrCode").qrcode({
                    render: "canvas",
                    width: window.innerWidth - 150,
                    height: window.innerHeight / 3,
                    text: "https://open.weixin.qq.com/connect/oauth2/authorize?appid=wxda337f3186c93879&redirect_uri=http://admin.huijiwanjia.com/WechatAuth/AuthCallback&response_type=code&scope=snsapi_userinfo&state=" + ls.getObject("userInfo").UserId + "&connect_redirect=1#wechat_redirect"
                });
            })
            .controller('SuccessController', function ($scope, $state, sc, $stateParams) {
                $scope.back = function () {
                    $state.go(curPage);
                };
                $scope.successInfo = $stateParams.obj;
                var _interval = setInterval(function () {
                    if (parseInt($("#time").text()) > 0) {
                        $("#time").text(parseInt($("#time").text()) - 1);
                    }
                    else {
                        clearInterval(_interval);
                        $state.go(curPage);
                    }
                }, 1000);
            })
            .controller('MapController', function ($scope, $state, $http, sc, $rootScope, ls) {
                curPage = "map";
                sc.ValidateLogin();
                $scope.QueryText = "";
                $scope.Query = function () {
                    $http({
                        method: "post",
                        url: DreamConfig.tbkQuery,
                        contentType: "application/json",
                        data: { q: $scope.QueryText, pagesize:5 },
                        timeout: 30000,
                    }).success(function (d, textStatu, xhr) {
                        d = JSON.parse(d);
                        var ret = d.tbk_dg_material_optional_response.result_list.map_data;
                        for (i = 0; i < ret.length; i++) {
                            if (!!ret[i].coupon_share_url) ret[i].coupon_share_url = encodeURIComponent(ret[i].coupon_share_url);
                            else ret[i].coupon_share_url = encodeURIComponent(ret[i].url);
                        }
                        $scope.QueryResult = d;
                        console.log($scope.QueryResult);
                    }).error(function (error, textStatu, xhr) {
                        DeviceEvent.SpinnerHide();
                        DeviceEvent.Toast("网络异常");
                    });
                };
                $scope.ClickLog = function (itemId) {
                    console.log(DreamConfig.clickLog);
                    $http({
                        method: "post",
                        url: DreamConfig.clickLog,
                        contentType: "application/json",
                        data: { UserId: ls.getObject("userInfo").UserId, ItemId: itemId },
                        timeout: 30000,
                    }).success(function (d, textStatu, xhr) {
                    }).error(function (error, textStatu, xhr) {
                        DeviceEvent.SpinnerHide();
                        DeviceEvent.Toast("网络异常");
                    });
                };
            })
            .controller('FooterController', function ($scope, $state, ls) {
                switch (curPage) {
                    case "map":
                        $(".item-box.map").addClass("active");
                        break;
                    case "message":
                        $(".item-box.message").addClass("active");
                        break;
                    case "my":
                        $(".item-box.my").addClass("active");
                        break;
                    case "contacts":
                        $(".item-box.contacts").addClass("active");
                        break;
                }
            })
            .controller('LoginController', function ($scope, ls, sc, $state) {
                if (!ls.get('guideIsChecked')) $state.go('guide');
                sc.checkTicketStillActive();
                $scope.login = function () {
                    DeviceEvent.SpinnerShow();
                    sc.Login();
                };
            })
            .controller('ContactsController', function ($scope, sc, ls, $state, $http) {
                curPage = "contacts";
                sc.ValidateLogin();
                $http({
                    method: "GET",
                    url: DreamConfig.userOrders + "/?userId=" + ls.getObject("userInfo").UserId,                   
                    timeout: 30000,
                }).success(function (d, textStatu, xhr) {
                    $scope.userOrders = d;
                    console.log(d);
                }).error(function (error, textStatu, xhr) {
                    DeviceEvent.SpinnerHide();
                    DeviceEvent.Toast("网络异常");
                });

            })
            .controller('MyController', function ($scope, $state, sc, ls) {
                curPage = "my";
                sc.ValidateLogin();
                $scope.userInfo = ls.getObject("userInfo");
                $scope.goUserpage = function () {
                    $state.go('userpage', { userId: $scope.userInfo.UserId, returnUrl: "my" });
                }
                $scope.goWithdraw = function () {
                    if ($scope.userInfo.AliPay == null || $scope.userInfo.AliPayName == null) {
                        DeviceEvent.Confirm("您还未填写支付宝账号或姓名",
                            function (buttonIndex) {
                                if (buttonIndex == 1) {
                                    $state.go('userinfo');
                                }
                            }, "请完善个人资料", ['去填写', '取消']);
                    }
                    else {
                        $state.go('withdraw');
                    }
                }
                $scope.logOut = function () {
                    sc.logOut();
                };
            })
    }
};
