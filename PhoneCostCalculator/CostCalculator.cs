using System;

namespace PhoneCostCalculator
{
    public class CostCalculator
    {
        // Основной метод расчёта стоимости
        public static double Calculate(int duration, double pricePerMinute, string dayOfWeek)
        {
            bool isWeekend = dayOfWeek == "Суббота" || dayOfWeek == "Воскресенье";

            double cost;

            // Скидка 30% на минуты после 30-й
            if (duration <= 30)
            {
                cost = duration * pricePerMinute;
            }
            else
            {
                double first30 = 30 * pricePerMinute;
                double rest = (duration - 30) * pricePerMinute * 0.7;
                cost = first30 + rest;
            }

            // Скидка 15% в выходные дни
            if (isWeekend)
            {
                cost = cost * 0.85;
            }

            return Math.Round(cost, 2);
        }
    }
}
