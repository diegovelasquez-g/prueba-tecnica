//Marcas

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


//Equipos
function editarEquipoModal(equipoId) {
    $.ajax({
        url: '/Equipo/_ModificarEquipo',
        type: 'POST',
        data: { equipoId: equipoId },
        success: function (result) {
            $('#PlaceHolder').html(result);
            $('#editarEquipo').modal('show');
        },
        error: function (xhr, status, error) {

        }
    });
}

function editarEquipo(equipoId) {
    var equipo = {
        IdEquipo: equipoId,
        IdMarca: $('#IdMarca').val(),
        NombreEquipo: $('#NombreEquipo').val(),
        Descripcion: $('#Descripcion').val(),
        NumeroSerie: $('#NumeroSerie').val(),
    };

    $.ajax({
        url: '/Equipo/ModificarEquipo',
        type: 'POST',
        data: equipo,
        success: function (result) {
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

function eliminarEquipo(equipoId) {
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
                url: '/Equipo/EliminarEquipo',
                type: 'DELETE',
                data: { equipoId: equipoId },
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

//Prestamos
function cargarProductos() {
    var marcaId = $('#IdMarca').val();
    $.ajax({
        url: '/Prestamo/ObtenerEquipos',
        type: 'POST',
        data: { marcaId: marcaId },
        success: function (result) {
            if (result.success) {
                var select = $('#IdEquipo');
                select.empty();
                select.append($('<option></option>').val(0).text('Seleccione un equipo'));

                if (result.equipos.length > 0) {
                    $.each(result.equipos, function (index, equipo) {
                        var option = $('<option></option>').val(equipo.idEquipo).text(equipo.nombreEquipo);
                        select.append(option);
                    });
                } else {
                    select.empty();
                    select.append($('<option></option>').val(0).text('No hay equipos en esta marca'));
                }
            } else {
                console.log('Hubo un error al obtener los equipos');
            }
        },
        error: function (xhr, status, error) {
            console.log('Hubo un error en la llamada al servidor');
        }
    });
}

function eliminarPrestamo(prestamoId) {
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
                url: '/Prestamo/EliminarPrestamo',
                type: 'DELETE',
                data: { prestamoId: prestamoId },
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

function editarPrestamoModal(prestamoId) {
    $.ajax({
        url: '/Prestamo/_ModificarPrestamo',
        type: 'POST',
        data: { prestamoId: prestamoId },
        success: function (result) {
            $('#PlaceHolder').html(result);
            $('#editarPrestamo').modal('show');
        },
        error: function (xhr, status, error) {

        }
    });
}

function editarPrestamo(prestamoId) {
    var prestamo = {
        IdPrestamo: prestamoId,
        IdEquipo: $('#IdEquipo').val(),
        NombrePersona: $('#NombrePersona').val(),
        FechaInicio: $('#FechaInicio').val(),
        FechaFin: $('#FechaFin').val(),
    };

    $.ajax({
        url: '/Prestamo/ModificarPrestamo',
        type: 'POST',
        data: prestamo,
        success: function (result) {
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