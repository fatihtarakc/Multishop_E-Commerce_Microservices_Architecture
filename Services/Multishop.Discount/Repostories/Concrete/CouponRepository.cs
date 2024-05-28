using Dapper;
using Multishop.Discount.Data.Context;
using Multishop.Discount.Data.Entities;
using Multishop.Discount.Repostories.Abstract;

namespace Multishop.Discount.Repostories.Concrete
{
    public class CouponRepository : ICouponRepository
    {
        private readonly DiscountContext db;
        public CouponRepository(DiscountContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddAsync(Coupon coupon)
        {
            var query = "insert into Coupons (Id, Code, Rate, IsActive, ExpirationDate) values (@couponId, @code, @rate, @isActive, @expirationDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", Guid.NewGuid());
            parameters.Add("@code", coupon.Code);
            parameters.Add("@rate", coupon.Rate);
            parameters.Add("@isActive", coupon.IsActive);
            parameters.Add("@expirationDate", coupon.ExpirationDate);

            try
            {
                using (var conn = db.CreateConnection())
                {
                    return await conn.ExecuteAsync(query, parameters) > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Guid couponId)
        {
            var query = "delete from Coupons where Id = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", couponId);

            try
            {
                using (var conn = db.CreateConnection())
                {
                    return await conn.ExecuteAsync(query, parameters) > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Guid couponId, bool isActive)
        {
            var query = "update Coupons set IsActive = @isActive where Id = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", couponId);
            parameters.Add("@isActive", isActive);

            try
            {
                using (var conn = db.CreateConnection())
                {
                    return await conn.ExecuteAsync(query, parameters) > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Coupon coupon)
        {
            var query = "update Coupons set Code = @code, Rate = @rate, IsActive = @isActive, ExpirationDate = @expirationDate where Id = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", coupon.Id);
            parameters.Add("@code", coupon.Code);
            parameters.Add("@rate", coupon.Rate);
            parameters.Add("@isActive", coupon.IsActive);
            parameters.Add("@expirationDate", coupon.ExpirationDate);

            try
            {
                using (var conn = db.CreateConnection())
                {
                    return await conn.ExecuteAsync(query, parameters) > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<Coupon> GetByAsync(Guid couponId)
        {
            var query = "select * from Coupons where Id = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", couponId);

            try
            {
                using (var conn = db.CreateConnection())
                {
                    return await conn.QueryFirstOrDefaultAsync<Coupon>(query, parameters);
                }
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Coupon>> GetAllAsync()
        {
            var query = "select * from Coupons";

            try
            {
                using (var conn = db.CreateConnection())
                {
                    return (await conn.QueryAsync<Coupon>(query)).ToList();
                }
            }
            catch
            {
                return null;
            }
        }
    }
}