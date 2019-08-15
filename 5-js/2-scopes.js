'use strict'; //turns on strict mode for this file
//added by es 5
//we always use it

//strict mode turns bad practices into errors
//such as assigining to undeclared variables
//x =5;

//console.log(x);

//before ES6, we had two scopes for variables ...
//function scope and gloval scope.

function operate(a){
    console.log(abc);//undefined instead of error
    var abc = 'abc'; //function scope
    //not visable outside the function

    //undeclared variables are always gobal scope
    //thanksfully illegal in strict
   // asf = 'asf'
    if (a == undefined) {
        
        var def = 'def';
        //also function scope
        //there is also a behavior called hoisting
        //any declaration inside a function is treated as if its at the top
    }
    console.log(def);
    //
}

operate(4);

//ES6 addded block scoope to JS with Let keyword

function operate2() {
    if(3==3){
        let asdf = 'asdf'
        console.log(asdf);//asdf has block scope
    //decause declared with let
    }
    
}

//always use let instead of var

//const was added same time
//works like let but can never be reassigned

const x = 3;

operate2();

//JS tries to coerce types into each other
//this behavior is fully standerized
//we should be explicit and not rely on that because
//its confusing to read

//except for the boolean conversion
//ex) in an if condition
//in JS most values convert to true and are called truthy
//some convert to false and are claeed falsy

//falsy:
//false
//0
//-0
//NaN
//null & undefined
//empty string is falsy ''

//everything else is truthy

//loose equality and strict equality
//== double equals
//=== triple equales
//also !== and !===

//double equals attempts to compare value equality accross different types
//triple does the right thing, compares both types and value
//use === as the right answer

function compare(a,b) {
    console.log(`${a}==${b}:${a==b}`);
    console.log(`${a}===${b}:${a===b}`);
}

compare(1,'1');

let mkmk = 'hi';