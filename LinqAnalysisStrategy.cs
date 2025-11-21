using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ScheduleApp
{
    public class LinqAnalysisStrategy : IAnalysisStrategy
    {
        public List<Lesson> Analyze(Lesson template, string filePath)
        {
            var doc = XDocument.Load(filePath);

            return doc.Descendants("Lesson")
                .Select(x => new Lesson
                {
                    Teacher = (string)x.Attribute("Teacher"),
                    Subject = (string)x.Attribute("Subject"),
                    Auditorium = (string)x.Attribute("Auditorium"),
                    Group = (string)x.Attribute("Group"),
                    Department = (string)x.Attribute("Department"),
                    Faculty = (string)x.Attribute("Faculty"),
                    Day = (string)x.Attribute("Day"),
                    Time = (string)x.Attribute("Time")
                })
                .Where(l =>
                    (string.IsNullOrEmpty(template.Teacher) || l.Teacher == template.Teacher) &&
                    (string.IsNullOrEmpty(template.Subject) || l.Subject == template.Subject) &&
                    (string.IsNullOrEmpty(template.Auditorium) || l.Auditorium == template.Auditorium) &&
                    (string.IsNullOrEmpty(template.Group) || l.Group == template.Group) &&
                    (string.IsNullOrEmpty(template.Department) || l.Department == template.Department) &&
                    (string.IsNullOrEmpty(template.Faculty) || l.Faculty == template.Faculty) &&
                    (string.IsNullOrEmpty(template.Day) || l.Day == template.Day) &&
                    (string.IsNullOrEmpty(template.Time) || l.Time == template.Time)
                )
                .ToList();
        }
    }
}