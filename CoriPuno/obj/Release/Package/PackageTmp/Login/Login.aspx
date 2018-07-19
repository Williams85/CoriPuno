<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CoriPuno.Login.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inicio Sesión</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/Site.css" rel="stylesheet" />
    <script src="../Scripts/jquery-3.1.1.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Scripts/Controladores/functions.js"></script>
    <script src="../Scripts/Controladores/ajax-mvc.js"></script>
    <script src="../Scripts/Controladores/Login/login-route.js"></script>
    <script src="../Scripts/Controladores/Login/login-controller.js"></script>
</head>
<body>

    <div id="contenedor-login">
        <form class="login-form" method="post" action="/Home/Login" id="form01" name="form01">
            <img src="../images/logo.png" width="200" />
            <input type="text" placeholder="Usuario" id="Nom_Usuario" name="Nom_Usuario" />
            <input type="password" placeholder="Password" id="Pass_Usuario" name="Pass_Usuario" />
            <div class="alert alert-danger text-left" id="Message-Error">
                <strong></strong>
            </div>
            <button type="submit" id="btnLogin" name="btnLogin" class="btn btn-success"  onclick="return ValidarLogin(this);">LOGIN</button>
        </form>
    </div>

</body>
</html>
