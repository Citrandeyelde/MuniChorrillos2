$(document).ready(function () {
    

    // Llenar datos en el modal para actualizar usuario
    $('#modalUsuario').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget); // Botón que activó el modal
        var id = button.data('id') || 0;
        var nombre = button.data('nombre') || '';
        var apellido = button.data('apellido') || '';
        var direccion = button.data('direccion') || '';
        var telefono = button.data('telefono') || '';
        var email = button.data('email') || '';

        var modal = $(this);
        modal.find('#hddIdUsuario').val(id);
        modal.find('#txtNombreU').val(nombre);
        modal.find('#txtApellidoU').val(apellido);
        modal.find('#txtDireccion').val(direccion);
        modal.find('#txtTelefono').val(telefono);
        modal.find('#txtEmail').val(email);
    });

    // Enviar el formulario de guardar
    $('#btnGuardarUsuario').click(function () {
        $('#usuarioForm').submit();
    });

    // Llenar datos en el modal para eliminar
    $('#modalDelete').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget); // Botón que activó el modal
        var id = button.data('id');
        var modal = $(this);
        modal.find('#deleteUsuarioId').val(id);
    });
});
