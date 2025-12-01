using System.Collections.Generic;

namespace ScheduleApp
{
  public interface IAnalysisStrategy
  {
    List<Lesson> Analyze(Lesson template, string filePath);
  }
}