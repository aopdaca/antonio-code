'use strict'

//functions as function parameters
// all the time in JS

function output(x,outputFn = console.log) {
    outputFn(x);
}

output(123);

// output(123, alert);

//callback functions
//to some library code
//when you pass a function as a parameter
// and you expect that function to be "called back" later

function addSlowly(a,b,callback) {
    let result = a+b;
    callback(result);
}

//when you get the result, log it to console
addSlowly(1,2,x => console.log(x));

function newCounter(){
    let count = 0;

        return () => count++
    

}



let counter1 = newCounter();
console.log(counter1());
console.log(counter1());

//in JS, functions "close over" any variables they reference, keeping them
//alive even if they would normally be out of
//scoop and removed from memort
//this behavior is called cosure

// another technique is called immidiately invoked function
//expression (IIFE)

(function () {
    let x = 'data';
    console.log(x);
})();

// in JS we dont want to polute the global scope with all our data

//IIFE encsulates some code to run right now

//and throws away the variables in it wonce its done

let library = (function () {
    let privateData = 0;

    function privateFunction(){
        privateData++;
        return privateData;
    }

    return {
        publicData: 22,

        publicFunction(x) {
            return x + privateFunction();
        }
    };
})();

console.log(library.publicFunction(12))