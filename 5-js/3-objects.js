'use strict';

//console.log(mkmk); from other js

// object literal syntax
let x = {
    id: 4,      //we call these properties
    name:'Bill',
    height: 200
};

x.age = 12;

//debugger; //breakpoint
//console.log(x);

x.sayHello = function () {
    console.log('hello');
}

x.sayHello();

x.sayName = function () {
    // console.log(x.name);
    console.log(this.name);
    //"this" keyword points to whatever value was to the left of dot when we called it
    //(or undefined if there wasnt any dot access)
}

let obj =x;
x=123;

//obj to left of dot
obj.sayName();

let func = obj.sayName;
//func(); //typeError, undefined this

//JS has inheritance without classes
//it has prototypal inheritance:
//inheritance from object to object
//rather than from class to class

obj.__proto__={value: 123};

console.log(obj.age);
console.log(obj.value);

//because property access works this way,
//prototypal inheritance exisits

//whenever you try to access some property
// if its not found it will check the prototype recusevly
//(this doesnt happen with setting properties)
obj.value = 5;

//we dont have classes but we have cunstructors

function Person(name, age) {
    this.name = name;
    this.age = age;

    this.sayName = function (){
        console.log(this.name);
    }
}

// to create an object from a constructor we use 'new'
let sam = new Person('Sam', 26);
// "new runs a function on a new object"
//with this set to that new object
console.log(sam);
sam.sayName = 123;

function Student(name, age, school){
    this.__proto__ = new Person(name,age);
    this.school = school;

    this.isSchoolUta = function () {
        return this.school ==="UTA";
    }
}

let tim = new Student('Tim', 19, 'UTA');
console.log(tim);
tim.sayName();
tim.isSchoolUta();


class Person2 {
    constructor(name, age) {
        this.name = name;
        this.age = age;
        this.sayName = function () {
            console.log(this.name);
        };
    }
    //method syntax also new in ES6 (2015)
    //(works on object literals too)
    sayName(){
        console.log(this.name);
    }
}

class Student2 extends Person2{
    constructor(name,age,school){
        super(name, age);

        this.school = school;
    }

    isSchoolUta() {
        return this.school === 'UTA';
    }
}

let tom = new Student2('Tom', 18, 'WVU');
console.log(tom);

//in JS classes exist but only as syntactic sugar

//arrow functions do not treat "this"
//the dame way all other functions do

//instead of taking "this" from the object to the left
//of the dot when called,
//it takes it form the enviornmentoutside where it was defined

let obj2 = {
    name: 'obj2',
    printer: null,

    printName() {
        console.log(this.name);
    }
};

obj2.printName();