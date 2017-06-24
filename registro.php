<html>
  <head>
    <?php
      include 'phpFunctions/DBManage.php';
      include 'phpFunctions/registroFunc.php';
    ?>
    <link rel="stylesheet" type="text/css" href="css/defaultStyle.css"></script>
    <link rel="stylesheet" type="text/css" href="css/registroStyle.css"></script>

    <script type="text/javascript" src="js/functions.js"></script>
    
  </head>
  <body>
    <div id="bodyDiv">
      <?php
      $_registrar = TRUE;
      if ($_SERVER["REQUEST_METHOD"] == "POST"){

        $_nombre = $_POST["name"];
        $_apellido = $_POST["apellido"];
        $_usuario = $_POST["usuario"];
        $_clave = $_POST["pass"];
        $_repClave = $_POST["repPass"];

        if (empty($_nombre) | empty($_apellido) | empty($_usuario) | empty($_clave) | empty($_repClave)) {
        } 
        else { 
          if (ExisteUsuario($_usuario)) {
            $_Error = "El usuario que esta intentando ingresar ya existe.";
          }
          else {
            if ($_clave != $_repClave) {
              $_Error = "Las claves no coinciden.";
            }
            else{
              RegistrarPersona($_nombre, $_apellido, $_usuario, $_clave);
              
              header('Location: main.php?usuario='. $_usuario);
              
            }
          }
        }
      }
      ?>
      <form method="post" action="<?php echo htmlspecialchars($_SEVER["PHP_SELF"]);?>">
        <label>* Nombres: </label>
        <input type="text" id="nombreInp" name="name">
        <span class="error"></span>
        <br>
        <label>* Apellido: </label>
        <input type="text" id="apellidoInp" name="apellido">
        <span class="error"></span>
        <br>
        <label>* Usuario: </label>
        <input type="text" id="usuaroInp" name="usuario">
        <span class="error"></span>
        <br>
        <label>* Password: </label>
        <input type="password" class="DefaultTextField" id="passInp" name="pass">
        <span class="error"></span>
        <br>
        <label>* Repita Password: </label>
        <input type="password" class="DefaultTextField" id="repPassInp" name="repPass" onblur="ControlPassword()">
        <span class="error"></span>
        <br>
        <span><?php echo $_Error;?></span>
        <div id="buttons">
          <input type="submit" class="btnSubmit" value="Registrar">
          <input type="button" class="btnCancel" value="Cancelar" onclick="GoBack()">
        </div>
      </form>
    </div>
  </body>
</html>

