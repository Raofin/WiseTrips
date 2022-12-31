app.controller("login", function ($scope, ajax, $window) {

    if(localStorage.getItem('token') == null) {
        $scope.submit = function () {
            ajax.post("https://localhost:44359/api/login", $scope.post, success, error);
        }

        function success(response){
            console.log(response);
            localStorage.setItem('token', response.data.AuthToken);
            $window.location.href = '#!/packages';
        }

        function error(error){
            console.log(error);
        }
        
    } else $window.location.href = '#!/packages';
});
