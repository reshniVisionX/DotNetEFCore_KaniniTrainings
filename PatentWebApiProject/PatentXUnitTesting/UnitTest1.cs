using Moq;
using PatentWebApiProject.DTO;
using PatentWebApiProject.Interface;
using PatentWebApiProject.Models;
using PatentWebApiProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PatentWebApiProject.Tests
{
    public class PatentServiceTests
    {
        private readonly Mock<ICrud<Patent>> _mockCrudPatentRepo;
        private readonly Mock<IPatent> _mockPatentRepo;
        private readonly Mock<ICrud<Members>> _mockCrudMemberRepo;
        private readonly PatentService _service;

        public PatentServiceTests()
        {
            _mockCrudPatentRepo = new Mock<ICrud<Patent>>();
            _mockPatentRepo = new Mock<IPatent>();
            _mockCrudMemberRepo = new Mock<ICrud<Members>>();

           
            _service = new PatentService(
                _mockCrudPatentRepo.Object,
                _mockPatentRepo.Object,
                _mockCrudMemberRepo.Object
            );
        }

        [Fact]
        public async Task GetAllPatents_ReturnsAllPatents()
        {
            var patents = new List<Patent>
            {
                new Patent { patentId = 1, title = "AI Patent" },
                new Patent { patentId = 2, title = "Blockchain Patent" }
            };

            _mockCrudPatentRepo.Setup(r => r.GetAllAsync())
                               .ReturnsAsync(patents);

            var result = await _service.GetAllPatents();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Contains(result, p => p.title == "AI Patent");
            Assert.Contains(result, p => p.title == "Blockchain Patent");
        }

        [Fact]
        public async Task GetPatentById_ReturnsPatent_WhenExists()
        {
            var patent = new Patent { patentId = 1, title = "AI Patent" };

            _mockCrudPatentRepo.Setup(r => r.GetByIdAsync(1))
                               .ReturnsAsync(patent);

            var result = await _service.GetPatentById(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.patentId);
            Assert.Equal("AI Patent", result.title);
        }

        [Fact]
        public async Task GetPatentById_ThrowsException_WhenNotFound()
        {
            _mockCrudPatentRepo.Setup(r => r.GetByIdAsync(99))
                               .ReturnsAsync((Patent)null); 

            var ex = await Assert.ThrowsAsync<Exception>(() => _service.GetPatentById(99));
            Assert.Equal("Patent with ID 99 does not exist.", ex.Message);
        }

        [Fact]
        public async Task GetPatentsByTitle_ReturnsPatents_WhenExists()
        {
            var patents = new List<Patent>
            {
                new Patent { patentId = 1, title = "AI Patent" }
            };

            _mockPatentRepo.Setup(r => r.GetByTitleAsync("AI Patent"))
                           .ReturnsAsync(patents);

            var result = await _service.GetByTitleAsync("AI Patent");

            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("AI Patent", result.First().title);
        }

        [Fact]
        public async Task GetPatentsByTitle_ThrowsException_WhenNotFound()
        {
            _mockPatentRepo.Setup(r => r.GetByTitleAsync("NonExistent"))
                           .ReturnsAsync(new List<Patent>());

            var ex = await Assert.ThrowsAsync<Exception>(() => _service.GetByTitleAsync("NonExistent"));
            Assert.Equal("No patent with title : NonExistent is available", ex.Message);
        }
        [Fact]
        public async Task CreatePatent_ThrowsException_WhenPatentAlreadyExists()
        {
          
            var dto = new PatentDTO { title = "DuplicatePatent", name = "John" };

            _mockPatentRepo.Setup(r => r.GetByTitleAsync(dto.title))
                           .ReturnsAsync(new List<Patent> { new Patent { title = dto.title } });

            var ex = await Assert.ThrowsAsync<Exception>(() => _service.CreatePatent(dto));
            Assert.Equal($"Patent with title '{dto.title}' already exists.", ex.Message);
        }

    }
}
