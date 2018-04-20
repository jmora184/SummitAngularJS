angular.module('MyAppModule.services', []).factory('Payment', function ($resource) {
    return $resource('api/movies/:id', { id: '@_id' }, {
        update: {
            method: 'PUT'
        }
    });
});