var app = angular.module("myApp", ["ngRoute", "ng-fusioncharts","ui.bootstrap"]); 

app.config(function($routeProvider) {
    $routeProvider
    .when("/", {
        templateUrl : "view1.html"
    })
    .when("/Payroll", {
        templateUrl : "Payroll.html"
        })
        .when("/view4", {
            templateUrl: "view4.html"
        })
    .when("/Graph", {
        
        templateUrl : "Graph.html"
        })
        .when("/Invoice", {

            templateUrl: "Invoice.html"
        }) 
        .when("/Payment", {

            controller: "yes",
            templateUrl: "Payment.html"
        })
        .when("/customers", {

            templateUrl: "customers.html"
        })
        .when("/product", {

            templateUrl: "product.html"
        })
    .when("/Vendor", {
        templateUrl : "Vendor.html"
        });

});

//

app.controller("CustomerController", ['$scope', '$http', '$uibModal', '$location', '$route', '$window', function ($scope, $http, $uibModal, $location, $route, $window) {
    $http.get('http://localhost:51767/api/customers').then(function (response) {
        $scope.customers = response.data;

    });

    $scope.PostCustomer = function (customer) {
        $http.post('http://localhost:51767/api/customers', customer);
    }

    $scope.UpdateCustomer = function (id, params) {


        if ($scope.name != null) {
            params.CustName = $scope.name;
        }


        if ($scope.add != null) {
            params.CustAddress = $scope.add;
        }

        if ($scope.phone != null) {
            params.CustPhone = $scope.phone;
        }


        console.log($scope.params.CustID);
        console.log(id, params);
        $http.put('http://localhost:51767/api/customers/' + id, params);


        //$location.path('/customers');
        //$window.location.reload();
    }
    $scope.openModel = function (id, CustName,CustAddress,CustPhone) {

        var modelInstance = $uibModal.open({
            templateUrl: 'openCustomers.html',
            controller: 'modelCtr3',

            size: 'xs',
            resolve: {
                params: function () {
                    return {
                        CustID:id,
                        CustName: CustName,
                        CustAddress: CustAddress,
                        CustPhone: CustPhone

                    }
                }
            }
        });

        modelInstance.result.then(function (selectedItem) {

        }, function () {

        });
    }
}]);



app.controller("yes", function ($scope, $http) {
    //Get All Vendors
    $http.get('http://localhost:51767/api/Payments').then(function (response) {
        $scope.vendors = response.data;

    });
});
app.controller("customerController", ['$scope', '$http', '$location',
    function ($scope, $http, $location) {
        $scope.submitForm = function (form) {
            if (form) {
                item = {
                    "CustID": $scope.item.CustID,
                    "CustName": $scope.item.CustName,
                    "CustAddress": $scope.item.CustAddress,
                    "CustPhone": $scope.item.CustPhone
                }
                $http.post("http://localhost:51767/api/customers",
                    item
                ).then(function (result) {
                    location.reload(true);
                })
            }
        };
    }]);

app.controller("productControllers", productControllers);
function productControllers($http, $scope) {
    $http.get("http://localhost:51767/api/product").then(function (data) {
        $scope.products = data.data;
    });
}
app.controller("productController", ['$scope', '$http', '$location',
    function ($scope, $http, $location) {
        $scope.submitForm = function (form) {
            if (form) {
                item = {
                    "ProductID": $scope.item.ProductID,
                    "VendorID": $scope.item.VendorID,
                    "Price": $scope.item.Price,
                    "Description": $scope.item.Description
                }
                $http.post("http://localhost:51767/api/product",
                    item
                ).then(function (result) {
                    location.reload(true);
                })
            }
        }
    }]);



//


app.controller("demoCntrl", demoCntrl);
    function demoCntrl($http,$scope){
        $http.get("http://localhost:51767/api/user").then(function(data){
            $scope.users=data.data;
       
        })
}

app.controller("payroll", ['$scope', '$http','$uibModal', '$location', '$route','$window', function ($scope, $http,$uibModal,  $location, $route,$window) {


    //Get All Vendors
    $http.get('http://localhost:51767/api/user').then(function (response) {
        $scope.payroll = response.data;

    });

    $scope.$watch('sn_number', function (v) {
        $scope.id = v;
    });

    //Insert a Vendor
    $scope.PostVendor = function (vendor) {
        $http.post('http://localhost:51767/api/user', vendor);
    }

    //Update a Vendor
    $scope.vendorDetails = { id: "", Name: "", Address: "" }
    $scope.GetVendorById = function (id) {

        $http.get('http://localhost:51767/api/user' + id).then(function (response) {
            $scope.vendorDetails = response.data;
        });
    }

    $scope.UpdatePayroll = function (id, params) {

       
        if ($scope.bank != null) {
            params.BankName = $scope.bank;
        }


        if ($scope.acct != null) {
            params.AcctNumber = $scope.acct;
        }


        if ($scope.addr != null) {
            params.EmpAddress = $scope.addr;
        }

        console.log($scope.payroll.BankName);
        console.log(id,params);
        $http.put('http://localhost:51767/api/user/' + id, params);


        $location.path('/Payroll');
        $window.location.reload();

        
    }

    //Delete a Vendor
    $scope.Delete = function (id) {
        confirm("Do you want to delete the Vendor")
        $http.delete('http://localhost:51767/api/user/' + id);
    }

    $scope.openModel = function (id,BankName,AcctNumber,EmpAddress) {
        
        var modelInstance = $uibModal.open({
            templateUrl: 'openModal.html',
            controller: 'modelCtrl',
 
            size: 'xs',
            resolve: {
                params: function () {
                    return {
                        PayrollID: id,
                        BankName: BankName,
                        AcctNumber: AcctNumber,
                        EmpAddress: EmpAddress
                    }
                }
            }
        });

        modelInstance.result.then(function (selectedItem) {
            
        }, function () {
            
        });
    }
}]);

    app.controller("loginctrl",function($scope,$http,$location){
        var vm = this;
        $http.get("http://localhost:51767/api/LogIn").then(function(response){
            $scope.agents = response.data;
        }
    );
    $scope.check=function(){
        for (i = 0; i<$scope.agents.length; i++) { 
            if( $scope.username==$scope.agents[i].UserID && $scope.password==$scope.agents[i].Password.trim())
            {
                // $rootScope.allset=true;
                // rootScope.UserSession=$scope.username;

                $location.path('/');
            }

            else{

            }

        }
    }
});

        app.controller("ItemCtrl", ['$scope', '$http','$location','$route', function ($scope, $http,$location,$route) {
     $scope.submitForm = function (form) {
  
     if (form) {       //If Title has some value
         item = {
         "UserID": $scope.item.UserID, 
         "Password": $scope.item.Password, 
         "Role": 'admin',
         "Email": $scope.item.Email,
         "PayrollID": $scope.item.PayrollID,
         "BankName": $scope.item.BankName,
         "EmpName": $scope.item.EmpName,
         "EmpAddress": $scope.item.EmpAddress,
         "EmpPhone": $scope.item.EmpPhone
                }
        
              //This shows that my value is not null
         $http.post("http://localhost:51767/api/user",       
         item
           ).then(function (result) {     //the parameter of API post   
                $location.path('/Payroll');
                $route.reload();
           })
         }
     }
    }]);

    app.controller('demo', function($scope, $http) {  

        $scope.myDataSource = {
            chart: {
                caption: "Money History",
                subCaption: "Money recieved by year",
                numberPrefix: "$",
                theme: "ocean"
            },
            data:[
            {
                label: "Bakersfield Central",
                value: "730000"
            },
            {
                label: "Garden Groove harbour",
                value: "730000"
            },
            {
                label: "Los Angeles Topanga",
                value: "590000"
            },
            {
                label: "Compton-Rancho Dom",
                value: "520000"
            },
            {
                label: "Daly City Serramonte",
                value: "123400"
            }]
        };

            $http.get("http://localhost:51767/api/Values").then(function(data){
                console.log(data);
                $scope.myDataSource.data = data.data;
                console.log($scope.myDataSource);
            })

        });


        // function TestController($scope, $http) {
        //     var data = { "Id": 3, "FirstName": "Test", "LastName": "User", "Username": "testuser", "IsApproved": true, "IsOnlineNow": true, "IsChecked": true };
        //     $http.post(
        //         "http://localhost:53225/api/user",
        //         JSON.stringify(data),
        //         {
        //             headers: {
        //                 'Content-Type': 'application/json'
        //             }
        //         }
        //     ).success(function (data) {
        //         $scope.person = data;
        //     });
        // }

//  app.controller("rem",rem);
//         $scope.join = function () {
//     if (!$scope.joinForm.$valid) return;

//     // Writing it to the server        
//     var res = $http.post( "http://localhost:53225/api/user", $scope.user, { header: { 'Content-Type': 'application/json' } });
//     res.success(function (data, status, headers, config) {
//         $scope.message = data;            
//     });
//     res.error(function (data, status, headers, config) {
//         alert("failure message: " + JSON.stringify({ data: data }));
//     });
// }



//     app.service("demoService",function($http)
// {   
//     getData=function(){
//     return $http.get("http://localhost::59927/api/user");   
//     }
// });

// app.controller("demoCntrl",demoCntrl,demoService)
// function demoCntrl($http,$scope){
//     demoService.getData()
//     .then(function(data){
//         $scope.users=data.data;
//     });

app.controller('modelCtr3', function ($scope,$uibModalInstance, params) {
    console.log(params);
    $scope.params = params;

    $scope.close = function () {
        $uibModalInstance.close("Done");
    }
});