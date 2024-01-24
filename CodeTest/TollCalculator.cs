namespace CodeTest.Vehicles
{
    public class TollCalculator
    {

        /**
         * Calculate the total toll fee for one day
         *
         * @param vehicle - the vehicle
         * @param dates   - date and time of all passes on one day
         * @return - the total toll fee for that day
         */

        public static int GetTollFee(IVehicle vehicle, DateTime[] dates)
        {
            const int maxTotalFee = 60;

            if (dates == null || dates.Length == 0)
            {
                return 0;
            }

            DateTime intervalStart = dates[0];
            int totalFee = 0;

            foreach (DateTime date in dates)
            {
                int nextFee = GetTollFee(date, vehicle);
                int tempFee = GetTollFee(intervalStart, vehicle);

                TimeSpan timeDifference = date - intervalStart;

                if (timeDifference.TotalMinutes <= 60)
                {
                    totalFee = AdjustTotalFee(totalFee, tempFee, nextFee);
                }
                else
                {
                    totalFee += nextFee;
                }
            }

            return Math.Min(totalFee, maxTotalFee);
        }

        private static int AdjustTotalFee(int totalFee, int tempFee, int nextFee)
        {
            if (totalFee > 0)
            {
                totalFee -= tempFee;
            }

            return totalFee + Math.Max(nextFee, tempFee);
        }

        private static bool IsTollFreeVehicle(IVehicle vehicle)
        {
            if (vehicle == null) return false;
            string vehicleType = vehicle.GetVehicleType().ToString();
            return vehicleType.Equals(TollFreeVehicles.Motorbike.ToString()) ||
                   vehicleType.Equals(TollFreeVehicles.Tractor.ToString()) ||
                   vehicleType.Equals(TollFreeVehicles.Emergency.ToString()) ||
                   vehicleType.Equals(TollFreeVehicles.Diplomat.ToString()) ||
                   vehicleType.Equals(TollFreeVehicles.Foreign.ToString()) ||
                   vehicleType.Equals(TollFreeVehicles.Military.ToString());
        }

        public static int GetTollFee(DateTime date, IVehicle vehicle)
        {
            if (IsTollFreeDate(date) || IsTollFreeVehicle(vehicle))
                return 0;

            int hour = date.Hour;
            int minute = date.Minute;

            if (IsInTimeRange(hour, minute, 6, 0, 29)) return 8;
            if (IsInTimeRange(hour, minute, 6, 30, 59)) return 13;
            if (IsInTimeRange(hour, minute, 7, 0, 59)) return 18;
            if (IsInTimeRange(hour, minute, 8, 0, 29)) return 13;
            if (IsInTimeRange(hour, minute, 8, 30, 59)) return 8;
            if (IsInTimeRange(hour, minute, 15, 0, 29)) return 13;
            if (IsInTimeRange(hour, minute, 15, 0, 59) || IsInTimeRange(hour, minute, 16, 0, 59)) return 18;
            if (IsInTimeRange(hour, minute, 17, 0, 59)) return 13;
            if (IsInTimeRange(hour, minute, 18, 0, 29)) return 8;

            return 0;
        }

        private static bool IsInTimeRange(int currentHour, int currentMinute, int targetHour, int startMinute, int endMinute)
        {
            return currentHour == targetHour && currentMinute >= startMinute && currentMinute <= endMinute;
        }

        private static bool IsTollFreeDate(DateTime date)
        {

            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                return true;


            int year = date.Year;
            int month = date.Month;
            int day = date.Day;

            if (date.Month == 7)
                return true;

            var holidays = new List<DateTime>
        {
        new(year, 1, 1),
        new(year, 3, 28),
        new(year, 3, 29),
        new(year, 4, 1),
        new(year, 4, 30),
        new(year, 5, 1),
        new(year, 5, 8),
        new(year, 5, 9),
        new(year, 6, 5),
        new(year, 6, 6),
        new(year, 6, 21),
        new(year, 11, 1),
        new(year, 12, 24),
        new(year, 12, 25),
        new(year, 12, 26)
        };

            if (holidays.Contains(date.Date))
                return true;

            return false;
        }

        private enum TollFreeVehicles
        {
            Motorbike = 0,
            Tractor = 1,
            Emergency = 2,
            Diplomat = 3,
            Foreign = 4,
            Military = 5
        }
    }
}