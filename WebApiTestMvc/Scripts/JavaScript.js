var MyProd = function () {
    var member = undefined;
    var createInstance = function () {
        member = "Narendhar Reddy Pannala";
    }
    var getInstance = function () {
        return member;
    }
}();
function Calling() {
    MyProd.getInstance()
}
Calling();