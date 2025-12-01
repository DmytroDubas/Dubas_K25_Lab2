using System.Xml.Xsl;

namespace ScheduleApp
{
  public class XslTransformStrategy : ITransformStrategy
  {
    public void Transform(string xmlPath, string xslPath, string htmlPath)
    {
    var xslt = new XslCompiledTransform();
    xslt.Load(xslPath);
    xslt.Transform(xmlPath, htmlPath);
    }
  }
}