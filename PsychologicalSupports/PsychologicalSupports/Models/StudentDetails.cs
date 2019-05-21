using System;
using System.ComponentModel.DataAnnotations;

namespace PsychologicalSupports.Models
{
    public class StudentDetails
    {
        public long StudentID { get; set; }
        [Display(Name = "ФИО")]
        public string FIO { get; set; }
        [Display(Name = "Номер класса")]
        public Nullable<int> NumberClass { get; set; }
        [Display(Name = "Класс")]
        public string Class { get; set; }
        [Display(Name = "Дата поступления")]
        public Nullable<System.DateTime> AdmissionDate { get; set; }
        [Display(Name = "Обучается")]
        public string BeingTrained { get; set; }
        [Display(Name = "Средний балл")]
        public string AveragePoint { get; set; }
        [Display(Name = "Взаимоотношения в классе")]
        public string ClassroomRelationship { get; set; }
        [Display(Name = "Информация классного руководителя")]
        public string ClassTeacheInformation { get; set; }
        [Display(Name = "Тест эмоций")]
        public string EmotioTest { get; set; }
        [Display(Name = "Анализ семейной тревоги")]
        public string FamilyAlarmAnalysi { get; set; }
        [Display(Name = "6 класс")]
        public string Intellectual_6_Class { get; set; }
        [Display(Name = "7 класс")]
        public string Intellectual_7_Class { get; set; }
        [Display(Name = "8 класс")]
        public string Intellectual_8_Class { get; set; }
        [Display(Name = "9 класс")]
        public string Intellectual_9_Class { get; set; }
        [Display(Name = "Карта интересов  145")]
        public string Interests_Card_145 { get; set; }
        [Display(Name = "Карта интересов 50")]
        public string Interests_Card_50 { get; set; }
        [Display(Name = "Интересующие школьные предметы")]
        public string InterestsInSchoolSubject { get; set; }
        [Display(Name = "Mindset")]
        public string Mindset { get; set; }
        [Display(Name = "Шкала личностной тревоги")]
        public string PersonaAnxietyScale { get; set; }
        [Display(Name = "Личностный тест Айзенко")]
        public string PersonalProtagonistAizenko { get; set; }
        [Display(Name = "Школьная мотивация")]
        public string SchoolMotivation { get; set; }
        [Display(Name = "Самооценка")]
        public string Self_esteem { get; set; }
    }
}