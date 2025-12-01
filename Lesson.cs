using System;

namespace ScheduleApp
{
  public class Lesson
  {
    public string Teacher { get; set; }
    public string Subject { get; set; }
    public string Auditorium { get; set; }
    public string Group { get; set; }
    public string Department { get; set; }
    public string Faculty { get; set; }
    public string Day { get; set; }
    public string Time { get; set; }

    public Lesson() { }

    public override string ToString()
    {
    return $"[{Day} {Time}] {Subject} | {Teacher} | Aud: {Auditorium} | Gr: {Group}";
    }
  }
}