function checkFunction() {
    var usernameValue = document.getElementById('kullaniciadi').querySelector('input').value;
    var passwordValue = document.getElementById('sifre').querySelector('input').value;

    if (usernameValue === 'Admin' && passwordValue === '1234') {
        document.getElementById("change").innerHTML = "Giriş Yapılıyor...";

        // Örnek olarak 2 saniye sonra 'Giriş Yapıldı!' mesajını gösterelim
        setTimeout(function() {
            document.getElementById("change").innerHTML = "Giriş Yapıldı!";
        }, 4000);
    } else {
        document.getElementById("change").innerHTML = "Eksik veya Hatalı bilgi...";
        // Kullanıcı adı veya şifre hatalıysa 2 saniye sonra "Giriş Yap" mesajını geri getir
        setTimeout(function() {
            document.getElementById("change").innerHTML = "Giriş Yap";
        }, 4000);
    }
}