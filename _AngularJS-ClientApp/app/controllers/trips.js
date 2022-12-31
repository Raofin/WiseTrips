app.controller("trips", function ($scope, $http, $window) {

    if(localStorage.getItem('token') != null) {
        $http.get("https://localhost:44359/api/trips").then(function (resp) {
            $scope.trips = resp.data;
        });
    } else $window.location.href = '#!/login';
});