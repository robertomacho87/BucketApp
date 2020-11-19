using BucketApp;
using System;
using Xunit;
using static BucketApp.Container;

namespace XUnitTests
{
    public class BucketShould
    {
        private readonly Bucket _sut;

        public BucketShould()
        {
            _sut = new Bucket();
        }
           
        [Fact]
        public void BucketCreateEmptyConstructor()
        {
            Assert.True(_sut.Capacity == 100);
            Assert.True(_sut.Content == 0);
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

            _sut.Fill(10);

            Assert.Equal(10, _sut.Content);
        }

        [Fact]
        public void RaiseFullEvent()
        {
            var evt = Assert.Raises<FilledEventArgs>(handler => _sut.Full += handler, 
                                            handler => _sut.Full -= handler, 
                                            ()=> { _sut.Fill(110); });

            Assert.Equal(10, evt.Arguments.Overflow);
        }

        [Fact]
        public void FillBucketWithBucket()
        {
            _sut.Fill(new Bucket(content: 10));

            Assert.Equal(10, _sut.Content);
        }

        [Fact]
        public void EmptyBucket()
        {
            _sut.Empty();

            Assert.Equal(0, _sut.Content);
        }
    }
}
