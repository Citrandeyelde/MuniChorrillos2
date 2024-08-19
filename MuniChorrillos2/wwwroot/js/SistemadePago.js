$(document).ready(function () {
    // Manejo del modal para mostrar la imagen
    $('#imageModal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget); // Botón que abrió el modal
        var modal = $(this);
        var imagenBase64 = button.data('imagen'); // Obtiene la imagen en Base64

        // Asigna la imagen en el modal
        modal.find('#modalImage').attr('src', imagenBase64);
    });  
});
