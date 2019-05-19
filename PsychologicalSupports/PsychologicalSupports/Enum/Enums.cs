namespace PsychologicalSupports
{
    public class Enums
    {
        public static int[] GetNumberClass()
        {
            return new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
        }

        public static string[] GetSociometry()
        {
            return new string[] { "Изолированный", "Принятый", "Популярный", "Лидер", "Отвергаемый" };
        }

        public static string[] GetSishoraGroupCohesionIndex()
        {
            return new string[] { "Очень низкая ", "Низкая", "Средняя ", "Высокая ", "Очень высокая" };
        }

        public static string[] GetSelfEsteem()
        {
            return new string[] { "Завышенная ", "Адекватная", "Заниженная " };
        }

        public static string[] GetPersonalPersonalityTest()
        {
            return new string[] { "Меланхолик", "Флегматик", "Сангвиник ", "Холерик" };
        }

        public static string[] GetIQ()
        {
            return new string[] { "Высокий", "Выше среднего", "Средний  ", "Ниже среднего", "Низкий" };
        }

        public static string[] GetANALYSIS_RELATIONSHIPS_TO_SCIENTIST()
        {
            return new string[] { "Активно-положительный", "Положительный", "Безразличный", "Отрицательный ", "Крайне отрицательный " };
        }
    }
}