using ZDZCode_Api.Src.Application.Dtos;
using ZDZCode_Api.Src.Domain.Entities;

namespace ZDZCode_Api.Src.Domain.Repositories
{
     public interface IBillsRepository
    {
        BillsEntity[] GetAll(string userID);
        Task<bool> Create(BillsEntity data);
        Task<bool> Delete(Guid id);
        Task<BillsEntity?> Update(Guid id, UpdateBillDto billUpdate );
    }
}
