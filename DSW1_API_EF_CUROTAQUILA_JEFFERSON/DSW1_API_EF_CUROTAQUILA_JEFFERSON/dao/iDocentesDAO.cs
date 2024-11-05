using DSW1_API_EF_CUROTAQUILA_JEFFERSON.Model;

namespace DSW1_API_EF_CUROTAQUILA_JEFFERSON.dao
{
    public interface iDocentesDAO
    {
        List<Docentes> ListarDocentes();
        Docentes BuscarDocentePorId(int id);
        void RegistrarDocente(Docentes docente);
        void ActualizarDocente(Docentes docente);
        void EliminarDocentePorId(int id);
    }
}
