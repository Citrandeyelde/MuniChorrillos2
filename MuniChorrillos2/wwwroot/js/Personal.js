$(document).ready(function () {
    // Manejo del modal para agregar/actualizar Personal
    $('#modalPersonal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget);
        var id = button.data('id') || 0;
        var empleado = button.data('empleado') || '';
        var area = button.data('area') || '';
        var usuario = button.data('usuario') || '';

        var modal = $(this);
        modal.find('.modal-title').text(id ? 'Actualizar Personal Administrativo' : 'Agregar Personal Administrativo');
        modal.find('#IdPersonal').val(id);
        modal.find('#ddlEmpleado').val(empleado);
        modal.find('#ddlArea').val(area);
        modal.find('#txtUsuarioAcceso').val(usuario);
        modal.find('#txtContraseña').val('');
    });

    // Enviar el formulario al hacer clic en el botón "Guardar"
    $('#btnGuardarPersonal').click(function () {
        var form = $('#personalForm');
        if (!form[0].checkValidity()) {
            form[0].reportValidity();
            return;
        }

        $.ajax({
            url: form.attr('action'),
            type: 'POST',
            data: form.serialize(),
            success: function () {
                $('#modalPersonal').modal('hide');
                location.reload();  // Recarga la página para mostrar los cambios
            },
            error: function (xhr, status, error) {
                console.error("Error al guardar el personal: ", error);
                alert("Hubo un error al guardar el personal. Verifique la consola para más detalles.");
            }
        });
    });

    // Manejo del modal para eliminación
    $('#modalDelete').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget);
        var id = button.data('id');

        var modal = $(this);
        modal.find('#deletePersonalId').val(id);
    });
});
