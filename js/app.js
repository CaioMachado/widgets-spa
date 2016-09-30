angular.module('AngularApp', [
  'AngularApp.services',
  'AngularApp.controllers',
  'ngRoute'
]).
config(['$routeProvider', function($routeProvider) {
  $routeProvider.
	when("/", {templateUrl: "partials/dashboard.html"}).
	when("/dashboard", {templateUrl: "partials/dashboard.html"}).
	when("/users", {templateUrl: "partials/users.html"}).	
	when("/widgets", {templateUrl: "partials/widgets.html"}).	
	when("/widget/:id", {templateUrl: "partials/widget.html"}).	
	when("/widget", {templateUrl: "partials/widget.html"}).	
	when("/user/:id", {templateUrl: "partials/user.html"}).
	otherwise({redirectTo: '/'});
}]);