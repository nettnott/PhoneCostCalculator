using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneCostCalculator;

namespace PhoneCostCalculatorTests
{
    [TestClass]
    public class CalculatorTests
    {
        // TC_FUNC_1: Расчет стоимости для будних дней (менее 30 минут)
        // Длительность: 20 мин, Цена: 5 руб/мин, День: Вторник
        // Ожидаемый результат: 20 * 5 = 100 руб
        [TestMethod]
        public void TC_FUNC_1_WeekdayLessThan30Min()
        {
            double result = CostCalculator.Calculate(20, 5, "Вторник");
            Assert.AreEqual(100.0, result, 0.01, "TC_FUNC_1: Стоимость должна быть 100 руб");
        }

        // TC_FUNC_2: Расчет стоимости для выходных дней (скидка 15%)
        // Длительность: 25 мин, Цена: 4 руб/мин, День: Суббота
        // Ожидаемый результат: (25 * 4) * 0.85 = 85 руб
        [TestMethod]
        public void TC_FUNC_2_WeekendDiscount15Percent()
        {
            double result = CostCalculator.Calculate(25, 4, "Суббота");
            Assert.AreEqual(85.0, result, 0.01, "TC_FUNC_2: Стоимость должна быть 85 руб");
        }

        // TC_FUNC_3: Расчет стоимости для разговора более 30 минут (скидка 30% на остаток)
        // Длительность: 50 мин, Цена: 10 руб/мин, День: Среда
        // Ожидаемый результат: (30 * 10) + (20 * 10 * 0.7) = 300 + 140 = 440 руб
        [TestMethod]
        public void TC_FUNC_3_WeekdayMoreThan30Min()
        {
            double result = CostCalculator.Calculate(50, 10, "Среда");
            Assert.AreEqual(440.0, result, 0.01, "TC_FUNC_3: Стоимость должна быть 440 руб");
        }

        // TC_FUNC_4: Комбинированные скидки (выходной день + более 30 минут)
        // Длительность: 40 мин, Цена: 6 руб/мин, День: Воскресенье
        // Ожидаемый результат: [(30 * 6) + (10 * 6 * 0.7)] * 0.85 = (180 + 42) * 0.85 = 188.7 руб
        [TestMethod]
        public void TC_FUNC_4_WeekendAndMoreThan30Min()
        {
            double result = CostCalculator.Calculate(40, 6, "Воскресенье");
            Assert.AreEqual(188.7, result, 0.01, "TC_FUNC_4: Стоимость должна быть 188.7 руб");
        }

        // TC_BOUND_5: Граничное значение: ровно 30 минут
        // Длительность: 30 мин, Цена: 5 руб/мин, День: Четверг
        // Ожидаемый результат: 30 * 5 = 150 руб (скидка 30% НЕ применяется)
        [TestMethod]
        public void TC_BOUND_5_ExactlyAt30Minutes()
        {
            double result = CostCalculator.Calculate(30, 5, "Четверг");
            Assert.AreEqual(150.0, result, 0.01, "TC_BOUND_5: Стоимость должна быть 150 руб (без скидки на длительность)");
        }

        // Дополнительный тест: проверка воскресенья (тоже выходной)
        [TestMethod]
        public void Sunday_IsWeekend_Discount15Percent()
        {
            double result = CostCalculator.Calculate(10, 10, "Воскресенье");
            // 10 * 10 = 100, с скидкой 15% = 85
            Assert.AreEqual(85.0, result, 0.01, "Воскресенье должно давать скидку 15%");
        }

        // Дополнительный тест: пятница — будний день, без скидки
        [TestMethod]
        public void Friday_IsWeekday_NoDiscount()
        {
            double result = CostCalculator.Calculate(10, 10, "Пятница");
            Assert.AreEqual(100.0, result, 0.01, "Пятница — будний день, скидки нет");
        }
    }
}
