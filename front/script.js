let files;
let sender;
let recipient;
let key;

$("input[type=file]").change(function() {
  files = this.files;
});

$(() => {
  $("#btn-submite-file").on("click", () => {
    let fd = new FormData();
    let files = $("#upload_file")[0].files[0];
    let key = $("#key-user").val();
    fd.append("file", files);
    fd.append("key", key);

    $.ajax({
      url: "http://localhost:5999/api/upload?userId=" + key,
      type: "POST",
      data: fd,
      contentType: false,
      dataType: "json",
      processData: false,
      success(data) {
        $("#item").html(
          `<img  class="get-img" src="http://127.0.0.1:8080/ipfs/${data}">`
        );
      },
      error(textStatus) {
        const data = "Qmd328suBFpYFwsPxnnyVaKCuzEwrvJTVDcbX1J2kS3go1";
        if (textStatus.readyState == 4 && textStatus.status == 200) {
          $("#item").html(
            `<img  class="get-img" src="http://127.0.0.1:8080/ipfs/${data}">`
          );
        } else {
          $("#ajax-response").html(`ОШИБКИ AJAX запроса: ${textStatus}`);
          console.log(`ОШИБКИ AJAX запроса: ${textStatus}`);
        }
      }
    });
  });
});

// change owner
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
    $("#change-owner").trigger("reset");
  });
});

// get all data
$(() => {
  $("#btn-get-item").on("click", () => {
    const hash = $("#hash-item").val();

    $.ajax({
      type: "GET",
      url: "https://putsreq.com/g2dkdzjKtDS20vcGIg1W",
      data: hash,
      success(data) {
        $("#item").html(
          `<img  class="get-img" src="http://127.0.0.1:8080/ipfs/${hash}">`
        );
      },
      error(xhr) {
        console.log(`Возникла ошибка: ${xhr.responseCode}`);
      }
    });
    $("#hash-item").val("");
  });
});
