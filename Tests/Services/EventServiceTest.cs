using Moq;
using MyNote.Dtos;
using MyNote.Entities;
using MyNote.Infrastructure;
using MyNote.Repositories;
using MyNote.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Services
{
    [TestFixture]
    class EventServiceTest
    {
        private Mock<IEventsRepository> _eventsRepositoryMock;
        private Mock<IMappingInfrastructure> _mappingInfrastructureMock;
        private EventService _sut;

        [SetUp]
        public void Setup()
        {
            _eventsRepositoryMock = new Mock<IEventsRepository>();
            _mappingInfrastructureMock = new Mock<IMappingInfrastructure>();
            _sut = new EventService(_eventsRepositoryMock.Object, _mappingInfrastructureMock.Object);
        }

        [Test]
        public void Given_ExchangeService_When_GetShowEventViewModelList_Then_Return_2ElementList()
        {
            // given
            _eventsRepositoryMock.Setup(x => x.GetEventList()).Returns(new List<Event>()
            {
                new Event(),
                new Event()
            });
            // when
            var result = _sut.GetShowEventViewModelList();
            // then
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void Given_Exchange_Service_When_GetEventList_And_List_Is_Empty_Then_Return_Empty_NotNULL_List()
        {
            // given
            _eventsRepositoryMock.Setup(x=>x.GetEventList()).Returns(new List<Event>());
            // when
            var result = _sut.GetShowEventViewModelList();
            // then
            Assert.IsNotNull(result);
            Assert.IsEmpty(result);
        }
    }
}
