using Project.Business.Abstract;
using Project.Data.Entities;
using Project.Data.Enums;
using Project.DataAccess.Abstract;
using Project.DTO.BasketDTO;

namespace Project.Business.Concrete
{
    public class BasketManager : IBasketService
    {
        private readonly IBasketDal _basketDal;

        public BasketManager(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }

		public List<ResutBasketWithCustomerNameByIdDTO> TGetBasketByCustomerId(int id)
		{
			var baskets = _basketDal.GetBasketByCustomerId(id);

			return baskets.Select(b => new ResutBasketWithCustomerNameByIdDTO
			{
				BasketId = b.BasketId,
				Price = b.Price,
				Count = b.Count,
				TotalProductPrice = b.TotalProductPrice,
				ProductId = b.ProductId,
				ProductPrice = b.Product.ProductPrice,
				ProductName = b.Product.ProductName,
				CustomerId = b.CustomerId,
				CustomerName = b.Customer.CustomerName
			}).ToList();
		}

		public void TAdd(Basket entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.DataStatus = DataStatus.Active;
            _basketDal.Add(entity);
        }

        public void TDelete(Basket entity)
        {
			entity.DeletedDate = DateTime.Now;
			entity.DataStatus = DataStatus.Deleted;
			_basketDal.Delete(entity);
        }

        public List<Basket> TGetAll()
        {
            return _basketDal.GetAll().Where(x => x.DataStatus != DataStatus.Deleted).ToList();
		}

        public Basket TGetById(int id)
        {
            return _basketDal.GetById(id);
        }

        public void TUpdate(Basket entity)
        {
            entity.ModifiedDate = DateTime.Now;
            entity.DataStatus = DataStatus.Modified;
            _basketDal.Update(entity);
		}

    }
}
