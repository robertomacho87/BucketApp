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

        [Fact]
        public void RaiseFullEvent()
        {
            Bucket sut = new Bucket();

            var evt = Assert.Raises<FilledEventArgs>(handler => sut.Full += handler, 
                                            handler => sut.Full -= handler, 
                                            ()=> { sut.Fill(110); });

            Assert.Equal(10, evt.Arguments.Overflow);
        }

        [Fact]
        public void FillBucketWithBucket()
        {
            Bucket sut = new Bucket();

            sut.Fill(new Bucket(content: 10));

            Assert.Equal(10, sut.Content);
        }

        [Fact]
        public void EmptyBucket()
        {
            Bucket sut = new Bucket();

            sut.Empty();

            Assert.Equal(0, sut.Content);
        }

        
    }
}
