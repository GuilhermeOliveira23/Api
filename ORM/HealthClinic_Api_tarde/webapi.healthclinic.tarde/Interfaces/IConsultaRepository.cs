using webapi.healthclinic.tarde.Domains;

namespace webapi.healthclinic.tarde.Interfaces
{
    public interface IConsultaRepository
    {
        void Cadastrar(Consulta consulta);
        void Deletar(Guid id);
        void Atualizar(Consulta consulta, Guid id);
        List<Consulta> Listar();

        //Buscar por id medico e paciente
        Consulta BuscarPorIdMedico(Guid id);
        Consulta BuscarPorIdPaciente(Guid id);
        

    }
}
