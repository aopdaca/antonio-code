console.log("hello world!");

//JS runs in the browser
//Client side
//every modern browser has a JS engine (runtime)
//chrome's: V8

//there is also server side JS-Node.JS
//Node.Js or Node is pretty much V8

//Js has been standerized ads ECMAScript
//Versions of JS
// ECMA Script versions pre-5
//ES5 <---- is the baseline for all modern browser
//ES6 (ES2015) <--- 98% of modern browser usage
//ES7 (ES2016)
//etc 
//Know features in 5 & 6

//Js is multi-paradigm
//Sort of OO (Object Based)
//Has objects but no classes
    //until es6
    //lot of support for functional programming 

//JS is weakly typed/loosely-typed
//     Variables do not have types
//      Any varialbe can contain any value but values do have types

//there are 7 types in JS (6 before ES6)
var x;
//default value of a new variable
//is undefined
//this type has one value, undefined
x = undefined;

x = null;
//null is its own type with  one possible value, null.
//type of says it is type object for historical reasons.

//Number tyoes
x = 1;
x = 1.5;
//in js number is basically double
//IEEE 94-bit floting point number
x = Infinity;
x = -Infinity;
x = Math.pow(10, 1000); //Infinity
x = 4/0 ; // infinity
x = NaN;
x = 4/ -Infinity; //-0
x = 4 + true;//5...
x = 'aasd'/3; 
    //NAN
//console.log(NaN == NaN); // use isNaN to heck for NaN

//boolean type
x = true;
x = (3 == 4) || (4<5); //true
x = false;

//string
x = 'ab\'c'; //backslash standard way to escape things
x = "abc";
x = 'abc'.indexOf('b');
//string interpolation syntax or
//template literals
x = `backtick string new in ES6 ${12 + 3}`

//object type
x = console;
x = {};
x = {'name': 'Ant'};
x = x.name;
x = x['name']; //indexing-type axxess instead of dot access
var y = {}
x = {name: y};

//functions are typeof object
//function statemant way to define function
function add(a, b = 5){
    return a+b;
}

//function expression
var multiply = function (a,b){
    return a*b;
};

//arrow function added in ES6
var divide = (a,b) => a/b; 

x = add(3,2);//function arguments
//can ass fewer or more than defined
//return types can be anything

//x = (a => {console.log(a); })('4');

//with ES 6 we can give default parameters  to args

x = add(4);
x = [1,2,3]; //arrays are objects, danamic like c#
//List
//es6 addes sets and maps

//our 7th type, Symbol, added in ES6



console.log(x);
console.log(typeof x);



//similar to EQL, semicolons are optional in JS
//"semicolon injection"

//many c-style controll flow stuff

if (condition) {
    
}

if (condition) {
    
} else {
    
}

do {
    
} while (condition);

switch (key) {
    case value:
        
        break;

    default:
        break;
}
for (let index = 0; index < array.length; index++) {
    const element = array[index];
    
}
for (const iterator of object) {
    
}

