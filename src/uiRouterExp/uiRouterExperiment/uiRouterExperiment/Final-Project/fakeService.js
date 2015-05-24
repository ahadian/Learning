angular.module('finalProject').service('fakeService', function () {
    var books = [];
    books.push({
        id: 1,
        Name: "Bangla Literature",
        Author: "Humayun Ahmed"
    });
    books.push(
         {
             id: 2,
             Name: "English Literature",
             Author: "Shahruk Khan"
         });
    books.push(
         {
             id: 3,
             Name: "Hindi Literature",
             Author: "Barak Obama"
         });
    var getMyBooks = function () {
        return books;
    }
    var getBookbyId = function(id) {
        return books[id-1];
    }
    return {
        GetBooks: getMyBooks,
        GetbyId: getBookbyId
    }
});