$(document).ready(function () {

    // Función para actualizar la enumeración
    function updateEnumeration() {
        $('#tblInfraccion tbody tr').each(function (index) {
            $(this).find('td:first').text(index + 1);
        });
    }

    // Llamar a la función para actualizar la enumeración al cargar la página
    updateEnumeration();

    $('#modalInfraccion').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget);
        var id = button.data('id');
        var nominfraccion = button.data('nominfraccion');
        var descripcion = button.data('descripcion');
        var resolucion = button.data('resolucion');
        var rango = button.data('rango');
        var monto = button.data('monto');
        var modal = $(this);

        modal.find('.modal-title').text(id ? 'Actualizar Ordenanza Municipal' : 'Agregar Ordenanza Municipal');
        modal.find('#hddIdInfraccion').val(id ? id : 0);
        modal.find('#txtNomInfraccion').val(nominfraccion ? nominfraccion : '');
        modal.find('#txtDescripcion').val(descripcion ? descripcion : '');
        modal.find('#txtResolucion').val(resolucion ? resolucion : '');
        modal.find('#txtRango').val(rango ? rango : '');
        modal.find('#txtMonto').val(monto ? monto : '');
    });

    $('#btnGuardarInfraccion').click(function () {
        var form = $('#vInfraccionForm');
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
                $('#modalInfraccion').modal('hide');
                location.reload(); // Recargar la página para ver los cambios
            },
            error: function (xhr, status, error) {
                console.error("Error al guardar: " + error);
                alert("Error al guardar los datos");
            }
        });
    });

    $('#modalDelete').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget);
        var id = button.data('id');
        var modal = $(this);

        modal.find('#deleteInfraccionId').val(id);
    });
});
