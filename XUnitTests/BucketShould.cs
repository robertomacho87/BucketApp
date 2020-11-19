using BucketApp;
using System;
using Xunit;
using static BucketApp.Container;

namespace XUnitTests
{
    public class BucketShould
    {
        [Fact]
        public void BucketCreateEmptyConstructor()
        {
            //assign
            Bucket sut = new Bucket();

            Assert.True(sut.Capacity == 100);
            Assert.True(sut.Content == 0);
        }

        [Fact]
        public void BucketCreateWithArguments()
        {
            Bucket sut = new Bucket(10, 50);

            Assert.True(sut.Capacity == 50);
            Assert.True(sut.Content == 10);
        }

        [Fact]
        public void FillBucketUnderCapacity()
        {
            Bucket sut = new Bucket();

            sut.Fill(10);

            Assert.Equal(10, sut.Content);
        }

        public void RaiseFilledEvent()
        {
            Bucket sut = new Bucket();

            sut.Fill(100);

            Assert.Raises<FilledEventArgs>(handler => sut.Full += handler);
            
        }
    }
}
