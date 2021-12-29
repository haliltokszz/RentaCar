using System.Threading.Tasks;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace DataAccess.Concrete
{
    public class UnitofWork : IUnitofWork
    {
        private readonly RentaCarContext _context;

        public UnitofWork()
        {
            _context = new RentaCarContext();
        }

        public IUserDal Users => new EfUserDal();
        public ICarDal Cars => new EfCarDal();
        public ICompanyDal Companies => new EfCompanyDal();
        public ICustomerDal Customers => new EfCustomerDal();
        public IRentalDal Rentals => new EfRentalDal();
        public IBrandDal Brands => new EfBrandDal();
        public ICarImageDal CarImages => new EfCarImageDal();
        public IColorDal Colors => new EfColorDal();
        public IFindeksDal Findekses => new EfFindeksDal();
        public IOperationClaimDal OperationClaims => new EfOperationClaimDal();
        public IUserOperationClaimDal UserOperationClaims => new EfUserOperationClaimDal();

        public async Task<bool> Save()
        {
            var isSuccess = await _context.SaveChangesAsync() > 0;
            return isSuccess;
        }

        public void Dispose()
        {
            _context?.DisposeAsync();
        }
    }
}