angular.module('AngularApp.controllers', []).
controller('HeaderController', function($scope, $location){ 
    $scope.isActive = function (viewLocation) { 
        return viewLocation === $location.path();
    };
}).

controller('WidgetsController', function($scope, redVenturesAPI ,$window) {

	redVenturesAPI.getWidgets().success(function (response) {        
		$scope.widgets = response;
	});

	$scope.GoToDetailedPage = function(obj) {			
		$window.location.href = '#widget/' + obj.widget.id;		
	};
}).

controller('WidgetController', function($scope, redVenturesAPI ,$window, $routeParams) {

	var id = $routeParams.id;	
	if (id) {
		$scope.headerText = "Edit";
		$scope.formHeaderText = "Edit Widget";
		redVenturesAPI.getWidget(id).success(function (response) {        
			$scope.name = response.name;
			$scope.color = response.color;		
			$scope.price = response.price;
			$scope.melts = response.melts;
			$scope.inventory = response.inventory;
		});
	}
	else
	{
		$scope.headerText = "Create";
		$scope.formHeaderText = "Create Widget";
	}
	
	$scope.save = function(name, color, price, melts, inventory, $routeParams)
	{		
		var type = "POST";
		if (id) { type = "PUT"; }		
		
		if (redVenturesAPI.InsertWidget("name=" + name + "&color=" + color + "&price=" + price + "&melts=" + melts + "&inventory=" + inventory, type, id))
		{
			alert("Requested was processed successfully!");
			$window.location.href = '#widgets';	
		}
		else
			alert("An error occurred trying to process. Please try again later.");
	}
}).

controller('UsersController', function($scope, redVenturesAPI ,$window) {

	redVenturesAPI.getUsers().success(function (response) {        
		$scope.users = response;
	});

	$scope.GoToDetailedPage = function(obj) {			
		$window.location.href = '#user/' + obj.user.id;		
	};
}).

controller('MenuController', function($scope, redVenturesAPI ,$window) {
	$scope.active = "Dashboard";
}).

controller('UserController', function($scope, redVenturesAPI ,$window, $routeParams) {
	
	var id = $routeParams.id;	
	redVenturesAPI.getUser(id).success(function (response) {        
		$scope.name = response.name;
		$scope.id = response.id;		
		$scope.gravatar = response.gravatar;
	});
}).

controller('IndexController', function($scope, redVenturesAPI, $window) {	
	
	redVenturesAPI.getUsers().success(function (response) {        
		$scope.users = response;
		$scope.usersCount = response.length;
	});
	
	redVenturesAPI.getWidgets().success(function (response) {        
		$scope.widgets = response;
		$scope.widgetsCount = response.length;
	});
	
	$scope.GoToUserDetailedPage = function(obj) {			
		$window.location.href = '#user/' + obj.user.id;
	};
	
	$scope.GoToWidgetDetailedPage = function(obj) {			
		$window.location.href = '#widget/' + obj.widget.id;		
	};
});