app.controller("take", function ($scope, ajax, $window, $http, $routeParams) {

    if (localStorage.getItem('token') != null) {
        $http.get("https://localhost:44359/api/packages/")
            .then(resp => $scope.package = resp.data);

        $http.get("https://localhost:44359/api/hotels/")
            .then(resp => $scope.hotel = resp.data);

        $scope.submit = () => {
            console.log($scope.formData);
            ajax.post("https://localhost:44359/api/trip/add", $scope.formData);
            ajax.get("https://localhost:44359/api/pdf", success, error);
        }

        function success(response) {
            console.log(response);
            window.open(response.data.Message, "_blank");
        }

        function error(error) {
            console.log(error);
        }
    } else $window.location.href = '#!/packages';

    $('#package').change(function () {
        if (this.value != undefined) {
            ajax.get("https://localhost:44359/api/package/" + this.value, success, error);
        }

        function success(response) {
            $('#package-cost').text('$' + response.data.Price);
        }

        $('#total-amount').text("$" + (+$('#package-cost').text().substring(1) + +$('#persons-cost').text().substring(1)));
    })

    $('#hotel').change(function () {
        if (this.value != undefined) {
            ajax.get("https://localhost:44359/api/hotels/" + this.value, success, error);
        }

        function success(response) {
            $('#hotel-cost').text('$' + response.data.Price);
        }

        $('#total-amount').text("$" + (+$('#package-cost').text().substring(1) + +$('#persons-cost').text().substring(1)));
    })

    $('#persons').bind('keyup mouseup', function () {
        if (this.value > 0) {
            $('#persons-cost').text("$" + $('#hotel-cost').text().substring(1) * $('#persons').val());
        }

        function success(response) {
            $('#hotel-cost').text('$' + response.data.Price);
        }

        $('#total-amount').text("$" + (+$('#package-cost').text().substring(1) + +$('#persons-cost').text().substring(1)));
    })
});