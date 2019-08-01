using System;
using System.Collections.Generic;
using CollectionTesting.Library;
using System.Text;
using Xunit;

namespace CollectionTesting.Test
{
    //will test all behavior of string collection

    //different kinds of automated test
    //we test individual slices of behavior
    //not whole app/library/class
    //advantaged --if test brakes, then you know exactly what part of code is wronge
    // enfoces better design on the code itself
    
    public class StringCollectionTests
    {
        //each test method should test one thing only
        //everything else it needs to do like set up code is assumed to be correct
        //(those parts should have their own seperate tests)
        [Fact] // the "fact" attribute turns this into a test method visiable to xUnit
        public void CunstructorShouldCreateObject()
        {
            //arranged

            //act
            var collection = new StringCollectionTests();
            //assert
        }

        [Fact]
        public void AddShowAdd()
        {
            //arrange
            var collection = new StringCollection();

            //act
            collection.Add("abc");

            //assert
            //first argument is expected valuse, second is actual value
            Assert.Equal("abc", collection[0]);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        //fact is for zero parameter test
        //theory is for test that we want to un with different values
        // this test will run 3 times with 3 different values
        public void AddShouldAddUnusualValues(string value)
        {
            //arrange
            var collection = new StringCollection();

            //act
            collection.Add(value);

            //assert
            //first argument is expected valuse, second is actual value
            Assert.Equal(value, collection[0]);

        }

        [Fact]
        public void RemoveShouldRemove()
        {
            //arrange
            var collection = new StringCollection();

            //act
            collection.Add("abc");
            collection.Remove("abc");

            //assert
            Assert.True(collection.IsEmpty());

        }

        [Fact]
        public void RemoveShouldReturnFalseIfEmpty()
        {
            //arrange
            var collection = new StringCollection();

            //act

            //assert
            Assert.False(collection.Removebool("abc"));

        }

        [Fact]
        public void GetShouldGetRightItem()
        {
            //arrange
            var collection = new StringCollection();

            //act
            collection.Add("hi");
            collection.Add("bye");

            //assert
            Assert.Equal("hi",collection[0]);

        }

        [Fact]
        public void GetLongestShouldRetrunLongest()
        {
            //arrange
            var collection = new StringCollection();

            //act
            collection.Add("hi");
            collection.Add("bye");

            //assert
            Assert.Equal("bye",collection.GetLongest());

        }
        //[Theory]
        //[InlineData("", "aaa", "antonio","fdda")]
        //[InlineData(null, null, null)]
        //[InlineData("1", "fa", "garr")]
        //public void GetLong(params string[] values)

        [Theory]
        [InlineData("","aaa","antonio")]
        [InlineData(null, null,null)]
        [InlineData("1","fa","garr")]
        public void GetLongestShouldRetrunLongestUnusualValues(string value1,string value2, string value3)
        {
            //arrange
            var collection = new StringCollection();

            //act
            collection.Add(value1);
            collection.Add(value2);
            collection.Add(value3);

            //assert
            Assert.Equal(value3,collection.GetLongest());

        }

        [Fact]
        public void GetAvgLengthShouldReturnAvgLength()
        {
            //arrange
            var collection = new StringCollection();

            //act
            collection.Add("hi");
            collection.Add("byef");

            //assert
            Assert.Equal(3, collection.GetAvrageLength());

        }

        [Fact]
        public void GetNumberOfVowelsShouldReturnNumberOfVowels()
        {
            //arrange
            var collection = new StringCollection();

            //act
            collection.Add("hi");
            collection.Add("abcde");

            //assert
            Assert.Equal(3, collection.GetNumberOfVowle());

        }

        public void TryOutCtor()
        {
            var x = new StringCollection(new[] { "abc", "abc" });
        }

    }
}
