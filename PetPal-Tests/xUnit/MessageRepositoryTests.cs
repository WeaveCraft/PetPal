using Microsoft.EntityFrameworkCore;
using Moq;
using PetPal_Business.Helpers;
using PetPal_Business.Repositories;
using PetPal_Business.Repositories.Interfaces;
using PetPal_DataAccess.Data;
using PetPal_Model.DTOs;
using PetPal_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PetPal_Tests.xUnit
{
    public class MessageRepositoryTests
    {
        private readonly Mock<IMessageRepository> _messageRepositoryMock;
        private readonly IMessageRepository _sut;

        public MessageRepositoryTests()
        {
            var testMessage = new Message
            {
                Id = 1,
                SenderUsername = "SenderUsername",
                RecipientId = 1,
                RecipientUsername = "RecipientUsername",
                Content = "Message Content",
                DateRead = DateTime.Now,
                MessageSent = DateTime.Now
            };

            _messageRepositoryMock = new Mock<IMessageRepository>();
            _messageRepositoryMock.Setup(x => x.GetMessage(1)).ReturnsAsync(testMessage);

            _sut = _messageRepositoryMock.Object;
        }

        [Fact]
        public void AddMessageTest()
        {
            // Arrange
            var testMessage = new Message
            {
                Id = 1,
                SenderUsername = "SenderUsername",
                RecipientId = 1,
                RecipientUsername = "RecipientUsername",
                Content = "Message Content",
            };

            // Act
            _sut.AddMessage(testMessage);

            // Assert
            _messageRepositoryMock.Verify(x => x.AddMessage(It.IsAny<Message>()), Times.Once);
            Assert.IsType<Message>(testMessage);
        }

        [Fact]
        public async Task GetMessage()
        {
            // Arrange
            var expectedMessage = new Message
            {
                Id = 1,
                SenderUsername = "SenderUsername",
                RecipientId = 1,
                RecipientUsername = "RecipientUsername",
                Content = "Message Content",
            };

            // Act
            var result = await _sut.GetMessage(1);

            // Assert
            Assert.Equal(expectedMessage.Id, result.Id);
            Assert.Equal(expectedMessage.SenderUsername, result.SenderUsername);
            Assert.Equal(expectedMessage.RecipientId, result.RecipientId);
            Assert.Equal(expectedMessage.RecipientUsername, result.RecipientUsername);
            Assert.Equal(expectedMessage.Content, result.Content);
        }
    }
}
