using Arta.Domain.Vehicles;
using Framework.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arta.Application.CongestionTaxHandlers
{
    public static class CalculatorUtility
    {
        public static List<TollYearFree> TollYearFreebies { get; set; }
        public static List<VehiclesType> VehiclesTypes { get; set; }
        public static List<TaxTimePrice> TaxTimePricies { get; set; }
        static CalculatorUtility()
        {
            TollYearFreebies = new List<TollYearFree>()
            {
                new (1,new (){ 1 }),
                new (3,new (){ 28,29 }),
                new (4,new (){ 1,30 }),
                new (5,new (){ 1,8,9 }),
                new (6,new (){ 5,6,21 }),
                new (7,new ()),
                new (11,new (){ 1 }),
                new (12,new (){ 24,25,26,31 }),
            };


            VehiclesType[] allVehicleTypes = Enum.GetValues<VehiclesType>();
            VehiclesTypes = allVehicleTypes.Where(p => p != VehiclesType.NormalVehicle).ToList();


            TaxTimePricies = new List<TaxTimePrice>()
            {
                new (new(6,0,0),new(6,29,0),8),
                new (new(6,30,0),new(6,59,0),13),
                new (new(7,0,0),new(7,59,0),18),
                new (new(8,0,0),new(8,29,0),13),
                new (new(8,30,0),new(14,59,0),8),
                new (new(15,0,0),new(15,29,0),13),
                new (new(15,30,0),new(16,59,0),18),
                new (new(17,0,0),new(17,59,0),13),
                new (new(18,0,0),new(18,29,0),8),
            };
        }
    }
    public class CongestionTaxCalculator
    {
        public List<TaxResult> GetTax(Vehicle vehicle, List<DateTime> dates)
        {
            var groupedDates = dates.GroupBy(p => p.Date).ToList();

            if (IsTollFreeVehicle(vehicle))
                return groupedDates.Select(p => new TaxResult { Date = p.Key, Tax = 0 }).ToList();

            int totalFee = 0;

            var taxes = groupedDates.Select(p =>
            {
                var groupedHours = p.GroupBy(p => p.Hour).ToList();
                var taxes = groupedHours.Select(p =>
                {
                    var maxFee = p.Select(p => GetTollFee(p)).Max();
                    return maxFee;
                });
                totalFee = taxes.Sum();

                if (totalFee > 60) totalFee = 60;

                return new TaxResult { Date = p.Key, Tax = totalFee };
            }).ToList();

            return taxes;
        }

        private bool IsTollFreeVehicle(Vehicle vehicle)
        {
            if (vehicle == null) return false;

            return CalculatorUtility.VehiclesTypes.Any(t => t == vehicle.VehicleType);
        }

        public int GetTollFee(DateTime date)
        {
            if (IsTollFreeDate(date)) return 0;

            var tax = CalculatorUtility.TaxTimePricies.FirstOrDefault(p => IsTimeWithinPeriod(date.TimeOfDay, p.StartTime, p.EndTime));

            if (tax == null) return 0;

            return tax.Price;
        }
        public bool IsTimeWithinPeriod(TimeSpan current, TimeSpan start, TimeSpan end)
        {
            if (end < start)
                return (current > start) && (current < end.Add(new TimeSpan(24, 0, 0)));
            else
                return (current >= start) && (current <= end);
        }
        private Boolean IsTollFreeDate(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return true;

            int year = date.Year;
            int month = date.Month;
            int day = date.Day;

            if (year == 2013)
                return CalculatorUtility.TollYearFreebies.Any(p => p.Month == month && (p.Days.Count == 0 || p.Days.Contains(day)));

            return false;
        }
    }
    public class TaxResult
    {
        public DateTime Date { get; set; }
        public int Tax { get; set; }
    }
    public class TollYearFree
    {
        public TollYearFree(int month, List<int> days)
        {
            Month = month;
            Days = days;
        }

        public int Month { get; set; }

        public List<int> Days { get; set; } = new List<int>();
    }

    public class TaxTimePrice
    {
        public TaxTimePrice(TimeSpan startTime, TimeSpan endTime, int price)
        {
            StartTime = startTime;
            EndTime = endTime;
            Price = price;
        }

        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int Price { get; set; }
    }
}
