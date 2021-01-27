using sistemaEscolarNotas.Application.Model;
using sistemaEscolarNotas.Application.Service;
using sistemaEscolarNotas.Domain;
using sistemaEscolarNotas.Domain.Interface;
using System;
using System.Threading.Tasks;

namespace sistemaEscolarNotas.Application
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _repository;

        public AlunoService(IAlunoRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Create(AlunoRequestModel request)
        {
            var aluno = new AlunoEntity(request.NomeAluno, request.Email, request.CPF, request.Telefone);
            var alunoJaExiste = await _repository.VerificarSeJaExisteAluno(aluno.CPF);

            if (alunoJaExiste)
            {
                throw new ArgumentException("Aluno já existe.");
            }
           
            aluno.Validate();
            await _repository.Create(aluno);
            return aluno.Id;
        }

        public async Task<AlunoEntity> Delete(int id)
        {
            var aluno = await _repository.GetById(id);
            if (aluno == null)
            {
                throw new ArgumentException("Id inexistente.");
            }
            aluno.Delete();
            await _repository.Delete(aluno);
            return aluno;
        }

        public async Task<AlunoResponseModel> GetById(int id)
        {
            var aluno = await _repository.GetById(id);
            if (aluno == null)
            {
                throw new ArgumentException("Id de aluno inexistente.");
            }

            var alunoResponseModel = new AlunoResponseModel(aluno);
            return alunoResponseModel;
        }

        public async Task<AlunoEntity> Update(int id, AlunoRequestModel request)
        {
            var aluno = await _repository.GetById(id);
            if (aluno == null)
            {
                throw new ArgumentException("Id do aluno inválido.");
            }

            aluno.Update(request.NomeAluno, request.Email, request.CPF, request.Telefone);
            aluno.Validate();

            var emailJaExiste = await _repository.VerificarSeEmailJaExiste(aluno.Email, aluno.Id);
            if (emailJaExiste)
            {
                throw new ArgumentException("Email já existente.");
            }
            await _repository.Update(aluno);
            return aluno;
        }
    }
}
