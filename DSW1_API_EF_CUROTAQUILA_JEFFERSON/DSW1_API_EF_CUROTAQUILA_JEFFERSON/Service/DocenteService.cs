using DSW1_API_EF_CUROTAQUILA_JEFFERSON.dao;
using DSW1_API_EF_CUROTAQUILA_JEFFERSON.Model;

namespace DSW1_API_EF_CUROTAQUILA_JEFFERSON.Service
{
    public class DocenteService
    {

        private iDocentesDAO docenteDao;

        public DocenteService(iDocentesDAO docenteDao)
        {
            this.docenteDao = docenteDao;
        }

        public List<Docentes> ListarDocentes()
        {
            return docenteDao.ListarDocentes();
        }

        public Docentes BuscarDocentePorId(int id)
        {
            return docenteDao.BuscarDocentePorId(id);
        }

        public void RegistrarDocente(Docentes docente)
        {
            docenteDao.RegistrarDocente(docente);
        }

        public void ActualizarDocente(Docentes docente)
        {
            docenteDao.ActualizarDocente(docente);
        }

        public void EliminarDocentePorId(int id)
        {
            docenteDao.EliminarDocentePorId(id);
        }
    }
}
