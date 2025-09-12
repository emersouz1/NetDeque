using System;
using Xunit;
using NetDeque;

namespace NetDeqeue.Tests
{
    public class Dequetests
    {
        [Fact]
        public void GivenNewDeque_WhenCreate_ThenCountShouldBeZero()
        {
            var deque = new Deque<int>();
            Assert.Equal(0, deque.Count);
            Assert.True(deque.IsEmpty);
        }

        [Fact]
        public void GivenDequeVazio_WhenAddBeg_ThenPeekBeg()
        {
            var deque = new Deque<int>();
            deque.AddBeg(17);
            Assert.Equal(17, deque.PeekBeg());

        }

        [Fact]
        public void GivenDequeVazio_WhenAddEnd_ThenPeekEnd()
        {
            var deque = new Deque<int>();
            deque.AddEnd(96);
            Assert.Equal(96, deque.PeekEnd());

        }

        [Fact]
        public void GivenDeque_WhenAddMultiElements_ThenRemBegAndCountShouldUpdate()
        {
            var deque = new Deque<int>();
            deque.AddBeg(17);
            deque.AddBeg(10);
            deque.AddBeg(96);
            deque.AddBeg(200);

            Assert.Equal(200, deque.RemBeg());
            Assert.Equal(96, deque.RemBeg());
            Assert.Equal(10, deque.RemBeg());
            Assert.Equal(17, deque.RemBeg());
            Assert.Equal(0, deque.Count);
        }
        [Fact]
        public void GivenDeque_WhenAddMultiElements_ThenRemEndAndCountShouldUpdate()
        {
            var deque = new Deque<int>();
            deque.AddEnd(17);
            deque.AddEnd(10);
            deque.AddEnd(96);
            deque.AddEnd(200);

            Assert.Equal(200, deque.RemEnd());
            Assert.Equal(96, deque.RemEnd());
            Assert.Equal(10, deque.RemEnd());
            Assert.Equal(17, deque.RemEnd());
            Assert.Equal(0, deque.Count);
        }

        [Fact]
        public void GivenDequeEmpty_WhenRemBeg_ThenReturnException()
        {
            var deque = new Deque<int>();
            Assert.Throws<InvalidOperationException>(() => deque.RemBeg());
        }

        [Fact]
        public void GivenDequeEmpty_WhenRemEnd_ThenReturnException()
        {
            var deque = new Deque<int>();
            Assert.Throws<InvalidOperationException>(() => deque.RemEnd());
        }

        [Fact]
        public void GivenDequeEmpty_WhenPeekBeg_ThenShouldBeException()
        {
            var deque = new Deque<int>();
            Assert.Throws<InvalidOperationException>(() => deque.PeekBeg());
        }

        [Fact]
        public void GivenDequeEmpty_WhenPeekEnd_ThenShouldBeException()
        {
            var deque = new Deque<int>();
            Assert.Throws<InvalidOperationException>(() => deque.PeekEnd());
        }

        [Fact]
        public void GivenDeque_WhenPeekBegOrPeekEnd_ThenElementShouldBeEqualAndCountOne()
        {
            var deque = new Deque<int>();
            deque.AddBeg(1109);

            var begvalue = deque.PeekBeg();
            var endvalue = deque.PeekEnd();

            Assert.Equal(begvalue, endvalue);
            Assert.Equal(1, deque.Count);
        }

        [Fact]
        public void GivenDeque_WhenAddBegAndAddRem_ThenRemoveShouldMantain()
        {
            var deque = new Deque<int>();
            deque.AddBeg(17);
            deque.AddEnd(10);
            deque.AddBeg(96);
            deque.AddEnd(200);

            Assert.Equal(96, deque.RemBeg());
            Assert.Equal(200, deque.RemEnd());
            Assert.Equal(17, deque.RemBeg());
            Assert.Equal(10, deque.RemEnd());
            Assert.True(deque.IsEmpty);
        }

        [Fact]
        public void GivenDeque_WhenAddBegAndAddRemMultiplesElements_ThenRemoveShouldMantain()
        {
            var deque = new Deque<int>();
            int Total = 10;

            for (int i = 0; i < Total; i++)
                deque.AddBeg(i);

            Assert.Equal(Total, deque.Count);
        }

        [Fact]
        public void GivenDeque_WhenAddBegAndAddRemMultiplesElements_ThenRemoveShouldMantain2()
        {
            var deque = new Deque<int>();
            int Total = 10;

            for (int i = 0; i < Total; i++)
                deque.AddBeg(i);
            for (int i = 0; i < Total; i++)
                deque.RemBeg();

            Assert.True(deque.IsEmpty);
        }
    }
}
