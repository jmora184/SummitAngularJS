//Routing to different pages
//var App = angular.module("MyAppModule", ['ngRoute']);

app.controller("VendorController", ['$scope', '$http', '$uibModal', '$location', '$route','$window', function ($scope, $http, $uibModal, $location, $route,$window) {
        //Get All Vendors
        $http.get('http://localhost:51767/api/Vendors').then(function (response) {
            $scope.vendors = response.data;
            
        });

        //Insert a Vendor
        $scope.PostVendor = function (vendor) {
            $http.post('http://localhost:51767/api/Vendors', vendor);
            $location.path('/Vendor');
            $window.location.reload();
        }


        
    $scope.UpdateVendor = function (id, params) {


        if ($scope.vName != null) {
            params.VendorName = $scope.vName;
        }


        if ($scope.vAddress != null) {
            params.VendorAddress = $scope.vAddress;
        }


        console.log($scope.params.VendorID);
        console.log(id, params);
        $http.put('http://localhost:51767/api/Vendors/' + id, params);


        $location.path('/Vendor');
        $window.location.reload();



    }

        //Delete a Vendor
        $scope.Delete = function (id) {
            confirm("Do you want to delete the Vendor")
            $http.delete('http://localhost:51767/api/Vendors/' + id);
            $location.path('/Vendor');
            $window.location.reload();
    }

    $scope.openModel = function (id, VendorName, VendorAddress) {

        var modelInstance = $uibModal.open({
            templateUrl: 'openVendor.html',
            controller: 'modelCtrl2',

            size: 'xs',
            resolve: {
                params: function () {
                    return {
                        VendorID: id,
                        VendorName: VendorName,
                        VendorAddress: VendorAddress

                    }
                }
            }
        });

        modelInstance.result.then(function (selectedItem) {

        }, function () {

        });
    }
}]);

app.controller("InvoiceController", function ($scope, $http,$window,$location) {
        //Get All Invoice
        $http.get('http://localhost:51767/api/Invoices').then(function (response) {
            $scope.invoices = response.data;

        });
        //Insert an Invoice
        $scope.PostInvoice = function (invoice) {
            console.log(invoice)
            $http.post('http://localhost:51767/api/Invoices', invoice);
        }
        //Update an Invoice
        $scope.invoiceDetails = { Invoiceid: "", Date: "", Amount: "", Description: "", Status: "", VendorID:"" }
        $scope.GetInvoiceById = function (id) {
            alert(id);
            $http.get('http://localhost:51767/api/Invoices' + id).then(function (response) {
                $scope.invoiceDetails = response.data;
            });
        }
        $scope.UpdateInvoice = function (id, invoiceDetails) {
            alert(id);
            $http.put('http://localhost:51767/api/Invoices' + id, invoiceDetails);
            console.log(invoiceDetails.invoiceID)
        }


        //Delete an Invoice
    $scope.DeleteInvoice = function (id) {
        confirm("Do you want to delete the Invoice")
        $http.delete('http://localhost:51767/api/Invoices/' + id);
        $location.path('/Invoice');
        $window.location.reload();
    }

    });


  app.controller("yes", function ($scope, $http) {
    //Get All Vendors
    $http.get('http://localhost:51767/api/Payments').then(function (response) {
        $scope.vendors = response.data;

    });
    //Insert a Payment
    $scope.PostPayment = function (payment) {
        console.log(payment)
        $http.post('http://localhost:51767/api/Payments/PostPayment', payment);

    }
    //Update a Payment
    $scope.PaymentDetails = { Payid: "", InvoiceID: "", VendorID: "", PaymentDate: "", PaymentType: "", Amount: "" }
    $scope.GetPaymentById = function (id) {

        $http.get('http://localhost:51767/api/Payments/' + id).then(function (response) {
            $scope.PaymentDetails = response.data;
        });
    }
    $scope.UpdatePayment = function (id, PaymentDetails) {
        alert(id);
        $http.put('http://localhost:51767/api/Payments/' + id, PaymentDetails);
        console.log(PaymentDetails.Payid)
    }
    //Delete an Payment
    $scope.DeletePayment = function (id) {
        $http.delete('http://localhost:51767/api/Payments/' + id);
    }
});

app.controller('modelCtrl2', function ($scope, $uibModalInstance, $route,$location,params) {
    console.log(params);
    $scope.params = params;

    $scope.close = function () {

        $uibModalInstance.close("Done");

        
    }
});

app.controller('demo2', function ($scope, $http) {

    $scope.myDataSource2 = {
        chart: {
            caption: "Money History",
            subCaption: "Money recieved by year",
            numberPrefix: "$",
            theme: "ocean"
        },
        data: [
 
        ]
    };

    $http.get("http://localhost:51767/api/Values2").then(function (data) {
        console.log(data);
        $scope.myDataSource2.data = data.data;
        console.log($scope.myDataSource2);
    })

});