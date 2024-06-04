using ZDZCode_Api.Src.Domain.Entities;

namespace ZDZCode_Api.Src.Domain.Repositories
{
     public interface IBillsRepository
    {
        BillsEntity[] GetAll(string usedID);
        Task<bool> Create(BillsEntity data);
        void Delete(string id);
        BillsEntity Update(string id);
    }
}
