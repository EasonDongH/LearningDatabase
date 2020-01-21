<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<%@taglib prefix="security" uri="http://www.springframework.org/security/tags" %>

<script src="${pageContext.request.contextPath}/plugins/jQuery/jquery-2.2.3.min.js"></script>
<script>
    $(function () {
        $("#btn").click(function () {
            $.ajax({
                url: "${pageContext.request.contextPath}/role/findAll.do",
                contentType: "application/json; charset=utf-8",
                data: {},
                dataType: "json",
                type: "GET",
                async: true,
                success: function (data) {
                    alert("成功");
                },
                error: function (xhr, textStatus, errorThrown) {
                    /*错误信息处理*/
                    alert("进入error---");
                    alert("状态码："+xhr.status);
                    alert("状态:"+xhr.readyState);//当前状态,0-未初始化，1-正在载入，2-已经载入，3-数据进行交互，4-完成。
                    alert("错误信息:"+xhr.statusText );
                    alert("返回响应信息："+xhr.responseText );//这里是详细的信息
                    alert("请求状态："+textStatus);
                    alert(errorThrown);
                    alert("请求失败");
                }
            });
        });
    });
</script>
<!-- 页面头部 -->
<header class="main-header">
	<!-- Logo -->
	<a href="all-admin-index.html" class="logo"> <!-- mini logo for sidebar mini 50x50 pixels -->
		<span class="logo-mini"><b>数据</b></span> <!-- logo for regular state and mobile devices -->
		<span class="logo-lg"><b>数据</b>后台管理</span>
	</a>
	<!-- Header Navbar: style can be found in header.less -->
	<nav class="navbar navbar-static-top">
		<!-- Sidebar toggle button-->
		<a href="#" class="sidebar-toggle" data-toggle="offcanvas"
			role="button"> <span class="sr-only">Toggle navigation</span>
		</a>

		<button id="btn">ajax</button>
		<div class="navbar-custom-menu">
			<ul class="nav navbar-nav">

				<li class="dropdown user user-menu"><a href="#"
					class="dropdown-toggle" data-toggle="dropdown"> <img
						src="${pageContext.request.contextPath}/img/user2-160x160.jpg"
						class="user-image" alt="User Image"> <span class="hidden-xs">
							<security:authentication property="principal.username"></security:authentication>
					</span>

				</a>
					<ul class="dropdown-menu">
						<!-- User image -->
						<li class="user-header"><img
							src="${pageContext.request.contextPath}/img/user2-160x160.jpg"
							class="img-circle" alt="User Image"></li>

						<!-- Menu Footer-->
						<li class="user-footer">
							<div class="pull-left">
								<a href="#" class="btn btn-default btn-flat">修改密码</a>
							</div>
							<div class="pull-right">
								<a href="${pageContext.request.contextPath}/logout.do"
									class="btn btn-default btn-flat">注销</a>
							</div>
						</li>
					</ul></li>

			</ul>
		</div>
	</nav>
</header>
<!-- 页面头部 /-->