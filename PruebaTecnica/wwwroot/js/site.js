function displayAlert() {
    Swal.fire("Marca guardada con éxito");
}

$(function () {
    var PlaceHolderElement = $('#PlaceHolder');
    $('button[data-toggle="ajax-modal"]').click(function (event) {
        var url = $(this).data('url');
        $.get(url).done(function (data) {
            PlaceHolderElement.html(data);
            PlaceHolderElement.find('.modal').modal('show');
        });
    });
});

function editarMarcaModal(marcaId) {
    $.ajax({
        url: '/Marca/_ModificarMarca',
        type: 'POST',
        data: { marcaId: marcaId },
        success: function (result) {
            $('#PlaceHolder').html(result);
            $('#modalEditarMarca').modal('show');
        },
        error: function (xhr, status, error) {
            
        }
    });
}
function editarMarca(marcaId) {
    var marca = {
        IdMarca: marcaId,
        NombreMarca: $('#NombreMarca').val(),
        Descripcion: $('#descripcionInput').val(),
        Herramienta: $('#tipoHerramientaInput').val(),
        Exactitud: $('#exactitudInput').val()
    };

    $.ajax({
        url: '/Marca/ModificarMarca',
        type: 'POST',
        data: marca,
        success: function (result) {
            console.log(result)
            if (result.success) {
                Swal.fire({
                    title: '¡Actualizado!',
                    text: result.message,
                    icon: 'success'
                }).then(function () {
                    location.reload();
                });
            } else {
                Swal.fire({
                    title: 'Error',
                    text: 'Hubo un error al actualizar el registro',
                    icon: 'error'
                });
            }
        },
        error: function (xhr, status, error) {
            Swal.fire({
                title: 'Error',
                text: 'Hubo un error al actualizar el registro',
                icon: 'error'
            });
        }
    });
}

function eliminarMarca(marcaId) {
    Swal.fire({
        title: 'Confirmar eliminación',
        text: '¿Está seguro de que desea eliminar este registro?',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Sí, eliminar',
        cancelButtonText: 'Cancelar'
    }).then(function (result) {
        if (result.isConfirmed) {
            $.ajax({
                url: '/Marca/EliminarMarca',
                type: 'DELETE',
                data: { marcaId: marcaId },
                success: function (result) {
                    if (result.success) {
                        Swal.fire({
                            title: '¡Eliminado!',
                            text: result.message,
                            icon: 'success'
                        }).then(function () {
                            location.reload();
                        });
                    } else {
                        Swal.fire({
                            title: 'Error',
                            text: 'Hubo un error al eliminar el registro',
                            icon: 'error'
                        });
                    }
                },
                error: function (xhr, status, error) {
                    Swal.fire({
                        title: 'Error',
                        text: 'Hubo un error al eliminar el registro',
                        icon: 'error'
                    });
                }
            });
        }
    });
}
