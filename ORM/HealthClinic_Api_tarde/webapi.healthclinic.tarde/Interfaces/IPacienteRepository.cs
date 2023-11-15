using webapi.healthclinic.tarde.Domains;

namespace webapi.healthclinic.tarde.Interfaces
{
    public interface IPacienteRepository
    {
        void Cadastrar(Paciente paciente);
        void Deletar(Guid id);
        void Atualizar(Paciente paciente, Guid id);
        List<Paciente> ListarComConsulta();
    }
}
