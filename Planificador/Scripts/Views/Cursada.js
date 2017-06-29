function CargarDatosAlumno(nombre, apellido, dni) {
    $("#lblNombre").empty();
    $("#lblNombre").append(nombre);

    $("#lblApellido").empty();
    $("#lblApellido").append(apellido);

    $("#lblDni").empty();
    $("#lblDni").append(dni);

    $("#divDatosAlumno").css("display", "inline");

    OcultarBotones();
    /*--> Inicio, Nicolás Fernández, 08/05/2017, Se agrega linea que desavilita el ingreso del nombre del alumno para que no se pueda modificar en los siguientes pasos. */
    document.getElementById("txtNombreAlumno").disabled = true;
    /*<-- Fin, Nicolas Fernández, 08/05/2017. */
    $("#btnObtenerPlanesEstudio").show();
};

function CargarPlanDeEstudio(planes) {
    /*--> Inicio, Nicolás Fernández, 08/05/2017, Se separan los planes de estudio en diferentes tablas para despues poder cargar las materias independientemente por cada plan. */
    const div = document.getElementById("divPlanesDeEstudio");
    //const table = document.getElementById("tblPlanesEstudio");
    //const tableBody = document.createElement('TBODY');

    for (let i = 0; i < planes.length; i++) {
        const table = document.createElement('table');
        table.className = "table table-bordered text-center";
        const tr = document.createElement('TR');
        const td = document.createElement('TD');
        td.appendChild(document.createTextNode(planes[i].Id));

        tr.appendChild(td);

        /*--> Inicio, Nicolás Fernández, 01/05/2017. Se agrega el nombre del plan de carrera. */
        const td1 = document.createElement('td');
        td1.appendChild(document.createTextNode(planes[i].Nombre));
        tr.appendChild(td1);
        /*<-- Fin, Nicolás Fernández, 01/05/2017. */

        /*--> Inicio, Nicolás Fernández, 08/05/2017. Se agrega botones a nivel de row. */
        const txtBtnVerPlan = document.createTextNode("Ver Plan De Estudio");
        const btnVerPlan = document.createElement('button');
        btnVerPlan.className = "btn btn-default";
        btnVerPlan.appendChild(txtBtnVerPlan);
        const tdVerPlan = document.createElement("td");
        //tdVerPlan.style = "max-width:30px";
        tdVerPlan.appendChild(btnVerPlan);
        tr.appendChild(tdVerPlan);

        const txtBtnVerMateriasPendientes = document.createTextNode("Ver Materias Pendientes");
        const btnVerMateriasPendientes = document.createElement('button');
        btnVerMateriasPendientes.className = "btn btn-default";
        btnVerMateriasPendientes.appendChild(txtBtnVerMateriasPendientes);
        const tdVermateriasPendientes = document.createElement("td");
        tdVermateriasPendientes.appendChild(btnVerMateriasPendientes);
        tr.appendChild(tdVermateriasPendientes);
        /*<-- Fin, Nicolás Fernández, 08/05/2017. */

        //tableBody.appendChild(tr);
        table.appendChild(tr);
        div.appendChild(table);
    }

    //table.appendChild(tableBody);
    /* <-- Fin, Nicolás Fernández, '08/05/2017. */
    $("#divPlanesDeEstudio").css("display", "inline");

    /* Me parece mejor que el usuario luego de elegir el plan de estudio pueda elegir entre ver las aprobadas o las no cursadas. */
    OcultarBotones();
    $("#btnObtenerMateriasAprobadas").show();
    $("#btnObtenerMateriasPendientes").show();
};

function CargarMateriasAprobadas(materias) {

    const table = document.getElementById("tblMateriasAprobadas");
    const tableBody = document.createElement('TBODY');

    for (let i = 0; i < materias.length; i++) {
        const tr = document.createElement('TR');
        const td = document.createElement('TD');
        td.appendChild(document.createTextNode(materias[i].Nombre));
        tr.appendChild(td);

        tableBody.appendChild(tr);
    }
    table.appendChild(tableBody);

    $("#divMateriasAprobadas").css("display", "inline");

    /* Se comneta porque me parece mejor que el usuario pueda elegir el boton que desea apretar. */
    OcultarBotones();
    $("#btnObtenerMateriasPendientes").show();
};

function CargarMateriasPendientes(materias) {
    const table = document.getElementById("tblMateriasPendientes");
    const tableBody = document.createElement('TBODY');

    /*--> Inicio - Nicolas Fernandez - 27/04/2017. Agregado de cabecera de la table. */
    var th = document.createElement('th');
    th.appendChild(document.createTextNode('Materias'));

    var tr0 = document.createElement('tr');
    tr0.appendChild(th);
    table.appendChild(tr0);
    /*<-- Fin - Nicolás Fernandez - 27/04/2017. */

    for (let i = 0; i < materias.length; i++) {
        const tr = document.createElement('TR');
        const td = document.createElement('TD');

        td.appendChild(document.createTextNode(materias[i].Nombre));
        tr.appendChild(td);

        /*--> Inicio - Nicolas Fernandez - 27/04/2017. Me parece necesario el boton que ponga a la materia como aprobada. */
        /*var inp = document.createElement('Input');
        inp.id = materias[i].nombre;
        inp.type = "Button";
        inp.value = "Aprobar Materia";
        inp.classList = "btn btn-default";
        var td1 = document.createElement('td');
        td1.appendChild(inp);
        tr.appendChild(td1);*/
        /*<-- Fin - Nicolas Fernandez - 27/04/2017. */

        tableBody.appendChild(tr);
    }
    table.appendChild(tableBody);


    $("#divMateriasPendientes").css("display", "inline");
    /*--> Inicio - Nicolas Fernandez - 27/04/2017. Me parece que no deberia ocultar botones en este evento. */
    //OcultarBotones();
    //$("#btnObtenerCaminoCritico").show();
    /*<-- Fin - Nicolas Fernandez - 27/04/2017. */
};

function CargarCaminoCritico(materias) {
    const table = document.getElementById("tblCaminoCritico");
    const tableBody = document.createElement('TBODY');

    for (let i = 0; i < materias.length; i++) {
        const tr = document.createElement('TR');
        const td = document.createElement('TD');
        td.appendChild(document.createTextNode(materias[i].Nombre));
        tr.appendChild(td);

        const td2 = document.createElement('TD');
        td.appendChild(document.createTextNode(materias[i].Peso));
        tr.appendChild(td);

        tableBody.appendChild(tr);
    }
    table.appendChild(tableBody);



    $("#divCaminoCritico").css("display", "inline");
};

function MostrarModal(texto) {
    $("#detalleModal").text("");
    $("#detalleModal").text(texto);
    $('#modalPopUp').modal('show');
};

function OcultarBotones() {
    $("#btnObtenerDatosAlumno").hide();
    $("#btnObtenerPlanesEstudio").hide();
    $("#btnObtenerMateriasAprobadas").hide();
    $("#btnObtenerMateriasPendientes").hide();
    $("#btnObtenerCaminoCritico").hide();
};
