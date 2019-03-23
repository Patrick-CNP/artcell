let files;
let sender;
let recipient;

$("input[type=file]").change(function() {
  files = this.files;
  console.log(files);
});

$(() => {
  $("#btn-submite-file").on("click", () => {
    // const fd = new FormData(jQuery("#upload_file")[0]);
    // console.log(fd);
    var data = new FormData($("#upload_file"));

    jQuery.each($("#upload_file")[0].files, (i, file) => {
      data.append(i, file);
    });
    $.ajax({
        url: "http://localhost:5999/api/upload?userId=1239210831209jdkofdjkfdshfksdfsdf",
      type: "POST",
      data: data,
      contentType: false,
      processData: false,
      success(data) {
        $(".ajax-response").html(data);
      },
      error(textStatus) {
        $("#ajax-response").html(`ОШИБКИ AJAX запроса: ${textStatus}`);
        console.log(`ОШИБКИ AJAX запроса: ${textStatus}`);
      },
      cache: false,
      contentType: false,
      processData: false
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
