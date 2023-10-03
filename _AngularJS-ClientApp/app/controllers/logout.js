app.controller("logout", function ($http, $window) {

    if(localStorage.getItem('token') != null) {
        $http.get("https://localhost:7017/api/logout")
            .then(function (response) {
                localStorage.removeItem('token');
            }), function (error) {
            console.log(error);
        }
    } else $window.location.href = '#!/login';
})