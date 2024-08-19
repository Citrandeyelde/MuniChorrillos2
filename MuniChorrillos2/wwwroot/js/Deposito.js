$(document).ready(function () {

    // Función para actualizar la enumeración
    function updateEnumeration() {
        $('#tblDeposito tbody tr').each(function (index) {
            $(this).find('td:first').text(index + 1);
        });
    }

    // Llamar a la función al cargar la página para enumerar las filas iniciales
    updateEnumeration();

    // Filtro de búsqueda
    $('#searchInput').on('keyup', function () {
        var value = $(this).val().toLowerCase();
        $('#tblDeposito tbody tr').filter(function () {
            $(this).toggle($(this).find('td:eq(1)').text().toLowerCase().indexOf(value) > -1 ||
                $(this).find('td:eq(2)').text().toLowerCase().indexOf(value) > -1 ||
                $(this).find('td:eq(3)').text().toLowerCase().indexOf(value) > -1);
        });
        updateEnumeration(); // Actualizar la enumeración después del filtrado
    });

    // Para abrir el modal de agregar/actualizar
    $('#modalDeposito').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget); // Botón que disparó el modal
        var id = button.data('id'); // Extraer el ID del botón (si lo tiene)
        var nombre = button.data('nombre'); // Extraer el nombre del depósito
        var direccion = button.data('direccion'); // Extraer la dirección del depósito
        var personal = button.data('personal'); // Extraer el ID del personal asociado

        var modal = $(this);
        modal.find('#IdDeposito').val(id ? id : 0); // Si no hay id, es una creación
        modal.find('#txtNomDeposito').val(nombre); // Poner el nombre en el campo del modal
        modal.find('#txtDireccion').val(direccion); // Poner la dirección en el campo del modal
        modal.find('#ddlPersonal').val(personal); // Seleccionar el personal en el dropdown

        // Cambiar el título del modal dependiendo de si se está creando o actualizando
        if (id) {
            modal.find('.modal-title').text('Actualizar Deposito');
        } else {
            modal.find('.modal-title').text('Agregar Deposito');
        }
    });

    // Para abrir el modal de eliminación
    $('#modalDelete').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget); // Botón que disparó el modal
        var id = button.data('id'); // Extraer el ID del depósito a eliminar

        var modal = $(this);
        modal.find('#deleteDepositosId').val(id); // Poner el ID en el campo oculto del formulario
    });

    // Enviar el formulario de crear/actualizar cuando se hace clic en el botón de guardar
    $('#btnGuardarDeposito').on('click', function () {
        $('#depositoForm').submit(); // Enviar el formulario
    });

});
