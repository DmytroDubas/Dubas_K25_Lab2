using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ScheduleApp
{
    public class XmlProcessor
    {
        private IAnalysisStrategy _analysisStrategy;
        private ITransformStrategy _transformStrategy;

        public XmlProcessor()
        {
            _transformStrategy = new XslTransformStrategy();
        }

        public void SetAnalysisStrategy(IAnalysisStrategy strategy)
        {
            _analysisStrategy = strategy;
        }

        public List<Lesson> Search(Lesson template, string xmlPath)
        {
            if (_analysisStrategy == null)
                throw new System.Exception("Стратегія не обрана.");

            return _analysisStrategy.Analyze(template, xmlPath);
        }

        public void ConvertToHtml(List<Lesson> lessons, string xslPath, string htmlPath)
        {
            string tempXmlPath = "temp_filtered_schedule.xml";
            SaveToXml(lessons, tempXmlPath);
            _transformStrategy.Transform(tempXmlPath, xslPath, htmlPath);
        }

        private void SaveToXml(List<Lesson> lessons, string path)
        {
            var doc = new XDocument(
                new XElement("Schedule",
                    from l in lessons
                    select new XElement("Lesson",
                        new XAttribute("Teacher", l.Teacher ?? ""),
                        new XAttribute("Subject", l.Subject ?? ""),
                        new XAttribute("Auditorium", l.Auditorium ?? ""),
                        new XAttribute("Group", l.Group ?? ""),
                        new XAttribute("Department", l.Department ?? ""),
                        new XAttribute("Faculty", l.Faculty ?? ""),
                        new XAttribute("Day", l.Day ?? ""),
                        new XAttribute("Time", l.Time ?? "")
                    )
                )
            );
            doc.Save(path);
        }

        public List<string> GetUniqueValues(string xmlPath, string attributeName)
        {
            try
            {
                var doc = XDocument.Load(xmlPath);
                return doc.Descendants("Lesson")
                          .Select(x => (string)x.Attribute(attributeName))
                          .Where(val => !string.IsNullOrEmpty(val))
                          .Distinct()
                          .OrderBy(val => val)
                          .ToList();
            }
            catch
            {
                return new List<string>();
            }
        }
    }
}