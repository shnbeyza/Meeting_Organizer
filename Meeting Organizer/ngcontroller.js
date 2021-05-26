var app = angular.module('proje1', []);
app.controller('Toplanti', function ($scope, $http) {//Toplanti->kullanicictrl

    $http.get("https://localhost:44318/api/Toplanti/ToplantilariListele").then(function (response) {
        $scope.list = response.data;
    });


    $scope.ToplantiSilID = function (SilinecekID) {
        $http.get("https://localhost:44318/api/Toplanti/ToplantiSilId", { params: { id: SilinecekID } }).then(function (response) {
            $scope.list = response.data;
        });
    }


    $scope.ToplantiEkle = function (veri) {
        $http.post("https://localhost:44318/api/Toplanti/ToplantiEkle", veri).then(function (response) {
            $scope.list = response.data;
            $scope.ToplantiTip = {};
        });
    }


    $scope.ToplantiGuncelle = function (yeni) {

        $scope.ToplantiTip = yeni;

    }


    $scope.guncelle = function (yeni) {
        $http.post("https://localhost:44318/api/Toplanti/ToplantiGuncelle", yeni).then(function (response) {

            if (response.data == true)
            {
                $http.get("https://localhost:44318/api/Toplanti/ToplantilariListele").then(function (response) {
                    $scope.list = response.data;
                    alert("Kullanıcı güncelleme işlemi başarıyla tamamlandı.")
                });
            }

            else
                alert("Kullanıcı güncelleme işlemi sırasında hata oluştu.")
            $scope.ToplantiTip = {};
        });

        console.log("güncellenecek veri", yeni);
    }


    $scope.islemiptal = function () {

        $scope.ToplantiTip = {};
    }

});