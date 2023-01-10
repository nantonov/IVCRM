using IVCRM.BLL.Models.Interfaces;

namespace IVCRM.BLL.Services.Interfaces
{
    public interface IBaseService<TModel> where TModel : IModel
    {
        Task<TModel> Create(TModel model);
        Task<IEnumerable<TModel>> GetAll();
        Task<TModel> GetById(int id);
        Task<TModel> Update(TModel model);
        Task Delete(int id);
        Task<bool> IsEntityExists(int id);
    }
}
