// BUS/RestrictionsBUS.cs
using System;
using DAL;

namespace BUS
{
    public class RestrictionsBUS
    {
        private RestrictionsDAL restrictionsDAL;

        public RestrictionsBUS()
        {
            restrictionsDAL = new RestrictionsDAL();
        }

        public bool SaveRestrictions(TimeSpan minFlightTime, int maxTransit, TimeSpan minTransitTime, TimeSpan maxTransitTime, int latestBookingTime, int latestCancelingTime)
        {
            // Thực hiện các logic kiểm tra (nếu có), sau đó gọi DAL để lưu dữ liệu
            return restrictionsDAL.SaveRestrictions(minFlightTime, maxTransit, minTransitTime, maxTransitTime, latestBookingTime, latestCancelingTime);
        }
    }
}
