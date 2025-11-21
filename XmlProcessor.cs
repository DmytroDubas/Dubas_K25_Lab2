using System.Collections.Generic;

namespace ScheduleApp
{
    public class XmlProcessor
    {
        private IAnalysisStrategy _analysisStrategy;
        private ITransformStrategy _transformStrategy;

        public XmlProcessor()
        {
            // дефолтна стратегія
            _transformStrategy = new XslTransformStrategy();
        }

        public void SetAnalysisStrategy(IAnalysisStrategy strategy)
        {
            _analysisStrategy = strategy;
        }

        public List<Lesson> Search(Lesson template, string xmlPath)
        {
            if (_analysisStrategy == null)
                throw new System.Exception("Analysis strategy not selected.");

            return _analysisStrategy.Analyze(template, xmlPath);
        }

        public void ConvertToHtml(string xmlPath, string xslPath, string htmlPath)
        {
            _transformStrategy.Transform(xmlPath, xslPath, htmlPath);
        }
    }
}