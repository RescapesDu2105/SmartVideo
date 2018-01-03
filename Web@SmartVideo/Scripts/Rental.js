$(document).ready(function ()
{
    $('#Modal').on('show.bs.modal', function (event)
    {
        var button = $(event.relatedTarget);
        var trailer = button.data('trailer'); 
        var modal = $(this);
        modal.find('.modal-body iframe').attr('src', trailer);
        //console.log("test" + modal.find('.modal-body iframe'));
    });


    $('#fermerVisu').click(function ()
    {
        $('#player')[0].src += "&autoplay=0";
    });
});
