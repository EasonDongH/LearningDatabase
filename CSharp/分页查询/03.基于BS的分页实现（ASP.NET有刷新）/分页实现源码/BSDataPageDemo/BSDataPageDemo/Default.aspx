<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BSDataPageDemo.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style/CommonPage.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script  type="text/javascript">
        function CheckGoTo() {
            var txt = document.getElementById("txtGoTo").value;
            if (txt.length == 0) {
                alert("请输入要跳转的页数！");
                return false;
            }
            else {
                var r = new RegExp("^[0-9]*[1-9][0-9]*$");
                if (!r.test(txt)) {
                    alert("要跳转的页数必须是正整数！");
                    return false;
                }            
                if (parseInt(txt) > parseInt(document.getElementById("hfPagesCount").value)) {
                    alert("要跳转的页数不能大于总页数！");
                    return false;
                }
                else {
                    return true;
                }
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
        <div id="DemoTitle">
            使用《ASP.NET三层架构+存储过程》实现分页</div>
        <div id="stuList">
            <asp:Literal ID="ltaMsg" Visible="false"  runat="server" Text="没有查询到符合条件的记录！"></asp:Literal>
            <asp:DataList ID="dlStuList" runat="server">
                <ItemTemplate>
                    <div class="ItemDiv">
                        <div class="ImgDiv">
                            <img src="Images/<%#Eval("StudentId") %>.PNG" />
                        </div>
                        <div class="DescDiv">
                            学号：<%#Eval("StudentId") %></div>
                        <div class="DescDiv">
                            姓名：<%#Eval("StudentName")%>&nbsp;&nbsp;性别：<%#Eval("Gender")%>&nbsp;&nbsp;出生日期：<%#Eval("Birthday","{0:yyyy-MM-dd}" )%></div>
                        <div class="DescDiv">
                            电话：<%#Eval("PhoneNumber")%></div>
                        <div class="DescDiv">
                            住址：天津市南开区白堤路风荷大夏<%#Eval("StudentId")%>号</div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div class="QueryDiv">
            记录总条数：<asp:Literal ID="RecordsCount" Text="0" runat="server"></asp:Literal>&nbsp;&nbsp;总计页数：<asp:Literal
                ID="PagesCount" Text="0" runat="server">              
            </asp:Literal>  <asp:HiddenField ID="hfPagesCount" runat="server" />&nbsp;&nbsp;当前页码：
            <asp:Literal ID="CurrentPage" Text="0" runat="server"></asp:Literal>
        </div>
        <div class="QueryDiv">
            每页显示：<asp:DropDownList ID="ddlPageSize" runat="server">
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem Selected="True">10</asp:ListItem>
                <asp:ListItem>15</asp:ListItem>
            </asp:DropDownList>
            &nbsp;条&nbsp;&nbsp;跳转到：<asp:TextBox ID="txtGoTo" runat="server" Width="32px"></asp:TextBox>
            页&nbsp;<asp:Button ID="btnGoTo" runat="server" Text="GO " OnClientClick="return CheckGoTo();" OnClick="btnGoTo_Click" />
            &nbsp;<asp:Button ID="btnFirst" runat="server" Text="第一页" OnClick="btnFirst_Click" />
            &nbsp;
            <asp:Button ID="btnPre" runat="server" Text="上一页" OnClick="btnPre_Click" />
            &nbsp;<asp:Button ID="btnNext" runat="server" Text="下一页" OnClick="btnNext_Click" />
            &nbsp;<asp:Button ID="btnLast" runat="server" Text="最后页" OnClick="btnLast_Click" />
        </div>
        <div class="QueryDiv">
            出生日期大于：<asp:TextBox ID="txtBirthday" onclick="WdatePicker()" Text="1988-01-01" runat="server"></asp:TextBox>
            <asp:Button ID="btnQuery" runat="server" Text="提交查询" OnClick="btnQuery_Click" />
        </div>
        <br style="clear: both;" />
    </div>
    </form>
</body>
</html>
