$(document).ready(function () {
    // Manejo del evento 'show' del modal para agregar o actualizar
    $('#modalVmunicipal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget); // Botón que disparó el modal
        var id = button.data('id');
        var placa = button.data('placa');
        var marca = button.data('marca');
        var modelo = button.data('modelo');
        var nmotor = button.data('nmotor');
        var año = button.data('año');
        var color = button.data('color');
        var estado = button.data('estado');
        var personal = button.data('personal');
        var modal = $(this);

        modal.find('.modal-title').text(id ? 'Actualizar Vehículo Municipal' : 'Agregar Vehículo Municipal');
        modal.find('#hddIdVehiculoMunicipal').val(id ? id : 0);
        modal.find('#txtPlaca').val(placa ? placa : '');
        modal.find('#txtMarca').val(marca ? marca : '');
        modal.find('#txtModelo').val(modelo ? modelo : '');
        modal.find('#txtNmotor').val(nmotor ? nmotor : '');
        modal.find('#txtAño').val(año ? año : '');
        modal.find('#txtColor').val(color ? color : '');
        modal.find('#txtEstado').val(estado ? estado : '');
        modal.find('#ddlPersonal').val(personal ? personal : '');
    });

    // Manejo del evento 'click' para guardar los datos
    $('#btnGuardarVmunicipal').click(function () {
        var form = $('#vMunicipalForm');
        if (!form[0].checkValidity()) {
            form[0].reportValidity();
            return; // Detener la ejecución si el formulario no es válido
        }
        var actionUrl = form.attr('action');
        var dataToSend = form.serialize();

        $.ajax({
            type: 'POST',
            url: actionUrl,
            data: dataToSend,
            success: function (data) {
                $('#modalVmunicipal').modal('hide');
                location.reload(); // Recargar la página para ver los cambios
            },
            error: function (xhr, status, error) {
                console.error("Error al guardar: " + error);
                alert("Error al guardar los datos");
            }
        });
    });

    // Manejo del evento 'show' del modal para eliminar
    $('#modalDelete').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget);
        var id = button.data('id');
        var modal = $(this);

        modal.find('#deleteVehiculoMunicipalId').val(id);
    });
});
