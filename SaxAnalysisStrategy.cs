using System.Collections.Generic;
using System.Xml;

namespace ScheduleApp
{
  public class SaxAnalysisStrategy : IAnalysisStrategy
  {
    public List<Lesson> Analyze(Lesson template, string filePath)
    {
    var results = new List<Lesson>();
    using (var reader = new XmlTextReader(filePath))
    {
      while (reader.Read())
      {
        if (reader.NodeType == XmlNodeType.Element && reader.Name == "Lesson")
        {
        var lesson = new Lesson
        {
          Teacher = reader.GetAttribute("Teacher"),
          Subject = reader.GetAttribute("Subject"),
          Auditorium = reader.GetAttribute("Auditorium"),
          Group = reader.GetAttribute("Group"),
          Department = reader.GetAttribute("Department"),
          Faculty = reader.GetAttribute("Faculty"),
          Day = reader.GetAttribute("Day"),
          Time = reader.GetAttribute("Time")
        };

        if (IsMatch(lesson, template))
        {
          results.Add(lesson);
        }
        }
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