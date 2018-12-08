var IslemSonucTurleri =
{
    Basarili: "BAŞARILI",
    Hata: "HATA",
    Uyari: "UYARI",
    Bilgi: "BİLGİ"
};

var IslemSonucKodlari =
{
    Basarili: 1,
    Hata: 2,
    Uyari: 3,
    Bilgi: 4
};

function ModalBilgilendirme(baslik, aciklama) {
    $("#MdlBaslik").text(baslik);
    $("#MdlAciklama").text(aciklama);
    ModalGoster("MdlBilgilendirme");
}

function ModalGoster(modalId) {
    $("#" + modalId).modal("show");
}

function ModalKapat(modalId) {
    $("#" + modalId).modal("hide");
}

function userLogin() {
    try {
        var kkodu = $("#Email").val();
        var psw = $("#Password").val();
        if (kkodu === "") {
            ModalBilgilendirme("UYARI", "E-MAİL Boş Geçilemez.");
            return false;
        }
        if (psw === "") {
            ModalBilgilendirme("UYARI", "PAROLA Boş Geçilemez.");
            return false;
        }

        $.ajax({
            type: "POST",
            url: "/LoginOrRegister/SignIn",
            content: "application/json",
            dataType: 'json',
            data: $('#FrmUserLogin').serialize(),
            async: false,
            success: function (data) {
                console.log(data);
                if (data.IslemKodu === 1) {
                    window.location.href = "/Admin/Home/Index";
                }
                else if (data.IslemKodu === 2) {
                    ModalBilgilendirme("HATA", "EMAİL-ŞİFRE UYUMSUZLUĞU");
                }
            },
            error: function (ex) {
                ModalBilgilendirme(IslemSonucTurleri.Hata, data.Aciklama);
            }
        });
    }
    catch (e) {
        console.log("Hata : " + e);
    }
}




