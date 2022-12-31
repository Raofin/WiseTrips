app.controller("profile", function (ajax, $scope, $http, $window) {

    if (localStorage.getItem('token') != null) {
        ajax.get("https://localhost:44359/api/logged-in-user", success);

        function success(response) {
            $scope.user = response.data;
        }
        
    } else $window.location.href = '#!/login';
});
