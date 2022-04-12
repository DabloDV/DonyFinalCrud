jQueryAjaxPost = (form,titulo, mensaje) => {
    Swal.fire({
        title: titulo,
        showDenyButton: true,
        showCancelButton: false,
        confirmButtonText: 'Sí',
        denyButtonText: `No`,
    }).then((result) => {
         
        if (result.isConfirmed) {
            Swal.fire('Guardado', '', 'success')
            form.submit();
        } else if (result.isDenied) {
            Swal.fire('Datos no guardados', '', 'info')

        }

        
    })

    return false;
}

jQueryAjaxPost2 = (form, titulo, mensaje) => {
    Swal.fire({
        title: titulo,
        showDenyButton: true,
        showCancelButton: false,
        confirmButtonText: 'Sí',
        denyButtonText: `No`,
    }).then((result) => {

        if (result.isConfirmed) {
            Swal.fire('Usuario eliminado', '', 'success')
            form.submit();
        } else if (result.isDenied) {
            Swal.fire('Usuario no eliminado', '', 'info')

        }


    })

    return false;
}