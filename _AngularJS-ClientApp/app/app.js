var app = angular.module("myApp", ["ngRoute"]);

app.config(["$routeProvider", "$locationProvider", function ($routeProvider, $locationProvider) {

    $routeProvider
        .when("/", {
            templateUrl: "views/pages/home.html",
        })
        .when("/trips", {
            templateUrl: "views/pages/trips.html",
            controller: 'trips'
        })
        .when("/packages", {
            templateUrl: "views/pages/packages.html",
            controller: 'packages'
        })
        .when("/package-details", {
            templateUrl: "views/pages/package-details.html",
            controller: 'packageDetails'
        })
        .when("/login", {
            templateUrl: "views/pages/login.html",
            controller: 'login'
        })
        .when("/logout", {
            templateUrl: "views/pages/login.html",
            controller: 'logout'
        })
        .when("/register", {
            templateUrl: "views/pages/register.html",
            controller: 'register'
        })
        .when("/pdf", {
            templateUrl: "views/pages/home.html",
            controller: 'pdf'
        })
        .when("/profile", {
            templateUrl: "views/pages/profile.html",
            controller: 'profile'
        })
        .when("/profile-update", {
            templateUrl: "views/pages/profile-update.html",
            controller: 'profileUpdate'
        })
        .when("/take", {
            templateUrl: "views/pages/take.html",
            controller: 'take'
        })
        .otherwise({
            redirectTo: "/"
        });
}]);

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('interCeptor');
})