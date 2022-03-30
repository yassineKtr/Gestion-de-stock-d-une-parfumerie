using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using ParfumerieServices.Repositories;
using ParfumerieServices.Services;
using Xunit;

namespace ParfumerieServices.Tests
{
    public class PerfumeServicesShould
    {
        [Fact]
        public void ShouldAddPerfume()
        {
            //Arrange
            var service = new Mock<IPerfumeServices>();
            //Act
           
            //Assert
        }
    }
}
