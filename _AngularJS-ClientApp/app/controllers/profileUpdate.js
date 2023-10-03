app.controller("profileUpdate", function (ajax, $scope, $http, $window) {

    if (localStorage.getItem('token') != null) {
        ajax.get("https://localhost:7017/api/logged-in-user", success);

        function success(response) {
            $scope.user = response.data;
            $('#username').val(response.data.Username);
            $('#email').val(response.data.Email);
            $('#password').val(response.data.Password);
        }

        $scope.submit = function () {
            ajax.post("https://localhost:7017/api/update", $scope.post);
            $window.location.href = '#!/profile';
        }

    } else $window.location.href = '#!/login';
});
