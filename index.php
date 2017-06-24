<html>
  <head>
    <?php
      include 'phpFunctions/DBManage.php';
      include 'phpFunctions/registroFunc.php';
    ?>

    <link rel="stylesheet" type="text/css" href="css/defaultStyle.css"></script>
    <link rel="stylesheet" type="text/css" href="css/indexStyle.css"></script>

    <script type="text/javascript" src="js/functions.js"></script>
    <script type="text/javascript" src="js/index.js"></script>
  </head>
  <body>
    <div id="principalDiv">		
      <div id="headDiv">
        <img src="img/camareIcon.jpg" alt="Smiley face" height="42" width="42">
        <a href="registro">Registrarse</a>
      </div>
      <div id="bodyDiv">
        <div id="leyenda">
          <p> 
            peliculas para agregar las peliculas que uno vio y para ver los pares de usuario que vieron la misma peliculas. 
          </p> 
        </div> 
        <div id="logDiv">     
          <?php
          $_mensajeError = "";
          $_usuario = $_POST["usuario"];
          $_pass = $_POST["pass"];
          if (!empty($_usuario) and !empty($_pass)) {
            if(ExisteUsuario($_usuario)) {
              if (LogInFor($_usuario, $_pass)) {
                header('Location: main.php?usuario='. $_POST["usuario"]);
              }
              else {
                $_mensajeError = "La password ingresada no es la correcta.";
              }
            }
            else {
              $_mensajeError = "No Ingreso un nombre de usuario correcto";
            }
          }
          ?>
          <form method="post" action="<?php echo htmlspecialchars($_SEVER["PHP_SELF"]); ?>">
            <br>
            <t>Usuario: </t>
            <input type="text" name="usuario" maxlength="20" placeholder="Usuario"/>
            <br>
            <t>Password: </t>
            <input type="password" name="pass" maxlength="20" placeholder="Password"/>
            <input type="submit" class="btnSubmit" value="Ingresar">
          </form>
          <label class="ErrorText"><?php echo $_mensajeError;?></label>
        </div>
      </div>
    <div>
  </body>
</html>

