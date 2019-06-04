namespace PsychologicalSupports
{
    public class Enums
    {
        public static int[] GetNumberClass()
        {
            return new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
        }

        public static string[] GetClass()
        {
            return new string[] { "А", "Б", "В", "Г", "Д", "Е", "C" };
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

        public static int[] GetFamilyAlarmAnalysis()
        {
            return new int[] { 0, 1, 2, 3, 4, 5};
        }

        public static int[] GetFamilyAnalysis()
        {
            return new int[] { 0, 1, 2, 3, 4, 5, 6, 7 };
        }

        public static int[] GetSchoolMotivations()
        {
            return new int[] { 0, 1, 2, 3 };
        }

        public static string[] GetRecommendedProfile_8()
        {
            return new string[] {
                "физика",
                "математика",
                "электронная радиотехника",
                "техника ",
                "химия",
                "биология ",
                "медицина ",
                "география и геология  ",
                "история ",
                "филология и журналистика ",
                "искусство ",
                "педагогика ",
                "сфера бытового обслуживания ",
                "военное дело ",
                "спорт ",
                "предпринимательство, бизнес"
            };
        }

        public static string[] GetRecommendedProfile_9()
        {
            return new string[] {
                "Физика",
                "Математика",
                "Химия",
                "Астрономия ",
                "Биология",
                "Медицина ",
                "Сельское хозяйство",
                "Лесное хозяйство",
                "Филология ",
                "Журналистика",
                "История ",
                "Искусство",
                "Геология",
                "География",
                "Общественная деятельность",
                "Транспорт",
                "Педагогика ",
                "Рабочие специальности",
                "Сфера обслуживания",
                "Строительство",
                "Легкая промышленность",
                "Техника",
                "Электроника"
            };
        }
    }
}