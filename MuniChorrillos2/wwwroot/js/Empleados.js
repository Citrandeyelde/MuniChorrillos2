$(document).ready(function () {
    $('#modalEmpleado').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget); // Botón que disparó el modal
        var id = button.data('id'); // Extraer el ID del empleado (si lo tiene)
        var nombre = button.data('nombre');
        var apellidoP = button.data('apellidop');
        var apellidoM = button.data('apellidom');
        var email = button.data('email');
        var telefono = button.data('telefono');
        var direccion = button.data('direccion');
        var fechaIngreso = button.data('fechaingreso');
        var activo = button.data('activo'); // Extraer el estado activo, esperando que sea 1 o 0
        var estadoCivil = button.data('estadocivil');
        var nroIdentidad = button.data('nroidentidad');
        var tipoDoc = button.data('tipodoc');

        var modal = $(this);
        modal.find('#hddIdEmpleado').val(id ? id : 0);
        modal.find('#txtNomEmpleado').val(nombre);
        modal.find('#txtApellidoP').val(apellidoP);
        modal.find('#txtApellidoM').val(apellidoM);
        modal.find('#txtEmail').val(email);
        modal.find('#txtTelefono').val(telefono);
        modal.find('#txtDireccion').val(direccion);
        modal.find('#txtFechaIngreso').val(fechaIngreso);
        modal.find('#txtEstadoCivil').val(estadoCivil);
        modal.find('#txtNroIdentidad').val(nroIdentidad);
        modal.find('#ddlTipoDoc').val(tipoDoc);

        // Ajustar el checkbox según el valor de 'activo'
        modal.find('#chkActivo').prop('checked', activo === 1);

        if (id) {
            modal.find('.modal-title').text('Actualizar Empleado');
        } else {
            modal.find('.modal-title').text('Agregar Empleado');
        }
    });

    $('#modalDelete').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget);
        var id = button.data('id');

        var modal = $(this);
        modal.find('#deleteEmpleadoId').val(id);
    });

    $('#btnGuardarEmpleado').on('click', function () {
        $('#empleadoForm').submit();
    });

    $('.activo-checkbox').on('change', function () {
        var checkbox = $(this); // Guarda el checkbox en una variable para reusarlo
        var empleadoId = checkbox.data('id');
        var estado = checkbox.is(':checked');
        var mensaje = estado ? "¿Desea activar este empleado?" : "¿Desea bloquear este empleado?";

        // Mostrar un mensaje de confirmación
        if (confirm(mensaje)) {
            // Si el usuario confirma, envía la solicitud AJAX
            $.ajax({
                url: '/Empleados/UpdateEstadoActivo',
                method: 'POST',
                data: {
                    id: empleadoId,
                    activo: estado ? 1 : 0
                },
                success: function (response) {
                    alert('Estado actualizado correctamente');
                },
                error: function (error) {
                    alert('Error al actualizar el estado');
                    // En caso de error, revierte el estado del checkbox
                    checkbox.prop('checked', !estado);
                }
            });
        } else {
            // Si el usuario no confirma, revierte el estado del checkbox
            checkbox.prop('checked', !estado);
        }
    });

});
