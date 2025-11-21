using System.Collections.Generic;
using System.Xml;

namespace ScheduleApp
{
    public class DomAnalysisStrategy : IAnalysisStrategy
    {
        public List<Lesson> Analyze(Lesson template, string filePath)
        {
            var results = new List<Lesson>();
            var doc = new XmlDocument();
            doc.Load(filePath);

            var nodes = doc.SelectNodes("//Lesson");
            if (nodes == null) return results;

            foreach (XmlNode node in nodes)
            {
                var lesson = new Lesson
                {
                    Teacher = node.Attributes["Teacher"]?.Value,
                    Subject = node.Attributes["Subject"]?.Value,
                    Auditorium = node.Attributes["Auditorium"]?.Value,
                    Group = node.Attributes["Group"]?.Value,
                    Department = node.Attributes["Department"]?.Value,
                    Faculty = node.Attributes["Faculty"]?.Value,
                    Day = node.Attributes["Day"]?.Value,
                    Time = node.Attributes["Time"]?.Value
                };

                if (IsMatch(lesson, template))
                {
                    results.Add(lesson);
                }
            }
            return results;
        }

        private bool IsMatch(Lesson current, Lesson template)
        {
            if (!string.IsNullOrEmpty(template.Teacher) && current.Teacher != template.Teacher) return false;
            if (!string.IsNullOrEmpty(template.Subject) && current.Subject != template.Subject) return false;
            if (!string.IsNullOrEmpty(template.Auditorium) && current.Auditorium != template.Auditorium) return false;
            if (!string.IsNullOrEmpty(template.Group) && current.Group != template.Group) return false;
            if (!string.IsNullOrEmpty(template.Department) && current.Department != template.Department) return false;
            if (!string.IsNullOrEmpty(template.Faculty) && current.Faculty != template.Faculty) return false;
            if (!string.IsNullOrEmpty(template.Day) && current.Day != template.Day) return false;
            if (!string.IsNullOrEmpty(template.Time) && current.Time != template.Time) return false;
            return true;
        }
    }
}