let files; let sender; let 
recipient;

$('input[type=file]').change(function () {
  files = this.files;
  console.log(files);
});

$(() => {
  $('#btn-submite-file').on('click', () => {
    const fd = new FormData($('#send-file'));
    $.ajax({
      url: '##',
      type: 'POST',
      data: fd,
      success(data) {
        $('#ajax-respond').html(data);
      },
      error(textStatus) {
        $('#ajax-respond').html(`ОШИБКИ AJAX запроса: ${textStatus}`);
        console.log(`ОШИБКИ AJAX запроса: ${textStatus}`);
      },
      cache: false,
      contentType: false,
      processData: false,
    });
  });
});

$(() => {
  $('#btn-change-owner').on('click', () => {
    const msg = $('#change-owner').serialize();
    console.log(msg);
    $.ajax({
      type: 'POST',
      url: '##',
      data: msg,
      success(data) {
        $('#results').html(data);
      },
      error(xhr, _str) {
        console.log(`Возникла ошибка: ${xhr.responseCode}`);
      },
    });
  });
});

