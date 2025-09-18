using System;
using Xunit;
using FluentAssertions;
using NetDeque;

namespace NetDeqeue.Tests
{
    public class Dequetests
    {
        [Fact]
        public void GivenNewDeque_WhenCreate_ThenCountShouldBeZero()
        {
            //Arrange
            var deque = new Deque<int>();

            //Act
            var count = deque.Count;
            var isEmpty = deque.IsEmpty;
            
            //Assert
            
            //Assert.Equal(0, deque.Count);
            //Assert.True(deque.IsEmpty);

            count.Should().Be(0);
            isEmpty.Should().BeTrue();

        }

        [Fact]
        public void GivenDequeVazio_WhenAddBeg_ThenPeekBeg()
        {
            //Arrange
            var deque = new Deque<int>();

            //Act
            deque.AddBeg(17);
            var value = deque.PeekBeg();

            //Assert
            
            //Assert.Equal(17, deque.PeekBeg());

            value.Should().Be(17);
        }

        [Fact]
        public void GivenDequeVazio_WhenAddEnd_ThenPeekEnd()
        {
            //Arrange
            var deque = new Deque<int>();

            //Act
            deque.AddEnd(96);
            var value = deque.PeekEnd();

            //Assert
            //Assert.Equal(96, deque.PeekEnd());

            value.Should().Be(96);
        }

        [Fact]
        public void GivenDeque_WhenAddMultiElements_ThenRemBegAndCountShouldUpdate()
        {
            //Arrange
            var deque = new Deque<int>();
            deque.AddBeg(17);
            deque.AddBeg(10);
            deque.AddBeg(96);
            deque.AddBeg(200);

            //Act
            var first = deque.RemBeg();
            var second = deque.RemBeg();
            var third = deque.RemBeg();
            var fourth = deque.RemBeg();
            var count = deque.Count;


            //Assert

            //Assert.Equal(200, deque.RemBeg());
            //Assert.Equal(96, deque.RemBeg());
            //Assert.Equal(10, deque.RemBeg());
            //Assert.Equal(17, deque.RemBeg());
            //Assert.Equal(0, deque.Count);
               
            first.Should().Be(200);
            second.Should().Be(96);
            third.Should().Be(10);
            fourth.Should().Be(17);
            count.Should().Be(0);

        }
        [Fact]
        public void GivenDeque_WhenAddMultiElements_ThenRemEndAndCountShouldUpdate()
        {
            //Arrange
            var deque = new Deque<int>();

            deque.AddEnd(17);
            deque.AddEnd(10);
            deque.AddEnd(96);
            deque.AddEnd(200);

            //Act
            var first = deque.RemEnd();
            var second = deque.RemEnd();
            var third = deque.RemEnd();
            var fourth = deque.RemEnd();
            var count = deque.Count;

            //Assert

            //Assert.Equal(200, deque.RemEnd());
            //Assert.Equal(96, deque.RemEnd());
            //Assert.Equal(10, deque.RemEnd());
            //Assert.Equal(17, deque.RemEnd());
            //Assert.Equal(0, deque.Count);

            first.Should().Be(200);
            second.Should().Be(96);
            third.Should().Be(10);
            fourth.Should().Be(17);
            count.Should().Be(0);

        }

        [Fact]
        public void GivenDequeEmpty_WhenRemBeg_ThenReturnException()
        {
            //Arrange
            var deque = new Deque<int>();

            //Act
            var exception = Record.Exception(() => deque.RemBeg());

            //Assert

            //Assert.Throws<InvalidOperationException>(() => deque.RemBeg());

            exception.Should().BeOfType<InvalidOperationException>();
        }

        [Fact]
        public void GivenDequeEmpty_WhenRemEnd_ThenReturnException()
        {
            //Arrange
            var deque = new Deque<int>();

            //Act
            var exception = Record.Exception(() => deque.RemEnd());

            //Assert

            //Assert.Throws<InvalidOperationException>(() => deque.RemEnd());

            exception.Should().BeOfType<InvalidOperationException>();

        }

        [Fact]
        public void GivenDequeEmpty_WhenPeekBeg_ThenShouldBeException()
        {
            //Arrange
            var deque = new Deque<int>();

            //Act
            var exception = Record.Exception(() => deque.PeekBeg());

            //Assert

            //Assert.Throws<InvalidOperationException>(() => deque.PeekBeg());
            
            exception.Should().BeOfType<InvalidOperationException>();

        }

        [Fact]
        public void GivenDequeEmpty_WhenPeekEnd_ThenShouldBeException()
        {
            //Arrange
            var deque = new Deque<int>();

            //Act
            var exception = Record.Exception(() => deque.PeekBeg());

            //Assert

            //Assert.Throws<InvalidOperationException>(() => deque.PeekEnd());

            exception.Should().BeOfType<InvalidOperationException>();
        }

        [Fact]
        public void GivenDeque_WhenPeekBegOrPeekEnd_ThenElementShouldBeEqualAndCountOne()
        {
            //Arrange
            var deque = new Deque<int>();
            deque.AddBeg(1109);

            //Act
            var begvalue = deque.PeekBeg();
            var endvalue = deque.PeekEnd();
            var count = deque.Count;

            //Assert

            //Assert.Equal(begvalue, endvalue);
            //Assert.Equal(1, deque.Count);

            begvalue.Should().Be(endvalue);
            count.Should().Be(1);
        }

        [Fact]
        public void GivenDeque_WhenAddBegAndAddRem_ThenRemoveShouldMantain()
        {
            //Arrange
            var deque = new Deque<int>();

            //Act
            deque.AddBeg(17);
            deque.AddEnd(10);
            deque.AddBeg(96);
            deque.AddEnd(200);


            //Assert
            Assert.Equal(96, deque.RemBeg());
            Assert.Equal(200, deque.RemEnd());
            Assert.Equal(17, deque.RemBeg());
            Assert.Equal(10, deque.RemEnd());
            Assert.True(deque.IsEmpty);
        }

        [Fact]
        public void GivenDeque_WhenAddBegAndAddRemMultiplesElements_ThenRemoveShouldMantain()
        {
            //Arrange
            var deque = new Deque<int>();

            int Total = 10;

            //Act
            for (int i = 0; i < Total; i++)
                deque.AddBeg(i);

            //Assert

            //Assert.Equal(Total, deque.Count);

            deque.Count.Should().Be(Total);
        }

        [Fact]
        public void GivenDeque_WhenAddBegAndAddRemMultiplesElements_ThenRemoveShouldMantain2()
        {
            //Arrange
            var deque = new Deque<int>();

            int Total = 10;

            //Act
            for (int i = 0; i < Total; i++)
                deque.AddBeg(i);
            for (int i = 0; i < Total; i++)
                deque.RemBeg();


            //Assert

            //Assert.True(deque.IsEmpty);

            deque.IsEmpty.Should().BeTrue();
        }
    }
}
