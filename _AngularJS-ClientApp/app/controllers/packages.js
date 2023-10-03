app.controller("packages", function ($scope, $http, $window) {
    
    if(localStorage.getItem('token') != null) {
        $http.get("https://localhost:7017/api/packages").then(function (resp) {
            $scope.packages = resp.data;
        });
    } else $window.location.href = '#!/login';
});
