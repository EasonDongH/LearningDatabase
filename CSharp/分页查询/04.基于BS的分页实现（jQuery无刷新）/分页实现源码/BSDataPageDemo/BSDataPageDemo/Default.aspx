<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BSDataPageDemo.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style/CommonPage.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script type="text/javascript">
        //日期格式转换
        function formatDate(str) {
            if (str != null) {
                return (new Date(parseInt(str.substring(str.indexOf('(') + 1, str.indexOf(')'))))).toLocaleDateString();
            }
        }
        //禁用所有分页按钮
        $(function () {
            DisableButton();
        });
        function DisableButton() {
            $("#btnFirst").attr("disabled", true);
            $("#btnPre").attr("disabled", true);
            $("#btnNext").attr("disabled", true);
            $("#btnLast").attr("disabled", true);
            $("#btnGoTo").attr("disabled", true);
        }
        //提交查询
        $(function () {
            $("#btnQuery").click(function () {
                var currentPage = 1;
                var pageSize = $("#selPageSize").val(); //获取每页显示的条数
                var birthday = $("#txtBirthday").val(); //获取出生日期              
                //执行查询
                $.post("Handlers/PagerHandler.ashx", { "currentPage": currentPage,
                    "pageSize": pageSize, "birthday": birthday
                },
                function (data, status) {
                    // alert(data);  
                    if (data != "0") {
                        $("#CurrentPage").text("1"); //当前页码为1
                        $("#btnFirst").attr("disabled", true);
                        $("#btnPre").attr("disabled", true);
                        $("#btnNext").attr("disabled", false);
                        $("#btnLast").attr("disabled", false);
                        $("#btnGoTo").attr("disabled", false);
                        showResult(data, status);
                    } else {
                        $("#stuList").html("");
                        $("#stuList").append("没有符合条件的查询结果！")
                        $("#CurrentPage").text("0");
                        $("#PagesCount").text("0");
                        $("#RecordsCount").text("0");
                        DisableButton();
                    }
                });
            });
        });
        //第一页
        $(function () {
            $("#btnFirst").click(function () {
                var currentPage = 1;
                var pageSize = $("#selPageSize").val(); //获取每页显示的条数
                var birthday = $("#txtBirthday").val(); //获取出生日期              
                //执行查询
                $.post("Handlers/PagerHandler.ashx", { "currentPage": currentPage,
                    "pageSize": pageSize, "birthday": birthday
                },
                function (data, status) {
                    // alert(data);
                    showResult(data, status);
                    $("#CurrentPage").text("1"); //当前页码为1
                    //控制按钮的使用
                    if (data != "0") {
                        $("#btnFirst").attr("disabled", true);
                        $("#btnPre").attr("disabled", true);
                        $("#btnNext").attr("disabled", false);
                        $("#btnLast").attr("disabled", false);
                    }
                });

            });
        });
        //最后页
        $(function () {
            $("#btnLast").click(function () {
                var currentPage = $("#PagesCount").text();
                var pageSize = $("#selPageSize").val(); //获取每页显示的条数
                var birthday = $("#txtBirthday").val(); //获取出生日期              
                //执行查询
                $.post("Handlers/PagerHandler.ashx", { "currentPage": currentPage,
                    "pageSize": pageSize, "birthday": birthday
                },
                function (data, status) {
                    // alert(data);
                    showResult(data, status);
                    $("#CurrentPage").text(currentPage); //当前页码为最后一页
                });
                if (currentPage == $("#PagesCount").text().toString()) {
                    $("#btnFirst").attr("disabled", false);
                    $("#btnPre").attr("disabled", false);
                    $("#btnNext").attr("disabled", true);
                    $("#btnLast").attr("disabled", true);
                }
            });
        });
        //上一页
        $(function () {
            $("#btnPre").click(function () {
                var currentPage = parseInt($("#CurrentPage").text()) - 1; //获取当前页码
                var pageSize = $("#selPageSize").val(); //获取每页显示的条数
                var birthday = $("#txtBirthday").val(); //获取出生日期              
                //执行查询
                $.post("Handlers/PagerHandler.ashx", { "currentPage": currentPage,
                    "pageSize": pageSize, "birthday": birthday
                },
                function (data, status) {
                    // alert(data);
                    showResult(data, status);
                    $("#CurrentPage").text(currentPage); //显示当前页码
                    //控制按钮的使用
                    if (currentPage == 1) {
                        $("#btnFirst").attr("disabled", true);
                        $("#btnPre").attr("disabled", true);
                        $("#btnNext").attr("disabled", false);
                        $("#btnLast").attr("disabled", false);
                    } else {
                        $("#btnFirst").attr("disabled", false);
                        $("#btnPre").attr("disabled", false);
                        $("#btnNext").attr("disabled", false);
                        $("#btnLast").attr("disabled", false);
                    }
                });
            });
        });
        //下一页
        $(function () {
            $("#btnNext").click(function () {
                var currentPage = parseInt($("#CurrentPage").text()) + 1; //获取当前页码
                var pageSize = $("#selPageSize").val(); //获取每页显示的条数
                var birthday = $("#txtBirthday").val(); //获取出生日期              
                //执行查询
                $.post("Handlers/PagerHandler.ashx", { "currentPage": currentPage,
                    "pageSize": pageSize, "birthday": birthday
                },
                function (data, status) {
                    // alert(data);
                    showResult(data, status);
                    $("#CurrentPage").text(currentPage); //显示当前页码
                });
                //控制按钮的使用
                if (currentPage == $("#PagesCount").text().toString()) {
                    $("#btnFirst").attr("disabled", false);
                    $("#btnPre").attr("disabled", false);
                    $("#btnNext").attr("disabled", true);
                    $("#btnLast").attr("disabled", true);
                }
                else {
                    $("#btnFirst").attr("disabled", false);
                    $("#btnPre").attr("disabled", false);
                    $("#btnNext").attr("disabled", false);
                    $("#btnLast").attr("disabled", false);
                }
            });
        });
        //跳转到
        $(function () {
            $("#btnGoTo").click(function () {
                var currentPage = parseInt($("#txtGoTo").val()); //获取当前页码
                if (currentPage > parseInt($("#PagesCount").text()) || currentPage < 1) {
                    alert("跳转的页数不符合要求！")
                    return;
                }
                var pageSize = $("#selPageSize").val(); //获取每页显示的条数
                var birthday = $("#txtBirthday").val(); //获取出生日期              
                //执行查询
                $.post("Handlers/PagerHandler.ashx", { "currentPage": currentPage,
                    "pageSize": pageSize, "birthday": birthday
                },
                function (data, status) {
                    // alert(data);
                    showResult(data, status);
                    $("#CurrentPage").text(currentPage); //显示当前页码
                });
                //按钮禁用
                if (currentPage == $("#PagesCount").text().toString()) {
                    $("#btnFirst").attr("disabled", false);
                    $("#btnPre").attr("disabled", false);
                    $("#btnNext").attr("disabled", true);
                    $("#btnLast").attr("disabled", true);
                } else if (currentPage == 1) {
                    $("#btnFirst").attr("disabled", true);
                    $("#btnPre").attr("disabled", true);
                    $("#btnNext").attr("disabled", false);
                    $("#btnLast").attr("disabled", false);
                }
            });
        });
        //显示查询结果列表
        function showResult(data, status) {
            var stuList = data.substring(0, data.indexOf("||")); //解析查询结果
            var info = data.substring(data.indexOf("||") + 2);
            $("#PagesCount").text(info.substring(0, info.indexOf("||"))); //获取总页数
            $("#RecordsCount").text(info.substring(info.indexOf("||") + 2)); //获取总记录数
            var list = $.parseJSON(stuList); //获取返回的“对象集合”,并转成jQuery能识别的JSON格式

            $("#stuList").html(""); //先清除以前的数据      

            //遍历集合，并添加查询结果
            for (var i = 0; i < list.length; i++) {
                var studiv = "<div class='ItemDiv'><div class='ImgDiv'>"
                              + "<img src='Images/" + list[i].StudentId + ".PNG' /></div>"
                              + "<div class='DescDiv'>学号：" + list[i].StudentId + "</div>"
                              + "<div class='DescDiv'>姓名：" + list[i].StudentName + "&nbsp;&nbsp;性别："
                              + list[i].Gender + "&nbsp;&nbsp;出生日期："
                              + formatDate(list[i].Birthday) + "</div>"
                              + " <div class='DescDiv'>电话：" + list[i].PhoneNumber + "</div>"
                              + "<div class='DescDiv'> 住址：天津市南开区白堤路风荷大夏" + list[i].StudentId + "号</div></div>";
                $("#stuList").append(studiv); //使用append方法追加项目
            }
        }      
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
        <div id="DemoTitle">
            使用《ASP.NET三层架构+jQuery+存储过程》实现无刷新分页</div>
        <div id="stuList">
        </div>
        <div class="QueryDiv">
            记录总条数：<span id="RecordsCount">0</span>&nbsp;&nbsp;总计页数：<span id="PagesCount">0</span>&nbsp;&nbsp;当前页码：<span
                id="CurrentPage">0</span>
        </div>
        <div class="QueryDiv">
            每页显示：
            <select id="selPageSize">
                <option>5</option>
                <option selected="selected">10</option>
                <option>15</option>
            </select>条&nbsp;&nbsp;跳转到：<input id="txtGoTo" type="text" />页<input id="btnGoTo"
                type="button" value="go" />&nbsp;<input id="btnFirst" type="button" value="第一页" />&nbsp;<input
                    id="btnPre" type="button" value="上一页" />&nbsp;<input id="btnNext" type="button" value="下一页" />&nbsp;<input
                        id="btnLast" type="button" value="最后页" />
        </div>
        <div class="QueryDiv">
            出生日期大于：<input id="txtBirthday" onclick="WdatePicker()" value="1988-01-01" type="text" /><input
                id="btnQuery" type="button" value="提交查询" />
        </div>
        <br style="clear: both;" />
    </div>
    </form>
</body>
</html>
