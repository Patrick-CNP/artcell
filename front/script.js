let files;
let sender;
let recipient;
let key;


$("input[type=file]").change(function() {
  files = this.files;
  console.log(files);
});

$(() => {
  $("#btn-submite-file").on("click", () => {

    let fd = new FormData();
    let files = $("#upload_file")[0].files[0];
    let key = $("#key-user").val();
    fd.append("file", files);
    fd.append("key", key);

    $.ajax({
      url: "https://putsreq.com/vX2qLnaVmK6YLOB7h7YZ",
      type: "POST",
      data: fd,
      contentType: false,
      processData: false,
      success(data) {
        $(".ajax-response").html(JSON.parse(data).params.key);
      },
      error(textStatus) {
        $("#ajax-response").html(`ОШИБКИ AJAX запроса: ${textStatus}`);
        console.log(`ОШИБКИ AJAX запроса: ${textStatus}`);
      }
    });
  });
});

$(() => {
  $("#btn-change-owner").on("click", () => {
    const msg = $("#change-owner").serialize();
    console.log(msg);
    $.ajax({
      type: "GET",
      url: "https://putsreq.com/g2dkdzjKtDS20vcGIg1W",
      data: msg,
      success(data) {
        $(".ajax-response").html(data);
      },
      error(xhr) {
        console.log(`Возникла ошибка: ${xhr.responseCode}`);
      }
    });
  });
});
