//Routing to different pages
//var App = angular.module("MyAppModule", ['ngRoute']);

app.controller("VendorController", function ($scope, $http) {
        //Get All Vendors
        $http.get('http://localhost:53225/api/Vendors').then(function (response) {
            $scope.vendors = response.data;
            
        });

        //Insert a Vendor
        $scope.PostVendor = function (vendor) {
            $http.post('http://localhost:53225/api/Vendors', vendor);
        }

        //Update a Vendor
        $scope.vendorDetails = { id: "", Name: "", Address: "" }
        $scope.GetVendorById = function (id) {

            $http.get('http://localhost:53225/api/Vendors' + id).then(function (response) {
                $scope.vendorDetails = response.data;
            });
        }
        
        $scope.UpdateVendor = function (id,vendorDetails) {
            alert(id);
            $http.put('http://localhost:53225/api/Vendors' + id, vendorDetails);
            console.log(vendorDetails.VendorName)
        }

        //Delete a Vendor
        $scope.Delete = function (id) {
            confirm("Do you want to delete the Vendor")
            $http.delete('http://localhost:53225/api/Vendors/' + id);
        }
});

app.controller("InvoiceController", function ($scope, $http) {
        //Get All Invoice
        $http.get('http://localhost:53225/api/Invoices').then(function (response) {
            $scope.invoices = response.data;

        });
        //Insert an Invoice
        $scope.PostInvoice = function (invoice) {
            console.log(invoice)
            $http.post('http://localhost:53225/api/Invoices', invoice);
        }
        //Update an Invoice
        $scope.invoiceDetails = { Invoiceid: "", Date: "", Amount: "", Description: "", Status: "", VendorID:"" }
        $scope.GetInvoiceById = function (id) {
            alert(id);
            $http.get('http://localhost:53225/api/Invoices' + id).then(function (response) {
                $scope.invoiceDetails = response.data;
            });
        }
        $scope.UpdateInvoice = function (id, invoiceDetails) {
            alert(id);
            $http.put('http://localhost:53225/api/Invoices' + id, invoiceDetails);
            console.log(invoiceDetails.invoiceID)
        }


        //Delete an Invoice
        $scope.DeleteInvoice = function (id) {
            $http.delete('http://localhost:53225/api/Invoices' + id);
        }


    });


  app.controller("yes", function ($scope, $http) {
    //Get All Vendors
    $http.get('http://localhost:53225/api/Payments').then(function (response) {
        $scope.vendors = response.data;

    });
    //Insert a Payment
    $scope.PostPayment = function (payment) {
        console.log(payment)
        $http.post('http://localhost:53225/api/Payments/PostPayment', payment);

    }
    //Update a Payment
    $scope.PaymentDetails = { Payid: "", InvoiceID: "", VendorID: "", PaymentDate: "", PaymentType: "", Amount: "" }
    $scope.GetPaymentById = function (id) {

        $http.get('http://localhost:53225/api/Payments/' + id).then(function (response) {
            $scope.PaymentDetails = response.data;
        });
    }
    $scope.UpdatePayment = function (id, PaymentDetails) {
        alert(id);
        $http.put('http://localhost:53225/api/Payments/' + id, PaymentDetails);
        console.log(PaymentDetails.Payid)
    }
    //Delete an Payment
    $scope.DeletePayment = function (id) {
        $http.delete('http://localhost:53225/api/Payments/' + id);
    }
});