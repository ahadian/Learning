angular.module('restDemo').service('restService', ['$resource', '$q', function ($resource, $q) {
    var fGetArray = function (url) {
        var deferred = $q.defer();
        var serverRestApi = $resource(url, {}, { get: { method: 'GET', isArray: true} });
        serverRestApi.get(
            function (response) {
                //console.log('This is response : ');
                //console.log(response);
                return deferred.resolve(response);
            },
            function (error) {
                //console.log(response);
                return deferred.reject(error);
            });
        return deferred.promise;
    }

    var fGetIntStringObject = function (url) {
        var deferred = $q.defer();
        var serverRestApi = $resource(url, { age: 20, name: 'def' }, { get: { method: 'GET', isArray: false } });
        serverRestApi.get(
            function (response) {
                //console.log('This is response : ');
                //console.log(response);
                return deferred.resolve(response);
            },
            function (error) {
                //console.log(response);
                return deferred.reject(error);
            });
        return deferred.promise;
    }

    var fPostObject = function (url) {
        var deferred = $q.defer();
        var serverRestApi = $resource(url);
        var newperson = { PersonId: 3, PersonName: "jkl", PersonPhoneNumber: "101112", PersonAge: 28 };
        serverRestApi.save(newperson,
            function (response) {
                console.log('This is response : ');
                console.log(response);
                return deferred.resolve(response.$resolved);
            },
            function (error) {
                //console.log(response);
                return deferred.reject(error);
            });
        return deferred.promise;
    }

    var fPutIdObject = function (url) {
        var deferred = $q.defer();
        var serverRestApi = $resource(url, { id: 0 }, { anything: { method: 'PUT' } });
        var updatedPerson = { PersonId: 0, PersonName: "abc", PersonPhoneNumber: "x123", PersonAge: 50 };
        serverRestApi.anything(updatedPerson,
            function (response) {
                console.log('This is response : ');
                console.log(response);
                return deferred.resolve(response.$resolved);
            },
            function (error) {
                //console.log(response);
                return deferred.reject(error);
            });
        return deferred.promise;
    }

    var fDeleteId = function (url) {
        var deferred = $q.defer();
        var serverRestApi = $resource(url, { id: 13 }, { boom: { method: 'DELETE' } });
        serverRestApi.boom(
            function (response) {
                //console.log('This is response : ');
                //console.log(response);
                return deferred.resolve(response.$resolved);
            },
            function (error) {
                //console.log(response);
                return deferred.reject(error);
            });
        return deferred.promise;
    }
    //fDeleteId

    return {
        Get_Array: fGetArray,
        Get_IntString_Object: fGetIntStringObject,
        Post_Object: fPostObject,
        Put_Id_Object: fPutIdObject,
        Delete_Id: fDeleteId
        //delete: restDelete,
        //count: restCount,
        //save: restSave,
        //update: restUpdate
    }
}]);