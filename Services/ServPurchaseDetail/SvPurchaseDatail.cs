using Entidades;
using Microsoft.EntityFrameworkCore;
using Services.Customer;
using Services.MyDbContext;
using Services.Shoe;

namespace Services.ServPurchaseDetail
{
    public class SvPurchaseDatail : ISvPurchaseDatail
    {
        private MyContext _myDbContext = default!;
        private SvShoe _svShoe = default!;
        public SvPurchaseDatail()
        {
            _myDbContext = new MyContext();
            _svShoe = new SvShoe();
        }

        #region Writes
        public PurchaseDetail AddPurchase(PurchaseDetail purchase)
        {
            Entidades.Shoe shoe = _svShoe.GetShoeById(purchase.ShoeId);
            if (shoe.SubtractStock(purchase.Quantity) == false)
            {
                return purchase = null;
            }
            else
            {
                _svShoe.UpdateStock(purchase.ShoeId, shoe);
                purchase.setPrice(shoe);
                _myDbContext.PurchaseDetails.Add(purchase);
                _myDbContext.SaveChanges();

                return purchase;
            }
        }

        public void DeletePurchase(int id)
        {
            PurchaseDetail deletePurchase = _myDbContext.PurchaseDetails.Find(id);
            if (deletePurchase != null)
            {
                _myDbContext.PurchaseDetails.Remove(deletePurchase);
                _myDbContext.SaveChanges();
            }
        }
        public void DeletePurchasesByCustumerId(List<PurchaseDetail> purchaseDetailsCustomer)
        {
            _myDbContext.PurchaseDetails.RemoveRange(purchaseDetailsCustomer);
            _myDbContext.SaveChanges();
        }
        public PurchaseDetail UpdatePurchase(int id, PurchaseDetail purchase)
        {
            PurchaseDetail purchaseUpdate = _myDbContext.PurchaseDetails.Find(id);
            purchaseUpdate.Quantity = purchase.Quantity;

            _myDbContext.Update(purchaseUpdate);
            _myDbContext.SaveChanges();

            return purchaseUpdate;
        }
        #endregion

        #region Reads
        public List<PurchaseDetail> GetAllPurchases()
        {
            return _myDbContext.PurchaseDetails.Include(x => x.Shoe).Include(x => x.Customer).ToList();
        }

        public PurchaseDetail GetPurchaseById(int id)
        {
            return _myDbContext.PurchaseDetails.Include(x => x.Shoe).Include(x => x.Customer).SingleOrDefault(x => x.Id == id);
        }

        public List<PurchaseDetail> GetAllPurchasesByCustumerId(int IdCustumer)
        {
            return _myDbContext.PurchaseDetails.Where(x => x.CustomerId == IdCustumer).ToList();
            //_myDbContext.PurchaseDetails.RemoveRange();
        }
        #endregion
    }
}