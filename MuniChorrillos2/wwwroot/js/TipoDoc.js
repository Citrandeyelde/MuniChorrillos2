$(document).ready(function () {
    // Manejo del evento 'show' del modal para agregar o actualizar
    $('#modalTipoDoc').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget); // Botón que disparó el modal
        var id = button.data('tipo-doc-id');
        var descripcion = button.data('descripcion');
        var numIdentifica = button.data('num-identifica');
        var modal = $(this);

        modal.find('.modal-title').text(id ? 'Actualizar Tipo de Documento' : 'Agregar Tipo de Documento');
        modal.find('#hddIdTipoDoc').val(id ? id : 0);
        modal.find('#txtDescripcion').val(descripcion ? descripcion : '');
        modal.find('#txtNumIdentifica').val(numIdentifica ? numIdentifica : '');
    });

    // Manejo del evento 'click' para guardar los datos
    $('#btnguardarDocumento').click(function () {
        var form = $('#tipoDocForm');
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
                $('#modalTipoDoc').modal('hide');
                location.reload(); // Recargar la página para ver los cambios
            },
            error: function (xhr, status, error) {
                console.error("Error al guardar: " + error);
            }
        });
    });


    // Manejo del evento 'show' del modal para eliminar
    $('#modalDelete').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget);
        var id = button.data('tipo-doc-id');
        var modal = $(this);

        modal.find('#deleteTipoDocId').val(id);
    });
});
