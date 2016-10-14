angular.module('AngularApp.services', [])
  .factory('redVenturesAPI', function($http) {

    var redVenturesAPI = {};

    redVenturesAPI.getWidgets = function() {
      return $http({
		type: 'GET',
        url: 'http://spa.tglrw.com:4000/widgets',
		cache: false
      });
    }
	
	redVenturesAPI.getWidget = function(id) {
      return $http({
		type: 'GET',
        url: 'http://spa.tglrw.com:4000/widgets/' + id,
		cache: false
      });
    }
		
    redVenturesAPI.getUsers = function() {
      return $http({
		type: 'GET',
        url: 'http://spa.tglrw.com:4000/users',
		cache: false
      });
    }	

    redVenturesAPI.getUser = function(id) {
      return $http({       
		type: 'GET',
        url: 'http://spa.tglrw.com:4000/users/' + id,
		cache: false
      });
    }		
	
	redVenturesAPI.InsertWidget = function (json, type, id) {
				
		var url = 'http://spa.tglrw.com:4000/widgets';
		if (id)
			url = url + "/" + id;
		return $http({
          method  : type,
          url     : url,
          data    : json,
		  headers : {'Content-Type': 'application/json'}
         })
          .success(function(data) { return true; })
		  .error(function(data) { return false; })		  
        };    

    return redVenturesAPI;
  });