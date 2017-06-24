<html>
  <head>
    <link rel="stylesheet" type="text/css" href="css/defaultStyle.css"></script>
    <link rel="stylesheet" type="text/css" href="css/cambiarPassStyle.css"></script>

    <script type="text/javascript" src="js/functions.js"></script>

  </head>
  <body>
    <div id="headDiv">
    </div>
    <div id="bodyDiv">
      <div id="changePassDiv">
        <form method="post" action="<?php echo htmlspecialchars($_SEVER["PHP_SELF"]);?>">
          <label>Contrase&#241a Actual:</label>
          <input type="password">
          <br>
          <label>Nueva Contrase&#241a:</label>
          <input type="password" id="pass" class="DefaultTextField">
          <br>
          <label>Repita contrase&#241a:</label>
          <input type="password" id="repPass" class="DefaultTextField" onblur="ControlPassword('pass', 'repPass')" onkepress="ControlarPass('pass', 'repPass')">
          <br>
          <div id="buttons">
            <input type="submit" class="btnSubmit" value="Cambiar">
            <input type="button" class="btnCancel" value="Cancelar" onclick="GoBack()">
          </div>
        </form>
      </div>
    <div>
  </body>
</html>

