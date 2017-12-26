$(document).ready(function ()
{
    $('#film').click(function (event)
    {
        var img = $(event.currentTarget);

        var id = img.data('id');
        console.log(id);
        var title = img.data('title');
        var posterpath = img.data('posterpath');

        var modal = $('#ModalLouer');
        $('#MainContent_FilmID').attr('value', id);
        modal.find('.modal-body h5').text(title);
        modal.find('.modal-body img').attr('src', posterpath);

        $('#ModalLouer').modal('show');
    });
});