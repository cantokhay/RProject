using Project.Data.Entities;
using Project.DTO.BasketDTO;

namespace Project.Business.Abstract
{
    public interface IBasketService : IGenericService<Basket>
    {
        public List<ResutBasketWithCustomerNameByIdDTO> TGetBasketByCustomerId(int id);
    }
}
