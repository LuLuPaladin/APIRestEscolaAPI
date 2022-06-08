using EstudoAPI.Application.Services;
using EstudoAPI.Domain.Interfaces;
using NSubstitute;
using System;
using Xunit;

namespace EstudoAPI.Test.Services
{
    public class ProfessorServiceTests
    {
        private readonly IProfessorRepository _professorRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IDisciplinaRepository _disciplinaRepository;
        private readonly ProfessorService _professorService;

        public ProfessorServiceTests()
        {
            _professorRepository =  Substitute.For<IProfessorRepository>();
            _alunoRepository = Substitute.For<IAlunoRepository>();
            _disciplinaRepository = Substitute.For<IDisciplinaRepository>();
            _professorService = new ProfessorService(_professorRepository, _alunoRepository, _disciplinaRepository);
        }

        [Fact]
        public void TentaAssociarAlunoRetornoSucesso()
        {
            var response = _professorService.AssociarAluno(1, 2);

            Assert.True(response);
            
        }

        [Fact]
        public void TentaAssociarAlunoRetornoFracasso()
        {
            var response = _professorService.AssociarAluno(0, 0);

            Assert.False(response);

        }


    }
}
