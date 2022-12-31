app.controller("packages", function ($scope, $http, $window) {
    
    if(localStorage.getItem('token') != null) {
        $http.get("https://localhost:44359/api/packages").then(function (resp) {
            $scope.packages = resp.data;
        });
    } else $window.location.href = '#!/login';
});
