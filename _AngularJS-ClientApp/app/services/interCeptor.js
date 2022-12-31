app.factory("interCeptor", function ($location) {
    return {
        'request': function (config) {
            config.headers.Authorization = localStorage.getItem('token');
            return config;
        },
        'responseError': function (rejection) {

        }
    }
});