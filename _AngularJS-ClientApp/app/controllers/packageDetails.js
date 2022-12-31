app.controller("packageDetails", function ($scope, $http, $routeParams, $window) {

    if(localStorage.getItem('token') != null) {
        $http.get("https://localhost:44359/api/package/" + $routeParams.id).then(function (resp) {
            $scope.package = resp.data;
        });
    } else $window.location.href = '#!/login';
});
